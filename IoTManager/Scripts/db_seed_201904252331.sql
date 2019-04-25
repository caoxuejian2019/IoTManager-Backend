-- MySQL dump 10.13  Distrib 8.0.15, for macos10.14 (x86_64)
--
-- Host: localhost    Database: iotmanager
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8mb4 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `city` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cityName` varchar(30) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,'Shanghai','A big city','2019-04-18 13:26:46','2019-04-18 13:26:46'),(2,'Nanjing','A big city','2019-04-18 13:45:28','2019-04-18 13:45:28'),(3,'Hangzhou','A big city','2019-04-20 14:37:11','2019-04-20 14:37:11'),(4,'Tokyo','A big city','2019-04-23 10:34:27','2019-04-23 10:34:27'),(5,'Guangzhou','A big city','2019-04-20 14:37:34','2019-04-20 14:37:34'),(6,'Shenzhen','A big city','2019-04-20 14:37:43','2019-04-20 14:37:43'),(8,'Kashi','A small town','2019-04-20 14:38:11','2019-04-20 14:38:11'),(9,'Tokyo','A big city','2019-04-23 10:34:17','2019-04-23 10:34:17');
/*!40000 ALTER TABLE `city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `company` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `companyName` varchar(50) DEFAULT NULL,
  `phoneNumber` varchar(20) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'Shanghai University','+86 13800000000','Shangda Rd.','Shanghai University','2019-04-22 10:16:34','2019-04-22 10:16:34');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `department` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `path` varchar(100) DEFAULT NULL,
  `departmentName` varchar(100) DEFAULT NULL,
  `phoneNumber` varchar(20) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'/1','Offcial','+86 13800000000','The highest power in the company','2019-04-18 14:28:07','2019-04-18 14:28:07'),(2,'/1/2','Official 2','+86 13800000000','The department affiliated to Official','2019-04-20 14:39:37','2019-04-20 14:39:37'),(3,'/1/2/3','Official 3','+86 13800000000','The department affiliated to Official 2','2019-04-20 14:40:01','2019-04-20 14:40:01');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `device`
--

DROP TABLE IF EXISTS `device`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `device` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hardwareDeviceID` varchar(50) DEFAULT NULL,
  `deviceName` varchar(50) DEFAULT NULL,
  `city` int(11) DEFAULT NULL,
  `factory` int(11) DEFAULT NULL,
  `workshop` int(11) DEFAULT NULL,
  `deviceState` int(11) DEFAULT NULL,
  `imageUrl` varchar(500) DEFAULT NULL,
  `gatewayID` int(11) DEFAULT NULL,
  `mac` varchar(30) DEFAULT NULL,
  `deviceType` int(11) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `department` int(11) DEFAULT NULL,
  `LastConnectionTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `city` (`city`),
  KEY `factory` (`factory`),
  KEY `workshop` (`workshop`),
  KEY `deviceState` (`deviceState`),
  KEY `deviceType` (`deviceType`),
  KEY `department` (`department`),
  CONSTRAINT `device_ibfk_1` FOREIGN KEY (`city`) REFERENCES `city` (`id`),
  CONSTRAINT `device_ibfk_2` FOREIGN KEY (`factory`) REFERENCES `factory` (`id`),
  CONSTRAINT `device_ibfk_3` FOREIGN KEY (`workshop`) REFERENCES `workshop` (`id`),
  CONSTRAINT `device_ibfk_4` FOREIGN KEY (`deviceState`) REFERENCES `devicestate` (`id`),
  CONSTRAINT `device_ibfk_5` FOREIGN KEY (`deviceType`) REFERENCES `devicetype` (`id`),
  CONSTRAINT `device_ibfk_6` FOREIGN KEY (`department`) REFERENCES `department` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device`
--

LOCK TABLES `device` WRITE;
/*!40000 ALTER TABLE `device` DISABLE KEYS */;
INSERT INTO `device` VALUES (1,'asdfaefae','asdfasdfa',2,1,1,1,'jojo',3,'szdfgs',1,'adfe',1,'2019-04-16 12:45:53','2019-04-16 12:45:53','2019-04-16 12:45:53'),(2,'No. 1','Test Device 1',1,1,1,1,'http://www.baidu.com',3,'123',1,'d',2,'2019-04-20 14:36:28','2019-04-20 14:36:28','2019-04-20 14:36:28'),(4,'19279nu10v098','Test Device 5',8,4,3,2,'https://www.bilibili.com',5,'apdojgaoieg',1,'A Test Device',2,'2019-04-20 16:40:50','2019-04-20 16:40:50','2019-04-20 16:40:50'),(5,'19279nu10v098','Test Device 5',8,1,1,2,'https://www.bilibili.com',5,'apdojgaoieg',1,'A Test Device',3,'2019-04-20 16:36:55','2019-04-20 16:36:55','2019-04-20 16:36:55'),(8,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-20 16:53:49','2019-04-20 16:53:49','2019-04-20 16:53:49'),(9,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:37:49','2019-04-21 07:37:49','2019-04-21 07:37:49'),(11,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:37:54','2019-04-21 07:37:54','2019-04-21 07:37:54'),(12,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:37:54','2019-04-21 07:37:54','2019-04-21 07:37:54'),(13,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:37:55','2019-04-21 07:37:55','2019-04-21 07:37:55'),(14,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:37:55','2019-04-21 07:37:55','2019-04-21 07:37:55'),(16,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:42:44','2019-04-21 07:42:44','2019-04-21 07:42:44'),(17,'Not the previous Test Device','Test Device 17',6,4,1,2,'https://www.douyu.com',17,'apdojgaoieg',1,'A Test Device',2,'2019-04-21 07:42:46','2019-04-21 07:42:46','2019-04-21 08:00:44'),(19,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:42:48','2019-04-21 07:42:48','2019-04-21 07:42:48'),(20,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:42:49','2019-04-21 07:42:49','2019-04-21 07:42:49'),(21,'Not the previous Test Device','Test Device 17',6,4,1,2,'https://www.douyu.com',17,'apdojgaoieg',1,'A Test Device',2,'2019-04-21 07:42:50','2019-04-21 07:42:50','2019-04-21 08:02:46'),(22,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:42:52','2019-04-21 07:42:52','2019-04-21 07:42:52'),(23,'Test Device 201904210052','Test Device 7',4,5,3,1,'https://www.douyu.com',107,'apdojgaoieg',1,'A Test Device',1,'2019-04-21 07:42:53','2019-04-21 07:42:53','2019-04-21 07:42:53'),(24,'Not the previous Test Device','Test Device 17',6,4,1,2,'https://www.douyu.com',17,'apdojgaoieg',1,'A Test Device',2,'2019-04-21 08:31:11','2019-04-21 08:31:11','2019-04-21 08:31:11'),(26,'Not the previous Test Device','Test Device 26',1,4,1,2,'https://www.douyu.com',17,'apdojgaoieg',1,'A Test Device',2,'2019-04-21 08:31:13','2019-04-21 08:31:13','2019-04-21 08:31:30'),(27,'Not the previous Test Device','Test Device 26',1,4,1,2,'https://www.douyu.com',17,'apdojgaoieg',1,'A Test Device',2,'2019-04-21 08:46:58','2019-04-21 08:46:58','2019-04-21 08:46:58'),(28,'Not the previous Test Device','Test Device 26',1,4,1,2,'https://www.douyu.com',17,'apdojgaoieg',1,'A Test Device',2,'2019-04-21 08:47:03','2019-04-21 08:47:03','2019-04-21 08:47:03'),(30,'Not the previous Test Device','Test Device 26',2,2,1,2,'https://www.douyu.com',17,'apdojgaoieg',1,'A Test Device',2,'2019-04-25 15:18:28','2019-04-25 15:18:28','2019-04-25 15:18:28');
/*!40000 ALTER TABLE `device` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deviceState`
--

DROP TABLE IF EXISTS `deviceState`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `deviceState` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stateName` varchar(30) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deviceState`
--

LOCK TABLES `deviceState` WRITE;
/*!40000 ALTER TABLE `deviceState` DISABLE KEYS */;
INSERT INTO `deviceState` VALUES (1,'Normal','The device performs well.','2019-04-18 14:18:14','2019-04-18 14:18:14'),(2,'Error','There is something wrong with the device, please check the device as soon as you can.','2019-04-18 14:18:48','2019-04-18 14:18:48');
/*!40000 ALTER TABLE `deviceState` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deviceType`
--

DROP TABLE IF EXISTS `deviceType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `deviceType` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `deviceTypeName` varchar(50) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deviceType`
--

LOCK TABLES `deviceType` WRITE;
/*!40000 ALTER TABLE `deviceType` DISABLE KEYS */;
INSERT INTO `deviceType` VALUES (1,'General Device','A kind of device widely used.','2019-04-18 14:23:42','2019-04-18 14:23:42');
/*!40000 ALTER TABLE `deviceType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factory`
--

DROP TABLE IF EXISTS `factory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `factory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `factoryName` varchar(50) DEFAULT NULL,
  `factoryPhoneNumber` varchar(30) DEFAULT NULL,
  `factoryAddress` varchar(100) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `city` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `city` (`city`),
  CONSTRAINT `factory_ibfk_1` FOREIGN KEY (`city`) REFERENCES `city` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factory`
--

LOCK TABLES `factory` WRITE;
/*!40000 ALTER TABLE `factory` DISABLE KEYS */;
INSERT INTO `factory` VALUES (1,'Shanghai University','+86 138000002363462000','Shangda Rd. No.3 99','A university named in the city Shanghai.','2019-04-18 14:07:46','2019-04-25 10:36:14',3),(2,'Tongji University','+86 13800000000','Somewhere','A university named Tongji University','2019-04-20 14:41:30','2019-04-20 14:41:30',1),(3,'East China Normal University','+86 13800000000','Somewhere','A university named East China Normal University.','2019-04-20 14:42:13','2019-04-20 14:42:13',1),(4,'Shanghai University','+86 138000002363462000','Shangda Rd. No.3 99','A university named in the city Shanghai.','2019-04-20 14:42:40','2019-04-25 10:36:08',3),(5,'Shanghai Jiaotong University','+86 13800000000','Somewhere','A university named Shanghai Jiaotong University.','2019-04-20 14:43:05','2019-04-20 14:43:05',1),(6,'Shanghai University','+86 13800000000','Shangda Rd. No. 99','A university named in the city Shanghai.','2019-04-25 10:24:42','2019-04-25 10:24:42',1),(9,'Shanghai University','+86 138000002363462000','Shangda Rd. No.3 99','A university named in the city Shanghai.','2019-04-25 10:40:15','2019-04-25 10:40:15',3),(10,'Shanghai University','+86 138000002363462000','Shangda Rd. No.3 99','A university named in the city Shanghai.','2019-04-25 10:40:16','2019-04-25 10:40:16',3);
/*!40000 ALTER TABLE `factory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gateway`
--

DROP TABLE IF EXISTS `gateway`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `gateway` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hardwareGatewayID` varchar(50) DEFAULT NULL,
  `gatewayName` varchar(50) DEFAULT NULL,
  `gatewayType` int(11) DEFAULT NULL,
  `city` int(11) DEFAULT NULL,
  `factory` int(11) DEFAULT NULL,
  `workshop` int(11) DEFAULT NULL,
  `gatewayState` int(11) DEFAULT NULL,
  `imageUrl` varchar(500) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `department` int(11) DEFAULT NULL,
  `lastConnectionTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `city` (`city`),
  KEY `factory` (`factory`),
  KEY `workshop` (`workshop`),
  KEY `gatewayState` (`gatewayState`),
  KEY `gatewayType` (`gatewayType`),
  KEY `department` (`department`),
  CONSTRAINT `gateway_ibfk_1` FOREIGN KEY (`city`) REFERENCES `city` (`id`),
  CONSTRAINT `gateway_ibfk_2` FOREIGN KEY (`factory`) REFERENCES `factory` (`id`),
  CONSTRAINT `gateway_ibfk_3` FOREIGN KEY (`workshop`) REFERENCES `workshop` (`id`),
  CONSTRAINT `gateway_ibfk_4` FOREIGN KEY (`gatewayState`) REFERENCES `gatewaystate` (`id`),
  CONSTRAINT `gateway_ibfk_5` FOREIGN KEY (`gatewayType`) REFERENCES `gatewaytype` (`id`),
  CONSTRAINT `gateway_ibfk_6` FOREIGN KEY (`department`) REFERENCES `department` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gateway`
--

LOCK TABLES `gateway` WRITE;
/*!40000 ALTER TABLE `gateway` DISABLE KEYS */;
INSERT INTO `gateway` VALUES (1,'asdfasdha','asdfasdfa',3,1,1,1,1,'asdagdah','as',1,'2019-04-18 02:19:59','2019-04-18 02:19:59','2019-04-18 02:19:59'),(2,'Test Gateway 2','Gateway Name 2',2,4,2,1,2,'http://www.baidu.com','A Test Gateway',3,'2019-04-22 08:41:53','2019-04-22 08:41:53','2019-04-22 08:41:53'),(3,'asdfasdha','asdfasdfa',3,1,1,1,1,'asdagdah','as',1,'2019-04-22 09:14:44','2019-04-22 09:14:44','2019-04-22 09:14:44'),(5,'asdfasdha','asdfasdfa',3,1,1,1,1,'asdagdah','as',1,'2019-04-22 09:14:53','2019-04-22 09:14:53','2019-04-22 09:14:53');
/*!40000 ALTER TABLE `gateway` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gatewayState`
--

DROP TABLE IF EXISTS `gatewayState`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `gatewayState` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stateName` varchar(30) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gatewayState`
--

LOCK TABLES `gatewayState` WRITE;
/*!40000 ALTER TABLE `gatewayState` DISABLE KEYS */;
INSERT INTO `gatewayState` VALUES (1,'Normal','Gateway Performs Well','2019-04-22 08:37:50','2019-04-22 08:37:50'),(2,'Error','There is something wrong with gateway, please check immediately.','2019-04-22 08:38:14','2019-04-22 08:38:14');
/*!40000 ALTER TABLE `gatewayState` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gatewayType`
--

DROP TABLE IF EXISTS `gatewayType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `gatewayType` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `gatewayTypeName` varchar(50) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gatewayType`
--

LOCK TABLES `gatewayType` WRITE;
/*!40000 ALTER TABLE `gatewayType` DISABLE KEYS */;
INSERT INTO `gatewayType` VALUES (1,'No. 1','Gateway Type Number 1','2019-04-22 08:39:36','2019-04-22 08:39:36'),(2,'No. 2','Gateway Type Number 2','2019-04-22 08:39:36','2019-04-22 08:39:36'),(3,'No. 3','Gateway Type Number 3','2019-04-22 08:39:36','2019-04-22 08:39:36');
/*!40000 ALTER TABLE `gatewayType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pageElement`
--

DROP TABLE IF EXISTS `pageElement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pageElement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pageElementName` varchar(30) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pageElement`
--

LOCK TABLES `pageElement` WRITE;
/*!40000 ALTER TABLE `pageElement` DISABLE KEYS */;
/*!40000 ALTER TABLE `pageElement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roleName` varchar(20) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_page`
--

DROP TABLE IF EXISTS `role_page`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `role_page` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roleid` int(11) DEFAULT NULL,
  `pageid` int(11) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `create_time` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `update_time` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role_page`
--

LOCK TABLES `role_page` WRITE;
/*!40000 ALTER TABLE `role_page` DISABLE KEYS */;
/*!40000 ALTER TABLE `role_page` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userName` varchar(30) DEFAULT NULL,
  `displayName` varchar(30) DEFAULT NULL,
  `password` varchar(60) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `company` int(11) DEFAULT NULL,
  `phoneNumber` varchar(20) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `department` int(11) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `department` (`department`),
  KEY `company` (`company`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`department`) REFERENCES `department` (`id`),
  CONSTRAINT `user_ibfk_2` FOREIGN KEY (`company`) REFERENCES `company` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (2,'User 1','U1','aoisdjfoajefoiagj','Sample@gmail.com',1,'+86 13800000000','User 1',2,'2019-04-22 10:17:27','2019-04-22 10:17:27'),(3,'User 3','U3','aoisrjhaopie','Sample3@gmail.com',1,'+86 13800000000','User 3',1,'2019-04-22 10:30:15','2019-04-22 10:30:15'),(4,'Test User 1','TU1','1231525','sample@gmail.com',1,'+86 13800000000','Test User 1',1,'2019-04-22 11:48:49','2019-04-22 11:48:49'),(5,'Test User 1','TU1','1231525','sample@gmail.com',1,'+86 13800000000','Test User 1',1,'2019-04-22 11:48:50','2019-04-22 11:48:50'),(6,'Test User 6','TU26','1231525','sample00001@gmail.com',1,'+86 13812345000','Test User 6',3,'2019-04-22 11:49:24','2019-04-22 11:58:47'),(8,'Test User 2','TU2','1231525','sample@gmail.com',1,'+86 13800000000','Test User 2',1,'2019-04-22 11:49:52','2019-04-22 11:49:52'),(9,'Test User 6','TU26','a2420a7ef999a49c827a06d3adcd6a58','sample00001@gmail.com',1,'+86 13812345000','Test User 6',3,'2019-04-23 10:50:07','2019-04-23 10:50:07');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_role`
--

DROP TABLE IF EXISTS `user_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user_role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL,
  `roleid` int(11) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `create_time` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `update_time` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_role`
--

LOCK TABLES `user_role` WRITE;
/*!40000 ALTER TABLE `user_role` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workshop`
--

DROP TABLE IF EXISTS `workshop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `workshop` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `workshopName` varchar(50) DEFAULT NULL,
  `workshopPhoneNumber` varchar(50) DEFAULT NULL,
  `workshopAddress` varchar(100) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `createTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updateTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `factory` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `factory` (`factory`),
  CONSTRAINT `workshop_ibfk_1` FOREIGN KEY (`factory`) REFERENCES `factory` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workshop`
--

LOCK TABLES `workshop` WRITE;
/*!40000 ALTER TABLE `workshop` DISABLE KEYS */;
INSERT INTO `workshop` VALUES (1,'Tongji University','+86 13800000000','Shangda Rd. No. 99','A good University','2019-04-18 14:11:41','2019-04-18 14:11:41',1),(3,'Shanghai University','+86 13800000000','Somewhere','A university named Shanghai University.','2019-04-20 14:44:15','2019-04-20 14:44:15',2),(4,'Shanghai University','+86 13800000000','Somewhere','A university named Shanghai University.','2019-04-25 14:25:13','2019-04-25 14:25:13',2),(6,'Shanghai University','+86 13800000000','Somewhere','A university named Shanghai University.','2019-04-25 14:26:49','2019-04-25 14:26:49',5);
/*!40000 ALTER TABLE `workshop` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-04-25 23:31:23
