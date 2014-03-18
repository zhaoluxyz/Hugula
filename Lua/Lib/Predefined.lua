
luanet.load_assembly("ICSharpCode.SharpZipLib")
------------------Unity3D--------------
UnityEngine=luanet.UnityEngine
Time = UnityEngine.Time
Random = UnityEngine.Random
Object=UnityEngine.Object
Debug=UnityEngine.Debug
Input=UnityEngine.Input
GameObject=UnityEngine.GameObject
PrimitiveType=UnityEngine.PrimitiveType
Rect=UnityEngine.Rect
Component=UnityEngine.Component
Quaternion=UnityEngine.Quaternion
Mathf=UnityEngine.Mathf
PlayerPrefs=UnityEngine.PlayerPrefs
SendMessageOptions=UnityEngine.SendMessageOptions
Vector2=UnityEngine.Vector2
Vector3=UnityEngine.Vector3
Screen=UnityEngine.Screen
Material=UnityEngine.Material
Resources=UnityEngine.Resources
RenderTexture=UnityEngine.RenderTexture
Texture2D=UnityEngine.Texture2D
TextureFormat=UnityEngine.TextureFormat
CameraClearFlags = UnityEngine.CameraClearFlags
Color=UnityEngine.Color
Application=UnityEngine.Application
SystemInfo=UnityEngine.SystemInfo --SystemInfo.deviceUniqueIdentifier
-------------------.Net ---------------------
Hashtable=luanet.import_type("System.Collections.Hashtable")
GC=luanet.import_type("System.GC")
--------------------custom-------------------
import("CUtils")
import("CViewHelper")
import("ToolsBegin")
import("AudioSourceEX")

Shaders=ToolsBegin.shaderDic 
ToolsBegin = ToolsBegin.instance





