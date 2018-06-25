-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 21, 2018 at 09:52 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `pedagog`
--

-- --------------------------------------------------------

--
-- Table structure for table `adresar`
--

CREATE TABLE IF NOT EXISTS `adresar` (
  `id_kontakt` int(11) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `naziv` varchar(150) COLLATE utf8_croatian_ci NOT NULL,
  `adresa` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `grad` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `tel` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `mail` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `opis` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_kontakt`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `dokument`
--

CREATE TABLE IF NOT EXISTS `dokument` (
  `id_dokument` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `vrsta` int(11) NOT NULL,
  `naziv` varchar(60) COLLATE utf8_croatian_ci NOT NULL,
  `putanja` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_dokument`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ispisani_ucenici`
--

CREATE TABLE IF NOT EXISTS `ispisani_ucenici` (
  `id_analiza` bigint(20) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `datum` date NOT NULL,
  `razlog` text COLLATE utf8_croatian_ci NOT NULL,
  `skola` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `nastavnik`
--

CREATE TABLE IF NOT EXISTS `nastavnik` (
  `id_nastavnik` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_skola` int(11) NOT NULL,
  `ime_prezime` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `titula` int(11) NOT NULL,
  PRIMARY KEY (`id_nastavnik`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `nastavnik_analiza`
--

CREATE TABLE IF NOT EXISTS `nastavnik_analiza` (
  `id_analiza` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_nastavnik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `nastavni_sat` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `predmet` text COLLATE utf8_croatian_ci NOT NULL,
  `cilj` text COLLATE utf8_croatian_ci NOT NULL,
  `nastavna_jedinica` text COLLATE utf8_croatian_ci NOT NULL,
  `vrsta_sata` text COLLATE utf8_croatian_ci NOT NULL,
  `planiranje` text COLLATE utf8_croatian_ci NOT NULL,
  `izvedba` text COLLATE utf8_croatian_ci NOT NULL,
  `tijek` text COLLATE utf8_croatian_ci NOT NULL,
  `ugodaj` text COLLATE utf8_croatian_ci NOT NULL,
  `disciplina` text COLLATE utf8_croatian_ci NOT NULL,
  `ocjena_napredovanja` text COLLATE utf8_croatian_ci NOT NULL,
  `osvrt` text COLLATE utf8_croatian_ci NOT NULL,
  `prijedlozi` text COLLATE utf8_croatian_ci NOT NULL,
  `uvid` text COLLATE utf8_croatian_ci NOT NULL,
  `zakljucak` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_analiza`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `nastavnik_neposredni`
--

CREATE TABLE IF NOT EXISTS `nastavnik_neposredni` (
  `id_rad` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_nastavnik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `vrijeme` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `nastavni_sat` varchar(20) CHARACTER SET utf32 COLLATE utf32_croatian_ci NOT NULL,
  `mjesto` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `nas_jedinica` text COLLATE utf8_croatian_ci NOT NULL,
  `nas_cijelina` text COLLATE utf8_croatian_ci NOT NULL,
  `uvjeti_izvodenja` int(11) NOT NULL COMMENT '1-2',
  `uvjet_prostor` int(11) NOT NULL COMMENT 'da/ne',
  `uvjet_higijena` text COLLATE utf8_croatian_ci NOT NULL,
  `uvjet_materijalna` text COLLATE utf8_croatian_ci NOT NULL,
  `planiranje_redovno` int(11) NOT NULL COMMENT 'da/ne',
  `planiranje_priprava` text COLLATE utf8_croatian_ci NOT NULL,
  `planiranje_sadrzaji` int(11) NOT NULL COMMENT '1-3',
  `planiranje_postignuca` int(11) NOT NULL COMMENT '1-3',
  `planiranje_pismena` int(11) NOT NULL COMMENT '1-5',
  `analiza_model` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza_soci` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza_metode` text CHARACTER SET utf32 COLLATE utf32_croatian_ci NOT NULL,
  `analiza_strategija` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza_sredstva` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza_novi_pojam` int(11) NOT NULL COMMENT '1-3',
  `analiza_oblici` int(11) NOT NULL COMMENT '1-3',
  `analiza_ciljevi` int(11) NOT NULL COMMENT '1-3',
  `analiza_odnos` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza_pozornost` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza_nastup` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza_govor` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza_stil` text COLLATE utf8_croatian_ci NOT NULL,
  `aktiv_samostalan` text COLLATE utf8_croatian_ci NOT NULL,
  `aktiv_postignuca` text COLLATE utf8_croatian_ci NOT NULL,
  `aktiv_dz` text COLLATE utf8_croatian_ci NOT NULL,
  `aktiv_karakter` text COLLATE utf8_croatian_ci NOT NULL,
  `aktiv_dz_provjerena` int(11) NOT NULL COMMENT '1-4',
  `aktiv_zapis` int(11) NOT NULL,
  `aktiv_procjena` int(11) NOT NULL,
  `aktiv_evaluacija` int(11) NOT NULL,
  `aktiv_zapazanja` int(11) NOT NULL,
  `dokument_vodi` int(11) NOT NULL,
  `dokument_dnevnik` int(11) NOT NULL,
  `dokument_priprema` int(11) NOT NULL,
  `dokument_imenik` int(11) NOT NULL,
  `dokument_ocjene` int(11) NOT NULL,
  `poslovi` text COLLATE utf8_croatian_ci NOT NULL,
  `procjena_vodenja` int(11) NOT NULL COMMENT '1-5',
  PRIMARY KEY (`id_rad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `nastavnik_protokol`
--

CREATE TABLE IF NOT EXISTS `nastavnik_protokol` (
  `id_protokol` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_nastavnik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `vrijeme` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `nastavni_sat` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `mjesto` text COLLATE utf8_croatian_ci NOT NULL,
  `nas_cjelina` text COLLATE utf8_croatian_ci NOT NULL,
  `nas_jedinica` text COLLATE utf8_croatian_ci NOT NULL,
  `prijava` int(11) NOT NULL COMMENT 'da/ne',
  `cilj` int(11) NOT NULL COMMENT '1-4',
  `struktura` int(11) NOT NULL COMMENT '1-4',
  `plan` int(11) NOT NULL COMMENT '1-4',
  `ploca` int(11) NOT NULL COMMENT '1-4',
  `tip_sata` int(11) NOT NULL COMMENT '1-5',
  `metoda_verbalna` int(11) NOT NULL COMMENT '1-3',
  `metoda_vizualna` int(11) NOT NULL COMMENT '1-3',
  `metoda_demo` int(11) NOT NULL,
  `metoda_prakse` int(11) NOT NULL,
  `metoda_kombi` int(11) NOT NULL,
  `soc_oblik_rada` int(11) NOT NULL COMMENT '1-4',
  `nastavna_sredstva` text COLLATE utf8_croatian_ci NOT NULL,
  `funkci_pripema` int(11) NOT NULL COMMENT '1-4',
  `motiv_uvod` int(11) NOT NULL COMMENT '1-3',
  `motiv_komunikacija` int(11) NOT NULL COMMENT '1-3',
  `motiv_humor` int(11) NOT NULL COMMENT '1-3',
  `motiv_paznja` int(11) NOT NULL COMMENT '1-3',
  `prezent_sto_nastavnik` text COLLATE utf8_croatian_ci NOT NULL,
  `prezent_sto_ucenik` text COLLATE utf8_croatian_ci NOT NULL,
  `prezent_kompo_nastavnik` text COLLATE utf8_croatian_ci NOT NULL,
  `prezent_kompo_ucenik` text COLLATE utf8_croatian_ci NOT NULL,
  `prezent_tijek_nastavnik` text CHARACTER SET utf32 COLLATE utf32_croatian_ci NOT NULL,
  `prezent_tijek_ucenik` text COLLATE utf8_croatian_ci NOT NULL,
  `procjena_razgovora` int(11) NOT NULL COMMENT '1-4',
  `procjena_ohr_ponasanje` int(11) NOT NULL,
  `procjena_ohr_aktivnost` int(11) NOT NULL,
  `procjena_pitanja` int(11) NOT NULL,
  `procjena_autoritet` int(11) NOT NULL,
  `procjena_empatija` int(11) NOT NULL,
  `procjena_pomaze` int(11) NOT NULL,
  `procjena_neverbalna` int(11) NOT NULL,
  `procjena_inicijativa` int(11) NOT NULL,
  `dz` int(11) NOT NULL COMMENT '1-3',
  `daje_ocjenu` int(11) NOT NULL COMMENT 'da/ne',
  `komentar` text COLLATE utf8_croatian_ci NOT NULL,
  `prijedlozi` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_protokol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `obitelj`
--

CREATE TABLE IF NOT EXISTS `obitelj` (
  `id_obitelj` int(11) NOT NULL AUTO_INCREMENT,
  `id_ucenik` bigint(20) NOT NULL,
  `ime_prezime` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `vrsta` int(11) NOT NULL,
  `zanimanje` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `tel` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `mail` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `adresa` varchar(40) COLLATE utf8_croatian_ci NOT NULL,
  `grad` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `obrazovanje` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `biljeska` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_obitelj`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `pedagog`
--

CREATE TABLE IF NOT EXISTS `pedagog` (
  `id_pedagog` int(11) NOT NULL AUTO_INCREMENT,
  `ime_prezime` varchar(150) COLLATE utf8_croatian_ci NOT NULL,
  `mail` varchar(30) CHARACTER SET utf32 COLLATE utf32_croatian_ci NOT NULL,
  `lozinka` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `titula` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `licenca` date NOT NULL,
  `aktiv_link` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `aktivan` int(11) NOT NULL,
  `id_skola` int(11) NOT NULL,
  PRIMARY KEY (`id_pedagog`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `razednik_procjena`
--

CREATE TABLE IF NOT EXISTS `razednik_procjena` (
  `id_procjena` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_nastavnik` bigint(20) NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `br_ucenika` int(11) NOT NULL,
  `ucenici_pozitivni` int(11) NOT NULL,
  `ucenici_nedovoljno` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_izostanci` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_mjere` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_roditelji` text COLLATE utf8_croatian_ci NOT NULL,
  `predmet_malo_ocjena` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_procjena`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `razrednik_analiza`
--

CREATE TABLE IF NOT EXISTS `razrednik_analiza` (
  `id_analiza` bigint(20) NOT NULL,
  `id_pedagog` int(11) NOT NULL,
  `id_nastavnik` bigint(20) NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `br_ucenika_m` int(11) NOT NULL,
  `br_ucenika_z` int(11) NOT NULL,
  `br_ucenika_prehrana` int(11) NOT NULL,
  `br_ucenika_putnici` int(11) NOT NULL,
  `br_ucenika_predstavnik` int(11) NOT NULL,
  `br_ucenika_vrsnjacka` int(11) NOT NULL,
  `ucenici_oblik_skolovanja` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_pokrenut` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_nadzor` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_ukljuceni` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_novi` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_mijenjaju` text CHARACTER SET utf32 COLLATE utf32_croatian_ci NOT NULL,
  `ucenici_soci` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_bolest` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_jedan_roditelj` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_teski_uvjeti` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_branitelj` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_daroviti` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_izvanskolske` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_treba_pokrenut` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `razrednik_profil`
--

CREATE TABLE IF NOT EXISTS `razrednik_profil` (
  `id_profil` bigint(20) NOT NULL,
  `id_pedagog` int(11) NOT NULL,
  `id_nastavnik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `br_ucenika` int(11) NOT NULL,
  `ponavljaci` int(11) NOT NULL,
  `putnici` int(11) NOT NULL,
  `novi_ucenici` int(11) NOT NULL,
  `ucenik_bez_jednog` int(11) NOT NULL,
  `ucenik_bez_oba` int(11) NOT NULL,
  `uspjeh_prosjek` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_izdvojeni` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_slabi_uspjeh` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_aktivnost` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_izvanskolske` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_los_uspjeh` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_opravdani` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_neopravdani` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenici_nedisciplina` text COLLATE utf8_croatian_ci NOT NULL,
  `procjena_suradnje` text COLLATE utf8_croatian_ci NOT NULL,
  `roditelji_neredoviti` text COLLATE utf8_croatian_ci NOT NULL,
  `potreba_ukljucivanja` text COLLATE utf8_croatian_ci NOT NULL,
  `nastavnici_klima` text COLLATE utf8_croatian_ci NOT NULL,
  `suradnja_vijece` text COLLATE utf8_croatian_ci NOT NULL,
  `prijedlozi` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `razredni_odjel`
--

CREATE TABLE IF NOT EXISTS `razredni_odjel` (
  `id_odjel` int(11) NOT NULL AUTO_INCREMENT,
  `godina` int(11) NOT NULL COMMENT 'školska godina',
  `naziv` varchar(20) COLLATE utf8_croatian_ci NOT NULL COMMENT '1-8, 10,11,12,13',
  `razred` int(11) NOT NULL,
  `id_razrednik` int(11) NOT NULL,
  `os_ss` int(11) NOT NULL COMMENT '0-os, 1-srednja škola',
  `program` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `usmjerenje` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `broj_z` int(11) NOT NULL COMMENT 'br_učenica',
  `broj_m` int(11) NOT NULL COMMENT 'br_učenika',
  PRIMARY KEY (`id_odjel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `roditelj_biljeske`
--

CREATE TABLE IF NOT EXISTS `roditelj_biljeske` (
  `id_biljeske` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `naslov` text COLLATE utf8_croatian_ci NOT NULL,
  `ime_roditelja` text COLLATE utf8_croatian_ci NOT NULL,
  `zapazanja` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_biljeske`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `roditelj_biljeske_mjesec`
--

CREATE TABLE IF NOT EXISTS `roditelj_biljeske_mjesec` (
  `id_biljeske` bigint(20) NOT NULL,
  `mjesec` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `zakljucak` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `roditelj_list`
--

CREATE TABLE IF NOT EXISTS `roditelj_list` (
  `id_list` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `naslov` text COLLATE utf8_croatian_ci NOT NULL,
  `analiza` text COLLATE utf8_croatian_ci NOT NULL,
  `problemi` text COLLATE utf8_croatian_ci NOT NULL,
  `odgovori` text COLLATE utf8_croatian_ci NOT NULL,
  `zadaci` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_list`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `roditelj_procjena`
--

CREATE TABLE IF NOT EXISTS `roditelj_procjena` (
  `id_procjena` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `naslov` text COLLATE utf8_croatian_ci NOT NULL,
  `opis` text COLLATE utf8_croatian_ci NOT NULL,
  `interes` text COLLATE utf8_croatian_ci NOT NULL,
  `najaktivniji` text COLLATE utf8_croatian_ci NOT NULL,
  `poteskoce` text COLLATE utf8_croatian_ci NOT NULL,
  `boravak_skola` text COLLATE utf8_croatian_ci NOT NULL,
  `odnos_obitelj` text COLLATE utf8_croatian_ci NOT NULL,
  `aktivnosti` text COLLATE utf8_croatian_ci NOT NULL,
  `hobi` text COLLATE utf8_croatian_ci NOT NULL,
  `ocekivanja` text COLLATE utf8_croatian_ci NOT NULL,
  `dodatni_podaci` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_procjena`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `roditelj_razgovor`
--

CREATE TABLE IF NOT EXISTS `roditelj_razgovor` (
  `id_razgovor` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `naslov` text COLLATE utf8_croatian_ci NOT NULL,
  `ime_roditelja` varchar(30) COLLATE utf8_croatian_ci NOT NULL,
  `trazi` text COLLATE utf8_croatian_ci NOT NULL,
  `razlog` text COLLATE utf8_croatian_ci NOT NULL,
  `dolazak` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeske` text COLLATE utf8_croatian_ci NOT NULL,
  `prijedlog_roditelj` text COLLATE utf8_croatian_ci NOT NULL,
  `prijedlog_skola` text COLLATE utf8_croatian_ci NOT NULL,
  `dogovor` text COLLATE utf8_croatian_ci NOT NULL,
  `izvijestiti` text COLLATE utf8_croatian_ci NOT NULL,
  `sljedeci_susret` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_razgovor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `skola`
--

CREATE TABLE IF NOT EXISTS `skola` (
  `id_skola` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` varchar(70) COLLATE utf8_croatian_ci NOT NULL,
  `adresa` varchar(120) COLLATE utf8_croatian_ci NOT NULL,
  `grad` varchar(40) CHARACTER SET utf32 COLLATE utf32_croatian_ci NOT NULL,
  `oib` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `mail` varchar(30) CHARACTER SET utf32 COLLATE utf32_croatian_ci NOT NULL,
  `tel` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `opis` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_skola`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `skolska_godina`
--

CREATE TABLE IF NOT EXISTS `skolska_godina` (
  `id_skolska_godina` bigint(20) NOT NULL AUTO_INCREMENT,
  `godina` int(11) NOT NULL,
  PRIMARY KEY (`id_skolska_godina`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `strucno_usavrsavanje`
--

CREATE TABLE IF NOT EXISTS `strucno_usavrsavanje` (
  `id_usavrsavanje` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `naslov` text COLLATE utf8_croatian_ci NOT NULL,
  `cilj` text COLLATE utf8_croatian_ci NOT NULL,
  `namjena` text COLLATE utf8_croatian_ci NOT NULL,
  `nacina_rada` text COLLATE utf8_croatian_ci NOT NULL,
  `br_sudionika` text COLLATE utf8_croatian_ci NOT NULL,
  `modul_1_opis` text COLLATE utf8_croatian_ci NOT NULL,
  `modul_1_vrijeme` text COLLATE utf8_croatian_ci NOT NULL,
  `modul_2_opis` text COLLATE utf8_croatian_ci NOT NULL,
  `modul_2_vrijeme` text COLLATE utf8_croatian_ci NOT NULL,
  `modul_3_opis` text COLLATE utf8_croatian_ci NOT NULL,
  `modul_3_vrijeme` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_usavrsavanje`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik`
--

CREATE TABLE IF NOT EXISTS `ucenik` (
  `id_ucenik` bigint(11) NOT NULL AUTO_INCREMENT,
  `ime_prezime` varchar(50) COLLATE utf8_croatian_ci NOT NULL,
  `spol` int(11) NOT NULL,
  `datum` date NOT NULL COMMENT 'datum rođenja',
  `oib` varchar(15) COLLATE utf8_croatian_ci NOT NULL,
  `adresa` varchar(40) COLLATE utf8_croatian_ci NOT NULL,
  `grad` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `biljeska` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_ucenik`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_biljeska`
--

CREATE TABLE IF NOT EXISTS `ucenik_biljeska` (
  `id_biljeska` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `inicijalni_podaci` text COLLATE utf8_croatian_ci NOT NULL,
  `datum_pocetak` date NOT NULL,
  `biljeska_1` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_2` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_3` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_4` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_5` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_6` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_7` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_8` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_9` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_10` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_11` text COLLATE utf8_croatian_ci NOT NULL,
  `biljeska_12` text COLLATE utf8_croatian_ci NOT NULL,
  `zakljucak` text COLLATE utf8_croatian_ci NOT NULL,
  `zapazanja` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_biljeska`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_godina`
--

CREATE TABLE IF NOT EXISTS `ucenik_godina` (
  `id_ucenik` bigint(20) NOT NULL,
  `id_skola` int(11) NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `godina` int(11) NOT NULL,
  `id_razrednik` int(11) NOT NULL,
  `ponavlja` int(11) NOT NULL COMMENT 'da li učenik ponavlja razred',
  `putnik` int(11) NOT NULL,
  `zaduzenja` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_lista_pracenja`
--

CREATE TABLE IF NOT EXISTS `ucenik_lista_pracenja` (
  `id_pracenje` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `razlog` text COLLATE utf8_croatian_ci NOT NULL,
  `inic_ucenik` text COLLATE utf8_croatian_ci NOT NULL,
  `inic_roditelj` text COLLATE utf8_croatian_ci NOT NULL,
  `inic_razrednik` text COLLATE utf8_croatian_ci NOT NULL,
  `soc_eko` text COLLATE utf8_croatian_ci NOT NULL,
  `ucenje` text COLLATE utf8_croatian_ci NOT NULL,
  `vjestine` text COLLATE utf8_croatian_ci NOT NULL,
  `suradnja` text COLLATE utf8_croatian_ci NOT NULL,
  `zakljucak` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_pracenje`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_napredovanje`
--

CREATE TABLE IF NOT EXISTS `ucenik_napredovanje` (
  `id_napredovanje` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `vrijeme` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `naziv` varchar(40) COLLATE utf8_croatian_ci NOT NULL,
  `razlog` text COLLATE utf8_croatian_ci NOT NULL,
  `odgojni_otac` int(11) NOT NULL,
  `odgojni_majka` int(11) NOT NULL,
  `odnos_ucenje_otac` int(11) NOT NULL,
  `odnos_ucenje_majka` int(11) NOT NULL,
  `suradnja_otac` int(11) NOT NULL,
  `suradnja_majka` int(11) NOT NULL,
  `prijatelji` text COLLATE utf8_croatian_ci NOT NULL,
  `slobodno_vrijeme` text COLLATE utf8_croatian_ci NOT NULL,
  `los_utjecaj` text COLLATE utf8_croatian_ci NOT NULL,
  `zdravlje` text COLLATE utf8_croatian_ci NOT NULL,
  `promjene` text COLLATE utf8_croatian_ci NOT NULL,
  `ped_mjere` text COLLATE utf8_croatian_ci NOT NULL,
  `procjena` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_napredovanje`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_napredovanje_ponav`
--

CREATE TABLE IF NOT EXISTS `ucenik_napredovanje_ponav` (
  `id_napredovanje` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_pedagog` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `vrijeme` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `naziv` text COLLATE utf8_croatian_ci NOT NULL,
  `uzroci` text COLLATE utf8_croatian_ci NOT NULL,
  `mogucnost_1` int(11) NOT NULL COMMENT 'od 1-5',
  `mogucnost_2` int(11) NOT NULL,
  `mogucnost_3` int(11) NOT NULL,
  `mogucnost_4` int(11) NOT NULL,
  `mogucnost_5` int(11) NOT NULL,
  `mogucnost_6` int(11) NOT NULL,
  `mogucnost_7` int(11) NOT NULL,
  `mogucnost_8` int(11) NOT NULL,
  `mjera_1_predmet` text COLLATE utf8_croatian_ci NOT NULL,
  `mjera_2_predmet` text COLLATE utf8_croatian_ci NOT NULL,
  `mjera_3_predmet` text COLLATE utf8_croatian_ci NOT NULL,
  `mjera_1_ucinak` text COLLATE utf8_croatian_ci NOT NULL,
  `mjera_2_ucinak` text COLLATE utf8_croatian_ci NOT NULL,
  `mjera_3_ucinak` text COLLATE utf8_croatian_ci NOT NULL,
  `upitnik` int(11) NOT NULL COMMENT 'da/ne',
  `suradnja` int(11) NOT NULL COMMENT '1-3',
  `komentar` text COLLATE utf8_croatian_ci NOT NULL,
  `plan_razgovor_A_dan` text COLLATE utf8_croatian_ci NOT NULL,
  `plan_razgovor_A_sat` text COLLATE utf8_croatian_ci NOT NULL,
  `plan_razgovor_B_dan` text COLLATE utf8_croatian_ci NOT NULL,
  `plan_razgovor_B_sat` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_napredovanje`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_neposredni_rad`
--

CREATE TABLE IF NOT EXISTS `ucenik_neposredni_rad` (
  `id_pracenje` bigint(20) NOT NULL,
  `datum` date NOT NULL,
  `biljeska` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_obrazovna_postignuca`
--

CREATE TABLE IF NOT EXISTS `ucenik_obrazovna_postignuca` (
  `id_pracenje` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `razred` int(11) NOT NULL,
  `napomena` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_prijedlog_postupka`
--

CREATE TABLE IF NOT EXISTS `ucenik_prijedlog_postupka` (
  `id_pracenje` bigint(20) NOT NULL,
  `datum` date NOT NULL,
  `vrsta` text COLLATE utf8_croatian_ci NOT NULL,
  `vrijeme` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_procjena_suradnje_ponav`
--

CREATE TABLE IF NOT EXISTS `ucenik_procjena_suradnje_ponav` (
  `id_procjena` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_napredovanje` bigint(20) NOT NULL,
  `nastavnik` varchar(80) COLLATE utf8_croatian_ci NOT NULL,
  `datum_razgovora` date NOT NULL,
  `biljeska` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_procjena`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_protokol_pracenja`
--

CREATE TABLE IF NOT EXISTS `ucenik_protokol_pracenja` (
  `id_pracenje` bigint(20) NOT NULL,
  `id_pedagog` int(11) NOT NULL,
  `id_ucenik` bigint(20) NOT NULL,
  `godina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `vrijeme` varchar(20) COLLATE utf8_croatian_ci NOT NULL,
  `id_odjel` int(11) NOT NULL,
  `soc_eko` text COLLATE utf8_croatian_ci NOT NULL,
  `cilj` text COLLATE utf8_croatian_ci NOT NULL,
  `sposobnost` text COLLATE utf8_croatian_ci NOT NULL,
  `prilagodljivost` text COLLATE utf8_croatian_ci NOT NULL,
  `odnos` text COLLATE utf8_croatian_ci NOT NULL,
  `doprinos` text COLLATE utf8_croatian_ci NOT NULL,
  `opis` text COLLATE utf8_croatian_ci NOT NULL,
  `zakljucak` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_tijek_napredovanja`
--

CREATE TABLE IF NOT EXISTS `ucenik_tijek_napredovanja` (
  `id_napredovanje` bigint(20) NOT NULL,
  `datum` date NOT NULL,
  `sadrzaj` text COLLATE utf8_croatian_ci NOT NULL,
  `dogovor` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_tijek_napredovanja_ponav`
--

CREATE TABLE IF NOT EXISTS `ucenik_tijek_napredovanja_ponav` (
  `id_tijek` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_napredovanje` bigint(20) NOT NULL,
  `datum` date NOT NULL,
  `sadrzaj` text COLLATE utf8_croatian_ci NOT NULL,
  `dogovor` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_tijek`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ucenik_tijek_pracenja_ponav`
--

CREATE TABLE IF NOT EXISTS `ucenik_tijek_pracenja_ponav` (
  `id_tijek` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_napredovanje` bigint(20) NOT NULL,
  `datum` date NOT NULL,
  `sadrzaj` text COLLATE utf8_croatian_ci NOT NULL,
  `dogovor` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_tijek`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
