local chatPanel = LuaItemManager:getItemObject("chatPanel")
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
local split = split
local common_fun = common_fun
print("chatPanel....")

--==================================================================================================
chatPanel.assets=
{
   Asset("chatPanel.u3d", {"Config"}),
}

--频道ID默认为1
--1 世界频道
local channelID = 1;
local isLoadSuccess = false;
chatPanel.isShow = false;

function chatPanel:onAssetsLoad(items)
  isLoadSuccess = true;
  --获取已绑定UI物体
  local referScript = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects");
  if(referScript == nil)  then print("error config"); end
  -- panel
  self.panels = {};
  for i=0, referScript.refers.Count - 1 do
    table.insert(self.panels, referScript.refers[i]);
  end

  self:showLabelsByChannel(channelID);
end

--插入聊天信息
function chatPanel:insertChat(name , content)
	local textList = self.panels[1].transform.parent:GetComponent("UITextList");
	local text = "[66a90e]" .. name .. ":[-]" .. "[ffffff]" .. content;
	textList:Add(text);
end

--清空聊天内容
function chatPanel:clearChatContent()
	local textList = self.panels[1].transform.parent:GetComponent("UITextList");
	textList:Clear();
end

--发送聊天消息
function chatPanel:sendChatMsg(content)
	local playerID = 0;
	if channelID == 1 then
		playerID = 0;
	end
	local msg = NetMsgHelper:makesend_chat(channelID, playerID, content);

	Proxy:sendChat(NetAPIList.send_chat,msg);
end

--接收到聊天消息
function receive_Chat_Msg(name, content)
	if not chatPanel.isShow then
		print("聊天面板未打开");
		return;
	end
	chatPanel:insertChat(name, content);
end

--响应发送按钮
function chatPanel:onSendBtnClick()
	local inputLabel = LuaHelper.GetComponent(self.panels[2], "UILabel");
	if string.len(inputLabel.text) < 1 then
		return;
	end

	local name = Model:getPlayerInfo().name;
	local content = inputLabel.text;
  	local isQualified, msg = common_fun.checkString(content);

	if channelID == 1 then
  		Model.insertWorldChatMsgs(name, msg);
  	end

	self:insertChat(name, msg);
	self:sendChatMsg(inputLabel.text);
	self.panels[2].transform.parent.gameObject:GetComponent("UIInput").value = "";
	local textList = self.panels[1].transform.parent:GetComponent("UITextList");
	textList.scrollValue = 1;

end


function chatPanel:onClick(obj,arg)
	local cmd = obj.name;
	if cmd == "SendButton" then
		self:onSendBtnClick();
	-- elseif cmd == "WorldButton" then
	-- 	self:clearChatContent();
	elseif cmd =="CloseButton" then
		self:hideAll();
	end
end

--根据频道显示内容
function chatPanel:showLabelsByChannel(ID)
	self:clearChatContent();
	if ID == 1 then
		for i, v in ipairs(Model.getWorldChatMsgs()) do
			self:insertChat(v.playerName, v.msg);
		end
	end
end

function chatPanel:showAll()
	if not self.isShow then
		self.isShow = true;
		self:addToState();

		if not isLoadSuccess then
			return;
		end

		--每次打开面板时,重新取聊天信息
		self:showLabelsByChannel(channelID);
	end
end

function chatPanel:hideAll()
	self:removeFromState();
	self.isShow = false;
end




--==================================================================================================