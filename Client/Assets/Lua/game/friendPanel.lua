local friendPanel = LuaItemManager:getItemObject("friendPanel")
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
local PlayerPrefs = luanet.UnityEngine.PlayerPrefs
local RenderSettingsHelper=luanet.import_type("RenderSettingsHelper")
--==================================================================================================
friendPanel.assets=
{
  Asset("friendPanel.u3d"),
}

local totalRefer
local friendRefer
local addRefer
local friendList --好友列表
local addList --好友申请列表
local findList --查找好友列表
local friendTag --好友标签按钮sprite
local addTag --添加标签按钮sprite

local friendListData = {} --用于遍历Item和其数据
local addListData = {}
local findListData = {}

local tagState = 0; --1 好友 2 添加
local isDeleteState = false; --是否为删除状态

local isLoad = false; --是否加载完成预设

friendPanel.curChoose = nil;	

function friendPanel:onAssetsLoad(items)
	totalRefer = LuaHelper.GetComponent(self.assets[1].items["Config"],"ReferGameObjects")
	friendRefer = totalRefer.monos[0];
	addRefer = totalRefer.monos[1];
	friendTag = totalRefer.monos[2];
	addTag = totalRefer.monos[3];

	friendList = friendRefer.monos[0];
	addList = addRefer.monos[0];
	findList = addRefer.monos[1];

	self:updateListData();
	--注册各列表
	friendPanel:registerTableEnvent(friendList);
	friendPanel:registerTableEnvent(addList);
	friendPanel:registerTableEnvent(findList);

  	Proxy:binding(NetAPIList.recv_find_player_list,friendPanel.callback_searchFriendMsg);

	--默认显示好友列表
	self:showFriendList();
	self:setFriendNum();

	--设置标签消息
	self:setAddTagMsgNumber(#Model.friendApplyList);
	self:updateReceiveTimes();

	self:updateCoolDown();
	self:updateFriendship();
    isLoad = true;
end

--更新友情点
function friendPanel:updateFriendship()
	totalRefer.monos[5].text = tostring(Model.getPlayerInfo().player_friendship);
end

--刷新所有列表
function friendPanel:updateListData()
	print("friendList Num : " .. #Model.friendList)
	--加载列表
	friendList.pageSize = #Model.friendList;
	friendList.data = Model.friendList;
	friendList:Refresh();

	self:updateApplyListData();
end

--刷新申请列表
function friendPanel:updateApplyListData()
	print("friendApplyList Num : " .. #Model.friendApplyList)
	addList.pageSize = #Model.friendApplyList;
	addList.data = Model.friendApplyList;
	addList:Refresh();
end

--注册Table	
function friendPanel:registerTableEnvent(obj)
	if obj == friendList then
		obj.onItemRender = 
		function(referScipt,index,itemdata)
			print("instantiate the friend item  :"  .. itemdata.friends_player_name);
			local t = {};
			t.data = itemdata;
			t.item = referScipt;

			print("friend Instantiate index  :" .. index);
			--C#数组从0开始的
			friendListData[index + 1] = t;

			local icon = referScipt.monos[0];
			local data = Model.getUnit(itemdata.friends_player_role_id);
			if data then icon.spriteName = data.icon; end
			local name = referScipt.monos[1];
			local lv = referScipt.monos[2];
			name.text = itemdata.friends_player_name;
			lv.text = itemdata.friends_player_lv;

			--设置消息提示
			local mailTable = Model.friendMails[tostring(itemdata.friends_player_id)];
			local msgNum = 0;
			if mailTable then msgNum = #mailTable; end
			self:setItemMsgHint(referScipt, msgNum);

			--领取友情按钮设置
			self:setItemRecvFriendShipBtn(referScipt, itemdata.give_away_friendship);
			--不可赠送友情
			if itemdata.cool_down > 0 then
				local back = referScipt.monos[8];
				--back.color = Color.gray;
				back.transform.parent:GetComponent("BoxCollider").enabled = false;
				referScipt.monos[9].gameObject:SetActive(false);
				referScipt.monos[7].gameObject:SetActive(true);
			end
			referScipt.gameObject:SetActive(true);

			--刷新ScrollView
			if index == friendList.pageSize - 1 then
				local scrollview = referScipt.transform.parent.parent:GetComponent("UIScrollView");
				scrollview:ResetPosition();
			end
		end
	elseif obj == addList then
		obj.onItemRender = 
		function(referScipt,index,itemdata)
			local t = {};
			t.data = itemdata;
			t.item = referScipt;
			addListData[index + 1] = t;
			local icon = referScipt.monos[0];
			local name = referScipt.monos[1];
			local lv = referScipt.monos[2];
			name.text = itemdata.player_name;
			lv.text = itemdata.player_lv;
			local data = Model.getUnit(itemdata.player_role_id);
			if data then icon.spriteName = data.icon; end

			referScipt.gameObject:SetActive(true);

			--刷新ScrollView
			if index == addList.pageSize - 1 then
				local scrollview = referScipt.transform.parent.parent:GetComponent("UIScrollView");
				scrollview:ResetPosition();
			end
		end
	elseif obj == findList then
		obj.onItemRender =
		function (referScipt,index,itemdata)
			local t = {};
			t.data = itemdata;
			t.item = referScipt;
			findListData[index + 1] = t;
			local icon = referScipt.monos[0];
			local name = referScipt.monos[1];
			local lv = referScipt.monos[2];
			name.text = itemdata.player_name;
			lv.text = itemdata.player_lv;

			local data = Model.getUnit(itemdata.player_role_id);
			if data then icon.spriteName = data.icon; end

			referScipt.gameObject:SetActive(true);
			--刷新ScrollView
			if index == findList.pageSize - 1 then
				local scrollview = referScipt.transform.parent.parent:GetComponent("UIScrollView");
				scrollview:ResetPosition();
			end
		end
	end
end

--------------------------好友列表界面相关----------------------

--设置Item领取友情值按钮
function friendPanel:setItemRecvFriendShipBtn(item , num)
	--可领取友情点
	if num > 0 then
		local recvSprite = item.monos[6];
		recvSprite.gameObject:SetActive(true);
		local box = recvSprite.transform.parent:GetComponent("BoxCollider");
		box.enabled = true;
	else
		local recvSprite = item.monos[6];
		recvSprite.gameObject:SetActive(false);
		local box = recvSprite.transform.parent:GetComponent("BoxCollider");
		box.enabled = false;
	end
end

--设置提示消息
function friendPanel:setItemMsgHint(item, num)
	if num > 0 then
		item.refers[3]:SetActive(false);
		item.monos[5].text = num;
		item.monos[3].transform.parent.gameObject:SetActive(true);
	else
		item.monos[3].transform.parent.gameObject:SetActive(false);
		item.refers[3]:SetActive(true);
	end
end

--设置赠送友情点按钮
function friendPanel:updateCoolDown()
	for i, v in pairs(friendListData) do
		if self.isShow and v.data.cool_down >= 0 then
			local timeLabel = v.item.monos[7];
			local time = v.data.cool_down;
			local hour = math.floor(time / 3600);
			time = time - hour * 3600;
			local min = math.floor(time / 60);
			local second = time % 60;
			local sMin = tostring(min);
			local sSecond = tostring(second);
			if min < 10 then
				sMin = "0" .. sMin;
			end
			if second < 10 then
				sSecond = "0" .. sSecond;
			end
			timeLabel.text = hour ..":"..sMin .. ":" .. sSecond;

			v.data.cool_down = v.data.cool_down - 1;
			if v.data.cool_down < 0 then
				local back = v.item.monos[8];
				back.color = Color.white;
				back.transform.parent:GetComponent("BoxCollider").enabled = true;
				v.item.monos[7].gameObject:SetActive(false);
				v.item.monos[9].gameObject:SetActive(true);
			end
		end
	end

	delay(friendPanel.updateCoolDown, 1, self);
	print("updateCoolDown");
end

--显示好友列表
function friendPanel:showFriendList()
	if tagState == 1 then
		return;
	end
	tagState = 1;
	totalRefer.refers[1]:SetActive(true);
	friendTag.gameObject:SetActive(false);
	totalRefer.refers[2]:SetActive(false);
	addTag.gameObject:SetActive(true);

	friendRefer.gameObject:SetActive(true);
	addRefer.gameObject:SetActive(false);
end

--显示添加列表
function friendPanel:showAddList()
	if tagState == 2 then
		return;
	end
	tagState = 2;


	totalRefer.refers[1]:SetActive(false);
	friendTag.gameObject:SetActive(true);
	totalRefer.refers[2]:SetActive(true);
	addTag.gameObject:SetActive(false);

	friendRefer.gameObject:SetActive(false);
	addRefer.gameObject:SetActive(true);
	self:setAddTagMsgNumber(0);
end

--设置好友Item状态(删除开关)
function friendPanel:setItemState()

	if #Model.friendList > 0 then
		local fTrans = friendList.transform;
		if isDeleteState then isDeleteState = false;
		else isDeleteState = true; end

		for i,v in pairs(friendListData) do
			local item = v.item;
			if item then
				if isDeleteState then
					item.refers[0].transform.parent.gameObject:SetActive(false);
					item.refers[1]:SetActive(false);
					item.refers[2]:SetActive(true);
				else 
					item.refers[0].transform.parent.gameObject:SetActive(true);
					item.refers[1]:SetActive(true);
					item.refers[2]:SetActive(false);
				end
			end
		end
	end
end

--响应删除按钮
function friendPanel:deleteBtnClick(obj)
	local refer = obj.transform.parent:GetComponent("ReferGameObjects");
	self.curChoose = refer;
	self:setDeleteWndState(true);
end

--确定删除
function friendPanel:sureDeleteClick()
	--找到对应的数据
	for i, v in pairs(friendListData) do
		if v.item == self.curChoose then
			local msg = NetMsgHelper:makesend_player_friends_delete(v.data.friends_player_id);
    		Proxy:send(NetAPIList.player_friends_delete, msg);
			table.remove(Model.friendList, i);
			friendList.pageSize = #Model.friendList;
			friendList.data = Model.friendList;
			friendList:Refresh();
			self:setDeleteWndState(false);
		end
	end
end

--响应赠送好友友情按钮
function friendPanel:giveBtnClick(obj)
	local refer = obj.transform.parent:GetComponent("ReferGameObjects");
	--找到对应的数据
	for i, v in pairs(friendListData) do
		if v.item == refer then
			local data = v.data;
    		local msg = NetMsgHelper:makesend_value_friendship(data.friends_player_id);
    		Proxy:send(NetAPIList.player_add_send_value_friendship, msg);
		end
	end
end

--响应一键领取按钮
function friendPanel:onOneKeyBtnClick()
	local msg = NetMsgHelper:makesend_reveive_friendship_pick_up("a");
    Proxy:send(NetAPIList.player_friends_pick_up, msg);

    local times = 0;
    --减少可领取次数
    for i,v in pairs(Model.friendList) do
    	if v.give_away_friendship > 0 and Model.friendShipTimes > 0 then
     		Model.friendShipTimes = Model.friendShipTimes - 1;
     		v.give_away_friendship = 0;
     		times = times + 1;
     	end
	end

	for i,v in pairs(friendListData) do
		if v.data.give_away_friendship > 0 and times > 0 then
			v.data.give_away_friendship = 0;
			times = times - 1;
			self:setItemRecvFriendShipBtn(v.item, 0);
		end
	end
	self:updateReceiveTimes();
end

--响应发消息按钮
function friendPanel:onWriteMsgBtnClick(obj)
	local refer = obj.transform.parent.parent:GetComponent("ReferGameObjects");
	self.curChoose = refer;
	self:initMsgWindow(1, nil, refer.monos[1].text);
	self:setMsgWndState(true);
end

--响应读消息按钮
function friendPanel:onReadMsgBtnClick(obj)
	local refer = obj.transform.parent.parent:GetComponent("ReferGameObjects");
	self.curChoose = refer;
	for i,v in pairs(friendListData) do
		if v.item == refer then
			local t = Model.friendMails[tostring(v.data.friends_player_id)];
			local mail = t[1];
			self:initMsgWindow(2, mail.mail_body, refer.monos[1].text);
			local msg = NetMsgHelper:makesend_player_mail_delete(mail.mail_id);
    		Proxy:send(NetAPIList.player_mail_delete, msg);
			table.remove(t, 1);
			self:setItemMsgHint(refer, #t);
			self:setMsgWndState(true);
			break;
		end
	end
end

--初始化消息窗口.  msgType 1 写消息 2读消息
function friendPanel:initMsgWindow(msgType, content, name)
	if msgType == 1 then
		friendRefer.monos[5].gameObject:SetActive(true);
		friendRefer.monos[6].gameObject:SetActive(false);
		friendRefer.monos[2].text = name;
		local label = friendRefer.monos[3];
		local typeLabel = friendRefer.monos[1];
		local btnLabel = friendRefer.monos[8];
		label.text = "";
		label.transform.parent:GetComponent("BoxCollider").enabled = true;
		typeLabel.key = "friend_button_004";
	elseif msgType == 2 then
		friendRefer.monos[5].gameObject:SetActive(false);
		friendRefer.monos[6].gameObject:SetActive(true);
		friendRefer.monos[2].text = name;
		local label = friendRefer.monos[3];
		local typeLabel = friendRefer.monos[1];
		local btnLabel = friendRefer.monos[8];
		label.text = content;
		label.transform.parent:GetComponent("BoxCollider").enabled = false;
		typeLabel.key = "main_mail_005";
	end
end

--更新领取次数
function friendPanel:updateReceiveTimes()
	friendRefer.monos[7].text = tostring(Model.friendShipTimes);
end

--领取友情点
function friendPanel:receiveFriendShip(obj)
	if Model.friendShipTimes < 1 then
		return;
	end
	local refer = obj.transform.parent:GetComponent("ReferGameObjects");
	for i,v in pairs(friendListData) do
		if v.item == refer then
			local msg = NetMsgHelper:makesend_reveive_friendship(v.data.friends_player_id);
    		Proxy:send(NetAPIList.player_receive_friendship, msg);
			self:setItemRecvFriendShipBtn(v.item, 1000);
			Model.friendShipTimes = Model.friendShipTimes - 1;
		end
	end
	self:updateReceiveTimes();
end

--设置消息窗口状态
function friendPanel:setMsgWndState(state)
	friendRefer.refers[0]:SetActive(state);
end

-----信件界面消息------

--响应回复消息按钮
function friendPanel:onRequestMsgBtnClick()
	self:initMsgWindow(1, nil, self.curChoose.monos[1].text);
end

--响应发送消息按钮
function friendPanel:onSendMsgBtnClick()
	local label = friendRefer.monos[3].transform.parent:GetComponent("UIInput").value;
	if string.len(label) < 1 then return end;
	for i, v in pairs(friendListData) do
		if v.item == self.curChoose then
			local playerId = v.data.friends_player_id;
			local msg = NetMsgHelper:makesend_player_send_mail(playerId, "1", label);
    		Proxy:send(NetAPIList.player_send_mail, msg);
			self:setMsgWndState(false);
			return;
		end
	end
end

------------------------------添加列表界面相关----------------------------

--好友申请回复 1同意 0拒绝
function friendPanel:friendApplyRequest(obj, state)
	local refer = obj.transform.parent:GetComponent("ReferGameObjects"); 
	for i, v in pairs(addListData) do
		if v.item == refer then
			local msg = NetMsgHelper:makesend_request_friends_apply(v.data.player_id, state);
    		Proxy:send(NetAPIList.player_request_add_friends, msg);
			table.remove(Model.friendApplyList, i);
			
			addList.pageSize = #Model.friendApplyList;
			addList.data = Model.friendApplyList;
			addList:Refresh();
		end
	end
end

--模糊查找
function friendPanel:onFindBtnClick()
	local msg = NetMsgHelper:makesend_player_find_list("", 2, 1, 10);
    Proxy:send(NetAPIList.player_find_list, msg);
end

--精确查找
function friendPanel:onSearchBtnClick()
	local name = addRefer.monos[2];
	if string.len(name.value) < 1 then
		return;
	end
	local msg = NetMsgHelper:makesend_player_find_list(name.value, 1, 1, 1000);
    Proxy:send(NetAPIList.player_find_list, msg);
end

--接收查找列表
function friendPanel.callback_searchFriendMsg(data)
	addList.transform.parent.parent.gameObject:SetActive(false);
	findList.transform.parent.parent.gameObject:SetActive(true);
	findList.pageSize = #data.list;
	findList.data = data.list;
	findList:Refresh();
end

--响应返回按钮
function friendPanel:onBackBtnClick(obj)
	addList.transform.parent.parent.gameObject:SetActive(true);
	findList.transform.parent.parent.gameObject:SetActive(false);
end

--发送添加好友申请
function friendPanel:onApplyBtnClick(obj)
	local refer = obj.transform.parent:GetComponent("ReferGameObjects"); 
	for i, v in pairs(findListData) do
		if v.item == refer then
			local msg = NetMsgHelper:makesend_request_friends_apply(v.data.player_id);
    		Proxy:send(NetAPIList.player_apply_add_friends, msg);
    		table.remove(findList.data, i);
			findList.pageSize = #findList.data;
			findList.data = findList.data;
			findList:Refresh();
		end
	end
end

----------------------------------------

function friendPanel:onClick(obj,arg)
	local cmd = obj.name;
	if cmd == "CloseBtn" then
		self:hideAll();
	elseif cmd == "friendBtn" then
		self:showFriendList();
	elseif cmd == "addBtn" then
		self:showAddList();
	elseif cmd == "deleteFriendBtn" then
		self:setItemState();
	elseif cmd == "giveBtn" then
		self:giveBtnClick(obj);
	elseif cmd == "deleteBtn" then
		self:deleteBtnClick(obj);
	elseif cmd == "sureDeleteBtn" then
		self:sureDeleteClick();
	elseif cmd == "closeDeletePanel" then
		self:setDeleteWndState(false);
	elseif cmd == "agreeBtn" then
		self:friendApplyRequest(obj, 1);
	elseif cmd == "refuseBtn" then
		self:friendApplyRequest(obj, 0);
	elseif cmd == "searchBtn" then
		self:onSearchBtnClick();
	elseif cmd == "backBtn" then
		self:onBackBtnClick();
	elseif cmd == "findBtn" then
		self:onFindBtnClick();
	elseif cmd == "applyBtn" then
		self:onApplyBtnClick(obj);
	elseif cmd == "writeMsgBtn" then
		self:onWriteMsgBtnClick(obj);
	elseif cmd == "readMsgBtn" then
		self:onReadMsgBtnClick(obj);
	elseif cmd == "requestMsgBtn" then
		self:onRequestMsgBtnClick();
	elseif cmd == "sendMsgBtn" then
		self:onSendMsgBtnClick();
	elseif cmd == "oneKeyBtn" then
		self:onOneKeyBtnClick();
	elseif cmd == "closeMsgWndBtn" then
		self:setMsgWndState(false);
	elseif cmd == "Icon" then
		self:receiveFriendShip(obj);
	end
end

--设置添加标签消息数量
function friendPanel:setAddTagMsgNumber(num)
	local addTag = totalRefer.monos[4];
	if num > 0 then
		addTag.text = tostring(num);
		addTag.transform.parent.gameObject:SetActive(true);
	else
		addTag.transform.parent.gameObject:SetActive(false);
	end
end

--设置删除窗口状态
function friendPanel:setDeleteWndState(state)
	local deletePanel = totalRefer.refers[0];
	deletePanel:SetActive(state);
end

--好友数量
function friendPanel:setFriendNum()
	local label = friendRefer.monos[9];
	local limit = 0;

	for i ,v in pairs(Model.systemConfig) do
		if v.key == "conf_friend_max_num" then limit = v.val; break; end
	end

	label.text = #Model.friendList .. "/" .. limit;
end

function friendPanel:showAll()
	if not self.isShow then
    self.isShow = true;
    self:addToState();
  	end

  	if isLoad then
  		--刷新列表
		self:updateListData();
		--默认显示好友列表
		self:showFriendList();
		--设置标签消息
		self:setAddTagMsgNumber(#Model.friendApplyList);
		self:updateReceiveTimes();
  	end
end

function friendPanel:hideAll()
  self:removeFromState();
  self.isShow = false;
end

------------------------实时更新---------------
--更新好友列表
function updateFriendList()
	if friendPanel.isShow and isLoad then
		friendList.pageSize = #Model.friendList;
		friendList.data = Model.friendList;
		friendList:Refresh();

		friendPanel:setFriendNum();
	end
end

--收到消息后更新好友申请列表
function updateFriendApplyList()
	if friendPanel.isShow and isLoad then
		addList.pageSize = #Model.friendApplyList;
		addList.data = Model.friendApplyList;
		addList:Refresh();
	end
end

--刷新好友消息提示
function updateFriendMsgHint()
	if friendPanel.isShow and isLoad then
		for i, v in pairs(friendListData) do
			local t = Model.friendMails[tostring(v.data.friends_player_id)];
			local num = 0;
			if t then num = #t end
			friendPanel:setItemMsgHint(v.item, num);
		end
	end
end

function updateFriendship_Call_back()
	if friendPanel.isShow and isLoad then
		friendPanel:updateFriendship();
	end
end

