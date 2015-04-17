// Copyright (c) 2014 hugula
// direct https://github.com/Hugulor/Hugula
//
using UnityEngine;
using System.Collections;
#if Nlua
using NLua;
using Lua = NLua.Lua;
#else
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
#endif

    public class ToLuaCS
    {

        #region
        /// <summary>
        /// Global table name 存放 static方法
        /// </summary>
        public const string GlobalTableName = "toluacs";

        /// <summary>
        ///  静态方法获取值
        /// </summary>
        public const string StaticIndex = @"
local function index(obj,name)
        local getstr=""get_""..name
        local fn=rawget(obj,getstr)
        if type(fn)==""function"" then
            return fn()
        else
            return fn
        end     
 end
    return index
";

        /// <summary>
        /// 静态方法设置值
        /// </summary>
        public static string StaticNewIndex = @"
local function newindex(obj,name,value)
        local setstr=""set_""..name
        local fn=rawget(obj,setstr)
        if type(fn)==""function"" then
            return fn(value)
        end         
 end
    return newindex
";

        /// <summary>
        /// 实例方法获取值
        /// </summary>
        public const string InstanceIndex = @"
local function index(obj,name,meta1)
        local meta=getmetatable(meta1 or obj)
        if meta==nil then return nil end
        local fn=rawget(meta,name)
        if  fn~=nil then
            return fn
        elseif fn==nil then
            local getstr=""get_""..name
            fn= rawget(meta,getstr)
            if type(fn)==""function"" then
                return fn(obj)
            else
                return index(obj,name,meta)
            end
        end
 end
    return index
";

        /// <summary>
        /// 实例方法设置值
        /// </summary>
        public const string InstanceNewIndex = @"
local function newindex(obj,name,value,meta1)
        local meta=getmetatable(meta1 or obj)
        if meta==nil then return end
        local fn=rawget(meta,name)
        if  type(fn)==""function"" then
            fn(obj,value)
        elseif fn==nil then
          local setstr=""set_""..name
            fn=rawget(meta,setstr)
            if  type(fn)==""function"" then
                fn(obj,value)
            else
                newindex(obj,name,value,meta)
            end   
        end
 end
    return newindex
";

        #endregion

        public static Lua lua
        {
            get { return _lua; }
            set
            {
                _lua = value;
                translator = _lua.translator;
                metaFunctions = translator.metaFunctions;
            }
        }

        private static Lua _lua;
        private static ObjectTranslator translator;
        public static MetaFunctions metaFunctions;

        #region value type change

        public static LuaFunction unpackVec3 = null;
        public static LuaFunction unpackVec2 = null;
        public static LuaFunction unpackVec4 = null;
        public static LuaFunction unpackQuat = null;
        public static LuaFunction unpackColor = null;
        public static LuaFunction unpackRay = null;

        public static LuaFunction packVec3 = null;
        public static LuaFunction packVec2 = null;
        public static LuaFunction packVec4 = null;
        public static LuaFunction packQuat = null;
        public static LuaFunction packTouch = null;
        public static LuaFunction packRay = null;
        public static LuaFunction packRaycastHit = null;
        public static LuaFunction packColor = null;


        public static string[] ValueTypes = new string[] { "UnityEngine.Vector3", "UnityEngine.Vector2", "UnityEngine.Vector4", 
            "UnityEngine.Quaternion","UnityEngine.Color","UnityEngine.Ray" };

        public static void InitValueTypeChange()
        {
            unpackVec3 = GetLuaFunction("Vector3.Get");
            unpackVec2 = GetLuaFunction("Vector2.Get");
            unpackVec4 = GetLuaFunction("Vector4.Get");
            unpackQuat = GetLuaFunction("Quaternion.Get");
            unpackColor = GetLuaFunction("Color.Get");
            unpackRay = GetLuaFunction("Ray.Get");

            packVec3 = GetLuaFunction("Vector3.New");
            packVec2 = GetLuaFunction("Vector2.New");
            packVec4 = GetLuaFunction("Vector4.New");
            packQuat = GetLuaFunction("Quaternion.New");
            packRaycastHit = GetLuaFunction("Raycast.New");
            packColor = GetLuaFunction("Color.New");
            packRay = GetLuaFunction("Ray.New");
            packTouch = GetLuaFunction("Touch.New");

            //Debug.Log(string.Format("InitValueTypeChange packVec3 ={0} ,unpackVec3={1}", packVec3, unpackVec3));
        }

        #endregion

        #region getObject<T>
        /// <summary>
        /// 获取指定索引位置的值
        /// </summary>
        /// <param name="L"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static object getObject(LuaState L, int i)
        {
            return translator.getObject(L, i);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="stackPos"></param>
        /// <returns></returns>
        public static Vector3 getVector3(LuaState L, int stackPos)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            unpackVec3.push(L);

            LuaDLL.lua_pushvalue(L, stackPos);
            float x = 0, y = 0, z = 0;

            if (LuaDLL.lua_pcall(L, 1, -1,0) == 0)
            {
                x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
                y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
                z = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
            }
            else
            {
                ThrowLuaException(L);
            }

            LuaDLL.lua_settop(L, oldTop);
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="stackPos"></param>
        /// <returns></returns>
        public static Quaternion getQuaternion(LuaState L, int stackPos)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            unpackQuat.push(L);

            LuaDLL.lua_pushvalue(L, stackPos);
            float x = 0, y = 0, z = 0, w = 1;

            if (LuaDLL.lua_pcall(L, 1, -1,0) == 0)
            {
                x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
                y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
                z = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
                w = (float)LuaDLL.lua_tonumber(L, oldTop + 4);
            }
            else
            {
                ThrowLuaException(L);
            }

            LuaDLL.lua_settop(L, oldTop);
            return new Quaternion(x, y, z, w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="stackPos"></param>
        /// <returns></returns>
        public static Vector2 getVector2(LuaState L, int stackPos)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            unpackVec2.push(L);

            LuaDLL.lua_pushvalue(L, stackPos);
            float x = 0, y = 0;

            if (LuaDLL.lua_pcall(L, 1, -1,0) == 0)
            {
                x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
                y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
            }
            else
            {
                ThrowLuaException(L);
            }

            LuaDLL.lua_settop(L, oldTop);
            return new Vector2(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="stackPos"></param>
        /// <returns></returns>
        public static Vector4 getVector4(LuaState L, int stackPos)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            unpackVec4.push(L);

            LuaDLL.lua_pushvalue(L, stackPos);
            float x = 0, y = 0, z = 0, w = 0;

            if (LuaDLL.lua_pcall(L, 1, -1,0) == 0)
            {
                x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
                y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
                z = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
                w = (float)LuaDLL.lua_tonumber(L, oldTop + 4);
            }
            else
            {
                ThrowLuaException(L);
            }

            LuaDLL.lua_settop(L, oldTop);
            return new Vector4(x, y, z, w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="stackPos"></param>
        /// <returns></returns>
        public static Ray getRay(LuaState L, int stackPos)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            unpackRay.push(L);

            LuaDLL.lua_pushvalue(L, stackPos);
            float x = 0, y = 0, z = 0;
            Vector3 dir = new Vector3();
            Vector3 origin = new Vector3();

            if (LuaDLL.lua_pcall(L, 1, -1,0) == 0)
            {
                x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
                y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
                z = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
                origin.Set(x, y, z);
                x = (float)LuaDLL.lua_tonumber(L, oldTop + 4);
                y = (float)LuaDLL.lua_tonumber(L, oldTop + 5);
                z = (float)LuaDLL.lua_tonumber(L, oldTop + 6);
                dir.Set(x, y, z);
            }
            else
            {
                ThrowLuaException(L);
            }

            LuaDLL.lua_settop(L, oldTop);
            return new Ray(origin, dir);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="stackPos"></param>
        /// <returns></returns>
        public static Color getColor(LuaState L, int stackPos)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            unpackColor.push(L);

            LuaDLL.lua_pushvalue(L, stackPos);
            float r = 0, g = 0, b = 0, a = 0;

            if (LuaDLL.lua_pcall(L, 1, -1,0) == 0)
            {
                r = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
                g = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
                b = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
                a = (float)LuaDLL.lua_tonumber(L, oldTop + 4);
            }
            else
            {
                ThrowLuaException(L);
            }

            LuaDLL.lua_settop(L, oldTop);
            return new Color(r, g, b, a);
        }
        #endregion

        #region push value
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="L"></param>
        /// <param name="v"></param>
        public static void push(LuaState L, object v)
        {
            translator.push(L, v);
        }

        public static void push(LuaState L, float v)
        {
            LuaDLL.lua_pushnumber(L, v);
        }

        public static void push(LuaState L, double v)
        {
            LuaDLL.lua_pushnumber(L, v);
        }

        public static void push(LuaState L, int v)
        {
            LuaDLL.lua_pushnumber(L, v);
        }

        //public static void push(LuaState L, bool v)
        //{
        //    LuaDLL.lua_pushboolean(L, v);
        //}

        public static void push(LuaState L, string v)
        {
            LuaDLL.lua_pushstring(L, v);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="v3"></param>
        public static void push(LuaState L, Vector3 v3)
        {
            packVec3.push(L);
            LuaDLL.lua_pushnumber(L, v3.x);
            LuaDLL.lua_pushnumber(L, v3.y);
            LuaDLL.lua_pushnumber(L, v3.z);

            if (LuaDLL.lua_pcall(L, 3, -1,0) != 0)
            {
                ThrowLuaException(L);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="q"></param>
        public static void push(LuaState L, Quaternion q)
        {
            packQuat.push(L);
            LuaDLL.lua_pushnumber(L, q.x);
            LuaDLL.lua_pushnumber(L, q.y);
            LuaDLL.lua_pushnumber(L, q.z);
            LuaDLL.lua_pushnumber(L, q.w);

            if (LuaDLL.lua_pcall(L, 4, -1, 0) != 0)
            {
                ThrowLuaException(L);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="v2"></param>
        public static void push(LuaState L, Vector2 v2)
        {
            packVec2.push(L);
            LuaDLL.lua_pushnumber(L, v2.x);
            LuaDLL.lua_pushnumber(L, v2.y);

            if (LuaDLL.lua_pcall(L, 2, -1,0) != 0)
            {
                ThrowLuaException(L);
            }
        }

        public static void push(LuaState L, Vector4 v4)
        {
            packVec4.push(L);
            LuaDLL.lua_pushnumber(L, v4.x);
            LuaDLL.lua_pushnumber(L, v4.y);
            LuaDLL.lua_pushnumber(L, v4.z);
            LuaDLL.lua_pushnumber(L, v4.w);

            if (LuaDLL.lua_pcall(L, 4, -1,0) != 0)
            {
                ThrowLuaException(L);
            }
        }

        public static void push(LuaState L, RaycastHit hit)
        {
            packRaycastHit.push(L);

            push(L, hit.collider);
            push(L, hit.distance);
            push(L, hit.normal);
            push(L, hit.point);
            push(L, hit.rigidbody);
            push(L, hit.transform);

            if (LuaDLL.lua_pcall(L, 6, -1,0) != 0)
            {
                ThrowLuaException(L);
            }
        }

        public static void push(LuaState L, Ray ray)
        {
            packRay.push(L);

            push(L, ray.direction);
            push(L, ray.origin);

            if (LuaDLL.lua_pcall(L, 2, -1,0) != 0)
            {
                ThrowLuaException(L);
            }
        }

        public static void push(LuaState L, Color clr)
        {
            packColor.push(L);
            push(L, clr.r);
            push(L, clr.g);
            push(L, clr.b);
            push(L, clr.a);

            if (LuaDLL.lua_pcall(L, 4, -1,0) != 0)
            {
                ThrowLuaException(L);
            }
        }

        public static void push(LuaState L, Touch touch)
        {
            packTouch.push(L);

            push(L, touch.fingerId);
            push(L, touch.position);
            push(L, touch.rawPosition);
            push(L, touch.deltaPosition);
            push(L, touch.deltaTime);
            push(L, touch.tapCount);
            push(L, touch.phase);

            if (LuaDLL.lua_pcall(L, 7, -1,0) != 0)
            {
                ThrowLuaException(L);
            }
        }
        #endregion

        #region luaheper

        public static LuaFunction GetLuaFunction(string name)
        {
            LuaBase func = null;

            LuaState L = lua.L;
            int oldTop = LuaDLL.lua_gettop(L);

            if (PushLuaFunction(L, name))
            {
                int reference = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
                func = new LuaFunction(reference, lua);
            }

            LuaDLL.lua_settop(L, oldTop);

            return func as LuaFunction;
        }

        static bool PushLuaTable(LuaState L, string fullPath)
        {
            string[] path = fullPath.Split(new char[] { '.' });
            int oldTop = LuaDLL.lua_gettop(L);
            LuaDLL.lua_getglobal(L, path[0]);

            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type != LuaTypes.LUA_TTABLE)
            {
                LuaDLL.lua_settop(L, oldTop);
                //Debug.LogError("Push lua table {0} failed", path[0]);
                return false;
            }

            for (int i = 1; i < path.Length; i++)
            {
                LuaDLL.lua_pushstring(L, path[i]);
                LuaDLL.lua_rawget(L, -2);
                type = LuaDLL.lua_type(L, -1);

                if (type != LuaTypes.LUA_TTABLE)
                {
                    LuaDLL.lua_settop(L, oldTop);
                    //Debug.LogError("Push lua table {0} failed", fullPath);
                    return false;
                }
            }

            if (path.Length > 1)
            {
                LuaDLL.lua_insert(L, oldTop + 1);
                LuaDLL.lua_settop(L, oldTop + 1);
            }

            return true;
        }

        static bool PushLuaFunction(LuaState L, string fullPath)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            int pos = fullPath.LastIndexOf('.');

            if (pos > 0)
            {
                string tableName = fullPath.Substring(0, pos);

                if (PushLuaTable(L, tableName))
                {
                    string funcName = fullPath.Substring(pos + 1);
                    LuaDLL.lua_pushstring(L, funcName);
                    LuaDLL.lua_rawget(L, -2);
                }

                LuaTypes type = LuaDLL.lua_type(L, -1);

                if (type != LuaTypes.LUA_TFUNCTION)
                {
                    LuaDLL.lua_settop(L, oldTop);
                    return false;
                }

                LuaDLL.lua_insert(L, oldTop + 1);
                LuaDLL.lua_settop(L, oldTop + 1);
            }
            else
            {
                LuaDLL.lua_getglobal(L, fullPath);
                LuaTypes type = LuaDLL.lua_type(L, -1);

                if (type != LuaTypes.LUA_TFUNCTION)
                {
                    LuaDLL.lua_settop(L, oldTop);
                    return false;
                }
            }

            return true;
        }

        public LuaTable GetLuaTable(string tableName)
        {
            LuaBase lt = null;
            LuaState L = lua.L;
            int oldTop = LuaDLL.lua_gettop(L);

            if (PushLuaTable(L, tableName))
            {
                int reference = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
                lt = new LuaTable(reference, lua);
            }

            LuaDLL.lua_settop(L, oldTop);
            return lt as LuaTable;
        }

        public static void ThrowLuaException(LuaState L)
        {
            string err = LuaDLL.lua_tostring(L, -1);
            if (err == null) err = "Unknown Lua Error";
            throw new LuaScriptException(err.ToString(), "");
        }
        #endregion
    }
