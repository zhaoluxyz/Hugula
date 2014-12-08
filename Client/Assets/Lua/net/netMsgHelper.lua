NetMsgHelper={}
function NetMsgHelper:makept_pkid(id) 
	local t = {}
	t["id"]=id
	return t
end

function NetMsgHelper:makesend_check_version(os) 
	local t = {}
	t["os"]=os
	return t
end

function NetMsgHelper:makerecv_check_version(game_ver,res_ver) 
	local t = {}
	t["game_ver"]=game_ver
	t["res_ver"]=res_ver
	return t
end

function NetMsgHelper:makeplayer_anonymouslogin(udid,os,token) 
	local t = {}
	t["udid"]=udid
	t["os"]=os
	t["token"]=token
	return t
end

function NetMsgHelper:makept_game_serverlist(udid) 
	local t = {}
	t["udid"]=udid
	return t
end

function NetMsgHelper:makept_gs_login(udid,sid,player_id) 
	local t = {}
	t["udid"]=udid
	t["sid"]=sid
	t["player_id"]=player_id
	return t
end

function NetMsgHelper:makept_gs_good(command) 
	local t = {}
	t["command"]=command
	return t
end

function NetMsgHelper:makept_gs_bad(command,errno) 
	local t = {}
	t["command"]=command
	t["errno"]=errno
	return t
end

function NetMsgHelper:makept_int(i) 
	local t = {}
	t["i"]=i
	return t
end

function NetMsgHelper:makerecv_player_hero(player_hero_id,system_hero_id,player_hero_lv,player_hero_exp,pt_hero_attribute,player_hero_color,pt_pkid,pt_hero_skill,player_hero_next_exp,pos,player_hero_num,hero_group_id,player_hero_strengthen_rate,player_hero_strengthen,pt_hero_skill) 
	local t = {}
	t["player_hero_id"]=player_hero_id
	t["system_hero_id"]=system_hero_id
	t["player_hero_lv"]=player_hero_lv
	t["player_hero_exp"]=player_hero_exp
	t["player_hero_attribute"]=pt_hero_attribute
	t["player_hero_color"]=player_hero_color
	t["player_hero_equip"]=pt_pkid
	t["player_hero_skill"]=pt_hero_skill
	t["player_hero_next_exp"]=player_hero_next_exp
	t["pos"]=pos
	t["player_hero_num"]=player_hero_num
	t["hero_group_id"]=hero_group_id
	t["player_hero_strengthen_rate"]=player_hero_strengthen_rate
	t["player_hero_strengthen"]=player_hero_strengthen
	t["hero_skill"]=pt_hero_skill
	return t
end

function NetMsgHelper:makesend_player_hero_list(profession_category,page,size) 
	local t = {}
	t["profession_category"]=profession_category
	t["page"]=page
	t["size"]=size
	return t
end

function NetMsgHelper:makerecv_player_team(player_hero_id,system_hero_id,player_hero_lv,player_hero_exp,pt_hero_attribute,player_hero_color,pt_pkid,pt_hero_skill,pos,player_hero_next_exp,hero_group_id,player_hero_strengthen_rate,player_hero_strengthen,pt_hero_skill) 
	local t = {}
	t["player_hero_id"]=player_hero_id
	t["system_hero_id"]=system_hero_id
	t["player_hero_lv"]=player_hero_lv
	t["player_hero_exp"]=player_hero_exp
	t["player_hero_attribute"]=pt_hero_attribute
	t["player_hero_color"]=player_hero_color
	t["player_hero_equip"]=pt_pkid
	t["player_hero_skill"]=pt_hero_skill
	t["pos"]=pos
	t["player_hero_next_exp"]=player_hero_next_exp
	t["hero_group_id"]=hero_group_id
	t["player_hero_strengthen_rate"]=player_hero_strengthen_rate
	t["player_hero_strengthen"]=player_hero_strengthen
	t["hero_skill"]=pt_hero_skill
	return t
end

function NetMsgHelper:makept_player_team(recv_player_team) 
	local t = {}
	t["team"]=recv_player_team
	return t
end

function NetMsgHelper:makept_player_hero(count,recv_player_hero) 
	local t = {}
	t["count"]=count
	t["heros"]=recv_player_hero
	return t
end

function NetMsgHelper:makerecv_player_hero_list(recv_player_hero) 
	local t = {}
	t["heros"]=recv_player_hero
	return t
end

function NetMsgHelper:makesend_player_chapter(parent) 
	local t = {}
	t["parent"]=parent
	return t
end

function NetMsgHelper:makerecv_chapter_list(chapter_id,chapter_star,chapter_fastest_record,chapter_my_record,chapter_residue_number) 
	local t = {}
	t["chapter_id"]=chapter_id
	t["chapter_star"]=chapter_star
	t["chapter_fastest_record"]=chapter_fastest_record
	t["chapter_my_record"]=chapter_my_record
	t["chapter_residue_number"]=chapter_residue_number
	return t
end

function NetMsgHelper:makept_player_chapter_list(recv_chapter_list) 
	local t = {}
	t["list"]=recv_chapter_list
	return t
end

function NetMsgHelper:makesend_challenge_chapter(chapter_id) 
	local t = {}
	t["chapter_id"]=chapter_id
	return t
end

function NetMsgHelper:makept_character_attribute_a(gold,crystal,vit,exp,player_friendship,player_prestige,player_arena_number,player_skill_points,lv,max_lv,max_exp,vit_limit,pt_hero_attribute) 
	local t = {}
	t["gold"]=gold
	t["crystal"]=crystal
	t["vit"]=vit
	t["exp"]=exp
	t["player_friendship"]=player_friendship
	t["player_prestige"]=player_prestige
	t["player_arena_number"]=player_arena_number
	t["player_skill_points"]=player_skill_points
	t["lv"]=lv
	t["max_lv"]=max_lv
	t["max_exp"]=max_exp
	t["vit_limit"]=vit_limit
	t["attribute"]=pt_hero_attribute
	return t
end

function NetMsgHelper:makesend_player_challenge_chapter_start(chapter_id) 
	local t = {}
	t["chapter_id"]=chapter_id
	return t
end

function NetMsgHelper:makerecv_challenge_chapter_result(victory,star,recv_paygoods) 
	local t = {}
	t["victory"]=victory
	t["star"]=star
	t["drop"]=recv_paygoods
	return t
end

function NetMsgHelper:makerecv_player_sweep_chapter(recv_paygoods) 
	local t = {}
	t["drop"]=recv_paygoods
	return t
end

function NetMsgHelper:makerecv_challenge_chapter_result_hero(player_hero_id,system_hero_id,exp,isup,max_exp,cur_exp,hero_lv) 
	local t = {}
	t["player_hero_id"]=player_hero_id
	t["system_hero_id"]=system_hero_id
	t["exp"]=exp
	t["isup"]=isup
	t["max_exp"]=max_exp
	t["cur_exp"]=cur_exp
	t["hero_lv"]=hero_lv
	return t
end

function NetMsgHelper:makerecv_goods(goods_id,goods_num,goods_type) 
	local t = {}
	t["goods_id"]=goods_id
	t["goods_num"]=goods_num
	t["goods_type"]=goods_type
	return t
end

function NetMsgHelper:makerecv_hero(hero_id,hero_num) 
	local t = {}
	t["hero_id"]=hero_id
	t["hero_num"]=hero_num
	return t
end

function NetMsgHelper:makept_hero_attribute(hp,mp,maxHp,maxMp,damage,defend,magicDamage,magicDefend,critValue,dodgeValue,speed,attackSpeed,turnSpeed,rangeVisible) 
	local t = {}
	t["hp"]=hp
	t["mp"]=mp
	t["maxHp"]=maxHp
	t["maxMp"]=maxMp
	t["damage"]=damage
	t["defend"]=defend
	t["magicDamage"]=magicDamage
	t["magicDefend"]=magicDefend
	t["critValue"]=critValue
	t["dodgeValue"]=dodgeValue
	t["speed"]=speed
	t["attackSpeed"]=attackSpeed
	t["turnSpeed"]=turnSpeed
	t["rangeVisible"]=rangeVisible
	return t
end

function NetMsgHelper:makerecv_paygoods(gold,crystal,recv_goods,recv_hero,recv_challenge_chapter_result_hero,player_vit,player_exp,player_cur_exp,player_lv,player_is_up,player_prestige) 
	local t = {}
	t["gold"]=gold
	t["crystal"]=crystal
	t["goods"]=recv_goods
	t["heros"]=recv_hero
	t["hero_exp"]=recv_challenge_chapter_result_hero
	t["player_vit"]=player_vit
	t["player_exp"]=player_exp
	t["player_cur_exp"]=player_cur_exp
	t["player_lv"]=player_lv
	t["player_is_up"]=player_is_up
	t["player_prestige"]=player_prestige
	return t
end

function NetMsgHelper:makept_paygoods(recv_paygoods) 
	local t = {}
	t["goods"]=recv_paygoods
	return t
end

function NetMsgHelper:makerecv_player_bag_goods(recv_goods) 
	local t = {}
	t["goods"]=recv_goods
	return t
end

function NetMsgHelper:makept_use_goods(goods_id,goods_num) 
	local t = {}
	t["goods_id"]=goods_id
	t["goods_num"]=goods_num
	return t
end

function NetMsgHelper:makesend_hero_goods_use(goods_id,goods_num,player_hero_id) 
	local t = {}
	t["goods_id"]=goods_id
	t["goods_num"]=goods_num
	t["player_hero_id"]=player_hero_id
	return t
end

function NetMsgHelper:makesend_change_player_team_up(player_hero_id,pos) 
	local t = {}
	t["player_hero_id"]=player_hero_id
	t["pos"]=pos
	return t
end

function NetMsgHelper:makesend_change_player_team_down(pos) 
	local t = {}
	t["pos"]=pos
	return t
end

function NetMsgHelper:makesend_player_goods_sell(goods_id,goods_num) 
	local t = {}
	t["goods_id"]=goods_id
	t["goods_num"]=goods_num
	return t
end

function NetMsgHelper:makesend_player_hero_equip_up(goods_id,player_hero_id) 
	local t = {}
	t["goods_id"]=goods_id
	t["player_hero_id"]=player_hero_id
	return t
end

function NetMsgHelper:makesend_player_hero_advanced(player_hero_id) 
	local t = {}
	t["player_hero_id"]=player_hero_id
	return t
end

function NetMsgHelper:makept_hero_skill(id,lv) 
	local t = {}
	t["id"]=id
	t["lv"]=lv
	return t
end

function NetMsgHelper:makesend_kill_monster(chapter_id,monster_id) 
	local t = {}
	t["chapter_id"]=chapter_id
	t["monster_id"]=monster_id
	return t
end

function NetMsgHelper:makerecv_monster(id,system_hero_id,hero_group_id,hero_brain,pt_pos,pt_hero_attribute,pt_hero_skill) 
	local t = {}
	t["id"]=id
	t["system_hero_id"]=system_hero_id
	t["hero_group_id"]=hero_group_id
	t["hero_brain"]=hero_brain
	t["pos"]=pt_pos
	t["player_hero_attribute"]=pt_hero_attribute
	t["player_hero_skill"]=pt_hero_skill
	return t
end

function NetMsgHelper:makerecv_monster_list(recv_monster,round,count_round,team) 
	local t = {}
	t["monster"]=recv_monster
	t["round"]=round
	t["count_round"]=count_round
	t["team"]=team
	return t
end

function NetMsgHelper:makerecv_player_challenge_chapter(chapter_type,chapter_id,pt_pkid,pt_hero_skill,recv_stronghold_army) 
	local t = {}
	t["chapter_type"]=chapter_type
	t["chapter_id"]=chapter_id
	t["hero_group_ids"]=pt_pkid
	t["hero_skill_ids"]=pt_hero_skill
	t["stronghold"]=recv_stronghold_army
	return t
end

function NetMsgHelper:makerecv_stronghold_army(hero_id,hero_group_id,recv_monster) 
	local t = {}
	t["hero_id"]=hero_id
	t["hero_group_id"]=hero_group_id
	t["army"]=recv_monster
	return t
end

function NetMsgHelper:makesend_player_mail_list(max_mail_id) 
	local t = {}
	t["max_mail_id"]=max_mail_id
	return t
end

function NetMsgHelper:makerecv_mail(mail_id,mail_group,player_id,player_name,mail_title,mail_body,recv_paygoods,mail_status,mail_create_at) 
	local t = {}
	t["mail_id"]=mail_id
	t["mail_group"]=mail_group
	t["player_id"]=player_id
	t["player_name"]=player_name
	t["mail_title"]=mail_title
	t["mail_body"]=mail_body
	t["mail_goods"]=recv_paygoods
	t["mail_status"]=mail_status
	t["mail_create_at"]=mail_create_at
	return t
end

function NetMsgHelper:makerecv_mail_list(recv_mail) 
	local t = {}
	t["list"]=recv_mail
	return t
end

function NetMsgHelper:makesend_player_mail_goods(mail_id) 
	local t = {}
	t["mail_id"]=mail_id
	return t
end

function NetMsgHelper:makesend_player_mail_read(mail_id) 
	local t = {}
	t["mail_id"]=mail_id
	return t
end

function NetMsgHelper:makerecv_mail_content(recv_mail) 
	local t = {}
	t["list"]=recv_mail
	return t
end

function NetMsgHelper:makesend_player_mail_delete(mail_id) 
	local t = {}
	t["mail_id"]=mail_id
	return t
end

function NetMsgHelper:makerecv_broadcast_message(channel_id,type,body,sender_player_id,sender_player_role,sender_player_name,create_at) 
	local t = {}
	t["channel_id"]=channel_id
	t["type"]=type
	t["body"]=body
	t["sender_player_id"]=sender_player_id
	t["sender_player_role"]=sender_player_role
	t["sender_player_name"]=sender_player_name
	t["create_at"]=create_at
	return t
end

function NetMsgHelper:makesend_chat(channel_id,to_player_id,message) 
	local t = {}
	t["channel_id"]=channel_id
	t["to_player_id"]=to_player_id
	t["message"]=message
	return t
end

function NetMsgHelper:makesend_hero_equip_synthesis(goods_id) 
	local t = {}
	t["goods_id"]=goods_id
	return t
end

function NetMsgHelper:makept_pos(x,y,z) 
	local t = {}
	t["x"]=x
	t["y"]=y
	t["z"]=z
	return t
end

function NetMsgHelper:makesend_mail(recv_mail) 
	local t = {}
	t["list"]=recv_mail
	return t
end

function NetMsgHelper:makerecv_mail_count(count) 
	local t = {}
	t["count"]=count
	return t
end

function NetMsgHelper:makerecv_friends_remain_count(count) 
	local t = {}
	t["count"]=count
	return t
end

function NetMsgHelper:makesend_player_send_mail(to_player_id,mail_title,mail_body) 
	local t = {}
	t["to_player_id"]=to_player_id
	t["mail_title"]=mail_title
	t["mail_body"]=mail_body
	return t
end

function NetMsgHelper:makesend_player_hero_strengthen(player_hero_idl,player_hero_idr) 
	local t = {}
	t["player_hero_idl"]=player_hero_idl
	t["player_hero_idr"]=player_hero_idr
	return t
end

function NetMsgHelper:makerecv_player_hero_strengthen(success) 
	local t = {}
	t["success"]=success
	return t
end

function NetMsgHelper:makesend_hero_hero_synthesis(player_hero_idl,player_hero_idr) 
	local t = {}
	t["player_hero_idl"]=player_hero_idl
	t["player_hero_idr"]=player_hero_idr
	return t
end

function NetMsgHelper:makesend_player_reward_data(a) 
	local t = {}
	t["a"]=a
	return t
end

function NetMsgHelper:makerecv_reward_data(player_week,player_day,reward_status) 
	local t = {}
	t["player_week"]=player_week
	t["player_day"]=player_day
	t["reward_status"]=reward_status
	return t
end

function NetMsgHelper:makesend_player_reward_login(player_week,player_day) 
	local t = {}
	t["player_week"]=player_week
	t["player_day"]=player_day
	return t
end

function NetMsgHelper:makesend_player_hero_stlas_list(a) 
	local t = {}
	t["a"]=a
	return t
end

function NetMsgHelper:makerecv_hero_atlas(system_hero_id,player_hero_lv) 
	local t = {}
	t["system_hero_id"]=system_hero_id
	t["player_hero_lv"]=player_hero_lv
	return t
end

function NetMsgHelper:makerecv_hero_atlas_list(recv_hero_atlas) 
	local t = {}
	t["list"]=recv_hero_atlas
	return t
end

function NetMsgHelper:makesend_apply_friends_apply(friends_player_id) 
	local t = {}
	t["friends_player_id"]=friends_player_id
	return t
end

function NetMsgHelper:makerecv_friends_apply(player_name,player_lv,player_role_id,player_id) 
	local t = {}
	t["player_name"]=player_name
	t["player_lv"]=player_lv
	t["player_role_id"]=player_role_id
	t["player_id"]=player_id
	return t
end

function NetMsgHelper:makerecv_friends_apply_list(count,recv_friends_apply) 
	local t = {}
	t["count"]=count
	t["list"]=recv_friends_apply
	return t
end

function NetMsgHelper:makesend_request_friends_apply(friends_player_id,status) 
	local t = {}
	t["friends_player_id"]=friends_player_id
	t["status"]=status
	return t
end

function NetMsgHelper:makerecv_friends_request(friends_player_id,friends_player_name,status) 
	local t = {}
	t["friends_player_id"]=friends_player_id
	t["friends_player_name"]=friends_player_name
	t["status"]=status
	return t
end

function NetMsgHelper:makesend_friends_list(page,size) 
	local t = {}
	t["page"]=page
	t["size"]=size
	return t
end

function NetMsgHelper:makerecv_friends(friends_player_id,friends_player_lv,friends_player_role_id,friends_player_name,give_away_friendship,cool_down) 
	local t = {}
	t["friends_player_id"]=friends_player_id
	t["friends_player_lv"]=friends_player_lv
	t["friends_player_role_id"]=friends_player_role_id
	t["friends_player_name"]=friends_player_name
	t["give_away_friendship"]=give_away_friendship
	t["cool_down"]=cool_down
	return t
end

function NetMsgHelper:makesend_reveive_friendship(friends_player_id) 
	local t = {}
	t["friends_player_id"]=friends_player_id
	return t
end

function NetMsgHelper:makesend_reveive_friendship_pick_up(a) 
	local t = {}
	t["a"]=a
	return t
end

function NetMsgHelper:makesend_value_friendship(friends_player_id) 
	local t = {}
	t["friends_player_id"]=friends_player_id
	return t
end

function NetMsgHelper:makerecv_friends_list(count,recv_friends) 
	local t = {}
	t["count"]=count
	t["list"]=recv_friends
	return t
end

function NetMsgHelper:makesend_player_find_list(player_name,find_type,page,size) 
	local t = {}
	t["player_name"]=player_name
	t["find_type"]=find_type
	t["page"]=page
	t["size"]=size
	return t
end

function NetMsgHelper:makesend_player_friends_delete(friends_player_id) 
	local t = {}
	t["friends_player_id"]=friends_player_id
	return t
end

function NetMsgHelper:makerecv_find_player_list(count,recv_find_player) 
	local t = {}
	t["count"]=count
	t["list"]=recv_find_player
	return t
end

function NetMsgHelper:makerecv_find_player(player_id,player_name,player_lv,player_role_id) 
	local t = {}
	t["player_id"]=player_id
	t["player_name"]=player_name
	t["player_lv"]=player_lv
	t["player_role_id"]=player_role_id
	return t
end

function NetMsgHelper:makerecv_player_quest_list(recv_player_quest) 
	local t = {}
	t["list"]=recv_player_quest
	return t
end

function NetMsgHelper:makerecv_player_quest(id,quest_id,quest_status,recv_quest_progress) 
	local t = {}
	t["id"]=id
	t["quest_id"]=quest_id
	t["quest_status"]=quest_status
	t["quest_progress"]=recv_quest_progress
	return t
end

function NetMsgHelper:makerecv_quest_progress(current,total) 
	local t = {}
	t["current"]=current
	t["total"]=total
	return t
end

function NetMsgHelper:makesend_receive_quest_goods(id) 
	local t = {}
	t["id"]=id
	return t
end

function NetMsgHelper:makerecv_quest_goods(recv_paygoods) 
	local t = {}
	t["item"]=recv_paygoods
	return t
end

function NetMsgHelper:makerecv_friends_remain_count(count) 
	local t = {}
	t["count"]=count
	return t
end

function NetMsgHelper:makesend_player_compound_goods_beast(beast_id) 
	local t = {}
	t["beast_id"]=beast_id
	return t
end

function NetMsgHelper:makesend_player_drama(drama_id) 
	local t = {}
	t["drama_id"]=drama_id
	return t
end

function NetMsgHelper:makesend_player_boot(boot_id) 
	local t = {}
	t["boot_id"]=boot_id
	return t
end

function NetMsgHelper:makerecv_friends_mail(mail_id,player_id,player_name,mail_title,mail_body,mail_create_at) 
	local t = {}
	t["mail_id"]=mail_id
	t["player_id"]=player_id
	t["player_name"]=player_name
	t["mail_title"]=mail_title
	t["mail_body"]=mail_body
	t["mail_create_at"]=mail_create_at
	return t
end

function NetMsgHelper:makerecv_friends_mail_list(recv_friends_mail) 
	local t = {}
	t["list"]=recv_friends_mail
	return t
end

function NetMsgHelper:makeplayer_activity_list(a) 
	local t = {}
	t["a"]=a
	return t
end

function NetMsgHelper:makerecv_activity_list(recv_activity_one) 
	local t = {}
	t["list"]=recv_activity_one
	return t
end

function NetMsgHelper:makerecv_activity_one(category,activity_a,activity_b,activity_c) 
	local t = {}
	t["category"]=category
	t["activity_a"]=activity_a
	t["activity_b"]=activity_b
	t["activity_c"]=activity_c
	return t
end

function NetMsgHelper:makerecv_activity(activity_id,chapter_id) 
	local t = {}
	t["activity_id"]=activity_id
	t["chapter_id"]=chapter_id
	return t
end

function NetMsgHelper:makecondition_list(key,condition) 
	local t = {}
	t["key"]=key
	t["condition"]=condition
	return t
end

function NetMsgHelper:makerecv_player_arena_rank_near(current_rank,player_prestige,remaining_number,max_limit,recv_player_arena_rank) 
	local t = {}
	t["current_rank"]=current_rank
	t["player_prestige"]=player_prestige
	t["remaining_number"]=remaining_number
	t["max_limit"]=max_limit
	t["list"]=recv_player_arena_rank
	return t
end

function NetMsgHelper:makerecv_player_arena_rank(player_id,player_lv,player_name,rank,recv_player_hero,recv_paygoods,recv_reward_time) 
	local t = {}
	t["player_id"]=player_id
	t["player_lv"]=player_lv
	t["player_name"]=player_name
	t["rank"]=rank
	t["team"]=recv_player_hero
	t["rank_reward"]=recv_paygoods
	t["recv_reward_time"]=recv_reward_time
	return t
end

function NetMsgHelper:makerecv_player_beast_list(recv_player_beast) 
	local t = {}
	t["list"]=recv_player_beast
	return t
end

function NetMsgHelper:makesynthesis_goods_list(goods_id,goods_num) 
	local t = {}
	t["goods_id"]=goods_id
	t["goods_num"]=goods_num
	return t
end

function NetMsgHelper:makerecv_player_beast(beast_id,synthesis_goods_list,activate_status,cool_down,played) 
	local t = {}
	t["beast_id"]=beast_id
	t["synthesis_goods"]=synthesis_goods_list
	t["activate_status"]=activate_status
	t["cool_down"]=cool_down
	t["played"]=played
	return t
end

function NetMsgHelper:makerecv_player_exchanges(refresh_time,player_prestige,recv_exchange_goods,recv_goods_price,refresh_current_num,refresh_limit_num) 
	local t = {}
	t["refresh_time"]=refresh_time
	t["player_prestige"]=player_prestige
	t["goods"]=recv_exchange_goods
	t["refresh_price"]=recv_goods_price
	t["refresh_current_num"]=refresh_current_num
	t["refresh_limit_num"]=refresh_limit_num
	return t
end

function NetMsgHelper:makerecv_exchange_goods(goods_id,goods_num,exchange_num,prestige) 
	local t = {}
	t["goods_id"]=goods_id
	t["goods_num"]=goods_num
	t["exchange_num"]=exchange_num
	t["prestige"]=prestige
	return t
end

function NetMsgHelper:makesend_exchange_goods(goods_id) 
	local t = {}
	t["goods_id"]=goods_id
	return t
end

function NetMsgHelper:makerecv_player_arena_battle_report_list(recv_player_arena_battle_report) 
	local t = {}
	t["list"]=recv_player_arena_battle_report
	return t
end

function NetMsgHelper:makerecv_player_arena_battle_report(battle_type,battle_player_id,battle_player_name,is_victory,rank,battle_datetime) 
	local t = {}
	t["battle_type"]=battle_type
	t["battle_player_id"]=battle_player_id
	t["battle_player_name"]=battle_player_name
	t["is_victory"]=is_victory
	t["rank"]=rank
	t["battle_datetime"]=battle_datetime
	return t
end

function NetMsgHelper:makesned_player_activity_verify(activity_id,category) 
	local t = {}
	t["activity_id"]=activity_id
	t["category"]=category
	return t
end

function NetMsgHelper:makerecv_player_activity_verify(activity_id,status) 
	local t = {}
	t["activity_id"]=activity_id
	t["status"]=status
	return t
end

function NetMsgHelper:makesend_player_challenge_arena(enemy_player_id) 
	local t = {}
	t["enemy_player_id"]=enemy_player_id
	return t
end

function NetMsgHelper:makesend_player_besat_played(beast_id) 
	local t = {}
	t["beast_id"]=beast_id
	return t
end

function NetMsgHelper:makesend_player_hero_skill_up(player_hero_id,skill_id) 
	local t = {}
	t["player_hero_id"]=player_hero_id
	t["skill_id"]=skill_id
	return t
end

function NetMsgHelper:makesend_player_skill_release_up(a) 
	local t = {}
	t["a"]=a
	return t
end

function NetMsgHelper:makerecv_player_hero_skill_time(time) 
	local t = {}
	t["time"]=time
	return t
end

function NetMsgHelper:makerecv_system_conf_data(system_conf_data) 
	local t = {}
	t["list"]=system_conf_data
	return t
end

function NetMsgHelper:makesystem_conf_data(key,val) 
	local t = {}
	t["key"]=key
	t["val"]=val
	return t
end

function NetMsgHelper:makerecv_shop_goods_list(recv_shop_goods) 
	local t = {}
	t["list"]=recv_shop_goods
	return t
end

function NetMsgHelper:makerecv_shop_goods(id,shop_no,shop_sort,goods_id,goods_num,buy_limit,recv_goods_price,goods_free_time,goods_give,shop_artno) 
	local t = {}
	t["id"]=id
	t["shop_no"]=shop_no
	t["shop_sort"]=shop_sort
	t["goods_id"]=goods_id
	t["goods_num"]=goods_num
	t["buy_limit"]=buy_limit
	t["goods_price"]=recv_goods_price
	t["goods_free_time"]=goods_free_time
	t["goods_give"]=goods_give
	t["shop_artno"]=shop_artno
	return t
end

function NetMsgHelper:makerecv_goods_price(type,price) 
	local t = {}
	t["type"]=type
	t["price"]=price
	return t
end

function NetMsgHelper:makesend_buy_goods(id,goods_num) 
	local t = {}
	t["id"]=id
	t["goods_num"]=goods_num
	return t
end

function NetMsgHelper:makerecv_buy_goods_data(shop_no,recv_buy_goods) 
	local t = {}
	t["shop_no"]=shop_no
	t["items"]=recv_buy_goods
	return t
end

function NetMsgHelper:makerecv_buy_goods(recv_goods,recv_hero,recv_goods_price) 
	local t = {}
	t["goods"]=recv_goods
	t["hero"]=recv_hero
	t["other"]=recv_goods_price
	return t
end

function NetMsgHelper:makerecv_activity_residue_list(recv_activity_residue) 
	local t = {}
	t["list"]=recv_activity_residue
	return t
end

function NetMsgHelper:makerecv_activity_residue(category,num) 
	local t = {}
	t["category"]=category
	t["num"]=num
	return t
end

function NetMsgHelper:makevit_release_up(a) 
	local t = {}
	t["a"]=a
	return t
end

function NetMsgHelper:makerecv_vit_release_up(time) 
	local t = {}
	t["time"]=time
	return t
end

function NetMsgHelper:makerecv_player_friends_delete(friends_player_id) 
	local t = {}
	t["friends_player_id"]=friends_player_id
	return t
end

function NetMsgHelper:makesend_hero_fragments_synthetic(goods_id) 
	local t = {}
	t["goods_id"]=goods_id
	return t
end

function NetMsgHelper:makesend_player_hero_sell(player_hero_id) 
	local t = {}
	t["player_hero_id"]=player_hero_id
	return t
end

