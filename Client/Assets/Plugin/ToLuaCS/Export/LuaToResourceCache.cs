using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToResourceCache {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(ResourceCache).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(ResourceCache).AssemblyQualifiedName);
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
          System.Type superT = typeof(ResourceCache).BaseType;
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
          LuaDLL.lua_pushstring(L,"GetResource");
          luafn_GetResource= new LuaCSFunction(GetResource);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetResource);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Unload");
          luafn_Unload= new LuaCSFunction(Unload);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Unload);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Clear");
          luafn_Clear= new LuaCSFunction(Clear);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Clear);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_multipleLader");
          luafn_get_multipleLader= new LuaCSFunction(get_multipleLader);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_multipleLader);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_multipleLader");
          luafn_set_multipleLader= new LuaCSFunction(set_multipleLader);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_multipleLader);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_resdic");
          luafn_get_resdic= new LuaCSFunction(get_resdic);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_resdic);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_resdic");
          luafn_set_resdic= new LuaCSFunction(set_resdic);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_resdic);
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
    
          string[] names = typeof(ResourceCache).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(ResourceCache).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_instance");
          luafn_get_instance= new LuaCSFunction(get_instance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_instance);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"__call");
          luafn__resourcecache= new LuaCSFunction(_resourcecache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn__resourcecache);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_GetResource;
          private static LuaCSFunction luafn_Unload;
          private static LuaCSFunction luafn_Clear;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_ToString;
          private static LuaCSFunction luafn_get_multipleLader;
          private static LuaCSFunction luafn_set_multipleLader;
          private static LuaCSFunction luafn_get_resdic;
          private static LuaCSFunction luafn_set_resdic;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_instance;
          private static LuaCSFunction luafn__resourcecache;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetResource(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is CompleteHandle && ToLuaCS.getObject(L, 4) is CompleteHandle && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 6) is System.Object && LuaDLL.lua_type(L,7)==LuaTypes.LUA_TNUMBER )
              {
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 

                  CompleteHandle oncomplete_ = (CompleteHandle)ToLuaCS.getObject(L,3);
                  CompleteHandle onError_ = (CompleteHandle)ToLuaCS.getObject(L,4);
                  System.Int32 priority_ = (System.Int32)LuaDLL.lua_tonumber(L,5);
                  System.Object head_ = (System.Object)ToLuaCS.getObject(L,6);
                  System.Boolean cache_ =  LuaDLL.lua_toboolean(L,7);

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  target.GetResource( url_, oncomplete_, onError_, priority_, head_, cache_);
                 return 0;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is CompleteHandle && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 5) is System.Object && LuaDLL.lua_type(L,6)==LuaTypes.LUA_TNUMBER )
              {
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 

                  CompleteHandle oncomplete_ = (CompleteHandle)ToLuaCS.getObject(L,3);
                  System.Int32 priority_ = (System.Int32)LuaDLL.lua_tonumber(L,4);
                  System.Object head_ = (System.Object)ToLuaCS.getObject(L,5);
                  System.Boolean cache_ =  LuaDLL.lua_toboolean(L,6);

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  target.GetResource( url_, oncomplete_, priority_, head_, cache_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is System.Collections.Generic.IList<CRequest> && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Collections.Generic.IList<CRequest> reqs_ = (System.Collections.Generic.IList<CRequest>)ToLuaCS.getObject(L,2);
                  System.Boolean cache_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  target.GetResource( reqs_, cache_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is CRequest && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  CRequest req_ = (CRequest)ToLuaCS.getObject(L,2);
                  System.Boolean cache_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  target.GetResource( req_, cache_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Unload(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  target.Unload( url_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Clear(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String key_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  target.Clear( key_);
                 return 0;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  target.Clear();
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  System.Boolean equals= target.Equals( obj_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_multipleLader(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  var val=  target.multipleLader;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_multipleLader(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.multipleLader= (MultipleLoader)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_resdic(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original ;
                  var val=  target.resdic;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_resdic(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  ResourceCache target= (ResourceCache) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.resdic= (System.Collections.Generic.IDictionary<System.String,System.Object>)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_instance(LuaState L)
          {

                  ResourceCache instance= ResourceCache.instance;
                  ToLuaCS.push(L,instance); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _resourcecache(LuaState L)
          {

                  ResourceCache _resourcecache= new ResourceCache();
                  ToLuaCS.push(L,_resourcecache); 
                  return 1;

          }
  #endregion       
}

