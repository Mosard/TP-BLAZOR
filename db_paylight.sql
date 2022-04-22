-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mar. 19 oct. 2021 à 09:06
-- Version du serveur :  5.7.21
-- Version de PHP :  5.6.35

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `db_paylight`
--

DELIMITER $$
--
-- Procédures
--
DROP PROCEDURE IF EXISTS `proc_Save_Ab`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Ab` (IN `montant` FLOAT, IN `id_Client` INT, IN `id_Compteur` INT)  NO SQL
INSERT INTO tabonnement(statutAbonnement,montant, dateAbonnement, dateDesactivation,id_Client,id_Compteur) VALUES('ACTIF',montant,Now(),null,id_Client,id_Compteur)$$

DROP PROCEDURE IF EXISTS `proc_Save_Abonnement`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Abonnement` (IN `codeAb` INT, IN `montant` FLOAT, IN `id_Client` INT, IN `id_Compteur` INT, IN `numero` VARCHAR(50), IN `foreignKeyAv` INT, IN `id_Parcelle` INT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tabonnement WHERE id = codeAb) THEN
	INSERT INTO tabonnement(statutAbonnement,montant, dateAbonnement, dateDesactivation,id_Client,id_Compteur,id_Parcelle) VALUES('ACTIF',montant,Now(),null,id_Client,id_Compteur,id_Parcelle);
    
    	INSERT INTO tparcelle(numeroParcelle,id_Avenue,id_Client) VALUES(numero,foreignKeyAv,id_Client);
INSERT INTO tpaiement(montant, datePmt,id_Abonnement) VALUES(montant,Now(),codeAb);
INSERT INTO tachat (montant,dateAchat,dateExpiration,statusAchat,AchatId,id_tCompteur) VALUES(0,NOW(),NOW(),'-','-',id_Compteur);
        
UPDATE tcompteur SET statusCompteur='Used' WHERE id = id_Compteur;

ELSEIF EXISTS(SELECT *FROM tabonnement WHERE id = codeAb) THEN
	UPDATE tabonnement SET statutAbonnement=statutAbonnement,montant=montant,id_Client=id_Client,id_Compteur=id_Compteur WHERE id = codeAb;
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Achat`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Achat` (IN `codeA` INT, IN `montant` INT, IN `idtCompteur` INT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tachat WHERE id = codeA) THEN
	INSERT INTO tachat(montant,dateAchat,dateExpiration,   statusAchat, AchatId,id_tCompteur) VALUES(montant,NOW(),fun_Date_Add(idtCompteur,montant),
                                                                                        fun_AchatID(),'Non Activer',idtCompteur);
ELSEIF EXISTS(SELECT *FROM tachat WHERE id = codeA) THEN
	UPDATE tachat SET montant = montant, dateExpiration =fun_Date_Add(idtCompteur,montant), id_tCompteur=idtCompteur WHERE id = codeA; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Av`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Av` (IN `code` INT, IN `designation` VARCHAR(50), IN `foreignKey` INT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tavenue WHERE id = code) THEN
	INSERT INTO tavenue(designation,id_quartier) VALUES(designation,foreignKey);
ELSEIF EXISTS(SELECT *FROM tavenue WHERE id = code) THEN
	UPDATE tavenue SET designation = designation, id_quartier =foreignKey WHERE id = code; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Client`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Client` (IN `code` INT, IN `nom` VARCHAR(50), IN `postnom` VARCHAR(50), IN `prenom` VARCHAR(50), IN `profession` VARCHAR(50), IN `email` VARCHAR(50), IN `tel1_` VARCHAR(50), IN `tel2_` VARCHAR(50))  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tclient WHERE id = code) THEN
	INSERT INTO tclient(nom, postnom,prenom,profession,email,tel1,tel2,statusClient) VALUES(nom,postnom,prenom,profession,email,tel1_,tel2_,0);
ELSEIF EXISTS(SELECT *FROM tclient WHERE id = code) THEN
	UPDATE `tclient` SET `nom`=nom,`postnom`=postnom,`prenom`=prenom,`profession`=profession,`email`=email,tel1=tel1_,tel2=tel2_ WHERE id=code;
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Commune`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Commune` (IN `code` INT, IN `designation` VARCHAR(50), IN `ville` VARCHAR(50), IN `province` VARCHAR(50))  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tcommune WHERE id = code) THEN
	INSERT INTO tcommune(designation, ville, province) VALUES(designation,ville,province);
ELSEIF EXISTS(SELECT *FROM tcommune WHERE id = code) THEN
	UPDATE tcommune SET designation =  designation, ville=ville,province=province WHERE id = code; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Compteur`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Compteur` (IN `code` INT, IN `numero` VARCHAR(50), IN `foreignKey` INT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tcompteur WHERE id = code) THEN
	INSERT INTO tcompteur(numeroCompteur,id_typeCompteur, statusCompteur) VALUES(fun_GenerateNumCompteur(),foreignKey,'Available');
ELSEIF EXISTS(SELECT *FROM tcompteur WHERE id = code) THEN
	UPDATE tcompteur SET id_typeCompteur =foreignKey,statusCompteur = 'Available' WHERE id = code; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Fonction`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Fonction` (IN `code` INT, IN `designation` VARCHAR(50), IN `LevelAccess` INT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tfonction WHERE id = code) THEN
	INSERT INTO tfonction(designation,LevelAccess) VALUES(designation,LevelAccess);
ELSEIF EXISTS(SELECT *FROM tfonction WHERE id = code) THEN
	UPDATE tfonction SET designation = designation, LevelAccess=LevelAccess WHERE id = code; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Paiement`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Paiement` (IN `code` INT, IN `montant` FLOAT, IN `foreignKeyAb` INT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tpaiement WHERE id = code) THEN
	INSERT INTO tpaiement(montant,datePmt,id_Abonnement) VALUES(montant,Now(),foreignKeyAb) ;
ELSEIF EXISTS(SELECT *FROM tpaiement WHERE id = code) THEN
	UPDATE tpaiement SET montant = montant, id_Abonnement =foreignKeyAb WHERE id = code; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Parcelle`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Parcelle` (IN `code` INT, IN `numero` VARCHAR(50), IN `foreignKeyAv` INT, IN `foreignKeyCl` INT, IN `codeParcel` VARCHAR(50))  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tparcelle WHERE id = code) THEN
	INSERT INTO tparcelle(codeParcelle,numeroParcelle,id_Avenue,id_Client) VALUES(codeParcel,numero,foreignKeyAv,foreignKeyCl);
ELSEIF EXISTS(SELECT *FROM tparcelle WHERE id = code) THEN
	UPDATE tparcelle SET numeroParcelle =numero, id_Avenue = foreignKeyAv,id_Client=foreignKeyCl WHERE id = code; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_Qt`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_Qt` (IN `code` INT, IN `designation` VARCHAR(50), IN `foreignKey` INT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tquartier WHERE id = code) THEN
	INSERT INTO tquartier(designation,id_commune) VALUES(designation,foreignKey);
ELSEIF EXISTS(SELECT *FROM tquartier WHERE id = code) THEN
	UPDATE tquartier SET designation = designation, id_commune =foreignKey WHERE id = code; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_typeCompteur`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_typeCompteur` (IN `code` INT, IN `designation` VARCHAR(50), IN `montantParKws` FLOAT, IN `montantAb` FLOAT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM ttypecompteur WHERE id = code) THEN
	INSERT INTO ttypecompteur(designation,montantParKw,montantAb) VALUES(designation,montantParKws);
ELSEIF EXISTS(SELECT *FROM ttypecompteur WHERE id = code) THEN
	UPDATE ttypecompteur SET designation = designation, montantParKw =montantParKws, montantAbonnement=montantAb WHERE id = code; 
END IF;
END$$

DROP PROCEDURE IF EXISTS `proc_Save_User`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_Save_User` (IN `codeus` INT, IN `usern` VARCHAR(50), IN `pass` VARCHAR(50), IN `_email` VARCHAR(50), IN `phoneus` VARCHAR(50), IN `idF` INT)  NO SQL
BEGIN
IF NOT EXISTS(SELECT *FROM tusers WHERE code = codeus) THEN
	INSERT INTO tusers(userN,passCode,emailUser,phone,id_Fonction,statusUsers) VALUES(usern,pass,_email,phoneus,idF,0);
ELSEIF EXISTS(SELECT *FROM tusers WHERE code = codeus) THEN
	UPDATE tusers SET userN=usern,passCode=pass,emailUser=_email,phone=phoneus,id_Fonction=idF, statusUsers=0 WHERE code= codeus;
END IF;
END$$

--
-- Fonctions
--
DROP FUNCTION IF EXISTS `fun_AchatID`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `fun_AchatID` () RETURNS VARCHAR(250) CHARSET latin1 NO SQL
BEGIN
DECLARE va2 varchar(250);
SET va2= (SELECT 
  Concat (
      	 FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5),
         FLOOR(RAND()*(10-5+1)+5)));
          RETURN va2;
 END$$

DROP FUNCTION IF EXISTS `fun_Date_Add`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `fun_Date_Add` (`idCompteur` INT, `montantParKws` INT) RETURNS DATE NO SQL
BEGIN
DECLARE val1 date;
DECLARE val2 int;
DECLARE val3 int;


SET val3 =  (SELECT TRUNCATE(100/30, 0));
  SET val1 = (select MAX(DATE(dateExpiration)) FROM tachat WHERE id_tCompteur = idCompteur);
  SET val2 = (select montantParKw FROM v_compteurall where id  = idCompteur)+ val3;
  RETURN val1+(val2);
END$$

DROP FUNCTION IF EXISTS `fun_GenerateNumCompteur`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `fun_GenerateNumCompteur` () RETURNS VARCHAR(50) CHARSET latin1 NO SQL
BEGIN
DECLARE va2 varchar(100);
  SET va2 = (select concat('COMP',COUNT(Id)+1,'-',(SELECT YEAR(CURRENT_DATE))) from tcompteur);
  RETURN va2;
END$$

DROP FUNCTION IF EXISTS `fun_ResterAbonnement`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `fun_ResterAbonnement` (`code` INT, `compteur` VARCHAR(50)) RETURNS FLOAT NO SQL
BEGIN
DECLARE va2 float;
DECLARE val1 float;

  SET val1 = (SELECT ttypecompteur.montantAbonnement FROM tcompteur 
  INNER JOIN ttypecompteur 
  ON tcompteur.id_typeCompteur=ttypecompteur.id WHERE tcompteur.numeroCompteur=
            compteur);
  SET va2 = (select SUM(Montant) FROM tAbonnement where id  = code);
  RETURN val1-va2;
END$$

DROP FUNCTION IF EXISTS `fun_ResterAbonnement_Paiement`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `fun_ResterAbonnement_Paiement` (`code` INT, `compteur` VARCHAR(50)) RETURNS FLOAT NO SQL
BEGIN
DECLARE va2 float;
DECLARE val1 float;

  SET val1 = (SELECT ttypecompteur.montantAbonnement FROM tcompteur 
  INNER JOIN ttypecompteur 
  ON tcompteur.id_typeCompteur=ttypecompteur.id WHERE tcompteur.numeroCompteur= compteur);
SET va2=(select SUM(Montant)FROM tpaiement where id_Abonnement = code);
  RETURN val1-va2;
  
  END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `abonnement_all`
-- (Voir ci-dessous la vue réelle)
--
DROP VIEW IF EXISTS `abonnement_all`;
CREATE TABLE IF NOT EXISTS `abonnement_all` (
);

-- --------------------------------------------------------

--
-- Structure de la table `tabonnement`
--

DROP TABLE IF EXISTS `tabonnement`;
CREATE TABLE IF NOT EXISTS `tabonnement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `statutAbonnement` varchar(50) NOT NULL,
  `montant` float NOT NULL,
  `dateAbonnement` datetime NOT NULL,
  `dateDesactivation` datetime DEFAULT NULL,
  `id_Client` int(11) NOT NULL,
  `id_Compteur` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UC_compteur` (`id_Compteur`),
  KEY `fk_ClientAb` (`id_Client`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tabonnement`
--

INSERT INTO `tabonnement` (`id`, `statutAbonnement`, `montant`, `dateAbonnement`, `dateDesactivation`, `id_Client`, `id_Compteur`) VALUES
(15, 'ACTIF', 200, '2021-10-05 06:29:31', NULL, 9, 4),
(14, 'ACTIF', 100, '2021-10-05 06:13:52', NULL, 8, 5),
(13, 'ACTIF', 100, '2021-10-05 06:01:39', NULL, 7, 1),
(16, 'ACTIF', 200, '2021-10-05 08:03:23', NULL, 8, 2),
(17, 'ACTIF', -20, '2021-10-05 11:32:13', NULL, 7, 3),
(18, 'ACTIF', 100, '2021-10-17 07:33:40', NULL, 7, 0),
(19, 'ACTIF', 100, '2021-10-17 09:10:59', NULL, 0, 9);

-- --------------------------------------------------------

--
-- Structure de la table `tachat`
--

DROP TABLE IF EXISTS `tachat`;
CREATE TABLE IF NOT EXISTS `tachat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `montant` float NOT NULL,
  `dateAchat` datetime NOT NULL,
  `dateExpiration` date DEFAULT NULL,
  `statusAchat` varchar(50) NOT NULL,
  `AchatId` varchar(250) NOT NULL,
  `id_tCompteur` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Compteur` (`id_tCompteur`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tachat`
--

INSERT INTO `tachat` (`id`, `montant`, `dateAchat`, `dateExpiration`, `statusAchat`, `AchatId`, `id_tCompteur`) VALUES
(10, 0, '2021-10-05 06:29:31', '2021-10-05', '-', '-', 4),
(9, 10, '2021-10-05 06:13:52', '2021-10-05', '-', '-', 5),
(8, 1, '2021-10-05 06:01:39', '2021-10-05', '-', '-', 1),
(11, 0, '2021-10-05 08:03:23', '2021-10-05', '-', '-', 2),
(12, 0, '2021-10-05 11:32:13', '2021-10-05', '-', '-', 3);

-- --------------------------------------------------------

--
-- Structure de la table `tavenue`
--

DROP TABLE IF EXISTS `tavenue`;
CREATE TABLE IF NOT EXISTS `tavenue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `designation` varchar(50) NOT NULL,
  `id_quartier` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_quartier` (`id_quartier`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tavenue`
--

INSERT INTO `tavenue` (`id`, `designation`, `id_quartier`) VALUES
(1, 'DU LAC', 1),
(2, 'DE LA MISSION', 1),
(3, 'DE LA PAIX', 2),
(6, 'DE LA MONTAGNE', 2),
(4, 'DE LA MISSION', 1),
(5, 'AKILI', 3),
(7, 'UVIRA', 3),
(8, 'BELLE-VUE', 2);

-- --------------------------------------------------------

--
-- Structure de la table `tclient`
--

DROP TABLE IF EXISTS `tclient`;
CREATE TABLE IF NOT EXISTS `tclient` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `postnom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `profession` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `tel1` varchar(50) NOT NULL,
  `tel2` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `tel1` (`tel1`),
  UNIQUE KEY `tel2` (`tel2`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tclient`
--

INSERT INTO `tclient` (`id`, `nom`, `postnom`, `prenom`, `profession`, `email`, `tel1`, `tel2`) VALUES
(7, 'BARAKA', 'BIGEGA', 'ESPOIR', 'ETUDIANT', 'ESPOIR@GMAIL.COM', '0998559097', '0998545454'),
(8, 'TUMUMSIFU', 'NGANGO', 'MOISE', 'ETUDIANT', 'MOISENGAMGO@GMAIL.COM', '0975579097', '0972279012'),
(9, 'ABIO', 'BAMONGOYO', 'GAETAN', 'ETUDIANT', 'GAETAN@GMAIL.COM', '246554856224', '+243925625454'),
(10, 'dg', 'dfde', 'erer', 'erb', 'vbv', 'rh', 'sd'),
(11, 'KAVIRA', 'MALEKANI', 'SHEKINAH', 'ETUDIANTE', 'shekinah@gmail.com', '+243997522523', '+243997522525'),
(12, 'vc', 'vcv', 'cv', 'vcv', 'cv', 'cv', 'cv'),
(13, 'shabani', 'patrona', 'roger', 'commercant', 's@gmail.com', '+2455555', '+25574865');

-- --------------------------------------------------------

--
-- Structure de la table `tcommune`
--

DROP TABLE IF EXISTS `tcommune`;
CREATE TABLE IF NOT EXISTS `tcommune` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `designation` varchar(50) NOT NULL,
  `ville` varchar(50) NOT NULL,
  `province` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tcommune`
--

INSERT INTO `tcommune` (`id`, `designation`, `ville`, `province`) VALUES
(1, '   GOMA   ', ' GOMA', ' NORD-KIVU'),
(2, '  KARISIMBI  ', ' GOMA', ' NORD-KIVU'),
(3, '   NYIRAGONGO   ', ' GOMA  ', ' NORD-KIVU  '),
(4, '   KIBATI   ', ' GOMA  ', ' NORD-KIVU  '),
(5, ' GOMBE ', ' KINSHASA', ' KINSHASA'),
(6, 'NGALIEMA', 'KINSHASA', 'KINSHASA');

-- --------------------------------------------------------

--
-- Structure de la table `tcompteur`
--

DROP TABLE IF EXISTS `tcompteur`;
CREATE TABLE IF NOT EXISTS `tcompteur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numeroCompteur` varchar(50) NOT NULL,
  `id_typeCompteur` int(11) NOT NULL,
  `statusCompteur` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_typeCompteur` (`id_typeCompteur`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tcompteur`
--

INSERT INTO `tcompteur` (`id`, `numeroCompteur`, `id_typeCompteur`, `statusCompteur`) VALUES
(1, 'COMP1-2021', 3, 'Used'),
(2, 'COMP2-2021', 1, 'Used'),
(3, 'COMP3-2021', 1, 'Used'),
(4, 'COMP4-2021', 2, 'Used'),
(5, 'COMP5-2021', 4, 'Used'),
(6, 'COMP6-2021', 2, 'Available'),
(7, 'COMP7-2021', 0, 'Available'),
(8, 'COMP8-2021', 5, 'Available'),
(9, 'COMP9-2021', 4, 'Available'),
(10, 'COMP10-2021', 4, 'Available'),
(11, 'COMP11-2021', 4, 'Available'),
(12, 'COMP12-2021', 4, 'Available');

-- --------------------------------------------------------

--
-- Structure de la table `tfonction`
--

DROP TABLE IF EXISTS `tfonction`;
CREATE TABLE IF NOT EXISTS `tfonction` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `designation` varchar(50) NOT NULL,
  `LevelAccess` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tfonction`
--

INSERT INTO `tfonction` (`id`, `designation`, `LevelAccess`) VALUES
(1, 'ADMIN', 1),
(2, 'SECRETAIRE', 2),
(3, 'COMPTABLE', 2);

-- --------------------------------------------------------

--
-- Structure de la table `tpaiement`
--

DROP TABLE IF EXISTS `tpaiement`;
CREATE TABLE IF NOT EXISTS `tpaiement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `montant` float NOT NULL,
  `datePmt` datetime NOT NULL,
  `id_Abonnement` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pmtAbonnement` (`id_Abonnement`)
) ENGINE=MyISAM AUTO_INCREMENT=36 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tpaiement`
--

INSERT INTO `tpaiement` (`id`, `montant`, `datePmt`, `id_Abonnement`) VALUES
(26, 5, '2021-10-05 06:44:45', 14),
(25, 20, '2021-10-05 06:30:21', 15),
(24, 200, '2021-10-05 06:29:31', 15),
(23, 100, '2021-10-05 06:20:11', 13),
(22, 5, '2021-10-05 06:19:47', 14),
(21, 10, '2021-10-05 06:18:18', 14),
(20, 100, '2021-10-05 06:13:52', 14),
(19, 10, '2021-10-05 06:08:29', 13),
(18, 100, '2021-10-05 06:01:39', 1),
(27, 70, '2021-10-05 06:45:58', 13),
(28, 10, '2021-10-05 06:46:12', 13),
(29, 10, '2021-10-05 06:47:29', 14),
(30, 200, '2021-10-05 08:03:23', 16),
(31, 10, '2021-10-05 08:03:55', 16),
(32, 40, '2021-10-05 08:04:08', 16),
(33, -20, '2021-10-05 11:32:13', 17),
(34, 100, '2021-10-05 11:33:37', 17),
(35, 170, '2021-10-05 11:33:50', 17);

-- --------------------------------------------------------

--
-- Structure de la table `tparcelle`
--

DROP TABLE IF EXISTS `tparcelle`;
CREATE TABLE IF NOT EXISTS `tparcelle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numeroParcelle` varchar(50) NOT NULL,
  `id_Avenue` int(11) NOT NULL,
  `id_Client` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_avenue` (`id_Avenue`),
  KEY `fk_ClientPar` (`id_Client`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tparcelle`
--

INSERT INTO `tparcelle` (`id`, `numeroParcelle`, `id_Avenue`, `id_Client`) VALUES
(3, 'V10', 6, 7),
(4, 'V10', 2, 8),
(5, 'V123', 5, 9),
(6, 'V12', 5, 7),
(7, 'V12', 4, 8),
(8, 'V10', 5, 8),
(9, 'V10', 5, 7),
(10, 'V10', 8, 7),
(11, 'V10', 5, 7),
(12, '10V', 5, 8),
(13, 'V50', 5, 9),
(14, 'VH20', 5, 8),
(15, 'V56', 5, 7);

-- --------------------------------------------------------

--
-- Structure de la table `tquartier`
--

DROP TABLE IF EXISTS `tquartier`;
CREATE TABLE IF NOT EXISTS `tquartier` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `designation` varchar(50) DEFAULT NULL,
  `id_commune` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Commune` (`id_commune`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tquartier`
--

INSERT INTO `tquartier` (`id`, `designation`, `id_commune`) VALUES
(1, 'HIMBI', 1),
(2, 'KATINDO 1', 1),
(3, 'MAJENGO', 2),
(4, ' BUHENE ', 3),
(5, 'LES VOLCANS', 1);

-- --------------------------------------------------------

--
-- Structure de la table `ttelephone`
--

DROP TABLE IF EXISTS `ttelephone`;
CREATE TABLE IF NOT EXISTS `ttelephone` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `initial` varchar(50) NOT NULL,
  `numero` varchar(50) NOT NULL,
  `id_Client` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_client` (`id_Client`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `ttypecompteur`
--

DROP TABLE IF EXISTS `ttypecompteur`;
CREATE TABLE IF NOT EXISTS `ttypecompteur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `designation` varchar(50) NOT NULL,
  `montantParKw` int(11) NOT NULL,
  `montantAbonnement` float NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `ttypecompteur`
--

INSERT INTO `ttypecompteur` (`id`, `designation`, `montantParKw`, `montantAbonnement`) VALUES
(1, 'LUX 250WATT', 10, 250),
(2, 'LUX 150WATT', 17, 220),
(3, 'LUX 120WATT', 0, 1800),
(4, 'LUX 100WATT', 10, 120),
(5, 'LUX 350WATT', 35, 300),
(6, 'LUX95WATT', 7, 100);

-- --------------------------------------------------------

--
-- Structure de la table `tusers`
--

DROP TABLE IF EXISTS `tusers`;
CREATE TABLE IF NOT EXISTS `tusers` (
  `code` int(11) NOT NULL AUTO_INCREMENT,
  `userN` varchar(50) NOT NULL,
  `passCode` varchar(50) NOT NULL,
  `emailUser` varchar(50) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `id_Fonction` int(11) NOT NULL,
  `statusUsers` int(11) NOT NULL,
  PRIMARY KEY (`code`),
  UNIQUE KEY `uk_email` (`emailUser`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `tusers`
--

INSERT INTO `tusers` (`code`, `userN`, `passCode`, `emailUser`, `phone`, `id_Fonction`, `statusUsers`) VALUES
(1, 'BARAKA', '12', 'ESPI1@GMAIL.COM', '0998559097', 1, 0),
(2, 'KAVIRA', '1234', 'MALEK@GMAIL.COM', '0998559097', 3, 0),
(3, 'TUMUMSIFU', '1234', 'MOISENGAMGO@GMAIL.COM', '0975579097', 2, 0);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vachat_all`
-- (Voir ci-dessous la vue réelle)
--
DROP VIEW IF EXISTS `vachat_all`;
CREATE TABLE IF NOT EXISTS `vachat_all` (
`id` int(11)
,`statutAbonnement` varchar(50)
,`NOM` varchar(152)
,`numeroCompteur` varchar(50)
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vcompteur`
-- (Voir ci-dessous la vue réelle)
--
DROP VIEW IF EXISTS `vcompteur`;
CREATE TABLE IF NOT EXISTS `vcompteur` (
`AbonnementID` int(11)
,`CompteurID` int(11)
,`NumCompteur` varchar(50)
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `v_abonnementall`
-- (Voir ci-dessous la vue réelle)
--
DROP VIEW IF EXISTS `v_abonnementall`;
CREATE TABLE IF NOT EXISTS `v_abonnementall` (
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `v_compteurall`
-- (Voir ci-dessous la vue réelle)
--
DROP VIEW IF EXISTS `v_compteurall`;
CREATE TABLE IF NOT EXISTS `v_compteurall` (
`id` int(11)
,`numeroCompteur` varchar(50)
,`montantParKw` int(11)
,`montantAbonnement` float
,`statusCompteur` varchar(50)
);

-- --------------------------------------------------------

--
-- Structure de la vue `abonnement_all`
--
DROP TABLE IF EXISTS `abonnement_all`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `abonnement_all`  AS  select `tabonnement`.`id` AS `AbonnementID`,`tabonnement`.`statutAbonnement` AS `AbonnementStatut`,`tabonnement`.`montant` AS `AbonnementMontant`,`tabonnement`.`dateAbonnement` AS `abonnementDate`,`tabonnement`.`dateDesactivation` AS `desactivationAbonnement`,`tcompteur`.`id` AS `CompteurID`,`tcompteur`.`numeroCompteur` AS `numberCompteur`,`tcompteur`.`statusCompteur` AS `CompteurStatut`,`tcompteur`.`id_typeCompteur` AS `idTypeCompteur`,`tclient`.`id` AS `ClientID`,`tclient`.`nom` AS `Nom`,`tclient`.`postnom` AS `postnom`,`tclient`.`prenom` AS `prenom`,`tclient`.`profession` AS `Profession`,`tclient`.`email` AS `Mail`,`tclient`.`statusClient` AS `ClientStatut` from ((`tabonnement` join `tcompteur` on((`tabonnement`.`id_Compteur` = `tcompteur`.`id`))) join `tclient` on((`tabonnement`.`id_Client` = `tclient`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure de la vue `vachat_all`
--
DROP TABLE IF EXISTS `vachat_all`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vachat_all`  AS  select `tabonnement`.`id` AS `id`,`tabonnement`.`statutAbonnement` AS `statutAbonnement`,concat(`tclient`.`nom`,' ',`tclient`.`postnom`,' ',`tclient`.`prenom`) AS `NOM`,`tcompteur`.`numeroCompteur` AS `numeroCompteur` from ((`tabonnement` join `tclient` on((`tclient`.`id` = `tabonnement`.`id_Client`))) join `tcompteur` on((`tcompteur`.`id` = `tabonnement`.`id_Compteur`))) ;

-- --------------------------------------------------------

--
-- Structure de la vue `vcompteur`
--
DROP TABLE IF EXISTS `vcompteur`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vcompteur`  AS  select `tabonnement`.`id` AS `AbonnementID`,`tabonnement`.`id_Compteur` AS `CompteurID`,`tcompteur`.`numeroCompteur` AS `NumCompteur` from (`tcompteur` join `tabonnement` on((`tabonnement`.`id_Compteur` = `tcompteur`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure de la vue `v_abonnementall`
--
DROP TABLE IF EXISTS `v_abonnementall`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_abonnementall`  AS  select `tabonnement`.`id` AS `AbonnementID`,`tabonnement`.`statutAbonnement` AS `AbonnementStatut`,`tabonnement`.`montant` AS `AbonnementMontant`,`tabonnement`.`dateAbonnement` AS `abonnementDate`,`tabonnement`.`dateDesactivation` AS `desactivationAbonnement`,`tcompteur`.`id` AS `CompteurID`,`tcompteur`.`numeroCompteur` AS `numberCompteur`,`tcompteur`.`statusCompteur` AS `CompteurStatut`,`tcompteur`.`id_typeCompteur` AS `idTypeCompteur`,`tclient`.`id` AS `ClientID`,concat(`tclient`.`nom`,' ',`tclient`.`postnom`,' ',`tclient`.`prenom`) AS `Noms`,`tclient`.`profession` AS `Profession`,`tclient`.`email` AS `Mail`,`tclient`.`statusClient` AS `ClientStatut` from ((`tabonnement` join `tcompteur` on((`tabonnement`.`id_Compteur` = `tcompteur`.`id`))) join `tclient` on((`tabonnement`.`id_Client` = `tclient`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure de la vue `v_compteurall`
--
DROP TABLE IF EXISTS `v_compteurall`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_compteurall`  AS  select `tcompteur`.`id` AS `id`,`tcompteur`.`numeroCompteur` AS `numeroCompteur`,`ttypecompteur`.`montantParKw` AS `montantParKw`,`ttypecompteur`.`montantAbonnement` AS `montantAbonnement`,`tcompteur`.`statusCompteur` AS `statusCompteur` from (`tcompteur` join `ttypecompteur` on((`tcompteur`.`id_typeCompteur` = `ttypecompteur`.`id`))) ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
