/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 80014
 Source Host           : localhost:3306
 Source Schema         : iotmanager

 Target Server Type    : MySQL
 Target Server Version : 80014
 File Encoding         : 65001

 Date: 26/04/2019 17:48:28
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for city
-- ----------------------------
DROP TABLE IF EXISTS `city`;
CREATE TABLE `city`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cityName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 10 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of city
-- ----------------------------
INSERT INTO `city` VALUES (1, '上海', '超大城市', '2019-04-18 21:26:46', '2019-04-18 21:26:46');
INSERT INTO `city` VALUES (2, '南京', '大城市', '2019-04-18 21:45:28', '2019-04-18 21:45:28');
INSERT INTO `city` VALUES (3, '杭州', '大城市', '2019-04-20 22:37:11', '2019-04-20 22:37:11');
INSERT INTO `city` VALUES (4, '北京', '超大城市', '2019-04-23 18:34:27', '2019-04-23 18:34:27');
INSERT INTO `city` VALUES (5, '广州', '大城市', '2019-04-20 22:37:34', '2019-04-20 22:37:34');
INSERT INTO `city` VALUES (6, '深圳', '超大城市', '2019-04-20 22:37:43', '2019-04-20 22:37:43');
INSERT INTO `city` VALUES (8, '喀什', '小城市', '2019-04-20 22:38:11', '2019-04-20 22:38:11');
INSERT INTO `city` VALUES (9, '重庆', '大城市', '2019-04-23 18:34:17', '2019-04-23 18:34:17');

-- ----------------------------
-- Table structure for company
-- ----------------------------
DROP TABLE IF EXISTS `company`;
CREATE TABLE `company`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `companyName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `phoneNumber` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `address` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of company
-- ----------------------------
INSERT INTO `company` VALUES (1, '南洋公司', '+86 13800000000', '漕河泾', '南洋公司', '2019-04-22 18:16:34', '2019-04-22 18:16:34');
INSERT INTO `company` VALUES (2, 'BiliBili', '+86 13800000000', '江湾体育场', 'BiliBili公司', '2019-04-26 17:26:20', '2019-04-26 17:26:20');

-- ----------------------------
-- Table structure for department
-- ----------------------------
DROP TABLE IF EXISTS `department`;
CREATE TABLE `department`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `path` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `departmentName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `phoneNumber` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of department
-- ----------------------------
INSERT INTO `department` VALUES (1, '/1', '部门1', '+86 13800000000', '这是个部门', '2019-04-18 22:28:07', '2019-04-18 22:28:07');
INSERT INTO `department` VALUES (2, '/1/2', '部门2', '+86 13800000000', '这也是个部门', '2019-04-20 22:39:37', '2019-04-20 22:39:37');
INSERT INTO `department` VALUES (3, '/1/2/3', '部门3', '+86 13800000000', '这还是个部门', '2019-04-20 22:40:01', '2019-04-20 22:40:01');

-- ----------------------------
-- Table structure for device
-- ----------------------------
DROP TABLE IF EXISTS `device`;
CREATE TABLE `device`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hardwareDeviceID` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `deviceName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `city` int(11) NULL DEFAULT NULL,
  `factory` int(11) NULL DEFAULT NULL,
  `workshop` int(11) NULL DEFAULT NULL,
  `deviceState` int(11) NULL DEFAULT NULL,
  `imageUrl` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `gatewayID` int(11) NULL DEFAULT NULL,
  `mac` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `deviceType` int(11) NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `department` int(11) NULL DEFAULT NULL,
  `LastConnectionTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `city`(`city`) USING BTREE,
  INDEX `factory`(`factory`) USING BTREE,
  INDEX `workshop`(`workshop`) USING BTREE,
  INDEX `deviceState`(`deviceState`) USING BTREE,
  INDEX `deviceType`(`deviceType`) USING BTREE,
  INDEX `department`(`department`) USING BTREE,
  CONSTRAINT `device_ibfk_1` FOREIGN KEY (`city`) REFERENCES `city` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `device_ibfk_2` FOREIGN KEY (`factory`) REFERENCES `factory` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `device_ibfk_3` FOREIGN KEY (`workshop`) REFERENCES `workshop` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `device_ibfk_4` FOREIGN KEY (`deviceState`) REFERENCES `devicestate` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `device_ibfk_5` FOREIGN KEY (`deviceType`) REFERENCES `devicetype` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `device_ibfk_6` FOREIGN KEY (`department`) REFERENCES `department` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 31 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of device
-- ----------------------------
INSERT INTO `device` VALUES (1, 'D0001', '设备 1', 2, 1, 1, 1, 'http://www.baidu.com', 3, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-16 20:45:53', '2019-04-16 20:45:53', '2019-04-26 16:57:34');
INSERT INTO `device` VALUES (2, 'D0002', '设备 2', 1, 1, 1, 1, 'http://www.baidu.com', 3, '00-23-5A-15-99-43', 1, '这是设备', 2, '2019-04-20 22:36:28', '2019-04-20 22:36:28', '2019-04-20 22:36:28');
INSERT INTO `device` VALUES (4, 'D0004', '设备 5', 8, 4, 3, 2, 'https://www.bilibili.com', 5, '00-23-5A-15-99-45', 1, '这是设备', 2, '2019-04-21 00:40:50', '2019-04-21 00:40:50', '2019-04-21 00:40:50');
INSERT INTO `device` VALUES (5, 'D0005', '设备 5', 8, 1, 1, 2, 'https://www.bilibili.com', 5, '00-23-5A-15-99-42', 1, '这是设备', 3, '2019-04-21 00:36:55', '2019-04-21 00:36:55', '2019-04-21 00:36:55');
INSERT INTO `device` VALUES (8, 'D0008', '设备 8', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 00:53:49', '2019-04-21 00:53:49', '2019-04-21 00:53:49');
INSERT INTO `device` VALUES (9, 'T0009', '设备 9', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:37:49', '2019-04-21 15:37:49', '2019-04-21 15:37:49');
INSERT INTO `device` VALUES (11, 'T0011', '设备 11', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:37:54', '2019-04-21 15:37:54', '2019-04-21 15:37:54');
INSERT INTO `device` VALUES (12, 'D0012', '设备 12', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:37:54', '2019-04-21 15:37:54', '2019-04-21 15:37:54');
INSERT INTO `device` VALUES (13, 'T0013', '设备 13', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:37:55', '2019-04-21 15:37:55', '2019-04-21 15:37:55');
INSERT INTO `device` VALUES (14, 'T0014', '设备 14', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:37:55', '2019-04-21 15:37:55', '2019-04-21 15:37:55');
INSERT INTO `device` VALUES (16, 'T0016', '设备 16', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:42:44', '2019-04-21 15:42:44', '2019-04-21 15:42:44');
INSERT INTO `device` VALUES (17, 'D0017', '设备 17', 6, 4, 1, 2, 'https://www.douyu.com', 17, '00-23-5A-15-99-42', 1, '这是设备', 2, '2019-04-21 15:42:46', '2019-04-21 15:42:46', '2019-04-21 16:00:44');
INSERT INTO `device` VALUES (19, 'D0019', '设备 19', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:42:48', '2019-04-21 15:42:48', '2019-04-21 15:42:48');
INSERT INTO `device` VALUES (20, 'D0020', '设备 20', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:42:49', '2019-04-21 15:42:49', '2019-04-21 15:42:49');
INSERT INTO `device` VALUES (21, 'T0021', '设备 21', 6, 4, 1, 2, 'https://www.douyu.com', 17, '00-23-5A-15-99-42', 1, '这是设备', 2, '2019-04-21 15:42:50', '2019-04-21 15:42:50', '2019-04-21 16:02:46');
INSERT INTO `device` VALUES (22, 'T0022', '设备 22', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:42:52', '2019-04-21 15:42:52', '2019-04-21 15:42:52');
INSERT INTO `device` VALUES (23, 'D0023', '设备 23', 4, 5, 3, 1, 'https://www.douyu.com', 107, '00-23-5A-15-99-42', 1, '这是设备', 1, '2019-04-21 15:42:53', '2019-04-21 15:42:53', '2019-04-21 15:42:53');
INSERT INTO `device` VALUES (24, 'T0024', '设备 24', 6, 4, 1, 2, 'https://www.douyu.com', 17, '00-23-5A-15-99-42', 1, '这是设备', 2, '2019-04-21 16:31:11', '2019-04-21 16:31:11', '2019-04-21 16:31:11');
INSERT INTO `device` VALUES (26, 'D0026', '设备 26', 1, 4, 1, 2, 'https://www.douyu.com', 17, '00-23-5A-15-99-42', 1, '这是设备', 2, '2019-04-21 16:31:13', '2019-04-21 16:31:13', '2019-04-21 16:31:30');
INSERT INTO `device` VALUES (27, 'T0027', '设备 27', 1, 4, 1, 2, 'https://www.douyu.com', 17, '00-23-5A-15-99-42', 1, '这是设备', 2, '2019-04-21 16:46:58', '2019-04-21 16:46:58', '2019-04-21 16:46:58');
INSERT INTO `device` VALUES (28, 'T0028', '设备 28', 1, 4, 1, 2, 'https://www.douyu.com', 17, '00-23-5A-15-99-42', 1, '这是设备', 2, '2019-04-21 16:47:03', '2019-04-21 16:47:03', '2019-04-21 16:47:03');
INSERT INTO `device` VALUES (30, 'D0030', '设备 30', 2, 2, 1, 2, 'https://www.douyu.com', 17, '00-23-5A-15-99-42', 1, '这是设备', 2, '2019-04-25 23:18:28', '2019-04-25 23:18:28', '2019-04-25 23:18:28');

-- ----------------------------
-- Table structure for devicestate
-- ----------------------------
DROP TABLE IF EXISTS `devicestate`;
CREATE TABLE `devicestate`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stateName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of devicestate
-- ----------------------------
INSERT INTO `devicestate` VALUES (1, '正常', '设备正常', '2019-04-18 22:18:14', '2019-04-18 22:18:14');
INSERT INTO `devicestate` VALUES (2, '异常', '设备异常', '2019-04-18 22:18:48', '2019-04-18 22:18:48');

-- ----------------------------
-- Table structure for devicetype
-- ----------------------------
DROP TABLE IF EXISTS `devicetype`;
CREATE TABLE `devicetype`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `deviceTypeName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of devicetype
-- ----------------------------
INSERT INTO `devicetype` VALUES (1, '普通', '正常设备', '2019-04-18 22:23:42', '2019-04-18 22:23:42');
INSERT INTO `devicetype` VALUES (2, '特殊', '特殊设备', '2019-04-26 17:30:23', '2019-04-26 17:30:23');

-- ----------------------------
-- Table structure for factory
-- ----------------------------
DROP TABLE IF EXISTS `factory`;
CREATE TABLE `factory`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `factoryName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `factoryPhoneNumber` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `factoryAddress` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `city` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `city`(`city`) USING BTREE,
  CONSTRAINT `factory_ibfk_1` FOREIGN KEY (`city`) REFERENCES `city` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of factory
-- ----------------------------
INSERT INTO `factory` VALUES (1, '工厂1', '+86 138000002363462000', 'Shangda Rd. No.3 99', 'A university named in the city Shanghai.', '2019-04-18 22:07:46', '2019-04-25 18:36:14', 3);
INSERT INTO `factory` VALUES (2, '工厂2', '+86 13800000000', 'Somewhere', 'A university named Tongji University', '2019-04-20 22:41:30', '2019-04-20 22:41:30', 1);
INSERT INTO `factory` VALUES (3, '工厂3', '+86 13800000000', 'Somewhere', 'A university named East China Normal University.', '2019-04-20 22:42:13', '2019-04-20 22:42:13', 1);
INSERT INTO `factory` VALUES (4, '工厂4', '+86 138000002363462000', 'Shangda Rd. No.3 99', 'A university named in the city Shanghai.', '2019-04-20 22:42:40', '2019-04-25 18:36:08', 3);
INSERT INTO `factory` VALUES (5, '工厂5', '+86 13800000000', 'Somewhere', 'A university named Shanghai Jiaotong University.', '2019-04-20 22:43:05', '2019-04-20 22:43:05', 1);
INSERT INTO `factory` VALUES (6, '工厂6', '+86 13800000000', 'Shangda Rd. No. 99', 'A university named in the city Shanghai.', '2019-04-25 18:24:42', '2019-04-25 18:24:42', 1);
INSERT INTO `factory` VALUES (9, '工厂7', '+86 138000002363462000', 'Shangda Rd. No.3 99', 'A university named in the city Shanghai.', '2019-04-25 18:40:15', '2019-04-25 18:40:15', 3);
INSERT INTO `factory` VALUES (10, '工厂8', '+86 138000002363462000', 'Shangda Rd. No.3 99', 'A university named in the city Shanghai.', '2019-04-25 18:40:16', '2019-04-25 18:40:16', 3);

-- ----------------------------
-- Table structure for gateway
-- ----------------------------
DROP TABLE IF EXISTS `gateway`;
CREATE TABLE `gateway`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hardwareGatewayID` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `gatewayName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `gatewayType` int(11) NULL DEFAULT NULL,
  `city` int(11) NULL DEFAULT NULL,
  `factory` int(11) NULL DEFAULT NULL,
  `workshop` int(11) NULL DEFAULT NULL,
  `gatewayState` int(11) NULL DEFAULT NULL,
  `imageUrl` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `department` int(11) NULL DEFAULT NULL,
  `lastConnectionTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `city`(`city`) USING BTREE,
  INDEX `factory`(`factory`) USING BTREE,
  INDEX `workshop`(`workshop`) USING BTREE,
  INDEX `gatewayState`(`gatewayState`) USING BTREE,
  INDEX `gatewayType`(`gatewayType`) USING BTREE,
  INDEX `department`(`department`) USING BTREE,
  CONSTRAINT `gateway_ibfk_1` FOREIGN KEY (`city`) REFERENCES `city` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `gateway_ibfk_2` FOREIGN KEY (`factory`) REFERENCES `factory` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `gateway_ibfk_3` FOREIGN KEY (`workshop`) REFERENCES `workshop` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `gateway_ibfk_4` FOREIGN KEY (`gatewayState`) REFERENCES `gatewaystate` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `gateway_ibfk_5` FOREIGN KEY (`gatewayType`) REFERENCES `gatewaytype` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `gateway_ibfk_6` FOREIGN KEY (`department`) REFERENCES `department` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of gateway
-- ----------------------------
INSERT INTO `gateway` VALUES (1, 'G001', '网关1', 3, 1, 1, 1, 1, 'http://www.baidu.com', '网关1', 1, '2019-04-18 10:19:59', '2019-04-18 10:19:59', '2019-04-18 10:19:59');
INSERT INTO `gateway` VALUES (2, 'G002', '网关2', 2, 4, 2, 1, 2, 'http://www.baidu.com', '网关2', 3, '2019-04-22 16:41:53', '2019-04-22 16:41:53', '2019-04-22 16:41:53');
INSERT INTO `gateway` VALUES (3, 'G003', '网关3', 3, 1, 1, 1, 1, 'http://www.baidu.com', '网关3', 1, '2019-04-22 17:14:44', '2019-04-22 17:14:44', '2019-04-22 17:14:44');
INSERT INTO `gateway` VALUES (5, 'G004', '网关4', 3, 1, 1, 1, 1, 'http://www.baidu.com', '网关4', 1, '2019-04-22 17:14:53', '2019-04-22 17:14:53', '2019-04-22 17:14:53');

-- ----------------------------
-- Table structure for gatewaystate
-- ----------------------------
DROP TABLE IF EXISTS `gatewaystate`;
CREATE TABLE `gatewaystate`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stateName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of gatewaystate
-- ----------------------------
INSERT INTO `gatewaystate` VALUES (1, '正常', '网关正常运行', '2019-04-22 16:37:50', '2019-04-22 16:37:50');
INSERT INTO `gatewaystate` VALUES (2, '异常', '网关运行异常', '2019-04-22 16:38:14', '2019-04-22 16:38:14');

-- ----------------------------
-- Table structure for gatewaytype
-- ----------------------------
DROP TABLE IF EXISTS `gatewaytype`;
CREATE TABLE `gatewaytype`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `gatewayTypeName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of gatewaytype
-- ----------------------------
INSERT INTO `gatewaytype` VALUES (1, '普通', '普通网关', '2019-04-22 16:39:36', '2019-04-22 16:39:36');
INSERT INTO `gatewaytype` VALUES (2, '特殊', '特殊网关', '2019-04-22 16:39:36', '2019-04-22 16:39:36');
INSERT INTO `gatewaytype` VALUES (3, '测试', '测试网关', '2019-04-22 16:39:36', '2019-04-22 16:39:36');

-- ----------------------------
-- Table structure for pageelement
-- ----------------------------
DROP TABLE IF EXISTS `pageelement`;
CREATE TABLE `pageelement`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pageElementName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roleName` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for role_page
-- ----------------------------
DROP TABLE IF EXISTS `role_page`;
CREATE TABLE `role_page`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roleid` int(11) NULL DEFAULT NULL,
  `pageid` int(11) NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `create_time` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `update_time` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `displayName` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `password` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `phoneNumber` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `department` int(11) NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `department`(`department`) USING BTREE,
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`department`) REFERENCES `department` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 22 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (2, '测试1', '测试1', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 2, '2019-04-22 18:17:27', '2019-04-22 18:17:27');
INSERT INTO `user` VALUES (3, '测试2', '测试2', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 3, '2019-04-22 18:30:15', '2019-04-26 16:23:37');
INSERT INTO `user` VALUES (6, '测试3', '测试3', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 3, '2019-04-22 19:49:24', '2019-04-26 16:30:23');
INSERT INTO `user` VALUES (8, '测试4', '测试4', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 1, '2019-04-22 19:49:52', '2019-04-26 16:28:22');
INSERT INTO `user` VALUES (9, '测试5', '测试5', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 3, '2019-04-23 18:50:07', '2019-04-26 16:30:31');
INSERT INTO `user` VALUES (12, '测试6', '测试6', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 3, '2019-04-26 15:34:18', '2019-04-26 15:34:18');
INSERT INTO `user` VALUES (14, '测试7', '测试', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 3, '2019-04-26 15:37:41', '2019-04-26 15:37:41');
INSERT INTO `user` VALUES (18, '测试8', '测试', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 3, '2019-04-26 15:44:08', '2019-04-26 15:44:08');
INSERT INTO `user` VALUES (19, '测试9', '测试', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 2, '2019-04-26 15:45:26', '2019-04-26 16:29:00');
INSERT INTO `user` VALUES (20, '测试10', '测试', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 1, '2019-04-26 16:17:27', '2019-04-26 16:22:11');
INSERT INTO `user` VALUES (21, '测试11', '测试', '111111', 'xxx@shu,edu,cn', '+86 13800000000', '测试', 1, '2019-04-26 16:27:23', '2019-04-26 16:28:09');

-- ----------------------------
-- Table structure for user_role
-- ----------------------------
DROP TABLE IF EXISTS `user_role`;
CREATE TABLE `user_role`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NULL DEFAULT NULL,
  `roleid` int(11) NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `create_time` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `update_time` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for workshop
-- ----------------------------
DROP TABLE IF EXISTS `workshop`;
CREATE TABLE `workshop`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `workshopName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `workshopPhoneNumber` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `workshopAddress` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `factory` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `factory`(`factory`) USING BTREE,
  CONSTRAINT `workshop_ibfk_1` FOREIGN KEY (`factory`) REFERENCES `factory` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of workshop
-- ----------------------------
INSERT INTO `workshop` VALUES (1, '车间1', '+86 13800000000', '上大路南陈路', '这是一个车间', '2019-04-18 22:11:41', '2019-04-18 22:11:41', 1);
INSERT INTO `workshop` VALUES (3, '车间2', '+86 13800000000', '锦秋路南陈路', '这还是一个车间', '2019-04-20 22:44:15', '2019-04-20 22:44:15', 2);
INSERT INTO `workshop` VALUES (4, '车间3', '+86 13800000000', '上大路祁连山路', '这又是一个车间', '2019-04-25 22:25:13', '2019-04-25 22:25:13', 2);
INSERT INTO `workshop` VALUES (6, '车间4', '+86 13800000000', '上大路沪太路', '没错还是车间', '2019-04-25 22:26:49', '2019-04-25 22:26:49', 5);

SET FOREIGN_KEY_CHECKS = 1;
