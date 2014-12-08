// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
using UnityEditor;

public class AnimationConvert
{


    [MenuItem("Assets/AnimationConv/ConvertGe", false, 0)]
    static public void ConvertGe()
    {
        Debug.Log("Create map ");
        // AssetDatabase.CreateAsset();
        foreach (Object o in Selection.objects)
        {
            Debug.Log(o.name + " " + o.GetType().Name);
            if (o is AnimationClip)
            {
                // ((AnimationClip)o).t
                AnimationClip t = o as AnimationClip;
                //t.a
            }
        }
    }

    [MenuItem("Assets/AnimationConv/ConvertLeg", false, 1)]
    static public void ConvertLeg()
    {
        Debug.Log("Create map ");
        // AssetDatabase.CreateAsset();
        foreach (Object o in Selection.objects)
        {
            Debug.Log(o.name + " " + o.GetType().Name);
            if (o is AnimationClip)
            {
                // ((AnimationClip)o).t

            }
        }
    }

    [MenuItem("Assets/AnimationConv/IncludeAllShader", false, 1)]
    static public void IncludeAllShader()
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/GraphicsSettings.asset")[0]);
        SerializedProperty it = tagManager.GetIterator();
        SerializedProperty includeShader = null;
        while (it.NextVisible(true))
        {
            if (it.name == "m_AlwaysIncludedShaders")
            {
                for (int i = 0; i < it.arraySize; i++)
                {
                    SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
                    Debug.Log(dataPoint.objectReferenceValue);
                    includeShader = it;
                    break;
                }
            }
        }

        //int size = includeShader.arraySize;
        //includeShader.InsertArrayElementAtIndex(size - 1);

        //SerializedProperty dataPoint1 = it.GetArrayElementAtIndex(size);
        //Debug.Log(dataPoint1.objectReferenceValue);

    }

}
