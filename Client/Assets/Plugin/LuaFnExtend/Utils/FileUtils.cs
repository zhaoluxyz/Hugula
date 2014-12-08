// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

#if Nlua
using NLua;
#else
using LuaInterface;
#endif

public class FileUtils {
	
    private string _syspath = "";
    //每行的内容
    private ArrayList infoall;

	public FileUtils ()  
    {  
        _syspath = Application.persistentDataPath;  
    }  
	
   /**用于创建可读写空间的文件
   * name：文件的名称
   * info：写入的内容
   * overwrite：是否覆盖
   */
   public void CreateFile(string name,string info,bool overwrite = false)
   {
	  Debug.Log ("createFile ... ");
      //文件流信息
      StreamWriter sw;
      FileInfo t = new FileInfo(_syspath + "//" + name);
      if(!t.Exists)
      {
			Debug.Log ("createFile ... 1");
        //如果此文件不存在则创建
        sw = t.CreateText();
      }
      else
      {
			Debug.Log ("createFile ... 2");

        if(overwrite) 
       	  sw = t.CreateText();  
        else  
          sw = t.AppendText();   
      }
		Debug.Log (info);
      //以行的形式写入信息
      sw.WriteLine(info);
      //关闭流
      sw.Close();
      //销毁流
      sw.Dispose();
   } 
 
  /**用于写可读写空间的文件
   * name：读取文件的名称
   */
	public string ReadFile (string name)  
	{     
		//使用流的形式读取  
		StreamReader sr = null;     
		try {  
			sr = File.OpenText (_syspath + "//" + name);     
		} catch (Exception e) {  
			//路径与名称未找到文件则直接返回空  
			return null;  
		}     
		string data = sr.ReadToEnd ();  
		
		//关闭流  
		sr.Close ();   
		//销毁流  
		sr.Dispose ();  
		//将数组链表容器返回     
		return data;     
	}      
//   public ArrayList ReadFile(string name)
//   {
//		Debug.Log ("ReadFile ... 1");
//        //使用流的形式读取
//        StreamReader sr =null;
//        try{
//            sr = File.OpenText(_syspath + "//" + name);
//        }catch(Exception e)
//        {
//            //路径与名称未找到文件则直接返回空
//            return null;
//        }
//        string line;
//        ArrayList arrlist = new ArrayList();
//        while ((line = sr.ReadLine()) != null)
//        {
//            //一行一行的读取
//            //将每一行的内容存入数组链表容器中
//            arrlist.Add(line);
//        }
//		Debug.Log (arrlist.ToString());
//        //关闭流
//        sr.Close();
//        //销毁流
//        sr.Dispose();
//        //将数组链表容器返回
//        return arrlist;
//   }  
 
  /**用于删除可读写空间的文件
   * name：删除文件的名称
   */
   public void DeleteFile(string name)
   {
        File.Delete(_syspath + "//" + name);
   } 
}