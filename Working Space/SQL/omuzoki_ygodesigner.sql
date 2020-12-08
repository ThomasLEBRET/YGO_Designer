DROP DATABASE IF EXISTS omuzoki_ygodesigner;

CREATE DATABASE IF NOT EXISTS omuzoki_ygodesigner;
USE omuzoki_ygodesigner;
# -----------------------------------------------------------------------------
#       TABLE : STRATEGIE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS STRATEGIE
 (
   CODE_STRAT VARCHAR(12) NOT NULL  ,
   NOM_STRAT VARCHAR(30) NULL  ,
   RATIO_STARTER SMALLINT NULL  ,
   RATIO_EXTENDER SMALLINT NULL  ,
   RATIO_HANTRAP SMALLINT NULL
   , PRIMARY KEY (CODE_STRAT)
 )
 comment = "";
 ALTER TABLE STRATEGIE CHANGE `RATIO_HANTRAP` `RATIO_HANDTRAP` SMALLINT NULL;

# -----------------------------------------------------------------------------
#       TABLE : UTILISATEUR
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS UTILISATEUR
 (
   USER CHAR(32) NOT NULL  ,
   CD_TYPE CHAR(32) NOT NULL  ,
   MDP VARCHAR(128) NULL
   , PRIMARY KEY (USER)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       INDEX DE LA TABLE UTILISATEUR
# -----------------------------------------------------------------------------


CREATE  INDEX I_FK_UTILISATEUR_TYPE_USER
     ON UTILISATEUR (CD_TYPE ASC);

# -----------------------------------------------------------------------------
#       TABLE : EFFET
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS EFFET
 (
   CODE_EFFET VARCHAR(12) NOT NULL  ,
   NOM_EFFET VARCHAR(30) NULL
   , PRIMARY KEY (CODE_EFFET)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       TABLE : CARTE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS CARTE
 (
   NO_CARTE BIGINT(12) NOT NULL AUTO_INCREMENT ,
   CODE_ATTR_CARTE VARCHAR(12) NOT NULL  ,
   NOM VARCHAR(100) NULL  ,
   DESCRIPTION TEXT NULL  ,
   TYPE_MO VARCHAR(128) NULL  ,
   ATTR_MO VARCHAR(128) NULL  ,
   NIVEAU_MO SMALLINT NULL  ,
   TYPE_MA VARCHAR(128) NULL  ,
   TYPE_PI VARCHAR(128) NULL  ,
   ATK INTEGER NULL  ,
   DEF INTEGER NULL  ,
   TYPE_MONSTRE_CARTE VARCHAR(50) NULL
   , PRIMARY KEY (NO_CARTE)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       INDEX DE LA TABLE CARTE
# -----------------------------------------------------------------------------


CREATE  INDEX I_FK_CARTE_ATTRIBUT_CARTE
     ON CARTE (CODE_ATTR_CARTE ASC);

# -----------------------------------------------------------------------------
#       TABLE : ATTRIBUT_CARTE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS ATTRIBUT_CARTE
 (
   CODE_ATTR_CARTE VARCHAR(12) NOT NULL  ,
   NOM_ATTR_CARTE VARCHAR(15) NULL
   , PRIMARY KEY (CODE_ATTR_CARTE)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       TABLE : TYPE_USER
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS TYPE_USER
 (
   CD_TYPE CHAR(32) NOT NULL  ,
   NOM_TYPE CHAR(32) NULL
   , PRIMARY KEY (CD_TYPE)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       TABLE : DECK
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS DECK
 (
   NO_DECK INTEGER NOT NULL  ,
   USER CHAR(32) NOT NULL  ,
   NOM_DECK VARCHAR(30) NULL
   , PRIMARY KEY (NO_DECK)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       INDEX DE LA TABLE DECK
# -----------------------------------------------------------------------------


CREATE  INDEX I_FK_DECK_UTILISATEUR
     ON DECK (USER ASC);

# -----------------------------------------------------------------------------
#       TABLE : COMBO
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS COMBO
 (
   CODE_EFFET VARCHAR(12) NOT NULL  ,
   CODE_EFFET_1 VARCHAR(12) NOT NULL  ,
   CODE_STRAT VARCHAR(12) NOT NULL  ,
   POIDS SMALLINT NULL
   , PRIMARY KEY (CODE_EFFET,CODE_EFFET_1,CODE_STRAT)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       INDEX DE LA TABLE COMBO
# -----------------------------------------------------------------------------


CREATE  INDEX I_FK_COMBO_EFFET
     ON COMBO (CODE_EFFET ASC);

CREATE  INDEX I_FK_COMBO_EFFET1
     ON COMBO (CODE_EFFET_1 ASC);

CREATE  INDEX I_FK_COMBO_STRATEGIE
     ON COMBO (CODE_STRAT ASC);

# -----------------------------------------------------------------------------
#       TABLE : EFFET_STRAT
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS EFFET_STRAT
 (
   CODE_EFFET VARCHAR(12) NOT NULL  ,
   CODE_STRAT VARCHAR(12) NOT NULL
   , PRIMARY KEY (CODE_EFFET,CODE_STRAT)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       INDEX DE LA TABLE EFFET_STRAT
# -----------------------------------------------------------------------------


CREATE  INDEX I_FK_EFFET_STRAT_EFFET
     ON EFFET_STRAT (CODE_EFFET ASC);

CREATE  INDEX I_FK_EFFET_STRAT_STRATEGIE
     ON EFFET_STRAT (CODE_STRAT ASC);

# -----------------------------------------------------------------------------
#       TABLE : EFFET_CARTE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS EFFET_CARTE
 (
   CODE_EFFET VARCHAR(12) NOT NULL  ,
   NO_CARTE BIGINT(12) NOT NULL
   , PRIMARY KEY (CODE_EFFET,NO_CARTE)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       INDEX DE LA TABLE EFFET_CARTE
# -----------------------------------------------------------------------------


CREATE  INDEX I_FK_EFFET_CARTE_EFFET
     ON EFFET_CARTE (CODE_EFFET ASC);

CREATE  INDEX I_FK_EFFET_CARTE_CARTE
     ON EFFET_CARTE (NO_CARTE ASC);

# -----------------------------------------------------------------------------
#       TABLE : INCLUS
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS INCLUS
 (
   NO_DECK INTEGER NOT NULL  ,
   NO_CARTE BIGINT(12) NOT NULL
   , PRIMARY KEY (NO_DECK,NO_CARTE)
 )
 comment = "";

# -----------------------------------------------------------------------------
#       INDEX DE LA TABLE INCLUS
# -----------------------------------------------------------------------------


CREATE  INDEX I_FK_INCLUS_DECK
     ON INCLUS (NO_DECK ASC);

CREATE  INDEX I_FK_INCLUS_CARTE
     ON INCLUS (NO_CARTE ASC);


# -----------------------------------------------------------------------------
#       CREATION DES REFERENCES DE TABLE
# -----------------------------------------------------------------------------


ALTER TABLE UTILISATEUR
  ADD FOREIGN KEY FK_UTILISATEUR_TYPE_USER (CD_TYPE)
      REFERENCES TYPE_USER (CD_TYPE) ;


ALTER TABLE CARTE
  ADD FOREIGN KEY FK_CARTE_ATTRIBUT_CARTE (CODE_ATTR_CARTE)
      REFERENCES ATTRIBUT_CARTE (CODE_ATTR_CARTE) ;


ALTER TABLE DECK
  ADD FOREIGN KEY FK_DECK_UTILISATEUR (USER)
      REFERENCES UTILISATEUR (USER) ;


ALTER TABLE COMBO
  ADD FOREIGN KEY FK_COMBO_EFFET (CODE_EFFET)
      REFERENCES EFFET (CODE_EFFET) ;


ALTER TABLE COMBO
  ADD FOREIGN KEY FK_COMBO_EFFET1 (CODE_EFFET_1)
      REFERENCES EFFET (CODE_EFFET) ;


ALTER TABLE COMBO
  ADD FOREIGN KEY FK_COMBO_STRATEGIE (CODE_STRAT)
      REFERENCES STRATEGIE (CODE_STRAT) ;


ALTER TABLE EFFET_STRAT
  ADD FOREIGN KEY FK_EFFET_STRAT_EFFET (CODE_EFFET)
      REFERENCES EFFET (CODE_EFFET) ;


ALTER TABLE EFFET_STRAT
  ADD FOREIGN KEY FK_EFFET_STRAT_STRATEGIE (CODE_STRAT)
      REFERENCES STRATEGIE (CODE_STRAT) ;


ALTER TABLE EFFET_CARTE
  ADD FOREIGN KEY FK_EFFET_CARTE_EFFET (CODE_EFFET)
      REFERENCES EFFET (CODE_EFFET) ;


ALTER TABLE EFFET_CARTE
  ADD FOREIGN KEY FK_EFFET_CARTE_CARTE (NO_CARTE)
      REFERENCES CARTE (NO_CARTE) ;


ALTER TABLE INCLUS
  ADD FOREIGN KEY FK_INCLUS_DECK (NO_DECK)
      REFERENCES DECK (NO_DECK) ;


ALTER TABLE INCLUS
  ADD FOREIGN KEY FK_INCLUS_CARTE (NO_CARTE)
      REFERENCES CARTE (NO_CARTE) ;

      INSERT INTO `TYPE_USER` (`CD_TYPE`, `NOM_TYPE`) VALUES
      ('ADM', 'Administrateur'),
      ('JOU', 'Joueur');

      INSERT INTO `UTILISATEUR` (`USER`, `CD_TYPE`, `MDP`) VALUES
      ('Omuzoki', 'JOU', 'omuzoki'),
      ('Thomas', 'ADM', 'test');

      INSERT INTO `DECK` (`NO_DECK`, `USER`, `NOM_DECK`) VALUES
      (1, 'Omuzoki', 'Deck de test');

      INSERT INTO `ATTRIBUT_CARTE` (`CODE_ATTR_CARTE`, `NOM_ATTR_CARTE`) VALUES
      ('MAG', 'Magie'),
      ('MON', 'Monstre'),
      ('PIE', 'Piège');

      INSERT INTO `CARTE` (`NO_CARTE`, `CODE_ATTR_CARTE`, `NOM`, `DESCRIPTION`, `TYPE_MO`, `ATTR_MO`, `NIVEAU_MO`, `TYPE_MA`, `TYPE_PI`, `ATK`, `DEF`, `TYPE_MONSTRE_CARTE`) VALUES
      (1, 'MON', 'Justicia Dragarde', 'L\'avenir du Monde dépend des Dragardes nés de l\'Héritage du Monde.', 'Dragon', 'Eau', 2, '', NULL, 0, 2100, 'Syntoniseur'),
      (2, 'MAG', 'Terra Formation', 'Ajouter 1 Magie de Terrain depuis votre Deck à votre main.', NULL, NULL, NULL, 'Normal', '', NULL, NULL, NULL),
      (3, 'PIE', 'Métavers', 'Prenez 1 Magie de Terrain depuis votre Deck, et soit activez-la soit ajoutez-la à votre main.', NULL, NULL, NULL, NULL, 'Normal', NULL, NULL, ''),
      (4, 'MAG', 'Raigeki', 'Détruisez tous les monstres contrôlés par votre adversaire', NULL, NULL, NULL, 'Normal', NULL, NULL, NULL, NULL),
      (5, 'PIE', 'Métavers', 'Prenez 1 Magie de Terrain depuis votre Deck, et soit activez-la, soit ajoutez-la à votre main.', NULL, NULL, NULL, NULL, 'Normale', NULL, NULL, NULL),
      (6, 'MON', 'Demoiselle aux Yeux Couleur Bleu\r\n', 'Lorsqu\'une carte ou un effet qui cible cette carte est activé (Effet Rapide) : vous pouvez Invoquer Spécialement 1 \"Dragon Blanc aux Yeux Bleus\" depuis votre main, Deck ou Cimetière. Lorsque cette carte est ciblée par une attaque : vous pouvez annuler l\'attaque, et si vous le faites, changez la position de combat de cette carte, puis vous pouvez Invoquer Spécialement 1 \"Dragon Blanc aux Yeux Bleus\" depuis votre main, Deck ou Cimetière. Vous ne pouvez utiliser qu\'1 effet de \"Demoiselle aux Yeux Couleur Bleu\" par tour, et uniquement une fois le tour.', 'Magicien', 'Lumiere', 1, NULL, NULL, 0, 0, 'Syntoniseur');


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

      INSERT INTO `EFFET_CARTE` (`CODE_EFFET`, `NO_CARTE`) VALUES
      ('PIO', 5),
      ('CITOTERR', 6),
      ('DETOTER', 6),
      ('EFFRAP', 6),
      ('INVSPE', 6),
      ('MATOTER', 6),
      ('NORM', 6),
      ('ONEBYTURN', 6);

      INSERT INTO `STRATEGIE` (`CODE_STRAT`, `NOM_STRAT`, `RATIO_STARTER`, `RATIO_EXTENDER`, `RATIO_HANDTRAP`) VALUES
      ('BL', 'Yeux Bleus', 50, 30, 20),
      ('TEST', 'TEST', 50, 30, 20);

      INSERT INTO `EFFET_STRAT` (`CODE_EFFET`, `CODE_STRAT`) VALUES
      ('ANNULEFFMA', 'BL'),
      ('CHPOSCOM', 'BL'),
      ('CHPOSCOM', 'TEST'),
      ('DESMA', 'TEST');


DELIMITER |
      CREATE TRIGGER `delete_effets_carte` BEFORE DELETE ON `CARTE`
       FOR EACH ROW BEGIN
      DELETE FROM EFFET_CARTE WHERE NO_CARTE = old.NO_CARTE;
      END|
