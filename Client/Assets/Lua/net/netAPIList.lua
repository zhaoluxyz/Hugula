------------------- API type ---------------
NetAPIList= { 

	-- 版本检查 
	check_version = 
	{ 
		Code = 41000,
		DataStruct= 'send_check_version',
	}, 

	-- 匿名登陆 
	player_anonymouslogin = 
	{ 
		Code = 121,
		DataStruct= 'player_anonymouslogin',
	}, 

	-- 登入到游戏网关 
	gs_login = 
	{ 
		Code = 220,
		DataStruct= 'pt_gs_login',
	}, 

	-- 成功 
	gs_good = 
	{ 
		Code = 221,
		DataStruct= 'pt_gs_good',
	}, 

	-- 失败 
	gs_bad = 
	{ 
		Code = 222,
		DataStruct= 'pt_gs_bad',
	}, 

	-- 启动心跳 
	start_heartbeat = 
	{ 
		Code = 223,
		DataStruct= 'pt_int',
	}, 

	-- 心跳 
	heartbeat = 
	{ 
		Code = 224,
		DataStruct= 'pt_int',
	}, 

	-- 玩家队伍 
	player_team = 
	{ 
		Code = 225,
		DataStruct= 'pt_player_team',
	}, 

	-- 玩家英雄 
	player_hero = 
	{ 
		Code = 226,
		DataStruct= 'pt_player_hero',
	}, 

	-- 请求玩家关卡进度列表 
	player_chapter_list = 
	{ 
		Code = 227,
		DataStruct= 'send_player_chapter',
	}, 

	-- 玩家关卡数据 
	recv_player_chapter_list = 
	{ 
		Code = 228,
		DataStruct= 'pt_player_chapter_list',
	}, 

	-- 挑战关卡 
	player_challenge_chapter = 
	{ 
		Code = 229,
		DataStruct= 'send_challenge_chapter',
	}, 

	-- 扫荡关卡 
	player_sweep_chapter = 
	{ 
		Code = 2210,
		DataStruct= 'send_challenge_chapter',
	}, 

	-- 接收玩家属性更新 
	recv_player_attribute1 = 
	{ 
		Code = 2211,
		DataStruct= 'pt_character_attribute_a',
	}, 

	-- 发起挑战关卡战斗开始 
	player_challenge_chapter_start = 
	{ 
		Code = 2212,
		DataStruct= 'send_player_challenge_chapter_start',
	}, 

	-- 接收挑战关卡结果结算 
	recv_player_challenge_chapter_result = 
	{ 
		Code = 2213,
		DataStruct= 'recv_challenge_chapter_result',
	}, 

	-- 道具获得 
	recv_paygoods = 
	{ 
		Code = 2214,
		DataStruct= 'pt_paygoods',
	}, 

	-- 请求背包道具列表 
	player_bag = 
	{ 
		Code = 2215,
		DataStruct= 'pt_int',
	}, 

	-- 背包道具列表 
	recv_player_bag_goods = 
	{ 
		Code = 2216,
		DataStruct= 'recv_player_bag_goods',
	}, 

	-- 使用道具 
	use_goods_api = 
	{ 
		Code = 2217,
		DataStruct= 'pt_use_goods',
	}, 

	-- 玩家英雄列表 
	player_hero_list = 
	{ 
		Code = 2218,
		DataStruct= 'send_player_hero_list',
	}, 

	-- 英雄上阵 
	change_player_team_up = 
	{ 
		Code = 2219,
		DataStruct= 'send_change_player_team_up',
	}, 

	-- 英雄下阵 
	change_player_team_down = 
	{ 
		Code = 2220,
		DataStruct= 'send_change_player_team_down',
	}, 

	-- 道具出售 
	goods_sell = 
	{ 
		Code = 2221,
		DataStruct= 'send_player_goods_sell',
	}, 

	-- 背包道具列表 
	recv_player_bag_change_goods = 
	{ 
		Code = 2222,
		DataStruct= 'recv_player_bag_goods',
	}, 

	-- 玩家英雄装备 
	use_equip_api = 
	{ 
		Code = 2223,
		DataStruct= 'send_player_hero_equip_up',
	}, 

	-- 玩家英雄进阶 
	player_hero_advanced = 
	{ 
		Code = 2224,
		DataStruct= 'send_player_hero_advanced',
	}, 

	-- 击杀怪物 
	kill_monster = 
	{ 
		Code = 2225,
		DataStruct= 'send_kill_monster',
	}, 

	-- 接收怪物列表 
	recv_monster_list = 
	{ 
		Code = 2226,
		DataStruct= 'recv_monster_list',
	}, 

	-- 获取邮件列表 
	player_mail_list = 
	{ 
		Code = 2227,
		DataStruct= 'send_player_mail_list',
	}, 

	-- 接收邮件列表 
	recv_player_mail_list = 
	{ 
		Code = 2228,
		DataStruct= 'recv_mail_list',
	}, 

	-- 打开附件 
	player_mail_goods = 
	{ 
		Code = 2229,
		DataStruct= 'send_player_mail_goods',
	}, 

	-- 读取邮件 
	player_mail_read = 
	{ 
		Code = 2230,
		DataStruct= 'send_player_mail_read',
	}, 

	-- 删除邮件 
	player_mail_delete = 
	{ 
		Code = 2231,
		DataStruct= 'send_player_mail_delete',
	}, 

	-- 更新英雄信息 
	recv_player_hero_change = 
	{ 
		Code = 2232,
		DataStruct= 'recv_player_hero_list',
	}, 

	-- 装备合成 
	hero_equip_synthesis = 
	{ 
		Code = 2233,
		DataStruct= 'send_hero_equip_synthesis',
	}, 

	-- 接收邮件 
	recv_player_mail_content = 
	{ 
		Code = 2234,
		DataStruct= 'recv_mail',
	}, 

	-- 发送邮件 
	send_mail = 
	{ 
		Code = 2235,
		DataStruct= 'send_mail',
	}, 

	-- 扫荡关卡数据返回 
	recv_player_sweep_chapter = 
	{ 
		Code = 2236,
		DataStruct= 'recv_player_sweep_chapter',
	}, 

	-- 接收新邮件总数 
	recv_mail_count = 
	{ 
		Code = 2237,
		DataStruct= 'recv_mail_count',
	}, 

	-- 接收关卡挑战返回数据 
	recv_player_challenge_chapter = 
	{ 
		Code = 2238,
		DataStruct= 'recv_player_challenge_chapter',
	}, 

	-- 英雄强化 
	player_hero_strengthen = 
	{ 
		Code = 2239,
		DataStruct= 'send_player_hero_strengthen',
	}, 

	-- 接收英雄强化信息 
	recv_player_hero_strengthen = 
	{ 
		Code = 2240,
		DataStruct= 'recv_player_hero_strengthen',
	}, 

	-- 发送英雄合成 
	hero_hero_synthesis = 
	{ 
		Code = 2241,
		DataStruct= 'send_hero_hero_synthesis',
	}, 

	-- 用户对发邮件 
	player_send_mail = 
	{ 
		Code = 2242,
		DataStruct= 'send_player_send_mail',
	}, 

	-- 接收登录奖励领取天数 
	recv_reward_data = 
	{ 
		Code = 2243,
		DataStruct= 'recv_reward_data',
	}, 

	-- 领取登录奖励 
	player_login_receive = 
	{ 
		Code = 2244,
		DataStruct= 'send_player_reward_login',
	}, 

	-- 获取图鉴列表 
	select_player_hero_atlas_player_id = 
	{ 
		Code = 2245,
		DataStruct= 'send_player_hero_stlas_list',
	}, 

	-- 接收图鉴列表 
	recv_hero_atlas_list = 
	{ 
		Code = 2246,
		DataStruct= 'recv_hero_atlas_list',
	}, 

	-- 获取登录奖励数据 
	player_login_reward_data = 
	{ 
		Code = 2247,
		DataStruct= 'send_player_reward_data',
	}, 

	-- 申请好友请求 
	player_apply_add_friends = 
	{ 
		Code = 2248,
		DataStruct= 'send_apply_friends_apply',
	}, 

	-- 接收好友申请列表 
	recv_friends_apply_list = 
	{ 
		Code = 2249,
		DataStruct= 'recv_friends_apply_list',
	}, 

	-- 好友申请回复 
	player_request_add_friends = 
	{ 
		Code = 2250,
		DataStruct= 'send_request_friends_apply',
	}, 

	-- 接收好友列表 
	recv_friends_list = 
	{ 
		Code = 2251,
		DataStruct= 'recv_friends_list',
	}, 

	-- 获取好友列表 
	player_friends_list = 
	{ 
		Code = 2252,
		DataStruct= 'send_friends_list',
	}, 

	-- 接收申请好友回复结果 
	recv_friends_request = 
	{ 
		Code = 2253,
		DataStruct= 'recv_friends_request',
	}, 

	-- 接收挑战关卡战斗记时 
	recv_player_challenge_chapter_start = 
	{ 
		Code = 2254,
		DataStruct= 'pt_int',
	}, 

	-- 领取友情值 
	player_receive_friendship = 
	{ 
		Code = 2255,
		DataStruct= 'send_reveive_friendship',
	}, 

	-- 一件领取友情值 
	player_friends_pick_up = 
	{ 
		Code = 2256,
		DataStruct= 'send_reveive_friendship_pick_up',
	}, 

	-- 增送友情值 
	player_add_send_value_friendship = 
	{ 
		Code = 2257,
		DataStruct= 'send_value_friendship',
	}, 

	-- 查找好友 
	player_find_list = 
	{ 
		Code = 2259,
		DataStruct= 'send_player_find_list',
	}, 

	-- 接收查找好友列表 
	recv_find_player_list = 
	{ 
		Code = 2260,
		DataStruct= 'recv_find_player_list',
	}, 

	-- 删除好友 
	player_friends_delete = 
	{ 
		Code = 2261,
		DataStruct= 'send_player_friends_delete',
	}, 

	-- 获取玩家任务列表 
	recv_player_quest_list = 
	{ 
		Code = 2262,
		DataStruct= 'recv_player_quest_list',
	}, 

	-- 领取任务奖品 
	receive_quest_goods = 
	{ 
		Code = 2263,
		DataStruct= 'send_receive_quest_goods',
	}, 

	-- 接收任务奖品 
	recv_quest_goods = 
	{ 
		Code = 2264,
		DataStruct= 'recv_quest_goods',
	}, 

	-- 接收领取剩余友情值次数 
	recv_friends_remain_count = 
	{ 
		Code = 2265,
		DataStruct= 'recv_friends_remain_count',
	}, 

	-- 合成神兽碎片 
	player_compound_goods_beast = 
	{ 
		Code = 2266,
		DataStruct= 'send_player_compound_goods_beast',
	}, 

	-- 添加剧情位置 
	player_drama = 
	{ 
		Code = 2267,
		DataStruct= 'send_player_drama',
	}, 

	-- 添加新手引导位置 
	player_boot = 
	{ 
		Code = 2268,
		DataStruct= 'send_player_boot',
	}, 

	-- 接收好友邮件 
	recv_friends_mail_list = 
	{ 
		Code = 2269,
		DataStruct= 'recv_friends_mail_list',
	}, 

	-- 获取活动列表 
	player_activity_list = 
	{ 
		Code = 2270,
		DataStruct= 'player_activity_list',
	}, 

	-- 接收活动列表 
	recv_activity_list = 
	{ 
		Code = 2271,
		DataStruct= 'recv_activity_list',
	}, 

	-- 请求竟技场内与玩家排名相近的玩家10名 
	player_arena_rank_near = 
	{ 
		Code = 2272,
		DataStruct= 'pt_int',
	}, 

	-- 接收竟技场内与玩家排名相近的玩家10名 
	recv_player_arena_rank_near = 
	{ 
		Code = 2273,
		DataStruct= 'recv_player_arena_rank_near',
	}, 

	-- 接收玩家神兽数据 
	recv_player_beast_list = 
	{ 
		Code = 2274,
		DataStruct= 'recv_player_beast_list',
	}, 

	-- 请求竟技场内玩家排名前10名 
	player_arena_rank_top = 
	{ 
		Code = 2275,
		DataStruct= 'pt_int',
	}, 

	-- 接收竟技场内玩家排名前10名 
	recv_player_arena_rank_top = 
	{ 
		Code = 2276,
		DataStruct= 'recv_player_arena_rank_near',
	}, 

	-- 请求竟技场兑换商品 
	player_exchanges = 
	{ 
		Code = 2277,
		DataStruct= 'pt_int',
	}, 

	-- 接收请求竟技场兑换商品 
	recv_player_exchanges = 
	{ 
		Code = 2278,
		DataStruct= 'recv_player_exchanges',
	}, 

	-- 开始竟技场兑换商品 
	exchange_goods = 
	{ 
		Code = 2279,
		DataStruct= 'send_exchange_goods',
	}, 

	-- 刷新兑换道具 
	refresh_exchange_goods = 
	{ 
		Code = 2280,
		DataStruct= 'pt_int',
	}, 

	-- 请求竟技场战报 
	player_arena_battle_report = 
	{ 
		Code = 2281,
		DataStruct= 'pt_int',
	}, 

	-- 接收竟技场战报 
	recv_player_arena_battle_report = 
	{ 
		Code = 2282,
		DataStruct= 'recv_player_arena_battle_report_list',
	}, 

	-- 请求活动条件验证 
	player_activity_verify = 
	{ 
		Code = 2283,
		DataStruct= 'sned_player_activity_verify',
	}, 

	-- 接收活动条件验证结果 
	recv_player_activity_verify = 
	{ 
		Code = 2284,
		DataStruct= 'recv_player_activity_verify',
	}, 

	-- 发起竟技场挑战 
	player_challenge_arena = 
	{ 
		Code = 2285,
		DataStruct= 'send_player_challenge_arena',
	}, 

	-- 设置神兽默认出战 
	player_besat_played = 
	{ 
		Code = 2286,
		DataStruct= 'send_player_besat_played',
	}, 

	-- 英雄技能升级 
	player_hero_skill_up = 
	{ 
		Code = 2287,
		DataStruct= 'send_player_hero_skill_up',
	}, 

	-- 刷新玩家技能点数 
	player_skill_release_up = 
	{ 
		Code = 2288,
		DataStruct= 'send_player_skill_release_up',
	}, 

	-- 接收玩家技能点数刷新时间 
	recv_player_hero_skill_time = 
	{ 
		Code = 2289,
		DataStruct= 'recv_player_hero_skill_time',
	}, 

	-- 接收系统配置数据 
	recv_system_conf_data = 
	{ 
		Code = 2290,
		DataStruct= 'recv_system_conf_data',
	}, 

	-- 商城商品列表 
	shop_goods = 
	{ 
		Code = 2291,
		DataStruct= 'pt_int',
	}, 

	-- 接收商城商品列表 
	recv_shop_goods_list = 
	{ 
		Code = 2292,
		DataStruct= 'recv_shop_goods_list',
	}, 

	-- 购买商品 
	buy_goods = 
	{ 
		Code = 2293,
		DataStruct= 'send_buy_goods',
	}, 

	-- 接收购买商品信息 
	recv_buy_goods = 
	{ 
		Code = 2294,
		DataStruct= 'recv_buy_goods_data',
	}, 

	-- 接收活动剩余次数信息 
	recv_activity_residue_list = 
	{ 
		Code = 2295,
		DataStruct= 'recv_activity_residue_list',
	}, 

	-- 战斗中召唤神兽 
	call_mythical_animals = 
	{ 
		Code = 2296,
		DataStruct= 'pt_int',
	}, 

	-- 刷新玩家体力点数 
	player_vit_release_up = 
	{ 
		Code = 2297,
		DataStruct= 'vit_release_up',
	}, 

	-- 接收玩家体力点数刷新时间 
	recv_vit_release_up = 
	{ 
		Code = 2298,
		DataStruct= 'recv_vit_release_up',
	}, 

	-- 接受玩家删除的好友数据 
	recv_player_friends_delete = 
	{ 
		Code = 2299,
		DataStruct= 'recv_player_friends_delete',
	}, 

	-- 英雄碎片合成英雄 
	hero_fragments_synthetic = 
	{ 
		Code = 22100,
		DataStruct= 'send_hero_fragments_synthetic',
	}, 

	-- 英雄相关道具使用 
	hero_goods_use = 
	{ 
		Code = 22101,
		DataStruct= 'send_hero_goods_use',
	}, 

	-- 英雄出售 
	hero_sell = 
	{ 
		Code = 22102,
		DataStruct= 'send_player_hero_sell',
	}, 

	-- 聊天服务器成功 
	chatserv_good = 
	{ 
		Code = 321,
		DataStruct= 'pt_gs_good',
	}, 

	-- 聊天服务器失败 
	chatserv_bad = 
	{ 
		Code = 322,
		DataStruct= 'pt_gs_bad',
	}, 

	-- 登入聊天服务器 
	chatserv_login = 
	{ 
		Code = 320,
		DataStruct= 'pt_gs_login',
	}, 

	-- 接收聊天信息 
	recv_broadcast_message = 
	{ 
		Code = 323,
		DataStruct= 'recv_broadcast_message',
	}, 

	-- 发送收聊天信息 
	send_chat = 
	{ 
		Code = 324,
		DataStruct= 'send_chat',
	}, 

	-- 聊天心跳 
	chat_heartbeat = 
	{ 
		Code = 325,
		DataStruct= 'pt_int',
	}, 
} 

NetAPIList.CodeToMsgType = { 
	MSGTYPE2255	=	NetAPIList.player_receive_friendship.DataStruct,
	MSGTYPE2224	=	NetAPIList.player_hero_advanced.DataStruct,
	MSGTYPE322	=	NetAPIList.chatserv_bad.DataStruct,
	MSGTYPE2289	=	NetAPIList.recv_player_hero_skill_time.DataStruct,
	MSGTYPE2278	=	NetAPIList.recv_player_exchanges.DataStruct,
	MSGTYPE2245	=	NetAPIList.select_player_hero_atlas_player_id.DataStruct,
	MSGTYPE2213	=	NetAPIList.recv_player_challenge_chapter_result.DataStruct,
	MSGTYPE2248	=	NetAPIList.player_apply_add_friends.DataStruct,
	MSGTYPE223	=	NetAPIList.start_heartbeat.DataStruct,
	MSGTYPE2211	=	NetAPIList.recv_player_attribute1.DataStruct,
	MSGTYPE2250	=	NetAPIList.player_request_add_friends.DataStruct,
	MSGTYPE221	=	NetAPIList.gs_good.DataStruct,
	MSGTYPE220	=	NetAPIList.gs_login.DataStruct,
	MSGTYPE222	=	NetAPIList.gs_bad.DataStruct,
	MSGTYPE2285	=	NetAPIList.player_challenge_arena.DataStruct,
	MSGTYPE2210	=	NetAPIList.player_sweep_chapter.DataStruct,
	MSGTYPE2240	=	NetAPIList.recv_player_hero_strengthen.DataStruct,
	MSGTYPE226	=	NetAPIList.player_hero.DataStruct,
	MSGTYPE2232	=	NetAPIList.recv_player_hero_change.DataStruct,
	MSGTYPE2253	=	NetAPIList.recv_friends_request.DataStruct,
	MSGTYPE2227	=	NetAPIList.player_mail_list.DataStruct,
	MSGTYPE41000	=	NetAPIList.check_version.DataStruct,
	MSGTYPE22100	=	NetAPIList.hero_fragments_synthetic.DataStruct,
	MSGTYPE2252	=	NetAPIList.player_friends_list.DataStruct,
	MSGTYPE2241	=	NetAPIList.hero_hero_synthesis.DataStruct,
	MSGTYPE2244	=	NetAPIList.player_login_receive.DataStruct,
	MSGTYPE2257	=	NetAPIList.player_add_send_value_friendship.DataStruct,
	MSGTYPE2239	=	NetAPIList.player_hero_strengthen.DataStruct,
	MSGTYPE2216	=	NetAPIList.recv_player_bag_goods.DataStruct,
	MSGTYPE325	=	NetAPIList.chat_heartbeat.DataStruct,
	MSGTYPE324	=	NetAPIList.send_chat.DataStruct,
	MSGTYPE2296	=	NetAPIList.call_mythical_animals.DataStruct,
	MSGTYPE2218	=	NetAPIList.player_hero_list.DataStruct,
	MSGTYPE320	=	NetAPIList.chatserv_login.DataStruct,
	MSGTYPE2238	=	NetAPIList.recv_player_challenge_chapter.DataStruct,
	MSGTYPE2265	=	NetAPIList.recv_friends_remain_count.DataStruct,
	MSGTYPE2212	=	NetAPIList.player_challenge_chapter_start.DataStruct,
	MSGTYPE321	=	NetAPIList.chatserv_good.DataStruct,
	MSGTYPE2214	=	NetAPIList.recv_paygoods.DataStruct,
	MSGTYPE22102	=	NetAPIList.hero_sell.DataStruct,
	MSGTYPE2269	=	NetAPIList.recv_friends_mail_list.DataStruct,
	MSGTYPE227	=	NetAPIList.player_chapter_list.DataStruct,
	MSGTYPE22101	=	NetAPIList.hero_goods_use.DataStruct,
	MSGTYPE2246	=	NetAPIList.recv_hero_atlas_list.DataStruct,
	MSGTYPE2298	=	NetAPIList.recv_vit_release_up.DataStruct,
	MSGTYPE2297	=	NetAPIList.player_vit_release_up.DataStruct,
	MSGTYPE121	=	NetAPIList.player_anonymouslogin.DataStruct,
	MSGTYPE2219	=	NetAPIList.change_player_team_up.DataStruct,
	MSGTYPE323	=	NetAPIList.recv_broadcast_message.DataStruct,
	MSGTYPE2225	=	NetAPIList.kill_monster.DataStruct,
	MSGTYPE2271	=	NetAPIList.recv_activity_list.DataStruct,
	MSGTYPE2295	=	NetAPIList.recv_activity_residue_list.DataStruct,
	MSGTYPE2223	=	NetAPIList.use_equip_api.DataStruct,
	MSGTYPE2275	=	NetAPIList.player_arena_rank_top.DataStruct,
	MSGTYPE2294	=	NetAPIList.recv_buy_goods.DataStruct,
	MSGTYPE2293	=	NetAPIList.buy_goods.DataStruct,
	MSGTYPE2292	=	NetAPIList.recv_shop_goods_list.DataStruct,
	MSGTYPE2286	=	NetAPIList.player_besat_played.DataStruct,
	MSGTYPE2235	=	NetAPIList.send_mail.DataStruct,
	MSGTYPE2270	=	NetAPIList.player_activity_list.DataStruct,
	MSGTYPE2290	=	NetAPIList.recv_system_conf_data.DataStruct,
	MSGTYPE2276	=	NetAPIList.recv_player_arena_rank_top.DataStruct,
	MSGTYPE2236	=	NetAPIList.recv_player_sweep_chapter.DataStruct,
	MSGTYPE2287	=	NetAPIList.player_hero_skill_up.DataStruct,
	MSGTYPE2229	=	NetAPIList.player_mail_goods.DataStruct,
	MSGTYPE229	=	NetAPIList.player_challenge_chapter.DataStruct,
	MSGTYPE2266	=	NetAPIList.player_compound_goods_beast.DataStruct,
	MSGTYPE2291	=	NetAPIList.shop_goods.DataStruct,
	MSGTYPE2280	=	NetAPIList.refresh_exchange_goods.DataStruct,
	MSGTYPE2284	=	NetAPIList.recv_player_activity_verify.DataStruct,
	MSGTYPE2283	=	NetAPIList.player_activity_verify.DataStruct,
	MSGTYPE2282	=	NetAPIList.recv_player_arena_battle_report.DataStruct,
	MSGTYPE2251	=	NetAPIList.recv_friends_list.DataStruct,
	MSGTYPE2279	=	NetAPIList.exchange_goods.DataStruct,
	MSGTYPE2254	=	NetAPIList.recv_player_challenge_chapter_start.DataStruct,
	MSGTYPE224	=	NetAPIList.heartbeat.DataStruct,
	MSGTYPE2277	=	NetAPIList.player_exchanges.DataStruct,
	MSGTYPE2288	=	NetAPIList.player_skill_release_up.DataStruct,
	MSGTYPE2247	=	NetAPIList.player_login_reward_data.DataStruct,
	MSGTYPE2267	=	NetAPIList.player_drama.DataStruct,
	MSGTYPE2274	=	NetAPIList.recv_player_beast_list.DataStruct,
	MSGTYPE2217	=	NetAPIList.use_goods_api.DataStruct,
	MSGTYPE2273	=	NetAPIList.recv_player_arena_rank_near.DataStruct,
	MSGTYPE2261	=	NetAPIList.player_friends_delete.DataStruct,
	MSGTYPE2268	=	NetAPIList.player_boot.DataStruct,
	MSGTYPE2262	=	NetAPIList.recv_player_quest_list.DataStruct,
	MSGTYPE2263	=	NetAPIList.receive_quest_goods.DataStruct,
	MSGTYPE2234	=	NetAPIList.recv_player_mail_content.DataStruct,
	MSGTYPE2264	=	NetAPIList.recv_quest_goods.DataStruct,
	MSGTYPE2272	=	NetAPIList.player_arena_rank_near.DataStruct,
	MSGTYPE225	=	NetAPIList.player_team.DataStruct,
	MSGTYPE2260	=	NetAPIList.recv_find_player_list.DataStruct,
	MSGTYPE2259	=	NetAPIList.player_find_list.DataStruct,
	MSGTYPE2242	=	NetAPIList.player_send_mail.DataStruct,
	MSGTYPE2281	=	NetAPIList.player_arena_battle_report.DataStruct,
	MSGTYPE2249	=	NetAPIList.recv_friends_apply_list.DataStruct,
	MSGTYPE2299	=	NetAPIList.recv_player_friends_delete.DataStruct,
	MSGTYPE2230	=	NetAPIList.player_mail_read.DataStruct,
	MSGTYPE2222	=	NetAPIList.recv_player_bag_change_goods.DataStruct,
	MSGTYPE2220	=	NetAPIList.change_player_team_down.DataStruct,
	MSGTYPE2233	=	NetAPIList.hero_equip_synthesis.DataStruct,
	MSGTYPE2256	=	NetAPIList.player_friends_pick_up.DataStruct,
	MSGTYPE2228	=	NetAPIList.recv_player_mail_list.DataStruct,
	MSGTYPE2243	=	NetAPIList.recv_reward_data.DataStruct,
	MSGTYPE2231	=	NetAPIList.player_mail_delete.DataStruct,
	MSGTYPE2237	=	NetAPIList.recv_mail_count.DataStruct,
	MSGTYPE2226	=	NetAPIList.recv_monster_list.DataStruct,
	MSGTYPE2221	=	NetAPIList.goods_sell.DataStruct,
	MSGTYPE2215	=	NetAPIList.player_bag.DataStruct,
	MSGTYPE228	=	NetAPIList.recv_player_chapter_list.DataStruct,
} 

function NetAPIList:getDataStructFromMsgType(msgType)
	 return self.CodeToMsgType[msgType]
end
