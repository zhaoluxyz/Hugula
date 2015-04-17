// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Text;

using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public class PLua : MonoBehaviour
{

    public static string enterLua = "main";
    public LuaFunction onDestroyFn;
    public static bool isDebug = true;

    public Lua lua;
    public LNet net;
    public LNet ChatNet;
    public LuaState luaState;
    //搜索路径
    public static string package_path { private set; get; }
    //lua资源缓存路径
    public static Dictionary<string, TextAsset> luacache;

    #region priveta
    //入口lua
    private string luaMain = "";
    private const string initLua = @"require(""core.unity3d"")";

    //程序集名key
    private const string assemblyname = "assemblyname";
    private LuaCSFunction requireFunction;
    private LuaCSFunction delayFunction;

    private LuaFunction _updateFn;

    //lua 代码包
    //private static AssetBundle[] luaBundles;
    #endregion

    #region mono

    public LuaFunction updateFn
    {
        get { return _updateFn; }
        set
        {
            _updateFn = value;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        luacache = new Dictionary<string, TextAsset>();
        lua = new Lua();
        luaState = lua.L;
        ToLuaCS.lua = lua;
        _instance = this;
        LoadScript();
        ToLuaCSStart.Start(luaState);
    }

    void Start()
    {
        net = LNet.instance;
        ChatNet = LNet.ChatInstance;
        LoadBundle(true);
    }

    void Update()
    {
        if (net != null) net.Update();
        if (ChatNet != null) ChatNet.Update();
        if (_updateFn != null) _updateFn.Call();
        Timer.Update();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (net != null) net.OnApplicationPause(pauseStatus);
    }

    void OnDestroy()
    {
        if (onDestroyFn != null) onDestroyFn.Call();
        updateFn = null;
        if (lua != null) lua.Close();
        lua = null;
        _instance = null;
        net.Dispose();
        net = null;
        ChatNet.Dispose();
        ChatNet = null;
        luacache.Clear();
    }

    #endregion

    private void SetLuaPath()
    {
        System.Text.StringBuilder luaBegin = new System.Text.StringBuilder();
        string lua_data_path = UnityEngine.Application.dataPath + "/Lua/";
        string lua_persistent_path = string.Format("{0}/{1}", UnityEngine.Application.persistentDataPath, CUtils.GetAssetPath(""));
        string lua_streaming_Path = string.Format("{0}/{1}", UnityEngine.Application.streamingAssetsPath, CUtils.GetAssetPath(""));
#if UNITY_EDITOR
        if (isDebug)
        {
            package_path = lua_data_path + "?.lua";
        }
        else
        {
            package_path = lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX;
        }
#elif  UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_METRO
        package_path =  lua_persistent_path + "?." + Common.LUA_LC_SUFFIX + ";" + lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX ;
#else
        package_path =  lua_persistent_path + "?." + Common.LUA_LC_SUFFIX + ";" + lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX+ ";" + lua_streaming_Path + "?.lua";
#endif

        package_paths = package_path.Replace("?", "font").Replace(Common.LUA_LC_SUFFIX, Common.ASSETBUNDLE_SUFFIX).Split(split);
        luaBegin.Append("package.path=\"" + package_path + " \" \n");
        luaBegin.Append("return require(\"" + enterLua + "\") \n");
        this.luaMain = luaBegin.ToString();
        Debug.Log(luaMain);
    }

    private void LoadScript()
    {
        SetLuaPath();

        RegisterFunc();

        Assembly assb = Assembly.GetExecutingAssembly();
        string assemblyname = assb.GetName().Name;
        lua["assemblyname"] = assemblyname;
    }

    /// <summary>
    /// 加载lua bundle
    /// </summary>
    /// <returns></returns>
    private IEnumerator loadLuaBundle(bool domain)
    {
        string keyName = "";
        string luaP = CUtils.GetAssetFullPath("font.u3d");
        //Debug.Log("load lua bundle" + luaP);
        WWW luaLoader = new WWW(luaP);
        yield return luaLoader;
        if (luaLoader.error == null)
        {
            AssetBundle item = null;
            item = luaLoader.assetBundle;
#if UNITY_5
                    TextAsset[] all = item.LoadAllAssets<TextAsset>();
                    foreach (var ass in all)
                    {
                        keyName = ass.name;
                        luacache[keyName] = ass;
                    }
#else
            UnityEngine.Object[] all = item.LoadAll(typeof(TextAsset));
            foreach (var ass in all)
            {
                keyName = ass.name.Replace('.', '/');
                Debug.Log(keyName + " complete");
                luacache[keyName] = ass as TextAsset;
            }
#endif
            //Debug.Log("loaded lua bundle complete" + luaP);
            luaLoader.assetBundle.Unload(false);
            luaLoader.Dispose();
        }

        DoUnity3dLua();
        if (domain)
            DoMain();
    }

    #region public

    public void DoUnity3dLua()
    {
        //Require(
        lua.DoString(initLua);//执行unity3dlua
        ToLuaCS.InitValueTypeChange();
    }

    /// <summary>
    /// 执行开始文件
    /// </summary>
    public void DoMain()
    {
        lua.DoString(this.luaMain);
    }

    /// <summary>
    /// 加载lua 打包文件
    /// </summary>
    public void LoadBundle(bool domain)
    {
        StopCoroutine(loadLuaBundle(domain));
        StartCoroutine(loadLuaBundle(domain));
    }
    #endregion

    #region toolMethod

    public void RegisterFunc()
    {
        requireFunction = new LuaCSFunction(Require);
        LuaDLL.lua_pushstdcallcfunction(luaState, requireFunction);
        LuaDLL.lua_setfield(luaState, LuaIndexes.LUA_GLOBALSINDEX, "require");
        LuaStatic.Load = Loader;
    }

    /// <summary>
    /// 自定义loader
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static byte[] Loader(string name)
    {
        byte[] str = null;
//        name = name.Replace('.', '/');
#if UNITY_EDITOR

        if (isDebug)
        {
            string path = Application.dataPath + "/Lua/" + name+".lua";
//			string path = Application.dataPath + "/Tmp/PW/" + name+".bytes";
			Debug.Log(" Loader: "+path);
            try
            {
				str =  File.ReadAllBytes(path);
            }
            catch
            {
                //LuaDLL.luaL_error(ToLuaCS.lua.L, "Loader file failed: " + name);
            }
        } 
        else
        {
            //Debug.Log(name + " require");
            if (luacache.ContainsKey(name))
            {
                TextAsset file = luacache[name];
                str = file.bytes;
                //Debug.Log(name + " exist");
            }
        }
#else
        if(luacache.ContainsKey(name))
        {
        TextAsset file = luacache[name];
        str = file.bytes;
        }
#endif
        return str;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int Require(LuaState L)
    {
#if UNITY_EDITOR
        if (isDebug)
            return DebugRequireLua(L);
        else
            return RequireLua(L);
#else
         return RequireLua(L);
#endif
    }

    private static char[] split = new char[] { ';' };
    private static string[] package_paths;

#if UNITY_EDITOR
    /// <summary>
    /// debug
    /// </summary>
    /// <param name="L">L.</param>

    private static int DebugRequireLua(LuaState L)
    {
        string modle = LuaDLL.lua_tostring(L, 1);
        string path = modle.Replace(".", "/");

        string paths = package_path.Replace("?", path);
        string[] lua_paths = paths.Split(split);
        LuaDLL.lua_pop(L, 1);
        foreach (string iPath in lua_paths)
        {
            if (File.Exists(iPath))
            {
//				Debug.Log(iPath);
                int oldTop = LuaDLL.lua_gettop(L);

				int re=LuaDLL.luaL_loadfile(L, iPath);
                if ( re== 0)
                {

//					re = LuaDLL.lua_call(L,0,LuaDLL.LUA_MULTRET);
					re = LuaDLL.lua_pcall(L, 0, -1, -2);
					if(re==0)
                    {
                        int i = LuaDLL.lua_gettop(L);
                        return i;
                    }
					else
					{
						Debug.Log(iPath+" lua_pcall err"+ re);
					}
                }else
				{
					Debug.Log(LuaDLL.lua_tostring(L,-1));  //.ua_tostring(L, -1))
					Debug.Log(iPath+" luaL_loadfile err" + re);
				}
            }
        }

        return 0;
    }

#endif

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    private static int RequireLua(LuaState L)
    {
        string fileName = String.Empty;

        fileName = LuaDLL.lua_tostring(L, 1);
        fileName = fileName.Replace(".", "/");
        LuaDLL.lua_settop(L, 1);
        LuaDLL.lua_getfield(L, LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
        LuaDLL.lua_getfield(L, 2, fileName);
        Debug.Log("require" + fileName + " : " + LuaDLL.lua_toboolean(L, -1).ToString());
        if (LuaDLL.lua_toboolean(L, -1))
            return 1;

        LuaDLL.lua_pop(L, 1);
        //loader file
        if (luacache.ContainsKey(fileName))
        {
            TextAsset file = luacache[fileName];
            if (LuaDLL.luaL_loadbuffer(L, file.bytes, file.bytes.Length, fileName) == 0)
            {
                LuaDLL.lua_call(L, 0, 1);// LuaDLL.LUA_MULTRET
            }else
			{
				Debug.Log("luaL_loadfile err " +fileName);
			}

            if (!LuaDLL.lua_isnil(L, -1))  /* non-nil return? */
                LuaDLL.lua_setfield(L, 2, fileName);  /* _LOADED[name] = returned value */
        }

        LuaDLL.lua_getfield(L, 2, fileName);
        if (LuaDLL.lua_isnil(L, -1))
        {   /* module did not set a value? */
            LuaDLL.lua_pushboolean(L, true);  /* use true as result */
            LuaDLL.lua_pushvalue(L, -1);  /* extra copy to be returned */
            LuaDLL.lua_setfield(L, 2, fileName);  /* _LOADED[name] = true */
        }
        return 1;// LuaDLL.lua_gettop(L) - n;
    }

    public static void Log(object msg)
    {
        Debug.Log(msg);
    }

    public static void Delay(LuaFunction luafun, float time, object args = null)
    {
        _instance.StartCoroutine(DelayDo(luafun, args, time));
    }

    public static void StopDelay(string methodName = "DelayDo")
    {
        _instance.StopCoroutine(methodName);
    }

    private static IEnumerator DelayDo(LuaFunction luafun, object arg, float time)
    {
        yield return new WaitForSeconds(time);
        luafun.Call(arg);
    }

    #endregion

    #region static
    private static PLua _instance;

    public static PLua instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

}
