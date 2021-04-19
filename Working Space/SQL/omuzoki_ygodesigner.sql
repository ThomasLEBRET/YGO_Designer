-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Mar 19, 2021 at 08:41 AM
-- Server version: 5.7.31
-- PHP Version: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
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
-- Table structure for table `attribut_carte`
--

DROP TABLE IF EXISTS `attribut_carte`;
CREATE TABLE IF NOT EXISTS `attribut_carte` (
  `CODE_ATTR_CARTE` varchar(12) NOT NULL,
  `NOM_ATTR_CARTE` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`CODE_ATTR_CARTE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `attribut_carte`
--

INSERT INTO `attribut_carte` (`CODE_ATTR_CARTE`, `NOM_ATTR_CARTE`) VALUES
('MAG', 'Magie'),
('MON', 'Monstre'),
('PIE', 'Piège');

-- --------------------------------------------------------

--
-- Table structure for table `carte`
--

DROP TABLE IF EXISTS `carte`;
CREATE TABLE IF NOT EXISTS `carte` (
  `NO_CARTE` bigint(12) NOT NULL AUTO_INCREMENT,
  `CODE_ATTR_CARTE` varchar(12) NOT NULL,
  `NOM` varchar(100) DEFAULT NULL,
  `DESCRIPTION` text,
  `TYPE_MO` varchar(128) DEFAULT NULL,
  `ATTR_MO` varchar(128) DEFAULT NULL,
  `NIVEAU_MO` smallint(6) DEFAULT NULL,
  `TYPE_MA` varchar(128) DEFAULT NULL,
  `TYPE_PI` varchar(128) DEFAULT NULL,
  `ATK` int(11) DEFAULT NULL,
  `DEF` int(11) DEFAULT NULL,
  `TYPE_MONSTRE_CARTE` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`NO_CARTE`),
  KEY `I_FK_CARTE_ATTRIBUT_CARTE` (`CODE_ATTR_CARTE`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `carte`
--

INSERT INTO `carte` (`NO_CARTE`, `CODE_ATTR_CARTE`, `NOM`, `DESCRIPTION`, `TYPE_MO`, `ATTR_MO`, `NIVEAU_MO`, `TYPE_MA`, `TYPE_PI`, `ATK`, `DEF`, `TYPE_MONSTRE_CARTE`) VALUES
(1, 'MON', 'Justicia Dragarde', 'L\'avenir du Monde dépend des Dragardes nés de l\'Héritage du Monde.', 'Dragon', 'Eau', 2, '', NULL, 0, 2100, 'Syntoniseur'),
(2, 'MAG', 'Terra Formation', 'Ajouter 1 Magie de Terrain depuis votre Deck à votre main.', NULL, NULL, NULL, 'Normal', '', NULL, NULL, NULL),
(3, 'PIE', 'Métavers', 'Prenez 1 Magie de Terrain depuis votre Deck, et soit activez-la soit ajoutez-la à votre main.', NULL, NULL, NULL, NULL, 'Normal', NULL, NULL, ''),
(4, 'MAG', 'Raigeki', 'Détruisez tous les monstres contrôlés par votre adversaire', NULL, NULL, NULL, 'Normal', NULL, NULL, NULL, NULL),
(5, 'PIE', 'Métavers', 'Prenez 1 Magie de Terrain depuis votre Deck, et soit activez-la, soit ajoutez-la à votre main.', NULL, NULL, NULL, NULL, 'Normale', NULL, NULL, NULL),
(6, 'MON', 'Demoiselle aux Yeux Couleur Bleu\r\n', 'Lorsqu\'une carte ou un effet qui cible cette carte est activé (Effet Rapide) : vous pouvez Invoquer Spécialement 1 \"Dragon Blanc aux Yeux Bleus\" depuis votre main, Deck ou Cimetière. Lorsque cette carte est ciblée par une attaque : vous pouvez annuler l\'attaque, et si vous le faites, changez la position de combat de cette carte, puis vous pouvez Invoquer Spécialement 1 \"Dragon Blanc aux Yeux Bleus\" depuis votre main, Deck ou Cimetière. Vous ne pouvez utiliser qu\'1 effet de \"Demoiselle aux Yeux Couleur Bleu\" par tour, et uniquement une fois le tour.', 'Magicien', 'Lumiere', 1, NULL, NULL, 0, 0, 'Syntoniseur');

--
-- Triggers `carte`
--
DROP TRIGGER IF EXISTS `delete_effets_carte`;
DELIMITER $$
CREATE TRIGGER `delete_effets_carte` BEFORE DELETE ON `carte` FOR EACH ROW BEGIN
      DELETE FROM EFFET_CARTE WHERE NO_CARTE = old.NO_CARTE;
      END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `combo`
--

DROP TABLE IF EXISTS `combo`;
CREATE TABLE IF NOT EXISTS `combo` (
  `CODE_EFFET` varchar(12) NOT NULL,
  `CODE_EFFET_1` varchar(12) NOT NULL,
  `CODE_STRAT` varchar(12) NOT NULL,
  `POIDS` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`CODE_EFFET`,`CODE_EFFET_1`,`CODE_STRAT`),
  KEY `I_FK_COMBO_EFFET` (`CODE_EFFET`),
  KEY `I_FK_COMBO_EFFET1` (`CODE_EFFET_1`),
  KEY `I_FK_COMBO_STRATEGIE` (`CODE_STRAT`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `combo`
--

INSERT INTO `combo` (`CODE_EFFET`, `CODE_EFFET_1`, `CODE_STRAT`, `POIDS`) VALUES
('CHPOSCOM', 'ANNULEFFMA', 'BL', 1),
('ANNULEFFMA', 'CHPOSCOM', 'BL', -1);

-- --------------------------------------------------------

--
-- Table structure for table `deck`
--

DROP TABLE IF EXISTS `deck`;
CREATE TABLE IF NOT EXISTS `deck` (
  `NO_DECK` int(11) NOT NULL,
  `USER` char(32) NOT NULL,
  `NOM_DECK` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`NO_DECK`),
  KEY `I_FK_DECK_UTILISATEUR` (`USER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `deck`
--

INSERT INTO `deck` (`NO_DECK`, `USER`, `NOM_DECK`) VALUES
(1, 'Omuzoki', 'Deck de test');

-- --------------------------------------------------------

--
-- Table structure for table `effet`
--

DROP TABLE IF EXISTS `effet`;
CREATE TABLE IF NOT EXISTS `effet` (
  `CODE_EFFET` varchar(12) NOT NULL,
  `NOM_EFFET` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`CODE_EFFET`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `effet`
--

INSERT INTO `effet` (`CODE_EFFET`, `NOM_EFFET`) VALUES
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
-- Table structure for table `effet_carte`
--

DROP TABLE IF EXISTS `effet_carte`;
CREATE TABLE IF NOT EXISTS `effet_carte` (
  `CODE_EFFET` varchar(12) NOT NULL,
  `NO_CARTE` bigint(12) NOT NULL,
  PRIMARY KEY (`CODE_EFFET`,`NO_CARTE`),
  KEY `I_FK_EFFET_CARTE_EFFET` (`CODE_EFFET`),
  KEY `I_FK_EFFET_CARTE_CARTE` (`NO_CARTE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `effet_carte`
--

INSERT INTO `effet_carte` (`CODE_EFFET`, `NO_CARTE`) VALUES
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
-- Table structure for table `effet_strat`
--

DROP TABLE IF EXISTS `effet_strat`;
CREATE TABLE IF NOT EXISTS `effet_strat` (
  `CODE_EFFET` varchar(12) NOT NULL,
  `CODE_STRAT` varchar(12) NOT NULL,
  PRIMARY KEY (`CODE_EFFET`,`CODE_STRAT`),
  KEY `I_FK_EFFET_STRAT_EFFET` (`CODE_EFFET`),
  KEY `I_FK_EFFET_STRAT_STRATEGIE` (`CODE_STRAT`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `effet_strat`
--

INSERT INTO `effet_strat` (`CODE_EFFET`, `CODE_STRAT`) VALUES
('ANNULEFFMA', 'BL'),
('CHPOSCOM', 'BL'),
('CHPOSCOM', 'TEST'),
('DESMA', 'TEST');

-- --------------------------------------------------------

--
-- Table structure for table `inclus`
--

DROP TABLE IF EXISTS `inclus`;
CREATE TABLE IF NOT EXISTS `inclus` (
  `NO_DECK` int(11) NOT NULL,
  `NO_CARTE` bigint(12) NOT NULL,
  PRIMARY KEY (`NO_DECK`,`NO_CARTE`),
  KEY `I_FK_INCLUS_DECK` (`NO_DECK`),
  KEY `I_FK_INCLUS_CARTE` (`NO_CARTE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `strategie`
--

DROP TABLE IF EXISTS `strategie`;
CREATE TABLE IF NOT EXISTS `strategie` (
  `CODE_STRAT` varchar(12) NOT NULL,
  `NOM_STRAT` varchar(30) DEFAULT NULL,
  `RATIO_STARTER` smallint(6) DEFAULT NULL,
  `RATIO_EXTENDER` smallint(6) DEFAULT NULL,
  `RATIO_HANDTRAP` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`CODE_STRAT`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `strategie`
--

INSERT INTO `strategie` (`CODE_STRAT`, `NOM_STRAT`, `RATIO_STARTER`, `RATIO_EXTENDER`, `RATIO_HANDTRAP`) VALUES
('BL', 'Yeux Bleus', 50, 30, 20),
('TEST', 'TEST', 50, 30, 20);

-- --------------------------------------------------------

--
-- Table structure for table `type_user`
--

DROP TABLE IF EXISTS `type_user`;
CREATE TABLE IF NOT EXISTS `type_user` (
  `CD_TYPE` char(32) NOT NULL,
  `NOM_TYPE` char(32) DEFAULT NULL,
  PRIMARY KEY (`CD_TYPE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `type_user`
--

INSERT INTO `type_user` (`CD_TYPE`, `NOM_TYPE`) VALUES
('ADM', 'Administrateur'),
('JOU', 'Joueur');

-- --------------------------------------------------------

--
-- Table structure for table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `USER` char(32) NOT NULL,
  `CD_TYPE` char(32) NOT NULL,
  `MDP` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`USER`),
  KEY `I_FK_UTILISATEUR_TYPE_USER` (`CD_TYPE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `utilisateur`
--

INSERT INTO `utilisateur` (`USER`, `CD_TYPE`, `MDP`) VALUES
('Omuzoki', 'JOU', 'omuzoki'),
('Thomas', 'ADM', 'test');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
