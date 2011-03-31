/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50153
Source Host           : localhost:3306
Source Database       : cboo

Target Server Type    : MYSQL
Target Server Version : 50153
File Encoding         : 65001

Date: 2011-03-31 09:54:02
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `base_datadic_tree`
-- ----------------------------
DROP TABLE IF EXISTS `base_datadic_tree`;
CREATE TABLE `base_datadic_tree` (
  `item_id` char(36) NOT NULL DEFAULT '',
  `item_key` varchar(50) DEFAULT NULL,
  `item_name` varchar(50) DEFAULT NULL,
  `parent_id` char(36) DEFAULT NULL,
  `leaf` bit(1) DEFAULT NULL,
  `deep` smallint(11) DEFAULT NULL,
  `memo` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='数据字典树型';

-- ----------------------------
-- Records of base_datadic_tree
-- ----------------------------
