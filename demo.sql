-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: demo
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'đồ chơi trẻ con','2018-03-08 00:00:00'),(2,'đồ chơi người lớn','2018-03-08 00:00:00'),(3,'đồ chơi người già','2018-03-08 00:00:00');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `cate_id` int(11) NOT NULL,
  `created` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'gấu bông',1000.00,1,'2018-03-08 00:00:00'),(2,'mec 200',2000000.00,2,'2018-03-08 00:00:00'),(3,'gậy chống',1500.00,3,'2018-03-08 00:00:00'),(4,'spider man',1500.00,0,'2018-03-07 00:00:00'),(5,'aaa',1111.00,1,'2018-03-07 00:00:00'),(6,'bbb',222.00,2,'2018-03-07 00:00:00'),(7,'ccc',333.00,3,'2018-03-07 00:00:00'),(8,'ddd',333111.00,0,'2018-03-07 00:00:00'),(9,'eeee',444.00,1,'2018-03-07 00:00:00'),(10,'ffff',5555.00,1,'2018-03-07 00:00:00'),(11,'gggg',76666.00,2,'2018-03-07 00:00:00'),(12,'aadasda',21232131.00,1,'2018-03-07 00:00:00'),(13,'aaa',1111.00,1,'2018-03-07 00:00:00'),(14,'bbb',222.00,2,'2018-03-07 00:00:00'),(15,'ccc',333.00,3,'2018-03-07 00:00:00'),(16,'ddd',333111.00,0,'2018-03-07 00:00:00'),(17,'eeee',444.00,1,'2018-03-07 00:00:00'),(18,'ffff',5555.00,1,'2018-03-07 00:00:00'),(19,'gggg',76666.00,2,'2018-03-07 00:00:00'),(20,'aadasda',21232131.00,1,'2018-03-07 00:00:00'),(21,'aaa',1111.00,1,'2018-03-07 00:00:00'),(22,'bbb',222.00,2,'2018-03-07 00:00:00'),(23,'ccc',333.00,3,'2018-03-07 00:00:00'),(24,'ddd',333111.00,0,'2018-03-07 00:00:00'),(25,'eeee',444.00,1,'2018-03-07 00:00:00'),(26,'ffff',5555.00,1,'2018-03-07 00:00:00'),(27,'gggg',76666.00,2,'2018-03-07 00:00:00'),(28,'aadasda',21232131.00,1,'2018-03-07 00:00:00');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Age` int(11) NOT NULL,
  `Gender` tinyint(4) NOT NULL,
  `Created` datetime NOT NULL,
  `role_id` int(11) NOT NULL,
  `email` varchar(50) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'phong.tranle','123456','Phong',24,0,'2018-03-08 00:00:00',1,''),(2,'duc.nguyenvan','123456','Duc',30,0,'2018-03-09 00:00:00',2,''),(3,'tuan.nguyen','123456','Tuan',22,0,'2018-03-09 00:00:00',3,'');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-13 14:25:20
