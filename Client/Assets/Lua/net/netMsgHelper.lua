NetMsgHelper={}
function NetMsgHelper:makept_pkid(id) 
	local t = {}
	t["id"]=id
	return t
end

function NetMsgHelper:makept_pkids(ids) 
	local t = {}
	t["ids"]=ids
	return t
end

function NetMsgHelper:makept_int(i) 
	local t = {}
	t["i"]=i
	return t
end

function NetMsgHelper:makept_code(api,code) 
	local t = {}
	t["api"]=api
	t["code"]=code
	return t
end

function NetMsgHelper:makedb_single(id,user_id,gift_power_date) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["gift_power_date"]=gift_power_date
	return t
end

function NetMsgHelper:makept_ubase(name,sex,account_type,account,token) 
	local t = {}
	t["name"]=name
	t["sex"]=sex
	t["account_type"]=account_type
	t["account"]=account
	t["token"]=token
	return t
end

function NetMsgHelper:makedb_device(id,d_type,udid,os,os_version,market,terminal,lcl,mac_addr,locale) 
	local t = {}
	t["id"]=id
	t["d_type"]=d_type
	t["udid"]=udid
	t["os"]=os
	t["os_version"]=os_version
	t["market"]=market
	t["terminal"]=terminal
	t["lcl"]=lcl
	t["mac_addr"]=mac_addr
	t["locale"]=locale
	return t
end

function NetMsgHelper:makedb_user(id,user_id,device_id,account_type,account,name,sex,icon,power,gift_power,buy_power,level,experience,money,group,story,gold,magic_card,powergift_num,powergift_date,maxfevent) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["device_id"]=device_id
	t["account_type"]=account_type
	t["account"]=account
	t["name"]=name
	t["sex"]=sex
	t["icon"]=icon
	t["power"]=power
	t["gift_power"]=gift_power
	t["buy_power"]=buy_power
	t["level"]=level
	t["experience"]=experience
	t["money"]=money
	t["group"]=group
	t["story"]=story
	t["gold"]=gold
	t["magic_card"]=magic_card
	t["powergift_num"]=powergift_num
	t["powergift_date"]=powergift_date
	t["maxfevent"]=maxfevent
	return t
end

function NetMsgHelper:makerc_buy_times(id,num) 
	local t = {}
	t["id"]=id
	t["num"]=num
	return t
end

function NetMsgHelper:makerc_buy_log(type,rc_buy_times) 
	local t = {}
	t["type"]=type
	t["item"]=rc_buy_times
	return t
end

function NetMsgHelper:makeflrfid(floor,type,id) 
	local t = {}
	t["floor"]=floor
	t["type"]=type
	t["id"]=id
	return t
end

function NetMsgHelper:makemaze_fight(maze,enemy,floor,type,id,refush,step,reset) 
	local t = {}
	t["maze"]=maze
	t["enemy"]=enemy
	t["floor"]=floor
	t["type"]=type
	t["id"]=id
	t["refush"]=refush
	t["step"]=step
	t["reset"]=reset
	return t
end

function NetMsgHelper:makerc_magic_scroll(type,num) 
	local t = {}
	t["type"]=type
	t["num"]=num
	return t
end

function NetMsgHelper:makedb_userinfo(id,user_id,frd_del_num,frd_del_date,cards,runes,maze_fight,star5,rc_buy_log,buy_date,time_power_date,g_power_date,chp_times,chp_win,frd_times,frd_win,monster_add,login_time,logout_time,create_at,rc_magic_scroll,ban,mute,total_charge,lev_prize_date,change_name_num,first_event) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["frd_del_num"]=frd_del_num
	t["frd_del_date"]=frd_del_date
	t["cards"]=cards
	t["runes"]=runes
	t["mazes"]=maze_fight
	t["star5"]=star5
	t["buy_log"]=rc_buy_log
	t["buy_date"]=buy_date
	t["time_power_date"]=time_power_date
	t["g_power_date"]=g_power_date
	t["chp_times"]=chp_times
	t["chp_win"]=chp_win
	t["frd_times"]=frd_times
	t["frd_win"]=frd_win
	t["monster_add"]=monster_add
	t["login_time"]=login_time
	t["logout_time"]=logout_time
	t["create_at"]=create_at
	t["magic_scroll"]=rc_magic_scroll
	t["ban"]=ban
	t["mute"]=mute
	t["total_charge"]=total_charge
	t["lev_prize_date"]=lev_prize_date
	t["change_name_num"]=change_name_num
	t["first_event"]=first_event
	return t
end

function NetMsgHelper:makept_account(pt_ubase,db_device,app_ver) 
	local t = {}
	t["base"]=pt_ubase
	t["device"]=db_device
	t["app_ver"]=app_ver
	return t
end

function NetMsgHelper:makedb_card(id,user_id,base_id,level,experience) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["base_id"]=base_id
	t["level"]=level
	t["experience"]=experience
	return t
end

function NetMsgHelper:makedb_cards(db_card) 
	local t = {}
	t["cards"]=db_card
	return t
end

function NetMsgHelper:makegrune(id,baseid,level) 
	local t = {}
	t["id"]=id
	t["baseid"]=baseid
	t["level"]=level
	return t
end

function NetMsgHelper:makegcard(id,baseid,level) 
	local t = {}
	t["id"]=id
	t["baseid"]=baseid
	t["level"]=level
	return t
end

function NetMsgHelper:makedb_group(id,user_id,runes,cards) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["runes"]=runes
	t["cards"]=cards
	return t
end

function NetMsgHelper:makedb_groups(db_group) 
	local t = {}
	t["groups"]=db_group
	return t
end

function NetMsgHelper:makept_group_ac(id,card) 
	local t = {}
	t["id"]=id
	t["card"]=card
	return t
end

function NetMsgHelper:makept_group_dc(id,card) 
	local t = {}
	t["id"]=id
	t["card"]=card
	return t
end

function NetMsgHelper:makedb_rune(id,user_id,base_id,level,experience) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["base_id"]=base_id
	t["level"]=level
	t["experience"]=experience
	return t
end

function NetMsgHelper:makedb_runes(db_rune) 
	local t = {}
	t["runes"]=db_rune
	return t
end

function NetMsgHelper:makept_group_ar(id,rune) 
	local t = {}
	t["id"]=id
	t["rune"]=rune
	return t
end

function NetMsgHelper:makept_group_dr(id,rune) 
	local t = {}
	t["id"]=id
	t["rune"]=rune
	return t
end

function NetMsgHelper:makedb_story(id,user_id,base_id,finish) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["base_id"]=base_id
	t["finish"]=finish
	return t
end

function NetMsgHelper:makedb_storys(db_story) 
	local t = {}
	t["storys"]=db_story
	return t
end

function NetMsgHelper:makepk_fcard_base(baseId,hp,ad,limit,cost) 
	local t = {}
	t["baseId"]=baseId
	t["hp"]=hp
	t["ad"]=ad
	t["limit"]=limit
	t["cost"]=cost
	return t
end

function NetMsgHelper:makepk_fcard_fight(nowlevel,nowhp,nowat,nowdef,nowmis) 
	local t = {}
	t["nowlevel"]=nowlevel
	t["nowhp"]=nowhp
	t["nowat"]=nowat
	t["nowdef"]=nowdef
	t["nowmis"]=nowmis
	return t
end

function NetMsgHelper:makepk_fcard_temp(tmphp,tmpat,tmpap,tmpdef,tmpres,tmpmis) 
	local t = {}
	t["tmphp"]=tmphp
	t["tmpat"]=tmpat
	t["tmpap"]=tmpap
	t["tmpdef"]=tmpdef
	t["tmpres"]=tmpres
	t["tmpmis"]=tmpmis
	return t
end

function NetMsgHelper:makepk_buff(type,value,number) 
	local t = {}
	t["type"]=type
	t["value"]=value
	t["number"]=number
	return t
end

function NetMsgHelper:makepk_apply(atk,type,def,value) 
	local t = {}
	t["atk"]=atk
	t["type"]=type
	t["def"]=def
	t["value"]=value
	return t
end

function NetMsgHelper:makepk_fcard(idx,pk_fcard_base,pk_fcard_fight) 
	local t = {}
	t["idx"]=idx
	t["fcardbase"]=pk_fcard_base
	t["fcardfight"]=pk_fcard_fight
	return t
end

function NetMsgHelper:makepk_frune(idx,baseid,level,timer) 
	local t = {}
	t["idx"]=idx
	t["baseid"]=baseid
	t["level"]=level
	t["timer"]=timer
	return t
end

function NetMsgHelper:makepk_fight_group(hero,pk_frune,pk_fcard,pk_fcard,pk_fcard,pk_fcard) 
	local t = {}
	t["hero"]=hero
	t["rune"]=pk_frune
	t["home"]=pk_fcard
	t["waiting"]=pk_fcard
	t["fighting"]=pk_fcard
	t["dead"]=pk_fcard
	return t
end

function NetMsgHelper:makepk_area_log(hom,wit,fig,dea) 
	local t = {}
	t["hom"]=hom
	t["wit"]=wit
	t["fig"]=fig
	t["dea"]=dea
	return t
end

function NetMsgHelper:makepk_cres(hp,at,def,mis) 
	local t = {}
	t["hp"]=hp
	t["at"]=at
	t["def"]=def
	t["mis"]=mis
	return t
end

function NetMsgHelper:makepk_move(idx,from,to,pos) 
	local t = {}
	t["idx"]=idx
	t["from"]=from
	t["to"]=to
	t["pos"]=pos
	return t
end

function NetMsgHelper:makepk_flog(type,times,attacker,defender,skillid,target,hero_damage,hero_check,pk_cres,pk_cres,cardfstate,pk_buff,pk_apply,pk_apply,pk_cres,pk_move,pk_cres) 
	local t = {}
	t["type"]=type
	t["times"]=times
	t["attacker"]=attacker
	t["defender"]=defender
	t["skillid"]=skillid
	t["target"]=target
	t["hero_damage"]=hero_damage
	t["hero_check"]=hero_check
	t["cardfres"]=pk_cres
	t["cardfdata"]=pk_cres
	t["cardfstate"]=cardfstate
	t["cardfbuff"]=pk_buff
	t["atkdesc"]=pk_apply
	t["defdesc"]=pk_apply
	t["cardftemp"]=pk_cres
	t["area"]=pk_move
	t["attkerfdata"]=pk_cres
	return t
end

function NetMsgHelper:makepk_clog(a_pos,b_pos) 
	local t = {}
	t["a_pos"]=a_pos
	t["b_pos"]=b_pos
	return t
end

function NetMsgHelper:makepk_round(opts,content) 
	local t = {}
	t["opts"]=opts
	t["content"]=content
	return t
end

function NetMsgHelper:makepk_fight_log(pk_move,pk_move,pk_flog,pk_move,pk_flog,pk_move,pk_flog,pk_move) 
	local t = {}
	t["areaLogCho"]=pk_move
	t["areaLogSen"]=pk_move
	t["fistShowLog"]=pk_flog
	t["areaLogSho"]=pk_move
	t["runeLog"]=pk_flog
	t["areaLogRun"]=pk_move
	t["commonShowLog"]=pk_flog
	t["areaLogCom"]=pk_move
	return t
end

function NetMsgHelper:makepk_record(round,isend,pk_fight_log) 
	local t = {}
	t["round"]=round
	t["isend"]=isend
	t["fightlog"]=pk_fight_log
	return t
end

function NetMsgHelper:makepk_ready(first,pk_fight_group,pk_fight_group) 
	local t = {}
	t["first"]=first
	t["attacker"]=pk_fight_group
	t["defender"]=pk_fight_group
	return t
end

function NetMsgHelper:makepk_fight_data_result(result,totle,pk_ready,pk_record) 
	local t = {}
	t["result"]=result
	t["totle"]=totle
	t["ready"]=pk_ready
	t["recordlist"]=pk_record
	return t
end

function NetMsgHelper:makedb_fightlog(id,user_id,pk_fight_data_result) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["log"]=pk_fight_data_result
	return t
end

function NetMsgHelper:makedb_storylog(id,user_id,fighter,time,log) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["fighter"]=fighter
	t["time"]=time
	t["log"]=log
	return t
end

function NetMsgHelper:makedb_pvplog(id,user_id,enemy,result,value,type,time,log) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["enemy"]=enemy
	t["result"]=result
	t["value"]=value
	t["type"]=type
	t["time"]=time
	t["log"]=log
	return t
end

function NetMsgHelper:makept_pvelog(logid,name,icon,lev) 
	local t = {}
	t["logid"]=logid
	t["name"]=name
	t["icon"]=icon
	t["lev"]=lev
	return t
end

function NetMsgHelper:makept_pvelog_list(story,pt_pvelog) 
	local t = {}
	t["story"]=story
	t["log"]=pt_pvelog
	return t
end

function NetMsgHelper:makept_pvplog(logid,type,enemy,name,icon,lev,rank,score,len_id,len_flag,len_name,result,value,time) 
	local t = {}
	t["logid"]=logid
	t["type"]=type
	t["enemy"]=enemy
	t["name"]=name
	t["icon"]=icon
	t["lev"]=lev
	t["rank"]=rank
	t["score"]=score
	t["len_id"]=len_id
	t["len_flag"]=len_flag
	t["len_name"]=len_name
	t["result"]=result
	t["value"]=value
	t["time"]=time
	return t
end

function NetMsgHelper:makept_pvplog_list(rank,score,pt_pvplog) 
	local t = {}
	t["rank"]=rank
	t["score"]=score
	t["log"]=pt_pvplog
	return t
end

function NetMsgHelper:makept_chat2server(channel,receiveid,content) 
	local t = {}
	t["channel"]=channel
	t["receiveid"]=receiveid
	t["content"]=content
	return t
end

function NetMsgHelper:makept_chat2player(channel,sendid,sendname,sendlevel,sendicon,sendlen_id,sendlen_flag,sendlen_pos,receiveid,receivename,content) 
	local t = {}
	t["channel"]=channel
	t["sendid"]=sendid
	t["sendname"]=sendname
	t["sendlevel"]=sendlevel
	t["sendicon"]=sendicon
	t["sendlen_id"]=sendlen_id
	t["sendlen_flag"]=sendlen_flag
	t["sendlen_pos"]=sendlen_pos
	t["receiveid"]=receiveid
	t["receivename"]=receivename
	t["content"]=content
	return t
end

function NetMsgHelper:makept_crdlist(crdlist) 
	local t = {}
	t["crdlist"]=crdlist
	return t
end

function NetMsgHelper:makedb_friend(id,user_id,frd_id,type) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["frd_id"]=frd_id
	t["type"]=type
	return t
end

function NetMsgHelper:makedb_friends(db_friend) 
	local t = {}
	t["friends"]=db_friend
	return t
end

function NetMsgHelper:makedb_powergift(id,user_id,other_id,self_flag,self_date,other_flag,other_date) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["other_id"]=other_id
	t["self_flag"]=self_flag
	t["self_date"]=self_date
	t["other_flag"]=other_flag
	t["other_date"]=other_date
	return t
end

function NetMsgHelper:makedb_powergifts(db_powergift) 
	local t = {}
	t["gifts"]=db_powergift
	return t
end

function NetMsgHelper:makept_frd_info(user_id,name,sex,icon,level,type) 
	local t = {}
	t["user_id"]=user_id
	t["name"]=name
	t["sex"]=sex
	t["icon"]=icon
	t["level"]=level
	t["type"]=type
	return t
end

function NetMsgHelper:makept_frd_list(pt_frd_info) 
	local t = {}
	t["frd_list"]=pt_frd_info
	return t
end

function NetMsgHelper:makept_frd_init(pt_frd_info) 
	local t = {}
	t["frd_list"]=pt_frd_info
	return t
end

function NetMsgHelper:makept_frd_agree(friend_id,agree) 
	local t = {}
	t["friend_id"]=friend_id
	t["agree"]=agree
	return t
end

function NetMsgHelper:makept_enemy(rank,user_id,name,sex,level,win,lose,getpic,icon) 
	local t = {}
	t["rank"]=rank
	t["user_id"]=user_id
	t["name"]=name
	t["sex"]=sex
	t["level"]=level
	t["win"]=win
	t["lose"]=lose
	t["getpic"]=getpic
	t["icon"]=icon
	return t
end

function NetMsgHelper:makept_all_enemy(pt_enemy) 
	local t = {}
	t["enemy"]=pt_enemy
	return t
end

function NetMsgHelper:makedb_grade(id,user_id,cfg_id,finish_date,finish,gain) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["cfg_id"]=cfg_id
	t["finish_date"]=finish_date
	t["finish"]=finish
	t["gain"]=gain
	return t
end

function NetMsgHelper:makedb_gradeevent(id,user_id,event,condition) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["event"]=event
	t["condition"]=condition
	return t
end

function NetMsgHelper:makept_grade_test(event,condition) 
	local t = {}
	t["event"]=event
	t["condition"]=condition
	return t
end

function NetMsgHelper:makept_grade_info(cfg_id,finish,gain,event) 
	local t = {}
	t["cfg_id"]=cfg_id
	t["finish"]=finish
	t["gain"]=gain
	t["event"]=event
	return t
end

function NetMsgHelper:makept_grade_info_list(pt_grade_info) 
	local t = {}
	t["info"]=pt_grade_info
	return t
end

function NetMsgHelper:makept_card_enhance(id,food) 
	local t = {}
	t["id"]=id
	t["food"]=food
	return t
end

function NetMsgHelper:makept_rune_enhance(id,food) 
	local t = {}
	t["id"]=id
	t["food"]=food
	return t
end

function NetMsgHelper:makerc_chest(type,num) 
	local t = {}
	t["type"]=type
	t["num"]=num
	return t
end

function NetMsgHelper:makedb_chest(id,user_id,source,time,rc_chest) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["source"]=source
	t["time"]=time
	t["reward"]=rc_chest
	return t
end

function NetMsgHelper:makedb_chests(db_chest) 
	local t = {}
	t["chests"]=db_chest
	return t
end

function NetMsgHelper:makept_prize_test(type,num) 
	local t = {}
	t["type"]=type
	t["num"]=num
	return t
end

function NetMsgHelper:makerc_temple_site(type,id) 
	local t = {}
	t["type"]=type
	t["id"]=id
	return t
end

function NetMsgHelper:makerc_temple_fragment(type,num) 
	local t = {}
	t["type"]=type
	t["num"]=num
	return t
end

function NetMsgHelper:makedb_temple(id,user_id,grade,rc_temple_fragment,rc_temple_site) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["grade"]=grade
	t["fragment_amount"]=rc_temple_fragment
	t["site_goodtype"]=rc_temple_site
	return t
end

function NetMsgHelper:makept_temple_datas(grade,rc_temple_fragment,rc_temple_site) 
	local t = {}
	t["grade"]=grade
	t["fragments"]=rc_temple_fragment
	t["sites"]=rc_temple_site
	return t
end

function NetMsgHelper:makept_mapinfo(mapid,storyid,invade) 
	local t = {}
	t["mapid"]=mapid
	t["storyid"]=storyid
	t["invade"]=invade
	return t
end

function NetMsgHelper:makept_nadainfo(nadaid) 
	local t = {}
	t["nadaid"]=nadaid
	return t
end

function NetMsgHelper:makedb_legion(id,user_id,name,remark,flag,lock,lev,exp,guard,del_num,del_time) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["name"]=name
	t["remark"]=remark
	t["flag"]=flag
	t["lock"]=lock
	t["lev"]=lev
	t["exp"]=exp
	t["guard"]=guard
	t["del_num"]=del_num
	t["del_time"]=del_time
	return t
end

function NetMsgHelper:makedb_lenmeb(id,user_id,player_id,pos,devote,join_time,doe_money,doe_gold,doe_date) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["player_id"]=player_id
	t["pos"]=pos
	t["devote"]=devote
	t["join_time"]=join_time
	t["doe_money"]=doe_money
	t["doe_gold"]=doe_gold
	t["doe_date"]=doe_date
	return t
end

function NetMsgHelper:makedb_lenapply(id,user_id,player_id,apply,invite) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["player_id"]=player_id
	t["apply"]=apply
	t["invite"]=invite
	return t
end

function NetMsgHelper:makept_len_info(id,name,remark,exp,lev,flag,lock,meb,rank,score) 
	local t = {}
	t["id"]=id
	t["name"]=name
	t["remark"]=remark
	t["exp"]=exp
	t["lev"]=lev
	t["flag"]=flag
	t["lock"]=lock
	t["meb"]=meb
	t["rank"]=rank
	t["score"]=score
	return t
end

function NetMsgHelper:makept_len_list(pt_len_info) 
	local t = {}
	t["list"]=pt_len_info
	return t
end

function NetMsgHelper:makept_lenmeb_info(id,name,lev,pos,devote,rank,score) 
	local t = {}
	t["id"]=id
	t["name"]=name
	t["lev"]=lev
	t["pos"]=pos
	t["devote"]=devote
	t["rank"]=rank
	t["score"]=score
	return t
end

function NetMsgHelper:makept_lenmeb_list(pt_lenmeb_info) 
	local t = {}
	t["list"]=pt_lenmeb_info
	return t
end

function NetMsgHelper:makept_len_all_info(pt_len_info,pt_lenmeb_info) 
	local t = {}
	t["legion"]=pt_len_info
	t["meb"]=pt_lenmeb_info
	return t
end

function NetMsgHelper:makept_len_create(name) 
	local t = {}
	t["name"]=name
	return t
end

function NetMsgHelper:makept_len_apply(id,name,icon,lev,rank,score) 
	local t = {}
	t["id"]=id
	t["name"]=name
	t["icon"]=icon
	t["lev"]=lev
	t["rank"]=rank
	t["score"]=score
	return t
end

function NetMsgHelper:makept_len_apply_list(pt_len_apply) 
	local t = {}
	t["list"]=pt_len_apply
	return t
end

function NetMsgHelper:makept_len_apply_opr(id,agree) 
	local t = {}
	t["id"]=id
	t["agree"]=agree
	return t
end

function NetMsgHelper:makept_len_devote(type,num) 
	local t = {}
	t["type"]=type
	t["num"]=num
	return t
end

function NetMsgHelper:makept_create_legion(name,remark,flag,lock) 
	local t = {}
	t["name"]=name
	t["remark"]=remark
	t["flag"]=flag
	t["lock"]=lock
	return t
end

function NetMsgHelper:makept_legion_self(legion_id,pos) 
	local t = {}
	t["legion_id"]=legion_id
	t["pos"]=pos
	return t
end

function NetMsgHelper:makept_groupupd_rune(id,runelist) 
	local t = {}
	t["id"]=id
	t["runelist"]=runelist
	return t
end

function NetMsgHelper:makept_groupupd_card(id,cardlist) 
	local t = {}
	t["id"]=id
	t["cardlist"]=cardlist
	return t
end

function NetMsgHelper:makept_prize_get(type,prize) 
	local t = {}
	t["type"]=type
	t["prize"]=prize
	return t
end

function NetMsgHelper:makept_player_report(type,desc) 
	local t = {}
	t["type"]=type
	t["desc"]=desc
	return t
end

function NetMsgHelper:makept_rune_once(runes) 
	local t = {}
	t["runes"]=runes
	return t
end

function NetMsgHelper:makept_maze(maze,enemy,floor,type,id,refush,step,reset) 
	local t = {}
	t["maze"]=maze
	t["enemy"]=enemy
	t["floor"]=floor
	t["type"]=type
	t["id"]=id
	t["refush"]=refush
	t["step"]=step
	t["reset"]=reset
	return t
end

function NetMsgHelper:makept_maze_all(pt_maze) 
	local t = {}
	t["maze"]=pt_maze
	return t
end

function NetMsgHelper:makept_market_item(id,cost,num) 
	local t = {}
	t["id"]=id
	t["cost"]=cost
	t["num"]=num
	return t
end

function NetMsgHelper:makept_market(type,pt_market_item) 
	local t = {}
	t["type"]=type
	t["item"]=pt_market_item
	return t
end

function NetMsgHelper:makept_market_buy(type,id,flag) 
	local t = {}
	t["type"]=type
	t["id"]=id
	t["flag"]=flag
	return t
end

function NetMsgHelper:makept_market_card(type,id,pt_market_item,cards) 
	local t = {}
	t["type"]=type
	t["id"]=id
	t["item"]=pt_market_item
	t["cards"]=cards
	return t
end

function NetMsgHelper:makept_market_gold(type,id,pt_market_item,gold) 
	local t = {}
	t["type"]=type
	t["id"]=id
	t["item"]=pt_market_item
	t["gold"]=gold
	return t
end

function NetMsgHelper:makept_market_power(type,id,pt_market_item,power) 
	local t = {}
	t["type"]=type
	t["id"]=id
	t["item"]=pt_market_item
	t["power"]=power
	return t
end

function NetMsgHelper:makept_ranks_get(id,type) 
	local t = {}
	t["id"]=id
	t["type"]=type
	return t
end

function NetMsgHelper:makept_ranks_info(rank,user_id,name,icon,lev,value) 
	local t = {}
	t["rank"]=rank
	t["user_id"]=user_id
	t["name"]=name
	t["icon"]=icon
	t["lev"]=lev
	t["value"]=value
	return t
end

function NetMsgHelper:makept_ranks_list(id,pt_ranks_info,pt_ranks_info) 
	local t = {}
	t["id"]=id
	t["self"]=pt_ranks_info
	t["info"]=pt_ranks_info
	return t
end

function NetMsgHelper:makept_story_hide(info) 
	local t = {}
	t["info"]=info
	return t
end

function NetMsgHelper:makept_gmcmd(cmd) 
	local t = {}
	t["cmd"]=cmd
	return t
end

function NetMsgHelper:makedb_mapreward(id,user_id,map_id,invade,invade_time,gain_time,gain_num) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["map_id"]=map_id
	t["invade"]=invade
	t["invade_time"]=invade_time
	t["gain_time"]=gain_time
	t["gain_num"]=gain_num
	return t
end

function NetMsgHelper:makept_map_gain(map,money) 
	local t = {}
	t["map"]=map
	t["money"]=money
	return t
end

function NetMsgHelper:makept_map_info(date,story,gain,pt_maze,invade) 
	local t = {}
	t["date"]=date
	t["story"]=story
	t["gain"]=gain
	t["maze"]=pt_maze
	t["invade"]=invade
	return t
end

function NetMsgHelper:makept_map_friend(id,story,name,icon) 
	local t = {}
	t["id"]=id
	t["story"]=story
	t["name"]=name
	t["icon"]=icon
	return t
end

function NetMsgHelper:makept_map_friend_list(pt_map_friend) 
	local t = {}
	t["list"]=pt_map_friend
	return t
end

function NetMsgHelper:makedb_coldtime(id,user_id,chp_times,chp_gold,champion,freedom,monster,crazy,lrank,lrank_buy) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["chp_times"]=chp_times
	t["chp_gold"]=chp_gold
	t["champion"]=champion
	t["freedom"]=freedom
	t["monster"]=monster
	t["crazy"]=crazy
	t["lrank"]=lrank
	t["lrank_buy"]=lrank_buy
	return t
end

function NetMsgHelper:makept_champion(rank,times,cd) 
	local t = {}
	t["rank"]=rank
	t["times"]=times
	t["cd"]=cd
	return t
end

function NetMsgHelper:makept_freedom(cd) 
	local t = {}
	t["cd"]=cd
	return t
end

function NetMsgHelper:makemcard(baseid,level,hp,att) 
	local t = {}
	t["baseid"]=baseid
	t["level"]=level
	t["hp"]=hp
	t["att"]=att
	return t
end

function NetMsgHelper:makept_m_group(hero,cards) 
	local t = {}
	t["hero"]=hero
	t["cards"]=cards
	return t
end

function NetMsgHelper:makept_m_fighter(id,score) 
	local t = {}
	t["id"]=id
	t["score"]=score
	return t
end

function NetMsgHelper:makedb_monster(id,user_id,level,hard,score,find_id,find_time,end_time,pt_m_fighter,pt_m_group,killer_id,killed_time,prizecard) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["level"]=level
	t["hard"]=hard
	t["score"]=score
	t["find_id"]=find_id
	t["find_time"]=find_time
	t["end_time"]=end_time
	t["attacker"]=pt_m_fighter
	t["fightdata"]=pt_m_group
	t["killer_id"]=killer_id
	t["killed_time"]=killed_time
	t["prizecard"]=prizecard
	return t
end

function NetMsgHelper:makedb_mail(id,user_id,type,new,from,event,title,content,time) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["type"]=type
	t["new"]=new
	t["from"]=from
	t["event"]=event
	t["title"]=title
	t["content"]=content
	t["time"]=time
	return t
end

function NetMsgHelper:makept_player_mail(id,type,new,time,event) 
	local t = {}
	t["id"]=id
	t["type"]=type
	t["new"]=new
	t["time"]=time
	t["event"]=event
	return t
end

function NetMsgHelper:makept_player_mail_list(pt_player_mail) 
	local t = {}
	t["info"]=pt_player_mail
	return t
end

function NetMsgHelper:makept_write_mail(receiver,title,content) 
	local t = {}
	t["receiver"]=receiver
	t["title"]=title
	t["content"]=content
	return t
end

function NetMsgHelper:makept_new_mail(type,num) 
	local t = {}
	t["type"]=type
	t["num"]=num
	return t
end

function NetMsgHelper:makept_new_mail_list(pt_new_mail) 
	local t = {}
	t["list"]=pt_new_mail
	return t
end

function NetMsgHelper:makept_monster(level,hard,now,score,find_id,find_name,time,round,killer_id,killer_name) 
	local t = {}
	t["level"]=level
	t["hard"]=hard
	t["now"]=now
	t["score"]=score
	t["find_id"]=find_id
	t["find_name"]=find_name
	t["time"]=time
	t["round"]=round
	t["killer_id"]=killer_id
	t["killer_name"]=killer_name
	return t
end

function NetMsgHelper:makept_find_monster(pt_monster,cd) 
	local t = {}
	t["monster"]=pt_monster
	t["cd"]=cd
	return t
end

function NetMsgHelper:makept_monster_all(pt_monster,cd) 
	local t = {}
	t["all"]=pt_monster
	t["cd"]=cd
	return t
end

function NetMsgHelper:makept_crazy_score(once,totle) 
	local t = {}
	t["once"]=once
	t["totle"]=totle
	return t
end

function NetMsgHelper:makept_pay_verify(platform,pay_type,token,signature) 
	local t = {}
	t["platform"]=platform
	t["pay_type"]=pay_type
	t["token"]=token
	t["signature"]=signature
	return t
end

function NetMsgHelper:makept_pay_list_get(platform) 
	local t = {}
	t["platform"]=platform
	return t
end

function NetMsgHelper:makept_pay_list(pay_types) 
	local t = {}
	t["pay_types"]=pay_types
	return t
end

function NetMsgHelper:makept_legion_rank_get(start,size) 
	local t = {}
	t["start"]=start
	t["size"]=size
	return t
end

function NetMsgHelper:makept_lrank_buy(num,cost) 
	local t = {}
	t["num"]=num
	t["cost"]=cost
	return t
end

function NetMsgHelper:makelegion_rank(id,name,remark,exp,lev,flag,lock,meb,rank,score,threat) 
	local t = {}
	t["id"]=id
	t["name"]=name
	t["remark"]=remark
	t["exp"]=exp
	t["lev"]=lev
	t["flag"]=flag
	t["lock"]=lock
	t["meb"]=meb
	t["rank"]=rank
	t["score"]=score
	t["threat"]=threat
	return t
end

function NetMsgHelper:makept_legion_rank_list(len_id,name,num,cost,legion_rank) 
	local t = {}
	t["len_id"]=len_id
	t["name"]=name
	t["num"]=num
	t["cost"]=cost
	t["legion_ranks"]=legion_rank
	return t
end

function NetMsgHelper:makeplayer_rank_info(user_id,name,icon,level,rank,scores,pos,devote,plan_score,plan_money,protected) 
	local t = {}
	t["user_id"]=user_id
	t["name"]=name
	t["icon"]=icon
	t["level"]=level
	t["rank"]=rank
	t["scores"]=scores
	t["pos"]=pos
	t["devote"]=devote
	t["plan_score"]=plan_score
	t["plan_money"]=plan_money
	t["protected"]=protected
	return t
end

function NetMsgHelper:makept_player_rank_list(rank,num,cost,player_rank_info) 
	local t = {}
	t["rank"]=rank
	t["num"]=num
	t["cost"]=cost
	t["mebs"]=player_rank_info
	return t
end

function NetMsgHelper:makep_rank_info(user_id,name,icon,level,rank,scores,legion_id,legion_name,flag) 
	local t = {}
	t["user_id"]=user_id
	t["name"]=name
	t["icon"]=icon
	t["level"]=level
	t["rank"]=rank
	t["scores"]=scores
	t["legion_id"]=legion_id
	t["legion_name"]=legion_name
	t["flag"]=flag
	return t
end

function NetMsgHelper:makept_p_rank_list(rank,scores,p_rank_info) 
	local t = {}
	t["rank"]=rank
	t["scores"]=scores
	t["mebs"]=p_rank_info
	return t
end

function NetMsgHelper:makerc_sign(num,gain) 
	local t = {}
	t["num"]=num
	t["gain"]=gain
	return t
end

function NetMsgHelper:makedb_sign(id,user_id,month,rc_sign,time) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["month"]=month
	t["sign"]=rc_sign
	t["time"]=time
	return t
end

function NetMsgHelper:makept_sign(month,rc_sign) 
	local t = {}
	t["month"]=month
	t["sign"]=rc_sign
	return t
end

function NetMsgHelper:makedb_param(id,user_id,intary) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["intary"]=intary
	return t
end

function NetMsgHelper:makepk_cteam(baseid,level) 
	local t = {}
	t["baseid"]=baseid
	t["level"]=level
	return t
end

function NetMsgHelper:makedb_war(id,user_id,pk_cteam) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["cards"]=pk_cteam
	return t
end

function NetMsgHelper:makedb_gvglog(id,user_id,legion_id,rank,scores,shield,attack) 
	local t = {}
	t["id"]=id
	t["user_id"]=user_id
	t["legion_id"]=legion_id
	t["rank"]=rank
	t["scores"]=scores
	t["shield"]=shield
	t["attack"]=attack
	return t
end

function NetMsgHelper:makept_gvg_init_battle(legion_id,legion_name,guard_id,guard_name,guard_icon,shield,max_shield,scores,mebs,end_time) 
	local t = {}
	t["legion_id"]=legion_id
	t["legion_name"]=legion_name
	t["guard_id"]=guard_id
	t["guard_name"]=guard_name
	t["guard_icon"]=guard_icon
	t["shield"]=shield
	t["max_shield"]=max_shield
	t["scores"]=scores
	t["mebs"]=mebs
	t["end_time"]=end_time
	return t
end

function NetMsgHelper:makept_gvg_init_battle_list(attack_num,max_attack,pt_gvg_init_battle,pt_gvg_init_battle) 
	local t = {}
	t["attack_num"]=attack_num
	t["max_attack"]=max_attack
	t["self"]=pt_gvg_init_battle
	t["enemy"]=pt_gvg_init_battle
	return t
end

function NetMsgHelper:makept_gvg_battle_end(result,scores,totle_scores,less_scores) 
	local t = {}
	t["result"]=result
	t["scores"]=scores
	t["totle_scores"]=totle_scores
	t["less_scores"]=less_scores
	return t
end

function NetMsgHelper:makept_gvg_fight(type,target) 
	local t = {}
	t["type"]=type
	t["target"]=target
	return t
end

function NetMsgHelper:makept_gvg_shield(user_id,from_legion,target_legion,name,change,shield) 
	local t = {}
	t["user_id"]=user_id
	t["from_legion"]=from_legion
	t["target_legion"]=target_legion
	t["name"]=name
	t["change"]=change
	t["shield"]=shield
	return t
end

function NetMsgHelper:makept_gvg_first(legion_id,gvg_id,gvg_state,scores,shield,extra_shield,attack,extra_attack) 
	local t = {}
	t["legion_id"]=legion_id
	t["gvg_id"]=gvg_id
	t["gvg_state"]=gvg_state
	t["scores"]=scores
	t["shield"]=shield
	t["extra_shield"]=extra_shield
	t["attack"]=attack
	t["extra_attack"]=extra_attack
	return t
end

function NetMsgHelper:makept_gvg_star(gvg_id,state,legion_id,name,flag) 
	local t = {}
	t["gvg_id"]=gvg_id
	t["state"]=state
	t["legion_id"]=legion_id
	t["name"]=name
	t["flag"]=flag
	return t
end

function NetMsgHelper:makept_gvg_star_list(pt_gvg_star) 
	local t = {}
	t["list"]=pt_gvg_star
	return t
end

function NetMsgHelper:makept_gvg_rank(legion_id,name,rank,scores) 
	local t = {}
	t["legion_id"]=legion_id
	t["name"]=name
	t["rank"]=rank
	t["scores"]=scores
	return t
end

function NetMsgHelper:makept_gvg_rank_list(less_scores,pt_gvg_rank) 
	local t = {}
	t["less_scores"]=less_scores
	t["list"]=pt_gvg_rank
	return t
end

function NetMsgHelper:makept_gvg_legion_log(enemy_id,result,scores,time) 
	local t = {}
	t["enemy_id"]=enemy_id
	t["result"]=result
	t["scores"]=scores
	t["time"]=time
	return t
end

function NetMsgHelper:makept_gvg_legion_log_list(pt_gvg_legion_log) 
	local t = {}
	t["list"]=pt_gvg_legion_log
	return t
end

function NetMsgHelper:makept_gvg_player_log(user_id,name,attack,win,socres) 
	local t = {}
	t["user_id"]=user_id
	t["name"]=name
	t["attack"]=attack
	t["win"]=win
	t["socres"]=socres
	return t
end

function NetMsgHelper:makept_gvg_player_log_list(pt_gvg_player_log) 
	local t = {}
	t["list"]=pt_gvg_player_log
	return t
end

function NetMsgHelper:makept_gvg_login(gvg_id) 
	local t = {}
	t["gvg_id"]=gvg_id
	return t
end

function NetMsgHelper:makept_gvg_scores(legion_id,scores) 
	local t = {}
	t["legion_id"]=legion_id
	t["scores"]=scores
	return t
end

