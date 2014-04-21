using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
#if Nlua
using NLua;
#else
using LuaInterface;
#endif

public partial class  LuaHelper {

    /// <summary>
    /// Destroy object
    /// </summary>
    /// <param name="original"></param>
    public static void Destroy(Object original)
    {
        GameObject.Destroy(original);
    }

    /// <summary>
    /// Instantiate Object
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    public static Object Instantiate(Object original)
    {
        return GameObject.Instantiate(original);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="original"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static GameObject InstantiateLocal(GameObject original,GameObject parent=null)
    {
        var tranformTa = original.transform;
        Vector3 pos = tranformTa.localPosition;
        Quaternion rota = tranformTa.localRotation;
        Vector3 scale = tranformTa.localScale;
        GameObject clone = (GameObject)GameObject.Instantiate(original);
        var transform=clone.transform;
        if(parent!=null)clone.transform.parent = parent.transform;
        transform.localPosition = pos;
        transform.localScale = scale;
        transform.localRotation = rota;
        return clone;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="original"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static GameObject InstantiateGlobal(GameObject original, GameObject parent = null)
    {
        var tranformTa = original.transform;
        Vector3 pos = tranformTa.position;
        Quaternion rota = tranformTa.rotation;
        Vector3 scale = tranformTa.localScale;
        GameObject clone = (GameObject)GameObject.Instantiate(original);
        var transform = clone.transform;
        if (parent != null) clone.transform.parent = parent.transform;
        transform.position = pos;
        transform.localScale = scale;
        transform.rotation = rota;
        return clone;
    }

    /// <summary>
    /// getType
    /// </summary>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static System.Type GetType(string classname)
    {
        Assembly assb = Assembly.GetExecutingAssembly();  //.GetExecutingAssembly();
        System.Type t = null;
        t=assb.GetType(classname); ;
        if (t == null)
        {
            t = assb.GetType(classname);
        }
        return t;
    }

    ///// <summary>
    ///// create a list<object> for lua
    ///// </summary>
    ///// <returns></returns>
    //public static IList<object> CreateList()
    //{
    //    IList<object> re = new List<object>();
    //    re.Add(new LRequest(""));
    //    return re;
    //}

    /// <summary>
    /// GetComponentInChildren
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static Component GetComponentInChildren(GameObject obj, string classname)
    {
        System.Type t = GetType(classname);
        Component comp = null;
        if (t != null && obj != null)comp = obj.GetComponentInChildren(t);
        return comp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static Component GetComponent(GameObject obj, string classname)
    {
        //System.Type t = getType(classname);
        Component comp = null;
        if (obj != null) comp = obj.GetComponent(classname);
        return comp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static Component[] GetComponentsInChildren(GameObject obj, string classname)
    {
        System.Type t = GetType(classname);
        if (t != null && obj != null) return obj.transform.GetComponentsInChildren(t);
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static Transform[] GetAllChild(GameObject obj)
    {
        Transform[] child=null;
        int count=obj.transform.childCount;
        child =new Transform[count];
        for (int i = 0; i < count; i++)
        {
            child[i] = obj.transform.GetChild(i);
        }
        return child;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="eachFn"></param>
    public static void ForeachChild(GameObject parent, LuaFunction eachFn)
    {
        Transform pr=parent.transform;
        int count = pr.childCount;
        Transform child = null;
        for (int i = 0; i < count; i++)
        {
            child = pr.GetChild(i);
            eachFn.Call(i, child.gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="eachFn"></param>
    public static void ForeachChild(ReferGameObjects parent, LuaFunction eachFn)
    {
        List<GameObject> lists = parent.refers;
        int count = lists.Count;
        GameObject child = null;
        for (int i = 0; i < count; i++)
        {
            child = lists[i];
            eachFn.Call(i, child);
        }
    }
}


public class Vector3Helper
{
    public static Vector3 Subtracts(Vector3 v1, Vector3 v2)
    {
        return v1 - v2;
    }
}
    //Subtracts