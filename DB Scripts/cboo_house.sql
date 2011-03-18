/*
Navicat MySQL Data Transfer

Source Server         : KIMI
Source Server Version : 50022
Source Host           : localhost:3306
Source Database       : cboo_house

Target Server Type    : MYSQL
Target Server Version : 50022
File Encoding         : 65001

Date: 2011-03-18 18:02:15
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
  `demand_price` varchar(500) default NULL COMMENT '需求总价',
  `demand_use` varchar(500) default NULL COMMENT '购房用途',
  `demand_building` varchar(500) default NULL COMMENT '建筑类型需求（高层小高层别墅等)',
  `demand_consider` varchar(500) default NULL COMMENT '考虑因素',
  `demand_area` varchar(500) default NULL COMMENT '面积需求',
  `demand_service` varchar(500) default NULL,
  `demand_age` varchar(500) default NULL,
  `demand_special` varchar(500) default NULL,
  `demand_room` varchar(50) default NULL,
  `demand_hall` varchar(50) default NULL,
  `demand_toilet` varchar(50) default NULL,
  `demand_fitment` varchar(500) default NULL,
  `demand_catalog` varchar(100) default NULL,
  `demand_return_rate` varchar(500) default NULL,
  `status` int(11) default NULL,
  `add_person_id` char(36) default NULL,
  `add_time` datetime default NULL,
  `last_trace_time` datetime default NULL,
  `update_time` datetime default NULL,
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
  `add_time` datetime default NULL COMMENT '添加时间',
  `update_time` datetime default NULL COMMENT '更新时间',
  `web_send_status` int(11) default NULL COMMENT '房源推送状态(用位标示推送到了那些网站)',
  `last_refrash_time` datetime default NULL COMMENT '最后刷新时间',
  `house_remark` varchar(500) default NULL COMMENT '房源备注',
  `push_remark` varchar(2000) default NULL COMMENT '推送时的房源描述',
  PRIMARY KEY  (`house_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='房源基本信息表';

-- ----------------------------
-- Records of house_baseinfo
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
