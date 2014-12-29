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
#if Nlua
using NLua;
using Lua = NLua.Lua;
#else
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;
#endif

public class PLua : MonoBehaviour
{

    public string enterLua = "main";
    public LuaFunction onDestroyFn;
    public bool isDebug = true;

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

    public static bool isNlua { private set; get; }
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
#if Nlua
        lua = new Lua();
        isNlua = true;
#else
        lua = new Lua();
        isNlua = false;
        luaState = lua.L;
#endif
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
        luaBegin.Append("return require(\"" + this.enterLua + "\") \n");
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
        //luaBundles = new AssetBundle[package_paths.Length];
        int i = package_paths.Length - 1;
        string keyName = "";
        for (; i >= 0; i--)
        {
            string luaP = package_paths[i];
            if (File.Exists(luaP)) //如果存在
            {
                WWW luaLoader = new WWW("file://" + luaP);
                yield return luaLoader;
                if (luaLoader.error == null)
                {
                    AssetBundle item = null;
                    item = luaLoader.assetBundle;
                    TextAsset[] all = item.LoadAllAssets<TextAsset>();
                    foreach (var ass in all)
                    {
                        keyName = ass.name;
                        //Debug.Log(keyName);
                        luacache[keyName] = ass;
                    }
                    luaLoader.assetBundle.Unload(false);
                    luaLoader.Dispose();
                }
            }
        }

        if (domain)
            DoMain();

    }

    #region public
    /// <summary>
    /// 执行开始文件
    /// </summary>
    public void DoMain()
    {
        Debug.Log("DoMain");
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
#if UNITY_EDITOR
        if (isDebug)
        {
            requireFunction = new LuaCSFunction(DebugRequireLua);
            LuaDLL.lua_pushstdcallcfunction(luaState, requireFunction);
            LuaDLL.lua_setfield(luaState, LuaIndexes.LUA_GLOBALSINDEX, "require");
        }
        else
        {
            requireFunction = new LuaCSFunction(RequireLua);
            LuaDLL.lua_pushstdcallcfunction(luaState, requireFunction);
            LuaDLL.lua_setfield(luaState, LuaIndexes.LUA_GLOBALSINDEX, "require");
        }

#else
        requireFunction = new LuaCSFunction(RequireLua);
		LuaDLL.lua_pushstdcallcfunction(luaState, requireFunction);
		LuaDLL.lua_setfield(luaState, LuaIndexes.LUA_GLOBALSINDEX, "require");
#endif

    }

    private static char[] split = new char[] { ';' };
    private static string[] package_paths;

#if UNITY_EDITOR
    /// <summary>
    /// debug
    /// </summary>
    /// <param name="L">L.</param>
    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int DebugRequireLua(LuaState L)
    {
        string modle = LuaDLL.lua_tostring(L, 1);
        string path = modle.Replace(".", "/");
        //object[] re=null;
        string paths = package_path.Replace("?", path);
        string[] lua_paths = paths.Split(split);
        LuaDLL.lua_pop(L, 1);
        foreach (string iPath in lua_paths)
        {
            if (File.Exists(iPath))
            {

                int oldTop = LuaDLL.lua_gettop(L);

                if (LuaDLL.luaL_loadfile(L, iPath) == 0)
                {

                    if (LuaDLL.lua_pcall(L, 0, -1, -2) == 0)
                    {
                        int i = LuaDLL.lua_gettop(L);
                        return i;
                    }
                }
            }
        }
        return 0;
    }

#endif

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int RequireLua(LuaState L)
    {
        string fileName = String.Empty;

        fileName = LuaDLL.lua_tostring(L, 1);
        fileName = fileName.Replace("/", ".");
        LuaDLL.lua_settop(L, 1);
        LuaDLL.lua_getfield(L, LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
        LuaDLL.lua_getfield(L, 2, fileName);
        //Debug.Log("require" + fileName + " : " + LuaDLL.lua_toboolean(L, -1).ToString());
        if (LuaDLL.lua_toboolean(L, -1))
            return 1;

        LuaDLL.lua_pop(L, 1);
        //loader file
        if (luacache.ContainsKey(fileName))
        {
            TextAsset file = luacache[fileName];
            if (LuaDLL.luaL_loadbuffer(L, file.text, Encoding.UTF8.GetByteCount(file.text), fileName) == 0)
            {
                LuaDLL.lua_call(L, 0, 1);// LuaDLL.LUA_MULTRET
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
