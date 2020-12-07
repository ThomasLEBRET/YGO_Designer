-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: mysql-omuzoki.alwaysdata.net
-- Generation Time: Dec 07, 2020 at 07:47 PM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `omuzoki_ygodesigner`
--

-- --------------------------------------------------------

--
-- Table structure for table `ATTRIBUT_CARTE`
--

CREATE TABLE `ATTRIBUT_CARTE` (
  `CODE_ATTR_CARTE` varchar(12) NOT NULL,
  `NOM_ATTR_CARTE` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ATTRIBUT_CARTE`
--

INSERT INTO `ATTRIBUT_CARTE` (`CODE_ATTR_CARTE`, `NOM_ATTR_CARTE`) VALUES
('MAG', 'Magie'),
('MON', 'Monstre'),
('PIE', 'Piège');

-- --------------------------------------------------------

--
-- Table structure for table `CARTE`
--

CREATE TABLE `CARTE` (
  `NO_CARTE` bigint(12) NOT NULL,
  `CODE_ATTR_CARTE` varchar(12) NOT NULL,
  `NOM` varchar(100) DEFAULT NULL,
  `DESCRIPTION` text DEFAULT NULL,
  `TYPE_MO` varchar(128) DEFAULT NULL,
  `ATTR_MO` varchar(128) DEFAULT NULL,
  `NIVEAU_MO` smallint(6) DEFAULT NULL,
  `TYPE_MA` varchar(128) DEFAULT NULL,
  `TYPE_PI` varchar(128) DEFAULT NULL,
  `ATK` int(11) DEFAULT NULL,
  `DEF` int(11) DEFAULT NULL,
  `TYPE_MONSTRE_CARTE` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `CARTE`
--

INSERT INTO `CARTE` (`NO_CARTE`, `CODE_ATTR_CARTE`, `NOM`, `DESCRIPTION`, `TYPE_MO`, `ATTR_MO`, `NIVEAU_MO`, `TYPE_MA`, `TYPE_PI`, `ATK`, `DEF`, `TYPE_MONSTRE_CARTE`) VALUES
(1, 'MON', 'Justicia Dragarde', 'L\'avenir du Monde dépend des Dragardes nés de l\'Héritage du Monde.', 'Dragon', 'Eau', 2, '', NULL, 0, 2100, 'Syntoniseur'),
(2, 'MAG', 'Terra Formation', 'Ajouter 1 Magie de Terrain depuis votre Deck à votre main.', NULL, NULL, NULL, 'Normal', '', NULL, NULL, NULL),
(3, 'PIE', 'Métavers', 'Prenez 1 Magie de Terrain depuis votre Deck, et soit activez-la soit ajoutez-la à votre main.', NULL, NULL, NULL, NULL, 'Normal', NULL, NULL, ''),
(4, 'MAG', 'Raigeki', 'Détruisez tous les monstres contrôlés par votre adversaire', NULL, NULL, NULL, 'Normal', NULL, NULL, NULL, NULL),
(5, 'PIE', 'Métavers', 'Prenez 1 Magie de Terrain depuis votre Deck, et soit activez-la, soit ajoutez-la à votre main.', NULL, NULL, NULL, NULL, 'Normale', NULL, NULL, NULL),
(6, 'MON', 'Demoiselle aux Yeux Couleur Bleu\r\n', 'Lorsqu\'une carte ou un effet qui cible cette carte est activé (Effet Rapide) : vous pouvez Invoquer Spécialement 1 \"Dragon Blanc aux Yeux Bleus\" depuis votre main, Deck ou Cimetière. Lorsque cette carte est ciblée par une attaque : vous pouvez annuler l\'attaque, et si vous le faites, changez la position de combat de cette carte, puis vous pouvez Invoquer Spécialement 1 \"Dragon Blanc aux Yeux Bleus\" depuis votre main, Deck ou Cimetière. Vous ne pouvez utiliser qu\'1 effet de \"Demoiselle aux Yeux Couleur Bleu\" par tour, et uniquement une fois le tour.', 'Magicien', 'Lumiere', 1, NULL, NULL, 0, 0, 'Syntoniseur');

-- --------------------------------------------------------

--
-- Table structure for table `COMBO`
--

CREATE TABLE `COMBO` (
  `CODE_EFFET` varchar(12) NOT NULL,
  `CODE_EFFET_1` varchar(12) NOT NULL,
  `CODE_STRAT` char(12) NOT NULL,
  `POIDS` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `COMBO`
--

INSERT INTO `COMBO` (`CODE_EFFET`, `CODE_EFFET_1`, `CODE_STRAT`, `POIDS`) VALUES
('ANNULEFFMA', 'ANNULEFFMA', 'BL', 3),
('ANNULEFFMA', 'CHPOSCOM', 'BL', 5),
('CHPOSCOM', 'ANNULEFFMA', 'BL', 3),
('CHPOSCOM', 'CHPOSCOM', 'BL', 3),
('CHPOSCOM', 'CHPOSCOM', 'TEST', 1),
('CHPOSCOM', 'DESMA', 'TEST', 3),
('DESMA', 'CHPOSCOM', 'TEST', 2),
('DESMA', 'DESMA', 'TEST', 1);

-- --------------------------------------------------------

--
-- Table structure for table `DECK`
--

CREATE TABLE `DECK` (
  `NO_DECK` int(11) NOT NULL,
  `USER` char(32) NOT NULL,
  `NOM_DECK` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `DECK`
--

INSERT INTO `DECK` (`NO_DECK`, `USER`, `NOM_DECK`) VALUES
(1, 'Omuzoki', 'Deck de test');

-- --------------------------------------------------------

--
-- Table structure for table `EFFET`
--

CREATE TABLE `EFFET` (
  `CODE_EFFET` varchar(12) NOT NULL,
  `NOM_EFFET` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `EFFET`
--

INSERT INTO `EFFET` (`CODE_EFFET`, `NOM_EFFET`) VALUES
('ANNULATK', 'Annulation attaque'),
('ANNULEFFMA', 'Annulation d\'effet de Magie'),
('ANNULEFFMO', 'Annulation d\'effet de Monstre'),
('ANNULEFFPI', 'Annulation d\'effet de Piège'),
('BANMO', 'Bannir un Monstre'),
('CHPOSCOM', 'Changement de position de comb'),
('CITODE', 'Cimetière au Deck'),
('CITOTERR', 'Cimetière au Terrain'),
('DESMA', 'Destruction de Magie'),
('DESMON', 'Destruction de Monstre'),
('DESPI', 'Destruction de Piège'),
('DETOCI', 'Deck au Cimetière'),
('DETOMA', 'Deck à la Main'),
('DETOTER', 'Deck au Terrain'),
('DMGEFC', 'Dommages d\'effet'),
('DOATK', 'Diminution attaque'),
('DODEF', 'Diminution défense'),
('DOLP', 'Diminution des LP'),
('EFFRAP', 'Effet rapide'),
('INTEREFMA', 'Interruption effet de Magie'),
('INTEREFMO', 'Interruption effet de Monstre'),
('INTEREFPI', 'Interruption effet de Piege'),
('INVSPE', 'Invocation Spéciale'),
('MATOTER', 'Main au Terrain'),
('NORM', 'Normal/Lié aux monstres Normal'),
('ONEBYTURN', 'Une fois par tour'),
('PAR', 'Pari'),
('PIO', 'Pioche'),
('SYNTO', 'Syntoniseur'),
('TER', 'Terrain/Lié au Terrain'),
('TERTOCIM', 'Du Cimetière vers la Main'),
('UPATK', 'Augmentation d\'attaque'),
('UPDEF', 'Augmentation de défense'),
('UPLP', 'Augmentation des LP');

-- --------------------------------------------------------

--
-- Table structure for table `EFFET_CARTE`
--

CREATE TABLE `EFFET_CARTE` (
  `CODE_EFFET` varchar(12) NOT NULL,
  `NO_CARTE` bigint(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `EFFET_CARTE`
--

INSERT INTO `EFFET_CARTE` (`CODE_EFFET`, `NO_CARTE`) VALUES
('CITOTERR', 6),
('DETOTER', 6),
('EFFRAP', 6),
('INVSPE', 6),
('MATOTER', 6),
('NORM', 6),
('ONEBYTURN', 6),
('PIO', 5);

-- --------------------------------------------------------

--
-- Table structure for table `EFFET_STRAT`
--

CREATE TABLE `EFFET_STRAT` (
  `CODE_EFFET` varchar(12) NOT NULL,
  `CODE_STRAT` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `EFFET_STRAT`
--

INSERT INTO `EFFET_STRAT` (`CODE_EFFET`, `CODE_STRAT`) VALUES
('ANNULEFFMA', 'BL'),
('CHPOSCOM', 'BL'),
('CHPOSCOM', 'TEST'),
('DESMA', 'TEST');

-- --------------------------------------------------------

--
-- Table structure for table `INCLUS`
--

CREATE TABLE `INCLUS` (
  `NO_DECK` int(11) NOT NULL,
  `NO_CARTE` bigint(12) NOT NULL,
  `NB_EXEMPLAIRE` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `STRATEGIE`
--

CREATE TABLE `STRATEGIE` (
  `CODE_STRAT` varchar(12) NOT NULL,
  `NOM_STRAT` varchar(30) DEFAULT NULL,
  `RATIO_STARTER` int(3) DEFAULT NULL,
  `RATIO_EXTENDER` int(3) DEFAULT NULL,
  `RATIO_HANDTRAP` int(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `STRATEGIE`
--

INSERT INTO `STRATEGIE` (`CODE_STRAT`, `NOM_STRAT`, `RATIO_STARTER`, `RATIO_EXTENDER`, `RATIO_HANDTRAP`) VALUES
('BL', 'Yeux Bleus', 50, 30, 20),
('TEST', 'TEST', 50, 30, 20);

-- --------------------------------------------------------

--
-- Table structure for table `TYPE_USER`
--

CREATE TABLE `TYPE_USER` (
  `CD_TYPE` char(32) NOT NULL,
  `NOM_TYPE` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `TYPE_USER`
--

INSERT INTO `TYPE_USER` (`CD_TYPE`, `NOM_TYPE`) VALUES
('ADM', 'Administrateur'),
('JOU', 'Joueur');

-- --------------------------------------------------------

--
-- Table structure for table `UTILISATEUR`
--

CREATE TABLE `UTILISATEUR` (
  `USER` char(32) NOT NULL,
  `CD_TYPE` char(32) NOT NULL,
  `MDP` varchar(128) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `UTILISATEUR`
--

INSERT INTO `UTILISATEUR` (`USER`, `CD_TYPE`, `MDP`) VALUES
('Omuzoki', 'JOU', 'omuzoki'),
('Thomas', 'ADM', 'test');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ATTRIBUT_CARTE`
--
ALTER TABLE `ATTRIBUT_CARTE`
  ADD PRIMARY KEY (`CODE_ATTR_CARTE`);

--
-- Indexes for table `CARTE`
--
ALTER TABLE `CARTE`
  ADD PRIMARY KEY (`NO_CARTE`),
  ADD KEY `I_FK_CARTE_ATTRIBUT_CARTE` (`CODE_ATTR_CARTE`);

--
-- Indexes for table `COMBO`
--
ALTER TABLE `COMBO`
  ADD PRIMARY KEY (`CODE_EFFET`,`CODE_EFFET_1`,`CODE_STRAT`) USING BTREE,
  ADD KEY `I_FK_COMBO_EFFET` (`CODE_EFFET`),
  ADD KEY `I_FK_COMBO_EFFET1` (`CODE_EFFET_1`),
  ADD KEY `I_FK_COMBO_STRAT` (`CODE_STRAT`) USING BTREE;

--
-- Indexes for table `DECK`
--
ALTER TABLE `DECK`
  ADD PRIMARY KEY (`NO_DECK`),
  ADD KEY `I_FK_DECK_UTILISATEUR` (`USER`);

--
-- Indexes for table `EFFET`
--
ALTER TABLE `EFFET`
  ADD PRIMARY KEY (`CODE_EFFET`);

--
-- Indexes for table `EFFET_CARTE`
--
ALTER TABLE `EFFET_CARTE`
  ADD PRIMARY KEY (`CODE_EFFET`,`NO_CARTE`),
  ADD KEY `I_FK_EFFET_CARTE_EFFET` (`CODE_EFFET`),
  ADD KEY `I_FK_EFFET_CARTE_CARTE` (`NO_CARTE`);

--
-- Indexes for table `EFFET_STRAT`
--
ALTER TABLE `EFFET_STRAT`
  ADD PRIMARY KEY (`CODE_EFFET`,`CODE_STRAT`),
  ADD KEY `I_FK_EFFET_STRAT_EFFET` (`CODE_EFFET`),
  ADD KEY `I_FK_EFFET_STRAT_STRATEGIE` (`CODE_STRAT`);

--
-- Indexes for table `INCLUS`
--
ALTER TABLE `INCLUS`
  ADD PRIMARY KEY (`NO_DECK`,`NO_CARTE`),
  ADD KEY `I_FK_INCLUS_DECK` (`NO_DECK`),
  ADD KEY `I_FK_INCLUS_CARTE` (`NO_CARTE`);

--
-- Indexes for table `STRATEGIE`
--
ALTER TABLE `STRATEGIE`
  ADD PRIMARY KEY (`CODE_STRAT`);

--
-- Indexes for table `TYPE_USER`
--
ALTER TABLE `TYPE_USER`
  ADD PRIMARY KEY (`CD_TYPE`);

--
-- Indexes for table `UTILISATEUR`
--
ALTER TABLE `UTILISATEUR`
  ADD PRIMARY KEY (`USER`),
  ADD KEY `I_FK_UTILISATEUR_TYPE_USER` (`CD_TYPE`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `CARTE`
--
ALTER TABLE `CARTE`
  MODIFY `NO_CARTE` bigint(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `CARTE`
--
ALTER TABLE `CARTE`
  ADD CONSTRAINT `CARTE_ibfk_1` FOREIGN KEY (`CODE_ATTR_CARTE`) REFERENCES `ATTRIBUT_CARTE` (`CODE_ATTR_CARTE`);

--
-- Constraints for table `COMBO`
--
ALTER TABLE `COMBO`
  ADD CONSTRAINT `COMBO_ibfk_1` FOREIGN KEY (`CODE_EFFET`) REFERENCES `EFFET` (`CODE_EFFET`),
  ADD CONSTRAINT `COMBO_ibfk_2` FOREIGN KEY (`CODE_EFFET_1`) REFERENCES `EFFET` (`CODE_EFFET`);

--
-- Constraints for table `DECK`
--
ALTER TABLE `DECK`
  ADD CONSTRAINT `DECK_ibfk_1` FOREIGN KEY (`USER`) REFERENCES `UTILISATEUR` (`USER`);

--
-- Constraints for table `EFFET_CARTE`
--
ALTER TABLE `EFFET_CARTE`
  ADD CONSTRAINT `EFFET_CARTE_ibfk_1` FOREIGN KEY (`CODE_EFFET`) REFERENCES `EFFET` (`CODE_EFFET`),
  ADD CONSTRAINT `EFFET_CARTE_ibfk_2` FOREIGN KEY (`NO_CARTE`) REFERENCES `CARTE` (`NO_CARTE`);

--
-- Constraints for table `EFFET_STRAT`
--
ALTER TABLE `EFFET_STRAT`
  ADD CONSTRAINT `EFFET_STRAT_ibfk_1` FOREIGN KEY (`CODE_EFFET`) REFERENCES `EFFET` (`CODE_EFFET`),
  ADD CONSTRAINT `EFFET_STRAT_ibfk_2` FOREIGN KEY (`CODE_STRAT`) REFERENCES `STRATEGIE` (`CODE_STRAT`);

--
-- Constraints for table `INCLUS`
--
ALTER TABLE `INCLUS`
  ADD CONSTRAINT `INCLUS_ibfk_1` FOREIGN KEY (`NO_DECK`) REFERENCES `DECK` (`NO_DECK`),
  ADD CONSTRAINT `INCLUS_ibfk_2` FOREIGN KEY (`NO_CARTE`) REFERENCES `CARTE` (`NO_CARTE`);

--
-- Constraints for table `UTILISATEUR`
--
ALTER TABLE `UTILISATEUR`
  ADD CONSTRAINT `UTILISATEUR_ibfk_1` FOREIGN KEY (`CD_TYPE`) REFERENCES `TYPE_USER` (`CD_TYPE`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
