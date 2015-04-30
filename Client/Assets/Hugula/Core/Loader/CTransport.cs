// Copyright (c) 2015 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// C transport.
/// </summary>
public class CTransport : MonoBehaviour {

	#region private member
	private WWW www;
	private CRequest _req;
	#endregion

	#region public member
	/// <summary>
	/// if transport car is free
	/// </summary>
	/// <value><c>true</c> if is free; otherwise, <c>false</c>.</value>
	public bool isFree{private set;get;}

	/// <summary>
	/// The req.
	/// </summary>
	public CRequest req {
		get {
			return _req;
		}
	}

	/// <summary>
	/// The key.
	/// </summary>
	public string key;

	#endregion
		


	#region evnet
	public System.Action<CTransport,float> OnProcess;
	public System.Action<CTransport,CRequest,IList<CRequest>> OnComplete;
	public System.Action<CTransport,CRequest> OnError;
	#endregion

	void Awake()
	{
		isFree = true;
	}

	// Update is called once per frame
	void Update () {
		if(www!=null && isFree==false)
		{
			float pro=www.progress;
			if(OnProcess!=null)
				OnProcess(this,pro);
		}
	}


	#region public method

	public void BeginLoad(CRequest req)
	{
		isFree=false;
		this._req = req;
//		Debug.Log("BeginLoad : url "+req.url+" \n key:"+req.key);
		StopCoroutine (Loadres ());
		StartCoroutine(Loadres());
	}

	#endregion


	#region protected method

	IEnumerator Loadres()
	{
//		Debug.Log("StartCoroutine Loadres : url "+req.url+" \n key:"+req.key);
		if(req.head is WWWForm)
		{
			www=new WWW(req.url,(WWWForm)req.head);
		}else if(req.head is byte[])
		{
			www = new WWW(req.url, (byte[])req.head);
		}
		else
		{
			www=new WWW(req.url); //WWW.LoadFromCacheOrDownload(req.url,1);  
		}
//		Debug.Log("StartCoroutine www : url "+req.url+" \n key:"+req.key);
		yield return www;

		if(www.error!=null)
		{
//			Debug.LogWarning("error : url "+req.url+" \n error:"+www.error);
			isFree =true;
			DispatchErrorEvent(req);
		}
		else
		{
			if(OnProcess!=null)
				OnProcess(this,1);
//			Debug.Log("complete : url "+req.url+" \n key:"+req.key);
			try
			{
				req.data = www;
				IList<CRequest> depens=null;
				if (req.suffix.Equals(Common.ASSETBUNDLE_SUFFIX)
				    && www.assetBundle != null
				    && www.assetBundle.Contains(Common.DEPENDENCIES_OBJECT_NAME)
				    )
				{
#if UNITY_5
                    CDependenciesScript script = www.assetBundle.LoadAsset<CDependenciesScript>(Common.DEPENDENCIES_OBJECT_NAME);
                    depens = GetDependencies(script);
# else
                    CDependenciesScript script = (CDependenciesScript)www.assetBundle.Load(Common.DEPENDENCIES_OBJECT_NAME, typeof(CDependenciesScript));
                    depens = GetDependencies(script);
#endif
				}
				isFree =true;
				this.DispatchCompleteEvent(this.req,depens);
			}
			catch (Exception e)
			{
				Debug.LogError(e);
			}
		}
	}

	/// <summary>
	/// get Dependencies req
	/// </summary>
	/// <returns>The dependencies.</returns>
	/// <param name="script">Script.</param>
    private IList<CRequest> GetDependencies(CDependenciesScript script)
	{
		
		string paths=script.paths;

		if(string.IsNullOrEmpty(paths)) return null;

		string[] strs=paths.Split(',');		
		IList<CRequest> reqs=new List<CRequest>();
		CRequest item;
		int priority=this.req.priority+10;

		foreach(string p in strs)
		{
			item=new CRequest(CUtils.GetFileFullPath(p),priority);
			item.isShared=true;
			reqs.Add(item);
		}

		if (reqs.Count > 0)
						return reqs;
				else
						return null;
	}


	private void DispatchCompleteEvent(CRequest cReq,IList<CRequest> dependencies)
	{
		if(OnComplete!=null)
			OnComplete(this,cReq,dependencies);
	}
	
	
	private void DispatchErrorEvent(CRequest cReq)
	{
		if (OnError != null) {
			OnError (this, cReq);
				}
	}

	#endregion

//	public delegate void OnErrorHandle(CTransport transport,CRequest req);

}
