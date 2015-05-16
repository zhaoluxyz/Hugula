using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLocalization {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(Localization);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "get_dictionary", get_dictionary);

           ToLuaCS.AddMember(L, "set_dictionary", set_dictionary);

           ToLuaCS.AddMember(L, "get_knownLanguages", get_knownLanguages);

           ToLuaCS.AddMember(L, "get_language", get_language);

           ToLuaCS.AddMember(L, "set_language", set_language);

           ToLuaCS.AddMember(L, "Load", Load);

           ToLuaCS.AddMember(L, "Get", Get);

           ToLuaCS.AddMember(L, "Exists", Exists);

           ToLuaCS.AddMember(L, "get_localizationHasBeenSet", get_localizationHasBeenSet);

           ToLuaCS.AddMember(L, "set_localizationHasBeenSet", set_localizationHasBeenSet);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dictionary(LuaState L)
          {

                  System.Collections.Generic.Dictionary<System.String,System.String> dictionary= Localization.dictionary;
                  ToLuaCS.push(L,dictionary);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_dictionary(LuaState L)
          {
                  System.Collections.Generic.Dictionary<System.String,System.String> value_ = (System.Collections.Generic.Dictionary<System.String,System.String>)ToLuaCS.getObject(L, 1);

                  Localization.dictionary= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_knownLanguages(LuaState L)
          {

                  System.String[] knownLanguages= Localization.knownLanguages;
                  ToLuaCS.push(L,knownLanguages);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_language(LuaState L)
          {

                  System.String language= Localization.language;
                  LuaDLL.lua_pushstring(L, language);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_language(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,1); 


                  Localization.language= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Load(LuaState L)
          {
                  System.Byte[] asset_ = (System.Byte[])ToLuaCS.getObject(L, 1);

                  Localization.Load( asset_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Get(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  System.String get= Localization.Get( key_);
                  LuaDLL.lua_pushstring(L, get);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Exists(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  System.Boolean exists= Localization.Exists( key_);
                  LuaDLL.lua_pushboolean(L,exists);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localizationHasBeenSet(LuaState L)
          {
                  var val=   Localization.localizationHasBeenSet;
                  LuaDLL.lua_pushboolean(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localizationHasBeenSet(LuaState L)
          {
                  Localization.localizationHasBeenSet= LuaDLL.lua_toboolean(L,1);
                  return 0;

          }
  #endregion       
}

