using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Rect {

  public static void CreateMetaTableToLua(LuaState L) {

       System.Type t= typeof(UnityEngine.Rect);
       if(!ToLuaCS.CreateMetatable(L,t)){
          return;
      }
      #region  注册实例luameta
           ToLuaCS.AddMember(L, "Set", Set);
           ToLuaCS.AddMember(L, "get_x", get_x);
           ToLuaCS.AddMember(L, "set_x", set_x);
           ToLuaCS.AddMember(L, "get_y", get_y);
           ToLuaCS.AddMember(L, "set_y", set_y);
           ToLuaCS.AddMember(L, "get_position", get_position);
           ToLuaCS.AddMember(L, "set_position", set_position);
           ToLuaCS.AddMember(L, "get_center", get_center);
           ToLuaCS.AddMember(L, "set_center", set_center);
           ToLuaCS.AddMember(L, "get_min", get_min);
           ToLuaCS.AddMember(L, "set_min", set_min);
           ToLuaCS.AddMember(L, "get_max", get_max);
           ToLuaCS.AddMember(L, "set_max", set_max);
           ToLuaCS.AddMember(L, "get_width", get_width);
           ToLuaCS.AddMember(L, "set_width", set_width);
           ToLuaCS.AddMember(L, "get_height", get_height);
           ToLuaCS.AddMember(L, "set_height", set_height);
           ToLuaCS.AddMember(L, "get_size", get_size);
           ToLuaCS.AddMember(L, "set_size", set_size);
           ToLuaCS.AddMember(L, "get_xMin", get_xMin);
           ToLuaCS.AddMember(L, "set_xMin", set_xMin);
           ToLuaCS.AddMember(L, "get_yMin", get_yMin);
           ToLuaCS.AddMember(L, "set_yMin", set_yMin);
           ToLuaCS.AddMember(L, "get_xMax", get_xMax);
           ToLuaCS.AddMember(L, "set_xMax", set_xMax);
           ToLuaCS.AddMember(L, "get_yMax", get_yMax);
           ToLuaCS.AddMember(L, "set_yMax", set_yMax);
           ToLuaCS.AddMember(L, "ToString", ToString);
           ToLuaCS.AddMember(L, "Contains", Contains);
           ToLuaCS.AddMember(L, "Overlaps", Overlaps);
           ToLuaCS.AddMember(L, "GetHashCode", GetHashCode);
           ToLuaCS.AddMember(L, "Equals", Equals);
           ToLuaCS.AddMember(L, "GetType", GetType);
      #endregion

  #region  static method       
          ToLuaCS.CreateToLuaCSTable(L, t);
           ToLuaCS.AddMember(L, "MinMaxRect", MinMaxRect);

           ToLuaCS.AddMember(L, "NormalizedToPoint", NormalizedToPoint);

           ToLuaCS.AddMember(L, "PointToNormalized", PointToNormalized);

           ToLuaCS.AddMember(L, "__call", _rect);

#endregion       
}
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Set(LuaState L)
          {
                  System.Single left_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single top_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single width_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single height_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.Set( left_, top_, width_, height_);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_x(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Single x= target.x;
                  LuaDLL.lua_pushnumber(L, x);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_x(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.x= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_y(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Single y= target.y;
                  LuaDLL.lua_pushnumber(L, y);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_y(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.y= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_position(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  UnityEngine.Vector2 position= target.position;
                  ToLuaCS.push(L,position);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_position(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.position= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_center(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  UnityEngine.Vector2 center= target.center;
                  ToLuaCS.push(L,center);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_center(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.center= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_min(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  UnityEngine.Vector2 min= target.min;
                  ToLuaCS.push(L,min);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_min(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.min= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_max(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  UnityEngine.Vector2 max= target.max;
                  ToLuaCS.push(L,max);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_max(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.max= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_width(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Single width= target.width;
                  LuaDLL.lua_pushnumber(L, width);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_width(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.width= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_height(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Single height= target.height;
                  LuaDLL.lua_pushnumber(L, height);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_height(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.height= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_size(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  UnityEngine.Vector2 size= target.size;
                  ToLuaCS.push(L,size);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_size(LuaState L)
          {
                  UnityEngine.Vector2 value_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.size= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_xMin(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Single xMin= target.xMin;
                  LuaDLL.lua_pushnumber(L, xMin);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_xMin(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.xMin= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_yMin(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Single yMin= target.yMin;
                  LuaDLL.lua_pushnumber(L, yMin);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_yMin(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.yMin= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_xMax(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Single xMax= target.xMax;
                  LuaDLL.lua_pushnumber(L, xMax);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_xMax(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.xMax= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_yMax(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Single yMax= target.yMax;
                  LuaDLL.lua_pushnumber(L, yMax);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_yMax(LuaState L)
          {
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  target.yMax= value_;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,2)){
                  System.String format_ =  LuaDLL.lua_tostring(L,2); 


                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.String tostring= target.ToString( format_);
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,1)){

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.String tostring= target.ToString();
                  LuaDLL.lua_pushstring(L, tostring);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Contains(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Vector3 point_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);
                  System.Boolean allowInverse_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Boolean contains= target.Contains( point_, allowInverse_);
                  LuaDLL.lua_pushboolean(L,contains);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector3))){
                  UnityEngine.Vector3 point_ = (UnityEngine.Vector3)ToLuaCS.getVector3(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Boolean contains= target.Contains( point_);
                  LuaDLL.lua_pushboolean(L,contains);
                  return 1;

               }
               if( LuaDLL.lua_type(L,2)== LuaTypes.LUA_TTABLE &&  ToLuaCS.CheckTableType(L, 2, typeof(UnityEngine.Vector2))){
                  UnityEngine.Vector2 point_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Boolean contains= target.Contains( point_);
                  LuaDLL.lua_pushboolean(L,contains);
                  return 1;

               }
                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Overlaps(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,3)){
                  UnityEngine.Rect other_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 2);
                  System.Boolean allowInverse_ =  LuaDLL.lua_toboolean(L,3);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Boolean overlaps= target.Overlaps( other_, allowInverse_);
                  LuaDLL.lua_pushboolean(L,overlaps);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Rect other_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Boolean overlaps= target.Overlaps( other_);
                  LuaDLL.lua_pushboolean(L,overlaps);
                  return 1;

                 }
               return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  LuaDLL.lua_pushnumber(L, gethashcode);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object other_ = (System.Object)ToLuaCS.getObject(L, 2);

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Boolean equals= target.Equals( other_);
                  LuaDLL.lua_pushboolean(L,equals);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                   var original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Rect target= (UnityEngine.Rect) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype);
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MinMaxRect(LuaState L)
          {
                  System.Single left_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single top_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single right_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single bottom_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Rect minmaxrect= UnityEngine.Rect.MinMaxRect( left_, top_, right_, bottom_);
                  ToLuaCS.push(L,minmaxrect);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int NormalizedToPoint(LuaState L)
          {
                  UnityEngine.Rect rectangle_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 normalizedRectCoordinates_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                  UnityEngine.Vector2 normalizedtopoint= UnityEngine.Rect.NormalizedToPoint( rectangle_, normalizedRectCoordinates_);
                  ToLuaCS.push(L,normalizedtopoint);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int PointToNormalized(LuaState L)
          {
                  UnityEngine.Rect rectangle_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector2 point_ = (UnityEngine.Vector2)ToLuaCS.getVector2(L, 2);

                  UnityEngine.Vector2 pointtonormalized= UnityEngine.Rect.PointToNormalized( rectangle_, point_);
                  ToLuaCS.push(L,pointtonormalized);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int _rect(LuaState L)
          {
                  int argLength = LuaDLL.lua_gettop(L);
               if(ToLuaCS.CheckArgLength(argLength,5)){
                  System.Single left_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single top_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single width_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single height_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  UnityEngine.Rect _rect= new UnityEngine.Rect( left_, top_, width_, height_);
                  ToLuaCS.push(L,_rect);
                  return 1;

                 }
               else if(ToLuaCS.CheckArgLength(argLength,2)){
                  UnityEngine.Rect source_ = (UnityEngine.Rect)ToLuaCS.getObject(L, 2);

                  UnityEngine.Rect _rect= new UnityEngine.Rect( source_);
                  ToLuaCS.push(L,_rect);
                  return 1;

                 }
               return 0;
          }
  #endregion       
}

