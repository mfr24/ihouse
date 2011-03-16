/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50153
Source Host           : localhost:3306
Source Database       : cboo_main

Target Server Type    : MYSQL
Target Server Version : 50153
File Encoding         : 65001

Date: 2011-03-16 11:06:27
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `sys_user_baseinfo`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_baseinfo`;
CREATE TABLE `sys_user_baseinfo` (
  `user_id` char(38) NOT NULL,
  `user_code` varchar(50) DEFAULT NULL,
  `user_name` varchar(150) DEFAULT NULL,
  `department` varchar(150) DEFAULT NULL,
  `company_name` varchar(150) DEFAULT NULL,
  `password` varchar(200) DEFAULT NULL,
  `city_id` longtext,
  `CityName` varchar(50) DEFAULT NULL,
  `Validate` tinyint(4) DEFAULT NULL,
  `UserType` int(11) DEFAULT NULL,
  `IDType` varchar(50) DEFAULT NULL,
  `IDNum` varchar(150) DEFAULT NULL,
  `Mobile` varchar(50) DEFAULT NULL,
  `OfficeTel` varchar(50) DEFAULT NULL,
  `Email` varchar(250) DEFAULT NULL,
  `Remark` longtext,
  `Regtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Updatetime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastLoginTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user_baseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for `base_roleuserrelationinfo`
-- ----------------------------
DROP TABLE IF EXISTS `base_roleuserrelationinfo`;
CREATE TABLE `base_roleuserrelationinfo` (
  `record_id` char(38) NOT NULL,
  `role_id` longtext,
  `user_id` longtext,
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
  `record_id` char(38) NOT NULL,
  `role_id` longtext,
  `permit_id` longtext,
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
  `role_id` char(20) NOT NULL,
  `role_name` varchar(50) DEFAULT NULL,
  `city_id` longtext,
  `city_name` varchar(50) DEFAULT NULL,
  `company_id` longtext,
  `company_name` varchar(50) DEFAULT NULL,
  `is_show` tinyint(4) DEFAULT NULL,
  `DefRole` tinyint(4) DEFAULT NULL,
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
  `permit_id` char(38) NOT NULL,
  `permit_code` varchar(200) DEFAULT NULL,
  `permit_name` varchar(200) DEFAULT NULL,
  `permit_roup` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`permit_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of base_permit_define
-- ----------------------------
