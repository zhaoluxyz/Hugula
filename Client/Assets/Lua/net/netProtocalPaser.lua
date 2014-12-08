------------------- NetProtocalPaser---------------
local NetAPIList = NetAPIList
NetProtocalPaser = {}
function NetProtocalPaser:parsestring(msg, key, parentTable)
    parentTable[key]    =   msg:ReadString()
end

function NetProtocalPaser:parseinteger(msg, key, parentTable)
    parentTable[key]    =   msg:ReadInt()
end

function NetProtocalPaser:parsefloat(msg, key, parentTable)
    parentTable[key]    =   msg:ReadFloat()
end

function NetProtocalPaser:parseshort(msg, key, parentTable)
    parentTable[key]    =   msg:ReadShort()
end

function NetProtocalPaser:parsebyte(msg, key, parentTable)
    parentTable[key]    =   msg:ReadByte()
end

function NetProtocalPaser:parseboolean(msg, key, parentTable)
    parentTable[key]    =   msg:ReadBoolean()
end

function NetProtocalPaser:parsepkid(msg,key,parentTable)
    parentTable[key]    =   msg:ReadString()
end

function NetProtocalPaser:parsechar(msg,key,parentTable)
    parentTable[key]    =   msg:ReadChar()
end

function NetProtocalPaser:parseushort(msg,key,parentTable)
    parentTable[key]    =   msg:ReadUShort()
end

function NetProtocalPaser:parseuint(msg,key,parentTable)
    parentTable[key]    =   msg:ReadUInt()
end

function NetProtocalPaser:parseulong(msg,key,parentTable)
    parentTable[key]    =   msg:ReadULong()
end


function NetProtocalPaser:formatstring(msg, value)
    msg:WriteString(value)
end

function NetProtocalPaser:formatinteger(msg, value)
    msg:WriteInt(value)
end

function NetProtocalPaser:formatshort(msg, value)
    msg:WriteShort(value)
end

function NetProtocalPaser:formatfloat(msg, value)
    msg:WriteFloat(value)
end

function NetProtocalPaser:formatbyte(msg, value)
     msg:WriteByte(value)
end

function NetProtocalPaser:formatboolean(msg, value)
    msg:WriteBoolean(value)
end

function NetProtocalPaser:formatchar(msg, value)
    msg:WriteChar(value)
end

function NetProtocalPaser:formatushort(msg, value)
    msg:WriteUShort(value)
end

function NetProtocalPaser:formatuint(msg, value)
    msg:WriteUInt(value)
end

function NetProtocalPaser:formatulong(msg, value)
    msg:WriteULong(value)
end

function NetProtocalPaser:formatArray(msg, value, valueType)
    local funcName = "format" .. valueType
    local func = self[funcName]
    local arrayLen = #value
    msg:WriteUShort(arrayLen)
    for i=1, arrayLen, 1 do
        local v = value[i]
        func(self,msg,v)
    end
end

function NetProtocalPaser:formatpkid(msg,value)
     msg:WriteString(value)
end

function NetProtocalPaser:parseArray(msg, key, parentTable, valueType)
    local funcName = "parse" .. valueType
    local func = self[funcName]
    parentTable[key]= {}
    local arrayLen = msg:ReadUShort()
    for i=1, arrayLen, 1 do
        local tempT = {}
        func(self,msg,"tempK", tempT)
        table.insert(parentTable[key],tempT.tempK)
    end
end


function NetProtocalPaser:parseMessage(msg,msgType)
    local result    = {}
    msgType = "MSGTYPE" .. msgType
    local dataStructName = NetAPIList:getDataStructFromMsgType(msgType)

    if(dataStructName ~= "null") then
        local funcName = "parse"..dataStructName
        local func = NetProtocalPaser[funcName]
        func(self, msg,nil,result)
    end
    return result
end

function NetProtocalPaser:formatMessage(msg,msgType, content)
    msg:set_Type(msgType)
    msgType = "MSGTYPE" .. msgType
    local dataStructName = NetAPIList:getDataStructFromMsgType(msgType)
    if(dataStructName ~= "null") then
        local funcName = "format"..dataStructName
        --print("---- formatMessage func name--- " .. funcName)
        local func = NetProtocalPaser[funcName]
        func(self, msg, content)
    end
end

function NetProtocalPaser:parsept_pkid(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
end

function NetProtocalPaser:parsept_pkids(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'ids', parentTable,'pkid')
end

function NetProtocalPaser:parsept_int(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'i', parentTable)
end

function NetProtocalPaser:parsept_code(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'api', parentTable)
	self:parseinteger(msg,'code', parentTable)
end

function NetProtocalPaser:parsedb_single(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseinteger(msg,'gift_power_date', parentTable)
end

function NetProtocalPaser:parsept_ubase(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'name', parentTable)
	self:parseshort(msg,'sex', parentTable)
	self:parseshort(msg,'account_type', parentTable)
	self:parsestring(msg,'account', parentTable)
	self:parsestring(msg,'token', parentTable)
end

function NetProtocalPaser:parsedb_device(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsestring(msg,'d_type', parentTable)
	self:parsestring(msg,'udid', parentTable)
	self:parsestring(msg,'os', parentTable)
	self:parsestring(msg,'os_version', parentTable)
	self:parsestring(msg,'market', parentTable)
	self:parsestring(msg,'terminal', parentTable)
	self:parsestring(msg,'lcl', parentTable)
	self:parsestring(msg,'mac_addr', parentTable)
	self:parsestring(msg,'locale', parentTable)
end

function NetProtocalPaser:parsedb_user(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepkid(msg,'device_id', parentTable)
	self:parseshort(msg,'account_type', parentTable)
	self:parsestring(msg,'account', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseshort(msg,'sex', parentTable)
	self:parsestring(msg,'icon', parentTable)
	self:parseshort(msg,'power', parentTable)
	self:parseshort(msg,'gift_power', parentTable)
	self:parseinteger(msg,'buy_power', parentTable)
	self:parseinteger(msg,'level', parentTable)
	self:parsepkid(msg,'experience', parentTable)
	self:parsepkid(msg,'money', parentTable)
	self:parseinteger(msg,'group', parentTable)
	self:parseinteger(msg,'story', parentTable)
	self:parseinteger(msg,'gold', parentTable)
	self:parseinteger(msg,'magic_card', parentTable)
	self:parseshort(msg,'powergift_num', parentTable)
	self:parseinteger(msg,'powergift_date', parentTable)
	self:parseinteger(msg,'maxfevent', parentTable)
end

function NetProtocalPaser:parserc_buy_times(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'id', parentTable)
	self:parseshort(msg,'num', parentTable)
end

function NetProtocalPaser:parserc_buy_log(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseArray(msg,'item', parentTable,'rc_buy_times')
end

function NetProtocalPaser:parseflrfid(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'floor', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parseinteger(msg,'id', parentTable)
end

function NetProtocalPaser:parsemaze_fight(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'maze', parentTable)
	self:parseArray(msg,'enemy', parentTable,'flrfid')
	self:parseshort(msg,'floor', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parseinteger(msg,'id', parentTable)
	self:parseinteger(msg,'refush', parentTable)
	self:parseshort(msg,'step', parentTable)
	self:parseinteger(msg,'reset', parentTable)
end

function NetProtocalPaser:parserc_magic_scroll(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseshort(msg,'num', parentTable)
end

function NetProtocalPaser:parsedb_userinfo(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseshort(msg,'frd_del_num', parentTable)
	self:parseinteger(msg,'frd_del_date', parentTable)
	self:parseArray(msg,'cards', parentTable,'integer')
	self:parseArray(msg,'runes', parentTable,'integer')
	self:parseArray(msg,'mazes', parentTable,'maze_fight')
	self:parseshort(msg,'star5', parentTable)
	self:parseArray(msg,'buy_log', parentTable,'rc_buy_log')
	self:parseinteger(msg,'buy_date', parentTable)
	self:parseinteger(msg,'time_power_date', parentTable)
	self:parseinteger(msg,'g_power_date', parentTable)
	self:parseinteger(msg,'chp_times', parentTable)
	self:parseinteger(msg,'chp_win', parentTable)
	self:parseinteger(msg,'frd_times', parentTable)
	self:parseinteger(msg,'frd_win', parentTable)
	self:parseshort(msg,'monster_add', parentTable)
	self:parseinteger(msg,'login_time', parentTable)
	self:parseinteger(msg,'logout_time', parentTable)
	self:parsestring(msg,'create_at', parentTable)
	self:parseArray(msg,'magic_scroll', parentTable,'rc_magic_scroll')
	self:parseinteger(msg,'ban', parentTable)
	self:parseinteger(msg,'mute', parentTable)
	self:parseinteger(msg,'total_charge', parentTable)
	self:parseinteger(msg,'lev_prize_date', parentTable)
	self:parseshort(msg,'change_name_num', parentTable)
	self:parseArray(msg,'first_event', parentTable,'short')
end

function NetProtocalPaser:parsept_account(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsept_ubase(msg,'base', parentTable)
	self:parsedb_device(msg,'device', parentTable)
	self:parseinteger(msg,'app_ver', parentTable)
end

function NetProtocalPaser:parsedb_card(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseinteger(msg,'base_id', parentTable)
	self:parseshort(msg,'level', parentTable)
	self:parseinteger(msg,'experience', parentTable)
end

function NetProtocalPaser:parsedb_cards(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'cards', parentTable,'db_card')
end

function NetProtocalPaser:parsegrune(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'baseid', parentTable)
	self:parseinteger(msg,'level', parentTable)
end

function NetProtocalPaser:parsegcard(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'baseid', parentTable)
	self:parseinteger(msg,'level', parentTable)
end

function NetProtocalPaser:parsedb_group(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseArray(msg,'runes', parentTable,'grune')
	self:parseArray(msg,'cards', parentTable,'gcard')
end

function NetProtocalPaser:parsedb_groups(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'groups', parentTable,'db_group')
end

function NetProtocalPaser:parsept_group_ac(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'card', parentTable)
end

function NetProtocalPaser:parsept_group_dc(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'card', parentTable)
end

function NetProtocalPaser:parsedb_rune(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseinteger(msg,'base_id', parentTable)
	self:parseinteger(msg,'level', parentTable)
	self:parseinteger(msg,'experience', parentTable)
end

function NetProtocalPaser:parsedb_runes(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'runes', parentTable,'db_rune')
end

function NetProtocalPaser:parsept_group_ar(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'rune', parentTable)
end

function NetProtocalPaser:parsept_group_dr(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'rune', parentTable)
end

function NetProtocalPaser:parsedb_story(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseinteger(msg,'base_id', parentTable)
	self:parseinteger(msg,'finish', parentTable)
end

function NetProtocalPaser:parsedb_storys(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'storys', parentTable,'db_story')
end

function NetProtocalPaser:parsepk_fcard_base(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'baseId', parentTable)
	self:parseinteger(msg,'hp', parentTable)
	self:parseinteger(msg,'ad', parentTable)
	self:parseshort(msg,'limit', parentTable)
	self:parseshort(msg,'cost', parentTable)
end

function NetProtocalPaser:parsepk_fcard_fight(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'nowlevel', parentTable)
	self:parseinteger(msg,'nowhp', parentTable)
	self:parseinteger(msg,'nowat', parentTable)
	self:parseshort(msg,'nowdef', parentTable)
	self:parseshort(msg,'nowmis', parentTable)
end

function NetProtocalPaser:parsepk_fcard_temp(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'tmphp', parentTable)
	self:parseinteger(msg,'tmpat', parentTable)
	self:parseinteger(msg,'tmpap', parentTable)
	self:parseshort(msg,'tmpdef', parentTable)
	self:parseshort(msg,'tmpres', parentTable)
	self:parseshort(msg,'tmpmis', parentTable)
end

function NetProtocalPaser:parsepk_buff(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseshort(msg,'value', parentTable)
	self:parseshort(msg,'number', parentTable)
end

function NetProtocalPaser:parsepk_apply(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'atk', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parseshort(msg,'def', parentTable)
	self:parseshort(msg,'value', parentTable)
end

function NetProtocalPaser:parsepk_fcard(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'idx', parentTable)
	self:parsepk_fcard_base(msg,'fcardbase', parentTable)
	self:parsepk_fcard_fight(msg,'fcardfight', parentTable)
end

function NetProtocalPaser:parsepk_frune(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'idx', parentTable)
	self:parseinteger(msg,'baseid', parentTable)
	self:parseshort(msg,'level', parentTable)
	self:parseshort(msg,'timer', parentTable)
end

function NetProtocalPaser:parsepk_fight_group(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'hero', parentTable)
	self:parseArray(msg,'rune', parentTable,'pk_frune')
	self:parseArray(msg,'home', parentTable,'pk_fcard')
	self:parseArray(msg,'waiting', parentTable,'pk_fcard')
	self:parseArray(msg,'fighting', parentTable,'pk_fcard')
	self:parseArray(msg,'dead', parentTable,'pk_fcard')
end

function NetProtocalPaser:parsepk_area_log(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'hom', parentTable,'short')
	self:parseArray(msg,'wit', parentTable,'short')
	self:parseArray(msg,'fig', parentTable,'short')
	self:parseArray(msg,'dea', parentTable,'short')
end

function NetProtocalPaser:parsepk_cres(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'hp', parentTable)
	self:parseinteger(msg,'at', parentTable)
	self:parseshort(msg,'def', parentTable)
	self:parseshort(msg,'mis', parentTable)
end

function NetProtocalPaser:parsepk_move(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'idx', parentTable)
	self:parseshort(msg,'from', parentTable)
	self:parseshort(msg,'to', parentTable)
	self:parseshort(msg,'pos', parentTable)
end

function NetProtocalPaser:parsepk_flog(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseshort(msg,'times', parentTable)
	self:parseshort(msg,'attacker', parentTable)
	self:parseshort(msg,'defender', parentTable)
	self:parseinteger(msg,'skillid', parentTable)
	self:parseshort(msg,'target', parentTable)
	self:parseinteger(msg,'hero_damage', parentTable)
	self:parseinteger(msg,'hero_check', parentTable)
	self:parsepk_cres(msg,'cardfres', parentTable)
	self:parsepk_cres(msg,'cardfdata', parentTable)
	self:parseArray(msg,'cardfstate', parentTable,'short')
	self:parseArray(msg,'cardfbuff', parentTable,'pk_buff')
	self:parseArray(msg,'atkdesc', parentTable,'pk_apply')
	self:parseArray(msg,'defdesc', parentTable,'pk_apply')
	self:parsepk_cres(msg,'cardftemp', parentTable)
	self:parseArray(msg,'area', parentTable,'pk_move')
	self:parsepk_cres(msg,'attkerfdata', parentTable)
end

function NetProtocalPaser:parsepk_clog(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'a_pos', parentTable)
	self:parsestring(msg,'b_pos', parentTable)
end

function NetProtocalPaser:parsepk_round(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'opts', parentTable)
	self:parsestring(msg,'content', parentTable)
end

function NetProtocalPaser:parsepk_fight_log(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'areaLogCho', parentTable,'pk_move')
	self:parseArray(msg,'areaLogSen', parentTable,'pk_move')
	self:parseArray(msg,'fistShowLog', parentTable,'pk_flog')
	self:parseArray(msg,'areaLogSho', parentTable,'pk_move')
	self:parseArray(msg,'runeLog', parentTable,'pk_flog')
	self:parseArray(msg,'areaLogRun', parentTable,'pk_move')
	self:parseArray(msg,'commonShowLog', parentTable,'pk_flog')
	self:parseArray(msg,'areaLogCom', parentTable,'pk_move')
end

function NetProtocalPaser:parsepk_record(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'round', parentTable)
	self:parseshort(msg,'isend', parentTable)
	self:parsepk_fight_log(msg,'fightlog', parentTable)
end

function NetProtocalPaser:parsepk_ready(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'first', parentTable)
	self:parsepk_fight_group(msg,'attacker', parentTable)
	self:parsepk_fight_group(msg,'defender', parentTable)
end

function NetProtocalPaser:parsepk_fight_data_result(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'result', parentTable)
	self:parseshort(msg,'totle', parentTable)
	self:parsepk_ready(msg,'ready', parentTable)
	self:parseArray(msg,'recordlist', parentTable,'pk_record')
end

function NetProtocalPaser:parsedb_fightlog(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepk_fight_data_result(msg,'log', parentTable)
end

function NetProtocalPaser:parsedb_storylog(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'user_id', parentTable)
	self:parsepkid(msg,'fighter', parentTable)
	self:parseinteger(msg,'time', parentTable)
	self:parsepkid(msg,'log', parentTable)
end

function NetProtocalPaser:parsedb_pvplog(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepkid(msg,'enemy', parentTable)
	self:parseshort(msg,'result', parentTable)
	self:parseshort(msg,'value', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parseinteger(msg,'time', parentTable)
	self:parsepkid(msg,'log', parentTable)
end

function NetProtocalPaser:parsept_pvelog(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'logid', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'icon', parentTable)
	self:parseinteger(msg,'lev', parentTable)
end

function NetProtocalPaser:parsept_pvelog_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'story', parentTable)
	self:parseArray(msg,'log', parentTable,'pt_pvelog')
end

function NetProtocalPaser:parsept_pvplog(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'logid', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parsepkid(msg,'enemy', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'icon', parentTable)
	self:parseinteger(msg,'lev', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'score', parentTable)
	self:parsepkid(msg,'len_id', parentTable)
	self:parseshort(msg,'len_flag', parentTable)
	self:parsestring(msg,'len_name', parentTable)
	self:parseshort(msg,'result', parentTable)
	self:parseshort(msg,'value', parentTable)
	self:parseinteger(msg,'time', parentTable)
end

function NetProtocalPaser:parsept_pvplog_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'score', parentTable)
	self:parseArray(msg,'log', parentTable,'pt_pvplog')
end

function NetProtocalPaser:parsept_chat2server(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'channel', parentTable)
	self:parsepkid(msg,'receiveid', parentTable)
	self:parsestring(msg,'content', parentTable)
end

function NetProtocalPaser:parsept_chat2player(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'channel', parentTable)
	self:parsepkid(msg,'sendid', parentTable)
	self:parsestring(msg,'sendname', parentTable)
	self:parseinteger(msg,'sendlevel', parentTable)
	self:parsestring(msg,'sendicon', parentTable)
	self:parsepkid(msg,'sendlen_id', parentTable)
	self:parseshort(msg,'sendlen_flag', parentTable)
	self:parseshort(msg,'sendlen_pos', parentTable)
	self:parsepkid(msg,'receiveid', parentTable)
	self:parsestring(msg,'receivename', parentTable)
	self:parsestring(msg,'content', parentTable)
end

function NetProtocalPaser:parsept_crdlist(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'crdlist', parentTable,'integer')
end

function NetProtocalPaser:parsedb_friend(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepkid(msg,'frd_id', parentTable)
	self:parseshort(msg,'type', parentTable)
end

function NetProtocalPaser:parsedb_friends(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'friends', parentTable,'db_friend')
end

function NetProtocalPaser:parsedb_powergift(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepkid(msg,'other_id', parentTable)
	self:parseshort(msg,'self_flag', parentTable)
	self:parseinteger(msg,'self_date', parentTable)
	self:parseshort(msg,'other_flag', parentTable)
	self:parseinteger(msg,'other_date', parentTable)
end

function NetProtocalPaser:parsedb_powergifts(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'gifts', parentTable,'db_powergift')
end

function NetProtocalPaser:parsept_frd_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'user_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseshort(msg,'sex', parentTable)
	self:parsestring(msg,'icon', parentTable)
	self:parseinteger(msg,'level', parentTable)
	self:parseshort(msg,'type', parentTable)
end

function NetProtocalPaser:parsept_frd_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'frd_list', parentTable,'pt_frd_info')
end

function NetProtocalPaser:parsept_frd_init(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'frd_list', parentTable,'pt_frd_info')
end

function NetProtocalPaser:parsept_frd_agree(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'friend_id', parentTable)
	self:parseboolean(msg,'agree', parentTable)
end

function NetProtocalPaser:parsept_enemy(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'rank', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseshort(msg,'sex', parentTable)
	self:parseshort(msg,'level', parentTable)
	self:parseinteger(msg,'win', parentTable)
	self:parseinteger(msg,'lose', parentTable)
	self:parseshort(msg,'getpic', parentTable)
	self:parsestring(msg,'icon', parentTable)
end

function NetProtocalPaser:parsept_all_enemy(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'enemy', parentTable,'pt_enemy')
end

function NetProtocalPaser:parsedb_grade(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseinteger(msg,'cfg_id', parentTable)
	self:parseinteger(msg,'finish_date', parentTable)
	self:parseshort(msg,'finish', parentTable)
	self:parseshort(msg,'gain', parentTable)
end

function NetProtocalPaser:parsedb_gradeevent(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsestring(msg,'event', parentTable)
	self:parsestring(msg,'condition', parentTable)
end

function NetProtocalPaser:parsept_grade_test(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'event', parentTable)
	self:parsestring(msg,'condition', parentTable)
end

function NetProtocalPaser:parsept_grade_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'cfg_id', parentTable)
	self:parseshort(msg,'finish', parentTable)
	self:parseshort(msg,'gain', parentTable)
	self:parsestring(msg,'event', parentTable)
end

function NetProtocalPaser:parsept_grade_info_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'info', parentTable,'pt_grade_info')
end

function NetProtocalPaser:parsept_card_enhance(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseArray(msg,'food', parentTable,'integer')
end

function NetProtocalPaser:parsept_rune_enhance(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseArray(msg,'food', parentTable,'integer')
end

function NetProtocalPaser:parserc_chest(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseinteger(msg,'num', parentTable)
end

function NetProtocalPaser:parsedb_chest(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseshort(msg,'source', parentTable)
	self:parseinteger(msg,'time', parentTable)
	self:parseArray(msg,'reward', parentTable,'rc_chest')
end

function NetProtocalPaser:parsedb_chests(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'chests', parentTable,'db_chest')
end

function NetProtocalPaser:parsept_prize_test(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'type', parentTable)
	self:parseinteger(msg,'num', parentTable)
end

function NetProtocalPaser:parserc_temple_site(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseinteger(msg,'id', parentTable)
end

function NetProtocalPaser:parserc_temple_fragment(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseinteger(msg,'num', parentTable)
end

function NetProtocalPaser:parsedb_temple(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseshort(msg,'grade', parentTable)
	self:parseArray(msg,'fragment_amount', parentTable,'rc_temple_fragment')
	self:parseArray(msg,'site_goodtype', parentTable,'rc_temple_site')
end

function NetProtocalPaser:parsept_temple_datas(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'grade', parentTable)
	self:parseArray(msg,'fragments', parentTable,'rc_temple_fragment')
	self:parseArray(msg,'sites', parentTable,'rc_temple_site')
end

function NetProtocalPaser:parsept_mapinfo(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'mapid', parentTable)
	self:parseArray(msg,'storyid', parentTable,'integer')
	self:parseArray(msg,'invade', parentTable,'integer')
end

function NetProtocalPaser:parsept_nadainfo(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'nadaid', parentTable,'integer')
end

function NetProtocalPaser:parsedb_legion(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'remark', parentTable)
	self:parseshort(msg,'flag', parentTable)
	self:parseshort(msg,'lock', parentTable)
	self:parseshort(msg,'lev', parentTable)
	self:parseinteger(msg,'exp', parentTable)
	self:parsepkid(msg,'guard', parentTable)
	self:parseshort(msg,'del_num', parentTable)
	self:parseinteger(msg,'del_time', parentTable)
end

function NetProtocalPaser:parsedb_lenmeb(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepkid(msg,'player_id', parentTable)
	self:parseshort(msg,'pos', parentTable)
	self:parseinteger(msg,'devote', parentTable)
	self:parseinteger(msg,'join_time', parentTable)
	self:parseinteger(msg,'doe_money', parentTable)
	self:parseinteger(msg,'doe_gold', parentTable)
	self:parseinteger(msg,'doe_date', parentTable)
end

function NetProtocalPaser:parsedb_lenapply(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepkid(msg,'player_id', parentTable)
	self:parseshort(msg,'apply', parentTable)
	self:parseshort(msg,'invite', parentTable)
end

function NetProtocalPaser:parsept_len_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'remark', parentTable)
	self:parseinteger(msg,'exp', parentTable)
	self:parseshort(msg,'lev', parentTable)
	self:parseshort(msg,'flag', parentTable)
	self:parseshort(msg,'lock', parentTable)
	self:parseshort(msg,'meb', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'score', parentTable)
end

function NetProtocalPaser:parsept_len_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'pt_len_info')
end

function NetProtocalPaser:parsept_lenmeb_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseinteger(msg,'lev', parentTable)
	self:parseshort(msg,'pos', parentTable)
	self:parseinteger(msg,'devote', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'score', parentTable)
end

function NetProtocalPaser:parsept_lenmeb_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'pt_lenmeb_info')
end

function NetProtocalPaser:parsept_len_all_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsept_len_info(msg,'legion', parentTable)
	self:parseArray(msg,'meb', parentTable,'pt_lenmeb_info')
end

function NetProtocalPaser:parsept_len_create(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'name', parentTable)
end

function NetProtocalPaser:parsept_len_apply(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'icon', parentTable)
	self:parseinteger(msg,'lev', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'score', parentTable)
end

function NetProtocalPaser:parsept_len_apply_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'pt_len_apply')
end

function NetProtocalPaser:parsept_len_apply_opr(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseboolean(msg,'agree', parentTable)
end

function NetProtocalPaser:parsept_len_devote(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseinteger(msg,'num', parentTable)
end

function NetProtocalPaser:parsept_create_legion(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'remark', parentTable)
	self:parseshort(msg,'flag', parentTable)
	self:parseshort(msg,'lock', parentTable)
end

function NetProtocalPaser:parsept_legion_self(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'legion_id', parentTable)
	self:parseshort(msg,'pos', parentTable)
end

function NetProtocalPaser:parsept_groupupd_rune(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseArray(msg,'runelist', parentTable,'integer')
end

function NetProtocalPaser:parsept_groupupd_card(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseArray(msg,'cardlist', parentTable,'integer')
end

function NetProtocalPaser:parsept_prize_get(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parsestring(msg,'prize', parentTable)
end

function NetProtocalPaser:parsept_player_report(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'type', parentTable)
	self:parsestring(msg,'desc', parentTable)
end

function NetProtocalPaser:parsept_rune_once(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'runes', parentTable)
end

function NetProtocalPaser:parsept_maze(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'maze', parentTable)
	self:parseArray(msg,'enemy', parentTable,'flrfid')
	self:parseshort(msg,'floor', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parseinteger(msg,'id', parentTable)
	self:parseinteger(msg,'refush', parentTable)
	self:parseshort(msg,'step', parentTable)
	self:parseinteger(msg,'reset', parentTable)
end

function NetProtocalPaser:parsept_maze_all(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'maze', parentTable,'pt_maze')
end

function NetProtocalPaser:parsept_market_item(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'id', parentTable)
	self:parseinteger(msg,'cost', parentTable)
	self:parseinteger(msg,'num', parentTable)
end

function NetProtocalPaser:parsept_market(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'type', parentTable)
	self:parseArray(msg,'item', parentTable,'pt_market_item')
end

function NetProtocalPaser:parsept_market_buy(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'type', parentTable)
	self:parseinteger(msg,'id', parentTable)
	self:parseboolean(msg,'flag', parentTable)
end

function NetProtocalPaser:parsept_market_card(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'type', parentTable)
	self:parseinteger(msg,'id', parentTable)
	self:parseArray(msg,'item', parentTable,'pt_market_item')
	self:parseArray(msg,'cards', parentTable,'pkid')
end

function NetProtocalPaser:parsept_market_gold(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'type', parentTable)
	self:parseinteger(msg,'id', parentTable)
	self:parseArray(msg,'item', parentTable,'pt_market_item')
	self:parseinteger(msg,'gold', parentTable)
end

function NetProtocalPaser:parsept_market_power(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'type', parentTable)
	self:parseinteger(msg,'id', parentTable)
	self:parseArray(msg,'item', parentTable,'pt_market_item')
	self:parseinteger(msg,'power', parentTable)
end

function NetProtocalPaser:parsept_ranks_get(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'id', parentTable)
	self:parseinteger(msg,'type', parentTable)
end

function NetProtocalPaser:parsept_ranks_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'rank', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'icon', parentTable)
	self:parseinteger(msg,'lev', parentTable)
	self:parseinteger(msg,'value', parentTable)
end

function NetProtocalPaser:parsept_ranks_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'id', parentTable)
	self:parsept_ranks_info(msg,'self', parentTable)
	self:parseArray(msg,'info', parentTable,'pt_ranks_info')
end

function NetProtocalPaser:parsept_story_hide(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'info', parentTable)
end

function NetProtocalPaser:parsept_gmcmd(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'cmd', parentTable)
end

function NetProtocalPaser:parsedb_mapreward(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseinteger(msg,'map_id', parentTable)
	self:parseArray(msg,'invade', parentTable,'integer')
	self:parseinteger(msg,'invade_time', parentTable)
	self:parseinteger(msg,'gain_time', parentTable)
	self:parseshort(msg,'gain_num', parentTable)
end

function NetProtocalPaser:parsept_map_gain(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'map', parentTable)
	self:parseinteger(msg,'money', parentTable)
end

function NetProtocalPaser:parsept_map_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'date', parentTable)
	self:parseArray(msg,'story', parentTable,'integer')
	self:parseinteger(msg,'gain', parentTable)
	self:parseArray(msg,'maze', parentTable,'pt_maze')
	self:parseArray(msg,'invade', parentTable,'integer')
end

function NetProtocalPaser:parsept_map_friend(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'story', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'icon', parentTable)
end

function NetProtocalPaser:parsept_map_friend_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'pt_map_friend')
end

function NetProtocalPaser:parsedb_coldtime(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseshort(msg,'chp_times', parentTable)
	self:parseshort(msg,'chp_gold', parentTable)
	self:parseinteger(msg,'champion', parentTable)
	self:parseinteger(msg,'freedom', parentTable)
	self:parseinteger(msg,'monster', parentTable)
	self:parseinteger(msg,'crazy', parentTable)
	self:parseinteger(msg,'lrank', parentTable)
	self:parseinteger(msg,'lrank_buy', parentTable)
end

function NetProtocalPaser:parsept_champion(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'rank', parentTable)
	self:parseshort(msg,'times', parentTable)
	self:parseshort(msg,'cd', parentTable)
end

function NetProtocalPaser:parsept_freedom(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'cd', parentTable)
end

function NetProtocalPaser:parsemcard(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'baseid', parentTable)
	self:parseshort(msg,'level', parentTable)
	self:parseinteger(msg,'hp', parentTable)
	self:parseshort(msg,'att', parentTable)
end

function NetProtocalPaser:parsept_m_group(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'hero', parentTable)
	self:parseArray(msg,'cards', parentTable,'mcard')
end

function NetProtocalPaser:parsept_m_fighter(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseinteger(msg,'score', parentTable)
end

function NetProtocalPaser:parsedb_monster(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseshort(msg,'level', parentTable)
	self:parseshort(msg,'hard', parentTable)
	self:parseinteger(msg,'score', parentTable)
	self:parsepkid(msg,'find_id', parentTable)
	self:parseinteger(msg,'find_time', parentTable)
	self:parseinteger(msg,'end_time', parentTable)
	self:parseArray(msg,'attacker', parentTable,'pt_m_fighter')
	self:parsept_m_group(msg,'fightdata', parentTable)
	self:parsepkid(msg,'killer_id', parentTable)
	self:parseinteger(msg,'killed_time', parentTable)
	self:parseinteger(msg,'prizecard', parentTable)
end

function NetProtocalPaser:parsedb_mail(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parseshort(msg,'new', parentTable)
	self:parsepkid(msg,'from', parentTable)
	self:parseinteger(msg,'event', parentTable)
	self:parsestring(msg,'title', parentTable)
	self:parsestring(msg,'content', parentTable)
	self:parseinteger(msg,'time', parentTable)
end

function NetProtocalPaser:parsept_player_mail(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parseshort(msg,'new', parentTable)
	self:parseinteger(msg,'time', parentTable)
	self:parsestring(msg,'event', parentTable)
end

function NetProtocalPaser:parsept_player_mail_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'info', parentTable,'pt_player_mail')
end

function NetProtocalPaser:parsept_write_mail(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'receiver', parentTable)
	self:parsestring(msg,'title', parentTable)
	self:parsestring(msg,'content', parentTable)
end

function NetProtocalPaser:parsept_new_mail(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parseshort(msg,'num', parentTable)
end

function NetProtocalPaser:parsept_new_mail_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'pt_new_mail')
end

function NetProtocalPaser:parsept_monster(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'level', parentTable)
	self:parseshort(msg,'hard', parentTable)
	self:parseshort(msg,'now', parentTable)
	self:parseshort(msg,'score', parentTable)
	self:parsepkid(msg,'find_id', parentTable)
	self:parsestring(msg,'find_name', parentTable)
	self:parseinteger(msg,'time', parentTable)
	self:parseshort(msg,'round', parentTable)
	self:parsepkid(msg,'killer_id', parentTable)
	self:parsestring(msg,'killer_name', parentTable)
end

function NetProtocalPaser:parsept_find_monster(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsept_monster(msg,'monster', parentTable)
	self:parseshort(msg,'cd', parentTable)
end

function NetProtocalPaser:parsept_monster_all(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'all', parentTable,'pt_monster')
	self:parseshort(msg,'cd', parentTable)
end

function NetProtocalPaser:parsept_crazy_score(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'once', parentTable)
	self:parseinteger(msg,'totle', parentTable)
end

function NetProtocalPaser:parsept_pay_verify(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'platform', parentTable)
	self:parsestring(msg,'pay_type', parentTable)
	self:parsestring(msg,'token', parentTable)
	self:parsestring(msg,'signature', parentTable)
end

function NetProtocalPaser:parsept_pay_list_get(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'platform', parentTable)
end

function NetProtocalPaser:parsept_pay_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'pay_types', parentTable,'string')
end

function NetProtocalPaser:parsept_legion_rank_get(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'start', parentTable)
	self:parseinteger(msg,'size', parentTable)
end

function NetProtocalPaser:parsept_lrank_buy(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'num', parentTable)
	self:parseinteger(msg,'cost', parentTable)
end

function NetProtocalPaser:parselegion_rank(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'remark', parentTable)
	self:parseinteger(msg,'exp', parentTable)
	self:parseshort(msg,'lev', parentTable)
	self:parseshort(msg,'flag', parentTable)
	self:parseshort(msg,'lock', parentTable)
	self:parseshort(msg,'meb', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'score', parentTable)
	self:parseinteger(msg,'threat', parentTable)
end

function NetProtocalPaser:parsept_legion_rank_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'len_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseshort(msg,'num', parentTable)
	self:parseinteger(msg,'cost', parentTable)
	self:parseArray(msg,'legion_ranks', parentTable,'legion_rank')
end

function NetProtocalPaser:parseplayer_rank_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'user_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'icon', parentTable)
	self:parseinteger(msg,'level', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'scores', parentTable)
	self:parseshort(msg,'pos', parentTable)
	self:parseinteger(msg,'devote', parentTable)
	self:parseinteger(msg,'plan_score', parentTable)
	self:parseinteger(msg,'plan_money', parentTable)
	self:parseinteger(msg,'protected', parentTable)
end

function NetProtocalPaser:parsept_player_rank_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'rank', parentTable)
	self:parseshort(msg,'num', parentTable)
	self:parseinteger(msg,'cost', parentTable)
	self:parseArray(msg,'mebs', parentTable,'player_rank_info')
end

function NetProtocalPaser:parsep_rank_info(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'user_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parsestring(msg,'icon', parentTable)
	self:parseinteger(msg,'level', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'scores', parentTable)
	self:parsepkid(msg,'legion_id', parentTable)
	self:parsestring(msg,'legion_name', parentTable)
	self:parseshort(msg,'flag', parentTable)
end

function NetProtocalPaser:parsept_p_rank_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'scores', parentTable)
	self:parseArray(msg,'mebs', parentTable,'p_rank_info')
end

function NetProtocalPaser:parserc_sign(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'num', parentTable)
	self:parseshort(msg,'gain', parentTable)
end

function NetProtocalPaser:parsedb_sign(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseshort(msg,'month', parentTable)
	self:parseArray(msg,'sign', parentTable,'rc_sign')
	self:parseinteger(msg,'time', parentTable)
end

function NetProtocalPaser:parsept_sign(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'month', parentTable)
	self:parserc_sign(msg,'sign', parentTable)
end

function NetProtocalPaser:parsedb_param(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseArray(msg,'intary', parentTable,'integer')
end

function NetProtocalPaser:parsepk_cteam(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'baseid', parentTable)
	self:parseinteger(msg,'level', parentTable)
end

function NetProtocalPaser:parsedb_war(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parseArray(msg,'cards', parentTable,'pk_cteam')
end

function NetProtocalPaser:parsedb_gvglog(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'id', parentTable)
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepkid(msg,'legion_id', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'scores', parentTable)
	self:parseinteger(msg,'shield', parentTable)
	self:parseinteger(msg,'attack', parentTable)
end

function NetProtocalPaser:parsept_gvg_init_battle(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'legion_id', parentTable)
	self:parsestring(msg,'legion_name', parentTable)
	self:parsepkid(msg,'guard_id', parentTable)
	self:parsestring(msg,'guard_name', parentTable)
	self:parsestring(msg,'guard_icon', parentTable)
	self:parseinteger(msg,'shield', parentTable)
	self:parseinteger(msg,'max_shield', parentTable)
	self:parseinteger(msg,'scores', parentTable)
	self:parseArray(msg,'mebs', parentTable,'pkid')
	self:parseinteger(msg,'end_time', parentTable)
end

function NetProtocalPaser:parsept_gvg_init_battle_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'attack_num', parentTable)
	self:parseshort(msg,'max_attack', parentTable)
	self:parsept_gvg_init_battle(msg,'self', parentTable)
	self:parsept_gvg_init_battle(msg,'enemy', parentTable)
end

function NetProtocalPaser:parsept_gvg_battle_end(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'result', parentTable)
	self:parseinteger(msg,'scores', parentTable)
	self:parseinteger(msg,'totle_scores', parentTable)
	self:parseinteger(msg,'less_scores', parentTable)
end

function NetProtocalPaser:parsept_gvg_fight(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'type', parentTable)
	self:parsepkid(msg,'target', parentTable)
end

function NetProtocalPaser:parsept_gvg_shield(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'user_id', parentTable)
	self:parsepkid(msg,'from_legion', parentTable)
	self:parsepkid(msg,'target_legion', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseinteger(msg,'change', parentTable)
	self:parseinteger(msg,'shield', parentTable)
end

function NetProtocalPaser:parsept_gvg_first(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'legion_id', parentTable)
	self:parseinteger(msg,'gvg_id', parentTable)
	self:parseshort(msg,'gvg_state', parentTable)
	self:parseinteger(msg,'scores', parentTable)
	self:parseinteger(msg,'shield', parentTable)
	self:parseinteger(msg,'extra_shield', parentTable)
	self:parseinteger(msg,'attack', parentTable)
	self:parseinteger(msg,'extra_attack', parentTable)
end

function NetProtocalPaser:parsept_gvg_star(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'gvg_id', parentTable)
	self:parseinteger(msg,'state', parentTable)
	self:parsepkid(msg,'legion_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseshort(msg,'flag', parentTable)
end

function NetProtocalPaser:parsept_gvg_star_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'pt_gvg_star')
end

function NetProtocalPaser:parsept_gvg_rank(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'legion_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseinteger(msg,'rank', parentTable)
	self:parseinteger(msg,'scores', parentTable)
end

function NetProtocalPaser:parsept_gvg_rank_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'less_scores', parentTable)
	self:parseArray(msg,'list', parentTable,'pt_gvg_rank')
end

function NetProtocalPaser:parsept_gvg_legion_log(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'enemy_id', parentTable)
	self:parseshort(msg,'result', parentTable)
	self:parseinteger(msg,'scores', parentTable)
	self:parseinteger(msg,'time', parentTable)
end

function NetProtocalPaser:parsept_gvg_legion_log_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'pt_gvg_legion_log')
end

function NetProtocalPaser:parsept_gvg_player_log(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'user_id', parentTable)
	self:parsestring(msg,'name', parentTable)
	self:parseshort(msg,'attack', parentTable)
	self:parseshort(msg,'win', parentTable)
	self:parseinteger(msg,'socres', parentTable)
end

function NetProtocalPaser:parsept_gvg_player_log_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'pt_gvg_player_log')
end

function NetProtocalPaser:parsept_gvg_login(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseinteger(msg,'gvg_id', parentTable)
end

function NetProtocalPaser:parsept_gvg_scores(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsepkid(msg,'legion_id', parentTable)
	self:parseinteger(msg,'scores', parentTable)
end

function NetProtocalPaser:formatpt_pkid(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
end

function NetProtocalPaser:formatpt_pkids(msg, content) 
	self:formatArray(msg,content.ids,'pkid')
end

function NetProtocalPaser:formatpt_int(msg, content) 
	if(content.i == nil) then print('formatNetMessage Error: i is nil' ) end 
	self:formatinteger(msg,content.i)
end

function NetProtocalPaser:formatpt_code(msg, content) 
	if(content.api == nil) then print('formatNetMessage Error: api is nil' ) end 
	self:formatinteger(msg,content.api)
	if(content.code == nil) then print('formatNetMessage Error: code is nil' ) end 
	self:formatinteger(msg,content.code)
end

function NetProtocalPaser:formatdb_single(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.gift_power_date == nil) then print('formatNetMessage Error: gift_power_date is nil' ) end 
	self:formatinteger(msg,content.gift_power_date)
end

function NetProtocalPaser:formatpt_ubase(msg, content) 
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.sex == nil) then print('formatNetMessage Error: sex is nil' ) end 
	self:formatshort(msg,content.sex)
	if(content.account_type == nil) then print('formatNetMessage Error: account_type is nil' ) end 
	self:formatshort(msg,content.account_type)
	if(content.account == nil) then print('formatNetMessage Error: account is nil' ) end 
	self:formatstring(msg,content.account)
	if(content.token == nil) then print('formatNetMessage Error: token is nil' ) end 
	self:formatstring(msg,content.token)
end

function NetProtocalPaser:formatdb_device(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.d_type == nil) then print('formatNetMessage Error: d_type is nil' ) end 
	self:formatstring(msg,content.d_type)
	if(content.udid == nil) then print('formatNetMessage Error: udid is nil' ) end 
	self:formatstring(msg,content.udid)
	if(content.os == nil) then print('formatNetMessage Error: os is nil' ) end 
	self:formatstring(msg,content.os)
	if(content.os_version == nil) then print('formatNetMessage Error: os_version is nil' ) end 
	self:formatstring(msg,content.os_version)
	if(content.market == nil) then print('formatNetMessage Error: market is nil' ) end 
	self:formatstring(msg,content.market)
	if(content.terminal == nil) then print('formatNetMessage Error: terminal is nil' ) end 
	self:formatstring(msg,content.terminal)
	if(content.lcl == nil) then print('formatNetMessage Error: lcl is nil' ) end 
	self:formatstring(msg,content.lcl)
	if(content.mac_addr == nil) then print('formatNetMessage Error: mac_addr is nil' ) end 
	self:formatstring(msg,content.mac_addr)
	if(content.locale == nil) then print('formatNetMessage Error: locale is nil' ) end 
	self:formatstring(msg,content.locale)
end

function NetProtocalPaser:formatdb_user(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.device_id == nil) then print('formatNetMessage Error: device_id is nil' ) end 
	self:formatpkid(msg,content.device_id)
	if(content.account_type == nil) then print('formatNetMessage Error: account_type is nil' ) end 
	self:formatshort(msg,content.account_type)
	if(content.account == nil) then print('formatNetMessage Error: account is nil' ) end 
	self:formatstring(msg,content.account)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.sex == nil) then print('formatNetMessage Error: sex is nil' ) end 
	self:formatshort(msg,content.sex)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
	if(content.power == nil) then print('formatNetMessage Error: power is nil' ) end 
	self:formatshort(msg,content.power)
	if(content.gift_power == nil) then print('formatNetMessage Error: gift_power is nil' ) end 
	self:formatshort(msg,content.gift_power)
	if(content.buy_power == nil) then print('formatNetMessage Error: buy_power is nil' ) end 
	self:formatinteger(msg,content.buy_power)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatinteger(msg,content.level)
	if(content.experience == nil) then print('formatNetMessage Error: experience is nil' ) end 
	self:formatpkid(msg,content.experience)
	if(content.money == nil) then print('formatNetMessage Error: money is nil' ) end 
	self:formatpkid(msg,content.money)
	if(content.group == nil) then print('formatNetMessage Error: group is nil' ) end 
	self:formatinteger(msg,content.group)
	if(content.story == nil) then print('formatNetMessage Error: story is nil' ) end 
	self:formatinteger(msg,content.story)
	if(content.gold == nil) then print('formatNetMessage Error: gold is nil' ) end 
	self:formatinteger(msg,content.gold)
	if(content.magic_card == nil) then print('formatNetMessage Error: magic_card is nil' ) end 
	self:formatinteger(msg,content.magic_card)
	if(content.powergift_num == nil) then print('formatNetMessage Error: powergift_num is nil' ) end 
	self:formatshort(msg,content.powergift_num)
	if(content.powergift_date == nil) then print('formatNetMessage Error: powergift_date is nil' ) end 
	self:formatinteger(msg,content.powergift_date)
	if(content.maxfevent == nil) then print('formatNetMessage Error: maxfevent is nil' ) end 
	self:formatinteger(msg,content.maxfevent)
end

function NetProtocalPaser:formatrc_buy_times(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatshort(msg,content.num)
end

function NetProtocalPaser:formatrc_buy_log(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	self:formatArray(msg,content.item,'rc_buy_times')
end

function NetProtocalPaser:formatflrfid(msg, content) 
	if(content.floor == nil) then print('formatNetMessage Error: floor is nil' ) end 
	self:formatshort(msg,content.floor)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
end

function NetProtocalPaser:formatmaze_fight(msg, content) 
	if(content.maze == nil) then print('formatNetMessage Error: maze is nil' ) end 
	self:formatshort(msg,content.maze)
	self:formatArray(msg,content.enemy,'flrfid')
	if(content.floor == nil) then print('formatNetMessage Error: floor is nil' ) end 
	self:formatshort(msg,content.floor)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	if(content.refush == nil) then print('formatNetMessage Error: refush is nil' ) end 
	self:formatinteger(msg,content.refush)
	if(content.step == nil) then print('formatNetMessage Error: step is nil' ) end 
	self:formatshort(msg,content.step)
	if(content.reset == nil) then print('formatNetMessage Error: reset is nil' ) end 
	self:formatinteger(msg,content.reset)
end

function NetProtocalPaser:formatrc_magic_scroll(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatshort(msg,content.num)
end

function NetProtocalPaser:formatdb_userinfo(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.frd_del_num == nil) then print('formatNetMessage Error: frd_del_num is nil' ) end 
	self:formatshort(msg,content.frd_del_num)
	if(content.frd_del_date == nil) then print('formatNetMessage Error: frd_del_date is nil' ) end 
	self:formatinteger(msg,content.frd_del_date)
	self:formatArray(msg,content.cards,'integer')
	self:formatArray(msg,content.runes,'integer')
	self:formatArray(msg,content.mazes,'maze_fight')
	if(content.star5 == nil) then print('formatNetMessage Error: star5 is nil' ) end 
	self:formatshort(msg,content.star5)
	self:formatArray(msg,content.buy_log,'rc_buy_log')
	if(content.buy_date == nil) then print('formatNetMessage Error: buy_date is nil' ) end 
	self:formatinteger(msg,content.buy_date)
	if(content.time_power_date == nil) then print('formatNetMessage Error: time_power_date is nil' ) end 
	self:formatinteger(msg,content.time_power_date)
	if(content.g_power_date == nil) then print('formatNetMessage Error: g_power_date is nil' ) end 
	self:formatinteger(msg,content.g_power_date)
	if(content.chp_times == nil) then print('formatNetMessage Error: chp_times is nil' ) end 
	self:formatinteger(msg,content.chp_times)
	if(content.chp_win == nil) then print('formatNetMessage Error: chp_win is nil' ) end 
	self:formatinteger(msg,content.chp_win)
	if(content.frd_times == nil) then print('formatNetMessage Error: frd_times is nil' ) end 
	self:formatinteger(msg,content.frd_times)
	if(content.frd_win == nil) then print('formatNetMessage Error: frd_win is nil' ) end 
	self:formatinteger(msg,content.frd_win)
	if(content.monster_add == nil) then print('formatNetMessage Error: monster_add is nil' ) end 
	self:formatshort(msg,content.monster_add)
	if(content.login_time == nil) then print('formatNetMessage Error: login_time is nil' ) end 
	self:formatinteger(msg,content.login_time)
	if(content.logout_time == nil) then print('formatNetMessage Error: logout_time is nil' ) end 
	self:formatinteger(msg,content.logout_time)
	if(content.create_at == nil) then print('formatNetMessage Error: create_at is nil' ) end 
	self:formatstring(msg,content.create_at)
	self:formatArray(msg,content.magic_scroll,'rc_magic_scroll')
	if(content.ban == nil) then print('formatNetMessage Error: ban is nil' ) end 
	self:formatinteger(msg,content.ban)
	if(content.mute == nil) then print('formatNetMessage Error: mute is nil' ) end 
	self:formatinteger(msg,content.mute)
	if(content.total_charge == nil) then print('formatNetMessage Error: total_charge is nil' ) end 
	self:formatinteger(msg,content.total_charge)
	if(content.lev_prize_date == nil) then print('formatNetMessage Error: lev_prize_date is nil' ) end 
	self:formatinteger(msg,content.lev_prize_date)
	if(content.change_name_num == nil) then print('formatNetMessage Error: change_name_num is nil' ) end 
	self:formatshort(msg,content.change_name_num)
	self:formatArray(msg,content.first_event,'short')
end

function NetProtocalPaser:formatpt_account(msg, content) 
	if(content.base == nil) then print('formatNetMessage Error: base is nil' ) end 
	self:formatpt_ubase(msg,content.base)
	if(content.device == nil) then print('formatNetMessage Error: device is nil' ) end 
	self:formatdb_device(msg,content.device)
	if(content.app_ver == nil) then print('formatNetMessage Error: app_ver is nil' ) end 
	self:formatinteger(msg,content.app_ver)
end

function NetProtocalPaser:formatdb_card(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.base_id == nil) then print('formatNetMessage Error: base_id is nil' ) end 
	self:formatinteger(msg,content.base_id)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatshort(msg,content.level)
	if(content.experience == nil) then print('formatNetMessage Error: experience is nil' ) end 
	self:formatinteger(msg,content.experience)
end

function NetProtocalPaser:formatdb_cards(msg, content) 
	self:formatArray(msg,content.cards,'db_card')
end

function NetProtocalPaser:formatgrune(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.baseid == nil) then print('formatNetMessage Error: baseid is nil' ) end 
	self:formatinteger(msg,content.baseid)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatinteger(msg,content.level)
end

function NetProtocalPaser:formatgcard(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.baseid == nil) then print('formatNetMessage Error: baseid is nil' ) end 
	self:formatinteger(msg,content.baseid)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatinteger(msg,content.level)
end

function NetProtocalPaser:formatdb_group(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	self:formatArray(msg,content.runes,'grune')
	self:formatArray(msg,content.cards,'gcard')
end

function NetProtocalPaser:formatdb_groups(msg, content) 
	self:formatArray(msg,content.groups,'db_group')
end

function NetProtocalPaser:formatpt_group_ac(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.card == nil) then print('formatNetMessage Error: card is nil' ) end 
	self:formatinteger(msg,content.card)
end

function NetProtocalPaser:formatpt_group_dc(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.card == nil) then print('formatNetMessage Error: card is nil' ) end 
	self:formatinteger(msg,content.card)
end

function NetProtocalPaser:formatdb_rune(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.base_id == nil) then print('formatNetMessage Error: base_id is nil' ) end 
	self:formatinteger(msg,content.base_id)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatinteger(msg,content.level)
	if(content.experience == nil) then print('formatNetMessage Error: experience is nil' ) end 
	self:formatinteger(msg,content.experience)
end

function NetProtocalPaser:formatdb_runes(msg, content) 
	self:formatArray(msg,content.runes,'db_rune')
end

function NetProtocalPaser:formatpt_group_ar(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.rune == nil) then print('formatNetMessage Error: rune is nil' ) end 
	self:formatinteger(msg,content.rune)
end

function NetProtocalPaser:formatpt_group_dr(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.rune == nil) then print('formatNetMessage Error: rune is nil' ) end 
	self:formatinteger(msg,content.rune)
end

function NetProtocalPaser:formatdb_story(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.base_id == nil) then print('formatNetMessage Error: base_id is nil' ) end 
	self:formatinteger(msg,content.base_id)
	if(content.finish == nil) then print('formatNetMessage Error: finish is nil' ) end 
	self:formatinteger(msg,content.finish)
end

function NetProtocalPaser:formatdb_storys(msg, content) 
	self:formatArray(msg,content.storys,'db_story')
end

function NetProtocalPaser:formatpk_fcard_base(msg, content) 
	if(content.baseId == nil) then print('formatNetMessage Error: baseId is nil' ) end 
	self:formatinteger(msg,content.baseId)
	if(content.hp == nil) then print('formatNetMessage Error: hp is nil' ) end 
	self:formatinteger(msg,content.hp)
	if(content.ad == nil) then print('formatNetMessage Error: ad is nil' ) end 
	self:formatinteger(msg,content.ad)
	if(content.limit == nil) then print('formatNetMessage Error: limit is nil' ) end 
	self:formatshort(msg,content.limit)
	if(content.cost == nil) then print('formatNetMessage Error: cost is nil' ) end 
	self:formatshort(msg,content.cost)
end

function NetProtocalPaser:formatpk_fcard_fight(msg, content) 
	if(content.nowlevel == nil) then print('formatNetMessage Error: nowlevel is nil' ) end 
	self:formatshort(msg,content.nowlevel)
	if(content.nowhp == nil) then print('formatNetMessage Error: nowhp is nil' ) end 
	self:formatinteger(msg,content.nowhp)
	if(content.nowat == nil) then print('formatNetMessage Error: nowat is nil' ) end 
	self:formatinteger(msg,content.nowat)
	if(content.nowdef == nil) then print('formatNetMessage Error: nowdef is nil' ) end 
	self:formatshort(msg,content.nowdef)
	if(content.nowmis == nil) then print('formatNetMessage Error: nowmis is nil' ) end 
	self:formatshort(msg,content.nowmis)
end

function NetProtocalPaser:formatpk_fcard_temp(msg, content) 
	if(content.tmphp == nil) then print('formatNetMessage Error: tmphp is nil' ) end 
	self:formatinteger(msg,content.tmphp)
	if(content.tmpat == nil) then print('formatNetMessage Error: tmpat is nil' ) end 
	self:formatinteger(msg,content.tmpat)
	if(content.tmpap == nil) then print('formatNetMessage Error: tmpap is nil' ) end 
	self:formatinteger(msg,content.tmpap)
	if(content.tmpdef == nil) then print('formatNetMessage Error: tmpdef is nil' ) end 
	self:formatshort(msg,content.tmpdef)
	if(content.tmpres == nil) then print('formatNetMessage Error: tmpres is nil' ) end 
	self:formatshort(msg,content.tmpres)
	if(content.tmpmis == nil) then print('formatNetMessage Error: tmpmis is nil' ) end 
	self:formatshort(msg,content.tmpmis)
end

function NetProtocalPaser:formatpk_buff(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.value == nil) then print('formatNetMessage Error: value is nil' ) end 
	self:formatshort(msg,content.value)
	if(content.number == nil) then print('formatNetMessage Error: number is nil' ) end 
	self:formatshort(msg,content.number)
end

function NetProtocalPaser:formatpk_apply(msg, content) 
	if(content.atk == nil) then print('formatNetMessage Error: atk is nil' ) end 
	self:formatshort(msg,content.atk)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.def == nil) then print('formatNetMessage Error: def is nil' ) end 
	self:formatshort(msg,content.def)
	if(content.value == nil) then print('formatNetMessage Error: value is nil' ) end 
	self:formatshort(msg,content.value)
end

function NetProtocalPaser:formatpk_fcard(msg, content) 
	if(content.idx == nil) then print('formatNetMessage Error: idx is nil' ) end 
	self:formatshort(msg,content.idx)
	if(content.fcardbase == nil) then print('formatNetMessage Error: fcardbase is nil' ) end 
	self:formatpk_fcard_base(msg,content.fcardbase)
	if(content.fcardfight == nil) then print('formatNetMessage Error: fcardfight is nil' ) end 
	self:formatpk_fcard_fight(msg,content.fcardfight)
end

function NetProtocalPaser:formatpk_frune(msg, content) 
	if(content.idx == nil) then print('formatNetMessage Error: idx is nil' ) end 
	self:formatshort(msg,content.idx)
	if(content.baseid == nil) then print('formatNetMessage Error: baseid is nil' ) end 
	self:formatinteger(msg,content.baseid)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatshort(msg,content.level)
	if(content.timer == nil) then print('formatNetMessage Error: timer is nil' ) end 
	self:formatshort(msg,content.timer)
end

function NetProtocalPaser:formatpk_fight_group(msg, content) 
	if(content.hero == nil) then print('formatNetMessage Error: hero is nil' ) end 
	self:formatinteger(msg,content.hero)
	self:formatArray(msg,content.rune,'pk_frune')
	self:formatArray(msg,content.home,'pk_fcard')
	self:formatArray(msg,content.waiting,'pk_fcard')
	self:formatArray(msg,content.fighting,'pk_fcard')
	self:formatArray(msg,content.dead,'pk_fcard')
end

function NetProtocalPaser:formatpk_area_log(msg, content) 
	self:formatArray(msg,content.hom,'short')
	self:formatArray(msg,content.wit,'short')
	self:formatArray(msg,content.fig,'short')
	self:formatArray(msg,content.dea,'short')
end

function NetProtocalPaser:formatpk_cres(msg, content) 
	if(content.hp == nil) then print('formatNetMessage Error: hp is nil' ) end 
	self:formatinteger(msg,content.hp)
	if(content.at == nil) then print('formatNetMessage Error: at is nil' ) end 
	self:formatinteger(msg,content.at)
	if(content.def == nil) then print('formatNetMessage Error: def is nil' ) end 
	self:formatshort(msg,content.def)
	if(content.mis == nil) then print('formatNetMessage Error: mis is nil' ) end 
	self:formatshort(msg,content.mis)
end

function NetProtocalPaser:formatpk_move(msg, content) 
	if(content.idx == nil) then print('formatNetMessage Error: idx is nil' ) end 
	self:formatinteger(msg,content.idx)
	if(content.from == nil) then print('formatNetMessage Error: from is nil' ) end 
	self:formatshort(msg,content.from)
	if(content.to == nil) then print('formatNetMessage Error: to is nil' ) end 
	self:formatshort(msg,content.to)
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
end

function NetProtocalPaser:formatpk_flog(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.times == nil) then print('formatNetMessage Error: times is nil' ) end 
	self:formatshort(msg,content.times)
	if(content.attacker == nil) then print('formatNetMessage Error: attacker is nil' ) end 
	self:formatshort(msg,content.attacker)
	if(content.defender == nil) then print('formatNetMessage Error: defender is nil' ) end 
	self:formatshort(msg,content.defender)
	if(content.skillid == nil) then print('formatNetMessage Error: skillid is nil' ) end 
	self:formatinteger(msg,content.skillid)
	if(content.target == nil) then print('formatNetMessage Error: target is nil' ) end 
	self:formatshort(msg,content.target)
	if(content.hero_damage == nil) then print('formatNetMessage Error: hero_damage is nil' ) end 
	self:formatinteger(msg,content.hero_damage)
	if(content.hero_check == nil) then print('formatNetMessage Error: hero_check is nil' ) end 
	self:formatinteger(msg,content.hero_check)
	if(content.cardfres == nil) then print('formatNetMessage Error: cardfres is nil' ) end 
	self:formatpk_cres(msg,content.cardfres)
	if(content.cardfdata == nil) then print('formatNetMessage Error: cardfdata is nil' ) end 
	self:formatpk_cres(msg,content.cardfdata)
	self:formatArray(msg,content.cardfstate,'short')
	self:formatArray(msg,content.cardfbuff,'pk_buff')
	self:formatArray(msg,content.atkdesc,'pk_apply')
	self:formatArray(msg,content.defdesc,'pk_apply')
	if(content.cardftemp == nil) then print('formatNetMessage Error: cardftemp is nil' ) end 
	self:formatpk_cres(msg,content.cardftemp)
	self:formatArray(msg,content.area,'pk_move')
	if(content.attkerfdata == nil) then print('formatNetMessage Error: attkerfdata is nil' ) end 
	self:formatpk_cres(msg,content.attkerfdata)
end

function NetProtocalPaser:formatpk_clog(msg, content) 
	if(content.a_pos == nil) then print('formatNetMessage Error: a_pos is nil' ) end 
	self:formatstring(msg,content.a_pos)
	if(content.b_pos == nil) then print('formatNetMessage Error: b_pos is nil' ) end 
	self:formatstring(msg,content.b_pos)
end

function NetProtocalPaser:formatpk_round(msg, content) 
	if(content.opts == nil) then print('formatNetMessage Error: opts is nil' ) end 
	self:formatshort(msg,content.opts)
	if(content.content == nil) then print('formatNetMessage Error: content is nil' ) end 
	self:formatstring(msg,content.content)
end

function NetProtocalPaser:formatpk_fight_log(msg, content) 
	self:formatArray(msg,content.areaLogCho,'pk_move')
	self:formatArray(msg,content.areaLogSen,'pk_move')
	self:formatArray(msg,content.fistShowLog,'pk_flog')
	self:formatArray(msg,content.areaLogSho,'pk_move')
	self:formatArray(msg,content.runeLog,'pk_flog')
	self:formatArray(msg,content.areaLogRun,'pk_move')
	self:formatArray(msg,content.commonShowLog,'pk_flog')
	self:formatArray(msg,content.areaLogCom,'pk_move')
end

function NetProtocalPaser:formatpk_record(msg, content) 
	if(content.round == nil) then print('formatNetMessage Error: round is nil' ) end 
	self:formatshort(msg,content.round)
	if(content.isend == nil) then print('formatNetMessage Error: isend is nil' ) end 
	self:formatshort(msg,content.isend)
	if(content.fightlog == nil) then print('formatNetMessage Error: fightlog is nil' ) end 
	self:formatpk_fight_log(msg,content.fightlog)
end

function NetProtocalPaser:formatpk_ready(msg, content) 
	if(content.first == nil) then print('formatNetMessage Error: first is nil' ) end 
	self:formatshort(msg,content.first)
	if(content.attacker == nil) then print('formatNetMessage Error: attacker is nil' ) end 
	self:formatpk_fight_group(msg,content.attacker)
	if(content.defender == nil) then print('formatNetMessage Error: defender is nil' ) end 
	self:formatpk_fight_group(msg,content.defender)
end

function NetProtocalPaser:formatpk_fight_data_result(msg, content) 
	if(content.result == nil) then print('formatNetMessage Error: result is nil' ) end 
	self:formatshort(msg,content.result)
	if(content.totle == nil) then print('formatNetMessage Error: totle is nil' ) end 
	self:formatshort(msg,content.totle)
	if(content.ready == nil) then print('formatNetMessage Error: ready is nil' ) end 
	self:formatpk_ready(msg,content.ready)
	self:formatArray(msg,content.recordlist,'pk_record')
end

function NetProtocalPaser:formatdb_fightlog(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.log == nil) then print('formatNetMessage Error: log is nil' ) end 
	self:formatpk_fight_data_result(msg,content.log)
end

function NetProtocalPaser:formatdb_storylog(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatinteger(msg,content.user_id)
	if(content.fighter == nil) then print('formatNetMessage Error: fighter is nil' ) end 
	self:formatpkid(msg,content.fighter)
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
	if(content.log == nil) then print('formatNetMessage Error: log is nil' ) end 
	self:formatpkid(msg,content.log)
end

function NetProtocalPaser:formatdb_pvplog(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.enemy == nil) then print('formatNetMessage Error: enemy is nil' ) end 
	self:formatpkid(msg,content.enemy)
	if(content.result == nil) then print('formatNetMessage Error: result is nil' ) end 
	self:formatshort(msg,content.result)
	if(content.value == nil) then print('formatNetMessage Error: value is nil' ) end 
	self:formatshort(msg,content.value)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
	if(content.log == nil) then print('formatNetMessage Error: log is nil' ) end 
	self:formatpkid(msg,content.log)
end

function NetProtocalPaser:formatpt_pvelog(msg, content) 
	if(content.logid == nil) then print('formatNetMessage Error: logid is nil' ) end 
	self:formatpkid(msg,content.logid)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
	if(content.lev == nil) then print('formatNetMessage Error: lev is nil' ) end 
	self:formatinteger(msg,content.lev)
end

function NetProtocalPaser:formatpt_pvelog_list(msg, content) 
	if(content.story == nil) then print('formatNetMessage Error: story is nil' ) end 
	self:formatinteger(msg,content.story)
	self:formatArray(msg,content.log,'pt_pvelog')
end

function NetProtocalPaser:formatpt_pvplog(msg, content) 
	if(content.logid == nil) then print('formatNetMessage Error: logid is nil' ) end 
	self:formatpkid(msg,content.logid)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.enemy == nil) then print('formatNetMessage Error: enemy is nil' ) end 
	self:formatpkid(msg,content.enemy)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
	if(content.lev == nil) then print('formatNetMessage Error: lev is nil' ) end 
	self:formatinteger(msg,content.lev)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatinteger(msg,content.score)
	if(content.len_id == nil) then print('formatNetMessage Error: len_id is nil' ) end 
	self:formatpkid(msg,content.len_id)
	if(content.len_flag == nil) then print('formatNetMessage Error: len_flag is nil' ) end 
	self:formatshort(msg,content.len_flag)
	if(content.len_name == nil) then print('formatNetMessage Error: len_name is nil' ) end 
	self:formatstring(msg,content.len_name)
	if(content.result == nil) then print('formatNetMessage Error: result is nil' ) end 
	self:formatshort(msg,content.result)
	if(content.value == nil) then print('formatNetMessage Error: value is nil' ) end 
	self:formatshort(msg,content.value)
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
end

function NetProtocalPaser:formatpt_pvplog_list(msg, content) 
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatinteger(msg,content.score)
	self:formatArray(msg,content.log,'pt_pvplog')
end

function NetProtocalPaser:formatpt_chat2server(msg, content) 
	if(content.channel == nil) then print('formatNetMessage Error: channel is nil' ) end 
	self:formatinteger(msg,content.channel)
	if(content.receiveid == nil) then print('formatNetMessage Error: receiveid is nil' ) end 
	self:formatpkid(msg,content.receiveid)
	if(content.content == nil) then print('formatNetMessage Error: content is nil' ) end 
	self:formatstring(msg,content.content)
end

function NetProtocalPaser:formatpt_chat2player(msg, content) 
	if(content.channel == nil) then print('formatNetMessage Error: channel is nil' ) end 
	self:formatinteger(msg,content.channel)
	if(content.sendid == nil) then print('formatNetMessage Error: sendid is nil' ) end 
	self:formatpkid(msg,content.sendid)
	if(content.sendname == nil) then print('formatNetMessage Error: sendname is nil' ) end 
	self:formatstring(msg,content.sendname)
	if(content.sendlevel == nil) then print('formatNetMessage Error: sendlevel is nil' ) end 
	self:formatinteger(msg,content.sendlevel)
	if(content.sendicon == nil) then print('formatNetMessage Error: sendicon is nil' ) end 
	self:formatstring(msg,content.sendicon)
	if(content.sendlen_id == nil) then print('formatNetMessage Error: sendlen_id is nil' ) end 
	self:formatpkid(msg,content.sendlen_id)
	if(content.sendlen_flag == nil) then print('formatNetMessage Error: sendlen_flag is nil' ) end 
	self:formatshort(msg,content.sendlen_flag)
	if(content.sendlen_pos == nil) then print('formatNetMessage Error: sendlen_pos is nil' ) end 
	self:formatshort(msg,content.sendlen_pos)
	if(content.receiveid == nil) then print('formatNetMessage Error: receiveid is nil' ) end 
	self:formatpkid(msg,content.receiveid)
	if(content.receivename == nil) then print('formatNetMessage Error: receivename is nil' ) end 
	self:formatstring(msg,content.receivename)
	if(content.content == nil) then print('formatNetMessage Error: content is nil' ) end 
	self:formatstring(msg,content.content)
end

function NetProtocalPaser:formatpt_crdlist(msg, content) 
	self:formatArray(msg,content.crdlist,'integer')
end

function NetProtocalPaser:formatdb_friend(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.frd_id == nil) then print('formatNetMessage Error: frd_id is nil' ) end 
	self:formatpkid(msg,content.frd_id)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
end

function NetProtocalPaser:formatdb_friends(msg, content) 
	self:formatArray(msg,content.friends,'db_friend')
end

function NetProtocalPaser:formatdb_powergift(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.other_id == nil) then print('formatNetMessage Error: other_id is nil' ) end 
	self:formatpkid(msg,content.other_id)
	if(content.self_flag == nil) then print('formatNetMessage Error: self_flag is nil' ) end 
	self:formatshort(msg,content.self_flag)
	if(content.self_date == nil) then print('formatNetMessage Error: self_date is nil' ) end 
	self:formatinteger(msg,content.self_date)
	if(content.other_flag == nil) then print('formatNetMessage Error: other_flag is nil' ) end 
	self:formatshort(msg,content.other_flag)
	if(content.other_date == nil) then print('formatNetMessage Error: other_date is nil' ) end 
	self:formatinteger(msg,content.other_date)
end

function NetProtocalPaser:formatdb_powergifts(msg, content) 
	self:formatArray(msg,content.gifts,'db_powergift')
end

function NetProtocalPaser:formatpt_frd_info(msg, content) 
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.sex == nil) then print('formatNetMessage Error: sex is nil' ) end 
	self:formatshort(msg,content.sex)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatinteger(msg,content.level)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
end

function NetProtocalPaser:formatpt_frd_list(msg, content) 
	self:formatArray(msg,content.frd_list,'pt_frd_info')
end

function NetProtocalPaser:formatpt_frd_init(msg, content) 
	self:formatArray(msg,content.frd_list,'pt_frd_info')
end

function NetProtocalPaser:formatpt_frd_agree(msg, content) 
	if(content.friend_id == nil) then print('formatNetMessage Error: friend_id is nil' ) end 
	self:formatpkid(msg,content.friend_id)
	if(content.agree == nil) then print('formatNetMessage Error: agree is nil' ) end 
	self:formatboolean(msg,content.agree)
end

function NetProtocalPaser:formatpt_enemy(msg, content) 
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.sex == nil) then print('formatNetMessage Error: sex is nil' ) end 
	self:formatshort(msg,content.sex)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatshort(msg,content.level)
	if(content.win == nil) then print('formatNetMessage Error: win is nil' ) end 
	self:formatinteger(msg,content.win)
	if(content.lose == nil) then print('formatNetMessage Error: lose is nil' ) end 
	self:formatinteger(msg,content.lose)
	if(content.getpic == nil) then print('formatNetMessage Error: getpic is nil' ) end 
	self:formatshort(msg,content.getpic)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
end

function NetProtocalPaser:formatpt_all_enemy(msg, content) 
	self:formatArray(msg,content.enemy,'pt_enemy')
end

function NetProtocalPaser:formatdb_grade(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.cfg_id == nil) then print('formatNetMessage Error: cfg_id is nil' ) end 
	self:formatinteger(msg,content.cfg_id)
	if(content.finish_date == nil) then print('formatNetMessage Error: finish_date is nil' ) end 
	self:formatinteger(msg,content.finish_date)
	if(content.finish == nil) then print('formatNetMessage Error: finish is nil' ) end 
	self:formatshort(msg,content.finish)
	if(content.gain == nil) then print('formatNetMessage Error: gain is nil' ) end 
	self:formatshort(msg,content.gain)
end

function NetProtocalPaser:formatdb_gradeevent(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.event == nil) then print('formatNetMessage Error: event is nil' ) end 
	self:formatstring(msg,content.event)
	if(content.condition == nil) then print('formatNetMessage Error: condition is nil' ) end 
	self:formatstring(msg,content.condition)
end

function NetProtocalPaser:formatpt_grade_test(msg, content) 
	if(content.event == nil) then print('formatNetMessage Error: event is nil' ) end 
	self:formatstring(msg,content.event)
	if(content.condition == nil) then print('formatNetMessage Error: condition is nil' ) end 
	self:formatstring(msg,content.condition)
end

function NetProtocalPaser:formatpt_grade_info(msg, content) 
	if(content.cfg_id == nil) then print('formatNetMessage Error: cfg_id is nil' ) end 
	self:formatinteger(msg,content.cfg_id)
	if(content.finish == nil) then print('formatNetMessage Error: finish is nil' ) end 
	self:formatshort(msg,content.finish)
	if(content.gain == nil) then print('formatNetMessage Error: gain is nil' ) end 
	self:formatshort(msg,content.gain)
	if(content.event == nil) then print('formatNetMessage Error: event is nil' ) end 
	self:formatstring(msg,content.event)
end

function NetProtocalPaser:formatpt_grade_info_list(msg, content) 
	self:formatArray(msg,content.info,'pt_grade_info')
end

function NetProtocalPaser:formatpt_card_enhance(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	self:formatArray(msg,content.food,'integer')
end

function NetProtocalPaser:formatpt_rune_enhance(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	self:formatArray(msg,content.food,'integer')
end

function NetProtocalPaser:formatrc_chest(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatinteger(msg,content.num)
end

function NetProtocalPaser:formatdb_chest(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.source == nil) then print('formatNetMessage Error: source is nil' ) end 
	self:formatshort(msg,content.source)
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
	self:formatArray(msg,content.reward,'rc_chest')
end

function NetProtocalPaser:formatdb_chests(msg, content) 
	self:formatArray(msg,content.chests,'db_chest')
end

function NetProtocalPaser:formatpt_prize_test(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatinteger(msg,content.type)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatinteger(msg,content.num)
end

function NetProtocalPaser:formatrc_temple_site(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
end

function NetProtocalPaser:formatrc_temple_fragment(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatinteger(msg,content.num)
end

function NetProtocalPaser:formatdb_temple(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.grade == nil) then print('formatNetMessage Error: grade is nil' ) end 
	self:formatshort(msg,content.grade)
	self:formatArray(msg,content.fragment_amount,'rc_temple_fragment')
	self:formatArray(msg,content.site_goodtype,'rc_temple_site')
end

function NetProtocalPaser:formatpt_temple_datas(msg, content) 
	if(content.grade == nil) then print('formatNetMessage Error: grade is nil' ) end 
	self:formatinteger(msg,content.grade)
	self:formatArray(msg,content.fragments,'rc_temple_fragment')
	self:formatArray(msg,content.sites,'rc_temple_site')
end

function NetProtocalPaser:formatpt_mapinfo(msg, content) 
	if(content.mapid == nil) then print('formatNetMessage Error: mapid is nil' ) end 
	self:formatinteger(msg,content.mapid)
	self:formatArray(msg,content.storyid,'integer')
	self:formatArray(msg,content.invade,'integer')
end

function NetProtocalPaser:formatpt_nadainfo(msg, content) 
	self:formatArray(msg,content.nadaid,'integer')
end

function NetProtocalPaser:formatdb_legion(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.remark == nil) then print('formatNetMessage Error: remark is nil' ) end 
	self:formatstring(msg,content.remark)
	if(content.flag == nil) then print('formatNetMessage Error: flag is nil' ) end 
	self:formatshort(msg,content.flag)
	if(content.lock == nil) then print('formatNetMessage Error: lock is nil' ) end 
	self:formatshort(msg,content.lock)
	if(content.lev == nil) then print('formatNetMessage Error: lev is nil' ) end 
	self:formatshort(msg,content.lev)
	if(content.exp == nil) then print('formatNetMessage Error: exp is nil' ) end 
	self:formatinteger(msg,content.exp)
	if(content.guard == nil) then print('formatNetMessage Error: guard is nil' ) end 
	self:formatpkid(msg,content.guard)
	if(content.del_num == nil) then print('formatNetMessage Error: del_num is nil' ) end 
	self:formatshort(msg,content.del_num)
	if(content.del_time == nil) then print('formatNetMessage Error: del_time is nil' ) end 
	self:formatinteger(msg,content.del_time)
end

function NetProtocalPaser:formatdb_lenmeb(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.player_id == nil) then print('formatNetMessage Error: player_id is nil' ) end 
	self:formatpkid(msg,content.player_id)
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
	if(content.devote == nil) then print('formatNetMessage Error: devote is nil' ) end 
	self:formatinteger(msg,content.devote)
	if(content.join_time == nil) then print('formatNetMessage Error: join_time is nil' ) end 
	self:formatinteger(msg,content.join_time)
	if(content.doe_money == nil) then print('formatNetMessage Error: doe_money is nil' ) end 
	self:formatinteger(msg,content.doe_money)
	if(content.doe_gold == nil) then print('formatNetMessage Error: doe_gold is nil' ) end 
	self:formatinteger(msg,content.doe_gold)
	if(content.doe_date == nil) then print('formatNetMessage Error: doe_date is nil' ) end 
	self:formatinteger(msg,content.doe_date)
end

function NetProtocalPaser:formatdb_lenapply(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.player_id == nil) then print('formatNetMessage Error: player_id is nil' ) end 
	self:formatpkid(msg,content.player_id)
	if(content.apply == nil) then print('formatNetMessage Error: apply is nil' ) end 
	self:formatshort(msg,content.apply)
	if(content.invite == nil) then print('formatNetMessage Error: invite is nil' ) end 
	self:formatshort(msg,content.invite)
end

function NetProtocalPaser:formatpt_len_info(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.remark == nil) then print('formatNetMessage Error: remark is nil' ) end 
	self:formatstring(msg,content.remark)
	if(content.exp == nil) then print('formatNetMessage Error: exp is nil' ) end 
	self:formatinteger(msg,content.exp)
	if(content.lev == nil) then print('formatNetMessage Error: lev is nil' ) end 
	self:formatshort(msg,content.lev)
	if(content.flag == nil) then print('formatNetMessage Error: flag is nil' ) end 
	self:formatshort(msg,content.flag)
	if(content.lock == nil) then print('formatNetMessage Error: lock is nil' ) end 
	self:formatshort(msg,content.lock)
	if(content.meb == nil) then print('formatNetMessage Error: meb is nil' ) end 
	self:formatshort(msg,content.meb)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatinteger(msg,content.score)
end

function NetProtocalPaser:formatpt_len_list(msg, content) 
	self:formatArray(msg,content.list,'pt_len_info')
end

function NetProtocalPaser:formatpt_lenmeb_info(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.lev == nil) then print('formatNetMessage Error: lev is nil' ) end 
	self:formatinteger(msg,content.lev)
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
	if(content.devote == nil) then print('formatNetMessage Error: devote is nil' ) end 
	self:formatinteger(msg,content.devote)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatinteger(msg,content.score)
end

function NetProtocalPaser:formatpt_lenmeb_list(msg, content) 
	self:formatArray(msg,content.list,'pt_lenmeb_info')
end

function NetProtocalPaser:formatpt_len_all_info(msg, content) 
	if(content.legion == nil) then print('formatNetMessage Error: legion is nil' ) end 
	self:formatpt_len_info(msg,content.legion)
	self:formatArray(msg,content.meb,'pt_lenmeb_info')
end

function NetProtocalPaser:formatpt_len_create(msg, content) 
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
end

function NetProtocalPaser:formatpt_len_apply(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
	if(content.lev == nil) then print('formatNetMessage Error: lev is nil' ) end 
	self:formatinteger(msg,content.lev)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatinteger(msg,content.score)
end

function NetProtocalPaser:formatpt_len_apply_list(msg, content) 
	self:formatArray(msg,content.list,'pt_len_apply')
end

function NetProtocalPaser:formatpt_len_apply_opr(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.agree == nil) then print('formatNetMessage Error: agree is nil' ) end 
	self:formatboolean(msg,content.agree)
end

function NetProtocalPaser:formatpt_len_devote(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatinteger(msg,content.num)
end

function NetProtocalPaser:formatpt_create_legion(msg, content) 
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.remark == nil) then print('formatNetMessage Error: remark is nil' ) end 
	self:formatstring(msg,content.remark)
	if(content.flag == nil) then print('formatNetMessage Error: flag is nil' ) end 
	self:formatshort(msg,content.flag)
	if(content.lock == nil) then print('formatNetMessage Error: lock is nil' ) end 
	self:formatshort(msg,content.lock)
end

function NetProtocalPaser:formatpt_legion_self(msg, content) 
	if(content.legion_id == nil) then print('formatNetMessage Error: legion_id is nil' ) end 
	self:formatpkid(msg,content.legion_id)
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
end

function NetProtocalPaser:formatpt_groupupd_rune(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	self:formatArray(msg,content.runelist,'integer')
end

function NetProtocalPaser:formatpt_groupupd_card(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	self:formatArray(msg,content.cardlist,'integer')
end

function NetProtocalPaser:formatpt_prize_get(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.prize == nil) then print('formatNetMessage Error: prize is nil' ) end 
	self:formatstring(msg,content.prize)
end

function NetProtocalPaser:formatpt_player_report(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatstring(msg,content.type)
	if(content.desc == nil) then print('formatNetMessage Error: desc is nil' ) end 
	self:formatstring(msg,content.desc)
end

function NetProtocalPaser:formatpt_rune_once(msg, content) 
	if(content.runes == nil) then print('formatNetMessage Error: runes is nil' ) end 
	self:formatstring(msg,content.runes)
end

function NetProtocalPaser:formatpt_maze(msg, content) 
	if(content.maze == nil) then print('formatNetMessage Error: maze is nil' ) end 
	self:formatinteger(msg,content.maze)
	self:formatArray(msg,content.enemy,'flrfid')
	if(content.floor == nil) then print('formatNetMessage Error: floor is nil' ) end 
	self:formatshort(msg,content.floor)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	if(content.refush == nil) then print('formatNetMessage Error: refush is nil' ) end 
	self:formatinteger(msg,content.refush)
	if(content.step == nil) then print('formatNetMessage Error: step is nil' ) end 
	self:formatshort(msg,content.step)
	if(content.reset == nil) then print('formatNetMessage Error: reset is nil' ) end 
	self:formatinteger(msg,content.reset)
end

function NetProtocalPaser:formatpt_maze_all(msg, content) 
	self:formatArray(msg,content.maze,'pt_maze')
end

function NetProtocalPaser:formatpt_market_item(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	if(content.cost == nil) then print('formatNetMessage Error: cost is nil' ) end 
	self:formatinteger(msg,content.cost)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatinteger(msg,content.num)
end

function NetProtocalPaser:formatpt_market(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatinteger(msg,content.type)
	self:formatArray(msg,content.item,'pt_market_item')
end

function NetProtocalPaser:formatpt_market_buy(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatinteger(msg,content.type)
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	if(content.flag == nil) then print('formatNetMessage Error: flag is nil' ) end 
	self:formatboolean(msg,content.flag)
end

function NetProtocalPaser:formatpt_market_card(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatinteger(msg,content.type)
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	self:formatArray(msg,content.item,'pt_market_item')
	self:formatArray(msg,content.cards,'pkid')
end

function NetProtocalPaser:formatpt_market_gold(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatinteger(msg,content.type)
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	self:formatArray(msg,content.item,'pt_market_item')
	if(content.gold == nil) then print('formatNetMessage Error: gold is nil' ) end 
	self:formatinteger(msg,content.gold)
end

function NetProtocalPaser:formatpt_market_power(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatinteger(msg,content.type)
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	self:formatArray(msg,content.item,'pt_market_item')
	if(content.power == nil) then print('formatNetMessage Error: power is nil' ) end 
	self:formatinteger(msg,content.power)
end

function NetProtocalPaser:formatpt_ranks_get(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatinteger(msg,content.type)
end

function NetProtocalPaser:formatpt_ranks_info(msg, content) 
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
	if(content.lev == nil) then print('formatNetMessage Error: lev is nil' ) end 
	self:formatinteger(msg,content.lev)
	if(content.value == nil) then print('formatNetMessage Error: value is nil' ) end 
	self:formatinteger(msg,content.value)
end

function NetProtocalPaser:formatpt_ranks_list(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatinteger(msg,content.id)
	if(content.self == nil) then print('formatNetMessage Error: self is nil' ) end 
	self:formatpt_ranks_info(msg,content.self)
	self:formatArray(msg,content.info,'pt_ranks_info')
end

function NetProtocalPaser:formatpt_story_hide(msg, content) 
	if(content.info == nil) then print('formatNetMessage Error: info is nil' ) end 
	self:formatstring(msg,content.info)
end

function NetProtocalPaser:formatpt_gmcmd(msg, content) 
	if(content.cmd == nil) then print('formatNetMessage Error: cmd is nil' ) end 
	self:formatstring(msg,content.cmd)
end

function NetProtocalPaser:formatdb_mapreward(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.map_id == nil) then print('formatNetMessage Error: map_id is nil' ) end 
	self:formatinteger(msg,content.map_id)
	self:formatArray(msg,content.invade,'integer')
	if(content.invade_time == nil) then print('formatNetMessage Error: invade_time is nil' ) end 
	self:formatinteger(msg,content.invade_time)
	if(content.gain_time == nil) then print('formatNetMessage Error: gain_time is nil' ) end 
	self:formatinteger(msg,content.gain_time)
	if(content.gain_num == nil) then print('formatNetMessage Error: gain_num is nil' ) end 
	self:formatshort(msg,content.gain_num)
end

function NetProtocalPaser:formatpt_map_gain(msg, content) 
	if(content.map == nil) then print('formatNetMessage Error: map is nil' ) end 
	self:formatinteger(msg,content.map)
	if(content.money == nil) then print('formatNetMessage Error: money is nil' ) end 
	self:formatinteger(msg,content.money)
end

function NetProtocalPaser:formatpt_map_info(msg, content) 
	if(content.date == nil) then print('formatNetMessage Error: date is nil' ) end 
	self:formatinteger(msg,content.date)
	self:formatArray(msg,content.story,'integer')
	if(content.gain == nil) then print('formatNetMessage Error: gain is nil' ) end 
	self:formatinteger(msg,content.gain)
	self:formatArray(msg,content.maze,'pt_maze')
	self:formatArray(msg,content.invade,'integer')
end

function NetProtocalPaser:formatpt_map_friend(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.story == nil) then print('formatNetMessage Error: story is nil' ) end 
	self:formatinteger(msg,content.story)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
end

function NetProtocalPaser:formatpt_map_friend_list(msg, content) 
	self:formatArray(msg,content.list,'pt_map_friend')
end

function NetProtocalPaser:formatdb_coldtime(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.chp_times == nil) then print('formatNetMessage Error: chp_times is nil' ) end 
	self:formatshort(msg,content.chp_times)
	if(content.chp_gold == nil) then print('formatNetMessage Error: chp_gold is nil' ) end 
	self:formatshort(msg,content.chp_gold)
	if(content.champion == nil) then print('formatNetMessage Error: champion is nil' ) end 
	self:formatinteger(msg,content.champion)
	if(content.freedom == nil) then print('formatNetMessage Error: freedom is nil' ) end 
	self:formatinteger(msg,content.freedom)
	if(content.monster == nil) then print('formatNetMessage Error: monster is nil' ) end 
	self:formatinteger(msg,content.monster)
	if(content.crazy == nil) then print('formatNetMessage Error: crazy is nil' ) end 
	self:formatinteger(msg,content.crazy)
	if(content.lrank == nil) then print('formatNetMessage Error: lrank is nil' ) end 
	self:formatinteger(msg,content.lrank)
	if(content.lrank_buy == nil) then print('formatNetMessage Error: lrank_buy is nil' ) end 
	self:formatinteger(msg,content.lrank_buy)
end

function NetProtocalPaser:formatpt_champion(msg, content) 
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.times == nil) then print('formatNetMessage Error: times is nil' ) end 
	self:formatshort(msg,content.times)
	if(content.cd == nil) then print('formatNetMessage Error: cd is nil' ) end 
	self:formatshort(msg,content.cd)
end

function NetProtocalPaser:formatpt_freedom(msg, content) 
	if(content.cd == nil) then print('formatNetMessage Error: cd is nil' ) end 
	self:formatshort(msg,content.cd)
end

function NetProtocalPaser:formatmcard(msg, content) 
	if(content.baseid == nil) then print('formatNetMessage Error: baseid is nil' ) end 
	self:formatinteger(msg,content.baseid)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatshort(msg,content.level)
	if(content.hp == nil) then print('formatNetMessage Error: hp is nil' ) end 
	self:formatinteger(msg,content.hp)
	if(content.att == nil) then print('formatNetMessage Error: att is nil' ) end 
	self:formatshort(msg,content.att)
end

function NetProtocalPaser:formatpt_m_group(msg, content) 
	if(content.hero == nil) then print('formatNetMessage Error: hero is nil' ) end 
	self:formatinteger(msg,content.hero)
	self:formatArray(msg,content.cards,'mcard')
end

function NetProtocalPaser:formatpt_m_fighter(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatinteger(msg,content.score)
end

function NetProtocalPaser:formatdb_monster(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatshort(msg,content.level)
	if(content.hard == nil) then print('formatNetMessage Error: hard is nil' ) end 
	self:formatshort(msg,content.hard)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatinteger(msg,content.score)
	if(content.find_id == nil) then print('formatNetMessage Error: find_id is nil' ) end 
	self:formatpkid(msg,content.find_id)
	if(content.find_time == nil) then print('formatNetMessage Error: find_time is nil' ) end 
	self:formatinteger(msg,content.find_time)
	if(content.end_time == nil) then print('formatNetMessage Error: end_time is nil' ) end 
	self:formatinteger(msg,content.end_time)
	self:formatArray(msg,content.attacker,'pt_m_fighter')
	if(content.fightdata == nil) then print('formatNetMessage Error: fightdata is nil' ) end 
	self:formatpt_m_group(msg,content.fightdata)
	if(content.killer_id == nil) then print('formatNetMessage Error: killer_id is nil' ) end 
	self:formatpkid(msg,content.killer_id)
	if(content.killed_time == nil) then print('formatNetMessage Error: killed_time is nil' ) end 
	self:formatinteger(msg,content.killed_time)
	if(content.prizecard == nil) then print('formatNetMessage Error: prizecard is nil' ) end 
	self:formatinteger(msg,content.prizecard)
end

function NetProtocalPaser:formatdb_mail(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.new == nil) then print('formatNetMessage Error: new is nil' ) end 
	self:formatshort(msg,content.new)
	if(content.from == nil) then print('formatNetMessage Error: from is nil' ) end 
	self:formatpkid(msg,content.from)
	if(content.event == nil) then print('formatNetMessage Error: event is nil' ) end 
	self:formatinteger(msg,content.event)
	if(content.title == nil) then print('formatNetMessage Error: title is nil' ) end 
	self:formatstring(msg,content.title)
	if(content.content == nil) then print('formatNetMessage Error: content is nil' ) end 
	self:formatstring(msg,content.content)
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
end

function NetProtocalPaser:formatpt_player_mail(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.new == nil) then print('formatNetMessage Error: new is nil' ) end 
	self:formatshort(msg,content.new)
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
	if(content.event == nil) then print('formatNetMessage Error: event is nil' ) end 
	self:formatstring(msg,content.event)
end

function NetProtocalPaser:formatpt_player_mail_list(msg, content) 
	self:formatArray(msg,content.info,'pt_player_mail')
end

function NetProtocalPaser:formatpt_write_mail(msg, content) 
	if(content.receiver == nil) then print('formatNetMessage Error: receiver is nil' ) end 
	self:formatpkid(msg,content.receiver)
	if(content.title == nil) then print('formatNetMessage Error: title is nil' ) end 
	self:formatstring(msg,content.title)
	if(content.content == nil) then print('formatNetMessage Error: content is nil' ) end 
	self:formatstring(msg,content.content)
end

function NetProtocalPaser:formatpt_new_mail(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatshort(msg,content.num)
end

function NetProtocalPaser:formatpt_new_mail_list(msg, content) 
	self:formatArray(msg,content.list,'pt_new_mail')
end

function NetProtocalPaser:formatpt_monster(msg, content) 
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatshort(msg,content.level)
	if(content.hard == nil) then print('formatNetMessage Error: hard is nil' ) end 
	self:formatshort(msg,content.hard)
	if(content.now == nil) then print('formatNetMessage Error: now is nil' ) end 
	self:formatshort(msg,content.now)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatshort(msg,content.score)
	if(content.find_id == nil) then print('formatNetMessage Error: find_id is nil' ) end 
	self:formatpkid(msg,content.find_id)
	if(content.find_name == nil) then print('formatNetMessage Error: find_name is nil' ) end 
	self:formatstring(msg,content.find_name)
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
	if(content.round == nil) then print('formatNetMessage Error: round is nil' ) end 
	self:formatshort(msg,content.round)
	if(content.killer_id == nil) then print('formatNetMessage Error: killer_id is nil' ) end 
	self:formatpkid(msg,content.killer_id)
	if(content.killer_name == nil) then print('formatNetMessage Error: killer_name is nil' ) end 
	self:formatstring(msg,content.killer_name)
end

function NetProtocalPaser:formatpt_find_monster(msg, content) 
	if(content.monster == nil) then print('formatNetMessage Error: monster is nil' ) end 
	self:formatpt_monster(msg,content.monster)
	if(content.cd == nil) then print('formatNetMessage Error: cd is nil' ) end 
	self:formatshort(msg,content.cd)
end

function NetProtocalPaser:formatpt_monster_all(msg, content) 
	self:formatArray(msg,content.all,'pt_monster')
	if(content.cd == nil) then print('formatNetMessage Error: cd is nil' ) end 
	self:formatshort(msg,content.cd)
end

function NetProtocalPaser:formatpt_crazy_score(msg, content) 
	if(content.once == nil) then print('formatNetMessage Error: once is nil' ) end 
	self:formatinteger(msg,content.once)
	if(content.totle == nil) then print('formatNetMessage Error: totle is nil' ) end 
	self:formatinteger(msg,content.totle)
end

function NetProtocalPaser:formatpt_pay_verify(msg, content) 
	if(content.platform == nil) then print('formatNetMessage Error: platform is nil' ) end 
	self:formatshort(msg,content.platform)
	if(content.pay_type == nil) then print('formatNetMessage Error: pay_type is nil' ) end 
	self:formatstring(msg,content.pay_type)
	if(content.token == nil) then print('formatNetMessage Error: token is nil' ) end 
	self:formatstring(msg,content.token)
	if(content.signature == nil) then print('formatNetMessage Error: signature is nil' ) end 
	self:formatstring(msg,content.signature)
end

function NetProtocalPaser:formatpt_pay_list_get(msg, content) 
	if(content.platform == nil) then print('formatNetMessage Error: platform is nil' ) end 
	self:formatshort(msg,content.platform)
end

function NetProtocalPaser:formatpt_pay_list(msg, content) 
	self:formatArray(msg,content.pay_types,'string')
end

function NetProtocalPaser:formatpt_legion_rank_get(msg, content) 
	if(content.start == nil) then print('formatNetMessage Error: start is nil' ) end 
	self:formatinteger(msg,content.start)
	if(content.size == nil) then print('formatNetMessage Error: size is nil' ) end 
	self:formatinteger(msg,content.size)
end

function NetProtocalPaser:formatpt_lrank_buy(msg, content) 
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatshort(msg,content.num)
	if(content.cost == nil) then print('formatNetMessage Error: cost is nil' ) end 
	self:formatinteger(msg,content.cost)
end

function NetProtocalPaser:formatlegion_rank(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.remark == nil) then print('formatNetMessage Error: remark is nil' ) end 
	self:formatstring(msg,content.remark)
	if(content.exp == nil) then print('formatNetMessage Error: exp is nil' ) end 
	self:formatinteger(msg,content.exp)
	if(content.lev == nil) then print('formatNetMessage Error: lev is nil' ) end 
	self:formatshort(msg,content.lev)
	if(content.flag == nil) then print('formatNetMessage Error: flag is nil' ) end 
	self:formatshort(msg,content.flag)
	if(content.lock == nil) then print('formatNetMessage Error: lock is nil' ) end 
	self:formatshort(msg,content.lock)
	if(content.meb == nil) then print('formatNetMessage Error: meb is nil' ) end 
	self:formatshort(msg,content.meb)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.score == nil) then print('formatNetMessage Error: score is nil' ) end 
	self:formatinteger(msg,content.score)
	if(content.threat == nil) then print('formatNetMessage Error: threat is nil' ) end 
	self:formatinteger(msg,content.threat)
end

function NetProtocalPaser:formatpt_legion_rank_list(msg, content) 
	if(content.len_id == nil) then print('formatNetMessage Error: len_id is nil' ) end 
	self:formatpkid(msg,content.len_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatshort(msg,content.num)
	if(content.cost == nil) then print('formatNetMessage Error: cost is nil' ) end 
	self:formatinteger(msg,content.cost)
	self:formatArray(msg,content.legion_ranks,'legion_rank')
end

function NetProtocalPaser:formatplayer_rank_info(msg, content) 
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatinteger(msg,content.level)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
	if(content.devote == nil) then print('formatNetMessage Error: devote is nil' ) end 
	self:formatinteger(msg,content.devote)
	if(content.plan_score == nil) then print('formatNetMessage Error: plan_score is nil' ) end 
	self:formatinteger(msg,content.plan_score)
	if(content.plan_money == nil) then print('formatNetMessage Error: plan_money is nil' ) end 
	self:formatinteger(msg,content.plan_money)
	if(content.protected == nil) then print('formatNetMessage Error: protected is nil' ) end 
	self:formatinteger(msg,content.protected)
end

function NetProtocalPaser:formatpt_player_rank_list(msg, content) 
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatshort(msg,content.num)
	if(content.cost == nil) then print('formatNetMessage Error: cost is nil' ) end 
	self:formatinteger(msg,content.cost)
	self:formatArray(msg,content.mebs,'player_rank_info')
end

function NetProtocalPaser:formatp_rank_info(msg, content) 
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.icon == nil) then print('formatNetMessage Error: icon is nil' ) end 
	self:formatstring(msg,content.icon)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatinteger(msg,content.level)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
	if(content.legion_id == nil) then print('formatNetMessage Error: legion_id is nil' ) end 
	self:formatpkid(msg,content.legion_id)
	if(content.legion_name == nil) then print('formatNetMessage Error: legion_name is nil' ) end 
	self:formatstring(msg,content.legion_name)
	if(content.flag == nil) then print('formatNetMessage Error: flag is nil' ) end 
	self:formatshort(msg,content.flag)
end

function NetProtocalPaser:formatpt_p_rank_list(msg, content) 
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
	self:formatArray(msg,content.mebs,'p_rank_info')
end

function NetProtocalPaser:formatrc_sign(msg, content) 
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatinteger(msg,content.num)
	if(content.gain == nil) then print('formatNetMessage Error: gain is nil' ) end 
	self:formatshort(msg,content.gain)
end

function NetProtocalPaser:formatdb_sign(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.month == nil) then print('formatNetMessage Error: month is nil' ) end 
	self:formatshort(msg,content.month)
	self:formatArray(msg,content.sign,'rc_sign')
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
end

function NetProtocalPaser:formatpt_sign(msg, content) 
	if(content.month == nil) then print('formatNetMessage Error: month is nil' ) end 
	self:formatshort(msg,content.month)
	if(content.sign == nil) then print('formatNetMessage Error: sign is nil' ) end 
	self:formatrc_sign(msg,content.sign)
end

function NetProtocalPaser:formatdb_param(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	self:formatArray(msg,content.intary,'integer')
end

function NetProtocalPaser:formatpk_cteam(msg, content) 
	if(content.baseid == nil) then print('formatNetMessage Error: baseid is nil' ) end 
	self:formatinteger(msg,content.baseid)
	if(content.level == nil) then print('formatNetMessage Error: level is nil' ) end 
	self:formatinteger(msg,content.level)
end

function NetProtocalPaser:formatdb_war(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	self:formatArray(msg,content.cards,'pk_cteam')
end

function NetProtocalPaser:formatdb_gvglog(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatpkid(msg,content.id)
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.legion_id == nil) then print('formatNetMessage Error: legion_id is nil' ) end 
	self:formatpkid(msg,content.legion_id)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
	if(content.shield == nil) then print('formatNetMessage Error: shield is nil' ) end 
	self:formatinteger(msg,content.shield)
	if(content.attack == nil) then print('formatNetMessage Error: attack is nil' ) end 
	self:formatinteger(msg,content.attack)
end

function NetProtocalPaser:formatpt_gvg_init_battle(msg, content) 
	if(content.legion_id == nil) then print('formatNetMessage Error: legion_id is nil' ) end 
	self:formatpkid(msg,content.legion_id)
	if(content.legion_name == nil) then print('formatNetMessage Error: legion_name is nil' ) end 
	self:formatstring(msg,content.legion_name)
	if(content.guard_id == nil) then print('formatNetMessage Error: guard_id is nil' ) end 
	self:formatpkid(msg,content.guard_id)
	if(content.guard_name == nil) then print('formatNetMessage Error: guard_name is nil' ) end 
	self:formatstring(msg,content.guard_name)
	if(content.guard_icon == nil) then print('formatNetMessage Error: guard_icon is nil' ) end 
	self:formatstring(msg,content.guard_icon)
	if(content.shield == nil) then print('formatNetMessage Error: shield is nil' ) end 
	self:formatinteger(msg,content.shield)
	if(content.max_shield == nil) then print('formatNetMessage Error: max_shield is nil' ) end 
	self:formatinteger(msg,content.max_shield)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
	self:formatArray(msg,content.mebs,'pkid')
	if(content.end_time == nil) then print('formatNetMessage Error: end_time is nil' ) end 
	self:formatinteger(msg,content.end_time)
end

function NetProtocalPaser:formatpt_gvg_init_battle_list(msg, content) 
	if(content.attack_num == nil) then print('formatNetMessage Error: attack_num is nil' ) end 
	self:formatshort(msg,content.attack_num)
	if(content.max_attack == nil) then print('formatNetMessage Error: max_attack is nil' ) end 
	self:formatshort(msg,content.max_attack)
	if(content.self == nil) then print('formatNetMessage Error: self is nil' ) end 
	self:formatpt_gvg_init_battle(msg,content.self)
	if(content.enemy == nil) then print('formatNetMessage Error: enemy is nil' ) end 
	self:formatpt_gvg_init_battle(msg,content.enemy)
end

function NetProtocalPaser:formatpt_gvg_battle_end(msg, content) 
	if(content.result == nil) then print('formatNetMessage Error: result is nil' ) end 
	self:formatshort(msg,content.result)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
	if(content.totle_scores == nil) then print('formatNetMessage Error: totle_scores is nil' ) end 
	self:formatinteger(msg,content.totle_scores)
	if(content.less_scores == nil) then print('formatNetMessage Error: less_scores is nil' ) end 
	self:formatinteger(msg,content.less_scores)
end

function NetProtocalPaser:formatpt_gvg_fight(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.target == nil) then print('formatNetMessage Error: target is nil' ) end 
	self:formatpkid(msg,content.target)
end

function NetProtocalPaser:formatpt_gvg_shield(msg, content) 
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.from_legion == nil) then print('formatNetMessage Error: from_legion is nil' ) end 
	self:formatpkid(msg,content.from_legion)
	if(content.target_legion == nil) then print('formatNetMessage Error: target_legion is nil' ) end 
	self:formatpkid(msg,content.target_legion)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.change == nil) then print('formatNetMessage Error: change is nil' ) end 
	self:formatinteger(msg,content.change)
	if(content.shield == nil) then print('formatNetMessage Error: shield is nil' ) end 
	self:formatinteger(msg,content.shield)
end

function NetProtocalPaser:formatpt_gvg_first(msg, content) 
	if(content.legion_id == nil) then print('formatNetMessage Error: legion_id is nil' ) end 
	self:formatpkid(msg,content.legion_id)
	if(content.gvg_id == nil) then print('formatNetMessage Error: gvg_id is nil' ) end 
	self:formatinteger(msg,content.gvg_id)
	if(content.gvg_state == nil) then print('formatNetMessage Error: gvg_state is nil' ) end 
	self:formatshort(msg,content.gvg_state)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
	if(content.shield == nil) then print('formatNetMessage Error: shield is nil' ) end 
	self:formatinteger(msg,content.shield)
	if(content.extra_shield == nil) then print('formatNetMessage Error: extra_shield is nil' ) end 
	self:formatinteger(msg,content.extra_shield)
	if(content.attack == nil) then print('formatNetMessage Error: attack is nil' ) end 
	self:formatinteger(msg,content.attack)
	if(content.extra_attack == nil) then print('formatNetMessage Error: extra_attack is nil' ) end 
	self:formatinteger(msg,content.extra_attack)
end

function NetProtocalPaser:formatpt_gvg_star(msg, content) 
	if(content.gvg_id == nil) then print('formatNetMessage Error: gvg_id is nil' ) end 
	self:formatinteger(msg,content.gvg_id)
	if(content.state == nil) then print('formatNetMessage Error: state is nil' ) end 
	self:formatinteger(msg,content.state)
	if(content.legion_id == nil) then print('formatNetMessage Error: legion_id is nil' ) end 
	self:formatpkid(msg,content.legion_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.flag == nil) then print('formatNetMessage Error: flag is nil' ) end 
	self:formatshort(msg,content.flag)
end

function NetProtocalPaser:formatpt_gvg_star_list(msg, content) 
	self:formatArray(msg,content.list,'pt_gvg_star')
end

function NetProtocalPaser:formatpt_gvg_rank(msg, content) 
	if(content.legion_id == nil) then print('formatNetMessage Error: legion_id is nil' ) end 
	self:formatpkid(msg,content.legion_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatinteger(msg,content.rank)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
end

function NetProtocalPaser:formatpt_gvg_rank_list(msg, content) 
	if(content.less_scores == nil) then print('formatNetMessage Error: less_scores is nil' ) end 
	self:formatinteger(msg,content.less_scores)
	self:formatArray(msg,content.list,'pt_gvg_rank')
end

function NetProtocalPaser:formatpt_gvg_legion_log(msg, content) 
	if(content.enemy_id == nil) then print('formatNetMessage Error: enemy_id is nil' ) end 
	self:formatpkid(msg,content.enemy_id)
	if(content.result == nil) then print('formatNetMessage Error: result is nil' ) end 
	self:formatshort(msg,content.result)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatinteger(msg,content.time)
end

function NetProtocalPaser:formatpt_gvg_legion_log_list(msg, content) 
	self:formatArray(msg,content.list,'pt_gvg_legion_log')
end

function NetProtocalPaser:formatpt_gvg_player_log(msg, content) 
	if(content.user_id == nil) then print('formatNetMessage Error: user_id is nil' ) end 
	self:formatpkid(msg,content.user_id)
	if(content.name == nil) then print('formatNetMessage Error: name is nil' ) end 
	self:formatstring(msg,content.name)
	if(content.attack == nil) then print('formatNetMessage Error: attack is nil' ) end 
	self:formatshort(msg,content.attack)
	if(content.win == nil) then print('formatNetMessage Error: win is nil' ) end 
	self:formatshort(msg,content.win)
	if(content.socres == nil) then print('formatNetMessage Error: socres is nil' ) end 
	self:formatinteger(msg,content.socres)
end

function NetProtocalPaser:formatpt_gvg_player_log_list(msg, content) 
	self:formatArray(msg,content.list,'pt_gvg_player_log')
end

function NetProtocalPaser:formatpt_gvg_login(msg, content) 
	if(content.gvg_id == nil) then print('formatNetMessage Error: gvg_id is nil' ) end 
	self:formatinteger(msg,content.gvg_id)
end

function NetProtocalPaser:formatpt_gvg_scores(msg, content) 
	if(content.legion_id == nil) then print('formatNetMessage Error: legion_id is nil' ) end 
	self:formatpkid(msg,content.legion_id)
	if(content.scores == nil) then print('formatNetMessage Error: scores is nil' ) end 
	self:formatinteger(msg,content.scores)
end

