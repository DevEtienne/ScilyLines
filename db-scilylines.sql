-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : jeu. 13 oct. 2022 à 21:52
-- Version du serveur : 5.7.36
-- Version de PHP : 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `db-scilylines`
--

-- --------------------------------------------------------

--
-- Ajout de l'utilisateur admin
--

DROP user `admin`@`localhost`;
flush privileges;
CREATE USER 'admin'@'localhost' IDENTIFIED BY '3db857812fdaf74e3de40fec4080ff96';
GRANT ALL PRIVILEGES ON * . * TO 'admin'@'localhost';

--
-- Structure de la table `liaison`
--

DROP TABLE IF EXISTS `liaison`;
CREATE TABLE IF NOT EXISTS `liaison` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `duree` varchar(5) NOT NULL,
  `portDepart` int(11) NOT NULL,
  `portArrivee` int(11) NOT NULL,
  `idSecteur` int(2) NOT NULL,
  KEY `fk-depart` (`portDepart`),
  KEY `fk-arrivee` (`portArrivee`),
  KEY `id` (`id`),
  KEY `duree` (`duree`),
  KEY `fk-Secteur` (`idSecteur`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `liaison`
--

INSERT INTO `liaison` (`id`, `duree`, `portDepart`, `portArrivee`, `idSecteur`) VALUES
(28, '2h50', 2, 3, 1),
(32, '4h', 3, 1, 2);

-- --------------------------------------------------------

--
-- Structure de la table `login`
--

DROP TABLE IF EXISTS `login`;
CREATE TABLE IF NOT EXISTS `login` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `login`
--

INSERT INTO `login` (`username`, `password`) VALUES
('admin', '3db857812fdaf74e3de40fec4080ff96');

-- --------------------------------------------------------

--
-- Structure de la table `port`
--

DROP TABLE IF EXISTS `port`;
CREATE TABLE IF NOT EXISTS `port` (
  `id` int(11) NOT NULL,
  `nom` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `port`
--

INSERT INTO `port` (`id`, `nom`) VALUES
(1, 'Palerme'),
(2, 'Ustica'),
(3, 'Stromboli'),
(4, 'Lipari');

-- --------------------------------------------------------

--
-- Structure de la table `secteur`
--

DROP TABLE IF EXISTS `secteur`;
CREATE TABLE IF NOT EXISTS `secteur` (
  `id` int(2) NOT NULL,
  `nom` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `secteur`
--

INSERT INTO `secteur` (`id`, `nom`) VALUES
(1, 'Palerme'),
(2, 'Messine');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

