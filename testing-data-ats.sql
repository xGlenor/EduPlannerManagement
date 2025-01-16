-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Generation Time: Sty 16, 2025 at 11:44 AM
-- Wersja serwera: 11.2.2-MariaDB-1:11.2.2+maria~ubu2204
-- Wersja PHP: 8.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ats`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `admins`
--

CREATE TABLE `admins` (
  `idUser` int(11) UNSIGNED NOT NULL,
  `sName` varchar(40) DEFAULT '',
  `sSurname` varchar(40) NOT NULL DEFAULT '',
  `sMail` varchar(40) NOT NULL DEFAULT '',
  `Phone` int(11) DEFAULT NULL,
  `idOwner` int(11) UNSIGNED NOT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `availability`
--

CREATE TABLE `availability` (
  `id_cond` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `start_time` smallint(6) UNSIGNED DEFAULT NULL,
  `stop_time` smallint(6) UNSIGNED DEFAULT NULL,
  `idWeekDef` smallint(6) UNSIGNED DEFAULT 0,
  `idWeek` smallint(6) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `avail_gr`
--

CREATE TABLE `avail_gr` (
  `id_group` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `start_time` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `stop_time` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `idWeekDef` smallint(6) UNSIGNED DEFAULT 0,
  `idWeek` smallint(6) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `avail_room`
--

CREATE TABLE `avail_room` (
  `id_room` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `start_time` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `stop_time` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `idWeekDef` smallint(6) UNSIGNED DEFAULT 0,
  `idWeek` smallint(6) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `colors`
--

CREATE TABLE `colors` (
  `idColor` int(11) DEFAULT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `color` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `colors`
--

INSERT INTO `colors` (`idColor`, `name`, `color`) VALUES
(1, 'lab', 16167036),
(2, 'wyk', 9303931),
(3, 'ćw', 13760889),
(4, 'proj', 14517231),
(5, '', 5566712),
(6, 'c', 13158655),
(7, 'g', 16763080),
(8, 'r', 13158600),
(9, 'backtt', 11599871),
(10, 'gs', 4455849),
(11, 'ua', 5066239),
(12, 'ud', 8781823),
(13, 'up', 9869055),
(14, 'rowerror', 13421823),
(15, 'cellerror', 8421631),
(16, 'fixedcellbkgnd', 13820385),
(17, 'fixedcelltext', 0),
(18, 'nonfixedcelltext', 0),
(19, 'gridlinecolor', 13158600),
(20, 's', 4455849),
(21, 'badweek', 13893033),
(22, 'Konsultacja', 5566712),
(23, 'Praca własna', 5566712),
(24, 'TestRooms', 14469375),
(25, 'TestGroup', 14469375);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `conductors`
--

CREATE TABLE `conductors` (
  `id` int(11) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `surname` varchar(255) NOT NULL DEFAULT '',
  `shortcut` varchar(255) DEFAULT NULL,
  `title` varchar(255) NOT NULL DEFAULT '',
  `room` varchar(255) NOT NULL DEFAULT '',
  `mail` varchar(255) NOT NULL DEFAULT '',
  `phone` varchar(255) NOT NULL DEFAULT '',
  `id_cond_tree` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `maxdays` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `owner` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `blockade` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `last_change` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `comment` text NOT NULL,
  `comment2` text NOT NULL,
  `cost` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `continuous` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `breaks` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `balanced` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `color` int(8) UNSIGNED NOT NULL DEFAULT 0,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `conductors`
--

INSERT INTO `conductors` (`id`, `name`, `surname`, `shortcut`, `title`, `room`, `mail`, `phone`, `id_cond_tree`, `maxdays`, `owner`, `blockade`, `last_change`, `comment`, `comment2`, `cost`, `continuous`, `breaks`, `balanced`, `color`, `sHash`, `dtLastModified`, `bIsDeleted`) VALUES
(12, 'Katarzyna', 'Wiśniewska', 'KWI', 'dr', 'B108', 'katarzyna.wisniewska@uczelnia.edu', '+48 123 456 771', 0, 0, 1, 0, 1, 'test1', 'test2', 0, 0, 0, 0, 14204888, '20241223183032admin12', '2025-01-10 19:32:03', 0),
(13, 'Tomasz', 'Malinowski', 'TMA', 'prof. dr hab.', 'L412', 'tomasz.malinowski@uczelnia.edu', '+48 123 456 732', 60, 0, 1, 0, 1, '', '', 0, 0, 0, 0, 0, '20241223183034admin13', '2025-01-15 12:22:21', 0),
(17, 'Anna', 'Kowalska', 'AKO', 'dr hab.', 'A215', 'anna.kowalska@uczelnia.edu', '+48 123 456 789', 60, 0, 1, 0, 1, '', '', 0, 0, 0, 0, 16711680, '20241223183424admin17', '2025-01-15 12:22:21', 0),
(19, 'Jan', 'Nowak', 'JNO', 'prof.', 'L317', 'jan.nowak@uczelnia.edu', '+48 123 456 770', 0, 0, 1, 0, 1, '', '', 0, 0, 0, 0, 205, '20241223183426admin19', '2024-12-23 18:37:20', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `cond_tree`
--

CREATE TABLE `cond_tree` (
  `id_cond_tree` int(11) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `parent` int(11) UNSIGNED DEFAULT 0,
  `owner` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `blockade` smallint(3) UNSIGNED NOT NULL DEFAULT 0,
  `last_change` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `iTimeRangeStart` smallint(6) UNSIGNED NOT NULL DEFAULT 0,
  `iTimeRangeStop` smallint(6) UNSIGNED NOT NULL DEFAULT 0,
  `bTimeRangeActive` smallint(3) UNSIGNED NOT NULL DEFAULT 0,
  `bShowPlan` smallint(3) UNSIGNED NOT NULL DEFAULT 0,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `cond_tree`
--

INSERT INTO `cond_tree` (`id_cond_tree`, `name`, `parent`, `owner`, `blockade`, `last_change`, `iTimeRangeStart`, `iTimeRangeStop`, `bTimeRangeActive`, `bShowPlan`, `sHash`, `dtLastModified`, `bIsDeleted`) VALUES
(60, 'Wydział A', 0, 1, 0, 1, 33, 660, 0, 0, '20250115122207admin60', '2025-01-15 12:22:14', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `coursecourse`
--

CREATE TABLE `coursecourse` (
  `idCourseParent` int(10) UNSIGNED DEFAULT NULL,
  `idCourseChild` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `courses`
--

CREATE TABLE `courses` (
  `id` int(11) UNSIGNED NOT NULL,
  `name` varchar(255) DEFAULT '',
  `shortcut` varchar(255) DEFAULT '',
  `type` varchar(255) DEFAULT '',
  `iPossCond` tinyint(4) DEFAULT 1,
  `iPossRoom` tinyint(4) DEFAULT 1,
  `iNumberOfHours` tinyint(4) DEFAULT 0,
  `startfix` enum('1','0') DEFAULT '0',
  `owner` int(11) UNSIGNED DEFAULT 0,
  `blockade` smallint(3) UNSIGNED DEFAULT 0,
  `last_change` int(11) UNSIGNED DEFAULT 0,
  `comment` text DEFAULT NULL,
  `url` varchar(255) DEFAULT '',
  `cost` tinyint(3) UNSIGNED DEFAULT 0,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`id`, `name`, `shortcut`, `type`, `iPossCond`, `iPossRoom`, `iNumberOfHours`, `startfix`, `owner`, `blockade`, `last_change`, `comment`, `url`, `cost`, `sHash`, `dtLastModified`, `bIsDeleted`) VALUES
(42, 'Bezpieczeństwo pracy i ergonomia', 'Bpie', 'wyk', 0, 0, 0, '0', 1, 1, 1, '', '', 0, '20241223190721admin42', '2025-01-14 11:05:49', 0),
(43, 'Algebra liniowa z geometrią analityczną', 'Alzga', 'ćw', 0, 0, 0, '0', 1, 1, 1, '', '', 0, '20241223191247admin43', '2025-01-14 11:07:03', 0),
(51, 'Systemy monitorowania i sterowania', 'Smis', 'lab', 0, 0, 0, '0', 1, 1, 1, '', '', 0, '20250111024121admin51', '2025-01-11 05:02:44', 0),
(52, 'Systemy monitorowania i sterowania', 'Smis', 'lab', 0, 0, 0, '0', 1, 1, 1, '', '', 0, '20250111025050admin52', '2025-01-11 05:02:44', 0),
(55, 'test123', 'tes', 'ćw', 0, 0, 0, '0', 1, 0, 1, '', '', 0, '20250111031321admin55', '2025-01-14 05:22:41', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `coursetypes`
--

CREATE TABLE `coursetypes` (
  `idCoursetype` int(11) DEFAULT NULL,
  `type` varchar(255) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `coursetypes`
--

INSERT INTO `coursetypes` (`idCoursetype`, `type`) VALUES
(1, 'lab'),
(2, 'ćw'),
(3, 'proj'),
(4, 'wyk');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `days`
--

CREATE TABLE `days` (
  `id` smallint(6) NOT NULL,
  `name` varchar(255) NOT NULL,
  `sRate` varchar(255) DEFAULT '''0'''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `days`
--

INSERT INTO `days` (`id`, `name`, `sRate`) VALUES
(1, 'Poniedziałek', '1.0'),
(2, 'Wtorek', '1.0'),
(3, 'Środa', '1.0'),
(4, 'Czwartek', '1.0'),
(5, 'Piątek', '1.0'),
(6, 'Sobota', '1'),
(7, 'Niedziela', '1');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `description`
--

CREATE TABLE `description` (
  `name` varchar(255) NOT NULL DEFAULT '',
  `year` varchar(255) NOT NULL DEFAULT '',
  `semes` varchar(255) NOT NULL DEFAULT '',
  `nr_timeslots` int(11) NOT NULL DEFAULT 0,
  `start_time` time NOT NULL DEFAULT '00:00:00',
  `stop_time` time NOT NULL DEFAULT '00:00:00',
  `group_slots` smallint(6) NOT NULL DEFAULT 0,
  `spec_times` char(1) NOT NULL DEFAULT 'N',
  `hourcorrect` tinyint(3) DEFAULT NULL,
  `localidcounter` int(11) NOT NULL DEFAULT 0,
  `plan_version` varchar(255) NOT NULL,
  `counter` int(11) NOT NULL DEFAULT 0,
  `default_weekdef` int(11) NOT NULL,
  `dtExportAll` datetime NOT NULL,
  `dtConservation` datetime DEFAULT NULL,
  `sEncoding` varchar(20) NOT NULL DEFAULT 'iso-8859-2'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `description`
--

INSERT INTO `description` (`name`, `year`, `semes`, `nr_timeslots`, `start_time`, `stop_time`, `group_slots`, `spec_times`, `hourcorrect`, `localidcounter`, `plan_version`, `counter`, `default_weekdef`, `dtExportAll`, `dtConservation`, `sEncoding`) VALUES
('INFORMATYKA', '2024', '1', 52, '08:00:00', '21:00:00', 4, 'N', 0, 62, '5.0.015', 0, 1, '2025-01-15 22:26:38', NULL, 'utf-8');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `electivecourses`
--

CREATE TABLE `electivecourses` (
  `idCourse` int(11) UNSIGNED NOT NULL,
  `idStudent` int(11) UNSIGNED NOT NULL,
  `bSelected` tinyint(4) NOT NULL DEFAULT 0,
  `dtLastChange` datetime NOT NULL,
  `bBlockade` tinyint(4) NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `electivesubjectload`
--

CREATE TABLE `electivesubjectload` (
  `idSubjectLoad` int(11) UNSIGNED NOT NULL,
  `idStudent` int(11) UNSIGNED NOT NULL,
  `bSelected` tinyint(4) NOT NULL DEFAULT 0,
  `dtLastChange` datetime NOT NULL,
  `bBlockade` tinyint(4) NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `features`
--

CREATE TABLE `features` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `feature` varchar(255) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `features`
--

INSERT INTO `features` (`id`, `feature`) VALUES
(1, 'Występowanie: Parzyste');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `features_conds`
--

CREATE TABLE `features_conds` (
  `id` int(11) UNSIGNED DEFAULT NULL,
  `id_feature` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `features_courses`
--

CREATE TABLE `features_courses` (
  `id` int(11) UNSIGNED DEFAULT NULL,
  `id_feature` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `features_groups`
--

CREATE TABLE `features_groups` (
  `id` int(11) UNSIGNED DEFAULT NULL,
  `id_feature` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `features_rooms`
--

CREATE TABLE `features_rooms` (
  `id` int(11) UNSIGNED DEFAULT NULL,
  `id_feature` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `func`
--

CREATE TABLE `func` (
  `name` char(64) NOT NULL DEFAULT '',
  `ret` tinyint(1) NOT NULL DEFAULT 0,
  `dl` char(128) NOT NULL DEFAULT '',
  `type` enum('function','aggregate') NOT NULL DEFAULT 'function',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `groups`
--

CREATE TABLE `groups` (
  `id` int(11) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `id_group_tree` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `semester` tinyint(11) NOT NULL DEFAULT 0,
  `shortcut` varchar(255) NOT NULL DEFAULT '',
  `nr_stud` smallint(6) NOT NULL DEFAULT 0,
  `owner` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `blockade` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `last_change` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `comment` text NOT NULL,
  `cost` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `continuous` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `breaks` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `maxdays` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `balanced` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `color` int(8) UNSIGNED NOT NULL DEFAULT 0,
  `type` varchar(255) NOT NULL,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`id`, `name`, `id_group_tree`, `semester`, `shortcut`, `nr_stud`, `owner`, `blockade`, `last_change`, `comment`, `cost`, `continuous`, `breaks`, `maxdays`, `balanced`, `color`, `type`, `sHash`, `dtLastModified`, `bIsDeleted`) VALUES
(21, '', 34, 1, 'Inf/S/Ist/1sem/1gr/a', 15, 1, 0, 1, '', 0, 0, 0, 0, 0, 14204888, '', '20241223185637admin21', '2025-01-10 19:27:27', 0),
(22, '', 34, 1, 'Inf/S/Ist/1sem/1gr/b', 15, 1, 0, 1, '', 0, 0, 0, 0, 0, 0, '', '20241223185637admin22', '2025-01-10 19:27:27', 0),
(23, '', 35, 1, 'Inf/S/Ist/1sem/2gr/a', 15, 1, 0, 1, '', 0, 0, 0, 0, 0, 16711680, '', '20241223185637admin23', '2025-01-08 19:33:39', 0),
(24, '', 35, 1, 'Inf/S/Ist/1sem/2gr/b', 15, 1, 0, 1, '', 0, 0, 0, 0, 0, 205, '', '20241223185637admin24', '2025-01-08 19:33:39', 0),
(25, '', 40, 7, 'Inf/S/Ist/7sem/1gr/a/IO', 30, 1, 0, 1, '', 0, 0, 0, 0, 0, 25600, '', '20241223185637admin25', '2024-12-23 19:06:25', 0),
(30, '', 40, 7, 'Inf/S/Ist/7sem/1gr/b/IO', 30, 1, 0, 1, '', 0, 0, 0, 0, 0, 65535, '', '20241223185853admin30', '2024-12-23 19:06:57', 0),
(31, '', 41, 7, 'Inf/S/Ist/7sem/2gr/a/IO', 30, 1, 0, 1, '', 0, 0, 0, 0, 0, 10824234, '', '20241223185855admin31', '2024-12-23 19:06:52', 0),
(56, '', 0, 1, 'Nowa grupa', 30, 1, 0, 1, '', 0, 0, 0, 0, 0, 8190976, '', '20250111035802admin56', '2025-01-11 03:58:02', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `group_tree`
--

CREATE TABLE `group_tree` (
  `id_group_tree` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `name` varchar(255) NOT NULL DEFAULT '',
  `parent` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `owner` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `blockade` smallint(3) UNSIGNED NOT NULL DEFAULT 0,
  `last_change` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `iTimeRangeStart` smallint(6) UNSIGNED NOT NULL DEFAULT 0,
  `iTimeRangeStop` smallint(6) UNSIGNED NOT NULL DEFAULT 0,
  `bTimeRangeActive` smallint(3) UNSIGNED NOT NULL DEFAULT 0,
  `bShowPlan` smallint(3) UNSIGNED NOT NULL DEFAULT 0,
  `idStudyPlan` int(11) NOT NULL DEFAULT 0,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `group_tree`
--

INSERT INTO `group_tree` (`id_group_tree`, `name`, `parent`, `owner`, `blockade`, `last_change`, `iTimeRangeStart`, `iTimeRangeStop`, `bTimeRangeActive`, `bShowPlan`, `idStudyPlan`, `sHash`, `dtLastModified`, `bIsDeleted`) VALUES
(26, 'Wydział Budowy Maszyn I Informatyki', 0, 1, 0, 1, 33, 660, 0, 0, 0, '20241223185702admin26', '2025-01-10 23:46:56', 0),
(27, 'Stacjonarne', 26, 1, 0, 1, 33, 660, 0, 0, 0, '20241223185728admin27', '2025-01-10 23:46:56', 0),
(28, 'Informatyka', 27, 1, 0, 1, 33, 660, 0, 0, 0, '20241223185740admin28', '2025-01-10 23:46:56', 0),
(29, 'Inf/S/ I stopień', 28, 1, 0, 1, 33, 660, 0, 0, 0, '20241223185754admin29', '2025-01-10 23:46:56', 0),
(34, 'Inf/S/Ist/1sem/1gr', 36, 1, 0, 1, 33, 660, 0, 1, 0, '20241223190256admin34', '2025-01-14 05:22:14', 0),
(35, 'Inf/S/Ist/1sem/2gr', 36, 1, 0, 1, 33, 660, 0, 1, 0, '20241223190337admin35', '2025-01-14 01:54:24', 0),
(36, 'Inf/S/Ist/1sem', 29, 1, 0, 1, 33, 660, 0, 0, 0, '20241223190354admin36', '2025-01-10 23:46:56', 0),
(37, 'Inf/S/Ist/7sem', 29, 1, 0, 1, 33, 660, 0, 0, 0, '20241223190412admin37', '2025-01-10 23:46:56', 0),
(39, 'Inf/S/Ist/7sem/IO', 37, 1, 0, 1, 33, 660, 0, 0, 0, '20241223190435admin39', '2025-01-10 23:46:56', 0),
(40, 'Inf/S/Ist/7sem/1gr/IO', 39, 1, 0, 1, 33, 660, 0, 1, 0, '20241223190530admin40', '2025-01-14 02:54:40', 0),
(41, 'Inf/S/Ist/7sem/2gr/IO', 39, 1, 0, 1, 513, 660, 0, 1, 0, '20241223190538admin41', '2025-01-14 05:22:23', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `holidays`
--

CREATE TABLE `holidays` (
  `idHoliday` int(11) UNSIGNED NOT NULL,
  `sName` varchar(40) DEFAULT '',
  `sDescript` varchar(80) DEFAULT '',
  `idWeek` int(11) UNSIGNED DEFAULT 0,
  `iDay` smallint(3) DEFAULT 0,
  `iStart` int(11) DEFAULT 0,
  `iDur` int(11) DEFAULT 0,
  `idGroupTree` int(11) UNSIGNED DEFAULT 0,
  `idCondTree` int(11) UNSIGNED DEFAULT 0,
  `idRoomTree` int(11) UNSIGNED DEFAULT 0,
  `idOwner` int(11) UNSIGNED DEFAULT 0,
  `idLastChange` int(11) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `mainpage`
--

CREATE TABLE `mainpage` (
  `id` smallint(6) UNSIGNED NOT NULL,
  `sTag` varchar(128) NOT NULL,
  `sHtml` text NOT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `mainpage`
--

INSERT INTO `mainpage` (`id`, `sTag`, `sHtml`, `dtLastModified`, `bIsDeleted`) VALUES
(1, 'mainpage', '<table width=\"100%\" border=\"0\" cellpadding=\"20\" cellspacing=\"0\"><tr><td>{title}<p><strong>Witamy na Portalu ATS4.</br>{search}</strong></p>{login} </td> </tr></table>', NULL, 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `orders`
--

CREATE TABLE `orders` (
  `id` int(11) UNSIGNED NOT NULL,
  `idCourse` int(11) UNSIGNED NOT NULL,
  `idWeekDef` int(11) UNSIGNED NOT NULL,
  `dtSend` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `idSender` int(11) UNSIGNED NOT NULL,
  `idCondTree` int(11) UNSIGNED NOT NULL,
  `sComment` varchar(511) NOT NULL,
  `bConfirmed` int(3) NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `order_recipient`
--

CREATE TABLE `order_recipient` (
  `idOrderRecipient` int(11) UNSIGNED NOT NULL,
  `sDescript` varchar(255) DEFAULT NULL,
  `sMail` varchar(255) DEFAULT NULL,
  `idSOTS` int(11) UNSIGNED NOT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `poss_conds`
--

CREATE TABLE `poss_conds` (
  `idCourse` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `idCond` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `poss_rooms`
--

CREATE TABLE `poss_rooms` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `id_room` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `poss_starts`
--

CREATE TABLE `poss_starts` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `start` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `stop` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `idWeekDef` smallint(6) UNSIGNED DEFAULT 0,
  `idWeek` smallint(6) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `resers`
--

CREATE TABLE `resers` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `idReserType` int(11) UNSIGNED DEFAULT 0,
  `type` varchar(255) DEFAULT '',
  `descript` varchar(255) DEFAULT '',
  `active` smallint(3) UNSIGNED DEFAULT 0,
  `blockade` smallint(3) UNSIGNED DEFAULT 0,
  `last_change` int(11) UNSIGNED DEFAULT 0,
  `owner` int(11) UNSIGNED DEFAULT 0,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `resers`
--

INSERT INTO `resers` (`id`, `idReserType`, `type`, `descript`, `active`, `blockade`, `last_change`, `owner`, `sHash`, `dtLastModified`, `bIsDeleted`) VALUES
(58, 1, 'wyk', 'TEST', 1, 0, 1, 1, '20250114081550admin58', '2025-01-14 08:16:24', 0),
(61, 5, 'lab', 'Nowa rezerwacja', 1, 0, 1, 1, '20250115222115admin61', '2025-01-15 22:38:34', 0),
(62, 3, '', 'Nowa rezerwacja 1', 1, 0, 1, 1, '20250115223756admin62', '2025-01-15 22:39:01', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `reser_cond`
--

CREATE TABLE `reser_cond` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `id_cond` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `reser_cond`
--

INSERT INTO `reser_cond` (`id`, `id_cond`, `dtLastModified`, `bIsDeleted`) VALUES
(58, 17, '2025-01-14 08:16:04', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `reser_group`
--

CREATE TABLE `reser_group` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `id_group` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `reser_group`
--

INSERT INTO `reser_group` (`id`, `id_group`, `dtLastModified`, `bIsDeleted`) VALUES
(61, 21, '2025-01-15 22:38:34', 0),
(61, 22, '2025-01-15 22:38:34', 0),
(62, 21, '2025-01-15 22:38:38', 0),
(62, 22, '2025-01-15 22:38:38', 0),
(62, 23, '2025-01-15 22:38:38', 0),
(62, 24, '2025-01-15 22:38:38', 0),
(62, 25, '2025-01-15 22:38:38', 0),
(62, 30, '2025-01-15 22:38:38', 0),
(62, 31, '2025-01-15 22:38:38', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `reser_room`
--

CREATE TABLE `reser_room` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `id_room` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `reser_student`
--

CREATE TABLE `reser_student` (
  `id` int(11) UNSIGNED DEFAULT NULL,
  `id_student` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `reser_type`
--

CREATE TABLE `reser_type` (
  `idReserType` int(11) UNSIGNED NOT NULL,
  `sDescript` varchar(255) NOT NULL,
  `bBlockResource` tinyint(4) DEFAULT NULL,
  `bShowCondRoom` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `reser_type`
--

INSERT INTO `reser_type` (`idReserType`, `sDescript`, `bBlockResource`, `bShowCondRoom`) VALUES
(1, 'Konsultacja', 4, 0),
(2, 'Praca własna', 4, 0),
(3, '', 13, 0),
(4, 'TestRooms', 8, 0),
(5, 'TestGroup', 5, 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rights`
--

CREATE TABLE `rights` (
  `idUser` int(11) UNSIGNED NOT NULL,
  `idResource` int(11) UNSIGNED NOT NULL,
  `bRights` tinyint(4) UNSIGNED DEFAULT NULL,
  `iType` tinyint(4) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `rights`
--

INSERT INTO `rights` (`idUser`, `idResource`, `bRights`, `iType`, `dtLastModified`, `bIsDeleted`) VALUES
(1, 0, 0, 1, '2025-01-15 22:26:38', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rooms`
--

CREATE TABLE `rooms` (
  `id` int(11) UNSIGNED NOT NULL,
  `id_room_tree` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `nr_room` varchar(255) NOT NULL DEFAULT '',
  `capacity` smallint(6) NOT NULL DEFAULT 0,
  `owner` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `blockade` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `last_change` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `comment` text NOT NULL,
  `cost` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `continuous` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `breaks` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `maxdays` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `balanced` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `color` int(8) UNSIGNED NOT NULL DEFAULT 0,
  `type` varchar(255) NOT NULL,
  `capacity_lab` smallint(6) NOT NULL,
  `idUserResp` int(11) UNSIGNED NOT NULL,
  `charge` int(11) NOT NULL,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`id`, `id_room_tree`, `nr_room`, `capacity`, `owner`, `blockade`, `last_change`, `comment`, `cost`, `continuous`, `breaks`, `maxdays`, `balanced`, `color`, `type`, `capacity_lab`, `idUserResp`, `charge`, `sHash`, `dtLastModified`, `bIsDeleted`) VALUES
(2, 7, 'B203', 40, 1, 0, 1, '', 0, 0, 0, 0, 0, 967423, 'Laboratorium', 20, 0, 0, '20241223182331admin2', '2024-12-23 18:39:44', 0),
(3, 7, 'B310', 30, 1, 0, 1, '', 0, 0, 0, 0, 0, 967423, 'Laboratorium', 25, 0, 0, '20241223182331admin3', '2024-12-23 18:39:44', 0),
(4, 6, 'A140', 30, 1, 0, 1, '', 0, 0, 0, 0, 0, 967423, 'Laboratorium', 0, 0, 0, '20241223182331admin4', '2024-12-23 18:39:44', 0),
(5, 8, 'L120', 120, 1, 0, 1, '', 0, 0, 0, 0, 0, 982798, 'Ćwiczenia', 1, 0, 0, '20241223182331admin5', '2024-12-23 18:39:44', 0),
(45, 8, 'L128', 150, 1, 0, 1, '', 0, 0, 0, 0, 0, 16711680, 'Wykład', 1, 0, 0, '20241223192830admin45', '2025-01-08 19:33:39', 0),
(57, 7, 'C131', 20, 1, 0, 1, '', 0, 0, 0, 0, 0, 0, 'Laboratorium', 1, 0, 0, '20250114080551admin57', '2025-01-14 08:06:30', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `room_tree`
--

CREATE TABLE `room_tree` (
  `id_room_tree` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `name` varchar(255) NOT NULL DEFAULT '',
  `parent` int(11) UNSIGNED DEFAULT 0,
  `owner` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `blockade` smallint(3) NOT NULL DEFAULT 0,
  `last_change` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `iTimeRangeStart` smallint(6) UNSIGNED NOT NULL DEFAULT 0,
  `iTimeRangeStop` smallint(6) UNSIGNED NOT NULL DEFAULT 0,
  `bTimeRangeActive` smallint(3) UNSIGNED NOT NULL DEFAULT 0,
  `bShowPlan` smallint(3) UNSIGNED NOT NULL DEFAULT 0,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `room_tree`
--

INSERT INTO `room_tree` (`id_room_tree`, `name`, `parent`, `owner`, `blockade`, `last_change`, `iTimeRangeStart`, `iTimeRangeStop`, `bTimeRangeActive`, `bShowPlan`, `sHash`, `dtLastModified`, `bIsDeleted`) VALUES
(6, 'Budynek A', 0, 1, 0, 1, 33, 660, 0, 0, '20241223182821admin6', '2025-01-10 23:46:56', 0),
(7, 'Budynek B', 0, 1, 0, 1, 33, 660, 0, 0, '20241223182830admin7', '2025-01-10 23:46:56', 0),
(8, 'Budynek L', 0, 1, 0, 1, 33, 468, 1, 1, '20241223182838admin8', '2025-01-14 08:10:58', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `set_cond`
--

CREATE TABLE `set_cond` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `id_cond` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `nr_hours` int(11) NOT NULL DEFAULT 0,
  `remarks` varchar(255) NOT NULL DEFAULT '',
  `idRoom` int(11) NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `set_cond`
--

INSERT INTO `set_cond` (`id`, `id_cond`, `nr_hours`, `remarks`, `idRoom`, `dtLastModified`, `bIsDeleted`) VALUES
(42, 12, 0, '', 0, '1970-01-01 01:00:00', 0),
(42, 19, 0, '', 0, '1970-01-01 01:00:00', 0),
(42, 17, 0, '', 0, '1970-01-01 01:00:00', 0),
(42, 13, 0, '', 0, '1970-01-01 01:00:00', 0),
(43, 13, 0, '', 0, '1970-01-01 01:00:00', 0),
(51, 12, 0, '', 0, '1970-01-01 01:00:00', 0),
(52, 12, 0, '', 0, '1970-01-01 01:00:00', 0),
(55, 12, 0, '', 0, '1970-01-01 01:00:00', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `set_groups`
--

CREATE TABLE `set_groups` (
  `id` int(11) UNSIGNED DEFAULT NULL,
  `id_group` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `set_groups`
--

INSERT INTO `set_groups` (`id`, `id_group`, `dtLastModified`, `bIsDeleted`) VALUES
(42, 21, '2024-12-23 19:07:52', 0),
(42, 22, '2024-12-23 19:07:52', 0),
(42, 23, '2024-12-23 19:07:52', 0),
(42, 24, '2024-12-23 19:07:52', 0),
(43, 23, '2025-01-08 19:33:39', 0),
(43, 24, '2025-01-08 19:33:39', 0),
(43, 21, '2025-01-08 19:33:39', 0),
(43, 22, '2025-01-08 19:33:39', 0),
(51, 22, '2025-01-11 01:50:26', 0),
(52, 21, '2025-01-11 02:51:08', 0),
(55, 25, '2025-01-11 03:16:46', 0),
(55, 30, '2025-01-11 03:16:46', 0),
(55, 31, '2025-01-11 03:17:02', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `set_rooms`
--

CREATE TABLE `set_rooms` (
  `id` int(11) UNSIGNED DEFAULT NULL,
  `id_room` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `set_rooms`
--

INSERT INTO `set_rooms` (`id`, `id_room`, `dtLastModified`, `bIsDeleted`) VALUES
(42, 5, '2025-01-08 19:33:39', 0),
(43, 45, '2025-01-08 19:33:39', 0),
(51, 3, '2025-01-11 01:50:26', 0),
(52, 3, '2025-01-11 02:51:17', 0),
(55, 45, '2025-01-11 03:36:45', 0),
(55, 2, '2025-01-11 03:36:51', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `spec_times`
--

CREATE TABLE `spec_times` (
  `id` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `description` varchar(255) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `spec_times`
--

INSERT INTO `spec_times` (`id`, `description`) VALUES
(33, 'Lekcja 1'),
(34, 'Lekcja 2'),
(35, 'Lekcja 3'),
(36, 'Lekcja 4'),
(37, 'Lekcja 5'),
(38, 'Lekcja 6'),
(39, 'Lekcja 7'),
(40, 'Lekcja 8'),
(41, 'Lekcja 9'),
(42, 'Lekcja 10'),
(43, 'Lekcja 11'),
(44, 'Lekcja 12'),
(45, 'Lekcja 13'),
(46, 'Lekcja 14'),
(47, 'Lekcja 15'),
(48, 'Lekcja 16'),
(49, 'Lekcja 17'),
(50, 'Lekcja 18'),
(51, 'Lekcja 19'),
(52, 'Lekcja 20'),
(53, 'Lekcja 21'),
(54, 'Lekcja 22'),
(55, 'Lekcja 23'),
(56, 'Lekcja 24'),
(57, 'Lekcja 25'),
(58, 'Lekcja 26'),
(59, 'Lekcja 27'),
(60, 'Lekcja 28'),
(61, 'Lekcja 29'),
(62, 'Lekcja 30'),
(63, 'Lekcja 31'),
(64, 'Lekcja 32'),
(65, 'Lekcja 33'),
(66, 'Lekcja 34'),
(67, 'Lekcja 35'),
(68, 'Lekcja 36'),
(69, 'Lekcja 37'),
(70, 'Lekcja 38'),
(71, 'Lekcja 39'),
(72, 'Lekcja 40'),
(73, 'Lekcja 41'),
(74, 'Lekcja 42'),
(75, 'Lekcja 43'),
(76, 'Lekcja 44'),
(77, 'Lekcja 45'),
(78, 'Lekcja 46'),
(79, 'Lekcja 47'),
(80, 'Lekcja 48'),
(81, 'Lekcja 49'),
(82, 'Lekcja 50'),
(83, 'Lekcja 51'),
(84, 'Lekcja 52');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `stats`
--

CREATE TABLE `stats` (
  `idStats` int(11) UNSIGNED NOT NULL,
  `IP` varchar(25) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `studentcourse`
--

CREATE TABLE `studentcourse` (
  `idStudent` int(11) UNSIGNED DEFAULT NULL,
  `idCourse` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `studentgroup`
--

CREATE TABLE `studentgroup` (
  `idStudent` int(11) UNSIGNED DEFAULT NULL,
  `idGroup` int(11) UNSIGNED DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `students`
--

CREATE TABLE `students` (
  `idStudent` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `idSOTS` int(11) UNSIGNED DEFAULT 0,
  `idStudentTree` int(11) UNSIGNED DEFAULT 0,
  `sName` varchar(30) DEFAULT ' ',
  `sSurname` varchar(30) DEFAULT ' ',
  `sMail` varchar(50) DEFAULT ' ',
  `bBlockade` tinyint(4) DEFAULT 0,
  `idUserModified` int(11) UNSIGNED DEFAULT NULL,
  `idUserOwner` int(11) UNSIGNED DEFAULT NULL,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `student_tree`
--

CREATE TABLE `student_tree` (
  `idStudentTree` int(11) UNSIGNED NOT NULL,
  `sName` varchar(255) NOT NULL,
  `idParent` int(11) UNSIGNED NOT NULL,
  `idUserOwner` int(11) UNSIGNED NOT NULL,
  `bBlockadeType` tinyint(3) UNSIGNED NOT NULL,
  `idUserModified` int(11) UNSIGNED NOT NULL,
  `iTimeRangeStart` smallint(6) UNSIGNED NOT NULL,
  `iTimeRangeStop` smallint(6) UNSIGNED NOT NULL,
  `bTimeRangeActive` tinyint(3) UNSIGNED NOT NULL,
  `sHash` varchar(30) DEFAULT '',
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `studyplan`
--

CREATE TABLE `studyplan` (
  `idStudyPlan` int(11) UNSIGNED NOT NULL,
  `sName` varchar(50) DEFAULT NULL,
  `sSpecialization` varchar(50) DEFAULT NULL,
  `sSpecShortcut` varchar(20) DEFAULT NULL,
  `sStudyPlanType` varchar(100) DEFAULT NULL,
  `sTypeShortcut` varchar(20) DEFAULT NULL,
  `dtAproved` date DEFAULT NULL,
  `sDescription` text DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `studyplancondtree`
--

CREATE TABLE `studyplancondtree` (
  `idCondTree` int(11) UNSIGNED NOT NULL,
  `idStudyPlan` int(11) UNSIGNED NOT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `subject`
--

CREATE TABLE `subject` (
  `idSubject` int(11) UNSIGNED NOT NULL,
  `sName` varchar(50) DEFAULT NULL,
  `sFaculty` varchar(50) DEFAULT NULL,
  `sDescription` text DEFAULT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `subjectcondtree`
--

CREATE TABLE `subjectcondtree` (
  `idCondTree` int(11) UNSIGNED NOT NULL,
  `idSubject` int(11) UNSIGNED NOT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `subjectload`
--

CREATE TABLE `subjectload` (
  `idSubjectLoad` int(11) UNSIGNED NOT NULL,
  `iLecture` smallint(6) NOT NULL DEFAULT 0,
  `iExercise` smallint(6) NOT NULL DEFAULT 0,
  `iLaboratory` smallint(6) NOT NULL DEFAULT 0,
  `iProject` smallint(6) NOT NULL DEFAULT 0,
  `iSeminar` smallint(6) NOT NULL DEFAULT 0,
  `bExam` tinyint(4) NOT NULL DEFAULT 0,
  `iECTS` smallint(6) NOT NULL DEFAULT 0,
  `iSemester` smallint(6) NOT NULL,
  `idSubject` int(11) UNSIGNED NOT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `subjectloadcourse`
--

CREATE TABLE `subjectloadcourse` (
  `idSubjectLoad` int(11) UNSIGNED NOT NULL,
  `idCourse` int(11) UNSIGNED NOT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `subjectstudyplan`
--

CREATE TABLE `subjectstudyplan` (
  `idSubject` int(11) UNSIGNED NOT NULL,
  `idStudyPlan` int(11) UNSIGNED NOT NULL,
  `iNumber` smallint(4) UNSIGNED NOT NULL DEFAULT 9999,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `tables_last_modified`
--

CREATE TABLE `tables_last_modified` (
  `sTableName` varchar(25) NOT NULL,
  `dtLastModified` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `tables_last_modified`
--

INSERT INTO `tables_last_modified` (`sTableName`, `dtLastModified`) VALUES
('availability', '2025-01-15 22:26:38'),
('avail_gr', '2025-01-15 22:26:38'),
('avail_room', '2025-01-15 22:26:38'),
('colors', '2025-01-15 22:26:38'),
('conductors', '2025-01-15 22:26:38'),
('cond_tree', '2025-01-15 22:26:38'),
('coursecourse', '2025-01-15 22:26:38'),
('courses', '2025-01-15 22:26:38'),
('coursetypes', '2025-01-15 22:26:38'),
('days', '2025-01-15 22:26:38'),
('features', '2025-01-15 22:26:38'),
('features_conds', '2025-01-15 22:26:38'),
('features_courses', '2025-01-15 22:26:38'),
('features_groups', '2025-01-15 22:26:38'),
('features_rooms', '2025-01-15 22:26:38'),
('groups', '2025-01-15 22:26:38'),
('group_tree', '2025-01-15 22:26:38'),
('poss_conds', '2025-01-15 22:26:38'),
('poss_rooms', '2025-01-15 22:26:38'),
('poss_starts', '2025-01-15 22:26:38'),
('resers', '2025-01-15 22:26:38'),
('reser_cond', '2025-01-15 22:26:38'),
('reser_group', '2025-01-15 22:26:38'),
('reser_room', '2025-01-15 22:26:38'),
('reser_type', '2025-01-15 22:26:38'),
('rights', '2025-01-15 22:26:38'),
('rooms', '2025-01-15 22:26:38'),
('room_tree', '2025-01-15 22:26:38'),
('set_cond', '2025-01-15 22:26:38'),
('set_groups', '2025-01-15 22:26:38'),
('set_rooms', '2025-01-15 22:26:38'),
('spec_times', '2025-01-15 22:26:38'),
('studentcourse', '2025-01-15 22:26:38'),
('studentgroup', '2025-01-15 22:26:38'),
('students', '2025-01-15 22:26:38'),
('student_tree', '2025-01-15 22:26:38'),
('times', '2025-01-15 22:26:38'),
('titletypes', '2025-01-15 22:26:38'),
('undesirable', '2025-01-15 22:26:38'),
('undesir_gr', '2025-01-15 22:26:38'),
('undesir_room', '2025-01-15 22:26:38'),
('undesir_starts', '2025-01-15 22:26:38'),
('users', '2025-01-15 22:26:38'),
('weekdefs', '2025-01-15 22:26:38'),
('weeks', '2025-01-15 22:26:38'),
('weekweekdef', '2025-01-15 22:26:38');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `times`
--

CREATE TABLE `times` (
  `idEvent` int(11) UNSIGNED DEFAULT NULL,
  `start` int(11) DEFAULT 0,
  `dur` int(11) DEFAULT 0,
  `idWeek` int(11) UNSIGNED DEFAULT 0,
  `idWeekDef` int(11) UNSIGNED DEFAULT 0,
  `dtStart` time DEFAULT '00:00:00',
  `dtStop` time DEFAULT '00:00:00',
  `idRoom` int(11) NOT NULL DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `times`
--

INSERT INTO `times` (`idEvent`, `start`, `dur`, `idWeek`, `idWeekDef`, `dtStart`, `dtStop`, `idRoom`, `dtLastModified`, `bIsDeleted`) VALUES
(42, 47, 6, 0, 4, '00:00:00', '00:00:00', 0, '1970-01-01 01:00:00', 0),
(43, 136, 6, 0, 2, '00:00:00', '00:00:00', 0, '1970-01-01 01:00:00', 0),
(51, 142, 6, 0, 3, '00:00:00', '00:00:00', 0, '1970-01-01 01:00:00', 0),
(52, 142, 6, 0, 4, '00:00:00', '00:00:00', 0, '1970-01-01 01:00:00', 0),
(55, 240, 6, 1, 0, '00:00:00', '00:00:00', 5, '1970-01-01 01:00:00', 0),
(55, 233, 4, 2, 0, '00:00:00', '00:00:00', 45, '1970-01-01 01:00:00', 0),
(58, 156, 6, 0, 1, '00:00:00', '00:00:00', 0, '1970-01-01 01:00:00', 0),
(61, 149, 6, 0, 1, '00:00:00', '00:00:00', 0, '1970-01-01 01:00:00', 0),
(62, 59, 6, 0, 1, '00:00:00', '00:00:00', 0, '1970-01-01 01:00:00', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `titletypes`
--

CREATE TABLE `titletypes` (
  `idTitletype` int(10) DEFAULT NULL,
  `titletype` varchar(255) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `titletypes`
--

INSERT INTO `titletypes` (`idTitletype`, `titletype`) VALUES
(1, 'mgr'),
(2, 'mgr inż.'),
(3, 'dr'),
(4, 'dr inż.'),
(5, 'dr hab.'),
(6, 'dr hab. inż.'),
(7, 'prof.'),
(8, 'prof. dr hab.'),
(9, 'prof. dr hab. inż.');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `transactions`
--

CREATE TABLE `transactions` (
  `idEvent` int(11) UNSIGNED NOT NULL,
  `fCostPerTimeSlot` float DEFAULT 0,
  `idUserOwner` int(11) UNSIGNED NOT NULL,
  `idUserClient` int(11) UNSIGNED NOT NULL,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `undesirable`
--

CREATE TABLE `undesirable` (
  `id_cond` int(10) UNSIGNED NOT NULL DEFAULT 0,
  `start_time` smallint(5) UNSIGNED DEFAULT NULL,
  `stop_time` smallint(5) UNSIGNED DEFAULT NULL,
  `idWeekDef` smallint(6) UNSIGNED DEFAULT 0,
  `idWeek` smallint(6) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `undesir_gr`
--

CREATE TABLE `undesir_gr` (
  `id_group` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `start_time` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `stop_time` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `idWeekDef` smallint(6) UNSIGNED DEFAULT 0,
  `idWeek` smallint(6) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `undesir_room`
--

CREATE TABLE `undesir_room` (
  `id_room` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `start_time` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `stop_time` smallint(5) UNSIGNED NOT NULL DEFAULT 0,
  `idWeekDef` smallint(6) UNSIGNED DEFAULT 0,
  `idWeek` smallint(6) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `undesir_starts`
--

CREATE TABLE `undesir_starts` (
  `id` int(11) UNSIGNED DEFAULT 0,
  `start` smallint(5) UNSIGNED DEFAULT 0,
  `stop` smallint(5) UNSIGNED DEFAULT 0,
  `idWeekDef` smallint(6) UNSIGNED DEFAULT 0,
  `idWeek` smallint(6) UNSIGNED DEFAULT 0,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `id_cond` int(11) UNSIGNED DEFAULT 0,
  `id_stud` int(11) UNSIGNED DEFAULT 0,
  `data` datetime DEFAULT NULL,
  `bShowHelp` smallint(3) NOT NULL DEFAULT 1,
  `dtLastModified` datetime DEFAULT NULL,
  `bIsDeleted` smallint(3) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `id_cond`, `id_stud`, `data`, `bShowHelp`, `dtLastModified`, `bIsDeleted`) VALUES
(1, 'admin', 'bb0eede8eed69b7eb99869c34d4d01fc', 0, 0, '0000-00-00 00:00:00', 2025, '0000-00-00 00:00:00', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `weekdefs`
--

CREATE TABLE `weekdefs` (
  `idWeekDef` int(11) UNSIGNED NOT NULL,
  `sShortcut` varchar(25) DEFAULT NULL,
  `sDescript` varchar(250) DEFAULT NULL,
  `bShow` tinyint(4) DEFAULT NULL,
  `idWeekDefE` int(11) UNSIGNED DEFAULT 0,
  `idWeekDefO` int(11) UNSIGNED DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `weekdefs`
--

INSERT INTO `weekdefs` (`idWeekDef`, `sShortcut`, `sDescript`, `bShow`, `idWeekDefE`, `idWeekDefO`) VALUES
(1, 'Wszystkie', 'Wszystkie', 1, 0, 0),
(2, 'Stacjonarne', 'Stacjonarne', 1, 0, 0),
(3, 'S Parzyste', 'S Parzyste', 1, 0, 0),
(4, 'S Nieparzyste', 'S Nieparzyste', 1, 0, 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `weeks`
--

CREATE TABLE `weeks` (
  `idWeek` int(11) UNSIGNED NOT NULL,
  `dtStart` datetime DEFAULT NULL,
  `sDescript` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `weeks`
--

INSERT INTO `weeks` (`idWeek`, `dtStart`, `sDescript`) VALUES
(1, '2024-09-23 00:00:00', '23.09-29.09'),
(2, '2024-09-30 00:00:00', '30.09-06.10'),
(3, '2024-10-07 00:00:00', '07.10-13.10'),
(4, '2024-10-14 00:00:00', '14.10-20.10'),
(5, '2024-10-21 00:00:00', '21.10-27.10'),
(6, '2024-10-28 00:00:00', '28.10-03.11'),
(7, '2024-11-04 00:00:00', '04.11-10.11'),
(8, '2024-11-11 00:00:00', '11.11-17.11'),
(9, '2024-11-18 00:00:00', '18.11-24.11'),
(10, '2024-11-25 00:00:00', '25.11-01.12'),
(11, '2024-12-02 00:00:00', '02.12-08.12'),
(12, '2024-12-09 00:00:00', '09.12-15.12'),
(13, '2024-12-16 00:00:00', '16.12-22.12'),
(14, '2024-12-23 00:00:00', '23.12-29.12'),
(15, '2024-12-30 00:00:00', '30.12-05.01'),
(16, '2025-01-06 00:00:00', '06.01-12.01'),
(17, '2025-01-13 00:00:00', '13.01-19.01'),
(18, '2025-01-20 00:00:00', '20.01-26.01'),
(19, '2025-01-27 00:00:00', '27.01-02.02'),
(20, '2025-02-03 00:00:00', '03.02-09.02'),
(21, '2025-02-10 00:00:00', '10.02-12.02');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `weekweekdef`
--

CREATE TABLE `weekweekdef` (
  `idWeek` int(11) UNSIGNED DEFAULT NULL,
  `idWeekDef` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `weekweekdef`
--

INSERT INTO `weekweekdef` (`idWeek`, `idWeekDef`) VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 1),
(2, 2),
(2, 4),
(3, 1),
(3, 2),
(3, 3),
(4, 1),
(4, 2),
(4, 4),
(5, 1),
(5, 2),
(5, 3),
(6, 1),
(6, 2),
(6, 4),
(7, 1),
(7, 2),
(7, 3),
(8, 1),
(8, 2),
(8, 4),
(9, 1),
(9, 2),
(9, 3),
(10, 1),
(10, 2),
(10, 4),
(11, 1),
(11, 2),
(11, 3),
(12, 1),
(12, 2),
(12, 4),
(13, 1),
(13, 2),
(13, 3),
(14, 1),
(14, 2),
(14, 4),
(15, 1),
(15, 2),
(15, 3),
(16, 1),
(16, 2),
(16, 4),
(17, 1),
(17, 2),
(17, 3),
(18, 1),
(18, 2),
(18, 4),
(19, 1),
(19, 2),
(19, 3),
(20, 1),
(20, 2),
(20, 4),
(21, 2),
(21, 3);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `admins`
--
ALTER TABLE `admins`
  ADD KEY `idUser` (`idUser`),
  ADD KEY `idOwner` (`idOwner`),
  ADD KEY `IX_admins_lastModified` (`dtLastModified`),
  ADD KEY `IX_admins_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `availability`
--
ALTER TABLE `availability`
  ADD KEY `IX_availability` (`id_cond`),
  ADD KEY `IX_availability_lastModified` (`dtLastModified`),
  ADD KEY `IX_availability_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `avail_gr`
--
ALTER TABLE `avail_gr`
  ADD KEY `IX_avail_gr` (`id_group`),
  ADD KEY `IX_avail_gr_lastModified` (`dtLastModified`),
  ADD KEY `IX_avail_gr_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `avail_room`
--
ALTER TABLE `avail_room`
  ADD KEY `IX_avail_room` (`id_room`),
  ADD KEY `IX_avail_room_lastModified` (`dtLastModified`),
  ADD KEY `IX_avail_room_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `colors`
--
ALTER TABLE `colors`
  ADD KEY `name` (`name`);

--
-- Indeksy dla tabeli `conductors`
--
ALTER TABLE `conductors`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `IX_conductors_hash` (`sHash`),
  ADD KEY `IX_conductors_last_change` (`last_change`),
  ADD KEY `IX_conductors_id_cond_tree` (`id_cond_tree`),
  ADD KEY `IX_conductors_surname` (`surname`),
  ADD KEY `IX_conductors_lastModified` (`dtLastModified`),
  ADD KEY `IX_conductors_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_conductors_5_29243159__K3_K1_9` (`surname`,`id`,`id_cond_tree`),
  ADD KEY `_dta_index_conductors_5_29243159__K9_K3_1` (`id_cond_tree`,`surname`,`id`),
  ADD KEY `FK_conductors_users1` (`owner`);

--
-- Indeksy dla tabeli `cond_tree`
--
ALTER TABLE `cond_tree`
  ADD PRIMARY KEY (`id_cond_tree`),
  ADD UNIQUE KEY `IX_cond_tree_hash` (`sHash`),
  ADD KEY `FK_cond_tree_last_change` (`last_change`),
  ADD KEY `FK_cond_tree_owner` (`owner`),
  ADD KEY `IX_cond_tree_parent` (`parent`),
  ADD KEY `IX_cond_tree_lastModified` (`dtLastModified`),
  ADD KEY `IX_cond_tree_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `coursecourse`
--
ALTER TABLE `coursecourse`
  ADD KEY `_dta_index_coursecourse_5_157243615__K1_K2` (`idCourseParent`,`idCourseChild`),
  ADD KEY `IX_coursecourse` (`idCourseParent`),
  ADD KEY `IX_coursecourse_lastModified` (`dtLastModified`),
  ADD KEY `IX_coursecourse_deleted` (`bIsDeleted`),
  ADD KEY `FK_coursecourse_course1` (`idCourseChild`);

--
-- Indeksy dla tabeli `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `IX_courses_hash` (`sHash`),
  ADD KEY `IX_courses_last_change` (`last_change`),
  ADD KEY `IX_courses_name` (`name`),
  ADD KEY `IX_courses_shortcut` (`shortcut`),
  ADD KEY `IX_courses_lastModified` (`dtLastModified`),
  ADD KEY `IX_courses_deleted` (`bIsDeleted`),
  ADD KEY `FK_courses_users1` (`owner`);

--
-- Indeksy dla tabeli `days`
--
ALTER TABLE `days`
  ADD KEY `IX_days_id` (`id`);

--
-- Indeksy dla tabeli `electivecourses`
--
ALTER TABLE `electivecourses`
  ADD KEY `IX_electivecourses_idCourse` (`idCourse`),
  ADD KEY `IX_electivecourses_idStudent` (`idStudent`),
  ADD KEY `IX_electivecourses_lastModified` (`dtLastModified`),
  ADD KEY `IX_electivecourses_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `electivesubjectload`
--
ALTER TABLE `electivesubjectload`
  ADD KEY `IX_electivecourses_idSubjectLoad` (`idSubjectLoad`),
  ADD KEY `IX_electivecourses_idStudent` (`idStudent`),
  ADD KEY `IX_electivesubjectload_lastModified` (`dtLastModified`),
  ADD KEY `IX_electivesubjectload_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `features`
--
ALTER TABLE `features`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `features_conds`
--
ALTER TABLE `features_conds`
  ADD KEY `IX_features_conds` (`id`),
  ADD KEY `IX_features_conds_lastModified` (`dtLastModified`),
  ADD KEY `IX_features_conds_deleted` (`bIsDeleted`),
  ADD KEY `FK_features_conds_features` (`id_feature`);

--
-- Indeksy dla tabeli `features_courses`
--
ALTER TABLE `features_courses`
  ADD KEY `IX_features_courses` (`id`),
  ADD KEY `IX_features_courses_lastModified` (`dtLastModified`),
  ADD KEY `IX_features_courses_deleted` (`bIsDeleted`),
  ADD KEY `FK_features_courses_features` (`id_feature`);

--
-- Indeksy dla tabeli `features_groups`
--
ALTER TABLE `features_groups`
  ADD KEY `IX_features_groups` (`id`),
  ADD KEY `IX_features_groups_lastModified` (`dtLastModified`),
  ADD KEY `IX_features_groups_deleted` (`bIsDeleted`),
  ADD KEY `FK_features_groups_features` (`id_feature`);

--
-- Indeksy dla tabeli `features_rooms`
--
ALTER TABLE `features_rooms`
  ADD KEY `IX_features_rooms` (`id`),
  ADD KEY `IX_features_rooms_lastModified` (`dtLastModified`),
  ADD KEY `IX_features_rooms_deleted` (`bIsDeleted`),
  ADD KEY `FK_features_rooms_features` (`id_feature`);

--
-- Indeksy dla tabeli `func`
--
ALTER TABLE `func`
  ADD PRIMARY KEY (`name`),
  ADD KEY `IX_func_lastModified` (`dtLastModified`),
  ADD KEY `IX_func_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `IX_groups_hash` (`sHash`),
  ADD KEY `IX_groups_last_change` (`last_change`),
  ADD KEY `IX_groups_id_group_tree` (`id_group_tree`),
  ADD KEY `IX_groups_shortcut` (`shortcut`),
  ADD KEY `IX_groups_lastModified` (`dtLastModified`),
  ADD KEY `IX_groups_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_groups_5_61243273__K1_5` (`id`,`shortcut`),
  ADD KEY `_dta_index_groups_5_61243273__K3_K2_1` (`id_group_tree`,`name`,`id`),
  ADD KEY `_dta_index_groups_5_61243273__K3_K5_K1` (`id_group_tree`,`shortcut`,`id`),
  ADD KEY `IX_SNAKE1` (`id_group_tree`,`id`,`shortcut`),
  ADD KEY `FK_groups_users1` (`owner`);

--
-- Indeksy dla tabeli `group_tree`
--
ALTER TABLE `group_tree`
  ADD PRIMARY KEY (`id_group_tree`),
  ADD UNIQUE KEY `IX_group_tree_hash` (`sHash`),
  ADD KEY `IX_group_tree_parent` (`parent`),
  ADD KEY `IX_group_tree_last_change` (`last_change`),
  ADD KEY `IX_group_tree_lastModified` (`dtLastModified`),
  ADD KEY `IX_group_tree_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_group_tree_5_205243786__K1_2` (`id_group_tree`,`name`),
  ADD KEY `_dta_index_group_tree_5_205243786__K2_K3_1` (`name`,`parent`,`id_group_tree`),
  ADD KEY `_dta_index_group_tree_5_205243786__K3_K2` (`parent`,`name`),
  ADD KEY `_dta_index_group_tree_5_205243786__K3_K2_K1_11` (`parent`,`name`,`id_group_tree`,`bShowPlan`),
  ADD KEY `FK_group_tree_users1` (`owner`);

--
-- Indeksy dla tabeli `holidays`
--
ALTER TABLE `holidays`
  ADD PRIMARY KEY (`idHoliday`),
  ADD KEY `IX_holidays_lastModified` (`dtLastModified`),
  ADD KEY `IX_holidays_deleted` (`bIsDeleted`),
  ADD KEY `FK_holidays_weeks` (`idWeek`),
  ADD KEY `FK_holidays_group_tree` (`idGroupTree`),
  ADD KEY `FK_holidays_cond_tree` (`idCondTree`),
  ADD KEY `FK_holidays_room_tree` (`idRoomTree`),
  ADD KEY `FK_holidays_users0` (`idOwner`),
  ADD KEY `FK_holidays_users1` (`idLastChange`);

--
-- Indeksy dla tabeli `mainpage`
--
ALTER TABLE `mainpage`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IX_mainpage_lastModified` (`dtLastModified`),
  ADD KEY `IX_mainpage_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `orders`
--
ALTER TABLE `orders`
  ADD KEY `IX_orders_idSender` (`idSender`),
  ADD KEY `IX_orders_idCondTree` (`idCondTree`),
  ADD KEY `IX_orders_lastModified` (`dtLastModified`),
  ADD KEY `IX_orders_deleted` (`bIsDeleted`),
  ADD KEY `FK_orders_courses` (`idCourse`),
  ADD KEY `FK_orders_weekdef` (`idWeekDef`);

--
-- Indeksy dla tabeli `order_recipient`
--
ALTER TABLE `order_recipient`
  ADD KEY `IX_order_recipient_lastModified` (`dtLastModified`),
  ADD KEY `IX_order_recipient_deleted` (`bIsDeleted`),
  ADD KEY `FK_order_recipient_users` (`idOrderRecipient`);

--
-- Indeksy dla tabeli `poss_conds`
--
ALTER TABLE `poss_conds`
  ADD KEY `IX_poss_conds_idCourse` (`idCourse`),
  ADD KEY `IX_poss_conds_lastModified` (`dtLastModified`),
  ADD KEY `IX_poss_conds_deleted` (`bIsDeleted`),
  ADD KEY `FK_poss_conds_conductors` (`idCond`);

--
-- Indeksy dla tabeli `poss_rooms`
--
ALTER TABLE `poss_rooms`
  ADD KEY `IX_poss_rooms_id` (`id`),
  ADD KEY `IX_poss_rooms_lastModified` (`dtLastModified`),
  ADD KEY `IX_poss_rooms_deleted` (`bIsDeleted`),
  ADD KEY `FK_poss_rooms_rooms` (`id_room`);

--
-- Indeksy dla tabeli `poss_starts`
--
ALTER TABLE `poss_starts`
  ADD KEY `IX_poss_starts` (`id`),
  ADD KEY `IX_poss_starts_lastModified` (`dtLastModified`),
  ADD KEY `IX_poss_starts_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `resers`
--
ALTER TABLE `resers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `IX_resers_hash` (`sHash`),
  ADD KEY `IX_resers_last_change` (`last_change`),
  ADD KEY `IX_resers_owner` (`owner`),
  ADD KEY `IX_resers_lastModified` (`dtLastModified`),
  ADD KEY `IX_resers_deleted` (`bIsDeleted`),
  ADD KEY `FK_resers_reser_type` (`idReserType`);

--
-- Indeksy dla tabeli `reser_cond`
--
ALTER TABLE `reser_cond`
  ADD KEY `IX_reser_cond_id` (`id_cond`),
  ADD KEY `IX_reser_cond_id_cond` (`id`),
  ADD KEY `IX_reser_cond_lastModified` (`dtLastModified`),
  ADD KEY `IX_reser_cond_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `reser_group`
--
ALTER TABLE `reser_group`
  ADD KEY `IX_reser_group_id` (`id`),
  ADD KEY `IX_reser_group_id_group` (`id_group`),
  ADD KEY `IX_reser_group_lastModified` (`dtLastModified`),
  ADD KEY `IX_reser_group_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_reser_group_c_5_1504724413__K2_K1` (`id_group`,`id`),
  ADD KEY `IX_SNAKE5` (`id`,`id_group`);

--
-- Indeksy dla tabeli `reser_room`
--
ALTER TABLE `reser_room`
  ADD KEY `IX_reser_room_id` (`id`),
  ADD KEY `IX_reser_room_id_room` (`id_room`),
  ADD KEY `IX_reser_room_lastModified` (`dtLastModified`),
  ADD KEY `IX_reser_room_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `reser_student`
--
ALTER TABLE `reser_student`
  ADD KEY `IX_reser_student_id` (`id`),
  ADD KEY `IX_reser_student_id_student` (`id_student`),
  ADD KEY `IX_reser_student_lastModified` (`dtLastModified`),
  ADD KEY `IX_reser_student_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `reser_type`
--
ALTER TABLE `reser_type`
  ADD PRIMARY KEY (`idReserType`);

--
-- Indeksy dla tabeli `rights`
--
ALTER TABLE `rights`
  ADD KEY `IX_resers_idUser` (`idUser`),
  ADD KEY `IX_resers_idResource` (`idResource`),
  ADD KEY `IX_rights_lastModified` (`dtLastModified`),
  ADD KEY `IX_rights_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_rights_c_5_1632724869__K1_K2` (`idUser`,`idResource`),
  ADD KEY `_dta_index_rights_5_1632724869__K1_3` (`idUser`,`bRights`);

--
-- Indeksy dla tabeli `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `IX_rooms_hash` (`sHash`),
  ADD KEY `IX_rooms_last_change` (`last_change`),
  ADD KEY `IX_rooms_id_room_tree` (`id_room_tree`),
  ADD KEY `IX_rooms_shortcut` (`nr_room`),
  ADD KEY `IX_rooms_lastModified` (`dtLastModified`),
  ADD KEY `IX_rooms_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_rooms_5_1648724926__K2_K3_1` (`id_room_tree`,`nr_room`,`id`),
  ADD KEY `_dta_index_rooms_5_1648724926__K2_K3_K1` (`id_room_tree`,`nr_room`,`id`),
  ADD KEY `_dta_index_rooms_5_1648724926__K3_K2_1` (`nr_room`,`id_room_tree`,`id`),
  ADD KEY `FK_rooms_users1` (`owner`);

--
-- Indeksy dla tabeli `room_tree`
--
ALTER TABLE `room_tree`
  ADD PRIMARY KEY (`id_room_tree`),
  ADD UNIQUE KEY `IX_room_tree_hash` (`sHash`),
  ADD KEY `IX_room_tree_parent` (`parent`),
  ADD KEY `IX_room_tree_last_change` (`last_change`),
  ADD KEY `IX_room_tree_lastModified` (`dtLastModified`),
  ADD KEY `IX_room_tree_deleted` (`bIsDeleted`),
  ADD KEY `FK_room_tree_users1` (`owner`);

--
-- Indeksy dla tabeli `set_cond`
--
ALTER TABLE `set_cond`
  ADD KEY `IX_set_cond_id` (`id`),
  ADD KEY `IX_set_cond_id_cond` (`id_cond`),
  ADD KEY `IX_set_cond_lastModified` (`dtLastModified`),
  ADD KEY `IX_set_cond_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_set_cond_c_5_1680725040__K2_K5` (`id_cond`,`idRoom`),
  ADD KEY `_dta_index_set_cond_5_1680725040__K2_K1` (`id_cond`,`id`),
  ADD KEY `IX_SNAKE6` (`id`,`id_cond`);

--
-- Indeksy dla tabeli `set_groups`
--
ALTER TABLE `set_groups`
  ADD KEY `IX_set_groups_id` (`id`),
  ADD KEY `IX_set_groups_id_group` (`id_group`),
  ADD KEY `IX_set_groups_lastModified` (`dtLastModified`),
  ADD KEY `IX_set_groups_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_set_groups_5_1696725097__K1_K2` (`id`,`id_group`),
  ADD KEY `IX_set_groups_ID_GROUP_ID` (`id_group`,`id`);

--
-- Indeksy dla tabeli `set_rooms`
--
ALTER TABLE `set_rooms`
  ADD KEY `IX_set_rooms_id` (`id`),
  ADD KEY `IX_set_rooms_id_room` (`id_room`),
  ADD KEY `IX_set_rooms_lastModified` (`dtLastModified`),
  ADD KEY `IX_set_rooms_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_set_rooms_5_1712725154__K1_K2` (`id`,`id_room`),
  ADD KEY `IX_set_rooms_ID_ROOM_ID` (`id_room`,`id`);

--
-- Indeksy dla tabeli `stats`
--
ALTER TABLE `stats`
  ADD PRIMARY KEY (`idStats`),
  ADD KEY `IX_stats_lastModified` (`dtLastModified`),
  ADD KEY `IX_stats_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `studentcourse`
--
ALTER TABLE `studentcourse`
  ADD KEY `IX_studentcourse_idStudent` (`idStudent`),
  ADD KEY `IX_studentcourse_idCourse` (`idCourse`),
  ADD KEY `IX_studentcourse_lastModified` (`dtLastModified`),
  ADD KEY `IX_studentcourse_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `studentgroup`
--
ALTER TABLE `studentgroup`
  ADD KEY `IX_studentgroup_idStudent` (`idStudent`),
  ADD KEY `IX_studentgroup_idGroup` (`idGroup`),
  ADD KEY `IX_studentgroup_lastModified` (`dtLastModified`),
  ADD KEY `IX_studentgroup_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`idStudent`),
  ADD UNIQUE KEY `IX_students_hash` (`sHash`),
  ADD KEY `IX_students_idUserModified` (`idUserModified`),
  ADD KEY `IX_students_idStudentTree` (`idStudentTree`),
  ADD KEY `IX_students_sSurname` (`sSurname`),
  ADD KEY `IX_students_lastModified` (`dtLastModified`),
  ADD KEY `IX_students_deleted` (`bIsDeleted`),
  ADD KEY `FK_students_users1` (`idUserOwner`);

--
-- Indeksy dla tabeli `student_tree`
--
ALTER TABLE `student_tree`
  ADD PRIMARY KEY (`idStudentTree`),
  ADD UNIQUE KEY `IX_student_tree_hash` (`sHash`),
  ADD KEY `IX_student_tree_idParent` (`idParent`),
  ADD KEY `IX_student_tree_idUserModified` (`idUserModified`),
  ADD KEY `IX_student_tree_lastModified` (`dtLastModified`),
  ADD KEY `IX_student_tree_deleted` (`bIsDeleted`),
  ADD KEY `FK_student_tree_users1` (`idUserOwner`);

--
-- Indeksy dla tabeli `studyplan`
--
ALTER TABLE `studyplan`
  ADD PRIMARY KEY (`idStudyPlan`),
  ADD KEY `IX_studyplan_lastModified` (`dtLastModified`),
  ADD KEY `IX_studyplan_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `studyplancondtree`
--
ALTER TABLE `studyplancondtree`
  ADD KEY `IX_studyplancondtree_idCondTree` (`idCondTree`),
  ADD KEY `IX_studyplancondtree_idStudyPlan` (`idStudyPlan`),
  ADD KEY `IX_studyplancondtree_lastModified` (`dtLastModified`),
  ADD KEY `IX_studyplancondtree_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`idSubject`),
  ADD KEY `IX_subject_sName` (`sName`),
  ADD KEY `IX_subject_lastModified` (`dtLastModified`),
  ADD KEY `IX_subject_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `subjectcondtree`
--
ALTER TABLE `subjectcondtree`
  ADD KEY `IX_subjectcondtree_idCondTree` (`idCondTree`),
  ADD KEY `IX_subjectcondtree_idSubject` (`idSubject`),
  ADD KEY `IX_subjectcondtree_lastModified` (`dtLastModified`),
  ADD KEY `IX_subjectcondtree_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `subjectload`
--
ALTER TABLE `subjectload`
  ADD PRIMARY KEY (`idSubjectLoad`),
  ADD KEY `IX_subjectload_idSubject` (`idSubject`),
  ADD KEY `IX_subjectload_iSemester` (`iSemester`),
  ADD KEY `IX_subjectload_lastModified` (`dtLastModified`),
  ADD KEY `IX_subjectload_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_subjectload_5_1040722760__K10_K11_K1_3_4_5_6_7_8_9` (`iSemester`,`idSubject`,`idSubjectLoad`,`iLecture`,`iExercise`,`iLaboratory`,`iProject`,`iSeminar`,`bExam`,`iECTS`),
  ADD KEY `_dta_index_subjectload_5_1040722760__K11_K1_K10_3_4_5_6_7_8_9` (`idSubject`,`idSubjectLoad`,`iSemester`,`iLecture`,`iExercise`,`iLaboratory`,`iProject`,`iSeminar`,`bExam`,`iECTS`);

--
-- Indeksy dla tabeli `subjectloadcourse`
--
ALTER TABLE `subjectloadcourse`
  ADD KEY `IX_subjectloadcourse_idSubjectLoad` (`idSubjectLoad`),
  ADD KEY `IX_subjectloadcourse_idCourse` (`idCourse`),
  ADD KEY `IX_subjectloadcourse_lastModified` (`dtLastModified`),
  ADD KEY `IX_subjectloadcourse_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `subjectstudyplan`
--
ALTER TABLE `subjectstudyplan`
  ADD KEY `IX_subjectstudyplan_idSubject` (`idSubject`),
  ADD KEY `IX_subjectstudyplan_idStudyPlan` (`idStudyPlan`),
  ADD KEY `_dta_index_subjectstudyplan_5_1152723159__K2_K1_K3` (`idStudyPlan`,`idSubject`,`iNumber`),
  ADD KEY `IX_subjectstudyplan_lastModified` (`dtLastModified`),
  ADD KEY `IX_subjectstudyplan_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `tables_last_modified`
--
ALTER TABLE `tables_last_modified`
  ADD PRIMARY KEY (`sTableName`),
  ADD KEY `IX_tables_last_modified_lastModified` (`dtLastModified`);

--
-- Indeksy dla tabeli `times`
--
ALTER TABLE `times`
  ADD KEY `IX_times_idEvent` (`idEvent`),
  ADD KEY `IX_times_idWeekDef` (`idWeekDef`),
  ADD KEY `IX_times_idWeek` (`idWeek`),
  ADD KEY `IX_times_lastModified` (`dtLastModified`),
  ADD KEY `IX_times_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_times_c_5_1734297238__K1_K5_K2_K4_K8_K3_K6_K7` (`idEvent`,`idWeekDef`,`start`,`idWeek`,`idRoom`,`dur`,`dtStart`,`dtStop`),
  ADD KEY `IX_SNAKE2` (`idEvent`,`idWeek`,`idWeekDef`,`idRoom`,`dur`,`dtStart`,`dtStop`,`start`),
  ADD KEY `IX_SNAKE4` (`idEvent`,`start`,`idWeek`,`idWeekDef`);

--
-- Indeksy dla tabeli `transactions`
--
ALTER TABLE `transactions`
  ADD KEY `IX_transactions_idEvent` (`idEvent`),
  ADD KEY `IX_transactions_idUserOwner` (`idUserOwner`),
  ADD KEY `IX_transactions_idUserClient` (`idUserClient`),
  ADD KEY `IX_transactions_lastModified` (`dtLastModified`),
  ADD KEY `IX_transactions_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `undesirable`
--
ALTER TABLE `undesirable`
  ADD KEY `IX_undesirable` (`id_cond`),
  ADD KEY `IX_undesirable_lastModified` (`dtLastModified`),
  ADD KEY `IX_undesirable_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `undesir_gr`
--
ALTER TABLE `undesir_gr`
  ADD KEY `IX_undesir_gr` (`id_group`),
  ADD KEY `IX_undesir_gr_lastModified` (`dtLastModified`),
  ADD KEY `IX_undesir_gr_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `undesir_room`
--
ALTER TABLE `undesir_room`
  ADD KEY `IX_undesir_room` (`id_room`),
  ADD KEY `IX_undesir_room_lastModified` (`dtLastModified`),
  ADD KEY `IX_undesir_room_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `undesir_starts`
--
ALTER TABLE `undesir_starts`
  ADD KEY `IX_undesir_starts` (`id`),
  ADD KEY `IX_undesir_starts_lastModified` (`dtLastModified`),
  ADD KEY `IX_undesir_starts_deleted` (`bIsDeleted`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IX_users_lastModified` (`dtLastModified`),
  ADD KEY `IX_users_deleted` (`bIsDeleted`),
  ADD KEY `_dta_index_users_5_1170819233__K1` (`id`),
  ADD KEY `_dta_index_users_5_1170819233__K1_K4` (`id`,`id_cond`),
  ADD KEY `_dta_index_users_5_1170819233__K1_K4_K5_K2` (`id`,`id_cond`,`id_stud`,`username`),
  ADD KEY `_dta_index_users_5_1170819233__K2_1_4` (`username`,`id`,`id_cond`),
  ADD KEY `_dta_index_users_5_1170819233__K2_4` (`username`,`id_cond`),
  ADD KEY `_dta_index_users_5_1170819233__K4` (`id_cond`),
  ADD KEY `_dta_index_users_5_1170819233__K4_K5_K1` (`id_cond`,`id_stud`,`id`),
  ADD KEY `_dta_index_users_5_1170819233__K4_K5_K1_K2` (`id_cond`,`id_stud`,`id`,`username`),
  ADD KEY `_dta_index_users_5_1170819233__K5` (`id_stud`);

--
-- Indeksy dla tabeli `weekdefs`
--
ALTER TABLE `weekdefs`
  ADD PRIMARY KEY (`idWeekDef`),
  ADD KEY `IX_SNAKE2` (`idWeekDef`,`idWeekDefE`,`idWeekDefO`);

--
-- Indeksy dla tabeli `weeks`
--
ALTER TABLE `weeks`
  ADD PRIMARY KEY (`idWeek`);

--
-- Indeksy dla tabeli `weekweekdef`
--
ALTER TABLE `weekweekdef`
  ADD KEY `IX_weekweekdef_idWeek` (`idWeek`),
  ADD KEY `IX_weekweekdef_idWeekDef` (`idWeekDef`),
  ADD KEY `IX_SNAKE1` (`idWeek`,`idWeekDef`),
  ADD KEY `IX_SNAKE8` (`idWeekDef`,`idWeek`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `holidays`
--
ALTER TABLE `holidays`
  MODIFY `idHoliday` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mainpage`
--
ALTER TABLE `mainpage`
  MODIFY `id` smallint(6) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `stats`
--
ALTER TABLE `stats`
  MODIFY `idStats` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `studyplan`
--
ALTER TABLE `studyplan`
  MODIFY `idStudyPlan` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
  MODIFY `idSubject` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `subjectload`
--
ALTER TABLE `subjectload`
  MODIFY `idSubjectLoad` int(11) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `admins`
--
ALTER TABLE `admins`
  ADD CONSTRAINT `FK_admins_users` FOREIGN KEY (`idUser`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_admins_users1` FOREIGN KEY (`idOwner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `availability`
--
ALTER TABLE `availability`
  ADD CONSTRAINT `FK_availability_conductors` FOREIGN KEY (`id_cond`) REFERENCES `conductors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `avail_gr`
--
ALTER TABLE `avail_gr`
  ADD CONSTRAINT `FK_avail_gr_groups` FOREIGN KEY (`id_group`) REFERENCES `groups` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `avail_room`
--
ALTER TABLE `avail_room`
  ADD CONSTRAINT `FK_avail_room_rooms` FOREIGN KEY (`id_room`) REFERENCES `rooms` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `conductors`
--
ALTER TABLE `conductors`
  ADD CONSTRAINT `FK_conductors_cond_tree` FOREIGN KEY (`id_cond_tree`) REFERENCES `cond_tree` (`id_cond_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_conductors_users` FOREIGN KEY (`last_change`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_conductors_users1` FOREIGN KEY (`owner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `cond_tree`
--
ALTER TABLE `cond_tree`
  ADD CONSTRAINT `FK_cond_tree_users` FOREIGN KEY (`last_change`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_cond_tree_users1` FOREIGN KEY (`owner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `coursecourse`
--
ALTER TABLE `coursecourse`
  ADD CONSTRAINT `FK_coursecourse_course` FOREIGN KEY (`idCourseParent`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_coursecourse_course1` FOREIGN KEY (`idCourseChild`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `courses`
--
ALTER TABLE `courses`
  ADD CONSTRAINT `FK_courses_users` FOREIGN KEY (`last_change`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_courses_users1` FOREIGN KEY (`owner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `electivecourses`
--
ALTER TABLE `electivecourses`
  ADD CONSTRAINT `FK_electivecourses_courses` FOREIGN KEY (`idCourse`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_electivecourses_students` FOREIGN KEY (`idStudent`) REFERENCES `students` (`idStudent`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `electivesubjectload`
--
ALTER TABLE `electivesubjectload`
  ADD CONSTRAINT `FK_electivesubjectload_students` FOREIGN KEY (`idStudent`) REFERENCES `students` (`idStudent`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_electivesubjectload_subjectload` FOREIGN KEY (`idSubjectLoad`) REFERENCES `subjectload` (`idSubjectLoad`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `features_conds`
--
ALTER TABLE `features_conds`
  ADD CONSTRAINT `FK_features_conds_conductors` FOREIGN KEY (`id`) REFERENCES `conductors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_features_conds_features` FOREIGN KEY (`id_feature`) REFERENCES `features` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `features_courses`
--
ALTER TABLE `features_courses`
  ADD CONSTRAINT `FK_features_courses_courses` FOREIGN KEY (`id`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_features_courses_features` FOREIGN KEY (`id_feature`) REFERENCES `features` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `features_groups`
--
ALTER TABLE `features_groups`
  ADD CONSTRAINT `FK_features_groups_features` FOREIGN KEY (`id_feature`) REFERENCES `features` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_features_groups_groups` FOREIGN KEY (`id`) REFERENCES `groups` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `features_rooms`
--
ALTER TABLE `features_rooms`
  ADD CONSTRAINT `FK_features_rooms_features` FOREIGN KEY (`id_feature`) REFERENCES `features` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_features_rooms_rooms` FOREIGN KEY (`id`) REFERENCES `rooms` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `groups`
--
ALTER TABLE `groups`
  ADD CONSTRAINT `FK_groups_group_tree` FOREIGN KEY (`id_group_tree`) REFERENCES `group_tree` (`id_group_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_groups_users` FOREIGN KEY (`last_change`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_groups_users1` FOREIGN KEY (`owner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `group_tree`
--
ALTER TABLE `group_tree`
  ADD CONSTRAINT `FK_group_tree_users` FOREIGN KEY (`last_change`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_group_tree_users1` FOREIGN KEY (`owner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `holidays`
--
ALTER TABLE `holidays`
  ADD CONSTRAINT `FK_holidays_cond_tree` FOREIGN KEY (`idCondTree`) REFERENCES `cond_tree` (`id_cond_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_holidays_group_tree` FOREIGN KEY (`idGroupTree`) REFERENCES `group_tree` (`id_group_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_holidays_room_tree` FOREIGN KEY (`idRoomTree`) REFERENCES `room_tree` (`id_room_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_holidays_users0` FOREIGN KEY (`idOwner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_holidays_users1` FOREIGN KEY (`idLastChange`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_holidays_weeks` FOREIGN KEY (`idWeek`) REFERENCES `weeks` (`idWeek`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_orders_cond_tree` FOREIGN KEY (`idCondTree`) REFERENCES `cond_tree` (`id_cond_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_orders_courses` FOREIGN KEY (`idCourse`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_orders_users` FOREIGN KEY (`idSender`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_orders_weekdef` FOREIGN KEY (`idWeekDef`) REFERENCES `weekdefs` (`idWeekDef`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `order_recipient`
--
ALTER TABLE `order_recipient`
  ADD CONSTRAINT `FK_order_recipient_users` FOREIGN KEY (`idOrderRecipient`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `poss_conds`
--
ALTER TABLE `poss_conds`
  ADD CONSTRAINT `FK_poss_conds_conductors` FOREIGN KEY (`idCond`) REFERENCES `conductors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_poss_conds_courses` FOREIGN KEY (`idCourse`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `poss_rooms`
--
ALTER TABLE `poss_rooms`
  ADD CONSTRAINT `FK_poss_rooms_courses` FOREIGN KEY (`id`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_poss_rooms_rooms` FOREIGN KEY (`id_room`) REFERENCES `rooms` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `poss_starts`
--
ALTER TABLE `poss_starts`
  ADD CONSTRAINT `FK_poss_starts_courses` FOREIGN KEY (`id`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `resers`
--
ALTER TABLE `resers`
  ADD CONSTRAINT `FK_resers_reser_type` FOREIGN KEY (`idReserType`) REFERENCES `reser_type` (`idReserType`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_resers_users` FOREIGN KEY (`last_change`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_resers_users1` FOREIGN KEY (`owner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reser_cond`
--
ALTER TABLE `reser_cond`
  ADD CONSTRAINT `FK_reser_cond_conductors` FOREIGN KEY (`id_cond`) REFERENCES `conductors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_reser_cond_resers` FOREIGN KEY (`id`) REFERENCES `resers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reser_group`
--
ALTER TABLE `reser_group`
  ADD CONSTRAINT `FK_reser_group_groups` FOREIGN KEY (`id_group`) REFERENCES `groups` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_reser_group_resers` FOREIGN KEY (`id`) REFERENCES `resers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reser_room`
--
ALTER TABLE `reser_room`
  ADD CONSTRAINT `FK_reser_room_resers` FOREIGN KEY (`id`) REFERENCES `resers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_reser_room_rooms` FOREIGN KEY (`id_room`) REFERENCES `rooms` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `reser_student`
--
ALTER TABLE `reser_student`
  ADD CONSTRAINT `FK_reser_student_resers` FOREIGN KEY (`id`) REFERENCES `resers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_reser_student_students` FOREIGN KEY (`id_student`) REFERENCES `students` (`idStudent`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `rights`
--
ALTER TABLE `rights`
  ADD CONSTRAINT `FK_rights_users` FOREIGN KEY (`idUser`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `rooms`
--
ALTER TABLE `rooms`
  ADD CONSTRAINT `FK_rooms_room_tree` FOREIGN KEY (`id_room_tree`) REFERENCES `room_tree` (`id_room_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_rooms_users` FOREIGN KEY (`last_change`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_rooms_users1` FOREIGN KEY (`owner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `room_tree`
--
ALTER TABLE `room_tree`
  ADD CONSTRAINT `FK_room_tree_users` FOREIGN KEY (`last_change`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_room_tree_users1` FOREIGN KEY (`owner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `set_cond`
--
ALTER TABLE `set_cond`
  ADD CONSTRAINT `FK_set_cond_conductors` FOREIGN KEY (`id_cond`) REFERENCES `conductors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_set_cond_courses` FOREIGN KEY (`id`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `set_groups`
--
ALTER TABLE `set_groups`
  ADD CONSTRAINT `FK_set_groups_courses` FOREIGN KEY (`id`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_set_groups_groups` FOREIGN KEY (`id_group`) REFERENCES `groups` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `set_rooms`
--
ALTER TABLE `set_rooms`
  ADD CONSTRAINT `FK_set_rooms_courses` FOREIGN KEY (`id`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_set_rooms_rooms` FOREIGN KEY (`id_room`) REFERENCES `rooms` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `studentcourse`
--
ALTER TABLE `studentcourse`
  ADD CONSTRAINT `FK_studentcourse_courses` FOREIGN KEY (`idCourse`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_studentcourse_students` FOREIGN KEY (`idStudent`) REFERENCES `students` (`idStudent`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `studentgroup`
--
ALTER TABLE `studentgroup`
  ADD CONSTRAINT `FK_studentgroup_groups` FOREIGN KEY (`idGroup`) REFERENCES `groups` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_studentgroup_students` FOREIGN KEY (`idStudent`) REFERENCES `students` (`idStudent`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `FK_students_student_tree` FOREIGN KEY (`idStudentTree`) REFERENCES `student_tree` (`idStudentTree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_students_users` FOREIGN KEY (`idUserModified`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_students_users1` FOREIGN KEY (`idUserOwner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `student_tree`
--
ALTER TABLE `student_tree`
  ADD CONSTRAINT `FK_student_tree_users` FOREIGN KEY (`idUserModified`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_student_tree_users1` FOREIGN KEY (`idUserOwner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `studyplancondtree`
--
ALTER TABLE `studyplancondtree`
  ADD CONSTRAINT `FK_studyplancondtree_cond_tree` FOREIGN KEY (`idCondTree`) REFERENCES `cond_tree` (`id_cond_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_studyplancondtree_studyplan` FOREIGN KEY (`idStudyPlan`) REFERENCES `studyplan` (`idStudyPlan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `subjectcondtree`
--
ALTER TABLE `subjectcondtree`
  ADD CONSTRAINT `FK_subjectcondtree_cond_tree` FOREIGN KEY (`idCondTree`) REFERENCES `cond_tree` (`id_cond_tree`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_subjectcondtree_subject` FOREIGN KEY (`idSubject`) REFERENCES `subject` (`idSubject`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `subjectload`
--
ALTER TABLE `subjectload`
  ADD CONSTRAINT `FK_subjectload_subject` FOREIGN KEY (`idSubject`) REFERENCES `subject` (`idSubject`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `subjectloadcourse`
--
ALTER TABLE `subjectloadcourse`
  ADD CONSTRAINT `FK_subjectloadcourse_course` FOREIGN KEY (`idCourse`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_subjectloadcourse_subjectload` FOREIGN KEY (`idSubjectLoad`) REFERENCES `subjectload` (`idSubjectLoad`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `subjectstudyplan`
--
ALTER TABLE `subjectstudyplan`
  ADD CONSTRAINT `FK_subjectstudyplan_studyplan` FOREIGN KEY (`idStudyPlan`) REFERENCES `studyplan` (`idStudyPlan`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_subjectstudyplan_subject` FOREIGN KEY (`idSubject`) REFERENCES `subject` (`idSubject`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `times`
--
ALTER TABLE `times`
  ADD CONSTRAINT `FK_times_weekdefs` FOREIGN KEY (`idWeekDef`) REFERENCES `weekdefs` (`idWeekDef`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_times_weeks` FOREIGN KEY (`idWeek`) REFERENCES `weeks` (`idWeek`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `FK_transactions_times` FOREIGN KEY (`idEvent`) REFERENCES `times` (`idEvent`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_transactions_users` FOREIGN KEY (`idUserOwner`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_transactions_users1` FOREIGN KEY (`idUserClient`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `undesirable`
--
ALTER TABLE `undesirable`
  ADD CONSTRAINT `FK_undesirable_conductors` FOREIGN KEY (`id_cond`) REFERENCES `conductors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `undesir_gr`
--
ALTER TABLE `undesir_gr`
  ADD CONSTRAINT `FK_undesir_gr_groups` FOREIGN KEY (`id_group`) REFERENCES `groups` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `undesir_room`
--
ALTER TABLE `undesir_room`
  ADD CONSTRAINT `FK_undesir_room_rooms` FOREIGN KEY (`id_room`) REFERENCES `rooms` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `undesir_starts`
--
ALTER TABLE `undesir_starts`
  ADD CONSTRAINT `FK_undesir_starts_courses` FOREIGN KEY (`id`) REFERENCES `courses` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `FK_users_conductors` FOREIGN KEY (`id_cond`) REFERENCES `conductors` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_users_students` FOREIGN KEY (`id_stud`) REFERENCES `students` (`idStudent`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `weekweekdef`
--
ALTER TABLE `weekweekdef`
  ADD CONSTRAINT `FK_weekweekdef_weekdefs` FOREIGN KEY (`idWeekDef`) REFERENCES `weekdefs` (`idWeekDef`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_weekweekdef_weeks` FOREIGN KEY (`idWeek`) REFERENCES `weeks` (`idWeek`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
