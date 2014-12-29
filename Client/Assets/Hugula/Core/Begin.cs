// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
/// <summary>
/// 
/// </summary>
public class Begin : MonoBehaviour {
	
	public bool isDebug=true;
    public string enterLua = "main";

 	// Use this for initialization
	void Start () 
	{
        LuaBegin();
	}

	#region init
	
	void LuaBegin()
    {
        PLua.isDebug = this.isDebug;
		PLua luab=this.gameObject.GetComponent<PLua>();
		if(luab==null)
		{
            PLua.isDebug = isDebug;
            PLua p=gameObject.AddComponent<PLua>();
            p.enterLua = this.enterLua;
        }
        else if (luab.enabled == false)
        {
            luab.enabled = true;
        }
	
	}
	#endregion
   
}
