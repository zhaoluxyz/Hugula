using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToNGUIMath {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(NGUIMath);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "Lerp", Lerp);

           ToLuaCS.AddMember(L, "ClampIndex", ClampIndex);

           ToLuaCS.AddMember(L, "RepeatIndex", RepeatIndex);

           ToLuaCS.AddMember(L, "WrapAngle", WrapAngle);

           ToLuaCS.AddMember(L, "Wrap01", Wrap01);

           ToLuaCS.AddMember(L, "HexToDecimal", HexToDecimal);

           ToLuaCS.AddMember(L, "DecimalToHexChar", DecimalToHexChar);

           ToLuaCS.AddMember(L, "DecimalToHex24", DecimalToHex24);

           ToLuaCS.AddMember(L, "DecimalToHex32", DecimalToHex32);

           ToLuaCS.AddMember(L, "ColorToInt", ColorToInt);

           ToLuaCS.AddMember(L, "IntToColor", IntToColor);

           ToLuaCS.AddMember(L, "IntToBinary", IntToBinary);

           ToLuaCS.AddMember(L, "HexToColor", HexToColor);

           ToLuaCS.AddMember(L, "ConvertToTexCoords", ConvertToTexCoords);

           ToLuaCS.AddMember(L, "ConvertToPixels", ConvertToPixels);

           ToLuaCS.AddMember(L, "MakePixelPerfect", MakePixelPerfect);

           ToLuaCS.AddMember(L, "ConstrainRect", ConstrainRect);

           ToLuaCS.AddMember(L, "SpringDampen", SpringDampen);

           ToLuaCS.AddMember(L, "SpringLerp", SpringLerp);

           ToLuaCS.AddMember(L, "RotateTowards", RotateTowards);

           ToLuaCS.AddMember(L, "DistanceToRectangle", DistanceToRectangle);

           ToLuaCS.AddMember(L, "AdjustByDPI", AdjustByDPI);

           ToLuaCS.AddMember(L, "ScreenToPixels", ScreenToPixels);

           ToLuaCS.AddMember(L, "ScreenToParentPixels", ScreenToParentPixels);

#endregion       
}
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Lerp(LuaState L)
          {
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single factor_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  System.Single lerp= NGUIMath.Lerp( from_, to_, factor_);
                  LuaDLL.lua_pushnumber(L, lerp);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ClampIndex(LuaState L)
          {
                  System.Int32 val_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Int32 max_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  System.Int32 clampindex= NGUIMath.ClampIndex( val_, max_);
                  LuaDLL.lua_pushnumber(L, clampindex);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RepeatIndex(LuaState L)
          {
                  System.Int32 val_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Int32 max_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  System.Int32 repeatindex= NGUIMath.RepeatIndex( val_, max_);
                  LuaDLL.lua_pushnumber(L, repeatindex);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int WrapAngle(LuaState L)
          {
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  System.Single wrapangle= NGUIMath.WrapAngle( angle_);
                  LuaDLL.lua_pushnumber(L, wrapangle);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Wrap01(LuaState L)
          {
                  System.Single val_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  System.Single wrap01= NGUIMath.Wrap01( val_);
                  LuaDLL.lua_pushnumber(L, wrap01);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int HexToDecimal(LuaState L)
          {
                  System.Char ch_ = (System.Char)LuaDLL.lua_tonumber(L,1);

                  System.Int32 hextodecimal= NGUIMath.HexToDecimal( ch_);
                  LuaDLL.lua_pushnumber(L, hextodecimal);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DecimalToHexChar(LuaState L)
          {
                  System.Int32 num_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  System.Char decimaltohexchar= NGUIMath.DecimalToHexChar( num_);
                  LuaDLL.lua_pushnumber(L, decimaltohexchar);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DecimalToHex24(LuaState L)
          {
                  System.Int32 num_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  System.String decimaltohex24= NGUIMath.DecimalToHex24( num_);
                  LuaDLL.lua_pushstring(L, decimaltohex24);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DecimalToHex32(LuaState L)
          {
                  System.Int32 num_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  System.String decimaltohex32= NGUIMath.DecimalToHex32( num_);
                  LuaDLL.lua_pushstring(L, decimaltohex32);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ColorToInt(LuaState L)
          {
                  UnityEngine.Color c_ = (UnityEngine.Color)ToLuaCS.getColor(L, 1);

                  System.Int32 colortoint= NGUIMath.ColorToInt( c_);
                  LuaDLL.lua_pushnumber(L, colortoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IntToColor(LuaState L)
          {
                  System.Int32 val_ = (System.Int32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Color inttocolor= NGUIMath.IntToColor( val_);
                  ToLuaCS.push(L,inttocolor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int IntToBinary(LuaState L)
          {
                  System.Int32 val_ = (System.Int32)LuaDLL.lua_tonumber(L,1);
                  System.Int32 bits_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  System.String inttobinary= NGUIMath.IntToBinary( val_, bits_);
                  LuaDLL.lua_pushstring(L, inttobinary);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int HexToColor(LuaState L)
          {
                  System.UInt32 val_ = (System.UInt32)LuaDLL.lua_tonumber(L,1);

                  UnityEngine.Color hextocolor= NGUIMath.HexToColor( val_);
                  ToLuaCS.push(L,hextocolor);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ConvertToTexCoords(LuaState L)
          {
                  UnityEngine.Rect rect_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 1);
                  System.Int32 width_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Int32 height_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Rect converttotexcoords= NGUIMath.ConvertToTexCoords( rect_, width_, height_);
                  ToLuaCS.push(L,converttotexcoords);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ConvertToPixels(LuaState L)
          {
                  UnityEngine.Rect rect_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 1);
                  System.Int32 width_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Int32 height_ = (System.Int32)LuaDLL.lua_tonumber(L,3);
                  System.Boolean round_ =  LuaDLL.lua_toboolean(L,4);

                  UnityEngine.Rect converttopixels= NGUIMath.ConvertToPixels( rect_, width_, height_, round_);
                  ToLuaCS.push(L,converttopixels);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MakePixelPerfect(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Rect rect_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 1);
                  System.Int32 width_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Int32 height_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Rect makepixelperfect= NGUIMath.MakePixelPerfect( rect_, width_, height_);
                  ToLuaCS.push(L,makepixelperfect);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){
                  UnityEngine.Rect rect_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 1);

                  UnityEngine.Rect makepixelperfect= NGUIMath.MakePixelPerfect( rect_);
                  ToLuaCS.push(L,makepixelperfect);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ConstrainRect(LuaState L)
          {
                  UnityEngine.Vector2 minRect_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 1);
                  UnityEngine.Vector2 maxRect_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  UnityEngine.Vector2 minArea_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 3);
                  UnityEngine.Vector2 maxArea_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 4);

                  UnityEngine.Vector2 constrainrect= NGUIMath.ConstrainRect( minRect_, maxRect_, minArea_, maxArea_);
                  ToLuaCS.push(L,constrainrect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SpringDampen(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector2 && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Vector2 velocity_ = (UnityEngine.Vector2)ToLuaCS.getObject(L, 1);
                  System.Single strength_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector2 springdampen= NGUIMath.SpringDampen( ref velocity_, strength_, deltaTime_);
                  ToLuaCS.push(L,springdampen);
                  ToLuaCS.push(L,velocity_);
                  return 2;

               }
               if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3 && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Vector3 velocity_ = (UnityEngine.Vector3)ToLuaCS.getObject(L, 1);
                  System.Single strength_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 springdampen= NGUIMath.SpringDampen( ref velocity_, strength_, deltaTime_);
                  ToLuaCS.push(L,springdampen);
                  ToLuaCS.push(L,velocity_);
                  return 2;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SpringLerp(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,4)){
               if( LuaDLL.lua_type(L,1)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 1, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Single strength_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Vector3 springlerp= NGUIMath.SpringLerp( from_, to_, strength_, deltaTime_);
                  ToLuaCS.push(L,springlerp);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 1, typeof(UnityEngine.Quaternion)) && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Quaternion)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Quaternion from_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 1);
                  UnityEngine.Quaternion to_ = (UnityEngine.Quaternion)ToLuaCS.getQuaternion(L, 2);
                  System.Single strength_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Quaternion springlerp= NGUIMath.SpringLerp( from_, to_, strength_, deltaTime_);
                  ToLuaCS.push(L,springlerp);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 1, typeof(UnityEngine.Vector2)) && LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector2)) && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER ){
                  UnityEngine.Vector2 from_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 1);
                  UnityEngine.Vector2 to_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  System.Single strength_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Vector2 springlerp= NGUIMath.SpringLerp( from_, to_, strength_, deltaTime_);
                  ToLuaCS.push(L,springlerp);
                  return 1;

               }
               if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER ){
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single strength_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  System.Single springlerp= NGUIMath.SpringLerp( from_, to_, strength_, deltaTime_);
                  LuaDLL.lua_pushnumber(L, springlerp);
                  return 1;

               }
                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.Single strength_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single springlerp= NGUIMath.SpringLerp( strength_, deltaTime_);
                  LuaDLL.lua_pushnumber(L, springlerp);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateTowards(LuaState L)
          {
                  System.Single from_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single to_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single maxAngle_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  System.Single rotatetowards= NGUIMath.RotateTowards( from_, to_, maxAngle_);
                  LuaDLL.lua_pushnumber(L, rotatetowards);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DistanceToRectangle(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Vector3[] worldPoints_ = (UnityEngine.Vector3[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 mousePos_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);
                  UnityEngine.Camera cam_ = (UnityEngine.Camera)ToLuaCS.getObject(L, 3);

                  System.Single distancetorectangle= NGUIMath.DistanceToRectangle( worldPoints_, mousePos_, cam_);
                  LuaDLL.lua_pushnumber(L, distancetorectangle);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Vector2[] screenPoints_ = (UnityEngine.Vector2[])ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 mousePos_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                  System.Single distancetorectangle= NGUIMath.DistanceToRectangle( screenPoints_, mousePos_);
                  LuaDLL.lua_pushnumber(L, distancetorectangle);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AdjustByDPI(LuaState L)
          {
                  System.Single height_ = (System.Single)LuaDLL.lua_tonumber(L,1);

                  System.Int32 adjustbydpi= NGUIMath.AdjustByDPI( height_);
                  LuaDLL.lua_pushnumber(L, adjustbydpi);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenToPixels(LuaState L)
          {
                  UnityEngine.Vector2 pos_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 1);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                  UnityEngine.Vector2 screentopixels= NGUIMath.ScreenToPixels( pos_, relativeTo_);
                  ToLuaCS.push(L,screentopixels);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ScreenToParentPixels(LuaState L)
          {
                  UnityEngine.Vector2 pos_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 1);
                  UnityEngine.Transform relativeTo_ = (UnityEngine.Transform)ToLuaCS.getObject(L, 2);

                  UnityEngine.Vector2 screentoparentpixels= NGUIMath.ScreenToParentPixels( pos_, relativeTo_);
                  ToLuaCS.push(L,screentoparentpixels);
                  return 1;

          }
  #endregion       
}

