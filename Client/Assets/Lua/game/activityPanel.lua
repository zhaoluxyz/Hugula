local activityPanel = LuaItemManager:getItemObject("activityPanel")
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
local common_fun = common_fun
local Proxy=Proxy
local Model = Model
local MailData = MailData
local getValue = getValue
local NetMsgHelper = NetMsgHelper
local NetAPIList = NetAPIList
local Color = UnityEngine.Color
local FileUtils=FileUtils
local fileUtils = FileUtils()
local PrefabPool = luanet.PrefabPool.instance
local PlayerPrefs = luanet.UnityEngine.PlayerPrefs

local totalRefer; --总参数
local curType = 0;
local curTag;
local textureCount = 0;

activityPanel.assets=
{
  Asset("activityPanel.u3d"),
}

function activityPanel:onAssetsLoad(items)
	totalRefer = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects")
	local list = {};
	for i,v in pairs(Model.activityData) do
		activityPanel.addToList("activityBack" .. v.category, list);
	end
	Loader:getResource(list,false)
end

--初始化所有活动
function activityPanel:initActivity()
	local list = Model.activityData;
	local index = 0;
	for i,v in pairs(list) do
		if index == 0 then index = v.category; end
		if index > v.category then index = v.category; end
		self:openActivity(v);
	end
	self:changeActivity(index);
	local grid = totalRefer.refers[0].transform.parent.parent:GetComponent("UIGrid");
	grid:Reposition();
	local scrollView = grid.transform.parent:GetComponent("UIScrollView");
	scrollView:ResetPosition();
end

--图片资源加载完成回调
function activityPanel.onModelComplete(req)
  local key = req.key
  if req.data then
    local mainAsset = req.data.assetBundle.mainAsset
    local clone
    if mainAsset:GetType().Name == "Texture2D" then
      clone=mainAsset
    else
      LuaHelper.RefreshShader(req.data)
      clone = LuaHelper.Instantiate(req.data.assetBundle.mainAsset)
      clone.name=key
      clone:SetActive(false)
    end
    PrefabPool:Add(key,clone)
    disposeWWW(req.data)
  end
  textureCount = textureCount - 1;
  if textureCount == 0 then
  	activityPanel:initActivity();
  end
end 

function activityPanel.addToList(key,reqs)
  if key and key~="" and  string.match(string.lower(key),"ref_%w*")==nil then
      reqs[key]={CUtils.GetAssetFullPath(key..".u3d"), activityPanel.onModelComplete}
      textureCount = textureCount + 1;
  end
end

--开启活动
function activityPanel:openActivity(data)
	if data.category == 1 or data.category == 2 or 
	   data.category == 3 or data.category == 4 then
		local refer = totalRefer.monos[data.category];
		totalRefer.refers[data.category - 1].transform.parent.gameObject:SetActive(true);
		local times = refer.monos[0];
		local physical = refer.monos[1];
		local config = Model.getActivityData(data.activity_a);
		if config == nil then return end
		times.text = tostring(config.waste);
		physical.text = tostring(Model.getActivityTimes(data.category));
		
		if data.activity_a < 1 then
			local back = refer.monos[2];
			back.transform.parent:GetComponent("BoxCollider").enabled = false;
		end

		if data.activity_b < 1 then
			local back = refer.monos[3];
			back.transform.parent:GetComponent("BoxCollider").enabled = false;
		end

		if data.activity_c < 1 then
			local back = refer.monos[4];
			back.transform.parent:GetComponent("BoxCollider").enabled = false;
		end
	end

	--以后有活动类型增加在此扩展
end

function activityPanel:onClick(obj,arg)
	local cmd = obj.name;
	if cmd == "xiuLianBtn" then
		self:onXiuLianBtnClick();
	elseif cmd == "cangBaoBtn" then
		self:onCangBaoBtnClick();
	elseif cmd == "faShuBtn" then
		print("onFaShuBtnClick");
		self:onFaShuBtnClick();
	elseif cmd == "liLiangBtn" then
		self:onLiLiangBtnClick();
	elseif cmd == "CloseBtn" then
		self:hideAll();
	elseif cmd == "lowerBtn" then
		self:onlowerBtnClick();
	elseif cmd == "middleBtn" then
		self:onMiddleBtnClick();
	elseif cmd == "highBtn" then
		self:onHighBtnClick();
	end
end

--响应低级试练按钮
function activityPanel:onlowerBtnClick()
	for i, v in pairs(Model.activityData) do
		if v.category == curType then
			local config = Model.getActivityData(v.activity_a);
			self:sendBeginActivity(config.duo_name);
		end
	end
end

--响应中级试练按钮
function activityPanel:onMiddleBtnClick()
	for i, v in pairs(Model.activityData) do
		if v.category == curType then
			local config = Model.getActivityData(v.activity_b);
			self:sendBeginActivity(config.duo_name);
		end
	end
end

--响应高级试练按钮
function activityPanel:onHighBtnClick()
	for i, v in pairs(Model.activityData) do
		if v.category == curType then
			local config = Model.getActivityData(v.activity_c);
			self:sendBeginActivity(config.duo_name);
		end
	end
end

--发送进入关卡消息
function activityPanel:sendBeginActivity(id)
	print("begin activity  :" .. id);
	local msg = NetMsgHelper:makesend_challenge_chapter(id);
	Proxy:send(NetAPIList.player_challenge_chapter,msg);
end

--响应修练场按钮点击
function activityPanel:onXiuLianBtnClick()
	if curType ~= 1 then self:changeActivity(1);
	else return end
end

--响应藏宝洞按钮点击
function activityPanel:onCangBaoBtnClick()
	if curType ~= 2 then self:changeActivity(2);
	else return end
end

--响应法术试练按钮点击
function activityPanel:onFaShuBtnClick()
	if curType ~= 3 then 
		print("onFaShuBtnClick123");

		self:changeActivity(3);
	else 
		print("onFaShuBtnClick321");

		return 
	end
end

--响应力量试练按钮点击
function activityPanel:onLiLiangBtnClick()
	if curType ~= 4 then self:changeActivity(4);
	else return end
end

--打开活动页签
function activityPanel:changeActivity(change)
	if curType > 0 then
		totalRefer.monos[curType].gameObject:SetActive(false);
	end
	curType = change;
	totalRefer.monos[curType].gameObject:SetActive(true);
	local background = totalRefer.monos[0];

	local texture = PrefabPool:Get("activityBack" .. change)
	background.mainTexture = texture;

	if curTag then curTag:SetActive(false); end
	curTag = totalRefer.refers[change - 1];
	curTag:SetActive(true);
end

function activityPanel:showAll()
	if not self.isShow then
		self.isShow = true;
		self:addToState();
	end
end

function activityPanel:hideAll()
	self:removeFromState();
	self.isShow = false;
end