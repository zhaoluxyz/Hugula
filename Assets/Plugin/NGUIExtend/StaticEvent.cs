using UnityEngine;
using System.Collections;

public class CStaticEvent :MonoBehaviour {

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
		CStaticEvent.instance.onPressHandle(sender,press);
	}
	
	void OnClick()
	{
		GameObject sender=UICamera.hoveredObject;
		CStaticEvent.instance.onClickHandle(sender,this);
	}
	
	void  OnDrag (Vector2 delta)
	{
		GameObject sender=UICamera.hoveredObject;
		CStaticEvent.instance.onDragHandle(sender,this);
	}
	
	void OnDrop (GameObject drag)
	{
		GameObject sender=UICamera.hoveredObject;
		CStaticEvent.instance.onDropHandle(sender,this);
	}
	
	
	void OnSelect (bool selected)
	{
		GameObject sender=UICamera.hoveredObject;
		CStaticEvent.instance.onSelectHandle(sender,this);
	}
	
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
		if(OnPressHandle!=null)
		{
			OnPressHandle(sender,arg);
		}
	}

	public void onClickHandle(GameObject sender, object arg)
	{
		if(OnClickHandle!=null)
		{
			OnClickHandle(sender,arg);
		}
	}
	
	public void onDragHandle(GameObject sender,object arg)
	{
		if(OnDragHandle!=null)
		{
			OnDragHandle(sender,arg);
		}
	}
	
	public void onDropHandle(GameObject sender,object arg)
	{
		if(OnDropHandle!=null)
		{
			OnDropHandle(sender,arg);
		}
	}
	
	public void onSelectHandle(GameObject sender,object arg)
	{
		if(OnSelectHandle!=null)
		{
			OnSelectHandle(sender,arg);
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

	public event ViewOnEventHandle OnPressHandle;
	
	public event ViewOnEventHandle OnClickHandle;	

	public event ViewOnEventHandle OnDragHandle;
	
	public event ViewOnEventHandle OnDropHandle;
	
	public event ViewOnEventHandle OnSelectHandle;

	private static CStaticEvent _instance;

	public static CStaticEvent instance
	{
		get{
			if(_instance==null)
			{
				GameObject obj=new GameObject("CStaticEvent");
				_instance=obj.AddComponent<CStaticEvent>();
				//_instance=new CStaticEvent();
			}
			return _instance;
		}
	}

}

public delegate void ViewOnEventHandle(GameObject sender,object arg);

