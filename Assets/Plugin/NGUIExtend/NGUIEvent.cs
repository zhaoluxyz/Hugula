using UnityEngine;
using System.Collections;
#if Nlua
using NLua;
using Lua = NLua.Lua;
#else
using LuaInterface;
using Lua = LuaInterface.LuaState;
#endif

public class NGUIEvent :MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		UICamera.genericEventHandler=this.gameObject;
	}

	#region NGUI 
	void OnPress(bool press)
	{
		GameObject sender=UICamera.hoveredObject;
		instance.onPressHandle(sender,press);
	}
	
	void OnClick()
	{
		GameObject sender=UICamera.hoveredObject;
		instance.onClickHandle(sender,this);
	}

    void OnDrag(Vector2 delta)
    {
        GameObject sender = UICamera.hoveredObject;
        instance.onDragHandle(sender, this);
    }
	
	void OnDrop (GameObject drag)
	{
		GameObject sender=UICamera.hoveredObject;
		instance.onDropHandle(sender,this);
	}
	
	
    //void OnSelect (bool selected)
    //{
    //    GameObject sender=UICamera.hoveredObject;
    //    instance.onSelectHandle(sender,this);
    //}
	
//	void OnKey (KeyCode key)
//	{//Debug.Log("On key Down:"+key);
//		//GameObject sender=UICamera.hoveredObject;
//	}
//	
//	void OnDoubleClick()
//	{
//		GameObject sender=UICamera.hoveredObject;
//		//		CStaticEvent.onDoubleClickEvent(sender,this);
//		
//		//		if(onDoubleClickEvent!=null  && enabled)
//		//		{
//		//			onDoubleClickEvent(sender,this);
//		//		}
//	}

	#endregion

	#region public 
	public void onPressHandle(GameObject sender,object arg)
	{
        if (onPressFn != null)
		{
            onPressFn.Call(sender, arg);
		}
	}

	public void onClickHandle(GameObject sender, object arg)
	{
		if(onClickFn!=null)
		{
            onClickFn.Call(sender, arg);
		}
	}
	
	public void onDragHandle(GameObject sender,object arg)
	{
		if(onDragFn!=null)
		{
            onDragFn.Call(sender, arg);
		}
	}
	
	public void onDropHandle(GameObject sender,object arg)
	{
		if(onDropFn!=null)
		{
            onDropFn.Call(sender, arg);
		}
	}
	
	public void onSelectHandle(GameObject sender,object arg)
	{
		if(onSelectFn!=null)
		{
            onSelectFn.Call(sender, arg);
		}
	}
	
//	public static void onDoubleClickHandle(GameObject sender,object arg)
//	{
//		if(onDouble!=null)
//		{
//			onDouble(sender,arg);
//		}
//	}

	#endregion

	public LuaFunction onPressFn;

    public LuaFunction onClickFn;

    public LuaFunction onDragFn;

    public LuaFunction onDropFn;

    public LuaFunction onSelectFn;

    private static NGUIEvent _instance;

    public static NGUIEvent instance
	{
		get{
			if(_instance==null)
			{
                GameObject obj = new GameObject("NGUIEvent");
                _instance = obj.AddComponent<NGUIEvent>();
				//_instance=new CStaticEvent();
			}
			return _instance;
		}
	}

}

