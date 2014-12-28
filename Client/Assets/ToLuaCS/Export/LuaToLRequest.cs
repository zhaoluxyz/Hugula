using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLRequest {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LRequest).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LRequest).AssemblyQualifiedName);
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
          System.Type superT = typeof(LRequest).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_onCompleteFn");
          luafn_get_onCompleteFn= new LuaCSFunction(get_onCompleteFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onCompleteFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onCompleteFn");
          luafn_set_onCompleteFn= new LuaCSFunction(set_onCompleteFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onCompleteFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onEndFn");
          luafn_get_onEndFn= new LuaCSFunction(get_onEndFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onEndFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onEndFn");
          luafn_set_onEndFn= new LuaCSFunction(set_onEndFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onEndFn);
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
    
          string[] names = typeof(LRequest).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(LRequest).FullName);
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
          luafn__lrequest= new LuaCSFunction(_lrequest);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__lrequest);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_onCompleteFn;
          private static LuaCSFunction luafn_set_onCompleteFn;
          private static LuaCSFunction luafn_get_onEndFn;
          private static LuaCSFunction luafn_set_onEndFn;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn__lrequest;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCompleteFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LRequest target= (LRequest) original ;
                  var val=  target.onCompleteFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCompleteFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LRequest target= (LRequest) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onCompleteFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onEndFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LRequest target= (LRequest) original ;
                  var val=  target.onEndFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onEndFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LRequest target= (LRequest) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onEndFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _lrequest(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 

                  System.Int32 priority_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.String key_ =  LuaDLL.lua_tostring(L,4); 

                  System.String type_ =  LuaDLL.lua_tostring(L,5); 


                  LRequest _lrequest= new LRequest( url_, priority_, key_, type_);
                  ToLuaCS.push(L,_lrequest); 
                  return 1;

          }
  #endregion       
}

