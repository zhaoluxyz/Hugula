// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Text;
using LuaInterface;
using System.Text.RegularExpressions;

/// <summary>
/// author:ricky蒲
/// QQ:32145628
/// </summary>
public class ToLuaCSEditor
{

    private const string OutLuaPath = "ToLuaCS/Export/";
    //private const string OutLuaPath1 = "Script/ToLuaCS/";


    [MenuItem("Assets/ToLuaCS/Generate FullClass LuaToCS(xxx)", false, 2)]
    static void ExportLuaToCSP()
    {
        UnityEngine.Object[] objs = Selection.objects;

        foreach (var o in objs)
        {
            if (o is MonoScript || o is UnityEngine.TextAsset)
            {
                ExportFullCalssMtLua(o.name, OutLuaPath);
            }
            else if (isDirectory(o))
            {
                string path = AssetDatabase.GetAssetPath(o);
                List<string> dic = getAllChildFiles(path);
                string classname = string.Empty;
                foreach (string k in dic)
                {
                    classname = CUtils.GetURLFileName(k);
                    ExportFullCalssMtLua(classname, OutLuaPath);
                }
            }
            //Debug.Log(o.name + " " + o.GetType().FullName + " isDirectory :" + isDirectory(o));
        }
    }

    [MenuItem("Assets/ToLuaCS/Generate DeclaredOnly LuaToCS(xxx)", false, 1)]
    static void ExportLuaToCSP1()
    {
        UnityEngine.Object[] objs = Selection.objects;

        foreach (var o in objs)
        {
            if (o is MonoScript || o is UnityEngine.TextAsset)
            {
                ExportDeclaredOnlyClassMtLua(o.name, OutLuaPath);
            }
            else if (isDirectory(o))
            {
                string path = AssetDatabase.GetAssetPath(o);
                List<string> dic = getAllChildFiles(path);
                string classname = string.Empty;
                foreach (string k in dic)
                {
                    classname = CUtils.GetURLFileName(k);
                    ExportDeclaredOnlyClassMtLua(classname, OutLuaPath);
                }
            }
            //ExportDeclaredOnlyClassMtLua(o.name, OutLuaPath);
        }
    }

    [MenuItem("Assets/ToLuaCS/LuaToCS Start Class", false, 5)]
    [MenuItem("ToLuaCS/Generate Start Class ", false, 3)]
    static void ExprotLuatoStartClass()
    {
        StringBuilder sbTmp = new StringBuilder();
        sbTmp.AppendLine("using System.Collections;");
        sbTmp.AppendLine("using UnityEngine;");
        sbTmp.AppendLine("using Lua = LuaInterface.LuaState;");
        sbTmp.AppendLine("using LuaDLL = LuaInterface.LuaDLL;");
        sbTmp.AppendLine("using LuaState = System.IntPtr;");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("public static class ToLuaCSStart  { ");
        sbTmp.AppendLine("  ");
        sbTmp.AppendLine("  public static void Start(LuaState L){");
        sbTmp.AppendLine("  ");
        var assembly = typeof(ToLuaCS).Assembly;
        System.Type[] types = assembly.GetTypes();
        List<System.Type> buildType = new List<Type>();
        foreach (var t in types)
        {
            if (t.FullName.StartsWith("LuaTo"))
            {
                string name = t.FullName.Replace("LuaTo", "").Replace("_", ".");
                var t1 = GetTypeByName(name);
                buildType.Add(t1);
            }
        }

        System.Type tmp = null;
        System.Type not = null;

        for (int i = 0; i < buildType.Count; i++)
        {
            not = buildType[i];
            for (int j = 0; j < i - 1; j++)
            {
                if (IsSuperClass(not, buildType[j])) //如果j是j+1的父类 J>J+1
                {
                    tmp = buildType[j];
                    buildType[i] = tmp;// buildType[j];
                    buildType[j] = not;// buildType[j + 1];
                    not = tmp;
                }
            }
        }

        buildType.Reverse();

        foreach (var t in buildType)
        {
            sbTmp.AppendLine("      LuaTo" + t.FullName.Replace(".", "_") + ".CreateMetaTableToLua(L);");
        }

        sbTmp.AppendLine("  }");
        sbTmp.AppendLine("}");

        string classTname = "ToLuaCSStart";
        string path = Application.dataPath + "/ToLuaCS/" + classTname.Replace(".", "_") + ".cs";
        checkLuaToCSExportPath();
        using (StreamWriter sr = new StreamWriter(path, false))
        {
            sr.WriteLine(sbTmp.ToString());
        }
        Debug.Log(sbTmp.ToString());
    }

    [MenuItem("Assets/ToLuaCS/LuaToCS Clear Start Class", false, 5)]
    [MenuItem("ToLuaCS/Clear Start Class ", false, 3)]
    static void ClearStartClass()
    {
        StringBuilder sbTmp = new StringBuilder();
        sbTmp.AppendLine("using System.Collections;");
        sbTmp.AppendLine("using UnityEngine;");
        sbTmp.AppendLine("using Lua = LuaInterface.LuaState;");
        sbTmp.AppendLine("using LuaDLL = LuaInterface.LuaDLL;");
        sbTmp.AppendLine("using LuaState = System.IntPtr;");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("public static class ToLuaCSStart  { ");
        sbTmp.AppendLine("  ");
        sbTmp.AppendLine("  public static void Start(LuaState L){");
        sbTmp.AppendLine("  ");

        sbTmp.AppendLine("  }");
        sbTmp.AppendLine("}");

        string classTname = "ToLuaCSStart";
        string path = Application.dataPath + "/ToLuaCS/" + classTname.Replace(".", "_") + ".cs";
        checkLuaToCSExportPath();
        using (StreamWriter sr = new StreamWriter(path, false))
        {
            sr.WriteLine(sbTmp.ToString());
        }
        Debug.Log(sbTmp.ToString());
    }

    [MenuItem("Assets/", false, 1)]
    static void Breaker() { }
    #region v0.3.0 bata

    private static void ExportFullCalssMtLua(string name, string OutLuaPath)
    {
        StringBuilder st = new StringBuilder();
        System.Type t = GetTypeByName(name);
        if (t != null)
        {
            List<List<string>> methods = FilterMethod(t, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            Build_Class(st, t);
            Build_CreateMetaTableToLua(st, t, methods[0], methods[1]);
            //Build_DeclareLuaFn(st, t, methods[0], methods[1]);
            Build_Methods(st, t, methods[0], methods[1]);
            Build_ClassEnd(st);
            Build_ClassFile(st, t, OutLuaPath);
            //Debug.Log(st.ToString()); 
        }
        else
        {
            Debug.Log(" ExportFullCalssMtLua null :" + name);
        }
    }

    private static void ExportDeclaredOnlyClassMtLua(string name, string OutLuaPath)
    {
        StringBuilder st = new StringBuilder();
        System.Type t = GetTypeByName(name);
        if (t != null)
        {
            List<List<string>> methods = FilterMethod(t, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
            Build_Class(st, t);
            Build_CreateMetaTableToLua(st, t, methods[0], methods[1]);
            //Build_DeclareLuaFn(st, t, methods[0], methods[1]);
            Build_Methods(st, t, methods[0], methods[1]);
            Build_ClassEnd(st);
            Build_ClassFile(st, t, OutLuaPath);
            //Debug.Log(st.ToString());

        }
        else
        {
            Debug.Log(" GetTypeByName null :" + name);
        }

    }
    /// <summary>
    /// 过滤要生成的字段
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    private static List<List<string>> FilterMethod(System.Type t, BindingFlags flags)
    {
        List<List<string>> methodInfos = new List<List<string>>();
        //非静态方法
        methodInfos.Add(new List<string>());
        List<string> instances = methodInfos[0];
        //静态方法
        methodInfos.Add(new List<string>());
        List<string> statics = methodInfos[1];

        MemberInfo[] fields = t.GetMembers(flags);//BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public
        Dictionary<string, bool> addedMemberInfo = new Dictionary<string, bool>();

        //bool breakOne = false;
        foreach (MemberInfo fInfo in fields)
        {
            //Debug.Log(fInfo.GetType().Name+ "   " + fInfo.DeclaringType.Name );
            //fInfo.DeclaringType == typeof(Delegate)
            if (!fInfo.Name.Contains("op_") && !fInfo.Name.StartsWith("add_") && !fInfo.Name.StartsWith("remove_") && !IsObsoleteAttribute(fInfo)) //去掉操作函数 扔掉 unity3d 废弃的函数
            {

                if (!addedMemberInfo.ContainsKey(fInfo.Name) && (fInfo.MemberType == MemberTypes.Method || (fInfo.MemberType == MemberTypes.Constructor && !t.IsAbstract)))
                {
                    bool isPr = (fInfo.Name.StartsWith("set_") || fInfo.Name.StartsWith("get_"));
                    string realName = "";
                    MemberInfo checkInfo = fInfo;
                    if (isPr)
                    {
                        realName = fInfo.Name.Replace("set_", "").Replace("get_", "");
                        MemberInfo[] infos = t.GetMember(realName);
                        if (infos.Length > 0)
                        {
                            checkInfo = infos[0];
                            if (IsObsoleteAttribute(checkInfo)) continue;
                        }
                    }
                    //Debug.Log("add method "+realName);
                    if (fInfo.MemberType == MemberTypes.Method && ((MethodInfo)fInfo).IsStatic)
                    {
                        statics.Add(fInfo.Name);
                        addedMemberInfo[fInfo.Name] = ((MethodInfo)fInfo).IsStatic;
                    }
                    else if (fInfo.MemberType == MemberTypes.Constructor)
                    {
                        statics.Add(fInfo.Name);
                        addedMemberInfo[fInfo.Name] = true;
                    }
                    else
                    {
                        instances.Add(fInfo.Name);
                        addedMemberInfo[fInfo.Name] = false;
                    }

                }
                else if (!addedMemberInfo.ContainsKey(fInfo.Name) && fInfo.MemberType == MemberTypes.Field)
                {

                    string getmethName = "get_" + fInfo.Name;
                    string setmethName = "set_" + fInfo.Name;
                    bool canSet = ((FieldInfo)fInfo).IsLiteral;
                    if (((FieldInfo)fInfo).IsStatic)
                    {
                        statics.Add(getmethName);
                        if (canSet == false)
                            statics.Add(setmethName);
                    }
                    else
                    {
                        instances.Add(getmethName);
                        if (canSet == false)
                            instances.Add(setmethName);
                    }
                    //Debug.Log(fInfo.Name);
                    addedMemberInfo[fInfo.Name] = ((FieldInfo)fInfo).IsStatic;
                }
            }
        }

        return methodInfos;
    }

    private static void Build_Class(StringBuilder sbTmp, System.Type t)
    {
        string classTname = t.FullName.Replace(".", "_");
        sbTmp.AppendLine("using System.Collections;");
        sbTmp.AppendLine("using LuaInterface;");
        sbTmp.AppendLine("using Lua = LuaInterface.LuaState;");
        sbTmp.AppendLine("using LuaDLL = LuaInterface.LuaDLL;");
        sbTmp.AppendLine("using LuaState = System.IntPtr;");
        sbTmp.AppendLine("using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;");
        sbTmp.AppendLine("using LuaCSFunction = LuaInterface.LuaCSFunction;");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("public static class LuaTo" + classTname + " {");
        sbTmp.AppendLine("");
    }
    private static void Build_CreateMetaTableToLua(StringBuilder sbTmp, System.Type t, List<string> instances, List<string> statics)
    {
        string classTname = t.FullName;
        sbTmp.AppendLine("  public static void CreateMetaTableToLua(LuaState L) {");
        sbTmp.AppendLine("");
        sbTmp.AppendLine("       System.Type t= typeof(" + classTname + ");");
        sbTmp.AppendLine("       if(!ToLuaCS.CreateMetatable(L,t)){");
        sbTmp.AppendLine("          return;");
        sbTmp.AppendLine("      }");

        if (instances.Count > 0)
        {
            sbTmp.AppendLine("      #region  注册实例luameta");
            foreach (string mname in instances)
            {
                sbTmp.AppendLine("           ToLuaCS.AddMember(L, \"" + mname + "\", " + mname + ");");
            }
            sbTmp.AppendLine("      #endregion");
            sbTmp.AppendLine("");
        }

        if (statics.Count > 0)
        {
            sbTmp.AppendLine("  #region  static method       ");
            sbTmp.AppendLine("          ToLuaCS.CreateToLuaCSTable(L, t);");

            foreach (string mname in statics)
            {
                string mname1 = GetSafeMethodName(t, mname);
                if (mname.ToLower().Equals(".ctor"))
                {
                    sbTmp.AppendLine("           ToLuaCS.AddMember(L, \"__call\", " + mname1 + ");");
                }
                else
                {
                    sbTmp.AppendLine("           ToLuaCS.AddMember(L, \"" + mname1 + "\", " + mname1 + ");");
                }
                sbTmp.AppendLine("");
            }

            sbTmp.AppendLine("#endregion       ");
        }
        sbTmp.AppendLine("}");

    }
    private static void Build_DeclareLuaFn(StringBuilder sbTmp, System.Type t, List<string> instances, List<string> statics)
    {

        sbTmp.AppendLine("  #region instances declaration       ");
        foreach (string mname in instances)
        {
            sbTmp.AppendLine("          private static LuaCSFunction luafn_" + mname + ";");
        }
        sbTmp.AppendLine(" #endregion        ");

        sbTmp.AppendLine("  #region statics declaration       ");
        foreach (string mname in statics)
        {
            string mname1 = GetSafeMethodName(t, mname);
            sbTmp.AppendLine("          private static LuaCSFunction luafn_" + mname1 + ";");
        }
        sbTmp.AppendLine(" #endregion        ");
    }
    private static void Build_Methods(StringBuilder sbTmp, System.Type t, List<string> instances, List<string> statics)
    {
        #region 生成绑定方法
        sbTmp.AppendLine("  #region  instances method       ");
        foreach (string method in instances)
        {
            BuildMethod(sbTmp, t, method, false);
        }
        #endregion
        sbTmp.AppendLine("  #endregion       ");
        sbTmp.AppendLine("  #region  static method       ");
        foreach (string method in statics)
        {
            BuildMethod(sbTmp, t, method, true);
        }
        sbTmp.AppendLine("  #endregion       ");
    }
    private static void Build_ClassEnd(StringBuilder sbTmp)
    {
        sbTmp.AppendLine("}");
    }
    private static void Build_ClassFile(StringBuilder sbTmp, System.Type t, string outPutPath)
    {
        string classTname = t.FullName;
        string path = Application.dataPath + "/" + outPutPath + "LuaTo" + classTname.Replace(".", "_") + ".cs";
        checkLuaToCSExportPath();
        using (StreamWriter sr = new StreamWriter(path, false))
        {
            sr.WriteLine(sbTmp.ToString());
        }
        Debug.Log(sbTmp.ToString());
    }

    private static void BuildMethod(StringBuilder sbTmp, System.Type t, string name, bool isStatic)
    {
        bool isGet = name.StartsWith("get_");
        bool isSet = name.StartsWith("set_");
        string realName =string.Empty;

        if (isGet || isSet)
        {
            realName = name.Substring(4, name.Length - 4);
        }
        else
        {
            realName = name;
        }

        MemberInfo[] infos = t.GetMember(name);
        if (infos.Length == 0) infos = t.GetMember(realName);
        name = GetSafeMethodName(t, name);

        //方法头
        sbTmp.AppendLine("          ");
        sbTmp.AppendLine("          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sbTmp.AppendLine("          public static int " + name + "(LuaState L)");
        sbTmp.AppendLine("          {");
        if (infos.Length > 1)
        {
            sbTmp.AppendLine("                  int argLength = LuaDLL.lua_gettop(L);");
        }
        System.Array.Sort(infos, CompareParByLength);

        Dictionary<int, List<MemberInfo>> groups = new Dictionary<int, List<MemberInfo>>();

        //group
        foreach (var inf in infos)
        {

            if (inf is MethodInfo || inf is ConstructorInfo)
            {
                MethodBase mInfo = ((MethodBase)inf);
                int leng = mInfo.GetParameters().Length;
                if (!groups.ContainsKey(leng))
                {
                    groups[leng] = new List<MemberInfo>();
                }
                groups[leng].Add(inf);
            }
            else
            {
                if (!groups.ContainsKey(-1))
                {
                    groups[-1] = new List<MemberInfo>();
                }
                groups[-1].Add(inf);
            }
        }

        int i = 0;//begin index
        int realyMethodCount = 0;
        List<MemberInfo> mems = null;
        bool iselse = false;
        foreach (KeyValuePair<int, List<MemberInfo>> kv in groups)
        {
            if (kv.Key == -1)
            {
                mems = kv.Value;

                foreach (var inf in mems)
                {
                    if (isStatic)
                        i = 1;
                    else
                        i = 2;
                    FieldInfo fInfo = ((FieldInfo)inf);

                    sbTmp.AppendLine(GetFieldStr(t, fInfo, i, fInfo.IsStatic, isGet));
                }
            }
            else
            {
                mems = kv.Value;
                if (isStatic)
                    i = 1;
                else
                    i = 2;

                int addi = 0;
                
                if (infos.Length > 1)
                {
                    if (infos[0] is ConstructorInfo)
                    {
                        addi = 1;
                    }
                    if(iselse)
                        sbTmp.AppendLine("               else if(ToLuaCS.CheckArgLength(argLength," + (kv.Key + i - 1 + addi) + ")){");
                    else
                        sbTmp.AppendLine("               if(ToLuaCS.CheckArgLength(argLength," + (kv.Key + i - 1 + addi) + ")){");
                }

                foreach (var inf in mems)
                {
                    MethodBase mInfo = ((MethodBase)inf);
                    if (mInfo.ContainsGenericParameters)
                    {
                        realyMethodCount++;
                        continue;
                    }
                    ParameterInfo[] pars = mInfo.GetParameters();

                    if (mems.Count > 1)
                    {
                        sbTmp.AppendLine("               " + GetIFStr(pars, i + addi) + "{");
                    }
                    sbTmp.AppendLine(GetParStr(pars, i + addi));
                    sbTmp.AppendLine(GetCallMethod(t, mInfo, pars, i, mInfo.IsStatic));
                    if (mems.Count > 1)
                    {
                        sbTmp.AppendLine("               }");
                    }
                }

                if (infos.Length > 1)
                {
                    sbTmp.AppendLine("                 }");
                }

                iselse = true;
            }
        }

        if (infos.Length > 1 || realyMethodCount>0)
            sbTmp.AppendLine("               return 0;");

        sbTmp.AppendLine("          }");
      
    }

    [System.Obsolete("use BuildMethod")]
    private static void BuildMethodByNameNew(StringBuilder sbTmp, System.Type t, string name, bool isStatic)
    {
        string realName = name.Replace("get_", "").Replace("set_", "");
        MemberInfo[] infos = t.GetMember(name);
        if (infos.Length == 0) infos = t.GetMember(realName);
        bool isGet = name.StartsWith("get_");
        bool isSet = name.StartsWith("set_");

        name = GetSafeMethodName(t, name);
        //方法头
        sbTmp.AppendLine("          ");
        sbTmp.AppendLine("          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sbTmp.AppendLine("          public static int " + name + "(LuaState L)");
        sbTmp.AppendLine("          {");
        sbTmp.AppendLine("               int argLength = LuaDLL.lua_gettop(L);");


        System.Array.Sort(infos, CompareParByLength);
        string allIf = "";
        int i = 1;
        int realyMethodCount = 0;
        foreach (MemberInfo inf in infos)
        {
            i = 2;
            if (isStatic) i = 1;
            if (inf is MethodInfo)
            {
                allIf = "";
                MethodBase mInfo = ((MethodBase)inf);
                if (mInfo.ContainsGenericParameters)
                {
                    realyMethodCount++;
                    continue;
                }
                ParameterInfo[] pars = mInfo.GetParameters();
                if (infos.Length > 1)
                {
                    allIf = GetIFStr(pars, i);
                }
                if (allIf != "") //&& !allIf.Contains("true")
                {
                    sbTmp.AppendLine("              " + allIf);
                    sbTmp.AppendLine("              {");
                }

                sbTmp.AppendLine(GetParStr(pars, i));

                sbTmp.AppendLine(GetCallMethod(t, mInfo, pars, i, mInfo.IsStatic));
                if (allIf != "")
                {
                    sbTmp.AppendLine("              }");
                }
                realyMethodCount++;
            }
            else if (inf is ConstructorInfo)
            {
                allIf = "";
                MethodBase mInfo = ((MethodBase)inf);
                if (mInfo.ContainsGenericParameters)
                {
                    realyMethodCount++;
                    continue;
                }
                ParameterInfo[] pars = mInfo.GetParameters();
                if (infos.Length > 1)
                {
                    allIf = GetIFStr(pars, i + 1);
                }
                if (allIf != "")
                {
                    sbTmp.AppendLine("              " + allIf);
                    sbTmp.AppendLine("              {");
                }

                sbTmp.AppendLine(GetParStr(pars, i + 1));

                sbTmp.AppendLine(GetCallMethod(t, mInfo, pars, i, mInfo.IsStatic));
                if (allIf != "")
                {
                    sbTmp.AppendLine("              }");
                }
                realyMethodCount++;
            }
            else if (inf is FieldInfo)
            {
                FieldInfo fInfo = ((FieldInfo)inf);
                sbTmp.AppendLine(GetFieldStr(t, fInfo, i, fInfo.IsStatic, isGet));
            }
        }

        if (realyMethodCount > 1)
            sbTmp.AppendLine("          return 0;");

        sbTmp.AppendLine("          }");


    }
    private static string GetIFStr(ParameterInfo[] pars, int i)
    {
        string allIf = "";
        string split = "";

        if (pars.Length >= 1)
        {
            allIf = "if(";

            foreach (ParameterInfo pinfo in pars)
            {
                System.Type pt = pinfo.ParameterType;
                if (pt == typeof(string))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")==LuaTypes.LUA_TSTRING ";
                }
                else if (pt == typeof(Boolean))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")==LuaTypes.LUA_TBOOLEAN ";//LuaTypes.LUA_TNUMBER
                }
                else if (pt == typeof(uint) || pt == typeof(UInt16) || pt == typeof(UInt32) || pt == typeof(UInt64)
                        || pt == typeof(Int16) || pt == typeof(Int32) || pt == typeof(Int64)
                        || pt == typeof(Single) || pt == typeof(Double) || pt == typeof(Byte) || pt == typeof(Char))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")==LuaTypes.LUA_TNUMBER ";//LuaTypes.LUA_TNUMBER
                }
                else if (pt == typeof(LuaCSFunction))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")==LuaTypes.LUA_TFUNCTION ";//LuaTypes.LUA_TFUNCTION
                }
                else if (pt == typeof(LuaTable))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")== LuaTypes.LUA_TTABLE";
                }
                else if (pt == typeof(LuaFunction))
                {
                    allIf += split + " LuaDLL.lua_type(L," + i + ")== LuaTypes.LUA_TFUNCTION";
                }
                else
                {
                    //allIf += split + getObject(pt, i) + " is " + GetSafeTypeString(pt) + "";
                    allIf += split + IsTypeObject(pt, i);
                    //allIf += split + " ToLuaCS.getObject(L, " + i + ") is " + GetSafeTypeString(pt) + "";
                }

                i++;
                split = " &&";
            }

            allIf += ")";
        }
        else
        {
            allIf = "if(true)";
        }
        return allIf;
    }
    /// <summary>
    /// 生成调用参数
    /// </summary>
    /// <param name="pinfo"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    private static string GetParStr(ParameterInfo[] pars, int i)
    {
        StringBuilder re = new StringBuilder();
        foreach (ParameterInfo pinfo in pars)
        {

            System.Type t = pinfo.ParameterType;
            if (t == typeof(string))
            {
                re.AppendLine("                  " + pinfo.ParameterType + " " + GetSafeParName(pinfo.Name) + " =  LuaDLL.lua_tostring(L," + i + "); \r\n");
            }
            else if (t == typeof(Boolean))
            {
                re.AppendLine("                  " + pinfo.ParameterType + " " + GetSafeParName(pinfo.Name) + " =  LuaDLL.lua_toboolean(L," + i + ");");
            }
            else if (t == typeof(uint) || t == typeof(UInt16) || t == typeof(UInt32) || t == typeof(UInt64)
             || t == typeof(Int16) || t == typeof(Int32) || t == typeof(Int64)
             || t == typeof(Single) || t == typeof(Double) || t == typeof(Byte) || t == typeof(Char))
            {
                re.AppendLine("                  " + pinfo.ParameterType + " " + GetSafeParName(pinfo.Name) + " = (" + t + ")LuaDLL.lua_tonumber(L," + i + ");");
            }
            else
            {
                re.AppendLine("                  " + GetSafeTypeString(pinfo.ParameterType) + " " + GetSafeParName(pinfo.Name) + " = (" + GetSafeTypeString(pinfo.ParameterType) + ")" + getObject(pinfo.ParameterType, i) + ";");
                //re.AppendLine("                  " + GetSafeTypeString(pinfo.ParameterType) + " " + GetSafeParName(pinfo.Name) + " = (" + GetSafeTypeString(pinfo.ParameterType) + ")ToLuaCS.getObject(L," + i + ");");
            }
            i++;
        }
        return re.ToString();
    }
    private static string GetCallMethod(System.Type t, MethodBase mInfo, ParameterInfo[] pars, int i, bool isStatic)
    {
        StringBuilder sbTmp = new StringBuilder();
        string classTname = t.FullName;

        string parstr = "";
        string sp = "";
        string target = "";
        int returncout = 0;
        //out 参数
        List<ParameterInfo> outpars = new List<ParameterInfo>();

        foreach (ParameterInfo pinfo in pars)
        {
            if (pinfo.ParameterType.ToString().Contains("&"))
            {
                System.Type s = GetTypeByName(GetSafeTypeString(pinfo.ParameterType));
                //Debug.Log(pinfo.Name + " ParameterType = " +s.FullName + "  IsRetval=" + pinfo.IsRetval + " IsOut= " + pinfo.IsOut + " IsValueType = " + s.IsValueType);
                if (s.IsValueType)
                    parstr += sp + " ref " + GetSafeParName(pinfo.Name);
                else
                    parstr += sp + " out " + GetSafeParName(pinfo.Name);
                outpars.Add(pinfo);
                returncout++;
            }
            else
            {
                parstr += sp + " " + GetSafeParName(pinfo.Name);
            }
            sp = ",";
            //i++;
        }

        bool isPro = false;
        string proName = mInfo.Name;
        if (mInfo.Name.StartsWith("set_") || mInfo.Name.StartsWith("get_")) isPro = true;
        if (isPro)
        {
            proName = mInfo.Name.Replace("set_", "").Replace("get_", "");
            //Debug.Log(" method "+proName + " isStatic = " + isStatic);
        }

        string returnType = "";
        bool hasReturn = false;
        if (mInfo is MethodInfo)
        {
            if (!isStatic)
            {
                //sbTmp.AppendLine("                  object original = ToLuaCS.getObject(L, 1);");
                sbTmp.AppendLine("                   var original = " + getObject(t, 1) + ";");
                //getObject
                sbTmp.AppendLine("                  " + classTname + " target= (" + classTname + ") original ;");
                target = "target";
            }
            else
            {
                target = classTname;
            }

            System.Type returnT = ((MethodInfo)mInfo).ReturnType;
            returnType = GetSafeTypeString(returnT);
            hasReturn = ((MethodInfo)mInfo).ReturnType != typeof(void);

            if (hasReturn == false)
            {
                if (isPro)
                {
                    if (pars.Length > 1)
                    {
                        string[] items = parstr.Split(new char[] { ',' });
                        sbTmp.AppendLine("                  " + target + "[ " + items[0] + "]=" + items[1] + ";");
                    }
                    else
                        sbTmp.AppendLine("                  " + target + "." + proName + "=" + parstr + ";");
                }
                else
                {
                    sbTmp.AppendLine("                  " + target + "." + mInfo.Name + "(" + parstr + ");");
                }
                //sbTmp.AppendLine("                 return 0;");
            }
            else
            {
                if (isPro)
                {
                    if (pars.Length > 0)
                    {
                        sbTmp.AppendLine("                  " + returnType + " " + proName + "= " + target + "[" + parstr + "];");
                        //sbTmp.AppendLine("                  ToLuaCS.push(L," + proName + "); ");
                        sbTmp.AppendLine(LuaDLLPush(returnT, proName));
                        //sbTmp.AppendLine("                  return 1;");
                        returncout++;
                    }
                    else
                    {
                        sbTmp.AppendLine("                  " + returnType + " " + proName + "= " + target + "." + proName + ";");
                        //sbTmp.AppendLine("                  ToLuaCS.push(L," + proName + "); ");
                        sbTmp.AppendLine(LuaDLLPush(returnT, proName));
                        //sbTmp.AppendLine("                  return 1;");
                        returncout++;
                    }
                }
                else
                {
                    sbTmp.AppendLine("                  " + returnType + " " + mInfo.Name.ToLower() + "= " + target + "." + mInfo.Name + "(" + parstr + ");");
                    //sbTmp.AppendLine("                  ToLuaCS.push(L," + mInfo.Name.ToLower() + "); ");
                    sbTmp.AppendLine(LuaDLLPush(returnT, mInfo.Name.ToLower()));
                    returncout++;

                    //sbTmp.AppendLine("                  return 1;");
                }
            }
        }
        else if (mInfo is ConstructorInfo)
        {
            hasReturn = true;
            returnType = GetSafeTypeString(t);
            string mname1 = GetSafeMethodName(t, mInfo.Name.ToLower());

            sbTmp.AppendLine("                  " + returnType + " " + mname1 + "= new " + classTname + "(" + parstr + ");");
            //sbTmp.AppendLine("                  ToLuaCS.push(L," + mname1 + "); ");
            sbTmp.AppendLine(LuaDLLPush(t, mname1));
            returncout++;
            //sbTmp.AppendLine("                  return 1;");
        }

        foreach (ParameterInfo pinfo2 in outpars)
        {
            sbTmp.AppendLine(LuaDLLPush(pinfo2.ParameterType, GetSafeParName(pinfo2.Name)));
        }
        //if(returncout
        sbTmp.AppendLine("                  return " + returncout.ToString() + ";");
        return sbTmp.ToString();
    }
    private static string GetFieldStr(System.Type t, FieldInfo fInfo, int i, bool isStatic, bool isGet)
    {
        StringBuilder re = new StringBuilder();
        string classTname = t.FullName;

        string proName = fInfo.Name;
        System.Type ft = fInfo.FieldType;

        if (isStatic)
        {
            if (isGet)
            {
                re.AppendLine("                  var val=   " + classTname + "." + proName + ";");
                //re.AppendLine("                  ToLuaCS.push(L,val);");
                re.AppendLine(LuaDLLPush(ft, "val"));
                re.AppendLine("                  return 1;");
            }
            else //set
            {
                if (ft == typeof(string))
                {
                    re.AppendLine("                  " + classTname + "." + proName + "= LuaDLL.lua_tostring(L,1);");
                }
                else if (ft == typeof(Boolean))
                {
                    re.AppendLine("                  " + classTname + "." + proName + "= LuaDLL.lua_toboolean(L,1);");
                }
                else if (ft == typeof(uint) || ft == typeof(UInt16) || ft == typeof(UInt32) || ft == typeof(UInt64)
                   || ft == typeof(Int16) || ft == typeof(Int32) || ft == typeof(Int64)
                   || ft == typeof(Single) || ft == typeof(Double) || ft == typeof(Byte) || ft == typeof(Char))
                {
                    re.AppendLine("                  " + classTname + "." + proName + "= (" + ft + ")LuaDLL.lua_tonumber(L,1);");
                }
                else
                {
                    //re.AppendLine("                   var val= ToLuaCS.getObject(L, 1);");
                    re.AppendLine("                   var val= " + getObject(ft, 1) + ";");
                    re.AppendLine("                  " + classTname + "." + proName + "= (" + GetSafeTypeString(ft) + ")val;");
                }
                re.AppendLine("                  return 0;");

            }
        }
        else
        {
            if (isGet)
            {
                //re.AppendLine("                  object original = ToLuaCS.getObject(L, 1);");
                re.AppendLine("                  var original = " + getObject(t, 1) + ";");
                re.AppendLine("                  " + classTname + " target= (" + classTname + ") original ;");
                re.AppendLine("                  var val=  target." + proName + ";");
                //re.AppendLine("                  ToLuaCS.push(L,val);");
                re.AppendLine(LuaDLLPush(ft, "val"));
                re.AppendLine("                  return 1;");
            }
            else
            {
                //re.AppendLine("                  object original = ToLuaCS.getObject(L, 1);");
                re.AppendLine("                  var original = " + getObject(t, 1) + ";");
                re.AppendLine("                  " + classTname + " target= (" + classTname + ") original;");
                if (ft == typeof(string))
                {
                    re.AppendLine("                  target." + proName + "= LuaDLL.lua_tostring(L,2);");
                }
                else if (ft == typeof(Boolean))
                {
                    re.AppendLine("                  target." + proName + "= LuaDLL.lua_toboolean(L,2);");
                }
                else if (ft == typeof(uint) || ft == typeof(UInt16) || ft == typeof(UInt32) || ft == typeof(UInt64)
                   || ft == typeof(Int16) || ft == typeof(Int32) || ft == typeof(Int64)
                   || ft == typeof(Single) || ft == typeof(Double) || ft == typeof(Byte) || ft == typeof(Char))
                {
                    re.AppendLine("                  target." + proName + "= (" + ft + ")LuaDLL.lua_tonumber(L,2);");
                }
                else
                {
                    //re.AppendLine("                  var val= ToLuaCS.getObject(L, 2);");
                    re.AppendLine("                  var val= " + getObject(ft, 2) + ";");
                    re.AppendLine("                  target." + proName + "= (" + GetSafeTypeString(ft) + ")val;");
                }
                re.AppendLine("                  return 0;");

            }
        }

        return re.ToString();
    }

    #endregion

    #region helper

    static List<string> getAllChildFiles(string path, List<string> files = null)
    {
        if (files == null) files = new List<string>();
        addFiles(path, files);
        string[] dires = Directory.GetDirectories(path);
        foreach (string dirp in dires)
        {
            if (!dirp.Contains("Editor"))
                getAllChildFiles(dirp, files);
        }
        return files;
    }

    static void addFiles(string direPath, List<string> files)
    {
        string[] fileMys = Directory.GetFiles(direPath);
        foreach (string f in fileMys)
        {
            if (f.EndsWith("txt") || f.EndsWith("cs"))
            {
                files.Add(f);
            }
        }
    }

    /// <summary>
    /// 是否文件夹
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool isDirectory(UnityEngine.Object obj)
    {
        string path = AssetDatabase.GetAssetPath(obj);
        return Directory.Exists(path);
    }

    static List<string> valueTypes = new List<string>(ToLuaCS.ValueTypes);

    /// <summary>
    /// 替换ToLuaCS.getObject
    /// </summary>
    /// <param name="p"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public static string getObject(System.Type p, int i)
    {
        string name = p.FullName;
        //Debug.Log(name + " " + valueTypes.Count);
        if (p.IsValueType && valueTypes.Contains(name))  //如果是已经实现的值类型
        {
            string cname = p.Name;
            return "ToLuaCS.get" + cname + "(L, " + i + ")";
        }
        else
        {
            return "ToLuaCS.getObject(L, " + i + ")";
        }

    }

    public static string IsTypeObject(System.Type p, int i)
    {
        string name = p.FullName;
        if (p.IsValueType && valueTypes.Contains(name))  //如果是已经实现的值类型
        {
            string cname = p.Name;
            return " LuaDLL.lua_type(L," + i + ")== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, "+i+", typeof("+p.FullName+"))";
            //return "ToLuaCS.get" + cname + "(L, " + i + ")";
        }
        else
        {
            return " ToLuaCS.getObject(L, " + i + ") is " + GetSafeTypeString(p) + "";
        }

    }

    /// <summary>
    /// 以lua原始值得方式push值
    /// </summary>
    /// <param name="returnType"></param>
    /// <param name="mname1"></param>
    /// <returns></returns>
    public static string LuaDLLPush(System.Type pt, string mname1)
    {
        string re = string.Empty;

        if (pt == typeof(sbyte) || pt == typeof(byte) || pt == typeof(short) || pt == typeof(ushort)
                        || pt == typeof(int) || pt == typeof(uint) || pt == typeof(long)
                        || pt == typeof(float) || pt == typeof(ulong) || pt == typeof(decimal) || pt == typeof(double) || pt == typeof(char))
        {
            re = "                  LuaDLL.lua_pushnumber(L, " + mname1 + ");";
        }
        else if (pt == typeof(string))
        {
            re = "                  LuaDLL.lua_pushstring(L, " + mname1 + ");";
        }
        else if (pt == typeof(bool))
        {
            re = "                  LuaDLL.lua_pushboolean(L," + mname1 + ");";
        }
        else
        {
            re = "                  ToLuaCS.push(L," + mname1 + ");";
        }

        return re;
    }

    /// <summary>
    /// super是否是t1的基类
    /// </summary>
    /// <param name="t1"></param>
    /// <param name="super"></param>
    /// <returns></returns>
    public static bool IsSuperClass(System.Type t1, System.Type super)
    {
        if (t1.BaseType != null && t1.BaseType == super)
            return true;
        else if (t1.BaseType == null)
        {
            return false;
        }
        else
        {
            return IsSuperClass(t1.BaseType, super);
        }
    }

    private static bool IsObsoleteAttribute(MemberInfo fInfo)
    {
        object[] attrs = fInfo.GetCustomAttributes(true);
        for (int j = 0; j < attrs.Length; j++)
        {
            if (attrs[j].GetType() == typeof(System.ObsoleteAttribute))
            {
                return true;
            }
        }

        return false;
    }

    private static int CompareParByLength(MemberInfo x, MemberInfo y)
    {
        //if (x is ConstructorInfo && y is ConstructorInfo)
        //{
        //    ConstructorInfo mx = ((ConstructorInfo)x);
        //    ConstructorInfo my = ((ConstructorInfo)y);
        //    return my.GetParameters().Length - mx.GetParameters().Length;
        //}
        //else
        //{
        MethodBase mx = ((MethodBase)x);
        MethodBase my = ((MethodBase)y);
        return my.GetParameters().Length - mx.GetParameters().Length;
        //}
    }

    private static string GetSafeMethodName(System.Type t, string name)
    {
        if (name.ToLower().Equals(".ctor"))
        {
            return "_" + t.Name.ToLower();
        }
        else
        {
            return name;
        }
    }

    public static string GetSafeTypeString(System.Type t)
    {
        if (t == null) return "object";
        if (t.ToString() == "T" || t.ToString() == "T[]") return "object";
        string tname = t.FullName;
        //Debug.Log(tname);
        //Debug.Log(t.Name);

        tname = tname.Replace("&", "").Replace("+", ".");

        Match math = Regex.Match(tname, pattern);
        if (math.Success)
        {
            string reg = math.Groups["group"].Value;
            MatchCollection mc = Regex.Matches(reg, pattern1);
            string tNames = "", split = "", item = "";
            foreach (Match m in mc)
            {
                item = m.Groups["cla"].Value;
                tNames += split + item;
                split = ",";
            }
            string rerE = "<" + tNames + ">";
            tname = tname.Replace(math.Groups[0].Value, rerE);
        }
        return tname;
    }

    //private const string pattern=@"\`\d\[\[(?<cla>[\w|\d|\.]+),.*\]\]";
    private const string pattern = @"\`\d\[(?<group>(.)+)\]"; //@"\`\d\[\[(?<cla>[\w|\d|\.]+),.*\]\]";
    private const string pattern1 = @"\[(?<cla>[\w|\d|\.]+),?[^\]]*\]+";

    private static string GetSafeParName(string parsName)
    {
        return parsName + "_";
    }

    private static void checkLuaToCSExportPath()
    {
        string dircAssert = Application.dataPath + "/" + OutLuaPath;
        if (!Directory.Exists(dircAssert))
        {
            Directory.CreateDirectory(dircAssert);
        }
    }

    public static System.Type GetTypeByName(string classname)
    {
        System.Type t = null;
        Assembly[] ass = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assem in ass)
        {
            t = assem.GetType(classname);
            if (t != null)
                return t;
        }
        return null;
    }
    #endregion
}
