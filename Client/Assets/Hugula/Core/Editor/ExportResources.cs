// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

public class ExportResources{
	
	#region public p
	
	public const string OutLuaPath="/Tmp/"+Common.LUACFOLDER;
	public static string outConfigPath=Application.streamingAssetsPath+"/config.tz";
	//public const string zipPassword="hugula@pl@";
	public static string outAndroidZipt4f=Application.streamingAssetsPath+"/data.zip";
#if Nlua 
    #if UNITY_EDITOR_OSX
	    public static string luacPath=Application.dataPath+"/../tools/luaTools/luac";
    #else
        public static string luacPath = Application.dataPath + "/../tools/luaTools/win/luac.exe";
    #endif
#else
#if UNITY_EDITOR_OSX
	    public static string luacPath=Application.dataPath+"/../tools/luaTools/luajit";
#else
    public static string luacPath = Application.dataPath + "/../tools/luaTools/win/luajit.exe";
    #endif
#endif
	#endregion

    #region export
    [MenuItem("Hugula/", false, 11)]
    static void Breaker() { }

    [MenuItem("Hugula/export lua [Assets\\Lua]", false, 12)]
	public static void exportLua()
	{
		checkLuaExportPath();

         string  path= Application.dataPath+"/Lua"; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");
		
         List<string> files =getAllChildFiles(path);// Directory.GetFiles(Application.dataPath + path);
		
		IList<string> childrens = new List<string>();
		
		foreach (string file in files)
         {
             if (file.EndsWith("lua")) 
			 {
                 childrens.Add(file);
             }
         }
        Debug.Log("luajit path = "+luacPath);
		string crypName="",fileName="",outfilePath="",arg="";
		System.Text.StringBuilder sb=new System.Text.StringBuilder();
		 foreach (string filePath in childrens)
         {
			fileName=CUtils.GetURLFileName(filePath);
			//crypName=CryptographHelper.CrypfString(fileName);
            crypName = filePath.Replace(path,"").Replace(".lua","."+Common.LUA_LC_SUFFIX).Replace("\\","/");
			outfilePath=Application.dataPath+OutLuaPath+crypName;
            checkLuaChildDirectory(outfilePath);
#if Nlua 
             arg="-o "+outfilePath+" "+filePath;
#else
            arg = "-b " + filePath + " " + outfilePath; //for jit
#endif
            Debug.Log(arg);
            sb.Append(fileName);
            sb.Append("=");
            sb.Append(crypName);
            sb.Append("\n");

            //System.Diagnostics.Process.Start(luacPath, arg);//arg -b hello1.lua hello1.out

            File.Copy(filePath, outfilePath, true);
		 }
            Debug.Log(sb.ToString());
		 Debug.Log("lua:"+path+"files="+files.Count+" completed");

         System.Threading.Thread.Sleep(1000);
         AssetDatabase.Refresh();

        //打包成assetbundle
         string luaOut = Application.dataPath + OutLuaPath;
         Debug.Log(luaOut);
         List<string> luafiles = getAllChildFiles(luaOut + "/", Common.LUA_LC_SUFFIX);
         string assetPath = "Assets" + OutLuaPath;
         List<UnityEngine.Object> res = new List<Object>();
         string relatePathName = "";
         foreach (string name in luafiles)
         {
             relatePathName = name.Replace(luaOut, "");
             string abPath = assetPath + relatePathName;
             Debug.Log(abPath);
             Debug.Log(relatePathName);
             Object txt = AssetDatabase.LoadAssetAtPath(abPath, typeof(TextAsset));
             txt.name = relatePathName.Replace(@"\", @".").Replace("/", "").Replace("." + Common.LUA_LC_SUFFIX, "");
             //Object txt = AssetDatabase.LoadMainAssetAtPath(abPath);
             Debug.Log(txt.name);
             //Debug.Log(((TextAsset)txt).name);
             res.Add(txt);
         }

         string cname = "/font.u3d";
         string outPath = ExportAssetBundles.GetOutPath();
         string tarName = outPath + cname;
         Object[] ress = res.ToArray();
         Debug.Log(ress.Length);
         ExportAssetBundles.BuildAB(null, ress, tarName, BuildAssetBundleOptions.CompleteAssets);
         Debug.Log(tarName + " export");

         //Directory.CreateDirectory(luaOut);
         AssetDatabase.Refresh();
	}

    [MenuItem("Hugula/export config [Assets\\Config]", false, 13)]
	public static void exportConfig()
	{
		string  path= Application.dataPath+"/Config"; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");
        //FastZip f=new FastZip();
        //f.Password = Common.CONFIG_ZIP_PWD; //CryptographHelper.CrypfString(zipPassword,"");
        //f.CreateZip(outConfigPath,path,false,"^.*(.csv)$");
        //Debug.Log(" export config done: "+outConfigPath+" !");

        List<string> files = getAllChildFiles(path+"/", "csv");
        string assetPath = "Assets/Config";
        List<UnityEngine.Object> res = new List<Object>();

        foreach (string name in files)
        {
            string abPath = assetPath + name.Replace(path, "");
            Debug.Log(abPath);
            Object txt = AssetDatabase.LoadAssetAtPath(abPath, typeof(TextAsset));
            res.Add(txt);
        }

        string cname = "/config.tz";
        string outPath= ExportAssetBundles.GetOutPath();
        string tarName = outPath + cname;
        Object[] ress=res.ToArray();
        Debug.Log(ress.Length);
        ExportAssetBundles.BuildAB(null, ress, tarName, BuildAssetBundleOptions.CompleteAssets);
        Debug.Log(tarName + " export");

	}

    [MenuItem("Hugula/export language [Assets\\Lan]", false, 14)]
    public static void exportLanguage()
    {
        string assetPath = "Assets/Lan/";
        string path = Application.dataPath + "/Lan/"; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");

        List<string> files = getAllChildFiles(path,"csv");
        foreach (string name in files)
        {
            string abPath = assetPath + name.Replace(path, "");
            Debug.Log(abPath);
            Object txt = AssetDatabase.LoadAssetAtPath(abPath, typeof(TextAsset));
            string cname = txt.name;
            string outPath = ExportAssetBundles.GetOutPath();
            string tarName = outPath +"/Lan/"+ cname+"."+Common.LANGUAGE_SUFFIX;
            CheckDirectory(Application.streamingAssetsPath + "/" + ExportAssetBundles.GetTarget().ToString() + "/Lan/");
            ExportAssetBundles.BuildAB(txt, null, tarName, BuildAssetBundleOptions.CompleteAssets);
        }
    }

    [MenuItem("Hugula/", false, 15)]
    static void Breaker1() { }

    [MenuItem("Hugula/android export one key ", false, 15)]
	public static void exporAndroid()
	{
		exportLua();
		
		exportConfig();

        exportLanguage();

        autoVerAdd();
		
		string  path= Application.streamingAssetsPath+""; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");
		FastZip f=new FastZip();
		f.CreateZip(outAndroidZipt4f,path,true,"(^.*(."+Common.LUA_LC_SUFFIX+")$|ver.t$)");//[^.*(.t4f)$|Ver.txt|t4f]
		Debug.Log(" export android done: "+outConfigPath+" !");

       // Directory.Delete(Application.streamingAssetsPath + "/" + Common.LUACFOLDER, true);
	}

    public static void autoBindAndroid()
    {

        //Directory.Delete(Application.streamingAssetsPath + "/" + BuildOptions., true);
        string dirPath = Application.streamingAssetsPath + "/" + BuildTarget.Android;
        if (Directory.Exists(dirPath)) Directory.Delete(dirPath, true);
        dirPath = Application.streamingAssetsPath + "/" + BuildTarget.iOS;
        if (Directory.Exists(dirPath)) Directory.Delete(dirPath, true);
        dirPath = Application.streamingAssetsPath + "/" + BuildTarget.StandaloneWindows;
        if (Directory.Exists(dirPath)) Directory.Delete(dirPath, true);
        dirPath = Application.streamingAssetsPath + "/PW";
        if (Directory.Exists(dirPath)) Directory.Delete(dirPath, true);

        //导出所有需要的prefab
        string assetPath = "Assets/Resource/Export/";
        string path = Application.dataPath + "/Resource/Export/"; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");

        List<string> files = getAllChildFiles(path,"prefab");
        foreach (string name in files)
        {
            string abPath = assetPath + name.Replace(path, "");
            Debug.Log(abPath);
            ExportAssetBundles.ExportNGUIAssetBundle(abPath);
        }

        //导出英雄半生像
        assetPath = "Assets/Resource/Export/HerePhoto/";
        path = Application.dataPath + "/Resource/Export/HerePhoto/";
        files = getAllChildFiles(path, "png");
        foreach (string name in files)
        {
            string abPath = assetPath + name.Replace(path, "");
            Debug.Log(abPath);
            Object txt = AssetDatabase.LoadAssetAtPath(abPath, typeof(Texture));
            string cname = txt.name;
            string outPath = ExportAssetBundles.GetOutPath();
            string tarName = outPath + "/" + cname + "." + Common.ASSETBUNDLE_SUFFIX;
            ExportAssetBundles.BuildAB(txt, null, tarName, BuildAssetBundleOptions.CompleteAssets);
            Debug.Log("export texture " + tarName);
        }

        //导出材质集合
        assetPath = "Assets/Resource/Export/Altals/";
        path = Application.dataPath + "/Resource/Export/Altals/"; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");

        files = getAllChildFiles(path, "prefab");
        foreach (string name in files)
        {
            string abPath = assetPath + name.Replace(path, "");
            Object txt = AssetDatabase.LoadAssetAtPath(abPath, typeof(GameObject));
            string cname = txt.name;
            string outPath = ExportAssetBundles.GetOutPath();
            string tarName = outPath + "/" + cname + "." + Common.ASSETBUNDLE_SUFFIX;
            ExportAssetBundles.BuildAB(txt, null, tarName, BuildAssetBundleOptions.CompleteAssets);
            System.Threading.Thread.Sleep(10);
            Debug.Log("export atlas " + tarName);
          //  ExportAssetBundles.ExportNGUIAssetBundle(abPath);
        }

        exporAndroid();

    }

    [MenuItem("Hugula/other platform export one key ", false, 16)]
	public static void exportIphone()
	{
		exportLua();
		
		exportConfig();

        exportLanguage();

        autoVerAdd();

        //if(File.Exists(outAndroidZipt4f))
        //    File.Delete(outAndroidZipt4f);
	}
	
	#endregion
	
	#region private
    /// <summary>
    /// 资源版本号自动加一
    /// </summary>
    private static void autoVerAdd()
    {
        string curr = "";
        string path=Application.streamingAssetsPath + "/Ver.t";

         using (FileStream fs = File.Open(path,FileMode.OpenOrCreate,FileAccess.Read))
        {
            StreamReader sr = new StreamReader(fs);
             curr = sr.ReadToEnd();
             Debug.Log("current ver is " + curr);
             if (curr=="")curr="0";
             curr = (int.Parse(curr)+1).ToString();
        }

         using (StreamWriter sr = new StreamWriter(path, false))
         {
             Debug.Log("new ver is " + curr);
             sr.WriteLine(curr);
         }
    }

     //string dircAssert = string.Format("{0}/{1}",Application.streamingAssetsPath,target);
     //       Application.streamingAssetsPath+"/AssetBundles/"+target.ToString();
     //   if(!Directory.Exists(dircAssert))
     //   {
     //       Directory.CreateDirectory(dircAssert);
     //   }

    private static void CheckDirectory(string fullPath)
    {
        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }
    }

    private static void checkLuaChildDirectory(string fullpath)
    {
        DirectoryInfo info = Directory.GetParent(fullpath);
        string Dir = info.FullName; 
        if (!Directory.Exists(Dir))
        {
            Directory.CreateDirectory(Dir);
        }
    }
	
	private static void checkLuaExportPath()
	{
		string dircAssert=Application.dataPath+OutLuaPath;
		if(!Directory.Exists(dircAssert))
		{
			Directory.CreateDirectory(dircAssert);
		}
	}
	
	public static List<string> getAllChildFiles(string path,string suffix="lua",List<string> files=null)
	{
		if(files==null)files=new List<string>();
		addFiles(path,suffix,files);
		string[] dires=Directory.GetDirectories(path);
		foreach(string dirp in dires)
		{
//            Debug.Log(dirp);
			getAllChildFiles(dirp,suffix,files);
		}
		return files;
	}
	
    public static void addFiles(string direPath,string suffix,List<string> files)
	{
		string[] fileMys=Directory.GetFiles(direPath);
		foreach(string f in fileMys)
		{
			if(f.ToLower().EndsWith(suffix.ToLower())) 
			{
				files.Add(f);
			}
		}
	}
	#endregion
}
