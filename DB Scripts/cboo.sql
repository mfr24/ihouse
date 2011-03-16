/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50153
Source Host           : localhost:3306
Source Database       : cboo_main

Target Server Type    : MYSQL
Target Server Version : 50153
File Encoding         : 65001

Date: 2011-03-16 16:33:33
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `sys_user_baseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_baseinfo`;
CREATE TABLE `sys_user_baseinfo` (
  `user_id` char(36) NOT NULL,
  `user_code` varchar(50) DEFAULT NULL,
  `user_name` varchar(150) DEFAULT NULL,
  `department` varchar(150) DEFAULT NULL,
  `company_name` varchar(150) DEFAULT NULL,
  `password` varchar(200) DEFAULT NULL,
  `city_code` varchar(20) DEFAULT NULL,
  `city_name` varchar(50) DEFAULT NULL,
  `validate` bit(1) DEFAULT NULL,
  `user_type` int(11) DEFAULT NULL,
  `id_type` varchar(50) DEFAULT NULL,
  `it_num` varchar(150) DEFAULT NULL,
  `mobile` varchar(50) DEFAULT NULL,
  `office_tel` varchar(50) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  `remark` longtext,
  `reg_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `update_time` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `last_login_time` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user_baseinfo
-- ----------------------------
INSERT INTO sys_user_baseinfo VALUES ('724726ae-629e-4c64-a763-f366b0598eae', null, null, null, null, null, null, '北京', null, null, null, null, null, null, null, null, '0000-00-00 00:00:00', '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- ----------------------------
-- Table structure for `base_roleuserrelationinfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_roleuserrelationinfo`;
CREATE TABLE `base_roleuserrelationinfo` (
  `record_id` char(36) NOT NULL,
  `role_id` char(36) DEFAULT NULL,
  `user_id` char(36) DEFAULT NULL,
  PRIMARY KEY (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_roleuserrelationinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_rolepermitionrelationinfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_rolepermitionrelationinfo`;
CREATE TABLE `base_rolepermitionrelationinfo` (
  `record_id` char(36) NOT NULL,
  `role_id` char(36) DEFAULT NULL,
  `permit_id` char(36) DEFAULT NULL,
  PRIMARY KEY (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_rolepermitionrelationinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_permit_roledefine`
-- ----------------------------
DROP TABLE IF EXISTS `base_permit_roledefine`;
CREATE TABLE `base_permit_roledefine` (
  `role_id` char(36) NOT NULL,
  `role_name` varchar(50) DEFAULT NULL,
  `city_code` varchar(20) DEFAULT NULL,
  `city_name` varchar(50) DEFAULT NULL,
  `company_id` char(36) DEFAULT NULL,
  `company_name` varchar(50) DEFAULT NULL,
  `is_show` bit(1) DEFAULT NULL,
  `def_role` bit(1) DEFAULT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_permit_roledefine
-- ----------------------------

-- ----------------------------
-- Table structure for `base_permit_define`
-- ----------------------------
DROP TABLE IF EXISTS `base_permit_define`;
CREATE TABLE `base_permit_define` (
  `permit_id` char(36) NOT NULL,
  `permit_code` varchar(200) DEFAULT NULL,
  `permit_name` varchar(200) DEFAULT NULL,
  `permit_roup` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`permit_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_permit_define
-- ----------------------------

-- ----------------------------
-- Table structure for `base_datadic_iteminfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_datadic_iteminfo`;
CREATE TABLE `base_datadic_iteminfo` (
  `item_id` char(36) NOT NULL DEFAULT '' COMMENT '字典项目ID',
  `item_key` varchar(50) DEFAULT NULL COMMENT '字典项目Key',
  `item_name` varchar(100) DEFAULT NULL COMMENT '字典项名称',
  PRIMARY KEY (`item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_datadic_iteminfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_datadic_detailinfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_datadic_detailinfo`;
CREATE TABLE `base_datadic_detailinfo` (
  `record_id` char(36) NOT NULL DEFAULT '',
  `item_key` varchar(50) DEFAULT NULL COMMENT '字典项目',
  `item_value` varchar(255) DEFAULT NULL COMMENT '字典项目值',
  `item_index` int(11) DEFAULT NULL COMMENT '排序顺序',
  PRIMARY KEY (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_datadic_detailinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_community_buildinginfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_community_buildinginfo`;
CREATE TABLE `base_community_buildinginfo` (
  `building_id` char(36) NOT NULL DEFAULT '' COMMENT '楼栋ID',
  `community_id` char(36) DEFAULT NULL COMMENT '小区ID',
  `building_name` varchar(50) DEFAULT NULL COMMENT '楼栋名称',
  `building_use` varchar(50) DEFAULT NULL COMMENT '楼栋用途（参见楼盘）',
  `building_type` varchar(50) DEFAULT NULL COMMENT '楼栋建筑类型（参见楼盘）',
  `building_floor` int(11) DEFAULT NULL COMMENT '楼栋楼层数',
  `unit_num` int(11) DEFAULT NULL COMMENT '楼栋单元数',
  `unit_type` varchar(50) DEFAULT NULL COMMENT '楼栋单元类型',
  `room_rule` varchar(500) DEFAULT NULL COMMENT '楼栋房间号输入规则(正则表达式)',
  `room_rule_remark` varchar(500) DEFAULT NULL COMMENT '房间号输入规则描述',
  `status` int(11) DEFAULT NULL COMMENT '状态：1正常；-1作废',
  PRIMARY KEY (`building_id`),
  KEY `ix_community_id` (`community_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_community_buildinginfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_community_baseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_community_baseinfo`;
CREATE TABLE `base_community_baseinfo` (
  `community_id` char(36) NOT NULL COMMENT '小区\\楼盘ID',
  `community_name` varchar(200) DEFAULT NULL COMMENT '小区\\楼盘名称',
  `city_code` varchar(20) DEFAULT NULL COMMENT '所属城市ID',
  `city_name` varchar(50) DEFAULT NULL COMMENT '所属城市',
  `region` varchar(50) DEFAULT NULL COMMENT '所属区域',
  `block` varchar(50) DEFAULT NULL COMMENT '所属板块',
  `address` varchar(200) DEFAULT NULL COMMENT '小区地址',
  `community_use` varchar(50) DEFAULT NULL COMMENT '小区用途：如办公，住宅，商铺等',
  `building_type` varchar(50) DEFAULT NULL COMMENT '建筑类型：如高层，小高层，别墅，混合等',
  `complete_year` int(11) DEFAULT NULL COMMENT '竣工年份',
  `remark` varchar(500) DEFAULT NULL COMMENT '小区描述',
  `pinyin` varchar(200) DEFAULT NULL COMMENT '小区名拼音首字符',
  `add_person_id` char(36) DEFAULT NULL COMMENT '小区添加人',
  `status` int(11) DEFAULT NULL COMMENT '状态：1正常；-1作废',
  PRIMARY KEY (`community_id`),
  KEY `ix_add_person_id` (`add_person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_community_baseinfo
-- ----------------------------
