local packPanel = LuaItemManager:getItemObject("packPanel")
local StateManager = StateManager
local delay = delay
local LuaHelper=LuaHelper
local Loader = Loader
local CUtils = CUtils
local json=json
local Request = Request
local Vector3 = UnityEngine.Vector3
local Encodeing = luanet.import_type("System.Text.Encoding")
local Quaternion = UnityEngine.Quaternion
local Net=Net.instance
local LFunction = LFunction.instance
local Proxy=Proxy
local Model = Model
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
packPanel.assets=
{
   Asset("packageUI.u3d", {"Config"}),
}
-- 检查界面是否打开
packPanel.isShow = false;
-- panel
packPanel.main = {};
packPanel.mainBtn = 
{
	curName = "",
	views = {},
}
-- block prefab
packPanel.copyBlock = nil;
packPanel.blocks = {};
--- right Panel
packPanel.rightPan = {};
--- sell Panel
packPanel.sellPan = {};
--- detail Pan
packPanel.detailPan = {};
--- compose pan
packPanel.composePan = {};
--==================================================================================================
--- 顶部按钮的精灵名
local btnSpriteNames = 
{
	"pack_tab1",
	"pack_tab2",	
};
--==================================================================================================

------------------private-----------------

--- 返回一个指定长度的数值字符串, 比如1,显示为"01"
--- 字符串第一个元素的索引为1,sub返回两个字符之间的值
local function GetSpecifyStr(num, len)
  local numble = math.pow(10, len) + num;
  local tempStr = tostring(numble);
  tempStr = string.sub(tempStr,2,#tempStr);
  return tempStr;
end

----------sort---------------
local function sortColor(a,b)  
	if a~=nil and b~=nil and a.color and b.color then  
		return tonumber(a.color)>tonumber(b.color) 
	else
		return false
	end
end

local function sortIndex(a,b)  
	if a~=nil and b~=nil and a.index and b.index then  
		return tonumber(a.index)<tonumber(b.index) 
	else
		return false
	end
end
----------sort end-----------

--- 获得有序的新表
local function GetNewPackTable(tableData)
	local newTable = {};
	if tableData == nil then return newTable; end
	for i, v in pairs(tableData) do
		table.insert(newTable, v);
	end
	return newTable;
end

--- 返回需要显示的商品类型， 0是全部， 其他根据配置所得
local function GetShowGoodType(btnName)
	local iType = 0;
	if btnName == "BtnTopProp" then iType = 4;
	elseif btnName == "BtnTopEquip" then iType = 1;
	elseif btnName == "BtnTopScoll" then iType = 3;
	elseif btnName == "BtnTopChip" then iType = 2 end
	return iType;
end

--- 根据当前显示商品数量, 获得需要额外添加的板子块数
local function GetNeedAddBlock(curLen)
  if curLen < 20 then return 20-curLen end
  local newAdd = curLen - 20;
  while newAdd > 4 do
    newAdd = newAdd - 4;
  end
  if newAdd == 0 then return 0;
  else return 4 - newAdd end
end

---- 设置一个obj的child 隐藏/显示， 关闭/打开obj的碰撞块
local function SetChildAndBoxCollider(obj, switch)
  if obj == nil then return end
  local trans = LuaHelper.GetAllChild(obj);
  for i=0, trans.Length-1 do
    trans[i].gameObject:SetActive(switch);  
  end
  local boxCollider = LuaHelper.GetComponent(obj, "BoxCollider");
  if boxCollider then boxCollider.enabled = switch end
end


--- 获得实际上需要的数量, 传入需要检查的值， 标准值， 变化值
local function GetNewCountInfact(check, normal, add)
  --- 不够标准数量补足标准数量
  if check < normal then return normal end
  --- 按当前需要添加
  local checkEnd = check - normal;
  while checkEnd > add do
    checkEnd = checkEnd - add;
  end
  local reValue = check;
  if checkEnd > 0 then
    reValue = reValue + add - checkEnd;
  end
  return reValue;
end

--- 发送售卖信息 2221
local function SendGoods_sell(goods_id, goods_num)
	local cont = NetMsgHelper:makesend_player_goods_sell(goods_id, goods_num);
    Proxy:send(NetAPIList.goods_sell,cont);
end
--- 发送使用道具消息 2217
local function SendUse_goods(goods_id,goods_num)
	local cont = NetMsgHelper:makept_use_goods(goods_id,goods_num);
	Proxy:send(NetAPIList.use_goods_api,cont);
end

-----------------------------------------------------

------------------public------------------
function packPanel:initMainPan()
	------------ btn panel
	local ReferScript = LuaHelper.GetComponent(self.main[2],"ReferGameObjects");
	for i=0, 4 do
		local name = ReferScript.monos[i].transform.parent.name;
		self.mainBtn.views[name] = ReferScript.monos[i];
	end
	------------ block
	ReferScript = LuaHelper.GetComponent(self.main[3],"ReferGameObjects");
	self.copyBlock = ReferScript.refers[0];
	------------ right Pan
	ReferScript = LuaHelper.GetComponent(self.main[4],"ReferGameObjects");
	self.rightPan = {};
	self.rightPan["uiSprite"] = ReferScript.monos[0];
	self.rightPan["name"] = ReferScript.monos[1];
	self.rightPan["count"] = ReferScript.monos[3];
	self.rightPan["attribute"] = ReferScript.monos[5];
	self.rightPan["info"] = ReferScript.monos[6];
	self.rightPan["perSell"] = ReferScript.monos[8];
	self.rightPan["sellBtn"] = ReferScript.monos[9].transform.parent.gameObject; 
	self.rightPan["infoBtn"] = ReferScript.monos[10].transform.parent.gameObject; 
	self.rightPan["compBtn"] = ReferScript.monos[11].transform.parent.gameObject;
	self.rightPan["useBtn"] = ReferScript.monos[12].transform.parent.gameObject;
	--- getValue
	--[[
		-- text 拥有/件/出售单价
	ReferScript.monos[2].text = getValue("");
	ReferScript.monos[4].text = getValue("");
	ReferScript.monos[7].text = getValue("");
		-- button 出售/详情/合成
	ReferScript.monos[9].text = getValue("");
	ReferScript.monos[10].text = getValue("");
	ReferScript.monos[11].text = getValue("");
	]]
	------------ sell Pan
	ReferScript = LuaHelper.GetComponent(self.main[5],"ReferGameObjects");
	self.sellPan = {};
	self.sellPan["uiSprite"] = ReferScript.monos[0];
	self.sellPan["name"] = ReferScript.monos[1];
	self.sellPan["count"] = ReferScript.monos[3];
	self.sellPan["perSell"] = ReferScript.monos[6];
	self.sellPan["sellNum"] = ReferScript.monos[8];
	self.sellPan["totalSell"] = ReferScript.monos[10];
		--- getValue
	--[[
		-- text 拥有/件/出售单价
	ReferScript.monos[2].text = getValue("");
	ReferScript.monos[4].text = getValue("");
	ReferScript.monos[5].text = getValue("");
		-- button 出售数量/获得金钱/确认出售
	ReferScript.monos[7].text = getValue("");
	ReferScript.monos[9].text = getValue("");
	ReferScript.monos[11].text = getValue("");
	]]
	------------ detail Pan
	------------ Compose Pan
	ReferScript = LuaHelper.GetComponent(self.main[7],"ReferGameObjects");
	self.composePan = {};
	self.composePan["uiSprite"] = ReferScript.monos[0];
end

--- 默认初始化本地背包数据
function packPanel:initGoodDatas()
	--- 当前选中的商品唯一标识
	self.selGood = -1;
	--- 默认选中的Btn名字
	self.mainBtn.curName = "BtnTopAll";
end

--- 通过goodId 获得具体的数据信息
function packPanel:getGoodDataById(goods_id)
	--- 检查原始表
	if self.models == nil then return nil end
	return self.models[tostring(goods_id)];
end

--- 通过原始表生成排序显示表， 并在原始表加入排序显示表中的索引
--- 有且仅当服务器数据变化的时候， 会重新排序
function packPanel:sortModel()
	--- 初始化显示表
	self.goodDatas = {};
	if self.models == nil then return end
	--- 按商品类型生成一张初表
	local newDatas = {};
	for i, v in pairs(self.models) do
		-- 查找配置表数据
		local localData = Model.itemData[tostring(v.netData.goods_id)];
		if localData then
			--- 生成基本表
			local gData = {};
			gData.netData = v.netData;
			gData.type = tonumber(localData.type);
			gData.color = tonumber(localData.color);
			--- 按类型更新子表
			local dIndex = tonumber(localData.type);
			if newDatas[dIndex] == nil then newDatas[dIndex] = {} end
			table.insert(newDatas[dIndex], gData);
		end
	end
	--- 进行类型排序， 生成新表是为避免数据遗失
	local tempDatas = {}  
	for i, v in pairs(newDatas) do  
		tempDatas[#tempDatas+1] = {index = i, data = v};  
	end  
	table.sort(tempDatas, sortIndex);
	--- 最后根据颜色排序生成最终表
	for i, v in ipairs(tempDatas) do
		if #v.data > 1 then table.sort(v.data, sortColor) end
		for key, gData in ipairs(v.data) do
			table.insert(self.goodDatas, gData);
			---- 初始化记录当前数据关联的view id
			gData.block = #self.goodDatas;
			--- 将索引更新到原始表
			local strIndex = tostring(gData.netData.goods_id);
			if self.models[strIndex] then
				self.models[strIndex].index = #self.goodDatas;
			end
		end
	end
end

--- 获得背包数据(申请或者通知得到的)
--- 记录获得的服务器原始信息， 通过商品id来索引
function packPanel.getSpecifyPackData(netData)
	-------------- data handle
	--- 生成服务器原始表
	if packPanel.models == nil then packPanel.models = {} end
	for i, v in ipairs(netData.goods) do
		--- 根据物品id生成表
		local strIndex = tostring(v.goods_id);
		if packPanel.models[strIndex] == nil then
		packPanel.models[strIndex] = {} end
		--- set 服务器数据更新
		packPanel.models[strIndex].netData = v;
	end
	-------------- view handle
	if packPanel.isShow then packPanel:updateBlocks() end
end

--- 获得背包物品变化消息(主)
function packPanel.getGoodsChange(netData)
	if packPanel.models == nil then return end
	-------------- data handle
	for i, v in ipairs(netData.goods) do
		-- 查找本地表中的数据
		local strIndex = tostring(v.goods_id);
		if packPanel.models[strIndex] == nil then
		packPanel.models[strIndex] = {} end
		packPanel.models[strIndex].netData = v;
		if v.goods_num == 0 then 
			--- 道具数量为0， 删除这个道具
			packPanel.models[strIndex] = nil;
		end
	end
	-------------- view handle
	if packPanel.isShow then packPanel:updateBlocks() end
end

--- btn的刷新改变
function packPanel:topBtnSetView()
	local btnName = self.mainBtn.curName;
	for i,v in pairs(self.mainBtn.views) do
		local tran  = v.transform.parent;
		if tran.name == self.mainBtn.curName then
			v.transform.localScale = Vector3(1, 1.5, 1);
			v.spriteName = btnSpriteNames[2];
		else
			v.transform.localScale = Vector3(1, 1, 1);
			v.spriteName = btnSpriteNames[1];
		end
	end 
end

--- btn切换处理
function packPanel:topBtnOnClick(btnName)
	if self.mainBtn.curName == btnName or self.mainBtn.views[btnName] == nil then return end
	--- btn view
	self.mainBtn.curName = btnName;
	self:topBtnSetView();
	--- 刷新view
	self:updateViewByTopBtn();
	--- 获得新的商品ID
	self:getNewGoodId();
	self:updateOtherPanel();
end

--- 根据topBtn 类型获得当前默认的商品ID
function packPanel:getNewGoodId()
	--- 设置默认的选中商品
	self.selGood = -1;
	self.sellCount = 1;
	-------------------------
	local iType = GetShowGoodType(self.mainBtn.curName);
	for i, v in ipairs(self.goodDatas) do
		if iType == 0 or iType == v.type then
			self.selGood = v.netData.goods_id;
			break;
		end
	end
end

--- 根据btn的商品类型 决定显示那些物品
function packPanel:updateViewByTopBtn()
	local iType = GetShowGoodType(self.mainBtn.curName);
	---- 当前最后的block 索引
	local bIndex = 0;
	---- 当前显示的block 数量
	local curShowLen = 0;
	--- 重新设置需要显示的图片内容 
	for i, gData in ipairs(self.goodDatas) do
		local localData = Model.itemData[tostring(gData.netData.goods_id)];
		if iType == 0 or iType == tonumber(localData.type) then
			bIndex = bIndex + 1;
			--- block 显示
			local view = self.blocks[bIndex];
			view:SetActive(true);
			SetChildAndBoxCollider(view, true);
			curShowLen = curShowLen + 1;
			--- block 名字, 后缀为goodDatas的索引
			view.name = self.copyBlock.name .. GetSpecifyStr(i, 4);
			--- 更新数据关联的view 索引
			gData.block = bIndex;
			--- 商品小图标
			local childs = LuaHelper.GetAllChild(view);
			local uiSprite = LuaHelper.GetComponent(childs[0].gameObject,"UISprite");
			uiSprite.spriteName = localData.icon;
		end
	end
	--- 在尾部添加空白块
	--- 隐藏多余的block
	for i = bIndex + 1, #self.blocks do
		self.blocks[i]:SetActive(false);
		local addLen = GetNeedAddBlock(curShowLen);
		if addLen ~= 0 then
			self.blocks[i].name = self.copyBlock.name .. "9999";
			self.blocks[i]:SetActive(true);
			SetChildAndBoxCollider(self.blocks[i], false);
			curShowLen = curShowLen + 1;
		end
	end

	---- 重新排序
	local sortGrid = LuaHelper.GetComponent(self.copyBlock.transform.parent.gameObject,"UIGrid");
	if sortGrid then sortGrid:Reposition(); end
end

--- 刷新block
function packPanel:updateBlocks()
	--- 更新显示表
	self:sortModel();

	--- 初始化blocks表
	if self.blocks == nil then self.blocks = {} end
	--- 根据显示表生成对应的blocks
	local newGoodCount = #self.goodDatas;
	newGoodCount = GetNewCountInfact(newGoodCount, 24, 4);
	
	if newGoodCount > #self.blocks then
		local startId = #self.blocks + 1;
		for i=startId, newGoodCount do
			local clone = LuaHelper.InstantiateLocal(self.copyBlock, self.copyBlock.transform.parent.gameObject);
			clone.name = self.copyBlock.name .. "9999";
			clone:SetActive(true);
			table.insert(self.blocks, clone);
		end
	end
	--- 刷新view
	self:updateViewByTopBtn();
	--- 检查上次选中的商品是否有效
	local model = self:getGoodDataById(self.selGood);
	if model == nil or model.index == nil then
		--- 无效ID，关闭所有子界面(售卖/合成)
		self.main[5]:SetActive(false);
		self.main[6]:SetActive(false);
		--- 获得新的ID
		self:getNewGoodId();
	end
	--- title更新
	self:topBtnSetView();
	--- 信息界面更新
	self.sellCount = 1;
	self:updateOtherPanel();
end

--- 清理当前的blocks表 和复制原件
function packPanel:clearBlocks()
	for key, var in pairs(self.blocks) do
		var.transform.parent = nil;
		LuaHelper.Destroy(var);
	end
	self.blocks = {};
end

function packPanel:setOtherPanelDefault()
	self.rightPan["uiSprite"].spriteName = "";
	--- lable
	self.rightPan["name"].text = "";
	self.rightPan["count"].text = 0;
	self.rightPan["attribute"].text = "";
	self.rightPan["info"].text = "";
	self.rightPan["perSell"].text = 0;

	self.rightPan["sellBtn"]:SetActive(false); 
	self.rightPan["infoBtn"]:SetActive(false);
	self.rightPan["compBtn"]:SetActive(false);
	self.rightPan["useBtn"]:SetActive(false);
end

--- 刷新和商品相关的其他界面
function packPanel:updateOtherPanel()
	--- 检查是否有物件被选中
	if self.selGood == nil or self.selGood == -1 then 
		self:setOtherPanelDefault();
		return;
	end
	------------------------------------------------
	local model = self.models[tostring(self.selGood)];
	local localData = Model.itemData[tostring(self.selGood)];
	--- 售卖/信息 btn的显示
	self.rightPan["sellBtn"]:SetActive(true); 
	self.rightPan["infoBtn"]:SetActive(true);
	--- 合成btn管理[需要检查这个碎片的数量是否可以合成]
	if localData.type == 4 then
		self.rightPan["compBtn"]:SetActive(true);
	else
		self.rightPan["compBtn"]:SetActive(false);
	end
	--- 使用btn管理[检查goods_type 是否可以使用] 
	if model.netData.goods_type == 1 and localData.type ~= 4 then
		self.rightPan["useBtn"]:SetActive(true);
	else
		self.rightPan["useBtn"]:SetActive(false);			
	end
	--- 相关面板的道具图标
	self.rightPan["uiSprite"].spriteName = localData.icon;
	self.sellPan["uiSprite"].spriteName = localData.icon;
	self.composePan["uiSprite"].spriteName = localData.icon;
	--- 信息面板->道具名/数量/属性/描述
	--- 出售面板->道具名/数量/单价/当前出售数量/总价
	self.rightPan["name"].text = getValue(localData.name);
	self.rightPan["count"].text = model.netData.goods_num;
	self.rightPan["attribute"].text = getValue(localData.attributeDesc);
	self.rightPan["info"].text = getValue(localData.Desc2);
	self.rightPan["perSell"].text = localData.sell_price;
	self.sellPan["name"].text = getValue(localData.name);
	self.sellPan["count"].text = model.netData.goods_num;
	self.sellPan["perSell"].text = localData.sell_price;
	self.sellPan["sellNum"].text = tostring(self.sellCount) .. "/" .. tostring(model.netData.goods_num);
	self.sellPan["totalSell"].text = localData.sell_price;
end

function packPanel:sellOnClick(strInfo)
	if self.models == nil then return end
	local model = self.models[tostring(self.selGood)];
	if model == nil then return end
	--------------------------------------
	local localData = Model.itemData[tostring(self.selGood)];
	local max = model.netData.goods_num;
	if strInfo == "BtnSellAdd" then
		self.sellCount = self.sellCount + 1;
		if self.sellCount > max then self.sellCount = 1; end
		self.sellPan["sellNum"].text = tostring(self.sellCount) .. "/" .. tostring(max);
		self.sellPan["totalSell"].text = localData.sell_price * self.sellCount;
	elseif strInfo == "BtnSellSub" then
		self.sellCount = self.sellCount - 1;
		if self.sellCount < 1 then self.sellCount = max; end
		self.sellPan["sellNum"].text = tostring(self.sellCount) .. "/" .. tostring(max);
		self.sellPan["totalSell"].text = localData.sell_price * self.sellCount;
	elseif strInfo == "BtnSellMax" then
		self.sellCount = max;
		self.sellPan["sellNum"].text = tostring(self.sellCount) .. "/" .. tostring(max);
		self.sellPan["totalSell"].text = localData.sell_price * self.sellCount;
	elseif strInfo == "BtnSellSure" then
		---- 发送消息
		SendGoods_sell(self.selGood, self.sellCount);
	end
end

function packPanel:useOnClick(obj)
	local cmd = obj.name;
	local tran = obj.transform.parent;

  	if cmd == "BtnUse" and tran and tran.name == "RightPanel" then
  		--- 使用
  		local model = self.models[tostring(self.selGood)];
  		if model and model.index then
  			SendUse_goods(self.selGood, 1);
  		end
  	end
end

function packPanel:blockOnClick(obj)
	local strTitle = string.sub(obj.name, 1, 9);
	if strTitle == "blockPreb" then
		--- 显示刷新
		local index = tonumber(string.sub(obj.name, 10));
		local needGoodId = self.goodDatas[index].netData.goods_id;
		if self.selGood ~= needGoodId then
			--- 重置售卖数量
			self.sellCount = 1;
			self.selGood = needGoodId;
			self:updateOtherPanel();
		end
	end
end

function packPanel:showAll()
	if not self.isShow then
		self:initGoodDatas();
		self.isShow = true;
		self:addToState();
	end
end

function packPanel:hideAll()
	self:removeFromState();
	self.isShow = false;
end

function packPanel:onShowed( ... )
	self:updateBlocks();
end

-- 资源加载完成时候调用方法
function packPanel:onAssetsLoad(items)
	local ReferScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
	if(ReferScript == nil)  then print("erro config"); end
	--[[
		-- title 背包
	ReferScript.monos[0].text = getValue("");
		-- top button 全部/道具/装备/卷轴/碎片
	ReferScript.monos[1].text = getValue("");
	ReferScript.monos[2].text = getValue("");
	ReferScript.monos[3].text = getValue("");
	ReferScript.monos[4].text = getValue("");
	ReferScript.monos[5].text = getValue("");
	]]
	-- panel
	self.main = {};
	for i=0, ReferScript.refers.Count - 1 do
		table.insert(self.main, ReferScript.refers[i]);
	end

	self:initMainPan();
end

function packPanel.msgCallBackBind()
	Proxy:binding(NetAPIList.recv_player_bag_goods, packPanel.getSpecifyPackData);
	Proxy:binding(NetAPIList.recv_player_bag_change_goods, packPanel.getGoodsChange);
end

-- 第一次注册的时候调用
function packPanel:initialize()
	
end

function packPanel:onClick(obj,arg)
  local cmd =obj.name
  if cmd == "BtnTopAll" or cmd == "BtnTopProp" 
  	or cmd == "BtnTopEquip" or cmd == "BtnTopScoll" or cmd == "BtnTopChip" then
  	self:topBtnOnClick(cmd);
  elseif cmd == "BtnTopClose" then
  	self:hideAll();
  elseif cmd == "BtnRSell" then
  	--- 重置数量
  	self.sellCount = 0;
  	self:sellOnClick("BtnSellAdd")
  	self.main[5]:SetActive(true);
  elseif cmd == "BtnSellClose" then
  	self.main[5]:SetActive(false); 	 
  elseif cmd == "BtnRDetail" then
  	self.main[6]:SetActive(true);
  elseif cmd == "BtnDetClose" then
  	self.main[6]:SetActive(false);
  end

  --- 主界面菜单检查
  if cmd == "BtnTeam" or cmd == "BtnTask" or cmd == "BtnRisk" 
    or cmd == "BtnFriend" or cmd == "BtnTuJian" then
    if obj.transform.parent and obj.transform.parent.name == "buttomPanel" then
       self:hideAll();
    end
  end

  self:blockOnClick(obj);
  self:sellOnClick(cmd);
  self:useOnClick(obj);
end

