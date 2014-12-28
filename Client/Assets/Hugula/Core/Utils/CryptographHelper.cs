﻿// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// 简单加密
/// </summary>
public class CryptographHelper
{

    /// <summary>
    /// Md5s  base64 string.
    /// </summary>
    /// <returns>
    /// The base64 string.
    /// </returns>
    /// <param name='source'>
    /// Source.
    /// </param>
    public static string CrypfString(string source, string key = "")
    {
        byte[] inputs = Encoding.UTF8.GetBytes(source);
        byte[] hash = inputs;//Md5Instance.ComputeHash(inputs);
        string outStr = System.Convert.ToBase64String(hash);
        outStr = outStr.Replace("=", "");
        outStr = outStr.Replace(@"/", "-");
        return outStr;
    }

}

