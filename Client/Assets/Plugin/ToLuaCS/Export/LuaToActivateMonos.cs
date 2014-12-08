using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToActivateMonos {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(ActivateMonos).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(ActivateMonos).AssemblyQualifiedName);
          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(L, 1);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__gc");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
          LuaDLL.lua_rawset(L, -3);

      #region 判断父类
          System.Type superT = typeof(ActivateMonos).BaseType;
          if (superT != null)
          {
              LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);
              if (!LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_setmetatable(L, -2);
              }
              else
              {
                  LuaDLL.lua_remove(L, -1);
              }
          }
      #endregion

      #region  注册实例luameta
          LuaDLL.lua_pushstring(L,"get_monos");
          luafn_get_monos= new LuaCSFunction(get_monos);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_monos);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_monos");
          luafn_set_monos= new LuaCSFunction(set_monos);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_monos);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_activateGameObj");
          luafn_get_activateGameObj= new LuaCSFunction(get_activateGameObj);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_activateGameObj);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_activateGameObj");
          luafn_set_activateGameObj= new LuaCSFunction(set_activateGameObj);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_activateGameObj);
          LuaDLL.lua_rawset(L, -3);

      #endregion

  #region  static method       
          //static    
          LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
          LuaDLL.lua_getglobal(L,ToLuaCS.GlobalTableName);
          if (LuaDLL.lua_isnil(L, -1))
          {
             LuaDLL.lua_newtable(L);//table
             LuaDLL.lua_setglobal(L, ToLuaCS.GlobalTableName);//pop table
             LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
             LuaDLL.lua_getglobal(L, ToLuaCS.GlobalTableName);
          }
    
          string[] names = typeof(ActivateMonos).FullName.Split(new char[] { '.' });
          foreach (string name in names)
          {
              LuaDLL.lua_getfield(L, -1, name);
              if (LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_pop(L, 1);
                  LuaDLL.lua_pushstring(L, name);
                  LuaDLL.lua_newtable(L);
                  LuaDLL.lua_rawset(L, -3);
                  LuaDLL.lua_getfield(L, -1, name);
              }   
    
              LuaDLL.lua_remove(L, -2);
          }
          LuaDLL.lua_pushstring(L, "name");
          LuaDLL.lua_pushstring(L, typeof(ActivateMonos).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"__call");
          luafn__activatemonos= new LuaCSFunction(_activatemonos);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__activatemonos);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_monos;
          private static LuaCSFunction luafn_set_monos;
          private static LuaCSFunction luafn_get_activateGameObj;
          private static LuaCSFunction luafn_set_activateGameObj;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn__activatemonos;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_monos(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ActivateMonos target= (ActivateMonos) original ;
                  var val=  target.monos;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_monos(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ActivateMonos target= (ActivateMonos) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.monos= (System.Collections.Generic.List<UnityEngine.MonoBehaviour>)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_activateGameObj(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ActivateMonos target= (ActivateMonos) original ;
                  var val=  target.activateGameObj;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_activateGameObj(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ActivateMonos target= (ActivateMonos) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.activateGameObj= (System.Collections.Generic.List<UnityEngine.GameObject>)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _activatemonos(LuaState L)
          {

                  ActivateMonos _activatemonos= new ActivateMonos();
                  ToLuaCS.push(L,_activatemonos); 
                  return 1;

          }
  #endregion       
}

