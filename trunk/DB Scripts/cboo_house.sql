/*
Navicat MySQL Data Transfer

Source Server         : KIMI
Source Server Version : 50022
Source Host           : localhost:3306
Source Database       : cboo

Target Server Type    : MYSQL
Target Server Version : 50022
File Encoding         : 65001

Date: 2011-03-21 12:50:58
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `base_community_baseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_community_baseinfo`;
CREATE TABLE `base_community_baseinfo` (
  `community_id` char(36) NOT NULL COMMENT '小区\\楼盘ID',
  `community_name` varchar(200) default NULL COMMENT '小区\\楼盘名称',
  `city_id` int(11) default NULL COMMENT '所属城市ID',
  `city_name` varchar(50) default NULL COMMENT '所属城市',
  `region` varchar(50) default NULL COMMENT '所属区域',
  `block` varchar(50) default NULL COMMENT '所属板块',
  `address` varchar(200) default NULL COMMENT '小区地址',
  `community_use` varchar(50) default NULL COMMENT '小区用途：如办公，住宅，商铺等',
  `building_type` varchar(50) default NULL COMMENT '建筑类型：如高层，小高层，别墅，混合等',
  `complete_year` int(11) default NULL COMMENT '竣工年份',
  `remark` varchar(500) default NULL COMMENT '小区描述',
  `pinyin` varchar(200) default NULL COMMENT '小区名拼音首字符',
  `add_person_id` char(36) default NULL COMMENT '小区添加人',
  `status` int(11) default NULL COMMENT '状态：1正常；-1作废',
  PRIMARY KEY  (`community_id`),
  KEY `ix_add_person_id` (`add_person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='小区基本信息表';

-- ----------------------------
-- Records of base_community_baseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_community_buildinginfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_community_buildinginfo`;
CREATE TABLE `base_community_buildinginfo` (
  `building_id` char(36) NOT NULL default '' COMMENT '楼栋ID',
  `community_id` char(36) default NULL COMMENT '小区ID',
  `building_name` varchar(50) default NULL COMMENT '楼栋名称',
  `building_use` varchar(50) default NULL COMMENT '楼栋用途（参见楼盘）',
  `building_type` varchar(50) default NULL COMMENT '楼栋建筑类型（参见楼盘）',
  `building_floor` int(11) default NULL COMMENT '楼栋楼层数',
  `unit_num` int(11) default NULL COMMENT '楼栋单元数',
  `unit_type` varchar(50) default NULL COMMENT '楼栋单元类型',
  `room_rule` varchar(500) default NULL COMMENT '楼栋房间号输入规则(正则表达式)',
  `room_rule_remark` varchar(500) default NULL COMMENT '房间号输入规则描述',
  `status` int(11) default NULL COMMENT '状态：1正常；-1作废',
  PRIMARY KEY  (`building_id`),
  KEY `ix_community_id` USING BTREE (`community_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='小区楼栋信息表';

-- ----------------------------
-- Records of base_community_buildinginfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_datadic_detailinfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_datadic_detailinfo`;
CREATE TABLE `base_datadic_detailinfo` (
  `record_id` char(36) NOT NULL default '',
  `item_key` varchar(50) default NULL COMMENT '字典项目',
  `item_value` varchar(255) default NULL COMMENT '字典项目值',
  `item_index` int(11) default NULL COMMENT '排序顺序',
  PRIMARY KEY  (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统数据字典信息表';

-- ----------------------------
-- Records of base_datadic_detailinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_datadic_iteminfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_datadic_iteminfo`;
CREATE TABLE `base_datadic_iteminfo` (
  `item_id` char(36) NOT NULL default '' COMMENT '字典项目ID',
  `item_key` varchar(50) default NULL COMMENT '字典项目Key',
  `item_name` varchar(100) default NULL COMMENT '字典项名称',
  PRIMARY KEY  (`item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='数据字典项目信息表';

-- ----------------------------
-- Records of base_datadic_iteminfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_personal_push_config`
-- ----------------------------
DROP TABLE IF EXISTS `base_personal_push_config`;
CREATE TABLE `base_personal_push_config` (
  `record_id` char(36) NOT NULL default '' COMMENT '记录标识',
  `person_id` char(36) default NULL COMMENT '用户ID',
  `web_id` int(11) default NULL COMMENT '推送网站ID',
  `web_user_code` varchar(100) default NULL COMMENT '推送网站的 默认用户名',
  `web_user_password` varchar(100) default NULL COMMENT '推送网站默认密码',
  `display_name` varchar(100) default NULL COMMENT '推送时显示的姓名',
  `display_depart` varchar(100) default NULL COMMENT '推送时显示的部门',
  `display_company` varchar(100) default NULL COMMENT '推送时显示的公司',
  `display_mobile` varchar(100) default NULL COMMENT '推送时显示的电话',
  PRIMARY KEY  (`record_id`),
  KEY `ix_person_id` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户推送配置信息表';

-- ----------------------------
-- Records of base_personal_push_config
-- ----------------------------

-- ----------------------------
-- Table structure for `base_webpush_iteminfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_webpush_iteminfo`;
CREATE TABLE `base_webpush_iteminfo` (
  `record_id` char(36) default NULL,
  `city_id` char(36) default NULL COMMENT '城市ID',
  `city_name` varchar(50) default NULL COMMENT '城市名称',
  `web_port_code` varchar(100) default NULL COMMENT '推送目标编码',
  `web_port_name` varchar(200) default NULL COMMENT '推送目标名称'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='推送网站信息表';

-- ----------------------------
-- Records of base_webpush_iteminfo
-- ----------------------------

-- ----------------------------
-- Table structure for `customer_baseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `customer_baseinfo`;
CREATE TABLE `customer_baseinfo` (
  `customer_id` char(36) NOT NULL COMMENT '客户ID',
  `customer_name` varchar(255) default NULL COMMENT '客户姓名',
  `customer_sex` varchar(255) default NULL COMMENT '性别',
  `mobile` varchar(20) default NULL COMMENT '手机',
  `phone` varchar(100) default NULL COMMENT '电话',
  `address` varchar(100) default NULL COMMENT '地址',
  `status` int(11) default NULL COMMENT '状态(1：有效；-1无效)',
  `customer_type` varchar(255) default NULL COMMENT '客户类型(数据字典项目)',
  `last_trace_date` date default NULL COMMENT '最后跟单日期',
  `add_person_id` char(36) default NULL COMMENT '添加人ID',
  `add_time` datetime default NULL COMMENT '登记时间',
  `update_time` datetime default NULL COMMENT '更新时间',
  PRIMARY KEY  (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='客户基本信息表';

-- ----------------------------
-- Records of customer_baseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `customer_demandinfo`
-- ----------------------------
DROP TABLE IF EXISTS `customer_demandinfo`;
CREATE TABLE `customer_demandinfo` (
  `record_id` char(36) NOT NULL default '',
  `customer_id` char(36) default NULL COMMENT '客户ID',
  `demand_kind` int(11) default NULL COMMENT '需求类型：10：求租：20求购',
  `demand_type` int(11) default NULL COMMENT '需求目标：10=住宅；20=商铺；30=办公；40=厂房；50=其他',
  `demand_zone` varchar(500) default NULL COMMENT '需求区域',
  `demand_block` varchar(500) default NULL COMMENT '需求板块',
  `demand_center` varchar(500) default NULL COMMENT '商圈需求',
  `demand_price` varchar(500) default NULL COMMENT '需求总价',
  `demand_use` varchar(500) default NULL COMMENT '购房用途(投资，自用等，读数据字典)',
  `demand_building` varchar(500) default NULL COMMENT '建筑类型需求（高层小高层别墅等)',
  `demand_consider` varchar(500) default NULL COMMENT '考虑因素',
  `demand_area` varchar(500) default NULL COMMENT '面积需求',
  `demand_service` varchar(500) default NULL COMMENT '服务需求',
  `demand_age` varchar(500) default NULL COMMENT '房龄需求(住宅需求)',
  `demand_special` varchar(500) default NULL COMMENT '特殊需求',
  `demand_room` varchar(50) default NULL COMMENT '房型需求-室(住宅）',
  `demand_hall` varchar(50) default NULL COMMENT '房型需求-厅(住宅）',
  `demand_toilet` varchar(50) default NULL COMMENT '房型需求-卫(住宅）',
  `demand_fitment` varchar(500) default NULL COMMENT '装修需求',
  `demand_catalog` varchar(100) default NULL COMMENT '需求自定义类别',
  `demand_return_rate` varchar(500) default NULL COMMENT '投资回报率(商业办公需求)',
  `status` int(11) default NULL COMMENT '需求状态(1=有效；-1=无效)',
  `add_person_id` char(36) default NULL COMMENT '需求添加人',
  `add_time` datetime default NULL COMMENT '需求添加时间',
  `last_trace_time` datetime default NULL COMMENT '需求最后跟单时间',
  `update_time` datetime default NULL COMMENT '最后更新时间',
  `shop_type` varchar(500) default NULL COMMENT '商铺类型(沿街等,读数据字典）',
  `business_scope` varchar(500) default NULL COMMENT '经营范围(餐饮，服饰等，读数据字典)',
  `fav_community_id` char(36) default NULL COMMENT '第一选择的小区',
  PRIMARY KEY  (`record_id`),
  KEY `ix_customer_id` (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='客户需求信息表';

-- ----------------------------
-- Records of customer_demandinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `customer_traceinfo`
-- ----------------------------
DROP TABLE IF EXISTS `customer_traceinfo`;
CREATE TABLE `customer_traceinfo` (
  `record_id` char(36) NOT NULL,
  `customer_id` char(36) default NULL,
  `trace_type` int(11) default NULL,
  `trace_context` varchar(500) default NULL,
  `trace_time` datetime default NULL,
  `trace_person_id` char(255) default NULL,
  `trace_person_name` varchar(50) default NULL,
  PRIMARY KEY  (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='客户跟单信息表';

-- ----------------------------
-- Records of customer_traceinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `house_baseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `house_baseinfo`;
CREATE TABLE `house_baseinfo` (
  `house_id` char(36) NOT NULL default '' COMMENT '房源ID',
  `house_code` char(12) default NULL COMMENT '房源编号',
  `community_id` char(36) default NULL COMMENT '小区ID',
  `buidling_id` char(36) default NULL COMMENT '楼栋ID',
  `room` varchar(120) default NULL COMMENT '房间号',
  `house_address` varchar(500) default NULL COMMENT '房屋地址',
  `region` varchar(50) default NULL COMMENT '房源区域',
  `block` varchar(50) default NULL COMMENT '房源板块',
  `complete_year` int(11) default NULL COMMENT '房源竣工时间',
  `customer_id` char(36) default NULL COMMENT '客户ID',
  `customer_name` varchar(100) default NULL COMMENT '客户姓名',
  `customer_mobile` varchar(50) default NULL COMMENT '客户手机',
  `customer_phone` varchar(250) default NULL COMMENT '客户电话',
  `building_area` decimal(10,2) default NULL COMMENT '建筑面积',
  `building_type` varchar(50) default NULL COMMENT '建筑类型',
  `house_use` varchar(50) default NULL COMMENT '房屋用途',
  `model_room` int(11) default NULL COMMENT '房型-室',
  `model_hall` int(11) default NULL COMMENT '房型-厅',
  `model_toilet` int(11) default NULL COMMENT '房型-卫',
  `total_floor` int(11) default NULL COMMENT '总楼层',
  `cur_floor` int(11) default NULL COMMENT '当前楼层',
  `direction` varchar(255) default NULL COMMENT '房屋朝向',
  `fitment` varchar(500) default NULL COMMENT '装修',
  `sale_totalprice` decimal(10,0) default NULL COMMENT '出售总价',
  `sale_unitprice` decimal(10,0) default NULL COMMENT '出售单价',
  `sale_realprice` decimal(10,0) default NULL COMMENT '出售底价',
  `rent_price` decimal(10,0) default NULL COMMENT '租价',
  `rent_unit` varchar(50) default NULL COMMENT '租金单位(元/月，元/季,元/平方米等)',
  `pay_mode` varchar(20) default NULL COMMENT '租赁-付款方式(付三压一，年付，半年付等)',
  `is_rented` bit(1) default NULL COMMENT '是否出租中',
  `rent_overtime` date default NULL COMMENT '租期到期时间',
  `equipment` varchar(300) default NULL COMMENT '内部设施',
  `house_actuality` varchar(30) default NULL COMMENT '房屋现状(空置,业主住,租客住等)',
  `business_kind` int(11) default NULL COMMENT '业务类型(出租，出售，租售）',
  `house_status` int(11) default NULL COMMENT '房屋状态(有效，无效，暂缓)',
  `is_havekey` bit(1) default NULL COMMENT '是否有钥匙',
  `is_marked` bit(1) default NULL COMMENT '是否有备案',
  `mark_code` varchar(255) default NULL COMMENT '备案号码',
  `is_entrust` bit(1) default NULL COMMENT '是否签订委托',
  `add_peron_id` char(36) default NULL COMMENT '房源添加人',
  `opr_person_id` char(36) default NULL COMMENT '操作人ID',
  `add_time` datetime default NULL COMMENT '添加时间',
  `update_time` datetime default NULL COMMENT '更新时间',
  `web_send_status` int(11) default NULL COMMENT '房源推送状态(用位标示推送到了那些网站)',
  `last_refrash_time` datetime default NULL COMMENT '最后刷新时间',
  `house_remark` varchar(500) default NULL COMMENT '房源备注',
  `push_remark` varchar(2000) default NULL COMMENT '推送时的房源描述',
  `shop_type` varchar(500) default NULL COMMENT '商铺类型(沿街等,读数据字典）',
  `business_scope` varchar(500) default NULL COMMENT '经营范围(餐饮，服饰等，读数据字典)',
  PRIMARY KEY  (`house_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房源基本信息表';

-- ----------------------------
-- Records of house_baseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `house_intrustinfo`
-- ----------------------------
DROP TABLE IF EXISTS `house_intrustinfo`;
CREATE TABLE `house_intrustinfo` (
  `record_id` char(36) NOT NULL default '',
  `house_id` char(36) default NULL COMMENT '房源ID',
  `house_code` varchar(50) default NULL COMMENT '房源编号',
  `house_address` varchar(200) default NULL COMMENT '房源地址',
  `community_id` char(36) default NULL COMMENT '小区ID',
  `region` varchar(50) default NULL COMMENT '房源区域',
  `block` varchar(50) default NULL COMMENT '房源板块',
  `property_code` varchar(100) default NULL COMMENT '产证编号',
  `date_start` date default NULL COMMENT '委托开始日期',
  `date_end` date default NULL COMMENT '委托结束日期',
  `house_area` decimal(10,0) default NULL COMMENT '房屋面积',
  `total_price` decimal(10,0) default NULL COMMENT '委托总价',
  `unit_price` decimal(10,0) default NULL COMMENT '委托单价',
  `customer_name` varchar(100) default NULL COMMENT '客户姓名',
  `customer_phone` varchar(100) default NULL COMMENT '客户电话',
  `customer_mobile` varchar(50) default NULL COMMENT '客户手机',
  `customer_address` varchar(200) default NULL COMMENT '客户联系地址',
  `business_type` int(11) default NULL COMMENT '交易类型（10=出售；20=出租；30=租售',
  `entrust_type` int(11) default NULL COMMENT '委托类型（10=一般委托；20=独家委托)',
  `status` int(11) default NULL COMMENT '委托状态（1=有效；-1=无效）',
  `intrust_person_id` char(36) default NULL COMMENT '委托业务人员id',
  `add_person_id` char(36) default NULL COMMENT '记录添加人员id',
  `add_time` datetime default NULL COMMENT '记录添加时间',
  `update_time` datetime default NULL COMMENT '记录更新时间',
  PRIMARY KEY  (`record_id`),
  KEY `ix_house_id` (`house_id`),
  KEY `ix_house_code` (`house_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房源委托信息表';

-- ----------------------------
-- Records of house_intrustinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `house_key_receiptioninfo`
-- ----------------------------
DROP TABLE IF EXISTS `house_key_receiptioninfo`;
CREATE TABLE `house_key_receiptioninfo` (
  `record_id` char(36) NOT NULL COMMENT '记录标识',
  `house_id` char(36) default NULL COMMENT '房源ID',
  `house_code` varchar(50) default NULL COMMENT '房源编号',
  `house_address` varchar(200) default NULL COMMENT '房源地址',
  `receiption_code` varchar(50) default NULL COMMENT '钥匙收据编号',
  `key_count` int(11) default NULL COMMENT '收取钥匙数量',
  `get_date` date default NULL COMMENT '收取钥匙时间',
  `customer_name` varchar(50) default NULL COMMENT '客户姓名',
  `get_person_id` char(36) default NULL COMMENT '钥匙收取人ID',
  `add_person_id` char(50) default NULL COMMENT '记录添加人ID',
  `add_time` datetime default NULL COMMENT '记录添加时间',
  `update_time` datetime default NULL COMMENT '记录更新时间',
  `status` int(11) default NULL COMMENT '钥匙状态(-1=已被业主收回；1=在店中)',
  PRIMARY KEY  (`record_id`),
  KEY `ix_house_id` (`house_id`),
  KEY `ix_house_code` (`house_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房源钥匙收据信息表';

-- ----------------------------
-- Records of house_key_receiptioninfo
-- ----------------------------

-- ----------------------------
-- Table structure for `house_markedinfo`
-- ----------------------------
DROP TABLE IF EXISTS `house_markedinfo`;
CREATE TABLE `house_markedinfo` (
  `record_id` char(36) NOT NULL COMMENT '记录标识',
  `house_id` char(36) default NULL COMMENT '房源ID',
  `house_code` varchar(50) default NULL COMMENT '房源编号',
  `house_address` varchar(200) default NULL COMMENT '房源地址',
  `mark_code` varchar(50) default NULL COMMENT '备案编号',
  `mark_day` date default NULL COMMENT '备案日期',
  `mark_start_day` date default NULL COMMENT '备案开始时间',
  `mark_end_day` date default NULL COMMENT '备案结束时间',
  `status` int(11) default NULL COMMENT '备案状态(1=有效；-1=无效)',
  `mark_person_id` char(36) default NULL COMMENT '备案人',
  `add_person_id` char(36) default NULL COMMENT '备案添加人ID',
  `add_time` datetime default NULL COMMENT '记录添加时间',
  `update_time` datetime default NULL COMMENT '记录更新时间',
  PRIMARY KEY  (`record_id`),
  KEY `ix_house_id` (`house_id`),
  KEY `ix_house_code` (`house_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房源备案信息表';

-- ----------------------------
-- Records of house_markedinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `house_picinfo`
-- ----------------------------
DROP TABLE IF EXISTS `house_picinfo`;
CREATE TABLE `house_picinfo` (
  `record_id` char(36) NOT NULL default '',
  `house_id` char(255) NOT NULL default '' COMMENT '房源ID',
  `pic_type` int(11) default NULL COMMENT '图片类型10：房型图；20：室内图；30：外景图',
  `pic_enum` int(11) default NULL COMMENT '图片大小分类10：缩略图；20：原图；30水印图',
  `pic_url` varchar(200) default NULL COMMENT '图片地址',
  PRIMARY KEY  (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房源图片信息';

-- ----------------------------
-- Records of house_picinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `house_push_logs`
-- ----------------------------
DROP TABLE IF EXISTS `house_push_logs`;
CREATE TABLE `house_push_logs` (
  `record_id` char(36) NOT NULL default '',
  `house_id` char(36) default NULL,
  `house_code` varchar(50) default NULL,
  `house_address` varchar(200) default NULL,
  `push_to` int(11) default NULL,
  `push_time` datetime default NULL,
  `push_person_id` char(36) default NULL,
  `push_status` datetime default NULL,
  PRIMARY KEY  (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of house_push_logs
-- ----------------------------

-- ----------------------------
-- Table structure for `house_traceinfo`
-- ----------------------------
DROP TABLE IF EXISTS `house_traceinfo`;
CREATE TABLE `house_traceinfo` (
  `record_id` char(36) NOT NULL,
  `house_id` char(36) default NULL,
  `trace_type` int(11) default NULL,
  `trace_context` varchar(500) default NULL,
  `trace_time` datetime default NULL,
  `trace_person_id` char(255) default NULL,
  `trace_person_name` varchar(50) default NULL,
  PRIMARY KEY  (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房源跟单信息表';

-- ----------------------------
-- Records of house_traceinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `house_viewhouse_baseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `house_viewhouse_baseinfo`;
CREATE TABLE `house_viewhouse_baseinfo` (
  `record_id` char(36) NOT NULL default '' COMMENT '记录标识',
  `customer_id` char(36) default NULL COMMENT '客户ID',
  `customer_name` varchar(50) default NULL COMMENT '客户姓名',
  `description` varchar(500) default NULL COMMENT '看房结果描述',
  `view_time` datetime default NULL COMMENT '看房时间',
  `status` int(11) default NULL COMMENT '状态（-1=无效；1=有效)',
  `view_person_id` char(255) default NULL COMMENT '带看人员ID',
  `add_person_id` char(36) default NULL COMMENT '记录添加人员ID',
  `add_time` datetime default NULL COMMENT '记录添加时间',
  PRIMARY KEY  (`record_id`),
  KEY `ix_customer_id` (`customer_id`),
  KEY `ix_view_date` (`view_time`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='客户带看记录基本信息';

-- ----------------------------
-- Records of house_viewhouse_baseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `house_viewhouse_subinfo`
-- ----------------------------
DROP TABLE IF EXISTS `house_viewhouse_subinfo`;
CREATE TABLE `house_viewhouse_subinfo` (
  `record_id` char(36) NOT NULL default '' COMMENT '记录标识',
  `main_id` char(36) default NULL COMMENT '带看记录基本信息表主键ID',
  `house_id` char(36) default NULL COMMENT '房源ID',
  `house_code` varchar(50) default NULL COMMENT '房源编号',
  `house_address` varchar(200) default NULL COMMENT '房源地址',
  PRIMARY KEY  (`record_id`),
  KEY `ix_main_id` (`main_id`),
  KEY `ix_house_id` (`house_id`),
  KEY `ix_house_code` (`house_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='客户带看带看房源信息表';

-- ----------------------------
-- Records of house_viewhouse_subinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_user_business_config`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_business_config`;
CREATE TABLE `sys_user_business_config` (
  `user_id` char(36) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user_business_config
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_user_community_config`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_community_config`;
CREATE TABLE `sys_user_community_config` (
  `record_id` char(36) NOT NULL default '' COMMENT '记录标识',
  `user_id` char(36) default NULL COMMENT '用户ID',
  `community_id` char(36) default NULL COMMENT '小区ID',
  PRIMARY KEY  (`record_id`),
  KEY `ix_user_id` (`user_id`),
  KEY `ix_community_id` (`community_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户主营小区配置';

-- ----------------------------
-- Records of sys_user_community_config
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_user_region_config`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_region_config`;
CREATE TABLE `sys_user_region_config` (
  `record_id` char(36) NOT NULL default '' COMMENT '记录标识',
  `user_id` char(36) NOT NULL default '' COMMENT '用户ID',
  `regin` varchar(300) default NULL COMMENT '主营的区域',
  `block` varchar(300) default NULL COMMENT '主营的板块',
  PRIMARY KEY  (`record_id`),
  KEY `ix_user_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户主营的区域板块设置';

-- ----------------------------
-- Records of sys_user_region_config
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_user_relationinfo`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_relationinfo`;
CREATE TABLE `sys_user_relationinfo` (
  `record_id` char(36) NOT NULL default '' COMMENT '记录标识',
  `parent_id` char(36) default NULL COMMENT '父账号ID',
  `child_id` char(36) default NULL COMMENT '子账号id',
  PRIMARY KEY  (`record_id`),
  KEY `ix_parent_id` (`parent_id`),
  KEY `ix_child_id` (`child_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户子账户关系表';

-- ----------------------------
-- Records of sys_user_relationinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `usys_community_baseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `usys_community_baseinfo`;
CREATE TABLE `usys_community_baseinfo` (
  `community_id` char(36) NOT NULL COMMENT '小区\\楼盘ID',
  `community_name` varchar(200) default NULL COMMENT '小区\\楼盘名称',
  `city_id` int(11) default NULL COMMENT '所属城市ID',
  `city_name` varchar(50) default NULL COMMENT '所属城市',
  `region` varchar(50) default NULL COMMENT '所属区域',
  `block` varchar(50) default NULL COMMENT '所属板块',
  `address` varchar(200) default NULL COMMENT '小区地址',
  `community_use` varchar(50) default NULL COMMENT '小区用途：如办公，住宅，商铺等',
  `building_type` varchar(50) default NULL COMMENT '建筑类型：如高层，小高层，别墅，混合等',
  `complete_year` int(11) default NULL COMMENT '竣工年份',
  `remark` varchar(500) default NULL COMMENT '小区描述',
  `pinyin` varchar(200) default NULL COMMENT '小区名拼音首字符',
  `add_person_id` char(36) default NULL COMMENT '小区添加人',
  `status` int(11) default NULL COMMENT '状态：1正常；-1作废',
  PRIMARY KEY  (`community_id`),
  KEY `ix_add_person_id` (`add_person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='预设小区基本信息表';

-- ----------------------------
-- Records of usys_community_baseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `usys_community_buildinginfo`
-- ----------------------------
DROP TABLE IF EXISTS `usys_community_buildinginfo`;
CREATE TABLE `usys_community_buildinginfo` (
  `building_id` char(36) NOT NULL default '' COMMENT '楼栋ID',
  `community_id` char(36) default NULL COMMENT '小区ID',
  `building_name` varchar(50) default NULL COMMENT '楼栋名称',
  `building_use` varchar(50) default NULL COMMENT '楼栋用途（参见楼盘）',
  `building_type` varchar(50) default NULL COMMENT '楼栋建筑类型（参见楼盘）',
  `building_floor` int(11) default NULL COMMENT '楼栋楼层数',
  `unit_num` int(11) default NULL COMMENT '楼栋单元数',
  `unit_type` varchar(50) default NULL COMMENT '楼栋单元类型',
  `room_rule` varchar(500) default NULL COMMENT '楼栋房间号输入规则(正则表达式)',
  `room_rule_remark` varchar(500) default NULL COMMENT '房间号输入规则描述',
  `status` int(11) default NULL COMMENT '状态：1正常；-1作废',
  PRIMARY KEY  (`building_id`),
  KEY `ix_community_id` USING BTREE (`community_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='预设楼栋信息表';

-- ----------------------------
-- Records of usys_community_buildinginfo
-- ----------------------------
