using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCLoader {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(CLoader).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(CLoader).AssemblyQualifiedName);
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
          System.Type superT = typeof(CLoader).BaseType;
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
          LuaDLL.lua_pushstring(L,"BeginLoad");
          luafn_BeginLoad= new LuaCSFunction(BeginLoad);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_BeginLoad);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Dispose");
          luafn_Dispose= new LuaCSFunction(Dispose);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Dispose);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isDone");
          luafn_get_isDone= new LuaCSFunction(get_isDone);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isDone);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_curretDenp");
          luafn_get_curretDenp= new LuaCSFunction(get_curretDenp);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_curretDenp);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_dependencies");
          luafn_get_dependencies= new LuaCSFunction(get_dependencies);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_dependencies);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_castTime");
          luafn_get_castTime= new LuaCSFunction(get_castTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_castTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_castTime");
          luafn_set_castTime= new LuaCSFunction(set_castTime);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_castTime);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_number");
          luafn_get_number= new LuaCSFunction(get_number);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_number);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_number");
          luafn_set_number= new LuaCSFunction(set_number);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_number);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_req");
          luafn_get_req= new LuaCSFunction(get_req);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_req);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_req");
          luafn_set_req= new LuaCSFunction(set_req);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_req);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_key");
          luafn_get_key= new LuaCSFunction(get_key);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_key);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_key");
          luafn_set_key= new LuaCSFunction(set_key);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_key);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isWait");
          luafn_get_isWait= new LuaCSFunction(get_isWait);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isWait);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_isWait");
          luafn_set_isWait= new LuaCSFunction(set_isWait);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_isWait);
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
    
          string[] names = typeof(CLoader).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(CLoader).FullName);
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
          luafn__cloader= new LuaCSFunction(_cloader);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__cloader);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_BeginLoad;
          private static LuaCSFunction luafn_Dispose;
          private static LuaCSFunction luafn_get_isDone;
          private static LuaCSFunction luafn_get_curretDenp;
          private static LuaCSFunction luafn_get_dependencies;
          private static LuaCSFunction luafn_get_castTime;
          private static LuaCSFunction luafn_set_castTime;
          private static LuaCSFunction luafn_get_number;
          private static LuaCSFunction luafn_set_number;
          private static LuaCSFunction luafn_get_req;
          private static LuaCSFunction luafn_set_req;
          private static LuaCSFunction luafn_get_key;
          private static LuaCSFunction luafn_set_key;
          private static LuaCSFunction luafn_get_isWait;
          private static LuaCSFunction luafn_set_isWait;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn__cloader;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int BeginLoad(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  target.BeginLoad();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dispose(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  target.Dispose();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isDone(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  System.Boolean isDone= target.isDone;
                  ToLuaCS.push(L,isDone); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_curretDenp(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  System.Int32 curretDenp= target.curretDenp;
                  ToLuaCS.push(L,curretDenp); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dependencies(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  System.Int32 dependencies= target.dependencies;
                  ToLuaCS.push(L,dependencies); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_castTime(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  var val=  target.castTime;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_castTime(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original;
                  target.castTime= (System.Double)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_number(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  var val=  target.number;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_number(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original;
                  target.number= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_req(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  var val=  target.req;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_req(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.req= (CRequest)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_key(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  var val=  target.key;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_key(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original;
                  target.key= LuaDLL.lua_tostring(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isWait(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original ;
                  var val=  target.isWait;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isWait(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CLoader target= (CLoader) original;
                  target.isWait= LuaDLL.lua_toboolean(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _cloader(LuaState L)
          {

                  CLoader _cloader= new CLoader();
                  ToLuaCS.push(L,_cloader); 
                  return 1;

          }
  #endregion       
}

