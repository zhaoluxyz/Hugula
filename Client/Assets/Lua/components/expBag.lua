local LuaHelper=LuaHelper
local CUtils=CUtils
local delay = delay
local Timer = luanet.Timer
local fun = fun
local showTips = showTips
local localPack = LuaItemManager:getItemObject("packPanel")
local ExpBag =class(function(self,luaObj)
	self.items={}
	self.luaObj=luaObj
	self.assets = nil
	self.enable = true
end)

--- 面板激活的判断
ExpBag.isActive = false;
--- 默认的起始显示, 最多5个， 默认值从排序数组的第一个开始显示
ExpBag.curShowId = 1;
--- 道具界面隐藏切换时候的回调函数
ExpBag.onHideEndFn = nil;
--- 记录当前view的外来data
ExpBag.views = nil;
--- 记录当前的英雄ID, 当切换的时候需要更新
ExpBag.heroId = 0;

----------sort---------------
local function sortGoodId(a,b)  
	if a~=nil and b~=nil and a.goods_id and b.goods_id then  
		return tonumber(a.goods_id)<tonumber(b.goods_id) 
	else
		return false
	end
end

--- 发送使用道具消息 22101
local function SendUse_goods(goods_id, goods_num, player_hero_id)
	local cont = NetMsgHelper:makesend_hero_goods_use(goods_id,goods_num,player_hero_id);
	Proxy:send(NetAPIList.hero_goods_use,cont);
end
-----------------------------

function ExpBag:defaultInit(views,  callback)
    self.curShowId = 1;
    self.onHideEndFn = callback;
    self.views = views;
    ---- 获得默认的本地数据[只读]
    self.localData = {};
    for i, v in pairs(Model.itemData) do
        if v.type == 6 then
            local vdata = {};
			vdata.data = v;
            vdata.goods_id = v.id;
			table.insert(self.localData, vdata);
        end
    end
    table.sort(self.localData, sortGoodId);
end

--- 设置当前的默认显示
function ExpBag:setDefaultShow()
   --- 边界检查
   local localLen = #self.localData;
   if self.curShowId > localLen - 4 then
    self.curShowId = 1;
   elseif self.curShowId < 1 then
    self.curShowId = 1;
   end
   --- 基本显示设置
   for i = 1, 5 do
      local view = self.views.prop[i];
      local vdata = self.localData[self.curShowId + i - 1];
      view.icon.spriteName = vdata.data.icon;
      view.num.text = 0;
      view.info.text = getValue(vdata.data.Desc2);
   end
end

--- 更新获取的服务器经验道具信息, 刷新数量使用
function ExpBag:handleProp()
	self.curData = {};
	if localPack.models == nil then return end
	for i, v in pairs(localPack.models) do
		local localData = Model.itemData[tostring(v.netData.goods_id)];
		if localData.type == 6 then
			self.curData[tostring(v.netData.goods_id)] = v.netData;
		end
	end

    self:updateShow();
end

--- 发送使用道具的消息， 基准值为当前道具本地索引
function ExpBag:sendPropUse(goods_id, player_hero_id)
    print(player_hero_id);
    print(goods_id);
	SendUse_goods(goods_id, 1, player_hero_id);
end

-------------------- show/hide
function ExpBag:show()
	if self.views then
		self.views.root:SetActive(true);
        self.isActive = true;
	end
end

function ExpBag:hide()
	if self.views then
		self.views.root:SetActive(false);
        self.isActive = false;
		if self.onHideEndFn then self.onHideEndFn() end
	end
end

--- 根据当前的排序数据更新显示
function ExpBag:updateShow()
	if self.views == nil then return end
    --- 恢复默认的view 显示
    self:setDefaultShow();
    --- 从当前有效的服务器数据中更新道具数量显示
    for i = 1, 5 do
      local view = self.views.prop[i];
      local vdata = self.localData[self.curShowId + i - 1];
      local strIndex = tostring(vdata.goods_id);
      if self.curData[strIndex] then
        view.num.text = self.curData[strIndex].goods_num;
      end
    end
end

--- 道具界面的按键管理
function ExpBag:OnClick(obj,arg)
	local tran = obj.transform.parent;
    local cmd = string.sub(obj.name, 1, 8);

    if cmd == "InfoIcon" and tran and tran.name == "prop" then
        local selId = tonumber(string.sub(obj.name, 9));
        local vId = self.curShowId + selId - 1;
        if vId > #self.localData then return end
        local vdata = self.localData[vId];
        local curNum = tonumber(self.views.prop[selId].num.text);
        if curNum > 0 then 
            self:sendPropUse(vdata.goods_id, self.heroId);
        else
            showTips("你还没有拥有当前道具");
        end
    elseif obj.name == "leftArrow" and tran and tran.name == "expInfo" then
        --- 左移
        local localLen = #self.localData;
        self.curShowId = (self.curShowId - 1 + localLen)%localLen;
        self:updateShow();
    elseif obj.name == "rightArrow" and tran and tran.name == "expInfo" then
        --- 右移
        local localLen = #self.localData;
        self.curShowId = (self.curShowId + 1)%localLen;
        self:updateShow();
    end
end

return ExpBag;