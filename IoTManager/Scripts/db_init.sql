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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,'Shanghai','A big city','2019-04-18 13:26:46','2019-04-18 13:26:46'),(2,'Nanjing','A big city','2019-04-18 13:45:28','2019-04-18 13:45:28');
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'/1','Offcial','+86 18221242858','The highest power in the company','2019-04-18 14:28:07','2019-04-18 14:28:07');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device`
--

LOCK TABLES `device` WRITE;
/*!40000 ALTER TABLE `device` DISABLE KEYS */;
INSERT INTO `device` VALUES (1,'asdfaefae','asdfasdfa',2,1,1,2,'jojo',3,'szdfgs',1,'adfe',1,'2019-04-16 12:45:53','2019-04-16 12:45:53','2019-04-16 12:45:53');
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factory`
--

LOCK TABLES `factory` WRITE;
/*!40000 ALTER TABLE `factory` DISABLE KEYS */;
INSERT INTO `factory` VALUES (1,'Shanghai University','+86 18221242858','Shangda Rd. No. 99','A university named in the city Shanghai.','2019-04-18 14:07:46','2019-04-18 14:07:46');
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gateway`
--

LOCK TABLES `gateway` WRITE;
/*!40000 ALTER TABLE `gateway` DISABLE KEYS */;
INSERT INTO `gateway` VALUES (1,'asdfasdha','asdfasdfa',3,1,1,1,1,'asdagdah','as',1,'2019-04-18 02:19:59','2019-04-18 02:19:59','2019-04-18 02:19:59');
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gatewayState`
--

LOCK TABLES `gatewayState` WRITE;
/*!40000 ALTER TABLE `gatewayState` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gatewayType`
--

LOCK TABLES `gatewayType` WRITE;
/*!40000 ALTER TABLE `gatewayType` DISABLE KEYS */;
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workshop`
--

LOCK TABLES `workshop` WRITE;
/*!40000 ALTER TABLE `workshop` DISABLE KEYS */;
INSERT INTO `workshop` VALUES (1,'Shanghai University','+86 18221242858','Shangda Rd. No. 99','A good University','2019-04-18 14:11:41','2019-04-18 14:11:41');
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

-- Dump completed on 2019-04-18 23:21:25
