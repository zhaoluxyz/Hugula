using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System;
#if Nlua
using NLua;
using Lua = NLua.Lua;
#else
using LuaInterface;
using Lua = LuaInterface.LuaState;
#endif

public class PLua :MonoBehaviour {

    public string enterLua = "main";
    public LuaFunction updateFn;
    public LuaFunction fixedUpdateFn;
    public LuaFunction lateUpdateFn;

    public bool isDebug = true;
    public bool openUpdate = true;
    public bool openFixedUpdate = true;
    public bool openLateUpdate = true;

    public Lua lua;
    public LNet net;

    private string luaMain = "";

    #region mono
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
#if Nlua
        lua = new Lua();
#else
        lua = new LuaState();
#endif
        _instance = this;
        LoadScript();
    }

    void Start()
    {
        net = LNet.instance;
        SetLuaMain();
       object[] re= lua.DoString(luaMain);
       if (re != null && re.Length > 0)
       {
           LuaTable tb = re[0] as LuaTable;
           if (tb != null)
           {
               updateFn = tb[1] as LuaFunction;
               fixedUpdateFn = tb[2] as LuaFunction;
               lateUpdateFn = tb[3] as LuaFunction;
           }
       }

    }

    void Update()
    {
        if(net!=null) net.Update();

        if (openUpdate && updateFn != null) updateFn.Call();
    }

    void FixedUpdate()
    {
        if (openFixedUpdate && fixedUpdateFn != null) fixedUpdateFn.Call();
    }

   void LateUpdate()
    {
        if (openLateUpdate && lateUpdateFn != null) lateUpdateFn.Call();
    }

   void OnApplicationPause(bool pauseStatus)
   {
       //net.OnApplicationPause(pauseStatus);
   }

   void  OnDestroy() {
        updateFn=null;
        fixedUpdateFn=null;
        lateUpdateFn=null;
        lua.Dispose();
        lua = null;
        _instance = null;
        net.Dispose();
        net = null;
    }

    #endregion

    private void SetLuaMain()
    {
        System.Text.StringBuilder luaBegin = new System.Text.StringBuilder();
        string lua_data_path=UnityEngine.Application.dataPath+"/Lua/";
        string lua_persistent_path = string.Format("{0}/{1}/", UnityEngine.Application.persistentDataPath, Common.LUACFOLDER);
        string lua_streaming_Path = string.Format("{0}/{1}/", UnityEngine.Application.streamingAssetsPath, Common.LUACFOLDER);
        luaBegin.Append("UnityEngine=luanet.UnityEngine \n  ");
#if UNITY_EDITOR
        if (isDebug)
        {
            luaBegin.Append("package.path=\"" + lua_data_path + "?.lua \" \n ");
        }else
        {
            luaBegin.Append("package.path=\"" + lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX + " \" \n ");
        }
#else
        luaBegin.Append("package.path=\"" + lua_persistent_path + "?." + Common.LUA_LC_SUFFIX + ";" + lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX + " \" \n ");
#endif
        luaBegin.Append("return require('" + enterLua + "') ");
        this.luaMain = luaBegin.ToString();
        Debug.Log(luaMain);
    }

	private void LoadScript()
	{
		Assembly assb=Assembly.GetExecutingAssembly();
		string assemblyname=assb.GetName().Name;
		string dostr="luanet.load_assembly('"+assemblyname+"') \n";
        //dostr += "	DateTime=luanet.import_type(\"System.DateTime\") \n";
        //dostr += "	TimeSpan=luanet.import_type(\"System.TimeSpan\") \n";
        dostr += "	PLua=luanet.import_type(\"PLua\") \n";
        //dostr+="	GC=luanet.import_type(\"System.GC\") \n"; 

		lua.DoString(dostr);

        RegisterFunc();
    }

    #region toolMethod

    public void RegisterFunc()
    {
        lua.RegisterFunction("delay", this, this.GetType().GetMethod("Delay"));
        lua.RegisterFunction("stopDelay", this, this.GetType().GetMethod("StopDelay"));
    }

    public static void Delay(LuaFunction luafun, float time,object args=null)
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
		get{
			return _instance;
		}
	}
	#endregion

}
