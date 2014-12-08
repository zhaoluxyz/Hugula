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
	self:parseuint(msg,'id', parentTable)
end

function NetProtocalPaser:parsesend_check_version(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'os', parentTable)
end

function NetProtocalPaser:parserecv_check_version(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'game_ver', parentTable)
	self:parseushort(msg,'res_ver', parentTable)
end

function NetProtocalPaser:parseplayer_anonymouslogin(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'udid', parentTable)
	self:parsestring(msg,'os', parentTable)
	self:parsestring(msg,'token', parentTable)
end

function NetProtocalPaser:parsept_game_serverlist(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'udid', parentTable)
end

function NetProtocalPaser:parsept_gs_login(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'udid', parentTable)
	self:parsestring(msg,'sid', parentTable)
	self:parseuint(msg,'player_id', parentTable)
end

function NetProtocalPaser:parsept_gs_good(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'command', parentTable)
end

function NetProtocalPaser:parsept_gs_bad(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'command', parentTable)
	self:parseushort(msg,'errno', parentTable)
end

function NetProtocalPaser:parsept_int(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'i', parentTable)
end

function NetProtocalPaser:parserecv_player_hero(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_id', parentTable)
	self:parseuint(msg,'system_hero_id', parentTable)
	self:parseushort(msg,'player_hero_lv', parentTable)
	self:parseuint(msg,'player_hero_exp', parentTable)
	self:parsept_hero_attribute(msg,'player_hero_attribute', parentTable)
	self:parseushort(msg,'player_hero_color', parentTable)
	self:parseArray(msg,'player_hero_equip', parentTable,'pt_pkid')
	self:parseArray(msg,'player_hero_skill', parentTable,'pt_hero_skill')
	self:parseuint(msg,'player_hero_next_exp', parentTable)
	self:parseshort(msg,'pos', parentTable)
	self:parseshort(msg,'player_hero_num', parentTable)
	self:parseuint(msg,'hero_group_id', parentTable)
	self:parseushort(msg,'player_hero_strengthen_rate', parentTable)
	self:parseushort(msg,'player_hero_strengthen', parentTable)
	self:parseArray(msg,'hero_skill', parentTable,'pt_hero_skill')
end

function NetProtocalPaser:parsesend_player_hero_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'profession_category', parentTable)
	self:parseushort(msg,'page', parentTable)
	self:parseushort(msg,'size', parentTable)
end

function NetProtocalPaser:parserecv_player_team(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_id', parentTable)
	self:parseuint(msg,'system_hero_id', parentTable)
	self:parseushort(msg,'player_hero_lv', parentTable)
	self:parseuint(msg,'player_hero_exp', parentTable)
	self:parsept_hero_attribute(msg,'player_hero_attribute', parentTable)
	self:parseushort(msg,'player_hero_color', parentTable)
	self:parseArray(msg,'player_hero_equip', parentTable,'pt_pkid')
	self:parseArray(msg,'player_hero_skill', parentTable,'pt_hero_skill')
	self:parseshort(msg,'pos', parentTable)
	self:parseuint(msg,'player_hero_next_exp', parentTable)
	self:parseuint(msg,'hero_group_id', parentTable)
	self:parseushort(msg,'player_hero_strengthen_rate', parentTable)
	self:parseushort(msg,'player_hero_strengthen', parentTable)
	self:parseArray(msg,'hero_skill', parentTable,'pt_hero_skill')
end

function NetProtocalPaser:parsept_player_team(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'team', parentTable,'recv_player_team')
end

function NetProtocalPaser:parsept_player_hero(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'count', parentTable)
	self:parseArray(msg,'heros', parentTable,'recv_player_hero')
end

function NetProtocalPaser:parserecv_player_hero_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'heros', parentTable,'recv_player_hero')
end

function NetProtocalPaser:parsesend_player_chapter(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'parent', parentTable)
end

function NetProtocalPaser:parserecv_chapter_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'chapter_id', parentTable)
	self:parseuint(msg,'chapter_star', parentTable)
	self:parseuint(msg,'chapter_fastest_record', parentTable)
	self:parseuint(msg,'chapter_my_record', parentTable)
	self:parseushort(msg,'chapter_residue_number', parentTable)
end

function NetProtocalPaser:parsept_player_chapter_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_chapter_list')
end

function NetProtocalPaser:parsesend_challenge_chapter(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'chapter_id', parentTable)
end

function NetProtocalPaser:parsept_character_attribute_a(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'gold', parentTable)
	self:parseuint(msg,'crystal', parentTable)
	self:parseushort(msg,'vit', parentTable)
	self:parseuint(msg,'exp', parentTable)
	self:parseuint(msg,'player_friendship', parentTable)
	self:parseuint(msg,'player_prestige', parentTable)
	self:parseuint(msg,'player_arena_number', parentTable)
	self:parseuint(msg,'player_skill_points', parentTable)
	self:parseushort(msg,'lv', parentTable)
	self:parseushort(msg,'max_lv', parentTable)
	self:parseuint(msg,'max_exp', parentTable)
	self:parseushort(msg,'vit_limit', parentTable)
	self:parsept_hero_attribute(msg,'attribute', parentTable)
end

function NetProtocalPaser:parsesend_player_challenge_chapter_start(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'chapter_id', parentTable)
end

function NetProtocalPaser:parserecv_challenge_chapter_result(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseboolean(msg,'victory', parentTable)
	self:parseushort(msg,'star', parentTable)
	self:parserecv_paygoods(msg,'drop', parentTable)
end

function NetProtocalPaser:parserecv_player_sweep_chapter(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parserecv_paygoods(msg,'drop', parentTable)
end

function NetProtocalPaser:parserecv_challenge_chapter_result_hero(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_id', parentTable)
	self:parseuint(msg,'system_hero_id', parentTable)
	self:parseuint(msg,'exp', parentTable)
	self:parseushort(msg,'isup', parentTable)
	self:parseuint(msg,'max_exp', parentTable)
	self:parseuint(msg,'cur_exp', parentTable)
	self:parseushort(msg,'hero_lv', parentTable)
end

function NetProtocalPaser:parserecv_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
	self:parseushort(msg,'goods_num', parentTable)
	self:parseshort(msg,'goods_type', parentTable)
end

function NetProtocalPaser:parserecv_hero(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'hero_id', parentTable)
	self:parseushort(msg,'hero_num', parentTable)
end

function NetProtocalPaser:parsept_hero_attribute(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'hp', parentTable)
	self:parseuint(msg,'mp', parentTable)
	self:parseuint(msg,'maxHp', parentTable)
	self:parseuint(msg,'maxMp', parentTable)
	self:parsefloat(msg,'damage', parentTable)
	self:parsefloat(msg,'defend', parentTable)
	self:parsefloat(msg,'magicDamage', parentTable)
	self:parsefloat(msg,'magicDefend', parentTable)
	self:parsefloat(msg,'critValue', parentTable)
	self:parsefloat(msg,'dodgeValue', parentTable)
	self:parsefloat(msg,'speed', parentTable)
	self:parsefloat(msg,'attackSpeed', parentTable)
	self:parsefloat(msg,'turnSpeed', parentTable)
	self:parsefloat(msg,'rangeVisible', parentTable)
end

function NetProtocalPaser:parserecv_paygoods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'gold', parentTable)
	self:parseuint(msg,'crystal', parentTable)
	self:parseArray(msg,'goods', parentTable,'recv_goods')
	self:parseArray(msg,'heros', parentTable,'recv_hero')
	self:parseArray(msg,'hero_exp', parentTable,'recv_challenge_chapter_result_hero')
	self:parseuint(msg,'player_vit', parentTable)
	self:parseuint(msg,'player_exp', parentTable)
	self:parseuint(msg,'player_cur_exp', parentTable)
	self:parseushort(msg,'player_lv', parentTable)
	self:parseushort(msg,'player_is_up', parentTable)
	self:parseuint(msg,'player_prestige', parentTable)
end

function NetProtocalPaser:parsept_paygoods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'goods', parentTable,'recv_paygoods')
end

function NetProtocalPaser:parserecv_player_bag_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'goods', parentTable,'recv_goods')
end

function NetProtocalPaser:parsept_use_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
	self:parseshort(msg,'goods_num', parentTable)
end

function NetProtocalPaser:parsesend_hero_goods_use(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
	self:parseshort(msg,'goods_num', parentTable)
	self:parseuint(msg,'player_hero_id', parentTable)
end

function NetProtocalPaser:parsesend_change_player_team_up(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_id', parentTable)
	self:parseshort(msg,'pos', parentTable)
end

function NetProtocalPaser:parsesend_change_player_team_down(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'pos', parentTable)
end

function NetProtocalPaser:parsesend_player_goods_sell(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
	self:parseushort(msg,'goods_num', parentTable)
end

function NetProtocalPaser:parsesend_player_hero_equip_up(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
	self:parseuint(msg,'player_hero_id', parentTable)
end

function NetProtocalPaser:parsesend_player_hero_advanced(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_id', parentTable)
end

function NetProtocalPaser:parsept_hero_skill(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'id', parentTable)
	self:parseushort(msg,'lv', parentTable)
end

function NetProtocalPaser:parsesend_kill_monster(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'chapter_id', parentTable)
	self:parseuint(msg,'monster_id', parentTable)
end

function NetProtocalPaser:parserecv_monster(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'id', parentTable)
	self:parseuint(msg,'system_hero_id', parentTable)
	self:parseuint(msg,'hero_group_id', parentTable)
	self:parsestring(msg,'hero_brain', parentTable)
	self:parsept_pos(msg,'pos', parentTable)
	self:parsept_hero_attribute(msg,'player_hero_attribute', parentTable)
	self:parseArray(msg,'player_hero_skill', parentTable,'pt_hero_skill')
end

function NetProtocalPaser:parserecv_monster_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'monster', parentTable,'recv_monster')
	self:parseushort(msg,'round', parentTable)
	self:parseushort(msg,'count_round', parentTable)
	self:parseshort(msg,'team', parentTable)
end

function NetProtocalPaser:parserecv_player_challenge_chapter(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'chapter_type', parentTable)
	self:parseuint(msg,'chapter_id', parentTable)
	self:parseArray(msg,'hero_group_ids', parentTable,'pt_pkid')
	self:parseArray(msg,'hero_skill_ids', parentTable,'pt_hero_skill')
	self:parseArray(msg,'stronghold', parentTable,'recv_stronghold_army')
end

function NetProtocalPaser:parserecv_stronghold_army(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'hero_id', parentTable)
	self:parseuint(msg,'hero_group_id', parentTable)
	self:parseArray(msg,'army', parentTable,'recv_monster')
end

function NetProtocalPaser:parsesend_player_mail_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'max_mail_id', parentTable)
end

function NetProtocalPaser:parserecv_mail(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'mail_id', parentTable)
	self:parseshort(msg,'mail_group', parentTable)
	self:parseuint(msg,'player_id', parentTable)
	self:parsestring(msg,'player_name', parentTable)
	self:parsestring(msg,'mail_title', parentTable)
	self:parsestring(msg,'mail_body', parentTable)
	self:parserecv_paygoods(msg,'mail_goods', parentTable)
	self:parseshort(msg,'mail_status', parentTable)
	self:parsestring(msg,'mail_create_at', parentTable)
end

function NetProtocalPaser:parserecv_mail_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_mail')
end

function NetProtocalPaser:parsesend_player_mail_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'mail_id', parentTable)
end

function NetProtocalPaser:parsesend_player_mail_read(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'mail_id', parentTable)
end

function NetProtocalPaser:parserecv_mail_content(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_mail')
end

function NetProtocalPaser:parsesend_player_mail_delete(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'mail_id', parentTable)
end

function NetProtocalPaser:parserecv_broadcast_message(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'channel_id', parentTable)
	self:parseshort(msg,'type', parentTable)
	self:parsestring(msg,'body', parentTable)
	self:parseuint(msg,'sender_player_id', parentTable)
	self:parseuint(msg,'sender_player_role', parentTable)
	self:parsestring(msg,'sender_player_name', parentTable)
	self:parseuint(msg,'create_at', parentTable)
end

function NetProtocalPaser:parsesend_chat(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'channel_id', parentTable)
	self:parseuint(msg,'to_player_id', parentTable)
	self:parsestring(msg,'message', parentTable)
end

function NetProtocalPaser:parsesend_hero_equip_synthesis(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
end

function NetProtocalPaser:parsept_pos(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsefloat(msg,'x', parentTable)
	self:parsefloat(msg,'y', parentTable)
	self:parsefloat(msg,'z', parentTable)
end

function NetProtocalPaser:parsesend_mail(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_mail')
end

function NetProtocalPaser:parserecv_mail_count(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'count', parentTable)
end

function NetProtocalPaser:parserecv_friends_remain_count(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'count', parentTable)
end

function NetProtocalPaser:parsesend_player_send_mail(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'to_player_id', parentTable)
	self:parsestring(msg,'mail_title', parentTable)
	self:parsestring(msg,'mail_body', parentTable)
end

function NetProtocalPaser:parsesend_player_hero_strengthen(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_idl', parentTable)
	self:parseuint(msg,'player_hero_idr', parentTable)
end

function NetProtocalPaser:parserecv_player_hero_strengthen(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseboolean(msg,'success', parentTable)
end

function NetProtocalPaser:parsesend_hero_hero_synthesis(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_idl', parentTable)
	self:parseuint(msg,'player_hero_idr', parentTable)
end

function NetProtocalPaser:parsesend_player_reward_data(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'a', parentTable)
end

function NetProtocalPaser:parserecv_reward_data(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'player_week', parentTable)
	self:parseushort(msg,'player_day', parentTable)
	self:parseboolean(msg,'reward_status', parentTable)
end

function NetProtocalPaser:parsesend_player_reward_login(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'player_week', parentTable)
	self:parseushort(msg,'player_day', parentTable)
end

function NetProtocalPaser:parsesend_player_hero_stlas_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'a', parentTable)
end

function NetProtocalPaser:parserecv_hero_atlas(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'system_hero_id', parentTable)
	self:parseuint(msg,'player_hero_lv', parentTable)
end

function NetProtocalPaser:parserecv_hero_atlas_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_hero_atlas')
end

function NetProtocalPaser:parsesend_apply_friends_apply(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'friends_player_id', parentTable)
end

function NetProtocalPaser:parserecv_friends_apply(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'player_name', parentTable)
	self:parseuint(msg,'player_lv', parentTable)
	self:parseuint(msg,'player_role_id', parentTable)
	self:parseuint(msg,'player_id', parentTable)
end

function NetProtocalPaser:parserecv_friends_apply_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'count', parentTable)
	self:parseArray(msg,'list', parentTable,'recv_friends_apply')
end

function NetProtocalPaser:parsesend_request_friends_apply(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'friends_player_id', parentTable)
	self:parseushort(msg,'status', parentTable)
end

function NetProtocalPaser:parserecv_friends_request(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'friends_player_id', parentTable)
	self:parsestring(msg,'friends_player_name', parentTable)
	self:parseushort(msg,'status', parentTable)
end

function NetProtocalPaser:parsesend_friends_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'page', parentTable)
	self:parseushort(msg,'size', parentTable)
end

function NetProtocalPaser:parserecv_friends(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'friends_player_id', parentTable)
	self:parseuint(msg,'friends_player_lv', parentTable)
	self:parseuint(msg,'friends_player_role_id', parentTable)
	self:parsestring(msg,'friends_player_name', parentTable)
	self:parseushort(msg,'give_away_friendship', parentTable)
	self:parseuint(msg,'cool_down', parentTable)
end

function NetProtocalPaser:parsesend_reveive_friendship(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'friends_player_id', parentTable)
end

function NetProtocalPaser:parsesend_reveive_friendship_pick_up(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'a', parentTable)
end

function NetProtocalPaser:parsesend_value_friendship(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'friends_player_id', parentTable)
end

function NetProtocalPaser:parserecv_friends_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'count', parentTable)
	self:parseArray(msg,'list', parentTable,'recv_friends')
end

function NetProtocalPaser:parsesend_player_find_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'player_name', parentTable)
	self:parseushort(msg,'find_type', parentTable)
	self:parseushort(msg,'page', parentTable)
	self:parseushort(msg,'size', parentTable)
end

function NetProtocalPaser:parsesend_player_friends_delete(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'friends_player_id', parentTable)
end

function NetProtocalPaser:parserecv_find_player_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'count', parentTable)
	self:parseArray(msg,'list', parentTable,'recv_find_player')
end

function NetProtocalPaser:parserecv_find_player(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_id', parentTable)
	self:parsestring(msg,'player_name', parentTable)
	self:parseuint(msg,'player_lv', parentTable)
	self:parseuint(msg,'player_role_id', parentTable)
end

function NetProtocalPaser:parserecv_player_quest_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_player_quest')
end

function NetProtocalPaser:parserecv_player_quest(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'id', parentTable)
	self:parseuint(msg,'quest_id', parentTable)
	self:parseshort(msg,'quest_status', parentTable)
	self:parserecv_quest_progress(msg,'quest_progress', parentTable)
end

function NetProtocalPaser:parserecv_quest_progress(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'current', parentTable)
	self:parseushort(msg,'total', parentTable)
end

function NetProtocalPaser:parsesend_receive_quest_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'id', parentTable)
end

function NetProtocalPaser:parserecv_quest_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parserecv_paygoods(msg,'item', parentTable)
end

function NetProtocalPaser:parserecv_friends_remain_count(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'count', parentTable)
end

function NetProtocalPaser:parsesend_player_compound_goods_beast(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'beast_id', parentTable)
end

function NetProtocalPaser:parsesend_player_drama(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'drama_id', parentTable)
end

function NetProtocalPaser:parsesend_player_boot(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'boot_id', parentTable)
end

function NetProtocalPaser:parserecv_friends_mail(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'mail_id', parentTable)
	self:parseuint(msg,'player_id', parentTable)
	self:parsestring(msg,'player_name', parentTable)
	self:parsestring(msg,'mail_title', parentTable)
	self:parsestring(msg,'mail_body', parentTable)
	self:parsestring(msg,'mail_create_at', parentTable)
end

function NetProtocalPaser:parserecv_friends_mail_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_friends_mail')
end

function NetProtocalPaser:parseplayer_activity_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'a', parentTable)
end

function NetProtocalPaser:parserecv_activity_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_activity_one')
end

function NetProtocalPaser:parserecv_activity_one(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'category', parentTable)
	self:parseuint(msg,'activity_a', parentTable)
	self:parseuint(msg,'activity_b', parentTable)
	self:parseuint(msg,'activity_c', parentTable)
end

function NetProtocalPaser:parserecv_activity(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'activity_id', parentTable)
	self:parseuint(msg,'chapter_id', parentTable)
end

function NetProtocalPaser:parsecondition_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'key', parentTable)
	self:parsestring(msg,'condition', parentTable)
end

function NetProtocalPaser:parserecv_player_arena_rank_near(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'current_rank', parentTable)
	self:parseuint(msg,'player_prestige', parentTable)
	self:parseushort(msg,'remaining_number', parentTable)
	self:parseushort(msg,'max_limit', parentTable)
	self:parseArray(msg,'list', parentTable,'recv_player_arena_rank')
end

function NetProtocalPaser:parserecv_player_arena_rank(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_id', parentTable)
	self:parseushort(msg,'player_lv', parentTable)
	self:parsestring(msg,'player_name', parentTable)
	self:parseushort(msg,'rank', parentTable)
	self:parseArray(msg,'team', parentTable,'recv_player_hero')
	self:parserecv_paygoods(msg,'rank_reward', parentTable)
	self:parseinteger(msg,'recv_reward_time', parentTable)
end

function NetProtocalPaser:parserecv_player_beast_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_player_beast')
end

function NetProtocalPaser:parsesynthesis_goods_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
	self:parseushort(msg,'goods_num', parentTable)
end

function NetProtocalPaser:parserecv_player_beast(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'beast_id', parentTable)
	self:parseArray(msg,'synthesis_goods', parentTable,'synthesis_goods_list')
	self:parseushort(msg,'activate_status', parentTable)
	self:parseuint(msg,'cool_down', parentTable)
	self:parseushort(msg,'played', parentTable)
end

function NetProtocalPaser:parserecv_player_exchanges(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'refresh_time', parentTable)
	self:parseuint(msg,'player_prestige', parentTable)
	self:parseArray(msg,'goods', parentTable,'recv_exchange_goods')
	self:parserecv_goods_price(msg,'refresh_price', parentTable)
	self:parseushort(msg,'refresh_current_num', parentTable)
	self:parseushort(msg,'refresh_limit_num', parentTable)
end

function NetProtocalPaser:parserecv_exchange_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
	self:parseushort(msg,'goods_num', parentTable)
	self:parseushort(msg,'exchange_num', parentTable)
	self:parseuint(msg,'prestige', parentTable)
end

function NetProtocalPaser:parsesend_exchange_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
end

function NetProtocalPaser:parserecv_player_arena_battle_report_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_player_arena_battle_report')
end

function NetProtocalPaser:parserecv_player_arena_battle_report(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'battle_type', parentTable)
	self:parseuint(msg,'battle_player_id', parentTable)
	self:parsestring(msg,'battle_player_name', parentTable)
	self:parseboolean(msg,'is_victory', parentTable)
	self:parseushort(msg,'rank', parentTable)
	self:parsestring(msg,'battle_datetime', parentTable)
end

function NetProtocalPaser:parsesned_player_activity_verify(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'activity_id', parentTable)
	self:parseuint(msg,'category', parentTable)
end

function NetProtocalPaser:parserecv_player_activity_verify(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'activity_id', parentTable)
	self:parseushort(msg,'status', parentTable)
end

function NetProtocalPaser:parsesend_player_challenge_arena(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'enemy_player_id', parentTable)
end

function NetProtocalPaser:parsesend_player_besat_played(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'beast_id', parentTable)
end

function NetProtocalPaser:parsesend_player_hero_skill_up(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_id', parentTable)
	self:parseuint(msg,'skill_id', parentTable)
end

function NetProtocalPaser:parsesend_player_skill_release_up(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'a', parentTable)
end

function NetProtocalPaser:parserecv_player_hero_skill_time(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'time', parentTable)
end

function NetProtocalPaser:parserecv_system_conf_data(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'system_conf_data')
end

function NetProtocalPaser:parsesystem_conf_data(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'key', parentTable)
	self:parsestring(msg,'val', parentTable)
end

function NetProtocalPaser:parserecv_shop_goods_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_shop_goods')
end

function NetProtocalPaser:parserecv_shop_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'id', parentTable)
	self:parseshort(msg,'shop_no', parentTable)
	self:parseushort(msg,'shop_sort', parentTable)
	self:parseuint(msg,'goods_id', parentTable)
	self:parseushort(msg,'goods_num', parentTable)
	self:parseshort(msg,'buy_limit', parentTable)
	self:parserecv_goods_price(msg,'goods_price', parentTable)
	self:parseinteger(msg,'goods_free_time', parentTable)
	self:parseuint(msg,'goods_give', parentTable)
	self:parsestring(msg,'shop_artno', parentTable)
end

function NetProtocalPaser:parserecv_goods_price(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parsestring(msg,'type', parentTable)
	self:parseuint(msg,'price', parentTable)
end

function NetProtocalPaser:parsesend_buy_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'id', parentTable)
	self:parseushort(msg,'goods_num', parentTable)
end

function NetProtocalPaser:parserecv_buy_goods_data(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseshort(msg,'shop_no', parentTable)
	self:parserecv_buy_goods(msg,'items', parentTable)
end

function NetProtocalPaser:parserecv_buy_goods(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'goods', parentTable,'recv_goods')
	self:parseArray(msg,'hero', parentTable,'recv_hero')
	self:parseArray(msg,'other', parentTable,'recv_goods_price')
end

function NetProtocalPaser:parserecv_activity_residue_list(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseArray(msg,'list', parentTable,'recv_activity_residue')
end

function NetProtocalPaser:parserecv_activity_residue(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'category', parentTable)
	self:parseuint(msg,'num', parentTable)
end

function NetProtocalPaser:parsevit_release_up(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseushort(msg,'a', parentTable)
end

function NetProtocalPaser:parserecv_vit_release_up(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'time', parentTable)
end

function NetProtocalPaser:parserecv_player_friends_delete(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'friends_player_id', parentTable)
end

function NetProtocalPaser:parsesend_hero_fragments_synthetic(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'goods_id', parentTable)
end

function NetProtocalPaser:parsesend_player_hero_sell(msg, key, parentTable) 
	if(key ~= nil) then
		parentTable[key] = {}
		parentTable = parentTable[key]
	end
	self:parseuint(msg,'player_hero_id', parentTable)
end

function NetProtocalPaser:formatpt_pkid(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatuint(msg,content.id)
end

function NetProtocalPaser:formatsend_check_version(msg, content) 
	if(content.os == nil) then print('formatNetMessage Error: os is nil' ) end 
	self:formatstring(msg,content.os)
end

function NetProtocalPaser:formatrecv_check_version(msg, content) 
	if(content.game_ver == nil) then print('formatNetMessage Error: game_ver is nil' ) end 
	self:formatushort(msg,content.game_ver)
	if(content.res_ver == nil) then print('formatNetMessage Error: res_ver is nil' ) end 
	self:formatushort(msg,content.res_ver)
end

function NetProtocalPaser:formatplayer_anonymouslogin(msg, content) 
	if(content.udid == nil) then print('formatNetMessage Error: udid is nil' ) end 
	self:formatstring(msg,content.udid)
	if(content.os == nil) then print('formatNetMessage Error: os is nil' ) end 
	self:formatstring(msg,content.os)
	if(content.token == nil) then print('formatNetMessage Error: token is nil' ) end 
	self:formatstring(msg,content.token)
end

function NetProtocalPaser:formatpt_game_serverlist(msg, content) 
	if(content.udid == nil) then print('formatNetMessage Error: udid is nil' ) end 
	self:formatstring(msg,content.udid)
end

function NetProtocalPaser:formatpt_gs_login(msg, content) 
	if(content.udid == nil) then print('formatNetMessage Error: udid is nil' ) end 
	self:formatstring(msg,content.udid)
	if(content.sid == nil) then print('formatNetMessage Error: sid is nil' ) end 
	self:formatstring(msg,content.sid)
	if(content.player_id == nil) then print('formatNetMessage Error: player_id is nil' ) end 
	self:formatuint(msg,content.player_id)
end

function NetProtocalPaser:formatpt_gs_good(msg, content) 
	if(content.command == nil) then print('formatNetMessage Error: command is nil' ) end 
	self:formatushort(msg,content.command)
end

function NetProtocalPaser:formatpt_gs_bad(msg, content) 
	if(content.command == nil) then print('formatNetMessage Error: command is nil' ) end 
	self:formatushort(msg,content.command)
	if(content.errno == nil) then print('formatNetMessage Error: errno is nil' ) end 
	self:formatushort(msg,content.errno)
end

function NetProtocalPaser:formatpt_int(msg, content) 
	if(content.i == nil) then print('formatNetMessage Error: i is nil' ) end 
	self:formatuint(msg,content.i)
end

function NetProtocalPaser:formatrecv_player_hero(msg, content) 
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
	if(content.system_hero_id == nil) then print('formatNetMessage Error: system_hero_id is nil' ) end 
	self:formatuint(msg,content.system_hero_id)
	if(content.player_hero_lv == nil) then print('formatNetMessage Error: player_hero_lv is nil' ) end 
	self:formatushort(msg,content.player_hero_lv)
	if(content.player_hero_exp == nil) then print('formatNetMessage Error: player_hero_exp is nil' ) end 
	self:formatuint(msg,content.player_hero_exp)
	if(content.player_hero_attribute == nil) then print('formatNetMessage Error: player_hero_attribute is nil' ) end 
	self:formatpt_hero_attribute(msg,content.player_hero_attribute)
	if(content.player_hero_color == nil) then print('formatNetMessage Error: player_hero_color is nil' ) end 
	self:formatushort(msg,content.player_hero_color)
	self:formatArray(msg,content.player_hero_equip,'pt_pkid')
	self:formatArray(msg,content.player_hero_skill,'pt_hero_skill')
	if(content.player_hero_next_exp == nil) then print('formatNetMessage Error: player_hero_next_exp is nil' ) end 
	self:formatuint(msg,content.player_hero_next_exp)
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
	if(content.player_hero_num == nil) then print('formatNetMessage Error: player_hero_num is nil' ) end 
	self:formatshort(msg,content.player_hero_num)
	if(content.hero_group_id == nil) then print('formatNetMessage Error: hero_group_id is nil' ) end 
	self:formatuint(msg,content.hero_group_id)
	if(content.player_hero_strengthen_rate == nil) then print('formatNetMessage Error: player_hero_strengthen_rate is nil' ) end 
	self:formatushort(msg,content.player_hero_strengthen_rate)
	if(content.player_hero_strengthen == nil) then print('formatNetMessage Error: player_hero_strengthen is nil' ) end 
	self:formatushort(msg,content.player_hero_strengthen)
	self:formatArray(msg,content.hero_skill,'pt_hero_skill')
end

function NetProtocalPaser:formatsend_player_hero_list(msg, content) 
	if(content.profession_category == nil) then print('formatNetMessage Error: profession_category is nil' ) end 
	self:formatushort(msg,content.profession_category)
	if(content.page == nil) then print('formatNetMessage Error: page is nil' ) end 
	self:formatushort(msg,content.page)
	if(content.size == nil) then print('formatNetMessage Error: size is nil' ) end 
	self:formatushort(msg,content.size)
end

function NetProtocalPaser:formatrecv_player_team(msg, content) 
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
	if(content.system_hero_id == nil) then print('formatNetMessage Error: system_hero_id is nil' ) end 
	self:formatuint(msg,content.system_hero_id)
	if(content.player_hero_lv == nil) then print('formatNetMessage Error: player_hero_lv is nil' ) end 
	self:formatushort(msg,content.player_hero_lv)
	if(content.player_hero_exp == nil) then print('formatNetMessage Error: player_hero_exp is nil' ) end 
	self:formatuint(msg,content.player_hero_exp)
	if(content.player_hero_attribute == nil) then print('formatNetMessage Error: player_hero_attribute is nil' ) end 
	self:formatpt_hero_attribute(msg,content.player_hero_attribute)
	if(content.player_hero_color == nil) then print('formatNetMessage Error: player_hero_color is nil' ) end 
	self:formatushort(msg,content.player_hero_color)
	self:formatArray(msg,content.player_hero_equip,'pt_pkid')
	self:formatArray(msg,content.player_hero_skill,'pt_hero_skill')
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
	if(content.player_hero_next_exp == nil) then print('formatNetMessage Error: player_hero_next_exp is nil' ) end 
	self:formatuint(msg,content.player_hero_next_exp)
	if(content.hero_group_id == nil) then print('formatNetMessage Error: hero_group_id is nil' ) end 
	self:formatuint(msg,content.hero_group_id)
	if(content.player_hero_strengthen_rate == nil) then print('formatNetMessage Error: player_hero_strengthen_rate is nil' ) end 
	self:formatushort(msg,content.player_hero_strengthen_rate)
	if(content.player_hero_strengthen == nil) then print('formatNetMessage Error: player_hero_strengthen is nil' ) end 
	self:formatushort(msg,content.player_hero_strengthen)
	self:formatArray(msg,content.hero_skill,'pt_hero_skill')
end

function NetProtocalPaser:formatpt_player_team(msg, content) 
	self:formatArray(msg,content.team,'recv_player_team')
end

function NetProtocalPaser:formatpt_player_hero(msg, content) 
	if(content.count == nil) then print('formatNetMessage Error: count is nil' ) end 
	self:formatushort(msg,content.count)
	self:formatArray(msg,content.heros,'recv_player_hero')
end

function NetProtocalPaser:formatrecv_player_hero_list(msg, content) 
	self:formatArray(msg,content.heros,'recv_player_hero')
end

function NetProtocalPaser:formatsend_player_chapter(msg, content) 
	if(content.parent == nil) then print('formatNetMessage Error: parent is nil' ) end 
	self:formatuint(msg,content.parent)
end

function NetProtocalPaser:formatrecv_chapter_list(msg, content) 
	if(content.chapter_id == nil) then print('formatNetMessage Error: chapter_id is nil' ) end 
	self:formatuint(msg,content.chapter_id)
	if(content.chapter_star == nil) then print('formatNetMessage Error: chapter_star is nil' ) end 
	self:formatuint(msg,content.chapter_star)
	if(content.chapter_fastest_record == nil) then print('formatNetMessage Error: chapter_fastest_record is nil' ) end 
	self:formatuint(msg,content.chapter_fastest_record)
	if(content.chapter_my_record == nil) then print('formatNetMessage Error: chapter_my_record is nil' ) end 
	self:formatuint(msg,content.chapter_my_record)
	if(content.chapter_residue_number == nil) then print('formatNetMessage Error: chapter_residue_number is nil' ) end 
	self:formatushort(msg,content.chapter_residue_number)
end

function NetProtocalPaser:formatpt_player_chapter_list(msg, content) 
	self:formatArray(msg,content.list,'recv_chapter_list')
end

function NetProtocalPaser:formatsend_challenge_chapter(msg, content) 
	if(content.chapter_id == nil) then print('formatNetMessage Error: chapter_id is nil' ) end 
	self:formatuint(msg,content.chapter_id)
end

function NetProtocalPaser:formatpt_character_attribute_a(msg, content) 
	if(content.gold == nil) then print('formatNetMessage Error: gold is nil' ) end 
	self:formatuint(msg,content.gold)
	if(content.crystal == nil) then print('formatNetMessage Error: crystal is nil' ) end 
	self:formatuint(msg,content.crystal)
	if(content.vit == nil) then print('formatNetMessage Error: vit is nil' ) end 
	self:formatushort(msg,content.vit)
	if(content.exp == nil) then print('formatNetMessage Error: exp is nil' ) end 
	self:formatuint(msg,content.exp)
	if(content.player_friendship == nil) then print('formatNetMessage Error: player_friendship is nil' ) end 
	self:formatuint(msg,content.player_friendship)
	if(content.player_prestige == nil) then print('formatNetMessage Error: player_prestige is nil' ) end 
	self:formatuint(msg,content.player_prestige)
	if(content.player_arena_number == nil) then print('formatNetMessage Error: player_arena_number is nil' ) end 
	self:formatuint(msg,content.player_arena_number)
	if(content.player_skill_points == nil) then print('formatNetMessage Error: player_skill_points is nil' ) end 
	self:formatuint(msg,content.player_skill_points)
	if(content.lv == nil) then print('formatNetMessage Error: lv is nil' ) end 
	self:formatushort(msg,content.lv)
	if(content.max_lv == nil) then print('formatNetMessage Error: max_lv is nil' ) end 
	self:formatushort(msg,content.max_lv)
	if(content.max_exp == nil) then print('formatNetMessage Error: max_exp is nil' ) end 
	self:formatuint(msg,content.max_exp)
	if(content.vit_limit == nil) then print('formatNetMessage Error: vit_limit is nil' ) end 
	self:formatushort(msg,content.vit_limit)
	if(content.attribute == nil) then print('formatNetMessage Error: attribute is nil' ) end 
	self:formatpt_hero_attribute(msg,content.attribute)
end

function NetProtocalPaser:formatsend_player_challenge_chapter_start(msg, content) 
	if(content.chapter_id == nil) then print('formatNetMessage Error: chapter_id is nil' ) end 
	self:formatuint(msg,content.chapter_id)
end

function NetProtocalPaser:formatrecv_challenge_chapter_result(msg, content) 
	if(content.victory == nil) then print('formatNetMessage Error: victory is nil' ) end 
	self:formatboolean(msg,content.victory)
	if(content.star == nil) then print('formatNetMessage Error: star is nil' ) end 
	self:formatushort(msg,content.star)
	if(content.drop == nil) then print('formatNetMessage Error: drop is nil' ) end 
	self:formatrecv_paygoods(msg,content.drop)
end

function NetProtocalPaser:formatrecv_player_sweep_chapter(msg, content) 
	if(content.drop == nil) then print('formatNetMessage Error: drop is nil' ) end 
	self:formatrecv_paygoods(msg,content.drop)
end

function NetProtocalPaser:formatrecv_challenge_chapter_result_hero(msg, content) 
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
	if(content.system_hero_id == nil) then print('formatNetMessage Error: system_hero_id is nil' ) end 
	self:formatuint(msg,content.system_hero_id)
	if(content.exp == nil) then print('formatNetMessage Error: exp is nil' ) end 
	self:formatuint(msg,content.exp)
	if(content.isup == nil) then print('formatNetMessage Error: isup is nil' ) end 
	self:formatushort(msg,content.isup)
	if(content.max_exp == nil) then print('formatNetMessage Error: max_exp is nil' ) end 
	self:formatuint(msg,content.max_exp)
	if(content.cur_exp == nil) then print('formatNetMessage Error: cur_exp is nil' ) end 
	self:formatuint(msg,content.cur_exp)
	if(content.hero_lv == nil) then print('formatNetMessage Error: hero_lv is nil' ) end 
	self:formatushort(msg,content.hero_lv)
end

function NetProtocalPaser:formatrecv_goods(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
	if(content.goods_num == nil) then print('formatNetMessage Error: goods_num is nil' ) end 
	self:formatushort(msg,content.goods_num)
	if(content.goods_type == nil) then print('formatNetMessage Error: goods_type is nil' ) end 
	self:formatshort(msg,content.goods_type)
end

function NetProtocalPaser:formatrecv_hero(msg, content) 
	if(content.hero_id == nil) then print('formatNetMessage Error: hero_id is nil' ) end 
	self:formatuint(msg,content.hero_id)
	if(content.hero_num == nil) then print('formatNetMessage Error: hero_num is nil' ) end 
	self:formatushort(msg,content.hero_num)
end

function NetProtocalPaser:formatpt_hero_attribute(msg, content) 
	if(content.hp == nil) then print('formatNetMessage Error: hp is nil' ) end 
	self:formatuint(msg,content.hp)
	if(content.mp == nil) then print('formatNetMessage Error: mp is nil' ) end 
	self:formatuint(msg,content.mp)
	if(content.maxHp == nil) then print('formatNetMessage Error: maxHp is nil' ) end 
	self:formatuint(msg,content.maxHp)
	if(content.maxMp == nil) then print('formatNetMessage Error: maxMp is nil' ) end 
	self:formatuint(msg,content.maxMp)
	if(content.damage == nil) then print('formatNetMessage Error: damage is nil' ) end 
	self:formatfloat(msg,content.damage)
	if(content.defend == nil) then print('formatNetMessage Error: defend is nil' ) end 
	self:formatfloat(msg,content.defend)
	if(content.magicDamage == nil) then print('formatNetMessage Error: magicDamage is nil' ) end 
	self:formatfloat(msg,content.magicDamage)
	if(content.magicDefend == nil) then print('formatNetMessage Error: magicDefend is nil' ) end 
	self:formatfloat(msg,content.magicDefend)
	if(content.critValue == nil) then print('formatNetMessage Error: critValue is nil' ) end 
	self:formatfloat(msg,content.critValue)
	if(content.dodgeValue == nil) then print('formatNetMessage Error: dodgeValue is nil' ) end 
	self:formatfloat(msg,content.dodgeValue)
	if(content.speed == nil) then print('formatNetMessage Error: speed is nil' ) end 
	self:formatfloat(msg,content.speed)
	if(content.attackSpeed == nil) then print('formatNetMessage Error: attackSpeed is nil' ) end 
	self:formatfloat(msg,content.attackSpeed)
	if(content.turnSpeed == nil) then print('formatNetMessage Error: turnSpeed is nil' ) end 
	self:formatfloat(msg,content.turnSpeed)
	if(content.rangeVisible == nil) then print('formatNetMessage Error: rangeVisible is nil' ) end 
	self:formatfloat(msg,content.rangeVisible)
end

function NetProtocalPaser:formatrecv_paygoods(msg, content) 
	if(content.gold == nil) then print('formatNetMessage Error: gold is nil' ) end 
	self:formatuint(msg,content.gold)
	if(content.crystal == nil) then print('formatNetMessage Error: crystal is nil' ) end 
	self:formatuint(msg,content.crystal)
	self:formatArray(msg,content.goods,'recv_goods')
	self:formatArray(msg,content.heros,'recv_hero')
	self:formatArray(msg,content.hero_exp,'recv_challenge_chapter_result_hero')
	if(content.player_vit == nil) then print('formatNetMessage Error: player_vit is nil' ) end 
	self:formatuint(msg,content.player_vit)
	if(content.player_exp == nil) then print('formatNetMessage Error: player_exp is nil' ) end 
	self:formatuint(msg,content.player_exp)
	if(content.player_cur_exp == nil) then print('formatNetMessage Error: player_cur_exp is nil' ) end 
	self:formatuint(msg,content.player_cur_exp)
	if(content.player_lv == nil) then print('formatNetMessage Error: player_lv is nil' ) end 
	self:formatushort(msg,content.player_lv)
	if(content.player_is_up == nil) then print('formatNetMessage Error: player_is_up is nil' ) end 
	self:formatushort(msg,content.player_is_up)
	if(content.player_prestige == nil) then print('formatNetMessage Error: player_prestige is nil' ) end 
	self:formatuint(msg,content.player_prestige)
end

function NetProtocalPaser:formatpt_paygoods(msg, content) 
	self:formatArray(msg,content.goods,'recv_paygoods')
end

function NetProtocalPaser:formatrecv_player_bag_goods(msg, content) 
	self:formatArray(msg,content.goods,'recv_goods')
end

function NetProtocalPaser:formatpt_use_goods(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
	if(content.goods_num == nil) then print('formatNetMessage Error: goods_num is nil' ) end 
	self:formatshort(msg,content.goods_num)
end

function NetProtocalPaser:formatsend_hero_goods_use(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
	if(content.goods_num == nil) then print('formatNetMessage Error: goods_num is nil' ) end 
	self:formatshort(msg,content.goods_num)
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
end

function NetProtocalPaser:formatsend_change_player_team_up(msg, content) 
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
end

function NetProtocalPaser:formatsend_change_player_team_down(msg, content) 
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatshort(msg,content.pos)
end

function NetProtocalPaser:formatsend_player_goods_sell(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
	if(content.goods_num == nil) then print('formatNetMessage Error: goods_num is nil' ) end 
	self:formatushort(msg,content.goods_num)
end

function NetProtocalPaser:formatsend_player_hero_equip_up(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
end

function NetProtocalPaser:formatsend_player_hero_advanced(msg, content) 
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
end

function NetProtocalPaser:formatpt_hero_skill(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatuint(msg,content.id)
	if(content.lv == nil) then print('formatNetMessage Error: lv is nil' ) end 
	self:formatushort(msg,content.lv)
end

function NetProtocalPaser:formatsend_kill_monster(msg, content) 
	if(content.chapter_id == nil) then print('formatNetMessage Error: chapter_id is nil' ) end 
	self:formatuint(msg,content.chapter_id)
	if(content.monster_id == nil) then print('formatNetMessage Error: monster_id is nil' ) end 
	self:formatuint(msg,content.monster_id)
end

function NetProtocalPaser:formatrecv_monster(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatuint(msg,content.id)
	if(content.system_hero_id == nil) then print('formatNetMessage Error: system_hero_id is nil' ) end 
	self:formatuint(msg,content.system_hero_id)
	if(content.hero_group_id == nil) then print('formatNetMessage Error: hero_group_id is nil' ) end 
	self:formatuint(msg,content.hero_group_id)
	if(content.hero_brain == nil) then print('formatNetMessage Error: hero_brain is nil' ) end 
	self:formatstring(msg,content.hero_brain)
	if(content.pos == nil) then print('formatNetMessage Error: pos is nil' ) end 
	self:formatpt_pos(msg,content.pos)
	if(content.player_hero_attribute == nil) then print('formatNetMessage Error: player_hero_attribute is nil' ) end 
	self:formatpt_hero_attribute(msg,content.player_hero_attribute)
	self:formatArray(msg,content.player_hero_skill,'pt_hero_skill')
end

function NetProtocalPaser:formatrecv_monster_list(msg, content) 
	self:formatArray(msg,content.monster,'recv_monster')
	if(content.round == nil) then print('formatNetMessage Error: round is nil' ) end 
	self:formatushort(msg,content.round)
	if(content.count_round == nil) then print('formatNetMessage Error: count_round is nil' ) end 
	self:formatushort(msg,content.count_round)
	if(content.team == nil) then print('formatNetMessage Error: team is nil' ) end 
	self:formatshort(msg,content.team)
end

function NetProtocalPaser:formatrecv_player_challenge_chapter(msg, content) 
	if(content.chapter_type == nil) then print('formatNetMessage Error: chapter_type is nil' ) end 
	self:formatshort(msg,content.chapter_type)
	if(content.chapter_id == nil) then print('formatNetMessage Error: chapter_id is nil' ) end 
	self:formatuint(msg,content.chapter_id)
	self:formatArray(msg,content.hero_group_ids,'pt_pkid')
	self:formatArray(msg,content.hero_skill_ids,'pt_hero_skill')
	self:formatArray(msg,content.stronghold,'recv_stronghold_army')
end

function NetProtocalPaser:formatrecv_stronghold_army(msg, content) 
	if(content.hero_id == nil) then print('formatNetMessage Error: hero_id is nil' ) end 
	self:formatuint(msg,content.hero_id)
	if(content.hero_group_id == nil) then print('formatNetMessage Error: hero_group_id is nil' ) end 
	self:formatuint(msg,content.hero_group_id)
	self:formatArray(msg,content.army,'recv_monster')
end

function NetProtocalPaser:formatsend_player_mail_list(msg, content) 
	if(content.max_mail_id == nil) then print('formatNetMessage Error: max_mail_id is nil' ) end 
	self:formatuint(msg,content.max_mail_id)
end

function NetProtocalPaser:formatrecv_mail(msg, content) 
	if(content.mail_id == nil) then print('formatNetMessage Error: mail_id is nil' ) end 
	self:formatuint(msg,content.mail_id)
	if(content.mail_group == nil) then print('formatNetMessage Error: mail_group is nil' ) end 
	self:formatshort(msg,content.mail_group)
	if(content.player_id == nil) then print('formatNetMessage Error: player_id is nil' ) end 
	self:formatuint(msg,content.player_id)
	if(content.player_name == nil) then print('formatNetMessage Error: player_name is nil' ) end 
	self:formatstring(msg,content.player_name)
	if(content.mail_title == nil) then print('formatNetMessage Error: mail_title is nil' ) end 
	self:formatstring(msg,content.mail_title)
	if(content.mail_body == nil) then print('formatNetMessage Error: mail_body is nil' ) end 
	self:formatstring(msg,content.mail_body)
	if(content.mail_goods == nil) then print('formatNetMessage Error: mail_goods is nil' ) end 
	self:formatrecv_paygoods(msg,content.mail_goods)
	if(content.mail_status == nil) then print('formatNetMessage Error: mail_status is nil' ) end 
	self:formatshort(msg,content.mail_status)
	if(content.mail_create_at == nil) then print('formatNetMessage Error: mail_create_at is nil' ) end 
	self:formatstring(msg,content.mail_create_at)
end

function NetProtocalPaser:formatrecv_mail_list(msg, content) 
	self:formatArray(msg,content.list,'recv_mail')
end

function NetProtocalPaser:formatsend_player_mail_goods(msg, content) 
	if(content.mail_id == nil) then print('formatNetMessage Error: mail_id is nil' ) end 
	self:formatuint(msg,content.mail_id)
end

function NetProtocalPaser:formatsend_player_mail_read(msg, content) 
	if(content.mail_id == nil) then print('formatNetMessage Error: mail_id is nil' ) end 
	self:formatuint(msg,content.mail_id)
end

function NetProtocalPaser:formatrecv_mail_content(msg, content) 
	self:formatArray(msg,content.list,'recv_mail')
end

function NetProtocalPaser:formatsend_player_mail_delete(msg, content) 
	if(content.mail_id == nil) then print('formatNetMessage Error: mail_id is nil' ) end 
	self:formatuint(msg,content.mail_id)
end

function NetProtocalPaser:formatrecv_broadcast_message(msg, content) 
	if(content.channel_id == nil) then print('formatNetMessage Error: channel_id is nil' ) end 
	self:formatshort(msg,content.channel_id)
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatshort(msg,content.type)
	if(content.body == nil) then print('formatNetMessage Error: body is nil' ) end 
	self:formatstring(msg,content.body)
	if(content.sender_player_id == nil) then print('formatNetMessage Error: sender_player_id is nil' ) end 
	self:formatuint(msg,content.sender_player_id)
	if(content.sender_player_role == nil) then print('formatNetMessage Error: sender_player_role is nil' ) end 
	self:formatuint(msg,content.sender_player_role)
	if(content.sender_player_name == nil) then print('formatNetMessage Error: sender_player_name is nil' ) end 
	self:formatstring(msg,content.sender_player_name)
	if(content.create_at == nil) then print('formatNetMessage Error: create_at is nil' ) end 
	self:formatuint(msg,content.create_at)
end

function NetProtocalPaser:formatsend_chat(msg, content) 
	if(content.channel_id == nil) then print('formatNetMessage Error: channel_id is nil' ) end 
	self:formatshort(msg,content.channel_id)
	if(content.to_player_id == nil) then print('formatNetMessage Error: to_player_id is nil' ) end 
	self:formatuint(msg,content.to_player_id)
	if(content.message == nil) then print('formatNetMessage Error: message is nil' ) end 
	self:formatstring(msg,content.message)
end

function NetProtocalPaser:formatsend_hero_equip_synthesis(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
end

function NetProtocalPaser:formatpt_pos(msg, content) 
	if(content.x == nil) then print('formatNetMessage Error: x is nil' ) end 
	self:formatfloat(msg,content.x)
	if(content.y == nil) then print('formatNetMessage Error: y is nil' ) end 
	self:formatfloat(msg,content.y)
	if(content.z == nil) then print('formatNetMessage Error: z is nil' ) end 
	self:formatfloat(msg,content.z)
end

function NetProtocalPaser:formatsend_mail(msg, content) 
	self:formatArray(msg,content.list,'recv_mail')
end

function NetProtocalPaser:formatrecv_mail_count(msg, content) 
	if(content.count == nil) then print('formatNetMessage Error: count is nil' ) end 
	self:formatushort(msg,content.count)
end

function NetProtocalPaser:formatrecv_friends_remain_count(msg, content) 
	if(content.count == nil) then print('formatNetMessage Error: count is nil' ) end 
	self:formatushort(msg,content.count)
end

function NetProtocalPaser:formatsend_player_send_mail(msg, content) 
	if(content.to_player_id == nil) then print('formatNetMessage Error: to_player_id is nil' ) end 
	self:formatuint(msg,content.to_player_id)
	if(content.mail_title == nil) then print('formatNetMessage Error: mail_title is nil' ) end 
	self:formatstring(msg,content.mail_title)
	if(content.mail_body == nil) then print('formatNetMessage Error: mail_body is nil' ) end 
	self:formatstring(msg,content.mail_body)
end

function NetProtocalPaser:formatsend_player_hero_strengthen(msg, content) 
	if(content.player_hero_idl == nil) then print('formatNetMessage Error: player_hero_idl is nil' ) end 
	self:formatuint(msg,content.player_hero_idl)
	if(content.player_hero_idr == nil) then print('formatNetMessage Error: player_hero_idr is nil' ) end 
	self:formatuint(msg,content.player_hero_idr)
end

function NetProtocalPaser:formatrecv_player_hero_strengthen(msg, content) 
	if(content.success == nil) then print('formatNetMessage Error: success is nil' ) end 
	self:formatboolean(msg,content.success)
end

function NetProtocalPaser:formatsend_hero_hero_synthesis(msg, content) 
	if(content.player_hero_idl == nil) then print('formatNetMessage Error: player_hero_idl is nil' ) end 
	self:formatuint(msg,content.player_hero_idl)
	if(content.player_hero_idr == nil) then print('formatNetMessage Error: player_hero_idr is nil' ) end 
	self:formatuint(msg,content.player_hero_idr)
end

function NetProtocalPaser:formatsend_player_reward_data(msg, content) 
	if(content.a == nil) then print('formatNetMessage Error: a is nil' ) end 
	self:formatushort(msg,content.a)
end

function NetProtocalPaser:formatrecv_reward_data(msg, content) 
	if(content.player_week == nil) then print('formatNetMessage Error: player_week is nil' ) end 
	self:formatushort(msg,content.player_week)
	if(content.player_day == nil) then print('formatNetMessage Error: player_day is nil' ) end 
	self:formatushort(msg,content.player_day)
	if(content.reward_status == nil) then print('formatNetMessage Error: reward_status is nil' ) end 
	self:formatboolean(msg,content.reward_status)
end

function NetProtocalPaser:formatsend_player_reward_login(msg, content) 
	if(content.player_week == nil) then print('formatNetMessage Error: player_week is nil' ) end 
	self:formatushort(msg,content.player_week)
	if(content.player_day == nil) then print('formatNetMessage Error: player_day is nil' ) end 
	self:formatushort(msg,content.player_day)
end

function NetProtocalPaser:formatsend_player_hero_stlas_list(msg, content) 
	if(content.a == nil) then print('formatNetMessage Error: a is nil' ) end 
	self:formatushort(msg,content.a)
end

function NetProtocalPaser:formatrecv_hero_atlas(msg, content) 
	if(content.system_hero_id == nil) then print('formatNetMessage Error: system_hero_id is nil' ) end 
	self:formatuint(msg,content.system_hero_id)
	if(content.player_hero_lv == nil) then print('formatNetMessage Error: player_hero_lv is nil' ) end 
	self:formatuint(msg,content.player_hero_lv)
end

function NetProtocalPaser:formatrecv_hero_atlas_list(msg, content) 
	self:formatArray(msg,content.list,'recv_hero_atlas')
end

function NetProtocalPaser:formatsend_apply_friends_apply(msg, content) 
	if(content.friends_player_id == nil) then print('formatNetMessage Error: friends_player_id is nil' ) end 
	self:formatuint(msg,content.friends_player_id)
end

function NetProtocalPaser:formatrecv_friends_apply(msg, content) 
	if(content.player_name == nil) then print('formatNetMessage Error: player_name is nil' ) end 
	self:formatstring(msg,content.player_name)
	if(content.player_lv == nil) then print('formatNetMessage Error: player_lv is nil' ) end 
	self:formatuint(msg,content.player_lv)
	if(content.player_role_id == nil) then print('formatNetMessage Error: player_role_id is nil' ) end 
	self:formatuint(msg,content.player_role_id)
	if(content.player_id == nil) then print('formatNetMessage Error: player_id is nil' ) end 
	self:formatuint(msg,content.player_id)
end

function NetProtocalPaser:formatrecv_friends_apply_list(msg, content) 
	if(content.count == nil) then print('formatNetMessage Error: count is nil' ) end 
	self:formatushort(msg,content.count)
	self:formatArray(msg,content.list,'recv_friends_apply')
end

function NetProtocalPaser:formatsend_request_friends_apply(msg, content) 
	if(content.friends_player_id == nil) then print('formatNetMessage Error: friends_player_id is nil' ) end 
	self:formatuint(msg,content.friends_player_id)
	if(content.status == nil) then print('formatNetMessage Error: status is nil' ) end 
	self:formatushort(msg,content.status)
end

function NetProtocalPaser:formatrecv_friends_request(msg, content) 
	if(content.friends_player_id == nil) then print('formatNetMessage Error: friends_player_id is nil' ) end 
	self:formatuint(msg,content.friends_player_id)
	if(content.friends_player_name == nil) then print('formatNetMessage Error: friends_player_name is nil' ) end 
	self:formatstring(msg,content.friends_player_name)
	if(content.status == nil) then print('formatNetMessage Error: status is nil' ) end 
	self:formatushort(msg,content.status)
end

function NetProtocalPaser:formatsend_friends_list(msg, content) 
	if(content.page == nil) then print('formatNetMessage Error: page is nil' ) end 
	self:formatushort(msg,content.page)
	if(content.size == nil) then print('formatNetMessage Error: size is nil' ) end 
	self:formatushort(msg,content.size)
end

function NetProtocalPaser:formatrecv_friends(msg, content) 
	if(content.friends_player_id == nil) then print('formatNetMessage Error: friends_player_id is nil' ) end 
	self:formatuint(msg,content.friends_player_id)
	if(content.friends_player_lv == nil) then print('formatNetMessage Error: friends_player_lv is nil' ) end 
	self:formatuint(msg,content.friends_player_lv)
	if(content.friends_player_role_id == nil) then print('formatNetMessage Error: friends_player_role_id is nil' ) end 
	self:formatuint(msg,content.friends_player_role_id)
	if(content.friends_player_name == nil) then print('formatNetMessage Error: friends_player_name is nil' ) end 
	self:formatstring(msg,content.friends_player_name)
	if(content.give_away_friendship == nil) then print('formatNetMessage Error: give_away_friendship is nil' ) end 
	self:formatushort(msg,content.give_away_friendship)
	if(content.cool_down == nil) then print('formatNetMessage Error: cool_down is nil' ) end 
	self:formatuint(msg,content.cool_down)
end

function NetProtocalPaser:formatsend_reveive_friendship(msg, content) 
	if(content.friends_player_id == nil) then print('formatNetMessage Error: friends_player_id is nil' ) end 
	self:formatuint(msg,content.friends_player_id)
end

function NetProtocalPaser:formatsend_reveive_friendship_pick_up(msg, content) 
	if(content.a == nil) then print('formatNetMessage Error: a is nil' ) end 
	self:formatuint(msg,content.a)
end

function NetProtocalPaser:formatsend_value_friendship(msg, content) 
	if(content.friends_player_id == nil) then print('formatNetMessage Error: friends_player_id is nil' ) end 
	self:formatuint(msg,content.friends_player_id)
end

function NetProtocalPaser:formatrecv_friends_list(msg, content) 
	if(content.count == nil) then print('formatNetMessage Error: count is nil' ) end 
	self:formatushort(msg,content.count)
	self:formatArray(msg,content.list,'recv_friends')
end

function NetProtocalPaser:formatsend_player_find_list(msg, content) 
	if(content.player_name == nil) then print('formatNetMessage Error: player_name is nil' ) end 
	self:formatstring(msg,content.player_name)
	if(content.find_type == nil) then print('formatNetMessage Error: find_type is nil' ) end 
	self:formatushort(msg,content.find_type)
	if(content.page == nil) then print('formatNetMessage Error: page is nil' ) end 
	self:formatushort(msg,content.page)
	if(content.size == nil) then print('formatNetMessage Error: size is nil' ) end 
	self:formatushort(msg,content.size)
end

function NetProtocalPaser:formatsend_player_friends_delete(msg, content) 
	if(content.friends_player_id == nil) then print('formatNetMessage Error: friends_player_id is nil' ) end 
	self:formatuint(msg,content.friends_player_id)
end

function NetProtocalPaser:formatrecv_find_player_list(msg, content) 
	if(content.count == nil) then print('formatNetMessage Error: count is nil' ) end 
	self:formatuint(msg,content.count)
	self:formatArray(msg,content.list,'recv_find_player')
end

function NetProtocalPaser:formatrecv_find_player(msg, content) 
	if(content.player_id == nil) then print('formatNetMessage Error: player_id is nil' ) end 
	self:formatuint(msg,content.player_id)
	if(content.player_name == nil) then print('formatNetMessage Error: player_name is nil' ) end 
	self:formatstring(msg,content.player_name)
	if(content.player_lv == nil) then print('formatNetMessage Error: player_lv is nil' ) end 
	self:formatuint(msg,content.player_lv)
	if(content.player_role_id == nil) then print('formatNetMessage Error: player_role_id is nil' ) end 
	self:formatuint(msg,content.player_role_id)
end

function NetProtocalPaser:formatrecv_player_quest_list(msg, content) 
	self:formatArray(msg,content.list,'recv_player_quest')
end

function NetProtocalPaser:formatrecv_player_quest(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatuint(msg,content.id)
	if(content.quest_id == nil) then print('formatNetMessage Error: quest_id is nil' ) end 
	self:formatuint(msg,content.quest_id)
	if(content.quest_status == nil) then print('formatNetMessage Error: quest_status is nil' ) end 
	self:formatshort(msg,content.quest_status)
	if(content.quest_progress == nil) then print('formatNetMessage Error: quest_progress is nil' ) end 
	self:formatrecv_quest_progress(msg,content.quest_progress)
end

function NetProtocalPaser:formatrecv_quest_progress(msg, content) 
	if(content.current == nil) then print('formatNetMessage Error: current is nil' ) end 
	self:formatushort(msg,content.current)
	if(content.total == nil) then print('formatNetMessage Error: total is nil' ) end 
	self:formatushort(msg,content.total)
end

function NetProtocalPaser:formatsend_receive_quest_goods(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatuint(msg,content.id)
end

function NetProtocalPaser:formatrecv_quest_goods(msg, content) 
	if(content.item == nil) then print('formatNetMessage Error: item is nil' ) end 
	self:formatrecv_paygoods(msg,content.item)
end

function NetProtocalPaser:formatrecv_friends_remain_count(msg, content) 
	if(content.count == nil) then print('formatNetMessage Error: count is nil' ) end 
	self:formatuint(msg,content.count)
end

function NetProtocalPaser:formatsend_player_compound_goods_beast(msg, content) 
	if(content.beast_id == nil) then print('formatNetMessage Error: beast_id is nil' ) end 
	self:formatuint(msg,content.beast_id)
end

function NetProtocalPaser:formatsend_player_drama(msg, content) 
	if(content.drama_id == nil) then print('formatNetMessage Error: drama_id is nil' ) end 
	self:formatuint(msg,content.drama_id)
end

function NetProtocalPaser:formatsend_player_boot(msg, content) 
	if(content.boot_id == nil) then print('formatNetMessage Error: boot_id is nil' ) end 
	self:formatuint(msg,content.boot_id)
end

function NetProtocalPaser:formatrecv_friends_mail(msg, content) 
	if(content.mail_id == nil) then print('formatNetMessage Error: mail_id is nil' ) end 
	self:formatuint(msg,content.mail_id)
	if(content.player_id == nil) then print('formatNetMessage Error: player_id is nil' ) end 
	self:formatuint(msg,content.player_id)
	if(content.player_name == nil) then print('formatNetMessage Error: player_name is nil' ) end 
	self:formatstring(msg,content.player_name)
	if(content.mail_title == nil) then print('formatNetMessage Error: mail_title is nil' ) end 
	self:formatstring(msg,content.mail_title)
	if(content.mail_body == nil) then print('formatNetMessage Error: mail_body is nil' ) end 
	self:formatstring(msg,content.mail_body)
	if(content.mail_create_at == nil) then print('formatNetMessage Error: mail_create_at is nil' ) end 
	self:formatstring(msg,content.mail_create_at)
end

function NetProtocalPaser:formatrecv_friends_mail_list(msg, content) 
	self:formatArray(msg,content.list,'recv_friends_mail')
end

function NetProtocalPaser:formatplayer_activity_list(msg, content) 
	if(content.a == nil) then print('formatNetMessage Error: a is nil' ) end 
	self:formatuint(msg,content.a)
end

function NetProtocalPaser:formatrecv_activity_list(msg, content) 
	self:formatArray(msg,content.list,'recv_activity_one')
end

function NetProtocalPaser:formatrecv_activity_one(msg, content) 
	if(content.category == nil) then print('formatNetMessage Error: category is nil' ) end 
	self:formatushort(msg,content.category)
	if(content.activity_a == nil) then print('formatNetMessage Error: activity_a is nil' ) end 
	self:formatuint(msg,content.activity_a)
	if(content.activity_b == nil) then print('formatNetMessage Error: activity_b is nil' ) end 
	self:formatuint(msg,content.activity_b)
	if(content.activity_c == nil) then print('formatNetMessage Error: activity_c is nil' ) end 
	self:formatuint(msg,content.activity_c)
end

function NetProtocalPaser:formatrecv_activity(msg, content) 
	if(content.activity_id == nil) then print('formatNetMessage Error: activity_id is nil' ) end 
	self:formatuint(msg,content.activity_id)
	if(content.chapter_id == nil) then print('formatNetMessage Error: chapter_id is nil' ) end 
	self:formatuint(msg,content.chapter_id)
end

function NetProtocalPaser:formatcondition_list(msg, content) 
	if(content.key == nil) then print('formatNetMessage Error: key is nil' ) end 
	self:formatstring(msg,content.key)
	if(content.condition == nil) then print('formatNetMessage Error: condition is nil' ) end 
	self:formatstring(msg,content.condition)
end

function NetProtocalPaser:formatrecv_player_arena_rank_near(msg, content) 
	if(content.current_rank == nil) then print('formatNetMessage Error: current_rank is nil' ) end 
	self:formatushort(msg,content.current_rank)
	if(content.player_prestige == nil) then print('formatNetMessage Error: player_prestige is nil' ) end 
	self:formatuint(msg,content.player_prestige)
	if(content.remaining_number == nil) then print('formatNetMessage Error: remaining_number is nil' ) end 
	self:formatushort(msg,content.remaining_number)
	if(content.max_limit == nil) then print('formatNetMessage Error: max_limit is nil' ) end 
	self:formatushort(msg,content.max_limit)
	self:formatArray(msg,content.list,'recv_player_arena_rank')
end

function NetProtocalPaser:formatrecv_player_arena_rank(msg, content) 
	if(content.player_id == nil) then print('formatNetMessage Error: player_id is nil' ) end 
	self:formatuint(msg,content.player_id)
	if(content.player_lv == nil) then print('formatNetMessage Error: player_lv is nil' ) end 
	self:formatushort(msg,content.player_lv)
	if(content.player_name == nil) then print('formatNetMessage Error: player_name is nil' ) end 
	self:formatstring(msg,content.player_name)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatushort(msg,content.rank)
	self:formatArray(msg,content.team,'recv_player_hero')
	if(content.rank_reward == nil) then print('formatNetMessage Error: rank_reward is nil' ) end 
	self:formatrecv_paygoods(msg,content.rank_reward)
	if(content.recv_reward_time == nil) then print('formatNetMessage Error: recv_reward_time is nil' ) end 
	self:formatinteger(msg,content.recv_reward_time)
end

function NetProtocalPaser:formatrecv_player_beast_list(msg, content) 
	self:formatArray(msg,content.list,'recv_player_beast')
end

function NetProtocalPaser:formatsynthesis_goods_list(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
	if(content.goods_num == nil) then print('formatNetMessage Error: goods_num is nil' ) end 
	self:formatushort(msg,content.goods_num)
end

function NetProtocalPaser:formatrecv_player_beast(msg, content) 
	if(content.beast_id == nil) then print('formatNetMessage Error: beast_id is nil' ) end 
	self:formatuint(msg,content.beast_id)
	self:formatArray(msg,content.synthesis_goods,'synthesis_goods_list')
	if(content.activate_status == nil) then print('formatNetMessage Error: activate_status is nil' ) end 
	self:formatushort(msg,content.activate_status)
	if(content.cool_down == nil) then print('formatNetMessage Error: cool_down is nil' ) end 
	self:formatuint(msg,content.cool_down)
	if(content.played == nil) then print('formatNetMessage Error: played is nil' ) end 
	self:formatushort(msg,content.played)
end

function NetProtocalPaser:formatrecv_player_exchanges(msg, content) 
	if(content.refresh_time == nil) then print('formatNetMessage Error: refresh_time is nil' ) end 
	self:formatstring(msg,content.refresh_time)
	if(content.player_prestige == nil) then print('formatNetMessage Error: player_prestige is nil' ) end 
	self:formatuint(msg,content.player_prestige)
	self:formatArray(msg,content.goods,'recv_exchange_goods')
	if(content.refresh_price == nil) then print('formatNetMessage Error: refresh_price is nil' ) end 
	self:formatrecv_goods_price(msg,content.refresh_price)
	if(content.refresh_current_num == nil) then print('formatNetMessage Error: refresh_current_num is nil' ) end 
	self:formatushort(msg,content.refresh_current_num)
	if(content.refresh_limit_num == nil) then print('formatNetMessage Error: refresh_limit_num is nil' ) end 
	self:formatushort(msg,content.refresh_limit_num)
end

function NetProtocalPaser:formatrecv_exchange_goods(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
	if(content.goods_num == nil) then print('formatNetMessage Error: goods_num is nil' ) end 
	self:formatushort(msg,content.goods_num)
	if(content.exchange_num == nil) then print('formatNetMessage Error: exchange_num is nil' ) end 
	self:formatushort(msg,content.exchange_num)
	if(content.prestige == nil) then print('formatNetMessage Error: prestige is nil' ) end 
	self:formatuint(msg,content.prestige)
end

function NetProtocalPaser:formatsend_exchange_goods(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
end

function NetProtocalPaser:formatrecv_player_arena_battle_report_list(msg, content) 
	self:formatArray(msg,content.list,'recv_player_arena_battle_report')
end

function NetProtocalPaser:formatrecv_player_arena_battle_report(msg, content) 
	if(content.battle_type == nil) then print('formatNetMessage Error: battle_type is nil' ) end 
	self:formatshort(msg,content.battle_type)
	if(content.battle_player_id == nil) then print('formatNetMessage Error: battle_player_id is nil' ) end 
	self:formatuint(msg,content.battle_player_id)
	if(content.battle_player_name == nil) then print('formatNetMessage Error: battle_player_name is nil' ) end 
	self:formatstring(msg,content.battle_player_name)
	if(content.is_victory == nil) then print('formatNetMessage Error: is_victory is nil' ) end 
	self:formatboolean(msg,content.is_victory)
	if(content.rank == nil) then print('formatNetMessage Error: rank is nil' ) end 
	self:formatushort(msg,content.rank)
	if(content.battle_datetime == nil) then print('formatNetMessage Error: battle_datetime is nil' ) end 
	self:formatstring(msg,content.battle_datetime)
end

function NetProtocalPaser:formatsned_player_activity_verify(msg, content) 
	if(content.activity_id == nil) then print('formatNetMessage Error: activity_id is nil' ) end 
	self:formatuint(msg,content.activity_id)
	if(content.category == nil) then print('formatNetMessage Error: category is nil' ) end 
	self:formatuint(msg,content.category)
end

function NetProtocalPaser:formatrecv_player_activity_verify(msg, content) 
	if(content.activity_id == nil) then print('formatNetMessage Error: activity_id is nil' ) end 
	self:formatuint(msg,content.activity_id)
	if(content.status == nil) then print('formatNetMessage Error: status is nil' ) end 
	self:formatushort(msg,content.status)
end

function NetProtocalPaser:formatsend_player_challenge_arena(msg, content) 
	if(content.enemy_player_id == nil) then print('formatNetMessage Error: enemy_player_id is nil' ) end 
	self:formatuint(msg,content.enemy_player_id)
end

function NetProtocalPaser:formatsend_player_besat_played(msg, content) 
	if(content.beast_id == nil) then print('formatNetMessage Error: beast_id is nil' ) end 
	self:formatuint(msg,content.beast_id)
end

function NetProtocalPaser:formatsend_player_hero_skill_up(msg, content) 
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
	if(content.skill_id == nil) then print('formatNetMessage Error: skill_id is nil' ) end 
	self:formatuint(msg,content.skill_id)
end

function NetProtocalPaser:formatsend_player_skill_release_up(msg, content) 
	if(content.a == nil) then print('formatNetMessage Error: a is nil' ) end 
	self:formatushort(msg,content.a)
end

function NetProtocalPaser:formatrecv_player_hero_skill_time(msg, content) 
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatuint(msg,content.time)
end

function NetProtocalPaser:formatrecv_system_conf_data(msg, content) 
	self:formatArray(msg,content.list,'system_conf_data')
end

function NetProtocalPaser:formatsystem_conf_data(msg, content) 
	if(content.key == nil) then print('formatNetMessage Error: key is nil' ) end 
	self:formatstring(msg,content.key)
	if(content.val == nil) then print('formatNetMessage Error: val is nil' ) end 
	self:formatstring(msg,content.val)
end

function NetProtocalPaser:formatrecv_shop_goods_list(msg, content) 
	self:formatArray(msg,content.list,'recv_shop_goods')
end

function NetProtocalPaser:formatrecv_shop_goods(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatuint(msg,content.id)
	if(content.shop_no == nil) then print('formatNetMessage Error: shop_no is nil' ) end 
	self:formatshort(msg,content.shop_no)
	if(content.shop_sort == nil) then print('formatNetMessage Error: shop_sort is nil' ) end 
	self:formatushort(msg,content.shop_sort)
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
	if(content.goods_num == nil) then print('formatNetMessage Error: goods_num is nil' ) end 
	self:formatushort(msg,content.goods_num)
	if(content.buy_limit == nil) then print('formatNetMessage Error: buy_limit is nil' ) end 
	self:formatshort(msg,content.buy_limit)
	if(content.goods_price == nil) then print('formatNetMessage Error: goods_price is nil' ) end 
	self:formatrecv_goods_price(msg,content.goods_price)
	if(content.goods_free_time == nil) then print('formatNetMessage Error: goods_free_time is nil' ) end 
	self:formatinteger(msg,content.goods_free_time)
	if(content.goods_give == nil) then print('formatNetMessage Error: goods_give is nil' ) end 
	self:formatuint(msg,content.goods_give)
	if(content.shop_artno == nil) then print('formatNetMessage Error: shop_artno is nil' ) end 
	self:formatstring(msg,content.shop_artno)
end

function NetProtocalPaser:formatrecv_goods_price(msg, content) 
	if(content.type == nil) then print('formatNetMessage Error: type is nil' ) end 
	self:formatstring(msg,content.type)
	if(content.price == nil) then print('formatNetMessage Error: price is nil' ) end 
	self:formatuint(msg,content.price)
end

function NetProtocalPaser:formatsend_buy_goods(msg, content) 
	if(content.id == nil) then print('formatNetMessage Error: id is nil' ) end 
	self:formatuint(msg,content.id)
	if(content.goods_num == nil) then print('formatNetMessage Error: goods_num is nil' ) end 
	self:formatushort(msg,content.goods_num)
end

function NetProtocalPaser:formatrecv_buy_goods_data(msg, content) 
	if(content.shop_no == nil) then print('formatNetMessage Error: shop_no is nil' ) end 
	self:formatshort(msg,content.shop_no)
	if(content.items == nil) then print('formatNetMessage Error: items is nil' ) end 
	self:formatrecv_buy_goods(msg,content.items)
end

function NetProtocalPaser:formatrecv_buy_goods(msg, content) 
	self:formatArray(msg,content.goods,'recv_goods')
	self:formatArray(msg,content.hero,'recv_hero')
	self:formatArray(msg,content.other,'recv_goods_price')
end

function NetProtocalPaser:formatrecv_activity_residue_list(msg, content) 
	self:formatArray(msg,content.list,'recv_activity_residue')
end

function NetProtocalPaser:formatrecv_activity_residue(msg, content) 
	if(content.category == nil) then print('formatNetMessage Error: category is nil' ) end 
	self:formatuint(msg,content.category)
	if(content.num == nil) then print('formatNetMessage Error: num is nil' ) end 
	self:formatuint(msg,content.num)
end

function NetProtocalPaser:formatvit_release_up(msg, content) 
	if(content.a == nil) then print('formatNetMessage Error: a is nil' ) end 
	self:formatushort(msg,content.a)
end

function NetProtocalPaser:formatrecv_vit_release_up(msg, content) 
	if(content.time == nil) then print('formatNetMessage Error: time is nil' ) end 
	self:formatuint(msg,content.time)
end

function NetProtocalPaser:formatrecv_player_friends_delete(msg, content) 
	if(content.friends_player_id == nil) then print('formatNetMessage Error: friends_player_id is nil' ) end 
	self:formatuint(msg,content.friends_player_id)
end

function NetProtocalPaser:formatsend_hero_fragments_synthetic(msg, content) 
	if(content.goods_id == nil) then print('formatNetMessage Error: goods_id is nil' ) end 
	self:formatuint(msg,content.goods_id)
end

function NetProtocalPaser:formatsend_player_hero_sell(msg, content) 
	if(content.player_hero_id == nil) then print('formatNetMessage Error: player_hero_id is nil' ) end 
	self:formatuint(msg,content.player_hero_id)
end

