---------------------------------------------------------------------------------------------------
--===============================================================================================--
--filename: common_fun.lua
--data:2014.7.1
--author:yue an bang
--desc:公用接口类
--===============================================================================================--
---------------------------------------------------------------------------------------------------
common_fun = {}
local common_fun = common_fun
local LuaHelper=LuaHelper
local CUtils = CUtils
local getValue = getValue
local Model = Model
local Color = UnityEngine.Color
local Vector3 = UnityEngine.Vector3
local PrefabPool = luanet.PrefabPool.instance
--==================================================================================================
common_fun.loadModelCompFun = nil
common_fun.hideWord = {}
local debugTimeBegin
--==================================================================================================

----------------------------------------------------------------------------------------------------
--功能：load model成功回调
--参数：@req，data 
----------------------------------------------------------------------------------------------------
function common_fun.onModelComplete(req)
  local key = req:get_key()
  if req:get_data() then
    LuaHelper.RefreshShader(req:get_data())
    local clone = LuaHelper.Instantiate(req:get_data().assetBundle.mainAsset)
    clone.name=key
    clone.gameObject:SetActive(false)
    PrefabPool:Add(key,clone)
    disposeWWW(req:get_data())
    if common_fun.loadModelCompFun ~= nil then
      common_fun:loadModelCompFun(key)
    end
    return
  end
  print("-----[common fun] model load error:" .. key )
end 

----------------------------------------------------------------------------------------------------
--功能：添加一条load model请求
--参数：@key,model name
--     @reqs,table
--     @callbackFun,外部注册回调方法
----------------------------------------------------------------------------------------------------
function common_fun.addToList(key,reqs,callbackFun)
  if key and key~="" and  string.match(string.lower(key),"ref_%w*")==nil then
      reqs[key]={CUtils.GetAssetFullPath(key..".u3d"),common_fun.onModelComplete}
      common_fun.loadModelCompFun = callbackFun
  end
end

----------------------------------------------------------------------------------------------------
--功能：执行加载
--参数：@reqs,table
----------------------------------------------------------------------------------------------------
function common_fun.beginLoad( reqs )
  Loader:getResource(reqs,false)
end

----------------------------------------------------------------------------------------------------
--功能：log当前时间
--参数：nil
----------------------------------------------------------------------------------------------------
function common_fun.debugTimeBegin()
  debugTimeBegin =os.clock()
  print("__)()(__begin time:" .. tostring(debugTimeBegin))
end

----------------------------------------------------------------------------------------------------
--功能：配合debugTimeBegin，log当前时间的同时计算耗时，
--参数：nil
----------------------------------------------------------------------------------------------------
function common_fun.debugTime()
  local end1 = os.clock()
  local dt = end1-debugTimeBegin
  print("__)()(__time:" .. tostring(end1) .. ",dif:" .. tostring(dt))
end

----------------------------------------------------------------------------------------------------
--功能：检查字符串是否合法
--参数：@text，需要检查的字符串
--返回：bool,是否存在敏感字
--     string,转换后的字符串
----------------------------------------------------------------------------------------------------
function common_fun.checkString(text)
  if not common_fun.hideword then
    local temp = getValue("main_sensitive_word_001");
    local word = split(temp, ",");
    for i, v in pairs(word) do
      common_fun.hideWord[v] = v;
    end
  end

  local bIndex = 1;
  local cNum = 0;
  local max_Index = 15;
  local temp = {};
  local isQualified = true;
  if string.len(text) < max_Index then
    max_Index = string.len(text);
  end

--循环匹配
  while true do
    if cNum > max_Index then
      break;
    end

    --根据下标拆字
    local t = string.sub(text, bIndex, bIndex + cNum);

    --在字库里查找
    if common_fun.hideWord[t] then
      if isQualified then
        isQualified = false;
      end
      table.insert(temp, common_fun.hideWord[t]);
    end
    bIndex = bIndex + 1;
    if bIndex + cNum > string.len(text) then
      bIndex = 1;
      cNum = cNum + 1;
    end
  end

--将查找到的屏蔽字替换
  for i, v in pairs(temp) do
    text = string.gsub(text, v, "*");
  end

  return isQualified,text;

end

----------------------------------------------------------------------------------------------------
--功能：序列化一个table到string
--参数：@obj，table
--返回：string
----------------------------------------------------------------------------------------------------
function common_fun.serialize(obj)  
    local lua = ""  
    local t = type(obj)  
    if t == "number" then  
        lua = lua .. obj  
    elseif t == "boolean" then  
        lua = lua .. tostring(obj)  
    elseif t == "string" then  
        lua = lua .. string.format("%q", obj)  
    elseif t == "table" then  
        lua = lua .. "{\n"  
    for k, v in pairs(obj) do  
        lua = lua .. "[" .. common_fun.serialize(k) .. "]=" .. common_fun.serialize(v) .. ",\n"  
    end  
    local metatable = getmetatable(obj)  
        if metatable ~= nil and type(metatable.__index) == "table" then  
        for k, v in pairs(metatable.__index) do  
            lua = lua .. "[" .. common_fun.serialize(k) .. "]=" .. common_fun.serialize(v) .. ",\n"  
        end  
    end  
        lua = lua .. "}"  
    elseif t == "nil" then  
        return nil  
    else  
        error("can not serialize a " .. t .. " type.")  
    end  
    return lua  
end  
  
----------------------------------------------------------------------------------------------------
--功能：反序列化一个string 到 table
--参数：@lua，string
--返回：table
----------------------------------------------------------------------------------------------------
function common_fun.unserialize(lua)  
    local t = type(lua)  
    if t == "nil" or lua == "" then  
        return nil  
    elseif t == "number" or t == "string" or t == "boolean" then  
        lua = tostring(lua)  
    else  
        error("can not unserialize a " .. t .. " type.")  
    end  
    lua = "return " .. lua  
    local func = loadstring(lua)  
    if func == nil then  
        return nil  
    end  
    return func()  
end  

----------------------------------------------------------------------------------------------------
--功能：将秒构造成string返回
--参数：@number,秒
--     @format,格式       
--返回：时间,string
----------------------------------------------------------------------------------------------------
function common_fun.getTimeString(TimeSeconds,format)
  local min = string.format("%02.0f", math.modf(TimeSeconds / 60))
  local sec = string.format("%02.0f", TimeSeconds % 60)
  local hour = string.format("%02.0f", math.modf(TimeSeconds / 3600))
  if format == nil then
    return min .. "'" .. sec .. "''"
  else
    min = string.format("%02.0f", math.modf((TimeSeconds - hour * 3600) / 60))
    return hour .. ":" .. min .. ":" .. sec
  end
  
end

----------------------------------------------------------------------------------------------------
--功能：返回一个指定长度的数值字符串, 比如要将1显示为"01"
--参数：@num, 要显示的索引
--     @len, 保留位数    
----------------------------------------------------------------------------------------------------
function common_fun.getSpecifyStr(num, len)
  local numble = math.pow(10, len) + num
  local tempStr = tostring(numble)
  tempStr = string.sub(tempStr,2,#tempStr)
  return tempStr
end

----------------------------------------------------------------------------------------------------
--功能：设置一个obj的child 隐藏/显示， 关闭/打开obj的碰撞块
--参数：@obj, 要处理的gameObject
--     @switch, 开关  
----------------------------------------------------------------------------------------------------
function common_fun.setChildAndBoxCollider(obj, switch)
  if obj == nil then return end
  local trans = LuaHelper.GetAllChild(obj);
  for i=0, trans.Length-1 do
    trans[i].gameObject:SetActive(switch);  
  end
  local boxCollider = LuaHelper.GetComponent(obj, "BoxCollider");
  if boxCollider then boxCollider.enabled = switch end
end

----------------------------------------------------------------------------------------------------
--功能：获得加成后的英雄数据表
--参数：@netData, 服务器数据
--     @buffer, 加成表
----------------------------------------------------------------------------------------------------
function common_fun.getFinalHeroData(netData, buffer)
  local data = {};
  if buffer == nil then
    return netData.player_hero_attribute;
  end
  data.maxHp = netData.player_hero_attribute.maxHp * buffer.maxHp;
  data.defend = netData.player_hero_attribute.defend * buffer.defence;
  data.magicDefend = netData.player_hero_attribute.magicDefend * buffer.magicDefense;
  data.damage = netData.player_hero_attribute.damage * buffer.damage;
  data.magicDamage = netData.player_hero_attribute.magicDamage * buffer.magicDamage;
  data.critValue = netData.player_hero_attribute.critValue * buffer.critValue;
  data.dodgeValue = netData.player_hero_attribute.dodgeValue * buffer.dodgeValue;
  return data;
end

----------------------------------------------------------------------------------------------------
--功能：获得英雄的战力信息
--参数：@data, 英雄数据表
----------------------------------------------------------------------------------------------------
function common_fun.getFightPower(data)
  local hp = data.maxHp;
  local defence = data.defend;
  local magicDefense = data.magicDefend;
  local damage = data.damage;
  local magicDamage = data.magicDamage;
  local critValue = data.critValue;
  local dodgeValue = data.dodgeValue;
  local value = (hp/18)*(1+defence*0.015+magicDefense*0.015)+damage+magicDamage+critValue+dodgeValue;
  return math.floor(value);
end

----------------------------------------------------------------------------------------------------
--功能：获得英雄的种族信息的spriteName
--参数：@rtype, 英雄本地表的种族ID
----------------------------------------------------------------------------------------------------
function common_fun.getRaceName(rtype)
    local spriteName = "common_icon012";
    local index = rtype - 2 + 12; 
    spriteName =  "common_icon" .. common_fun.getSpecifyStr(index, 3);
    return spriteName;
end

----------------------------------------------------------------------------------------------------
--功能：获得英雄的元素信息的spriteName
--参数：@eType, 英雄本地表的元素ID
----------------------------------------------------------------------------------------------------
function common_fun.getElemName(eType)
    local spriteName = "common_icon006";
    local index = eType + 5; 
    spriteName =  "common_icon" .. common_fun.getSpecifyStr(index, 3);
    return spriteName;
end

----------------------------------------------------------------------------------------------------
--功能：更新排序功能按钮的显示
--参数：@views, table(根部是变化的UiSprite, 只有唯一的一个lable子gameObject)
---     @btnName, 需要切换的btnName名字
--- 注意： 这个函数比较特殊， 必须按照指定的格式来
----------------------------------------------------------------------------------------------------
function common_fun.setSortBtnShow(views, btnName)
    if views == nil or btnName == nil then return end
    for i, v in ipairs(views) do
        local uiSprite  = LuaHelper.GetComponent(v,"UISprite");
        local textLable = LuaHelper.GetComponentInChildren(v,"UILabel");
        if uiSprite then
            if v.name == btnName then
                uiSprite.transform.localScale = Vector3(1, 1.5, 1);
                uiSprite.spriteName = "common_img030";
                textLable.effectColor = Color(1, 0, 0);
                textLable.gameObject.transform.localScale = Vector3(1, 0.625, 1);
            else
                uiSprite.transform.localScale = Vector3(1, 1, 1);
                uiSprite.spriteName = "common_img036";
                textLable.effectColor = Color(0, 0, 0);
                textLable.gameObject.transform.localScale = Vector3(1, 1, 1);
            end
        end
    end
end

----------------------------------------------------------------------------------------------------
--功能：按钮变灰和关闭碰撞
--参数：@view (必须挂载uisprite和boxCollider)
--      @switch 为false是恢复
--- 注意： 这个函数比较特殊， 必须按照指定的格式来
----------------------------------------------------------------------------------------------------
function common_fun.setBtnEnable(view, switch)
    if view == nil then return end
    local uiSprite  = LuaHelper.GetComponent(view,"UISprite");
    local boxCollider = LuaHelper.GetComponent(view, "BoxCollider");
    if not switch then
        uiSprite.color = Color(0, 0, 0);
        if boxCollider then boxCollider.enabled = false end
    else
        uiSprite.color = Color(1, 1, 1);
        if boxCollider then boxCollider.enabled = true end
    end
end

----------------------------------------------------------------------------------------------------
--功能：获得英雄的边框spriteName
--参数：@colorLv (英雄的升阶等级，默认为1)
----------------------------------------------------------------------------------------------------
function common_fun.getHeroColor(colorLv)
    local  spriteName = "hero_rim" .. common_fun.getSpecifyStr(colorLv, 2);
    return spriteName;
end

----------------------------------------------------------------------------------------------------
--功能：英雄信息的设置
--参数：@views, table(必须都是lable, 且名字要一样)
--      @hData 必须和队伍界面保存的英雄数据一样(netdata是服务器数据， 其他附加数据),  可以为nil
--- 注意： 这个函数比较特殊， 必须按照指定的格式来
----------------------------------------------------------------------------------------------------
--- 更新显示信息面板
function common_fun.setHeroInfo(views, hData)
  local starLvTxt = 0;
  local powerTxt = 0;
  local hpTxt = 0;
  local attackTxt = 0;
  local defTxt = 0;
  local mdefTxt = 0;

  local isMagic = false;
  if hData ~= nil then
    local localData = Model.units[tostring(hData.netData.system_hero_id)];
    starLvTxt = localData.star;
    powerTxt = hData.power;
    hpTxt = math.floor(hData.netData.player_hero_attribute.maxHp);
    attackTxt = math.floor(hData.netData.player_hero_attribute.damage);
    local magicDamage = math.floor(hData.netData.player_hero_attribute.magicDamage);
    if attackTxt < magicDamage then
      attackTxt = magicDamage;
      isMagic = true;
    end
    defTxt = math.floor(hData.netData.player_hero_attribute.defend);
    mdefTxt = math.floor(hData.netData.player_hero_attribute.magicDefend);
  end
  ------------------------------ set
  ---- 星级/战力/hp/攻击/物防/魔防
  if views.starLv then views.starLv.text = starLvTxt end
  if views.power then views.power.text = powerTxt end
  if views.hp then views.hp.text = hpTxt end
  if views.attack then views.attack.text = attackTxt end
  if views.def then views.def.text = defTxt end
  if views.mdef then views.mdef.text = mdefTxt end
    
  ---- 设置sprite图标 魔法攻击 or 物理攻击
  local tran = views.attack.transform.parent;
  if tran then
      local uiSprite  = LuaHelper.GetComponent(tran.gameObject, "UISprite");
      if uiSprite == nil then return end
      if isMagic then
          uiSprite.spriteName = "common_icon009";  
      else
          uiSprite.spriteName = "common_icon002";
      end
  end
end