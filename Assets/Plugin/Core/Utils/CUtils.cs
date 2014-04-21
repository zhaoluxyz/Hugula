
using UnityEngine;
using System.Collections;
using System.IO;

public class CUtils {
	
	/// <summary>
	/// Gets the Suffix of the URL file.
	/// </summary>
	/// <returns>
	/// The URL file type.
	/// </returns>
	/// <param name='url'>
	/// url.
	/// </param>
	public static string GetURLFileSuffix(string url)
	{
		int last=url.LastIndexOf(".");
		int end=url.IndexOf("?");
		if(end==-1)
			end=url.Length;
		else
		{
			last=url.IndexOf(".",0,end);
		}
//		Debug.Log(string.Format("last={0},end={1}",last,end));
		string cut=url.Substring(last,end-last).Replace(".","");
		return cut;
	}
	
	/// <summary>
	/// Gets the name of the URL file.
	/// </summary>
	/// <returns>
	/// The URL file name.
	/// </returns>
	/// <param name='url'>
	/// URL.
	/// </param>
	public static string GetURLFileName(string url)
	{
		//Debug.Log(url);
		string re = "";
    	int len = url.Length - 1;
		char[] arr=url.ToCharArray();
	    while (len >= 0 && arr[len] != '/' && arr[len] != '\\')
			len = len - 1;
    	//int sub = (url.Length - 1) - len;
		//int end=url.Length-sub;
			
		re = url.Substring(len+1);
		int last=re.LastIndexOf(".");
		string cut=re.Substring(0,last);
		return cut;
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static string GetKeyURLFileName(string url)
    {
        //Debug.Log(url);
        string re = "";
        int len = url.Length - 1;
        char[] arr = url.ToCharArray();
        while (len >= 0 && arr[len] != '/' && arr[len] != '\\')
            len = len - 1;
        //int sub = (url.Length - 1) - len;
        //int end=url.Length-sub;

        re = url.Substring(len + 1);
        int last = re.LastIndexOf(".");
        string cut = re.Substring(0, last);
        cut = cut.Replace('.', '_');
        return cut;
    }
	
	public static string GetURLFullFileName(string url)
	{
		//Debug.Log(url);
		string re = "";
    	int len = url.Length - 1;
		char[] arr=url.ToCharArray();
	    while (len >= 0 && arr[len] != '/' && arr[len] != '\\')
			len = len - 1;
		
		re = url.Substring(len+1);
		return re;
	}
	
	/// <summary>
	/// Gets the file full path for www
	/// form Application.dataPath
	/// </summary>
	/// <returns>
	/// The file full path.
	/// </returns>
	/// <param name='absolutePath'>
	/// Absolute path.
	/// </param>
	public static string GetFileFullPath(string absolutePath)
	{
		string path="";
		
		path=Application.persistentDataPath+"/"+absolutePath;
		currPersistentExist=File.Exists(path);
		if(!currPersistentExist)
			path=Application.streamingAssetsPath+"/"+absolutePath;
		
		if (path.IndexOf("://")==-1)
		{
			path="file://"+path;
		}
		
		return path;
	}

    /// <summary>
    /// get assetBunld full path
    /// </summary>
    /// <param name="assetPath"></param>
    /// <returns></returns>
    public static string GetAssetFullPath(string assetPath)
    {
        string path = GetFileFullPath(GetAssetPath(assetPath));
        return path;
    }
	
	/// <summary>
	/// Gets the file full path.
	/// </summary>
	/// <returns>
	/// The file full path.
	/// </returns>
	/// <param name='absolutePath'>
	/// Absolute path.
	/// </param>
	public static string GetFileFullPathNoProtocol(string absolutePath)
	{
		string path=Application.persistentDataPath+"/"+absolutePath;
		currPersistentExist=File.Exists(path);
		if(!currPersistentExist)
			path=Application.streamingAssetsPath+"/"+absolutePath;
		
		return path;
	}
	
	public static string GetDirectoryFullPathNoProtocol(string absolutePath)
	{
		string path=Application.persistentDataPath+"/"+absolutePath;
		currPersistentExist=Directory.Exists(path);
		if(!currPersistentExist)
			path=Application.streamingAssetsPath+"/"+absolutePath;
		
		return path;
	}
	
	public static string dataPath
	{
		get{
#if UNITY_EDITOR
			return Application.streamingAssetsPath;
#else
			return Application.persistentDataPath;		
#endif
		}
	}
	
	
	public static string GetAssetPath(string name)
	{
		string Platform="";
		#if UNITY_IPHONE
			Platform="iPhone";
		#elif UNITY_ANDROID
			Platform="Android";
		#elif UNITY_WP8
			Platform="WP8Player";
        #elif UNITY_METRO
            Platform = "MetroPlayer";
        #elif UNITY_OSX
             Platform = "StandaloneOSXIntel";
        #else
            Platform ="StandaloneWindows";
        #endif
            string path = System.String.Format("{0}/{1}/{2}", Common.ASSETBUNDLE_FOLDER, Platform, name);
        return path;
	}
	
	public static bool currPersistentExist=false;

	public static void Collect()
	{
		System.GC.Collect();
	}

    public static System.Type GetType(object obj)
    {
        return obj.GetType();
    }

	public static void RefreshShader(AssetBundle assetBundle)
	{
		UnityEngine.Object[] materials = assetBundle.LoadAll(typeof(Material)) ;
		foreach(UnityEngine.Object m in materials)
		{
			Material mat = m as Material;
			
			string shaderName = mat.shader.name;
			Shader newShader = Shader.Find(shaderName);
			if(newShader != null)
			{
				mat.shader = newShader;
			}
			else
			{
				Debug.LogWarning("unable to refresh shader: "+ shaderName + " in material " + m.name);
			}
		}
	}

	public static void RefreshShader(WWW www)
	{
		if(www.assetBundle!=null)RefreshShader(www.assetBundle);
	}
}
