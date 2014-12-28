using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLoaderEventArg {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LoaderEventArg).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LoaderEventArg).AssemblyQualifiedName);
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
          System.Type superT = typeof(LoaderEventArg).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_number");
          luafn_get_number= new LuaCSFunction(get_number);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_number);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_number");
          luafn_set_number= new LuaCSFunction(set_number);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_number);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_target");
          luafn_get_target= new LuaCSFunction(get_target);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_target);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_target");
          luafn_set_target= new LuaCSFunction(set_target);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_target);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_total");
          luafn_get_total= new LuaCSFunction(get_total);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_total);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_total");
          luafn_set_total= new LuaCSFunction(set_total);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_total);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_current");
          luafn_get_current= new LuaCSFunction(get_current);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_current);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_current");
          luafn_set_current= new LuaCSFunction(set_current);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_current);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_progress");
          luafn_get_progress= new LuaCSFunction(get_progress);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_progress);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_progress");
          luafn_set_progress= new LuaCSFunction(set_progress);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_progress);
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
    
          string[] names = typeof(LoaderEventArg).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(LoaderEventArg).FullName);
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
          luafn__loadereventarg= new LuaCSFunction(_loadereventarg);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__loadereventarg);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_number;
          private static LuaCSFunction luafn_set_number;
          private static LuaCSFunction luafn_get_target;
          private static LuaCSFunction luafn_set_target;
          private static LuaCSFunction luafn_get_total;
          private static LuaCSFunction luafn_set_total;
          private static LuaCSFunction luafn_get_current;
          private static LuaCSFunction luafn_set_current;
          private static LuaCSFunction luafn_get_progress;
          private static LuaCSFunction luafn_set_progress;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn__loadereventarg;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_number(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original ;
                  var val=  target.number;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_number(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original;
                  target.number= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_target(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original ;
                  var val=  target.target;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_target(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.target= (System.Object)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_total(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original ;
                  var val=  target.total;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_total(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original;
                  target.total= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_current(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original ;
                  var val=  target.current;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_current(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original;
                  target.current= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_progress(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original ;
                  var val=  target.progress;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_progress(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LoaderEventArg target= (LoaderEventArg) original;
                  target.progress= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _loadereventarg(LuaState L)
          {

                  LoaderEventArg _loadereventarg= new LoaderEventArg();
                  ToLuaCS.push(L,_loadereventarg); 
                  return 1;

          }
  #endregion       
}

