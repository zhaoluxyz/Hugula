using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_UI_InputField {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.UI.InputField);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "set_shouldHideMobileInput", set_shouldHideMobileInput);
           ToLuaCS.AddMember(L, "get_shouldHideMobileInput", get_shouldHideMobileInput);
           ToLuaCS.AddMember(L, "get_text", get_text);
           ToLuaCS.AddMember(L, "set_text", set_text);
           ToLuaCS.AddMember(L, "get_isFocused", get_isFocused);
           ToLuaCS.AddMember(L, "get_caretBlinkRate", get_caretBlinkRate);
           ToLuaCS.AddMember(L, "set_caretBlinkRate", set_caretBlinkRate);
           ToLuaCS.AddMember(L, "get_textComponent", get_textComponent);
           ToLuaCS.AddMember(L, "set_textComponent", set_textComponent);
           ToLuaCS.AddMember(L, "get_placeholder", get_placeholder);
           ToLuaCS.AddMember(L, "set_placeholder", set_placeholder);
           ToLuaCS.AddMember(L, "get_selectionColor", get_selectionColor);
           ToLuaCS.AddMember(L, "set_selectionColor", set_selectionColor);
           ToLuaCS.AddMember(L, "get_onEndEdit", get_onEndEdit);
           ToLuaCS.AddMember(L, "set_onEndEdit", set_onEndEdit);
           ToLuaCS.AddMember(L, "get_onValueChange", get_onValueChange);
           ToLuaCS.AddMember(L, "set_onValueChange", set_onValueChange);
           ToLuaCS.AddMember(L, "get_onValidateInput", get_onValidateInput);
           ToLuaCS.AddMember(L, "set_onValidateInput", set_onValidateInput);
           ToLuaCS.AddMember(L, "get_characterLimit", get_characterLimit);
           ToLuaCS.AddMember(L, "set_characterLimit", set_characterLimit);
           ToLuaCS.AddMember(L, "get_contentType", get_contentType);
           ToLuaCS.AddMember(L, "set_contentType", set_contentType);
           ToLuaCS.AddMember(L, "get_lineType", get_lineType);
           ToLuaCS.AddMember(L, "set_lineType", set_lineType);
           ToLuaCS.AddMember(L, "get_inputType", get_inputType);
           ToLuaCS.AddMember(L, "set_inputType", set_inputType);
           ToLuaCS.AddMember(L, "get_keyboardType", get_keyboardType);
           ToLuaCS.AddMember(L, "set_keyboardType", set_keyboardType);
           ToLuaCS.AddMember(L, "get_characterValidation", get_characterValidation);
           ToLuaCS.AddMember(L, "set_characterValidation", set_characterValidation);
           ToLuaCS.AddMember(L, "get_multiLine", get_multiLine);
           ToLuaCS.AddMember(L, "get_asteriskChar", get_asteriskChar);
           ToLuaCS.AddMember(L, "set_asteriskChar", set_asteriskChar);
           ToLuaCS.AddMember(L, "get_wasCanceled", get_wasCanceled);
           ToLuaCS.AddMember(L, "MoveTextEnd", MoveTextEnd);
           ToLuaCS.AddMember(L, "MoveTextStart", MoveTextStart);
           ToLuaCS.AddMember(L, "ScreenToLocal", ScreenToLocal);
           ToLuaCS.AddMember(L, "OnBeginDrag", OnBeginDrag);
           ToLuaCS.AddMember(L, "OnDrag", OnDrag);
           ToLuaCS.AddMember(L, "OnEndDrag", OnEndDrag);
           ToLuaCS.AddMember(L, "OnPointerDown", OnPointerDown);
           ToLuaCS.AddMember(L, "ProcessEvent", ProcessEvent);
           ToLuaCS.AddMember(L, "OnUpdateSelected", OnUpdateSelected);
           ToLuaCS.AddMember(L, "Rebuild", Rebuild);
           ToLuaCS.AddMember(L, "ActivateInputField", ActivateInputField);
           ToLuaCS.AddMember(L, "OnSelect", OnSelect);
           ToLuaCS.AddMember(L, "OnPointerClick", OnPointerClick);
           ToLuaCS.AddMember(L, "DeactivateInputField", DeactivateInputField);
           ToLuaCS.AddMember(L, "OnDeselect", OnDeselect);
           ToLuaCS.AddMember(L, "OnSubmit", OnSubmit);
      #endregion

}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_shouldHideMobileInput(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.shouldHideMobileInput= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_shouldHideMobileInput(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  System.Boolean shouldHideMobileInput= target.shouldHideMobileInput;
                  LuaDLL.lua_pushboolean(L,shouldHideMobileInput);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_text(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  System.String text= target.text;
                  LuaDLL.lua_pushstring(L, text);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_text(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.text= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isFocused(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  System.Boolean isFocused= target.isFocused;
                  LuaDLL.lua_pushboolean(L,isFocused);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_caretBlinkRate(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  System.Single caretBlinkRate= target.caretBlinkRate;
                  LuaDLL.lua_pushnumber(L, caretBlinkRate);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_caretBlinkRate(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.caretBlinkRate= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_textComponent(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.Text textComponent= target.textComponent;
                  ToLuaCS.push(L,textComponent);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_textComponent(LuaState L)
          {
                  UnityEngine.UI.Text value_ = (UnityEngine.UI.Text)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.textComponent= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_placeholder(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.Graphic placeholder= target.placeholder;
                  ToLuaCS.push(L,placeholder);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_placeholder(LuaState L)
          {
                  UnityEngine.UI.Graphic value_ = (UnityEngine.UI.Graphic)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.placeholder= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_selectionColor(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.Color selectionColor= target.selectionColor;
                  ToLuaCS.push(L,selectionColor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_selectionColor(LuaState L)
          {
                  UnityEngine.Color value_ = (UnityEngine.Color)ToLuaCS.getColor(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.selectionColor= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onEndEdit(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.InputField.SubmitEvent onEndEdit= target.onEndEdit;
                  ToLuaCS.push(L,onEndEdit);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onEndEdit(LuaState L)
          {
                  UnityEngine.UI.InputField.SubmitEvent value_ = (UnityEngine.UI.InputField.SubmitEvent)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.onEndEdit= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onValueChange(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.InputField.OnChangeEvent onValueChange= target.onValueChange;
                  ToLuaCS.push(L,onValueChange);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onValueChange(LuaState L)
          {
                  UnityEngine.UI.InputField.OnChangeEvent value_ = (UnityEngine.UI.InputField.OnChangeEvent)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.onValueChange= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onValidateInput(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.InputField.OnValidateInput onValidateInput= target.onValidateInput;
                  ToLuaCS.push(L,onValidateInput);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onValidateInput(LuaState L)
          {
                  UnityEngine.UI.InputField.OnValidateInput value_ = (UnityEngine.UI.InputField.OnValidateInput)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.onValidateInput= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_characterLimit(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  System.Int32 characterLimit= target.characterLimit;
                  LuaDLL.lua_pushnumber(L, characterLimit);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_characterLimit(LuaState L)
          {
                  System.Int32 value_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.characterLimit= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_contentType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.InputField.ContentType contentType= target.contentType;
                  ToLuaCS.push(L,contentType);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_contentType(LuaState L)
          {
                  UnityEngine.UI.InputField.ContentType value_ = (UnityEngine.UI.InputField.ContentType)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.contentType= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_lineType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.InputField.LineType lineType= target.lineType;
                  ToLuaCS.push(L,lineType);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_lineType(LuaState L)
          {
                  UnityEngine.UI.InputField.LineType value_ = (UnityEngine.UI.InputField.LineType)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.lineType= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_inputType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.InputField.InputType inputType= target.inputType;
                  ToLuaCS.push(L,inputType);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_inputType(LuaState L)
          {
                  UnityEngine.UI.InputField.InputType value_ = (UnityEngine.UI.InputField.InputType)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.inputType= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_keyboardType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.TouchScreenKeyboardType keyboardType= target.keyboardType;
                  ToLuaCS.push(L,keyboardType);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_keyboardType(LuaState L)
          {
                  UnityEngine.TouchScreenKeyboardType value_ = (UnityEngine.TouchScreenKeyboardType)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.keyboardType= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_characterValidation(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.UI.InputField.CharacterValidation characterValidation= target.characterValidation;
                  ToLuaCS.push(L,characterValidation);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_characterValidation(LuaState L)
          {
                  UnityEngine.UI.InputField.CharacterValidation value_ = (UnityEngine.UI.InputField.CharacterValidation)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.characterValidation= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_multiLine(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  System.Boolean multiLine= target.multiLine;
                  LuaDLL.lua_pushboolean(L,multiLine);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_asteriskChar(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  System.Char asteriskChar= target.asteriskChar;
                  LuaDLL.lua_pushnumber(L, asteriskChar);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_asteriskChar(LuaState L)
          {
                  System.Char value_ = (System.Char)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.asteriskChar= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_wasCanceled(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  System.Boolean wasCanceled= target.wasCanceled;
                  LuaDLL.lua_pushboolean(L,wasCanceled);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveTextEnd(LuaState L)
          {
                  System.Boolean shift_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.MoveTextEnd( shift_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveTextStart(LuaState L)
          {
                  System.Boolean shift_ =  LuaDLL.lua_toboolean(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.MoveTextStart( shift_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenToLocal(LuaState L)
          {
                  UnityEngine.Vector2 screen_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  UnityEngine.Vector2 screentolocal= target.ScreenToLocal( screen_);
                  ToLuaCS.push(L,screentolocal);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnBeginDrag(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnBeginDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnDrag(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnEndDrag(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnEndDrag( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerDown(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnPointerDown( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ProcessEvent(LuaState L)
          {
                  UnityEngine.Event e_ = (UnityEngine.Event)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.ProcessEvent( e_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnUpdateSelected(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnUpdateSelected( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Rebuild(LuaState L)
          {
                  UnityEngine.UI.CanvasUpdate update_ = (UnityEngine.UI.CanvasUpdate)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.Rebuild( update_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ActivateInputField(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.ActivateInputField();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnSelect(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnSelect( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnPointerClick(LuaState L)
          {
                  UnityEngine.EventSystems.PointerEventData eventData_ = (UnityEngine.EventSystems.PointerEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnPointerClick( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DeactivateInputField(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.DeactivateInputField();
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnDeselect(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnDeselect( eventData_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnSubmit(LuaState L)
          {
                  UnityEngine.EventSystems.BaseEventData eventData_ = (UnityEngine.EventSystems.BaseEventData)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.UI.InputField target= (UnityEngine.UI.InputField) original ;
                  target.OnSubmit( eventData_);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

