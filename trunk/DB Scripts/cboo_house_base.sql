/*
Navicat MySQL Data Transfer

Source Server         : KIMI
Source Server Version : 50022
Source Host           : localhost:3306
Source Database       : cboo_house

Target Server Type    : MYSQL
Target Server Version : 50022
File Encoding         : 65001

Date: 2011-03-16 13:20:06
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `base_community_baseinfo`
-- 楼盘字典-小区基本信息表
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_community_baseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_community_buildinginfo`
-- 楼盘字典-小区楼栋信息表
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_community_buildinginfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_datadic_detailinfo`
-- 数据字典-数据字典详细表
-- ----------------------------
DROP TABLE IF EXISTS `base_datadic_detailinfo`;
CREATE TABLE `base_datadic_detailinfo` (
  `record_id` char(36) NOT NULL default '',
  `item_key` varchar(50) default NULL COMMENT '字典项目',
  `item_value` varchar(255) default NULL COMMENT '字典项目值',
  `item_index` int(11) default NULL COMMENT '排序顺序',
  PRIMARY KEY  (`record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_datadic_detailinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_datadic_iteminfo`
-- 数据字典-数据字典项信息表
-- ----------------------------
DROP TABLE IF EXISTS `base_datadic_iteminfo`;
CREATE TABLE `base_datadic_iteminfo` (
  `item_id` char(36) NOT NULL default '' COMMENT '字典项目ID',
  `item_key` varchar(50) default NULL COMMENT '字典项目Key',
  `item_name` varchar(100) default NULL COMMENT '字典项名称',
  PRIMARY KEY  (`item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_datadic_iteminfo
-- ----------------------------
