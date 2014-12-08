local signInPanel = LuaItemManager:getItemObject("signInPanel")
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
local showTips = showTips
local split = split
local GAMEOBJECT_ATLAS = GAMEOBJECT_ATLAS

signInPanel.assets=
{
   Asset("signInPanel.u3d", {"Config"}),
}

signInPanel.isShow = false;

function signInPanel:onAssetsLoad(items)
  --获取已绑定UI物体
  local referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
  if(referScript == nil)  then print("error config"); end
  -- panel
  self.refers = {};
  for i=0, referScript.refers.Count - 1 do
    table.insert(self.refers, referScript.refers[i]);
  end
  self:init();
  self:setReceivedState(Model.signInData.player_day - 1);
end

--初始化
function signInPanel:init()
	--获取配置表
	local config = Model.getDiscreteData(900040);
	local week = Model.signInData.player_week;
	local data = {};
	for i = 1,7 do
		local key = (week - 1) * 7 + i;
		local mData = config.data;
		if not mData then
			print("mData 为空请检查配置表");
			return;
		end
		local value = mData[tostring(key)];
		if not value then
			print("Can't find the key in DiscreteData  :" .. key);
			return;
		end
		data[i] = value;
	end

	--根据配置替换图标和名字
	for i, v in pairs(data) do
		local id = split(v, "-")[1];
		local trans = self.refers[i].transform;
		local data = Model.getItemData(id);

		local icon;
		if data then
			icon = trans:FindChild("icon"):GetComponent("UISprite");
		else
			data = Model.getUnit(id);
			if data then
				trans:FindChild("icon").gameObject:SetActive(false);
				icon = trans:FindChild("ricon"):GetComponent("UISprite");
				icon.gameObject:SetActive(true);
			end
		end
		if data then
			local name      = trans:FindChild("name"):GetComponent("UILabel");
			icon.spriteName = data.icon;
			name.text       = getValue(data.name);
		else
			print("Can't find the SignIn Config id  :" .. id);
		end
	end
end

--设置为已接收状态(传入天数)
function signInPanel:setReceivedState(daysNumber)
  for i=1, daysNumber do
	self.refers[i].transform:FindChild("received").gameObject:SetActive(true);
  end
  self.refers[1].transform.parent.parent.gameObject:SetActive(true);
end

--发送领取消息
function signInPanel:sendReceiveMsg()
	local week = Model.signInData.player_week;
	local day = Model.signInData.player_day;
	local msg = NetMsgHelper:makesend_player_reward_login(week, day);
	Proxy:send(NetAPIList.player_login_receive,msg);
	
  	Model.signInData.reward_status = true;
  	showTips("签到成功!", self:hideAll());
end

function signInPanel:onClick(obj,arg)
	local cmd = obj.name;
	if cmd =="CloseBtn" then
		self:hideAll();
	elseif cmd == "ReceiveBtn" then
		self:sendReceiveMsg();
	end
end

function signInPanel:showAll()
	if Model.signInData == nil then
		return;
	end
	if not self.isShow then
		self.isShow = true;
		self:addToState();
	end

end

function signInPanel:hideAll()
	self:removeFromState();
	self.isShow = false;
end