------------------- API type ---------------
NetAPIList= { 

	-- 待用加密key. 
	code_ack = 
	{ 
		Code = 10001,
		DataStruct= 'pt_code',
	}, 

	-- HeartBeat 
	heartbeat_req = 
	{ 
		Code = 1,
		DataStruct= 'pt_int',
	}, 

	-- GM指令 
	gm_cmd_req = 
	{ 
		Code = 2,
		DataStruct= 'pt_gmcmd',
	}, 

	-- 注册 
	login_req = 
	{ 
		Code = 10,
		DataStruct= 'pt_account',
	}, 

	-- 登录 
	register_req = 
	{ 
		Code = 11,
		DataStruct= 'pt_account',
	}, 

	-- 返回玩家数据快照 
	login_ack = 
	{ 
		Code = 20,
		DataStruct= 'pt_int',
	}, 

	-- 请求更新等级 
	user_l_req = 
	{ 
		Code = 60,
		DataStruct= 'pt_int',
	}, 

	-- 修改头像 
	user_icon_req = 
	{ 
		Code = 65,
		DataStruct= 'pt_int',
	}, 

	-- 合成魔法卷 
	mix_magic_req = 
	{ 
		Code = 66,
		DataStruct= 'pt_int',
	}, 

	-- 修改名字 
	user_name_req = 
	{ 
		Code = 67,
		DataStruct= 'string',
	}, 

	-- 改名字花费 
	name_cost_req = 
	{ 
		Code = 68,
		DataStruct= 'pt_int',
	}, 

	-- 改名字花费 
	name_cost_ack = 
	{ 
		Code = 69,
		DataStruct= 'pt_int',
	}, 

	-- 返回玩家数据快照 
	users_cah = 
	{ 
		Code = 70,
		DataStruct= 'db_user',
	}, 

	-- 加钱 
	user_m_req = 
	{ 
		Code = 130,
		DataStruct= 'pt_int',
	}, 

	-- 玩家卡牌数据的cache组 
	cards_cah = 
	{ 
		Code = 141,
		DataStruct= 'db_cards',
	}, 

	-- 玩家卡牌数据的cache组 
	cards_cah_new = 
	{ 
		Code = 142,
		DataStruct= 'db_card',
	}, 

	-- 玩家卡牌数据的cache组 
	cards_cah_del = 
	{ 
		Code = 143,
		DataStruct= 'pt_pkid',
	}, 

	-- 玩家卡牌数据的cache组 
	cards_cah_dels = 
	{ 
		Code = 144,
		DataStruct= 'pt_pkids',
	}, 

	-- 玩家卡牌数据的cache组 
	cards_cah_upt = 
	{ 
		Code = 145,
		DataStruct= 'db_card',
	}, 

	-- 增加一张卡牌 
	card_a_req = 
	{ 
		Code = 150,
		DataStruct= 'pt_int',
	}, 

	-- 删除一张卡牌 
	card_d_req = 
	{ 
		Code = 151,
		DataStruct= 'pt_int',
	}, 

	-- 玩家卡组数据的cache组. 
	groups_cah = 
	{ 
		Code = 161,
		DataStruct= 'db_groups',
	}, 

	-- 玩家卡组数据的cache组. 
	groups_cah_new = 
	{ 
		Code = 162,
		DataStruct= 'db_group',
	}, 

	-- 玩家卡组数据的cache组. 
	groups_cah_del = 
	{ 
		Code = 163,
		DataStruct= 'pt_pkid',
	}, 

	-- 玩家卡组数据的cache组. 
	groups_cah_dels = 
	{ 
		Code = 164,
		DataStruct= 'pt_pkids',
	}, 

	-- 玩家卡组数据的cache组. 
	groups_cah_upt = 
	{ 
		Code = 165,
		DataStruct= 'db_group',
	}, 

	-- 激活一个新开组 
	group_a_req = 
	{ 
		Code = 170,
		DataStruct= 'pt_int',
	}, 

	-- 增加一个卡牌到卡组 
	group_upac_req = 
	{ 
		Code = 171,
		DataStruct= 'pt_group_ac',
	}, 

	-- 从卡组中移除一张卡牌 
	group_updc_req = 
	{ 
		Code = 172,
		DataStruct= 'pt_group_dc',
	}, 

	-- 增加一个符文到卡组 
	group_upar_req = 
	{ 
		Code = 173,
		DataStruct= 'pt_group_ar',
	}, 

	-- 从卡组中移除一张符文 
	group_updr_req = 
	{ 
		Code = 174,
		DataStruct= 'pt_group_dr',
	}, 

	-- 交换出战卡组 
	group_change_req = 
	{ 
		Code = 175,
		DataStruct= 'pt_int',
	}, 

	-- 玩家符文数据的cache组. 
	runes_cah = 
	{ 
		Code = 181,
		DataStruct= 'db_runes',
	}, 

	-- 玩家符文数据的cache组. 
	runes_cah_new = 
	{ 
		Code = 182,
		DataStruct= 'db_rune',
	}, 

	-- 玩家符文数据的cache组. 
	runes_cah_del = 
	{ 
		Code = 183,
		DataStruct= 'pt_pkid',
	}, 

	-- 玩家符文数据的cache组. 
	runes_cah_dels = 
	{ 
		Code = 184,
		DataStruct= 'pt_pkids',
	}, 

	-- 玩家符文数据的cache组. 
	runes_cah_upt = 
	{ 
		Code = 185,
		DataStruct= 'db_rune',
	}, 

	-- 增加一个符文 
	rune_a_req = 
	{ 
		Code = 190,
		DataStruct= 'pt_int',
	}, 

	-- 删除一个符文 
	rune_d_req = 
	{ 
		Code = 191,
		DataStruct= 'pt_int',
	}, 

	-- 玩家剧情数据的cache组. 
	storys_cah = 
	{ 
		Code = 201,
		DataStruct= 'db_storys',
	}, 

	-- 玩家剧情数据的cache组. 
	storys_cah_new = 
	{ 
		Code = 202,
		DataStruct= 'db_story',
	}, 

	-- 玩家剧情数据的cache组. 
	storys_cah_del = 
	{ 
		Code = 203,
		DataStruct= 'pt_pkid',
	}, 

	-- 玩家剧情数据的cache组. 
	storys_cah_dels = 
	{ 
		Code = 204,
		DataStruct= 'pt_pkids',
	}, 

	-- 玩家剧情数据的cache组. 
	storys_cah_upt = 
	{ 
		Code = 205,
		DataStruct= 'db_story',
	}, 

	-- 增加一个通关剧情(挑战一个关卡) 
	story_a_req = 
	{ 
		Code = 210,
		DataStruct= 'pt_int',
	}, 

	-- 请求挑战战斗返回(自动战斗) 
	fight_data_ack = 
	{ 
		Code = 211,
		DataStruct= 'pk_fight_data_result',
	}, 

	-- 请求战斗的时候要求自动战斗 
	fight_ai_req = 
	{ 
		Code = 212,
		DataStruct= 'pt_int',
	}, 

	-- 发送请求出牌的卡牌列表 
	send_card_req = 
	{ 
		Code = 213,
		DataStruct= 'pt_crdlist',
	}, 

	-- 请求加入冠军争夺战 
	champion_join_req = 
	{ 
		Code = 214,
		DataStruct= 'pt_int',
	}, 

	-- 初始化战斗排名 
	champion_init_ack = 
	{ 
		Code = 215,
		DataStruct= 'pt_champion',
	}, 

	-- 请求查看挑战的对手列表 
	champion_allenemy_req = 
	{ 
		Code = 216,
		DataStruct= 'pt_int',
	}, 

	-- 所有的挑战对手详细信息 
	champion_allenemy_ack = 
	{ 
		Code = 217,
		DataStruct= 'pt_all_enemy',
	}, 

	-- 对排名xxx的玩家进行挑战 
	champion_challenge_req = 
	{ 
		Code = 218,
		DataStruct= 'pt_int',
	}, 

	-- 请求查看挑战的对手列表(同等级) 
	freedom_randenemy_req = 
	{ 
		Code = 219,
		DataStruct= 'pt_int',
	}, 

	-- 所有的挑战对手详细信息 
	freedom_randenemy_ack = 
	{ 
		Code = 220,
		DataStruct= 'pt_all_enemy',
	}, 

	-- 对相同等级的某玩家发起挑战 
	freedom_challenge_req = 
	{ 
		Code = 221,
		DataStruct= 'pt_int',
	}, 

	-- 向自己好友请求切磋 
	friend_challenge_req = 
	{ 
		Code = 222,
		DataStruct= 'pt_int',
	}, 

	-- 请求强化卡牌 
	card_enhance_req = 
	{ 
		Code = 223,
		DataStruct= 'pt_card_enhance',
	}, 

	-- 请求强化符文 
	rune_enhance_req = 
	{ 
		Code = 224,
		DataStruct= 'pt_rune_enhance',
	}, 

	-- 请求查看当前地图通关情况 
	mapinfo_req = 
	{ 
		Code = 225,
		DataStruct= 'pt_int',
	}, 

	-- 请求返回地图通关情况 
	mapinfo_ack = 
	{ 
		Code = 226,
		DataStruct= 'pt_mapinfo',
	}, 

	-- nadatest 
	nada_req = 
	{ 
		Code = 227,
		DataStruct= 'pt_int',
	}, 

	-- nadatestback 
	nada_ack = 
	{ 
		Code = 228,
		DataStruct= 'pt_nadainfo',
	}, 

	-- 请求挑战战斗返回(手动操作) 
	fight_data_hand_ack = 
	{ 
		Code = 229,
		DataStruct= 'pk_fight_data_result',
	}, 

	-- 一次性提交卡组更新卡牌消息 
	group_update_req = 
	{ 
		Code = 230,
		DataStruct= 'pt_groupupd_card',
	}, 

	-- 一次性提交卡组更新符文消息 
	group_updrune_req = 
	{ 
		Code = 231,
		DataStruct= 'pt_groupupd_rune',
	}, 

	-- 奖励详细信息(实际得到的) 
	prize_get_ack = 
	{ 
		Code = 232,
		DataStruct= 'pt_prize_get',
	}, 

	-- 玩家错误报告 
	player_report_req = 
	{ 
		Code = 233,
		DataStruct= 'pt_player_report',
	}, 

	-- 玩家卖出卡牌 
	sale_card_req = 
	{ 
		Code = 234,
		DataStruct= 'pt_pkids',
	}, 

	-- 玩家卖出符文 
	sale_rune_req = 
	{ 
		Code = 235,
		DataStruct= 'pt_pkids',
	}, 

	-- 快速通关(探索) 
	story_quick_pass_req = 
	{ 
		Code = 236,
		DataStruct= 'pt_int',
	}, 

	-- 获得过的卡牌列表(换头像) 
	card_once_req = 
	{ 
		Code = 237,
		DataStruct= 'pt_int',
	}, 

	-- 获得过的卡牌列表(换头像) 
	card_once_ack = 
	{ 
		Code = 238,
		DataStruct= 'pt_pkids',
	}, 

	-- 获得过的符文列表(换头像) 
	rune_once_req = 
	{ 
		Code = 239,
		DataStruct= 'pt_int',
	}, 

	-- 获得过的符文列表(换头像) 
	rune_once_ack = 
	{ 
		Code = 240,
		DataStruct= 'pt_pkids',
	}, 

	-- 请求迷宫数据(初始化) 
	maze_a_req = 
	{ 
		Code = 241,
		DataStruct= 'pt_int',
	}, 

	-- 迷宫数据 
	maze_a_ack = 
	{ 
		Code = 242,
		DataStruct= 'pt_maze',
	}, 

	-- 请求挑战迷宫 
	maze_fight_req = 
	{ 
		Code = 243,
		DataStruct= 'pt_int',
	}, 

	-- 请求重置迷宫 
	maze_refush_req = 
	{ 
		Code = 244,
		DataStruct= 'pt_int',
	}, 

	-- 隐藏关卡信息 
	story_hide_req = 
	{ 
		Code = 245,
		DataStruct= 'pt_int',
	}, 

	-- 隐藏关卡信息 
	story_hide_ack = 
	{ 
		Code = 246,
		DataStruct= 'pt_story_hide',
	}, 

	-- 所有迷宫信息 
	maze_all_req = 
	{ 
		Code = 247,
		DataStruct= 'pt_int',
	}, 

	-- 所有迷宫信息 
	maze_all_ack = 
	{ 
		Code = 248,
		DataStruct= 'pt_maze_all',
	}, 

	-- 查看可以打的关卡但是还没通关的 
	maybe_story_req = 
	{ 
		Code = 249,
		DataStruct= 'pt_int',
	}, 

	-- 查看可以打的关卡但是还没通关的返回关卡 
	maybe_story_ack = 
	{ 
		Code = 250,
		DataStruct= 'pt_pkids',
	}, 

	-- 请求清除排名战cd 
	champion_clean_req = 
	{ 
		Code = 251,
		DataStruct= 'pt_int',
	}, 

	-- 查看排名战前100位玩家 
	champion_top_req = 
	{ 
		Code = 252,
		DataStruct= 'pt_int',
	}, 

	-- 所有的挑战对手详细信息 
	champion_top_ack = 
	{ 
		Code = 253,
		DataStruct= 'pt_all_enemy',
	}, 

	-- 请求自由切磋数据 
	freedom_init_req = 
	{ 
		Code = 254,
		DataStruct= 'pt_int',
	}, 

	-- 自由切磋信息 
	freedom_init_ack = 
	{ 
		Code = 255,
		DataStruct= 'pt_freedom',
	}, 

	-- 请求清除自由切磋cd 
	freedom_clean_req = 
	{ 
		Code = 256,
		DataStruct= 'pt_int',
	}, 

	-- 请求增加挑战次数 
	champion_add_times_req = 
	{ 
		Code = 257,
		DataStruct= 'pt_int',
	}, 

	-- 完成新手引导 
	finish_first_event_req = 
	{ 
		Code = 260,
		DataStruct= 'pt_int',
	}, 

	-- 发送所有我可以挑战的盗贼 
	monster_all_req = 
	{ 
		Code = 450,
		DataStruct= 'pt_int',
	}, 

	-- 可以挑战的盗贼列表 
	monster_all_ack = 
	{ 
		Code = 451,
		DataStruct= 'pt_monster_all',
	}, 

	-- 发现盗贼 
	monster_creat_ack = 
	{ 
		Code = 452,
		DataStruct= 'pt_find_monster',
	}, 

	-- 对盗贼发起挑战 
	monster_challenge_req = 
	{ 
		Code = 453,
		DataStruct= 'pt_int',
	}, 

	-- 请求清除挑战盗贼cd 
	monster_clean_req = 
	{ 
		Code = 454,
		DataStruct= 'pt_int',
	}, 

	-- 对魔神发起挑战 
	crazy_challenge_req = 
	{ 
		Code = 460,
		DataStruct= 'pt_int',
	}, 

	-- 对魔神伤害 
	crazy_challenge_ack = 
	{ 
		Code = 461,
		DataStruct= 'pt_crazy_score',
	}, 

	-- 请求清除挑战魔神cd 
	crazy_clean_req = 
	{ 
		Code = 462,
		DataStruct= 'pt_int',
	}, 

	-- 客户端发送聊天数据. 
	chat_req = 
	{ 
		Code = 1010,
		DataStruct= 'pt_chat2server',
	}, 

	-- 服务器发送聊天数据 
	chat_ack = 
	{ 
		Code = 1011,
		DataStruct= 'pt_chat2player',
	}, 

	-- 玩家好友数据的cache组. 
	friends_cah = 
	{ 
		Code = 301,
		DataStruct= 'db_friends',
	}, 

	-- 玩家好友数据的cache组. 
	friends_cah_new = 
	{ 
		Code = 302,
		DataStruct= 'db_friend',
	}, 

	-- 玩家好友数据的cache组. 
	friends_cah_del = 
	{ 
		Code = 303,
		DataStruct= 'pt_pkid',
	}, 

	-- 玩家好友数据的cache组. 
	friends_cah_dels = 
	{ 
		Code = 304,
		DataStruct= 'pt_pkids',
	}, 

	-- 玩家好友数据的cache组. 
	friends_cah_upt = 
	{ 
		Code = 305,
		DataStruct= 'db_friend',
	}, 

	-- 搜索玩家，好友名字 
	friend_search_req = 
	{ 
		Code = 310,
		DataStruct= 'string',
	}, 

	-- 搜索到的玩家列表 
	friend_search_ack = 
	{ 
		Code = 311,
		DataStruct= 'pt_frd_list',
	}, 

	-- 请求加好友，好友id. 
	friend_add_req = 
	{ 
		Code = 315,
		DataStruct= 'pt_pkid',
	}, 

	-- 同意或拒绝好友申请 
	friend_agree_req = 
	{ 
		Code = 316,
		DataStruct= 'pt_frd_agree',
	}, 

	-- 请求删好友，好友id 
	friend_del_req = 
	{ 
		Code = 320,
		DataStruct= 'pt_pkid',
	}, 

	-- 好友详细数据 
	friend_info_req = 
	{ 
		Code = 325,
		DataStruct= 'pt_pkids',
	}, 

	-- 搜索到的玩家列表 
	friend_info_ack = 
	{ 
		Code = 326,
		DataStruct= 'pt_frd_list',
	}, 

	-- 成就领取奖励 
	grade_gain_req = 
	{ 
		Code = 5000,
		DataStruct= 'pt_int',
	}, 

	-- 成就信息 
	grade_info_req = 
	{ 
		Code = 5005,
		DataStruct= 'pt_int',
	}, 

	-- 成就信息回复 
	grade_info_ack = 
	{ 
		Code = 5006,
		DataStruct= 'pt_grade_info_list',
	}, 

	-- 返回玩家数据快照 
	signs_cah = 
	{ 
		Code = 5100,
		DataStruct= 'db_sign',
	}, 

	-- 领取签到奖励 
	sign_gain_req = 
	{ 
		Code = 5110,
		DataStruct= 'pt_int',
	}, 

	-- 玩家宝箱数据的cache组 
	chests_cah = 
	{ 
		Code = 401,
		DataStruct= 'db_chests',
	}, 

	-- 玩家宝箱数据的cache组 
	chests_cah_new = 
	{ 
		Code = 402,
		DataStruct= 'db_chest',
	}, 

	-- 玩家宝箱数据的cache组 
	chests_cah_del = 
	{ 
		Code = 403,
		DataStruct= 'pt_pkid',
	}, 

	-- 玩家宝箱数据的cache组 
	chests_cah_dels = 
	{ 
		Code = 404,
		DataStruct= 'pt_pkids',
	}, 

	-- 玩家宝箱数据的cache组 
	chests_cah_upt = 
	{ 
		Code = 405,
		DataStruct= 'db_chest',
	}, 

	-- 领取宝箱奖励 
	chest_get_req = 
	{ 
		Code = 410,
		DataStruct= 'pt_int',
	}, 

	-- 奖励测试 
	prize_test_req = 
	{ 
		Code = 411,
		DataStruct= 'pt_prize_test',
	}, 

	-- 冥想 
	temple_meditation_req = 
	{ 
		Code = 5200,
		DataStruct= 'pt_int',
	}, 

	-- 一键处理 
	temple_process_req = 
	{ 
		Code = 5201,
		DataStruct= 'pt_int',
	}, 

	-- 符文交换 
	temple_rune_exchange_req = 
	{ 
		Code = 5202,
		DataStruct= 'pt_int',
	}, 

	-- 神庙数据请求 
	temple_data_req = 
	{ 
		Code = 5203,
		DataStruct= 'pt_int',
	}, 

	-- 神庙数据 
	temple_data_ack = 
	{ 
		Code = 5204,
		DataStruct= 'pt_temple_datas',
	}, 

	-- 军团创建 
	legion_create_req = 
	{ 
		Code = 500,
		DataStruct= 'pt_create_legion',
	}, 

	-- 获取我的军团信息 
	legion_mine_req = 
	{ 
		Code = 505,
		DataStruct= 'pt_int',
	}, 

	-- 我的军团信息 
	legion_mine_ack = 
	{ 
		Code = 506,
		DataStruct= 'pt_len_all_info',
	}, 

	-- 获取军团列表 
	legion_list_req = 
	{ 
		Code = 510,
		DataStruct= 'pt_int',
	}, 

	-- 搜索军团 
	legion_search_req = 
	{ 
		Code = 511,
		DataStruct= 'string',
	}, 

	-- 军团列表回执 
	legion_list_ack = 
	{ 
		Code = 512,
		DataStruct= 'pt_len_list',
	}, 

	-- 其他军团的详细信息 
	legion_other_req = 
	{ 
		Code = 515,
		DataStruct= 'pt_pkid',
	}, 

	-- 其他军团的详细信息 
	legion_other_ack = 
	{ 
		Code = 516,
		DataStruct= 'pt_len_all_info',
	}, 

	-- 获取申请入团列表 
	legion_apply_list_req = 
	{ 
		Code = 530,
		DataStruct= 'pt_int',
	}, 

	-- 申请入团列表 
	legion_apply_list_ack = 
	{ 
		Code = 531,
		DataStruct= 'pt_len_apply_list',
	}, 

	-- 申请入团 
	legion_apply_req = 
	{ 
		Code = 532,
		DataStruct= 'pt_pkid',
	}, 

	-- 答复入团申请 
	legion_apply_opr_req = 
	{ 
		Code = 533,
		DataStruct= 'pt_len_apply_opr',
	}, 

	-- 邀请入团 
	legion_invite_req = 
	{ 
		Code = 534,
		DataStruct= 'pt_pkid',
	}, 

	-- 答复入团邀请 
	legion_invite_opr_req = 
	{ 
		Code = 535,
		DataStruct= 'pt_len_apply_opr',
	}, 

	-- 申请入团回执 
	legion_apply_ack = 
	{ 
		Code = 536,
		DataStruct= 'pt_int',
	}, 

	-- 退出军团 
	legion_quit_req = 
	{ 
		Code = 540,
		DataStruct= 'pt_int',
	}, 

	-- 军团踢人 
	legion_del_req = 
	{ 
		Code = 541,
		DataStruct= 'pt_pkid',
	}, 

	-- 军团转让团长 
	legion_shift_req = 
	{ 
		Code = 545,
		DataStruct= 'pt_pkid',
	}, 

	-- 军团捐献 
	legion_devote_req = 
	{ 
		Code = 550,
		DataStruct= 'pt_len_devote',
	}, 

	-- 军团设置军旗 
	legion_flag_req = 
	{ 
		Code = 555,
		DataStruct= 'pt_int',
	}, 

	-- 设置军旗回执 
	legion_flag_ack = 
	{ 
		Code = 556,
		DataStruct= 'pt_int',
	}, 

	-- 军团购买 
	legion_buy_req = 
	{ 
		Code = 560,
		DataStruct= 'pt_int',
	}, 

	-- 修改军团口号 
	legion_remark_req = 
	{ 
		Code = 565,
		DataStruct= 'string',
	}, 

	-- 修改口号回执 
	legion_remark_ack = 
	{ 
		Code = 566,
		DataStruct= 'string',
	}, 

	-- 修改免批锁 
	legion_lock_req = 
	{ 
		Code = 570,
		DataStruct= 'pt_int',
	}, 

	-- 修改免批锁回执 
	legion_lock_ack = 
	{ 
		Code = 571,
		DataStruct= 'pt_int',
	}, 

	-- 未加入军团的玩家列表 
	legion_notjoin_req = 
	{ 
		Code = 575,
		DataStruct= 'pt_int',
	}, 

	-- 未加入军团的玩家列表 
	legion_notjoin_ack = 
	{ 
		Code = 576,
		DataStruct= 'pt_len_apply_list',
	}, 

	-- 设置守卫 
	legion_guard_req = 
	{ 
		Code = 577,
		DataStruct= 'pt_pkid',
	}, 

	-- 未加入军团的玩家列表 
	legion_self_ntf = 
	{ 
		Code = 580,
		DataStruct= 'pt_legion_self',
	}, 

	-- 获取商城列表 
	market_get_req = 
	{ 
		Code = 600,
		DataStruct= 'pt_int',
	}, 

	-- 商城列表 
	market_get_ack = 
	{ 
		Code = 601,
		DataStruct= 'pt_market',
	}, 

	-- 购买商城物品 
	market_buy_req = 
	{ 
		Code = 602,
		DataStruct= 'pt_market_buy',
	}, 

	-- 购买卡牌回执信息 
	market_card_ack = 
	{ 
		Code = 603,
		DataStruct= 'pt_market_card',
	}, 

	-- 购买晶钻回执信息 
	market_gold_ack = 
	{ 
		Code = 604,
		DataStruct= 'pt_market_gold',
	}, 

	-- 购买行动力回执信息 
	market_power_ack = 
	{ 
		Code = 605,
		DataStruct= 'pt_market_power',
	}, 

	-- 获取排行榜资料 
	ranks_get_req = 
	{ 
		Code = 700,
		DataStruct= 'pt_ranks_get',
	}, 

	-- 排行榜资料 
	ranks_get_ack = 
	{ 
		Code = 701,
		DataStruct= 'pt_ranks_list',
	}, 

	-- 获取大地图信息 
	map_info_req = 
	{ 
		Code = 800,
		DataStruct= 'pt_int',
	}, 

	-- 大地图信息回执 
	map_info_ack = 
	{ 
		Code = 801,
		DataStruct= 'pt_map_info',
	}, 

	-- 地图好友信息回执 
	map_friend_ack = 
	{ 
		Code = 802,
		DataStruct= 'pt_map_friend_list',
	}, 

	-- 领取地图产出 
	map_gain_req = 
	{ 
		Code = 805,
		DataStruct= 'pt_int',
	}, 

	-- 地图产出回执 
	map_gain_ack = 
	{ 
		Code = 806,
		DataStruct= 'pt_map_gain',
	}, 

	-- 一键领取地图产出 
	map_gain_all_req = 
	{ 
		Code = 807,
		DataStruct= 'pt_int',
	}, 

	-- 一键领取地图产出回执 
	map_gain_all_ack = 
	{ 
		Code = 808,
		DataStruct= 'pt_int',
	}, 

	-- 关卡入侵被清理 
	story_invade_ntf = 
	{ 
		Code = 810,
		DataStruct= 'pt_int',
	}, 

	-- 获取玩家邮件 
	get_mail_req = 
	{ 
		Code = 900,
		DataStruct= 'pt_int',
	}, 

	-- 玩家邮件回执 
	get_mail_ack = 
	{ 
		Code = 901,
		DataStruct= 'pt_player_mail_list',
	}, 

	-- 您有新的消息^_^ 
	new_mail_ntf = 
	{ 
		Code = 910,
		DataStruct= 'pt_new_mail_list',
	}, 

	-- 读取邮件 
	read_mail_req = 
	{ 
		Code = 915,
		DataStruct= 'pt_pkid',
	}, 

	-- 读取邮件回执 
	read_mail_ack = 
	{ 
		Code = 916,
		DataStruct= 'string',
	}, 

	-- 删除邮件 
	del_mail_req = 
	{ 
		Code = 920,
		DataStruct= 'pt_pkid',
	}, 

	-- 写邮件 
	write_mail_req = 
	{ 
		Code = 925,
		DataStruct= 'pt_write_mail',
	}, 

	-- PVE战斗LOG信息 
	pve_log_req = 
	{ 
		Code = 1000,
		DataStruct= 'pt_int',
	}, 

	-- PVE战斗LOG回执 
	pve_log_ack = 
	{ 
		Code = 1001,
		DataStruct= 'pt_pvelog_list',
	}, 

	-- PVE战斗LOG信息 
	pvp_log_req = 
	{ 
		Code = 1005,
		DataStruct= 'pt_int',
	}, 

	-- PVP战斗LOG回执 
	pvp_log_ack = 
	{ 
		Code = 1006,
		DataStruct= 'pt_pvplog_list',
	}, 

	-- PVE战斗LOG信息 
	play_fightlog_req = 
	{ 
		Code = 1050,
		DataStruct= 'pt_pkid',
	}, 

	-- 战斗LOG回执 
	play_fightlog_ack = 
	{ 
		Code = 1051,
		DataStruct= 'pk_fight_data_result',
	}, 

	-- 赠送行动力数据的cache组. 
	powergifts_cah = 
	{ 
		Code = 1101,
		DataStruct= 'db_powergifts',
	}, 

	-- 赠送行动力数据的cache组. 
	powergifts_cah_new = 
	{ 
		Code = 1102,
		DataStruct= 'db_powergift',
	}, 

	-- 赠送行动力数据的cache组. 
	powergifts_cah_del = 
	{ 
		Code = 1103,
		DataStruct= 'pt_pkid',
	}, 

	-- 赠送行动力数据的cache组. 
	powergifts_cah_dels = 
	{ 
		Code = 1104,
		DataStruct= 'pt_pkids',
	}, 

	-- 赠送行动力数据的cache组. 
	powergifts_cah_upt = 
	{ 
		Code = 1105,
		DataStruct= 'db_powergift',
	}, 

	-- 求救 
	powergift_help_req = 
	{ 
		Code = 1110,
		DataStruct= 'pt_pkid',
	}, 

	-- 赠送行动力 
	powergift_give_req = 
	{ 
		Code = 1115,
		DataStruct= 'pt_pkid',
	}, 

	-- 领取行动力 
	powergift_get_req = 
	{ 
		Code = 1120,
		DataStruct= 'pt_pkid',
	}, 

	-- 服务器验证支付请求 
	pay_verify_req = 
	{ 
		Code = 1121,
		DataStruct= 'pt_pay_verify',
	}, 

	-- 查询支付商品列表 
	pay_list_req = 
	{ 
		Code = 1122,
		DataStruct= 'pt_pay_list_get',
	}, 

	-- 支付商品列表 
	pay_list_ack = 
	{ 
		Code = 1123,
		DataStruct= 'pt_pay_list',
	}, 

	-- 积分战榜单获取 
	legion_rank_req = 
	{ 
		Code = 1125,
		DataStruct= 'pt_legion_rank_get',
	}, 

	-- 积分战榜单 
	legion_rank_ack = 
	{ 
		Code = 1126,
		DataStruct= 'pt_legion_rank_list',
	}, 

	-- 积分战中某一军团的详细信息获取 
	legion_detail_rank_req = 
	{ 
		Code = 1127,
		DataStruct= 'pt_pkid',
	}, 

	-- 积分战中某一军团的详细信息 
	legion_detail_rank_ack = 
	{ 
		Code = 1128,
		DataStruct= 'pt_player_rank_list',
	}, 

	-- 积分战挑战。 
	legion_lrank_challenge_req = 
	{ 
		Code = 1129,
		DataStruct= 'pt_pkid',
	}, 

	-- 玩家按照等级随机匹配积分榜上没有军团的玩家 
	lrank_no_legion_req = 
	{ 
		Code = 1130,
		DataStruct= 'pt_int',
	}, 

	-- 未加入军团的玩家的挑战列表 
	lrank_no_legion_ack = 
	{ 
		Code = 1131,
		DataStruct= 'pt_player_rank_list',
	}, 

	-- 积分战挑战次数购买 
	lrank_buy_req = 
	{ 
		Code = 1132,
		DataStruct= 'pt_int',
	}, 

	-- 积分战挑战次数购买 
	lrank_buy_ack = 
	{ 
		Code = 1133,
		DataStruct= 'pt_lrank_buy',
	}, 

	-- 积分战玩家榜单。 
	player_lrank_list_req = 
	{ 
		Code = 1134,
		DataStruct= 'pt_legion_rank_get',
	}, 

	-- 积分战玩家榜单。 
	player_lrank_list_ack = 
	{ 
		Code = 1135,
		DataStruct= 'pt_p_rank_list',
	}, 

	-- 玩家发起GVG匹配 
	gvg_match_req = 
	{ 
		Code = 1200,
		DataStruct= 'pt_int',
	}, 

	-- 玩家进入GVG战场 
	gvg_into_battle_req = 
	{ 
		Code = 1201,
		DataStruct= 'pt_int',
	}, 

	-- 玩家退出GVG战场 
	gvg_out_battle_req = 
	{ 
		Code = 1203,
		DataStruct= 'pt_int',
	}, 

	-- 玩家进入GVG战场时的初始化信息 
	gvg_battle_init_ack = 
	{ 
		Code = 1204,
		DataStruct= 'pt_gvg_init_battle_list',
	}, 

	-- 通知军团所有人，GVG战斗开始 
	gvg_battle_begin_ntf = 
	{ 
		Code = 1205,
		DataStruct= 'pt_int',
	}, 

	-- GVG战斗结束 
	gvg_battle_end_ntf = 
	{ 
		Code = 1206,
		DataStruct= 'pt_gvg_battle_end',
	}, 

	-- gvg玩家战斗请求 
	gvg_fight_req = 
	{ 
		Code = 1207,
		DataStruct= 'pt_gvg_fight',
	}, 

	-- gvg护盾变化广播 
	gvg_shield_ntf = 
	{ 
		Code = 1208,
		DataStruct= 'pt_gvg_shield',
	}, 

	-- gvg战斗次数更新 
	gvg_attack_num_ntf = 
	{ 
		Code = 1209,
		DataStruct= 'pt_int',
	}, 

	-- gvg第一次打开界面 
	gvg_first_req = 
	{ 
		Code = 1210,
		DataStruct= 'pt_int',
	}, 

	-- gvg第一次打开界面回执 
	gvg_first_ack = 
	{ 
		Code = 1211,
		DataStruct= 'pt_gvg_first',
	}, 

	-- gvg星图 
	gvg_star_req = 
	{ 
		Code = 1212,
		DataStruct= 'pt_int',
	}, 

	-- gvg星图回执 
	gvg_star_ack = 
	{ 
		Code = 1213,
		DataStruct= 'pt_gvg_star_list',
	}, 

	-- gvg排行 
	gvg_rank_req = 
	{ 
		Code = 1214,
		DataStruct= 'pt_int',
	}, 

	-- gvg排行回执 
	gvg_rank_ack = 
	{ 
		Code = 1215,
		DataStruct= 'pt_gvg_rank_list',
	}, 

	-- gvg军团LOG 
	gvg_legion_log_req = 
	{ 
		Code = 1216,
		DataStruct= 'pt_int',
	}, 

	-- gvg军团LOG 
	gvg_legion_log_ack = 
	{ 
		Code = 1217,
		DataStruct= 'pt_gvg_legion_log_list',
	}, 

	-- gvg成员LOG 
	gvg_player_log_req = 
	{ 
		Code = 1218,
		DataStruct= 'pt_int',
	}, 

	-- gvg成员LOG 
	gvg_player_log_ack = 
	{ 
		Code = 1219,
		DataStruct= 'pt_gvg_player_log_list',
	}, 

	-- gvg登录提示 
	gvg_login_ntf = 
	{ 
		Code = 1220,
		DataStruct= 'pt_gvg_login',
	}, 

	-- gvg购买护盾 
	gvg_buy_shield_req = 
	{ 
		Code = 1221,
		DataStruct= 'pt_int',
	}, 

	-- gvg购买进攻次数 
	gvg_buy_attack_req = 
	{ 
		Code = 1222,
		DataStruct= 'pt_int',
	}, 

	-- gvg战场积分变化 
	gvg_battle_scores_ntf = 
	{ 
		Code = 1223,
		DataStruct= 'pt_gvg_scores',
	}, 
} 

NetAPIList.CodeToMsgType = { 
	MSGTYPE175	=	NetAPIList.group_change_req.DataStruct,
	MSGTYPE920	=	NetAPIList.del_mail_req.DataStruct,
	MSGTYPE69	=	NetAPIList.name_cost_ack.DataStruct,
	MSGTYPE212	=	NetAPIList.fight_ai_req.DataStruct,
	MSGTYPE67	=	NetAPIList.user_name_req.DataStruct,
	MSGTYPE229	=	NetAPIList.fight_data_hand_ack.DataStruct,
	MSGTYPE240	=	NetAPIList.rune_once_ack.DataStruct,
	MSGTYPE576	=	NetAPIList.legion_notjoin_ack.DataStruct,
	MSGTYPE800	=	NetAPIList.map_info_req.DataStruct,
	MSGTYPE535	=	NetAPIList.legion_invite_opr_req.DataStruct,
	MSGTYPE1221	=	NetAPIList.gvg_buy_shield_req.DataStruct,
	MSGTYPE203	=	NetAPIList.storys_cah_del.DataStruct,
	MSGTYPE151	=	NetAPIList.card_d_req.DataStruct,
	MSGTYPE311	=	NetAPIList.friend_search_ack.DataStruct,
	MSGTYPE246	=	NetAPIList.story_hide_ack.DataStruct,
	MSGTYPE68	=	NetAPIList.name_cost_req.DataStruct,
	MSGTYPE575	=	NetAPIList.legion_notjoin_req.DataStruct,
	MSGTYPE10001	=	NetAPIList.code_ack.DataStruct,
	MSGTYPE315	=	NetAPIList.friend_add_req.DataStruct,
	MSGTYPE605	=	NetAPIList.market_power_ack.DataStruct,
	MSGTYPE806	=	NetAPIList.map_gain_ack.DataStruct,
	MSGTYPE172	=	NetAPIList.group_updc_req.DataStruct,
	MSGTYPE915	=	NetAPIList.read_mail_req.DataStruct,
	MSGTYPE301	=	NetAPIList.friends_cah.DataStruct,
	MSGTYPE216	=	NetAPIList.champion_allenemy_req.DataStruct,
	MSGTYPE320	=	NetAPIList.friend_del_req.DataStruct,
	MSGTYPE600	=	NetAPIList.market_get_req.DataStruct,
	MSGTYPE66	=	NetAPIList.mix_magic_req.DataStruct,
	MSGTYPE219	=	NetAPIList.freedom_randenemy_req.DataStruct,
	MSGTYPE251	=	NetAPIList.champion_clean_req.DataStruct,
	MSGTYPE451	=	NetAPIList.monster_all_ack.DataStruct,
	MSGTYPE234	=	NetAPIList.sale_card_req.DataStruct,
	MSGTYPE253	=	NetAPIList.champion_top_ack.DataStruct,
	MSGTYPE1223	=	NetAPIList.gvg_battle_scores_ntf.DataStruct,
	MSGTYPE580	=	NetAPIList.legion_self_ntf.DataStruct,
	MSGTYPE1222	=	NetAPIList.gvg_buy_attack_req.DataStruct,
	MSGTYPE1220	=	NetAPIList.gvg_login_ntf.DataStruct,
	MSGTYPE1219	=	NetAPIList.gvg_player_log_ack.DataStruct,
	MSGTYPE1218	=	NetAPIList.gvg_player_log_req.DataStruct,
	MSGTYPE222	=	NetAPIList.friend_challenge_req.DataStruct,
	MSGTYPE533	=	NetAPIList.legion_apply_opr_req.DataStruct,
	MSGTYPE1216	=	NetAPIList.gvg_legion_log_req.DataStruct,
	MSGTYPE226	=	NetAPIList.mapinfo_ack.DataStruct,
	MSGTYPE141	=	NetAPIList.cards_cah.DataStruct,
	MSGTYPE1000	=	NetAPIList.pve_log_req.DataStruct,
	MSGTYPE250	=	NetAPIList.maybe_story_ack.DataStruct,
	MSGTYPE1104	=	NetAPIList.powergifts_cah_dels.DataStruct,
	MSGTYPE1213	=	NetAPIList.gvg_star_ack.DataStruct,
	MSGTYPE410	=	NetAPIList.chest_get_req.DataStruct,
	MSGTYPE515	=	NetAPIList.legion_other_req.DataStruct,
	MSGTYPE1212	=	NetAPIList.gvg_star_req.DataStruct,
	MSGTYPE510	=	NetAPIList.legion_list_req.DataStruct,
	MSGTYPE1131	=	NetAPIList.lrank_no_legion_ack.DataStruct,
	MSGTYPE60	=	NetAPIList.user_l_req.DataStruct,
	MSGTYPE1210	=	NetAPIList.gvg_first_req.DataStruct,
	MSGTYPE1135	=	NetAPIList.player_lrank_list_ack.DataStruct,
	MSGTYPE70	=	NetAPIList.users_cah.DataStruct,
	MSGTYPE1209	=	NetAPIList.gvg_attack_num_ntf.DataStruct,
	MSGTYPE1208	=	NetAPIList.gvg_shield_ntf.DataStruct,
	MSGTYPE1207	=	NetAPIList.gvg_fight_req.DataStruct,
	MSGTYPE173	=	NetAPIList.group_upar_req.DataStruct,
	MSGTYPE232	=	NetAPIList.prize_get_ack.DataStruct,
	MSGTYPE310	=	NetAPIList.friend_search_req.DataStruct,
	MSGTYPE1132	=	NetAPIList.lrank_buy_req.DataStruct,
	MSGTYPE233	=	NetAPIList.player_report_req.DataStruct,
	MSGTYPE1129	=	NetAPIList.legion_lrank_challenge_req.DataStruct,
	MSGTYPE1203	=	NetAPIList.gvg_out_battle_req.DataStruct,
	MSGTYPE404	=	NetAPIList.chests_cah_dels.DataStruct,
	MSGTYPE182	=	NetAPIList.runes_cah_new.DataStruct,
	MSGTYPE541	=	NetAPIList.legion_del_req.DataStruct,
	MSGTYPE925	=	NetAPIList.write_mail_req.DataStruct,
	MSGTYPE214	=	NetAPIList.champion_join_req.DataStruct,
	MSGTYPE217	=	NetAPIList.champion_allenemy_ack.DataStruct,
	MSGTYPE211	=	NetAPIList.fight_data_ack.DataStruct,
	MSGTYPE150	=	NetAPIList.card_a_req.DataStruct,
	MSGTYPE213	=	NetAPIList.send_card_req.DataStruct,
	MSGTYPE1134	=	NetAPIList.player_lrank_list_req.DataStruct,
	MSGTYPE1133	=	NetAPIList.lrank_buy_ack.DataStruct,
	MSGTYPE1205	=	NetAPIList.gvg_battle_begin_ntf.DataStruct,
	MSGTYPE1211	=	NetAPIList.gvg_first_ack.DataStruct,
	MSGTYPE1130	=	NetAPIList.lrank_no_legion_req.DataStruct,
	MSGTYPE1204	=	NetAPIList.gvg_battle_init_ack.DataStruct,
	MSGTYPE204	=	NetAPIList.storys_cah_dels.DataStruct,
	MSGTYPE174	=	NetAPIList.group_updr_req.DataStruct,
	MSGTYPE1128	=	NetAPIList.legion_detail_rank_ack.DataStruct,
	MSGTYPE1127	=	NetAPIList.legion_detail_rank_req.DataStruct,
	MSGTYPE462	=	NetAPIList.crazy_clean_req.DataStruct,
	MSGTYPE238	=	NetAPIList.card_once_ack.DataStruct,
	MSGTYPE2	=	NetAPIList.gm_cmd_req.DataStruct,
	MSGTYPE571	=	NetAPIList.legion_lock_ack.DataStruct,
	MSGTYPE1126	=	NetAPIList.legion_rank_ack.DataStruct,
	MSGTYPE1	=	NetAPIList.heartbeat_req.DataStruct,
	MSGTYPE243	=	NetAPIList.maze_fight_req.DataStruct,
	MSGTYPE1102	=	NetAPIList.powergifts_cah_new.DataStruct,
	MSGTYPE161	=	NetAPIList.groups_cah.DataStruct,
	MSGTYPE1122	=	NetAPIList.pay_list_req.DataStruct,
	MSGTYPE454	=	NetAPIList.monster_clean_req.DataStruct,
	MSGTYPE163	=	NetAPIList.groups_cah_del.DataStruct,
	MSGTYPE402	=	NetAPIList.chests_cah_new.DataStruct,
	MSGTYPE1120	=	NetAPIList.powergift_get_req.DataStruct,
	MSGTYPE5203	=	NetAPIList.temple_data_req.DataStruct,
	MSGTYPE260	=	NetAPIList.finish_first_event_req.DataStruct,
	MSGTYPE506	=	NetAPIList.legion_mine_ack.DataStruct,
	MSGTYPE255	=	NetAPIList.freedom_init_ack.DataStruct,
	MSGTYPE1115	=	NetAPIList.powergift_give_req.DataStruct,
	MSGTYPE236	=	NetAPIList.story_quick_pass_req.DataStruct,
	MSGTYPE1110	=	NetAPIList.powergift_help_req.DataStruct,
	MSGTYPE227	=	NetAPIList.nada_req.DataStruct,
	MSGTYPE20	=	NetAPIList.login_ack.DataStruct,
	MSGTYPE1006	=	NetAPIList.pvp_log_ack.DataStruct,
	MSGTYPE1214	=	NetAPIList.gvg_rank_req.DataStruct,
	MSGTYPE1103	=	NetAPIList.powergifts_cah_del.DataStruct,
	MSGTYPE1123	=	NetAPIList.pay_list_ack.DataStruct,
	MSGTYPE530	=	NetAPIList.legion_apply_list_req.DataStruct,
	MSGTYPE1200	=	NetAPIList.gvg_match_req.DataStruct,
	MSGTYPE1050	=	NetAPIList.play_fightlog_req.DataStruct,
	MSGTYPE1105	=	NetAPIList.powergifts_cah_upt.DataStruct,
	MSGTYPE225	=	NetAPIList.mapinfo_req.DataStruct,
	MSGTYPE228	=	NetAPIList.nada_ack.DataStruct,
	MSGTYPE181	=	NetAPIList.runes_cah.DataStruct,
	MSGTYPE411	=	NetAPIList.prize_test_req.DataStruct,
	MSGTYPE1001	=	NetAPIList.pve_log_ack.DataStruct,
	MSGTYPE184	=	NetAPIList.runes_cah_dels.DataStruct,
	MSGTYPE1215	=	NetAPIList.gvg_rank_ack.DataStruct,
	MSGTYPE231	=	NetAPIList.group_updrune_req.DataStruct,
	MSGTYPE500	=	NetAPIList.legion_create_req.DataStruct,
	MSGTYPE316	=	NetAPIList.friend_agree_req.DataStruct,
	MSGTYPE1051	=	NetAPIList.play_fightlog_ack.DataStruct,
	MSGTYPE916	=	NetAPIList.read_mail_ack.DataStruct,
	MSGTYPE805	=	NetAPIList.map_gain_req.DataStruct,
	MSGTYPE249	=	NetAPIList.maybe_story_req.DataStruct,
	MSGTYPE901	=	NetAPIList.get_mail_ack.DataStruct,
	MSGTYPE452	=	NetAPIList.monster_creat_ack.DataStruct,
	MSGTYPE810	=	NetAPIList.story_invade_ntf.DataStruct,
	MSGTYPE808	=	NetAPIList.map_gain_all_ack.DataStruct,
	MSGTYPE807	=	NetAPIList.map_gain_all_req.DataStruct,
	MSGTYPE802	=	NetAPIList.map_friend_ack.DataStruct,
	MSGTYPE910	=	NetAPIList.new_mail_ntf.DataStruct,
	MSGTYPE242	=	NetAPIList.maze_a_ack.DataStruct,
	MSGTYPE604	=	NetAPIList.market_gold_ack.DataStruct,
	MSGTYPE143	=	NetAPIList.cards_cah_del.DataStruct,
	MSGTYPE220	=	NetAPIList.freedom_randenemy_ack.DataStruct,
	MSGTYPE900	=	NetAPIList.get_mail_req.DataStruct,
	MSGTYPE700	=	NetAPIList.ranks_get_req.DataStruct,
	MSGTYPE602	=	NetAPIList.market_buy_req.DataStruct,
	MSGTYPE223	=	NetAPIList.card_enhance_req.DataStruct,
	MSGTYPE245	=	NetAPIList.story_hide_req.DataStruct,
	MSGTYPE11	=	NetAPIList.register_req.DataStruct,
	MSGTYPE603	=	NetAPIList.market_card_ack.DataStruct,
	MSGTYPE505	=	NetAPIList.legion_mine_req.DataStruct,
	MSGTYPE171	=	NetAPIList.group_upac_req.DataStruct,
	MSGTYPE1125	=	NetAPIList.legion_rank_req.DataStruct,
	MSGTYPE254	=	NetAPIList.freedom_init_req.DataStruct,
	MSGTYPE550	=	NetAPIList.legion_devote_req.DataStruct,
	MSGTYPE252	=	NetAPIList.champion_top_req.DataStruct,
	MSGTYPE566	=	NetAPIList.legion_remark_ack.DataStruct,
	MSGTYPE202	=	NetAPIList.storys_cah_new.DataStruct,
	MSGTYPE210	=	NetAPIList.story_a_req.DataStruct,
	MSGTYPE165	=	NetAPIList.groups_cah_upt.DataStruct,
	MSGTYPE241	=	NetAPIList.maze_a_req.DataStruct,
	MSGTYPE5100	=	NetAPIList.signs_cah.DataStruct,
	MSGTYPE5000	=	NetAPIList.grade_gain_req.DataStruct,
	MSGTYPE532	=	NetAPIList.legion_apply_req.DataStruct,
	MSGTYPE601	=	NetAPIList.market_get_ack.DataStruct,
	MSGTYPE191	=	NetAPIList.rune_d_req.DataStruct,
	MSGTYPE5202	=	NetAPIList.temple_rune_exchange_req.DataStruct,
	MSGTYPE545	=	NetAPIList.legion_shift_req.DataStruct,
	MSGTYPE1201	=	NetAPIList.gvg_into_battle_req.DataStruct,
	MSGTYPE190	=	NetAPIList.rune_a_req.DataStruct,
	MSGTYPE170	=	NetAPIList.group_a_req.DataStruct,
	MSGTYPE239	=	NetAPIList.rune_once_req.DataStruct,
	MSGTYPE540	=	NetAPIList.legion_quit_req.DataStruct,
	MSGTYPE142	=	NetAPIList.cards_cah_new.DataStruct,
	MSGTYPE1101	=	NetAPIList.powergifts_cah.DataStruct,
	MSGTYPE534	=	NetAPIList.legion_invite_req.DataStruct,
	MSGTYPE1217	=	NetAPIList.gvg_legion_log_ack.DataStruct,
	MSGTYPE531	=	NetAPIList.legion_apply_list_ack.DataStruct,
	MSGTYPE536	=	NetAPIList.legion_apply_ack.DataStruct,
	MSGTYPE453	=	NetAPIList.monster_challenge_req.DataStruct,
	MSGTYPE215	=	NetAPIList.champion_init_ack.DataStruct,
	MSGTYPE516	=	NetAPIList.legion_other_ack.DataStruct,
	MSGTYPE5204	=	NetAPIList.temple_data_ack.DataStruct,
	MSGTYPE450	=	NetAPIList.monster_all_req.DataStruct,
	MSGTYPE230	=	NetAPIList.group_update_req.DataStruct,
	MSGTYPE570	=	NetAPIList.legion_lock_req.DataStruct,
	MSGTYPE560	=	NetAPIList.legion_buy_req.DataStruct,
	MSGTYPE555	=	NetAPIList.legion_flag_req.DataStruct,
	MSGTYPE257	=	NetAPIList.champion_add_times_req.DataStruct,
	MSGTYPE5200	=	NetAPIList.temple_meditation_req.DataStruct,
	MSGTYPE405	=	NetAPIList.chests_cah_upt.DataStruct,
	MSGTYPE302	=	NetAPIList.friends_cah_new.DataStruct,
	MSGTYPE565	=	NetAPIList.legion_remark_req.DataStruct,
	MSGTYPE144	=	NetAPIList.cards_cah_dels.DataStruct,
	MSGTYPE256	=	NetAPIList.freedom_clean_req.DataStruct,
	MSGTYPE1121	=	NetAPIList.pay_verify_req.DataStruct,
	MSGTYPE237	=	NetAPIList.card_once_req.DataStruct,
	MSGTYPE401	=	NetAPIList.chests_cah.DataStruct,
	MSGTYPE5110	=	NetAPIList.sign_gain_req.DataStruct,
	MSGTYPE1010	=	NetAPIList.chat_req.DataStruct,
	MSGTYPE403	=	NetAPIList.chests_cah_del.DataStruct,
	MSGTYPE5006	=	NetAPIList.grade_info_ack.DataStruct,
	MSGTYPE5005	=	NetAPIList.grade_info_req.DataStruct,
	MSGTYPE326	=	NetAPIList.friend_info_ack.DataStruct,
	MSGTYPE325	=	NetAPIList.friend_info_req.DataStruct,
	MSGTYPE10	=	NetAPIList.login_req.DataStruct,
	MSGTYPE1206	=	NetAPIList.gvg_battle_end_ntf.DataStruct,
	MSGTYPE305	=	NetAPIList.friends_cah_upt.DataStruct,
	MSGTYPE577	=	NetAPIList.legion_guard_req.DataStruct,
	MSGTYPE512	=	NetAPIList.legion_list_ack.DataStruct,
	MSGTYPE304	=	NetAPIList.friends_cah_dels.DataStruct,
	MSGTYPE185	=	NetAPIList.runes_cah_upt.DataStruct,
	MSGTYPE461	=	NetAPIList.crazy_challenge_ack.DataStruct,
	MSGTYPE1005	=	NetAPIList.pvp_log_req.DataStruct,
	MSGTYPE701	=	NetAPIList.ranks_get_ack.DataStruct,
	MSGTYPE205	=	NetAPIList.storys_cah_upt.DataStruct,
	MSGTYPE5201	=	NetAPIList.temple_process_req.DataStruct,
	MSGTYPE511	=	NetAPIList.legion_search_req.DataStruct,
	MSGTYPE248	=	NetAPIList.maze_all_ack.DataStruct,
	MSGTYPE247	=	NetAPIList.maze_all_req.DataStruct,
	MSGTYPE244	=	NetAPIList.maze_refush_req.DataStruct,
	MSGTYPE1011	=	NetAPIList.chat_ack.DataStruct,
	MSGTYPE65	=	NetAPIList.user_icon_req.DataStruct,
	MSGTYPE235	=	NetAPIList.sale_rune_req.DataStruct,
	MSGTYPE303	=	NetAPIList.friends_cah_del.DataStruct,
	MSGTYPE224	=	NetAPIList.rune_enhance_req.DataStruct,
	MSGTYPE460	=	NetAPIList.crazy_challenge_req.DataStruct,
	MSGTYPE201	=	NetAPIList.storys_cah.DataStruct,
	MSGTYPE164	=	NetAPIList.groups_cah_dels.DataStruct,
	MSGTYPE221	=	NetAPIList.freedom_challenge_req.DataStruct,
	MSGTYPE218	=	NetAPIList.champion_challenge_req.DataStruct,
	MSGTYPE556	=	NetAPIList.legion_flag_ack.DataStruct,
	MSGTYPE183	=	NetAPIList.runes_cah_del.DataStruct,
	MSGTYPE162	=	NetAPIList.groups_cah_new.DataStruct,
	MSGTYPE145	=	NetAPIList.cards_cah_upt.DataStruct,
	MSGTYPE801	=	NetAPIList.map_info_ack.DataStruct,
	MSGTYPE130	=	NetAPIList.user_m_req.DataStruct,
} 

function NetAPIList:getDataStructFromMsgType(msgType)
	 return self.CodeToMsgType[msgType]
end
