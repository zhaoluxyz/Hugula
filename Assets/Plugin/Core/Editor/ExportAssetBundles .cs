// C# Example
// Builds an asset bundle from the selected objects in the project view.
// Once compiled go to "Menu" -> "Assets" and select one of the choices
// to build the Asset Bundle

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public class ExportAssetBundles
{
    public const string outPath = "Assets/StreamingAssets/"+Common.ASSETBUNDLE_FOLDER;
    public const string suffix = Common.ASSETBUNDLE_SUFFIX;
	
    private const BuildAssetBundleOptions optionsDefault = BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets; //
	private const BuildAssetBundleOptions optionsDependency = BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.CompleteAssets |  BuildAssetBundleOptions.CollectDependencies ;// 
#if UNITY_IPHONE
	const BuildTarget target=BuildTarget.iPhone;
#elif UNITY_ANDROID
	const BuildTarget target=BuildTarget.Android;
#elif UNITY_WP8
	const BuildTarget target=BuildTarget.WP8Player;
#elif UNITY_METRO
    const BuildTarget target = BuildTarget.MetroPlayer;
#elif UNITY_OSX
     const BuildTarget target = BuildTarget.StandaloneOSXIntel;
#else
	const BuildTarget target=BuildTarget.StandaloneWindows;
#endif

    #region menuitem
    /**
	#region iphone
	
	[MenuItem("Assets/iPhone AssetBundle UI Build ")]
	public static void ExportIPhoneUIGroup()
	{
		ExportGourpAssetBundleDependenGameObject(BuildTarget.iPhone);
	}
	
	[MenuItem("Assets/iPhone [folder]  AssetBundle UI Build ")]
    public static void ExportIPhoneUIFolder()
	{
		ExportFolderDependencies(BuildTarget.iPhone);
	}
	
	[MenuItem("Assets/iPhone Texture AssetBundle Build (share .texture)")]
	public static void ExportIphoneAssetBundle()
	{
		ExportGourpAssetBundle(BuildTarget.iPhone);
	}
	
	#endregion
	
	#region Android
	
	[MenuItem("Assets/Android AssetBundle UI Build ")]
	static void ExportAndroidUIGroup()
	{
		ExportGourpAssetBundleDependenGameObject(BuildTarget.Android);
	}
	
	[MenuItem("Assets/Android [folder]  AssetBundle UI Build ")]
    static void ExportAndroidUIFolder()
	{
		ExportFolderDependencies(BuildTarget.Android);
	}
	
	[MenuItem("Assets/Android Texture AssetBundle Build (share .texture)")]
	static void ExportAndroidAssetBundle()
	{
		ExportGourpAssetBundle(BuildTarget.Android);
	}
	
	#endregion
	
	#region wp8
	
	[MenuItem("Assets/wp8 AssetBundle UI Build ")]
	static void Exportwp8UIGroup()
	{
		ExportGourpAssetBundleDependenGameObject(BuildTarget.WP8Player);
	}
	
	[MenuItem("Assets/wp8 [folder]  AssetBundle UI Build")]
    static void Exportwp8UIFolder()
	{
		ExportFolderDependencies(BuildTarget.WP8Player);
	}
	
	[MenuItem("Assets/wp8 Texture AssetBundle Build (share .texture)")]
	static void Exportwp8AssetBundle()
	{
		ExportGourpAssetBundle(BuildTarget.WP8Player);
	}
	
	#endregion
	*/
	#region selected
    [MenuItem("Assets/AssetBundle Build")]
    static void ExportAssetBundle()
    {
        ExportGourpAssetBundleDependenGameObjectNotNGUI(target);
    }
	
	[MenuItem("Assets/NGUI AssetBundle UI Build")]
	static void ExportSelectedUIGroup()
	{
		ExportGourpAssetBundleDependenGameObject(target);
	}
	
	[MenuItem("Assets/NGUI [folder]  AssetBundle UI Build")]
    static void ExportselectedUIFolder()
	{
		ExportFolderDependencies(target);
	}
	
	[MenuItem("Assets/Texture AssetBundle Build (share .texture)")]
	static void ExportselectedAssetBundle()
	{
		ExportGourpAssetBundle(target);
	}
	
	#endregion
	
	#endregion
	
	#region protected 
	
    static void ExportGourpAssetBundleDependenGameObjectNotNGUI(BuildTarget btarget)
    {

        checkstreamingAssetsPath();

        string path = "";

        Object[] selection = Selection.objects;
        string name;
        foreach (Object s in selection)
        {
            if (s is GameObject)
            {
                path = AssetDatabase.GetAssetPath(s);
                //ExportSingleAssetGameObjectDependenciesCorssReference(Path, optionsDefault, btarget);
              
                 Debug.Log("path :"+path);
                    name = s.name + "." + suffix;
                    name = name.Replace(" ", "_");//
                    string tarName = getOutPutPath(btarget) + "/" + name;
                    //File.Delete(tarName); AssetDatabase.LoadMainAssetAtPath(path)
                    BuildPipeline.BuildAssetBundle(s, null, tarName,optionsDependency , btarget);

#if UNITY_EDITOR
                    Debug.Log(" Export :" + s.name);
#endif
                    System.Threading.Thread.Sleep(10);
            }
        }

        EditorUtility.UnloadUnusedAssets();
    }

	static void ExportGourpAssetBundleDependenGameObject(BuildTarget btarget)
	{
		
		checkstreamingAssetsPath();
				
		string Path = "";
		
		BuildPipeline.PushAssetDependencies();
		Object[] selection=Selection.objects;

		foreach(Object s in  selection)
		{
			if(s is GameObject)
			{
				Path=AssetDatabase.GetAssetPath(s);
				ExportSingleAssetGameObjectDependenciesCorssReference(Path,optionsDefault,btarget);
				//System.Threading.Thread.Sleep(10);
			}
		}
		
		BuildPipeline.PopAssetDependencies();
		EditorUtility.UnloadUnusedAssets();
	}
	
	static void ExportFolderDependencies(BuildTarget btarget)
     {
		
		checkstreamingAssetsPath();

         Object obj = Selection.activeObject;
         if (obj == null)
         {
             Debug.LogException(new System.Exception("必须选择一个文件夹！"), obj);
         }

         string  path=  AssetDatabase.GetAssetPath(obj).Replace("Assets","");
         List<string> files =getAllChildFiles(Application.dataPath + path);// Directory.GetFiles(Application.dataPath + path);

#if UNITY_EDITOR
         Debug.Log("floder Asset Bundles:"+path+"files="+files.Count);
#endif
         IList<string> childrens = new List<string>();

		foreach (string file in files)
         {
             if (file.EndsWith("prefab")) 
			 {
                 childrens.Add(getAssetPath(file));
             }
         }

         BuildPipeline.PushAssetDependencies();

         foreach (string filePath in childrens)
         {
             ExportSingleAssetGameObjectDependenciesCorssReference(filePath, optionsDefault,btarget);
         }

         BuildPipeline.PopAssetDependencies();
		EditorUtility.UnloadUnusedAssets();
     }
	
	static void ExportGourpAssetBundle(BuildTarget btarget)
	{
		
		checkstreamingAssetsPath();

		string Path = "";
		
		BuildPipeline.PushAssetDependencies();
		Object[] selection=Selection.objects;

		foreach(Object s in  selection)
		{
			if(s is GameObject)
			{
				Path=AssetDatabase.GetAssetPath(s);
				ExportSingleAssetTextureDependenciesCorssReference(Path,optionsDefault,btarget);
				System.Threading.Thread.Sleep(10);
			}
		}
		
		BuildPipeline.PopAssetDependencies();
		
		EditorUtility.UnloadUnusedAssets();
	}
	
	
	static void checkstreamingAssetsPath()
	{
        string dircAssert = string.Format("{0}/{1}/{2}",Application.streamingAssetsPath,Common.ASSETBUNDLE_FOLDER,target);
           // Application.streamingAssetsPath+"/AssetBundles/"+target.ToString();
		if(!Directory.Exists(dircAssert))
		{
			Directory.CreateDirectory(dircAssert);
		}
		
		Debug.Log(string.Format("current BuildTarget ={0}",target));
	}
	
    static void ExportSingleAssetTextureDependenciesCorssReference(string path,BuildAssetBundleOptions options,BuildTarget buildTarget)
     {
         Object obj =  AssetDatabase.LoadMainAssetAtPath(path);
		 string mainPath=path;
         string name = "";// obj.name;
         Object[] denpendencies = EditorUtility.CollectDependencies(new Object[] { obj });
		bool haveTexture=false,haveGameObject=false;
		BuildPipeline.PushAssetDependencies();
			 string paths="",split="";
	         foreach (Object obj1 in denpendencies)
	         {
	             if (obj1 is UnityEngine.Texture )//|| obj1 is UnityEditor.MonoScript
	             {
	                 path = AssetDatabase.GetAssetPath(obj1);
					 name=obj1.name+ "_.texture";
					 name=name.Replace(" ","_");
	                 BuildPipeline.BuildAssetBundle(AssetDatabase.LoadMainAssetAtPath(path), null, getOutPutPath(buildTarget) + "/" + name , optionsDependency,buildTarget);//| | BuildAssetBundleOptions.UncompressedAssetBundle
			#if UNITY_EDITOR
					Debug.Log("dependencies Texture:" + obj1.name + ",type=" + obj1.GetType()+"rename "+obj1.name);
			#endif				 
					paths+=split+"AssetBundles/"+buildTarget.ToString()+"/"+name;
					 split=",";
					haveTexture=true;
	             }
	         }
		
			if(haveTexture)	BuildPipeline.PushAssetDependencies();
		 	foreach (Object obj1 in denpendencies)
	         {
				if(obj1 is UnityEngine.GameObject)
				{
					path = AssetDatabase.GetAssetPath(obj1);
					if(path!=mainPath)
					{
						//Debug.Log("path :"+path);
					haveGameObject=true;
						 name=obj1.name+ "." + suffix;
						 name=name.Replace(" ","_");
		                 BuildPipeline.BuildAssetBundle(AssetDatabase.LoadMainAssetAtPath(path), null, getOutPutPath(buildTarget) + "/" + name , options,buildTarget);
									
						paths+=split+"AssetBundles/"+buildTarget.ToString()+"/"+name;
						 split=",";
			#if UNITY_EDITOR
						Debug.Log("dependencies GameObject:" + obj1.name + ",type=" + obj1.GetType()+"rename "+obj1.name);
			#endif	
					}
				}
	         }
			
	         		name = "/" + obj.name + "." + suffix;
		
				       if(haveGameObject) BuildPipeline.PushAssetDependencies();
						if(paths!="")
						{
							GameObject game=new GameObject();
							CDependencies denp=game.AddComponent<CDependencies>();
							denp.paths=paths;
							GameObject c_dependen=PrefabUtility.CreatePrefab("Assets/CObjDependencies.prefab",game);
				
							BuildPipeline.BuildAssetBundle(obj ,new Object[]{c_dependen}, getOutPutPath(buildTarget) + name, options,buildTarget);
						#if UNITY_EDITOR
							Debug.Log(name+" has export Contains :"+paths);
						#endif		
							GameObject.DestroyImmediate(game);
						}
						else
						{
				         	BuildPipeline.BuildAssetBundle(obj ,null, getOutPutPath(buildTarget) + name, options,buildTarget);
							Debug.Log(name+" has export");
				
						}
						
				       if(haveGameObject)  BuildPipeline.PopAssetDependencies();
		 		if(haveTexture)BuildPipeline.PopAssetDependencies();
         BuildPipeline.PopAssetDependencies();
		
     }

    static string getAssetPath(string fullPath)
     {
         return fullPath.Replace(Application.dataPath, "Assets");
     }
	
	static List<string> getAllChildFiles(string path,List<string> files=null)
	{
		if(files==null)files=new List<string>();
		addFiles(path,files);
		string[] dires=Directory.GetDirectories(path);
		foreach(string dirp in dires)
		{
			getAllChildFiles(dirp,files);
		}
		return files;
	}
	
	static void addFiles(string direPath,List<string> files)
	{
		string[] fileMys=Directory.GetFiles(direPath);
		foreach(string f in fileMys)
		{
			if(f.EndsWith("prefab")) 
			{
				files.Add(f);
			}
		}
	}
	
	static string getOutPutPath(BuildTarget buildTarget)
	{
		return outPath+"/"+buildTarget.ToString();
	}
	
	static void ExportSingleAssetGameObjectDependenciesCorssReference(string path,BuildAssetBundleOptions options,BuildTarget buildTarget)
     {
         Object obj =  AssetDatabase.LoadMainAssetAtPath(path);
		 string mainPath=path;
         string name = "";// obj.name;
         Object[] denpendencies = EditorUtility.CollectDependencies(new Object[] { obj });
		bool haveGameObject=false;
		BuildPipeline.PushAssetDependencies();

			string paths="",split="";
		 	foreach (Object obj1 in denpendencies)
	         {
                if (obj1 is UnityEngine.GameObject || obj1 is UnityEngine.Font)
				{
					path = AssetDatabase.GetAssetPath(obj1);
					if(path!=mainPath)
					{
//						Debug.Log("path :"+path);
						 name=obj1.name+ "." + suffix;
						 name=name.Replace(" ","_");//
					    string tarName=getOutPutPath(buildTarget) + "/" + name;
                        BuildPipeline.BuildAssetBundle(obj1,null,tarName ,optionsDependency,buildTarget);
						paths+=split+Common.ASSETBUNDLE_FOLDER+"/"+buildTarget.ToString()+"/"+name;
						split=",";
					    haveGameObject=true;
			#if UNITY_EDITOR
						Debug.Log("dependencies :" + obj1.name + ",type=" + obj1.GetType()+","+path);
			#endif	
					System.Threading.Thread.Sleep(10);
					}
				}
	         }
			
	         name = "/" + obj.name + "." + suffix;
		
				       if(haveGameObject) BuildPipeline.PushAssetDependencies();
						if(paths!="")
						{
							GameObject game=new GameObject();
                            game.name = Common.DEPENDENCIES_OBJECT_NAME;
							CDependencies denp=game.AddComponent<CDependencies>();
							denp.paths=paths;
                            GameObject c_dependen = PrefabUtility.CreatePrefab("Assets/" + Common.DEPENDENCIES_OBJECT_NAME + ".prefab", game);
				
							BuildPipeline.BuildAssetBundle(obj ,new Object[]{c_dependen}, getOutPutPath(buildTarget) + name, options,buildTarget);
						#if UNITY_EDITOR
							Debug.Log(name+" has export Contains :"+paths);
						#endif		
							GameObject.DestroyImmediate(game);
						}
						else
						{
				         	BuildPipeline.BuildAssetBundle(obj ,null, getOutPutPath(buildTarget) + name, options,buildTarget);
							Debug.Log(name+" has export");
						}
						
				      if (haveGameObject)BuildPipeline.PopAssetDependencies();
         BuildPipeline.PopAssetDependencies();
		
     }
	
	#endregion
}
