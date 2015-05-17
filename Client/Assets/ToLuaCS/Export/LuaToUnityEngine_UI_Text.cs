using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_Text {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.Text);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "get_cachedTextGenerator", get_cachedTextGenerator);
           ToLuaCS.AddMember(L, "get_cachedTextGeneratorForLayout", get_cachedTextGeneratorForLayout);
           ToLuaCS.AddMember(L, "get_defaultMaterial", get_defaultMaterial);
           ToLuaCS.AddMember(L, "get_mainTexture", get_mainTexture);
           ToLuaCS.AddMember(L, "FontTextureChanged", FontTextureChanged);
           ToLuaCS.AddMember(L, "get_font", get_font);
           ToLuaCS.AddMember(L, "set_font", set_font);
           ToLuaCS.AddMember(L, "get_text", get_text);
           ToLuaCS.AddMember(L, "set_text", set_text);
           ToLuaCS.AddMember(L, "get_supportRichText", get_supportRichText);
           ToLuaCS.AddMember(L, "set_supportRichText", set_supportRichText);
           ToLuaCS.AddMember(L, "get_resizeTextForBestFit", get_resizeTextForBestFit);
           ToLuaCS.AddMember(L, "set_resizeTextForBestFit", set_resizeTextForBestFit);
           ToLuaCS.AddMember(L, "get_resizeTextMinSize", get_resizeTextMinSize);
           ToLuaCS.AddMember(L, "set_resizeTextMinSize", set_resizeTextMinSize);
           ToLuaCS.AddMember(L, "get_resizeTextMaxSize", get_resizeTextMaxSize);
           ToLuaCS.AddMember(L, "set_resizeTextMaxSize", set_resizeTextMaxSize);
           ToLuaCS.AddMember(L, "get_alignment", get_alignment);
           ToLuaCS.AddMember(L, "set_alignment", set_alignment);
           ToLuaCS.AddMember(L, "get_fontSize", get_fontSize);
           ToLuaCS.AddMember(L, "set_fontSize", set_fontSize);
           ToLuaCS.AddMember(L, "get_horizontalOverflow", get_horizontalOverflow);
           ToLuaCS.AddMember(L, "set_horizontalOverflow", set_horizontalOverflow);
           ToLuaCS.AddMember(L, "get_verticalOverflow", get_verticalOverflow);
           ToLuaCS.AddMember(L, "set_verticalOverflow", set_verticalOverflow);
           ToLuaCS.AddMember(L, "get_lineSpacing", get_lineSpacing);
           ToLuaCS.AddMember(L, "set_lineSpacing", set_lineSpacing);
           ToLuaCS.AddMember(L, "get_fontStyle", get_fontStyle);
           ToLuaCS.AddMember(L, "set_fontStyle", set_fontStyle);
           ToLuaCS.AddMember(L, "get_pixelsPerUnit", get_pixelsPerUnit);
           ToLuaCS.AddMember(L, "GetGenerationSettings", GetGenerationSettings);
           ToLuaCS.AddMember(L, "CalculateLayoutInputHorizontal", CalculateLayoutInputHorizontal);
           ToLuaCS.AddMember(L, "CalculateLayoutInputVertical", CalculateLayoutInputVertical);
           ToLuaCS.AddMember(L, "get_minWidth", get_minWidth);
           ToLuaCS.AddMember(L, "get_preferredWidth", get_preferredWidth);
           ToLuaCS.AddMember(L, "get_flexibleWidth", get_flexibleWidth);
           ToLuaCS.AddMember(L, "get_minHeight", get_minHeight);
           ToLuaCS.AddMember(L, "get_preferredHeight", get_preferredHeight);
           ToLuaCS.AddMember(L, "get_flexibleHeight", get_flexibleHeight);
           ToLuaCS.AddMember(L, "get_layoutPriority", get_layoutPriority);
           ToLuaCS.AddMember(L, "OnRebuildRequested", OnRebuildRequested);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "GetTextAnchorPivot", GetTextAnchorPivot);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cachedTextGenerator(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.TextGenerator cachedTextGenerator= target.cachedTextGenerator;
                  ToLuaCS.push(L,cachedTextGenerator);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cachedTextGeneratorForLayout(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.TextGenerator cachedTextGeneratorForLayout= target.cachedTextGeneratorForLayout;
                  ToLuaCS.push(L,cachedTextGeneratorForLayout);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_defaultMaterial(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.Material defaultMaterial= target.defaultMaterial;
                  ToLuaCS.push(L,defaultMaterial);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_mainTexture(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.Texture mainTexture= target.mainTexture;
                  ToLuaCS.push(L,mainTexture);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FontTextureChanged(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.FontTextureChanged();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_font(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.Font font= target.font;
                  ToLuaCS.push(L,font);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_font(LuaState L)
          {
                  UnityEngine.Font value_ = (UnityEngine.Font)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.font= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_text(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.String text= target.text;
                  LuaDLL.lua_pushstring(L, text);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_text(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.text= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_supportRichText(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Boolean supportRichText= target.supportRichText;
                  LuaDLL.lua_pushboolean(L,supportRichText);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_supportRichText(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.supportRichText= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_resizeTextForBestFit(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Boolean resizeTextForBestFit= target.resizeTextForBestFit;
                  LuaDLL.lua_pushboolean(L,resizeTextForBestFit);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_resizeTextForBestFit(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.resizeTextForBestFit= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_resizeTextMinSize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Int32 resizeTextMinSize= target.resizeTextMinSize;
                  LuaDLL.lua_pushnumber(L, resizeTextMinSize);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_resizeTextMinSize(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.resizeTextMinSize= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_resizeTextMaxSize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Int32 resizeTextMaxSize= target.resizeTextMaxSize;
                  LuaDLL.lua_pushnumber(L, resizeTextMaxSize);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_resizeTextMaxSize(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.resizeTextMaxSize= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_alignment(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.TextAnchor alignment= target.alignment;
                  ToLuaCS.push(L,alignment);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_alignment(LuaState L)
          {
                  UnityEngine.TextAnchor value_ = (UnityEngine.TextAnchor)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.alignment= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fontSize(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Int32 fontSize= target.fontSize;
                  LuaDLL.lua_pushnumber(L, fontSize);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fontSize(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.fontSize= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_horizontalOverflow(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.HorizontalWrapMode horizontalOverflow= target.horizontalOverflow;
                  ToLuaCS.push(L,horizontalOverflow);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_horizontalOverflow(LuaState L)
          {
                  UnityEngine.HorizontalWrapMode value_ = (UnityEngine.HorizontalWrapMode)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.horizontalOverflow= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_verticalOverflow(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.VerticalWrapMode verticalOverflow= target.verticalOverflow;
                  ToLuaCS.push(L,verticalOverflow);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_verticalOverflow(LuaState L)
          {
                  UnityEngine.VerticalWrapMode value_ = (UnityEngine.VerticalWrapMode)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.verticalOverflow= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_lineSpacing(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Single lineSpacing= target.lineSpacing;
                  LuaDLL.lua_pushnumber(L, lineSpacing);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_lineSpacing(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.lineSpacing= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_fontStyle(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.FontStyle fontStyle= target.fontStyle;
                  ToLuaCS.push(L,fontStyle);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_fontStyle(LuaState L)
          {
                  UnityEngine.FontStyle value_ = (UnityEngine.FontStyle)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.fontStyle= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pixelsPerUnit(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Single pixelsPerUnit= target.pixelsPerUnit;
                  LuaDLL.lua_pushnumber(L, pixelsPerUnit);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetGenerationSettings(LuaState L)
          {
                  UnityEngine.Vector2 extents_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  UnityEngine.TextGenerationSettings getgenerationsettings= target.GetGenerationSettings( extents_);
                  ToLuaCS.push(L,getgenerationsettings);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CalculateLayoutInputHorizontal(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.CalculateLayoutInputHorizontal();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CalculateLayoutInputVertical(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.CalculateLayoutInputVertical();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_minWidth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Single minWidth= target.minWidth;
                  LuaDLL.lua_pushnumber(L, minWidth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_preferredWidth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Single preferredWidth= target.preferredWidth;
                  LuaDLL.lua_pushnumber(L, preferredWidth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_flexibleWidth(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Single flexibleWidth= target.flexibleWidth;
                  LuaDLL.lua_pushnumber(L, flexibleWidth);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_minHeight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Single minHeight= target.minHeight;
                  LuaDLL.lua_pushnumber(L, minHeight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_preferredHeight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Single preferredHeight= target.preferredHeight;
                  LuaDLL.lua_pushnumber(L, preferredHeight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_flexibleHeight(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Single flexibleHeight= target.flexibleHeight;
                  LuaDLL.lua_pushnumber(L, flexibleHeight);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_layoutPriority(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  System.Int32 layoutPriority= target.layoutPriority;
                  LuaDLL.lua_pushnumber(L, layoutPriority);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnRebuildRequested(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.Text target= (UnityEngine.UI.Text) original ;
                  target.OnRebuildRequested();
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetTextAnchorPivot(LuaState L)
          {
                  UnityEngine.TextAnchor anchor_ = (UnityEngine.TextAnchor)ToLuaCS.getObject(L, 1);

                  UnityEngine.Vector2 gettextanchorpivot= UnityEngine.UI.Text.GetTextAnchorPivot( anchor_);
                  ToLuaCS.push(L,gettextanchorpivot);
                  return 1;

          }
  #endregion       
}

