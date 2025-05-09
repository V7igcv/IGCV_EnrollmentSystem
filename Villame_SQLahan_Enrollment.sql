CREATE DATABASE  IF NOT EXISTS `enrollment` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `enrollment`;
-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: enrollment
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `courses` (
  `course_id` int NOT NULL AUTO_INCREMENT,
  `course_name` varchar(100) NOT NULL,
  `department_id` int NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`course_id`),
  KEY `department_id` (`department_id`),
  CONSTRAINT `courses_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `departments` (`department_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES (1,'Database Systems',1,NULL,NULL),(2,'Advanced Databases',1,NULL,NULL),(3,'Marketing 101',2,NULL,NULL),(4,'Digital Marketing Strategies',2,NULL,NULL),(5,'Mechanical Engineering Basics',3,NULL,NULL),(6,'Thermodynamics',3,NULL,NULL),(7,'Algebra',4,NULL,NULL),(8,'Calculus',4,NULL,NULL),(9,'Genetics',5,NULL,NULL),(10,'Molecular Biology',5,NULL,NULL),(11,'Quantum Mechanics',6,NULL,NULL),(12,'Relativity and Cosmology',6,NULL,NULL),(13,'Organic Chemistry',7,NULL,NULL),(14,'World History',8,NULL,NULL),(15,'Cognitive Psychology',9,NULL,NULL),(16,'English Literature',10,NULL,NULL),(17,'Public Speaking',10,NULL,NULL),(18,'Event Driven Programming',21,NULL,NULL),(19,'Business Economics',23,NULL,'2025-05-09 20:59:08'),(20,'Microeconomics',23,NULL,NULL),(21,'Macroeconomics',23,NULL,NULL);
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `before_update_course` BEFORE UPDATE ON `courses` FOR EACH ROW BEGIN
    IF (SELECT COUNT(*) FROM enrollments WHERE course_id = OLD.course_id) > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Cannot change course name with enrolled students';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departments` (
  `department_id` int NOT NULL AUTO_INCREMENT,
  `department_name` varchar(100) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`department_id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (1,'Computer Science',NULL,NULL),(2,'Business',NULL,NULL),(3,'Engineering',NULL,NULL),(4,'Mathematics',NULL,NULL),(5,'Biology',NULL,NULL),(6,'Physics',NULL,NULL),(7,'Chemistry',NULL,NULL),(8,'History',NULL,NULL),(9,'Psychology',NULL,NULL),(10,'English',NULL,NULL),(21,'Programming',NULL,NULL),(22,'Meteorology',NULL,'2025-05-08 23:55:52'),(23,'Economics',NULL,NULL);
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `before_delete_department` BEFORE DELETE ON `departments` FOR EACH ROW BEGIN
    IF EXISTS (SELECT 1 FROM instructors WHERE department_id = OLD.department_id) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Cannot delete department with assigned instructors';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `enrollment_logs`
--

DROP TABLE IF EXISTS `enrollment_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enrollment_logs` (
  `log_id` int NOT NULL AUTO_INCREMENT,
  `log_time` datetime NOT NULL,
  `total_enrollments` int NOT NULL,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrollment_logs`
--

LOCK TABLES `enrollment_logs` WRITE;
/*!40000 ALTER TABLE `enrollment_logs` DISABLE KEYS */;
INSERT INTO `enrollment_logs` VALUES (1,'2025-04-03 08:48:04',20),(2,'2025-04-03 08:48:14',20),(3,'2025-04-03 08:48:24',20),(4,'2025-04-03 08:48:34',21),(5,'2025-04-03 08:48:44',21),(6,'2025-04-03 08:48:54',21),(7,'2025-04-03 08:49:04',21);
/*!40000 ALTER TABLE `enrollment_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enrollments`
--

DROP TABLE IF EXISTS `enrollments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enrollments` (
  `enrollment_id` int NOT NULL AUTO_INCREMENT,
  `student_id` int NOT NULL,
  `course_id` int NOT NULL,
  `enrollment_date` date NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`enrollment_id`),
  KEY `student_id` (`student_id`),
  KEY `course_id` (`course_id`),
  CONSTRAINT `enrollments_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `enrollments_ibfk_2` FOREIGN KEY (`course_id`) REFERENCES `courses` (`course_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enrollments`
--

LOCK TABLES `enrollments` WRITE;
/*!40000 ALTER TABLE `enrollments` DISABLE KEYS */;
INSERT INTO `enrollments` VALUES (1,1,1,'2025-02-01',NULL,NULL),(2,1,2,'2025-02-01',NULL,NULL),(3,2,1,'2025-02-02',NULL,NULL),(4,3,3,'2025-02-03',NULL,NULL),(5,4,2,'2025-02-04',NULL,NULL),(6,4,4,'2025-02-04',NULL,NULL),(7,5,5,'2025-02-05',NULL,NULL),(8,6,7,'2025-02-06',NULL,NULL),(9,7,8,'2025-02-07',NULL,NULL),(10,7,6,'2025-02-07',NULL,NULL),(11,8,8,'2025-02-08',NULL,NULL),(12,9,9,'2025-02-09',NULL,NULL),(13,10,10,'2025-02-10',NULL,NULL),(14,10,11,'2025-02-10',NULL,NULL),(15,11,12,'2025-02-11',NULL,NULL),(16,11,13,'2025-02-11',NULL,NULL),(17,12,12,'2025-02-12',NULL,NULL),(18,13,14,'2025-02-13',NULL,NULL),(19,14,15,'2025-02-14',NULL,NULL),(20,15,16,'2025-02-15',NULL,NULL),(21,2,2,'2025-02-16',NULL,NULL),(22,17,18,'2025-04-13',NULL,NULL),(23,14,8,'2025-04-13',NULL,NULL);
/*!40000 ALTER TABLE `enrollments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evaluations`
--

DROP TABLE IF EXISTS `evaluations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evaluations` (
  `evaluation_id` int NOT NULL AUTO_INCREMENT,
  `student_id` int NOT NULL,
  `instructor_id` int NOT NULL,
  `course_id` int NOT NULL,
  `rating` int DEFAULT NULL,
  `comments` text,
  `evaluation_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`evaluation_id`),
  KEY `student_id` (`student_id`),
  KEY `instructor_id` (`instructor_id`),
  KEY `course_id` (`course_id`),
  CONSTRAINT `evaluations_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `evaluations_ibfk_2` FOREIGN KEY (`instructor_id`) REFERENCES `instructors` (`instructor_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `evaluations_ibfk_3` FOREIGN KEY (`course_id`) REFERENCES `courses` (`course_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `evaluations_chk_1` CHECK ((`rating` between 1 and 5))
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluations`
--

LOCK TABLES `evaluations` WRITE;
/*!40000 ALTER TABLE `evaluations` DISABLE KEYS */;
INSERT INTO `evaluations` VALUES (1,1,1,1,5,'Great course!','2025-02-10 16:00:00',NULL,NULL),(2,1,2,2,4,'Very informative.','2025-02-11 16:00:00',NULL,NULL),(3,2,1,2,4,'Loved the discussions.','2025-02-12 16:00:00',NULL,NULL),(4,3,3,3,3,'Could be more interactive.','2025-02-13 16:00:00',NULL,NULL),(5,5,5,5,5,'Very nice!','2025-02-14 16:00:00',NULL,NULL),(6,7,6,8,3,'Just average','2025-02-15 16:00:00',NULL,NULL),(7,9,8,9,5,'Very informative','2025-02-16 16:00:00',NULL,NULL);
/*!40000 ALTER TABLE `evaluations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grade_logs`
--

DROP TABLE IF EXISTS `grade_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grade_logs` (
  `log_id` int NOT NULL AUTO_INCREMENT,
  `grade_id` int DEFAULT NULL,
  `enrollment_id` int DEFAULT NULL,
  `old_grade` decimal(5,2) DEFAULT NULL,
  `new_grade` decimal(5,2) DEFAULT NULL,
  `log_time` datetime DEFAULT NULL,
  PRIMARY KEY (`log_id`),
  KEY `grade_id` (`grade_id`),
  KEY `enrollment_id` (`enrollment_id`),
  CONSTRAINT `grade_logs_ibfk_1` FOREIGN KEY (`grade_id`) REFERENCES `grades` (`grade_id`) ON DELETE CASCADE,
  CONSTRAINT `grade_logs_ibfk_2` FOREIGN KEY (`enrollment_id`) REFERENCES `enrollments` (`enrollment_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grade_logs`
--

LOCK TABLES `grade_logs` WRITE;
/*!40000 ALTER TABLE `grade_logs` DISABLE KEYS */;
INSERT INTO `grade_logs` VALUES (1,2,3,2.00,1.50,'2025-03-16 19:55:57');
/*!40000 ALTER TABLE `grade_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grades`
--

DROP TABLE IF EXISTS `grades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grades` (
  `grade_id` int NOT NULL AUTO_INCREMENT,
  `enrollment_id` int NOT NULL,
  `grade` decimal(2,1) NOT NULL,
  `date_recorded` date NOT NULL,
  PRIMARY KEY (`grade_id`),
  KEY `enrollment_id` (`enrollment_id`),
  CONSTRAINT `grades_ibfk_1` FOREIGN KEY (`enrollment_id`) REFERENCES `enrollments` (`enrollment_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grades`
--

LOCK TABLES `grades` WRITE;
/*!40000 ALTER TABLE `grades` DISABLE KEYS */;
INSERT INTO `grades` VALUES (1,1,1.2,'2025-02-20'),(2,3,1.5,'2025-02-21'),(3,4,1.5,'2025-02-22'),(4,5,1.8,'2025-02-23'),(5,7,2.3,'2025-02-24'),(6,8,1.9,'2025-02-25'),(7,9,1.1,'2025-02-26'),(8,11,1.4,'2025-02-27'),(9,12,1.5,'2025-02-28'),(10,13,2.0,'2025-03-01');
/*!40000 ALTER TABLE `grades` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `after_update_grade` AFTER UPDATE ON `grades` FOR EACH ROW BEGIN
    INSERT INTO grade_logs (grade_id, enrollment_id, old_grade, new_grade, log_time)
    VALUES (NEW.grade_id, NEW.enrollment_id, OLD.grade, NEW.grade, NOW());
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `instructor_deletions`
--

DROP TABLE IF EXISTS `instructor_deletions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instructor_deletions` (
  `deleted_id` int NOT NULL AUTO_INCREMENT,
  `instructor_id` int NOT NULL,
  `instructor_fname` varchar(100) NOT NULL,
  `instructor_lname` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone` varchar(15) NOT NULL,
  `department_id` int DEFAULT NULL,
  `deleted_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`deleted_id`),
  KEY `instructor_id` (`instructor_id`),
  KEY `department_id` (`department_id`),
  CONSTRAINT `instructor_deletions_ibfk_2` FOREIGN KEY (`department_id`) REFERENCES `departments` (`department_id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instructor_deletions`
--

LOCK TABLES `instructor_deletions` WRITE;
/*!40000 ALTER TABLE `instructor_deletions` DISABLE KEYS */;
INSERT INTO `instructor_deletions` VALUES (2,16,'Illyana','Rasputin','limbo@example.com','09123456789',10,'2025-03-16 12:31:09');
/*!40000 ALTER TABLE `instructor_deletions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instructors`
--

DROP TABLE IF EXISTS `instructors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instructors` (
  `instructor_id` int NOT NULL AUTO_INCREMENT,
  `instructor_fname` varchar(100) NOT NULL,
  `instructor_lname` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone` varchar(15) NOT NULL,
  `department_id` int NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`instructor_id`),
  UNIQUE KEY `email` (`email`),
  KEY `department_id` (`department_id`),
  CONSTRAINT `instructors_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `departments` (`department_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instructors`
--

LOCK TABLES `instructors` WRITE;
/*!40000 ALTER TABLE `instructors` DISABLE KEYS */;
INSERT INTO `instructors` VALUES (1,'Stephen','Strange','strange@gmail.com','09171234567',1,'2025-05-09 00:55:15',NULL),(2,'Peter','Parker','webber@gmail.com','09287654321',1,NULL,NULL),(3,'Wanda','Maximoff','myNewEmail@gmail.com','09999999999',2,NULL,NULL),(4,'Jeff','Sharkboy','sharkboy@gmail.com','09069876543',2,NULL,NULL),(5,'Luna','Snow','snow_white@gmail.com','09334567890',3,NULL,NULL),(6,'Steve','Rogers','assemble@gmail.com','09186543210',4,NULL,NULL),(7,'Charles','Xavier','x@gmail.com','09218765432',5,NULL,NULL),(8,'Victor','Adams','worlock@gmail.com','09993210987',5,NULL,NULL),(9,'Bruce','Banner','smash@gmail.com','09055678901',6,NULL,NULL),(10,'Jean','Grey','phoenix@gmail.com','09382106543',7,NULL,NULL),(11,'Tony','Stark','geniusbillionaire@gmail.com','09238273643',7,NULL,NULL),(12,'Loki','Laufeyson','godofstories@gmail.com','09271940532',8,NULL,NULL),(13,'Bruce','Wayne','4thwall@gmail.com','09381121948',9,NULL,NULL),(14,'I am','Groot','iamgroot@gmail.com','09777323299',10,NULL,NULL),(15,'Agatha','Harkness','witchesroad@gmail.com','09888823217',10,NULL,NULL),(17,'Natasha','Romanoff','sniper@gmail.com','09999994444',6,NULL,NULL),(18,'Jake','Locke','night@gmail.com','09874434544',23,'2025-05-09 21:12:55',NULL);
/*!40000 ALTER TABLE `instructors` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `after_instructor_delete` AFTER DELETE ON `instructors` FOR EACH ROW BEGIN
  INSERT INTO instructor_deletions (
    instructor_id, instructor_fname, instructor_lname, email, phone, department_id, deleted_at
  ) VALUES (
    OLD.instructor_id, OLD.instructor_fname, OLD.instructor_lname, OLD.email, OLD.phone, OLD.department_id, Now()
  );
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `payment_logs`
--

DROP TABLE IF EXISTS `payment_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payment_logs` (
  `log_id` int NOT NULL AUTO_INCREMENT,
  `payment_id` int DEFAULT NULL,
  `student_id` int DEFAULT NULL,
  `amount` decimal(10,2) DEFAULT NULL,
  `log_time` datetime DEFAULT NULL,
  PRIMARY KEY (`log_id`),
  KEY `payment_id` (`payment_id`),
  KEY `student_id` (`student_id`),
  CONSTRAINT `payment_logs_ibfk_1` FOREIGN KEY (`payment_id`) REFERENCES `payments` (`payment_id`) ON DELETE CASCADE,
  CONSTRAINT `payment_logs_ibfk_2` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment_logs`
--

LOCK TABLES `payment_logs` WRITE;
/*!40000 ALTER TABLE `payment_logs` DISABLE KEYS */;
INSERT INTO `payment_logs` VALUES (1,12,10,11700.00,'2025-03-16 19:48:13'),(2,13,17,500.00,'2025-05-08 19:47:12'),(3,14,14,3000.00,'2025-05-09 21:04:59');
/*!40000 ALTER TABLE `payment_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `payment_id` int NOT NULL AUTO_INCREMENT,
  `student_id` int NOT NULL,
  `amount_paid` decimal(10,2) NOT NULL,
  `payment_date` date NOT NULL,
  `fee_id` int NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`payment_id`),
  KEY `student_id` (`student_id`),
  KEY `fk_payments_tuition_fees` (`fee_id`),
  CONSTRAINT `fk_payments_tuition_fees` FOREIGN KEY (`fee_id`) REFERENCES `tuition_fees` (`fee_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (1,1,5000.00,'2025-03-01',1,NULL,NULL),(2,4,4500.00,'2025-03-02',2,NULL,NULL),(3,3,6000.00,'2025-03-03',3,NULL,NULL),(4,4,5500.00,'2025-03-04',4,NULL,NULL),(5,5,5300.00,'2025-03-05',5,NULL,NULL),(6,6,5000.00,'2025-03-01',7,NULL,NULL),(7,7,4500.00,'2025-03-02',8,NULL,NULL),(8,8,6000.00,'2025-03-03',8,NULL,NULL),(9,9,5500.00,'2025-03-04',9,NULL,NULL),(10,10,5300.00,'2025-03-05',10,NULL,NULL),(11,10,10800.00,'2025-03-10',10,NULL,NULL),(12,10,11700.00,'2025-03-11',10,NULL,NULL),(13,17,500.00,'2025-05-08',17,'2025-05-08 19:47:12',NULL),(14,14,3000.00,'2025-05-09',8,'2025-05-09 21:04:59',NULL);
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `before_insert_payment` BEFORE INSERT ON `payments` FOR EACH ROW BEGIN  
    IF NEW.amount_paid > 10000 THEN  
        SET NEW.amount_paid = NEW.amount_paid * 0.9;  
    END IF;  
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `after_insert_payment` AFTER INSERT ON `payments` FOR EACH ROW BEGIN
    INSERT INTO payment_logs (payment_id, student_id, amount, log_time)
    VALUES (NEW.payment_id, NEW.student_id, NEW.amount_paid, NOW());
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `schedules`
--

DROP TABLE IF EXISTS `schedules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedules` (
  `schedule_id` int NOT NULL AUTO_INCREMENT,
  `course_id` int NOT NULL,
  `instructor_id` int NOT NULL,
  `day_of_week` varchar(10) NOT NULL,
  `start_time` time NOT NULL,
  `end_time` time NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`schedule_id`),
  KEY `course_id` (`course_id`),
  KEY `instructor_id` (`instructor_id`),
  CONSTRAINT `schedules_ibfk_1` FOREIGN KEY (`course_id`) REFERENCES `courses` (`course_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `schedules_ibfk_2` FOREIGN KEY (`instructor_id`) REFERENCES `instructors` (`instructor_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedules`
--

LOCK TABLES `schedules` WRITE;
/*!40000 ALTER TABLE `schedules` DISABLE KEYS */;
INSERT INTO `schedules` VALUES (1,1,1,'Monday','08:00:00','10:00:00','2025-05-09 01:19:34',NULL),(2,2,2,'Tuesday','10:00:00','12:00:00',NULL,NULL),(3,3,3,'Wednesday','13:00:00','15:00:00',NULL,NULL),(4,4,4,'Thursday','14:00:00','16:00:00',NULL,NULL),(5,5,5,'Friday','09:00:00','11:00:00',NULL,NULL),(6,7,6,'Monday','08:00:00','10:00:00',NULL,NULL),(7,9,7,'Tuesday','10:00:00','12:00:00',NULL,NULL),(8,9,8,'Wednesday','13:00:00','15:00:00',NULL,NULL),(9,11,9,'Thursday','14:00:00','16:00:00',NULL,NULL),(10,13,10,'Friday','09:00:00','11:00:00',NULL,NULL),(11,12,17,'Wednesday','13:00:00','16:00:00',NULL,NULL),(12,20,18,'Tuesday','13:00:00','16:00:00',NULL,NULL),(13,21,18,'Monday','09:00:00','12:00:00',NULL,NULL);
/*!40000 ALTER TABLE `schedules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `students` (
  `student_id` int NOT NULL AUTO_INCREMENT,
  `student_fname` varchar(100) NOT NULL,
  `student_lname` varchar(100) NOT NULL,
  `age` int NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone` varchar(15) NOT NULL,
  `address` text NOT NULL,
  `student_number` varchar(15) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`student_id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,'Aether','Reyes',20,'aetherreyes1@school.edu','09123456789','Mondstadt, Windrise','2023006','2025-05-08 23:07:55',NULL),(2,'Lumine','Batumbakal',21,'luminebatumbakal2@school.edu','09234567890','Mondstadt, Starfell Valley','2023007',NULL,NULL),(3,'Diluc','Ragnvindr',23,'dilucragnvindr3@school.edu','09345678901','Dawn Winery, Mondstadt','2023008',NULL,NULL),(4,'Jean','Gunnhildr',22,'jeangunnhildr4@school.edu','09456789012','Knights of Favonius HQ, Mondstadt','2023009',NULL,NULL),(5,'Kamisato','Ayaka',19,'kamisatoayaka5@school.edu','09567890123','Kamisato Estate, Inazuma','2023010',NULL,NULL),(6,'Zhongli','Morax',25,'zhonglimorax6@school.edu','09678901234','Wangshu Inn, Liyue','2023011',NULL,NULL),(7,'Raiden','Ei',24,'raidenei7@school.edu','09789012345','Grand Narukami Shrine, Inazuma','2023012',NULL,NULL),(8,'Tartaglia','Childe',22,'tartagliachilde8@school.edu','09890123456','Northland Bank, Liyue','2023013',NULL,NULL),(9,'Albedo','Kreideprinz',23,'albedokreideprinz9@school.edu','09901234567','Dragonspine, Mondstadt','2023014',NULL,NULL),(10,'Eula','Lawrence',21,'eulalawrence10@school.edu','09012345678','Lawrence Manor, Mondstadt','2023015',NULL,NULL),(11,'Yun','Jin',20,'yunjin11@school.edu','09444538824','Wangshu Inn, Liyue','2023016',NULL,NULL),(12,'Sangonomiya','Kokomi',18,'sangonomiyakokomi12@school.edu','09882733245','Watatsumi Island, Inazuma','2023017',NULL,NULL),(13,'Venti','Barbatos',22,'ventibarbatos13@school.edu','09993435572','Mondstadt, Windrise','2023018',NULL,NULL),(14,'Kamisato','Ayato',24,'kamisatoayato14@school.edu','09774663231','Kamisato Estate, Inazuma','2023019',NULL,NULL),(15,'Adeptus','Xiao',23,'adeptusxiao15@school.edu','09444577288','Wangshu Inn, Liyue','2023020',NULL,NULL),(16,'Heizou','Shakanoin',21,'invalidemail@student.edu','9999999999','Legazpi, City','2023021',NULL,NULL),(17,'Sangonomiya','Kokomi',25,'jellyfish@school.edu','09997135311','Watatsumi Island, Inazuma','2023022',NULL,NULL),(18,'Ian','Villame',20,'gab@gmail.com','09174443323','Legazpi City','2023022',NULL,NULL),(19,'Kaeya','Alberichhhh',22,'kaeya@gmail.com','09554445434','Windrise, Mondstadt','2023024','2025-05-09 20:54:44','2025-05-09 20:54:55');
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tuition_fees`
--

DROP TABLE IF EXISTS `tuition_fees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tuition_fees` (
  `fee_id` int NOT NULL AUTO_INCREMENT,
  `course_id` int NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `academic_year` varchar(9) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`fee_id`),
  KEY `course_id` (`course_id`),
  CONSTRAINT `tuition_fees_ibfk_1` FOREIGN KEY (`course_id`) REFERENCES `courses` (`course_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tuition_fees`
--

LOCK TABLES `tuition_fees` WRITE;
/*!40000 ALTER TABLE `tuition_fees` DISABLE KEYS */;
INSERT INTO `tuition_fees` VALUES (1,1,5000.00,'2024-2025','2025-05-09 00:58:40',NULL),(2,2,4500.00,'2024-2025',NULL,NULL),(3,3,6000.00,'2024-2025',NULL,NULL),(4,4,5500.00,'2024-2025',NULL,NULL),(5,5,5300.00,'2024-2025',NULL,NULL),(6,6,5000.00,'2024-2025',NULL,NULL),(7,7,4500.00,'2024-2025',NULL,NULL),(8,8,6000.00,'2024-2025',NULL,NULL),(9,9,5500.00,'2024-2025',NULL,NULL),(10,10,5300.00,'2024-2025',NULL,NULL),(11,11,5000.00,'2024-2025',NULL,NULL),(12,12,4500.00,'2024-2025',NULL,NULL),(13,13,6000.00,'2024-2025',NULL,NULL),(14,14,5500.00,'2024-2025',NULL,NULL),(15,15,5300.00,'2024-2025',NULL,NULL),(16,16,5000.00,'2024-2025',NULL,NULL),(17,18,4000.00,'2024-2025',NULL,NULL),(18,17,2000.50,'2024-2025',NULL,NULL);
/*!40000 ALTER TABLE `tuition_fees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(255) NOT NULL,
  `recovery_birthdate` date NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `deleted_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Ian Gabriel','Villame','ian@gmail.com','87654321','2004-09-07','2025-05-07 14:09:58','2025-05-09 03:36:39',NULL),(2,'Deanielle','Villarroya','eyiel@gmail.com','12345678','2004-03-04','2025-05-08 04:23:55','2025-05-08 12:24:25','2025-05-08 12:24:25'),(3,'Mark James','Barreda','mark@gmail.com','12345678','2004-11-25','2025-05-09 01:10:22',NULL,NULL),(4,'Vicente','Bercasio','vicente@gmail.com','12345678','2003-02-02','2025-05-09 03:32:57',NULL,NULL),(5,'Iannn','Villame','gabriel@gmail.com','87654321','2004-09-07','2025-05-09 12:33:20','2025-05-09 12:35:11',NULL),(6,'Gabby','Villame','gabb@gmail.com','12345678','2004-02-09','2025-05-09 12:46:30','2025-05-09 12:47:36','2025-05-09 12:47:36');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `view_combined_students_instructors`
--

DROP TABLE IF EXISTS `view_combined_students_instructors`;
/*!50001 DROP VIEW IF EXISTS `view_combined_students_instructors`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_combined_students_instructors` AS SELECT 
 1 AS `name`,
 1 AS `role`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_instructor_departments`
--

DROP TABLE IF EXISTS `view_instructor_departments`;
/*!50001 DROP VIEW IF EXISTS `view_instructor_departments`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_instructor_departments` AS SELECT 
 1 AS `instructor_id`,
 1 AS `instructor_name`,
 1 AS `email`,
 1 AS `phone`,
 1 AS `department_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_student_contacts`
--

DROP TABLE IF EXISTS `view_student_contacts`;
/*!50001 DROP VIEW IF EXISTS `view_student_contacts`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_student_contacts` AS SELECT 
 1 AS `student_id`,
 1 AS `full_name`,
 1 AS `email`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_student_courses`
--

DROP TABLE IF EXISTS `view_student_courses`;
/*!50001 DROP VIEW IF EXISTS `view_student_courses`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_student_courses` AS SELECT 
 1 AS `full_name`,
 1 AS `course_name`,
 1 AS `total_enrollments`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_student_tuition`
--

DROP TABLE IF EXISTS `view_student_tuition`;
/*!50001 DROP VIEW IF EXISTS `view_student_tuition`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_student_tuition` AS SELECT 
 1 AS `student_id`,
 1 AS `student_lname`,
 1 AS `total_fee`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_total_students_per_course`
--

DROP TABLE IF EXISTS `view_total_students_per_course`;
/*!50001 DROP VIEW IF EXISTS `view_total_students_per_course`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_total_students_per_course` AS SELECT 
 1 AS `course_name`,
 1 AS `total_students`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'enrollment'
--
/*!50106 SET @save_time_zone= @@TIME_ZONE */ ;
/*!50106 DROP EVENT IF EXISTS `delete_old_enrollments` */;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8mb4 */ ;;
/*!50003 SET character_set_results = utf8mb4 */ ;;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `delete_old_enrollments` ON SCHEDULE AT '2025-04-03 08:42:21' ON COMPLETION PRESERVE DISABLE DO DELETE FROM enrollments WHERE enrollment_date < '2025-01-01' */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `log_enrollment_counts` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8mb4 */ ;;
/*!50003 SET character_set_results = utf8mb4 */ ;;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `log_enrollment_counts` ON SCHEDULE EVERY 10 SECOND STARTS '2025-04-03 08:48:04' ENDS '2025-04-03 08:49:04' ON COMPLETION PRESERVE DISABLE DO INSERT INTO enrollment_logs (log_time, total_enrollments)
SELECT NOW(), COUNT(*) FROM enrollments */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
DELIMITER ;
/*!50106 SET TIME_ZONE= @save_time_zone */ ;

--
-- Dumping routines for database 'enrollment'
--
/*!50003 DROP FUNCTION IF EXISTS `CountStudentsInCourse` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `CountStudentsInCourse`(p_course_id INT) RETURNS int
    DETERMINISTIC
BEGIN
    DECLARE student_count INT;
    SELECT COUNT(*) INTO student_count FROM enrollments WHERE course_id = p_course_id;
    RETURN student_count;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `GetInstructorName` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetInstructorName`(p_instructor_id INT) RETURNS varchar(100) CHARSET utf8mb4
    DETERMINISTIC
BEGIN
    DECLARE instructor_name VARCHAR(100);

    SELECT CONCAT(instructor_fname, ' ', instructor_lname) 
    INTO instructor_name 
    FROM instructors 
    WHERE instructor_id = p_instructor_id;
    RETURN instructor_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `GetOutstandingBalance` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetOutstandingBalance`(p_student_id INT) RETURNS double
    DETERMINISTIC
BEGIN
    DECLARE balance DOUBLE DEFAULT 0;
    DECLARE total_fee DOUBLE DEFAULT 0;
    DECLARE total_paid DOUBLE DEFAULT 0;

    SELECT SUM(tf.amount)
    INTO total_fee
    FROM tuition_fees tf
    JOIN enrollments e ON tf.course_id = e.course_id
    WHERE e.student_id = p_student_id;

    SELECT SUM(p.amount_paid)
    INTO total_paid
    FROM payments p
    WHERE p.student_id = p_student_id;

    SET balance = IFNULL(total_fee, 0) - IFNULL(total_paid, 0);

    RETURN balance;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `GetStudentStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetStudentStatus`(p_student_id INT) RETURNS char(10) CHARSET utf8mb4
    DETERMINISTIC
BEGIN
    DECLARE student_status CHAR(10);
    DECLARE gpa DOUBLE;

    SELECT AVG(g.grade) 
    INTO gpa 
    FROM grades g
    JOIN enrollments e ON g.enrollment_id = e.enrollment_id
    WHERE e.student_id = p_student_id;

    IF gpa <= 1.5 THEN
        SET student_status = 'Honor';
    ELSEIF gpa <= 3 THEN
        SET student_status = 'Regular';
    ELSE
        SET student_status = 'Probation';
    END IF;

    RETURN student_status;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `GetTotalTuition` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetTotalTuition`(p_student_id INT) RETURNS double
    DETERMINISTIC
BEGIN
    DECLARE total_fee DOUBLE DEFAULT 0;

    SELECT SUM(tf.amount) 
    INTO total_fee 
    FROM tuition_fees tf
    JOIN enrollments e ON tf.course_id = e.course_id
    WHERE e.student_id = p_student_id;

    RETURN IFNULL(total_fee, 0);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `TotalCourses` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `TotalCourses`() RETURNS int
    DETERMINISTIC
BEGIN
    DECLARE total INT;
    SELECT COUNT(*) INTO total FROM courses;
    RETURN total;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `TotalEnrollments` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `TotalEnrollments`() RETURNS int
    DETERMINISTIC
BEGIN
    DECLARE total INT;
    SELECT COUNT(*) INTO total FROM enrollments;
    RETURN total;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `TotalInstructors` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `TotalInstructors`() RETURNS int
    DETERMINISTIC
BEGIN
    DECLARE total INT;
    SELECT COUNT(*) INTO total FROM instructors;
    RETURN total;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `TotalStudents` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `TotalStudents`() RETURNS int
    DETERMINISTIC
BEGIN
    DECLARE total INT;
    SELECT COUNT(*) INTO total FROM students;
    RETURN total;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetCourseDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCourseDetails`()
BEGIN
    SELECT course_id, course_name, department_id
    FROM enrollment.courses
    WHERE deleted_at IS NULL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetInstructorDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetInstructorDetails`(p_instructor_id INT)
BEGIN
    SELECT 
        i.instructor_id, 
        GetInstructorName(i.instructor_id) AS instructor_name
    FROM instructors i
    WHERE i.instructor_id = p_instructor_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetStudentEnrollments` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetStudentEnrollments`()
BEGIN
    SELECT 
        s.student_id, 
        CONCAT(s.student_fname, ' ', s.student_lname) AS full_name, 
        c.course_name, 
        e.enrollment_date
    FROM enrollment.students s
    JOIN enrollment.enrollments e ON s.student_id = e.student_id
    JOIN enrollment.courses c ON e.course_id = c.course_id
    ORDER BY e.enrollment_date DESC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetStudentFinancialInfo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetStudentFinancialInfo`(p_student_id INT)
BEGIN
    SELECT 
        s.student_id, 
        CONCAT(s.student_fname, ' ', s.student_lname) AS student_name, 
        GetOutstandingBalance(s.student_id) AS balance, 
        GetStudentStatus(s.student_id) AS status
    FROM students s 
    WHERE s.student_id = p_student_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ReassignCourses` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ReassignCourses`(IN old_dept_id INT, IN new_dept_id INT)
BEGIN
    DECLARE course_count INT;
    
    SELECT COUNT(*) INTO course_count FROM enrollment.courses WHERE department_id = old_dept_id;
    
    IF course_count = 0 THEN
        SELECT 'No courses found in the specified old department' AS Message;
    ELSE
        UPDATE enrollment.courses 
        SET department_id = new_dept_id 
        WHERE department_id = old_dept_id;

        SELECT ROW_COUNT() AS Courses_Reassigned;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UppercaseCourseNames` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UppercaseCourseNames`()
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE course_id_value INT;
    DECLARE course_name_value VARCHAR(100);
    
    DECLARE cur CURSOR FOR 
    SELECT course_id, course_name FROM enrollment.courses;
    
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    OPEN cur;
    
    read_loop: LOOP
        FETCH cur INTO course_id_value, course_name_value;
        
        IF done THEN
            LEAVE read_loop;
        END IF;
        
        UPDATE enrollment.courses 
        SET course_name = UPPER(course_name_value) 
        WHERE course_id = course_id_value;
    END LOOP;

    CLOSE cur;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `view_combined_students_instructors`
--

/*!50001 DROP VIEW IF EXISTS `view_combined_students_instructors`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_combined_students_instructors` AS select concat(`students`.`student_fname`,' ',`students`.`student_lname`) AS `name`,'Student' AS `role` from `students` union select concat(`instructors`.`instructor_fname`,' ',`instructors`.`instructor_lname`) AS `name`,'Instructor' AS `role` from `instructors` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_instructor_departments`
--

/*!50001 DROP VIEW IF EXISTS `view_instructor_departments`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_instructor_departments` AS select `instructors`.`instructor_id` AS `instructor_id`,concat(`instructors`.`instructor_fname`,' ',`instructors`.`instructor_lname`) AS `instructor_name`,`instructors`.`email` AS `email`,`instructors`.`phone` AS `phone`,`instructors`.`department_id` AS `department_id` from `instructors` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_student_contacts`
--

/*!50001 DROP VIEW IF EXISTS `view_student_contacts`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_student_contacts` AS select `students`.`student_id` AS `student_id`,concat(`students`.`student_fname`,' ',`students`.`student_lname`) AS `full_name`,`students`.`email` AS `email` from `students` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_student_courses`
--

/*!50001 DROP VIEW IF EXISTS `view_student_courses`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_student_courses` AS select concat(`s`.`student_fname`,' ',`s`.`student_lname`) AS `full_name`,`c`.`course_name` AS `course_name`,count(0) AS `total_enrollments` from ((`enrollments` `e` join `students` `s` on((`e`.`student_id` = `s`.`student_id`))) join `courses` `c` on((`e`.`course_id` = `c`.`course_id`))) group by `s`.`student_id`,`c`.`course_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_student_tuition`
--

/*!50001 DROP VIEW IF EXISTS `view_student_tuition`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_student_tuition` AS select `s`.`student_id` AS `student_id`,`s`.`student_lname` AS `student_lname`,`GetTotalTuition`(`s`.`student_id`) AS `total_fee` from `students` `s` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_total_students_per_course`
--

/*!50001 DROP VIEW IF EXISTS `view_total_students_per_course`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_total_students_per_course` AS select `c`.`course_name` AS `course_name`,count(`e`.`student_id`) AS `total_students` from (`courses` `c` left join `enrollments` `e` on((`c`.`course_id` = `e`.`course_id`))) group by `c`.`course_id`,`c`.`course_name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-09 23:59:56
