// using System.Collections;
// using LuaInterface;
// using Lua = LuaInterface.LuaState;
// using LuaDLL = LuaInterface.LuaDLL;
// using LuaState = System.IntPtr;
// using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
// using LuaCSFunction = LuaInterface.LuaCSFunction;
// using System.IO;
// using System.Collections.Generic;
// using System;
// using System.Collections;
// using UnityEngine;


// public static class LuaToFileUtils {

//   public static void CreateMetaTableToLua(LuaState L) {
        
//        LuaDLL.luaL_getmetatable(L, typeof(FileUtils).AssemblyQualifiedName);
//       if (LuaDLL.lua_isnil(L, -1))
//       {
//           LuaDLL.lua_settop(L, -2);
//           LuaDLL.luaL_newmetatable(L, typeof(FileUtils).AssemblyQualifiedName);
//           LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
//           LuaDLL.lua_pushnumber(L, 1);
//           LuaDLL.lua_rawset(L, -3);
//           LuaDLL.lua_pushstring(L, "__gc");
//           LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
//           LuaDLL.lua_rawset(L, -3);
//           LuaDLL.lua_pushstring(L, "__tostring");
//           LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
//           LuaDLL.lua_rawset(L, -3);

//           LuaDLL.lua_pushstring(L, "__index");
//           LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
//           LuaDLL.lua_rawset(L, -3);

//           LuaDLL.lua_pushstring(L, "__newindex");
//           LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
//           LuaDLL.lua_rawset(L, -3);

//       #region 判断父类
//           System.Type superT = typeof(FileUtils).BaseType;
//           if (superT != null)
//           {
//               LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);
//               if (!LuaDLL.lua_isnil(L, -1))
//               {
//                   LuaDLL.lua_setmetatable(L, -2);
//               }
//               else
//               {
//                   LuaDLL.lua_remove(L, -1);
//               }
//           }
//       #endregion

//       #region  注册实例luameta
          
//           LuaDLL.lua_pushstring(L,"CreateFile");
//           luafn_CreateFile= new LuaCSFunction(CreateFile);
//           LuaDLL.lua_pushstdcallcfunction(L, luafn_CreateFile);
//           LuaDLL.lua_rawset(L, -3);


//           LuaDLL.lua_pushstring(L,"ReadFile");
//           luafn_ReadFile= new LuaCSFunction(ReadFile);
//           LuaDLL.lua_pushstdcallcfunction(L, luafn_ReadFile);
//           LuaDLL.lua_rawset(L, -3);

//           LuaDLL.lua_pushstring(L,"DeleteFile");
//           luafn_DeleteFile= new LuaCSFunction(DeleteFile);
//           LuaDLL.lua_pushstdcallcfunction(L, luafn_DeleteFile);
//           LuaDLL.lua_rawset(L, -3);  
//       #endregion

//          }
// }
//   #region instances declaration       

//           private static LuaCSFunction luafn_CreateFile;
//           private static LuaCSFunction luafn_ReadFile;
//           private static LuaCSFunction luafn_DeleteFile;

//  #endregion        
//   #region statics declaration       
//  #endregion        
//   #region  instances method       
          

//           [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//           public static int CreateFile(LuaState L)
//           {
//               System.String filename =  LuaDLL.lua_tostring(L,2);
//               System.String filetext =  LuaDLL.lua_tostring(L,3);  
//               System.Boolean reWrite =  LuaDLL.lua_toboolean(L,4);

//               object original = ToLuaCS.getObject(L, 1);
//               FileUtils target= (FileUtils) original ;
//               target.CreateFile(filename,filetext);
//              return 0;

//           }
        
//           [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//           public static int ReadFile(LuaState L)
//           {
//               System.String filename =  LuaDLL.lua_tostring(L,2);
//               object original = ToLuaCS.getObject(L, 1);
//               FileUtils target= (FileUtils) original ;
//               System.String readstring= target.ReadFile(filename);
//               ToLuaCS.push(L,readstring); 
//               return 1;

//           }
//           [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//           public static int DeleteFile(LuaState L)
//           {
//               System.String filename =  LuaDLL.lua_tostring(L,2);
//               object original = ToLuaCS.getObject(L, 1);
//               FileUtils target= (FileUtils) original ;
//               target.DeleteFile(filename);
//               return 0;

//           }
      
//   #endregion       
//   #region  static method       
//   #endregion       
// }

