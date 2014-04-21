using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

public class BeginSample : MonoBehaviour {
	
	public bool editorDebug=false;
    private static BeginSample _instance;
    public const string VERSION_FILE_NAME = "Ver.t";
    public static BeginSample instance
    {
        get
        {
            return _instance;
        }
    }

    private LMultipleLoader multipleLoader;

    void Awake()
    {
        multipleLoader = LMultipleLoader.instance;
        _instance = this;
    }

	// Use this for initialization
	void Start () 
	{
        CUtils.GetFileFullPath(VERSION_FILE_NAME);
        PlatformInit();
	}

	#region platform init
	
	void AndroidInit()
	{
        if(CUtils.currPersistentExist==false)// nothing 
		{
			string fileName=Application.streamingAssetsPath+"/data.zip";//  --System.IO.Path.ChangeExtension(Application.streamingAssetsPath,".zip");
			CRequest req=new CRequest(fileName);	
			req.OnComplete+=delegate(CRequest r){
				byte[] bytes=null;
				if(r.data is WWW)
				{
					WWW www=r.data as WWW;
					bytes=www.bytes;
				}
                FileHelper.UnZipFile(bytes, Application.persistentDataPath);
                LuaBegin();
			};
			this.multipleLoader.LoadReq(req);
		}else
		{
            LuaBegin();
		}
	}
	
	void IphoneInit()
	{
        LuaBegin();
	}
	
	void Wp8Init()
	{
        LuaBegin();
	}
	
	void WindowsPlayerInit()
	{
        LuaBegin();
	}
	
	void WindowsEditorInit()
	{
        LuaBegin();
	}
	
	void OsxEditorInit()
	{
        LuaBegin();
	}
	
	void LuaBegin()
	{
		PLua luab=this.gameObject.GetComponent<PLua>();
		if(luab==null)
		{
            PLua p=gameObject.AddComponent<PLua>();
            p.isDebug = editorDebug;
		}
	}
	
	void PlatformInit()
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			AndroidInit();
		}else if(Application.platform==RuntimePlatform.IPhonePlayer)
		{
			IphoneInit();
		}else if(Application.platform==RuntimePlatform.WP8Player)
		{
			Wp8Init();
		}else if(Application.platform==RuntimePlatform.WindowsPlayer)
		{
			WindowsPlayerInit();
		}else if(Application.platform==RuntimePlatform.OSXEditor)
		{
			OsxEditorInit();
		}else if(Application.platform==RuntimePlatform.WindowsEditor)
		{
			WindowsEditorInit();
		}
	}
	#endregion

}
