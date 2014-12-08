// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
using System.IO;
using System;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

#if Nlua
using NLua;
#else
using LuaInterface;
#endif

public partial class FileHelper  {

	private static LuaFunction callBackFn;

	public static void UnpackConfigZipFn(byte[] bytes, LuaFunction luaFn)
	{
		callBackFn = luaFn;
		using (MemoryStream m = new MemoryStream(bytes))
		{
			ZipFile z = new ZipFile(m);
			z.Password = Common.CONFIG_ZIP_PWD;
			foreach (ZipEntry ze in z)
			{
				if (ze.IsFile)
				{
					Stream str = z.GetInputStream(ze);
					using (StreamReader sr = new StreamReader(str))
					{
						string conext = sr.ReadToEnd();
						if (callBackFn != null)
							callBackFn.Call(ze.Name,conext);
					}
				}
			}
			callBackFn= null;
		}
	}

    public static void UnpackConfigAssetBundleFn(AssetBundle ab, LuaFunction luaFn)
    {
        callBackFn = luaFn;
        UnityEngine.Object[] all = ab.LoadAll();

        foreach (UnityEngine.Object i in all)
        {
            if (i is TextAsset)
            {
                TextAsset a = (TextAsset)i;
                if (callBackFn != null)
                    callBackFn.Call(a.name, a.text);
            }
        }
    }
}
