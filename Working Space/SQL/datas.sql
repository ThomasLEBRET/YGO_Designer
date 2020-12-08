INSERT INTO `type_user` (`CD_TYPE`, `NOM_TYPE`) VALUES
('ADM', 'Administrateur'),
('JOU', 'Joueur');

INSERT INTO `utilisateur` (`USER`, `CD_TYPE`, `MDP`) VALUES
('Omuzoki', 'JOU', 'omuzoki'),
('Thomas', 'ADM', 'test');

INSERT INTO `deck` (`NO_DECK`, `USER`, `NOM_DECK`) VALUES
(1, 'Omuzoki', 'Deck de test');

INSERT INTO `attribut_carte` (`CODE_ATTR_CARTE`, `NOM_ATTR_CARTE`) VALUES
('MAG', 'Magie'),
('MON', 'Monstre'),
('PIE', 'Piège');

INSERT INTO `carte` (`NO_CARTE`, `CODE_ATTR_CARTE`, `NOM`, `DESCRIPTION`, `TYPE_MO`, `ATTR_MO`, `NIVEAU_MO`, `TYPE_MA`, `TYPE_PI`, `ATK`, `DEF`, `TYPE_MONSTRE_CARTE`) VALUES
(1, 'MON', 'Justicia Dragarde', 'L\'avenir du Monde dépend des Dragardes nés de l\'Héritage du Monde.', 'Dragon', 'Eau', 2, '', NULL, 0, 2100, 'Syntoniseur'),
(2, 'MAG', 'Terra Formation', 'Ajouter 1 Magie de Terrain depuis votre Deck à votre main.', NULL, NULL, NULL, 'Normal', '', NULL, NULL, NULL),
(3, 'PIE', 'Métavers', 'Prenez 1 Magie de Terrain depuis votre Deck, et soit activez-la soit ajoutez-la à votre main.', NULL, NULL, NULL, NULL, 'Normal', NULL, NULL, ''),
(4, 'MAG', 'Raigeki', 'Détruisez tous les monstres contrôlés par votre adversaire', NULL, NULL, NULL, 'Normal', NULL, NULL, NULL, NULL),
(5, 'PIE', 'Métavers', 'Prenez 1 Magie de Terrain depuis votre Deck, et soit activez-la, soit ajoutez-la à votre main.', NULL, NULL, NULL, NULL, 'Normale', NULL, NULL, NULL),
(6, 'MON', 'Demoiselle aux Yeux Couleur Bleu\r\n', 'Lorsqu\'une carte ou un effet qui cible cette carte est activé (Effet Rapide) : vous pouvez Invoquer Spécialement 1 \"Dragon Blanc aux Yeux Bleus\" depuis votre main, Deck ou Cimetière. Lorsque cette carte est ciblée par une attaque : vous pouvez annuler l\'attaque, et si vous le faites, changez la position de combat de cette carte, puis vous pouvez Invoquer Spécialement 1 \"Dragon Blanc aux Yeux Bleus\" depuis votre main, Deck ou Cimetière. Vous ne pouvez utiliser qu\'1 effet de \"Demoiselle aux Yeux Couleur Bleu\" par tour, et uniquement une fois le tour.', 'Magicien', 'Lumiere', 1, NULL, NULL, 0, 0, 'Syntoniseur');


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

INSERT INTO `effet_carte` (`CODE_EFFET`, `NO_CARTE`) VALUES
('PIO', 5),
('CITOTERR', 6),
('DETOTER', 6),
('EFFRAP', 6),
('INVSPE', 6),
('MATOTER', 6),
('NORM', 6),
('ONEBYTURN', 6);

INSERT INTO `strategie` (`CODE_STRAT`, `NOM_STRAT`, `RATIO_STARTER`, `RATIO_EXTENDER`, `RATIO_HANDTRAP`) VALUES
('BL', 'Yeux Bleus', 50, 30, 20),
('TEST', 'TEST', 50, 30, 20);

INSERT INTO `effet_strat` (`CODE_EFFET`, `CODE_STRAT`) VALUES
('ANNULEFFMA', 'BL'),
('CHPOSCOM', 'BL'),
('CHPOSCOM', 'TEST'),
('DESMA', 'TEST');



CREATE TRIGGER `delete_effets_carte` BEFORE DELETE ON `carte`
 FOR EACH ROW BEGIN
DELETE FROM EFFET_CARTE WHERE NO_CARTE = old.NO_CARTE;
END
