-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 10 apr 2024 om 09:51
-- Serverversie: 10.4.32-MariaDB
-- PHP-versie: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `geldautomaat`
--
CREATE DATABASE IF NOT EXISTS `geldautomaat` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `geldautomaat`;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `admins`
--

CREATE TABLE `admins` (
  `Admin_ID` int(11) NOT NULL,
  `Gebruikersnaam` varchar(50) DEFAULT NULL,
  `Wachtwoord` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `admins`
--

INSERT INTO `admins` (`Admin_ID`, `Gebruikersnaam`, `Wachtwoord`) VALUES
(3, '1', '1');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `klanten`
--

CREATE TABLE `klanten` (
  `Klantnummer` int(11) NOT NULL,
  `Voornaam` varchar(50) DEFAULT NULL,
  `Achternaam` varchar(50) DEFAULT NULL,
  `Adres` varchar(100) DEFAULT NULL,
  `Contactgegevens` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `klanten`
--

INSERT INTO `klanten` (`Klantnummer`, `Voornaam`, `Achternaam`, `Adres`, `Contactgegevens`) VALUES
(14, 'Evert1245678', 'van Deventerman', 'Boekoeweg 21', 'Halalal23'),
(18, 'Voornaam', 'Achternaam', 'Adres', 'Contact'),
(19, 'Voornaam', 'Achternaam', 'Adres', 'Contact'),
(20, 'Banaan', 'Man', 'Banaanweg 1', 'Banaan@hotmail.com'),
(21, 'Voornaam', 'Achternaam', 'Adres', 'Contact'),
(22, 'Mike', 'Mananan', 'Mikestraat 13', 'Mike@mike.com');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `rekeningen`
--

CREATE TABLE `rekeningen` (
  `Rekeningnummer` varchar(50) NOT NULL,
  `Pincode` varchar(255) DEFAULT NULL,
  `Saldo` decimal(15,2) DEFAULT NULL,
  `Geblockt` tinyint(1) NOT NULL DEFAULT 0,
  `klanten_Klantnummer` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `rekeningen`
--

INSERT INTO `rekeningen` (`Rekeningnummer`, `Pincode`, `Saldo`, `Geblockt`, `klanten_Klantnummer`) VALUES
('1', '7c3afe3a3e156dc5c444f06025c5fbd09535cef5ffcb4d364586c71235ef10fc', 850.00, 0, 14),
('2', '525cfd02ce6f836ca4b1d8eeaf69a9a49cd3f0125f19ebe8cf1fda0c6ea0543a', 819.00, 0, 18),
('Banaanman123', '81e649b6fcfd9d691d4ac1337a5b4427cb3116cb0a857515389b60cbfa1daf3e', 860.00, 0, 20),
('Hallo123', '3742b6ed0958a48ac444666016bc97734d052ba6627be57eb11cabe63495b051', 8270.70, 1, 21),
('Mikedemogool', '5ad0e75a5119ff6de36d3fab783202c0224e685aa48461aed16aa72aa3960d21', 58905.00, 0, 22);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `transacties`
--

CREATE TABLE `transacties` (
  `Transactie_ID` int(11) NOT NULL,
  `rekeningen_Rekeningnummer` varchar(50) NOT NULL,
  `Datum_en_tijd` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Bedrag` decimal(15,2) DEFAULT NULL,
  `Soort` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `transacties`
--

INSERT INTO `transacties` (`Transactie_ID`, `rekeningen_Rekeningnummer`, `Datum_en_tijd`, `Bedrag`, `Soort`) VALUES
(53, 'Banaanman123', '2024-03-21 09:07:18', -300.00, ''),
(54, 'Banaanman123', '2024-03-21 09:07:25', -200.00, ''),
(55, 'Banaanman123', '2024-03-21 09:07:29', -100.00, ''),
(56, 'Hallo123', '2024-03-21 09:34:07', -50.00, ''),
(57, 'Hallo123', '2024-03-21 09:34:12', -50.00, ''),
(58, 'Hallo123', '2024-03-21 09:34:16', -50.00, ''),
(59, 'Hallo123', '2024-03-25 08:58:05', 100.00, ''),
(60, 'Hallo123', '2024-03-25 08:58:06', 100.00, ''),
(61, 'Hallo123', '2024-03-25 08:58:08', 100.00, ''),
(62, 'Hallo123', '2024-03-25 08:58:09', 100.00, ''),
(63, 'Hallo123', '2024-03-25 08:58:10', 100.00, ''),
(64, 'Banaanman123', '2024-03-25 09:20:26', -100.00, ''),
(65, 'Banaanman123', '2024-03-25 09:20:32', -100.00, ''),
(66, 'Banaanman123', '2024-03-25 09:20:39', 100.00, ''),
(67, 'Banaanman123', '2024-03-25 13:16:46', 100.00, ''),
(68, 'Hallo123', '2024-03-28 08:17:01', -100.00, ''),
(69, 'Hallo123', '2024-03-28 08:17:02', -100.00, ''),
(70, 'Hallo123', '2024-03-28 08:17:03', -100.00, ''),
(71, 'Hallo123', '2024-03-28 08:32:27', 100.00, ''),
(72, 'Hallo123', '2024-03-28 08:39:30', 100.00, ''),
(73, 'Banaanman123', '2024-03-28 08:44:40', 50.00, ''),
(74, 'Banaanman123', '2024-03-28 08:44:45', 10.00, ''),
(75, 'Banaanman123', '2024-03-28 08:44:56', -100.00, ''),
(76, 'Hallo123', '2024-03-28 08:57:47', 100.00, 'Opname'),
(77, 'Hallo123', '2024-03-28 08:57:56', 50.00, 'Opname'),
(78, 'Hallo123', '2024-03-28 08:59:58', 100.00, 'Opname'),
(79, 'Hallo123', '2024-03-28 09:00:10', 50.00, 'Opname'),
(80, 'Hallo123', '2024-03-28 09:06:02', 100.00, 'Opname'),
(81, 'Hallo123', '2024-03-28 09:12:43', 100.00, 'Opname'),
(82, 'Hallo123', '2024-03-28 09:12:48', 100.00, 'Opname'),
(83, 'Hallo123', '2024-03-28 09:14:22', 220.00, 'Storting'),
(84, 'Hallo123', '2024-03-28 09:15:03', 150.00, 'Storting'),
(85, 'Hallo123', '2024-03-28 09:15:14', 200.00, 'Storting'),
(86, 'Hallo123', '2024-03-28 09:18:15', 100.00, 'Opname'),
(87, 'Hallo123', '2024-03-28 09:18:35', 200.00, 'Opname'),
(88, 'Hallo123', '2024-03-28 09:18:36', 200.00, 'Opname'),
(89, 'Hallo123', '2024-03-28 09:18:36', 200.00, 'Opname'),
(90, 'Hallo123', '2024-03-28 09:18:36', 200.00, 'Opname'),
(91, 'Hallo123', '2024-03-28 09:18:36', 200.00, 'Opname'),
(92, 'Hallo123', '2024-03-28 09:18:37', 200.00, 'Opname'),
(93, 'Hallo123', '2024-03-28 09:18:37', 200.00, 'Opname'),
(94, 'Hallo123', '2024-03-28 09:18:37', 200.00, 'Opname'),
(95, 'Hallo123', '2024-03-28 09:18:38', 200.00, 'Opname'),
(96, 'Hallo123', '2024-03-28 09:18:38', 200.00, 'Opname'),
(97, 'Hallo123', '2024-03-28 09:18:38', 200.00, 'Opname'),
(98, 'Hallo123', '2024-03-28 09:18:38', 200.00, 'Opname'),
(99, 'Hallo123', '2024-03-28 09:18:38', 200.00, 'Opname'),
(100, 'Hallo123', '2024-03-28 09:20:37', 200.00, 'Opname'),
(101, 'Hallo123', '2024-03-28 09:20:38', 200.00, 'Opname'),
(102, 'Hallo123', '2024-03-28 09:20:38', 200.00, 'Opname'),
(103, 'Hallo123', '2024-03-28 09:23:19', 150.00, 'Opname'),
(104, 'Hallo123', '2024-03-28 09:23:20', 150.00, 'Opname'),
(105, 'Hallo123', '2024-03-28 09:23:20', 150.00, 'Opname'),
(106, 'Hallo123', '2024-03-28 09:26:15', 300.00, 'Opname'),
(107, 'Hallo123', '2024-03-28 09:27:13', 250.00, 'Opname'),
(108, 'Hallo123', '2024-03-28 09:27:29', 250.00, 'Opname'),
(109, 'Hallo123', '2024-03-28 09:48:55', 100.00, 'Opname'),
(110, '2', '2024-03-28 09:52:54', -100.00, 'Storting'),
(111, 'Hallo123', '2024-03-28 09:56:46', 100.00, 'Opname'),
(112, 'Hallo123', '2024-03-28 09:58:40', 50.00, 'Opname'),
(113, 'Hallo123', '2024-03-28 10:00:21', 100.00, 'Opname'),
(114, 'Hallo123', '2024-03-28 10:02:33', 50.40, 'Opname'),
(115, 'Hallo123', '2024-03-28 10:04:16', 100.00, 'Opname'),
(116, '2', '2024-03-28 10:06:06', 100.00, 'Opname'),
(117, '2', '2024-03-28 10:06:10', -50.00, 'Storting'),
(118, 'Hallo123', '2024-03-28 10:17:05', 100.00, 'Opname'),
(119, 'Hallo123', '2024-03-28 10:17:14', 200.30, 'Opname'),
(120, 'Hallo123', '2024-03-28 10:32:12', 400.00, 'Opname'),
(121, '1', '2024-04-04 08:48:34', 50.00, 'Opname'),
(122, 'Mikedemogool', '2024-04-04 11:27:56', 100.00, 'Opname'),
(123, 'Mikedemogool', '2024-04-04 11:28:00', 100.00, 'Opname'),
(124, 'Mikedemogool', '2024-04-04 11:28:02', 100.00, 'Opname'),
(125, 'Mikedemogool', '2024-04-04 11:28:11', 13000.00, 'Opname'),
(126, 'Mikedemogool', '2024-04-04 11:31:47', -120.00, 'Opname'),
(127, 'Mikedemogool', '2024-04-04 11:33:50', -100.00, 'Storting'),
(128, 'Mikedemogool', '2024-04-04 11:33:52', -100.00, 'Storting'),
(129, 'Mikedemogool', '2024-04-04 11:33:53', -100.00, 'Storting'),
(130, 'Mikedemogool', '2024-04-04 11:33:54', -100.00, 'Storting'),
(131, 'Mikedemogool', '2024-04-04 11:33:55', -100.00, 'Storting'),
(132, 'Mikedemogool', '2024-04-04 11:34:00', -100.00, 'Storting'),
(133, 'Mikedemogool', '2024-04-04 11:34:20', -120.00, 'Opname'),
(134, 'Mikedemogool', '2024-04-04 11:37:00', -100.00, 'Storting'),
(135, 'Mikedemogool', '2024-04-04 11:37:21', -100.00, 'Storting'),
(136, 'Mikedemogool', '2024-04-04 11:38:08', 100.00, 'Opname'),
(137, 'Mikedemogool', '2024-04-04 11:38:18', 100.00, 'Opname'),
(138, 'Mikedemogool', '2024-04-04 11:38:19', 100.00, 'Opname'),
(139, 'Mikedemogool', '2024-04-04 11:38:22', 45345.00, 'Opname'),
(140, 'Banaanman123', '2024-04-04 12:00:05', 100.00, 'Opname'),
(141, 'Banaanman123', '2024-04-04 12:00:06', 100.00, 'Opname'),
(142, 'Banaanman123', '2024-04-04 12:00:07', 100.00, 'Opname'),
(143, 'Banaanman123', '2024-04-04 12:00:09', 100.00, 'Opname'),
(144, 'Banaanman123', '2024-04-04 12:00:38', 100.00, 'Opname'),
(145, '1', '2024-04-04 12:04:07', 100.00, 'Storting'),
(146, '1', '2024-04-04 12:04:17', 100.00, 'Storting'),
(147, '1', '2024-04-04 12:04:18', 100.00, 'Storting'),
(148, '1', '2024-04-04 12:04:22', -100.00, 'Storting'),
(149, '1', '2024-04-04 12:04:24', -100.00, 'Storting'),
(150, '1', '2024-04-04 12:04:25', -100.00, 'Storting'),
(151, '1', '2024-04-04 12:04:26', -100.00, 'Storting'),
(152, '1', '2024-04-04 12:04:28', -100.00, 'Storting'),
(153, '2', '2024-04-04 12:07:52', 100.00, 'Storting'),
(154, '2', '2024-04-04 12:07:56', 100.00, 'Storting'),
(155, '2', '2024-04-04 12:08:00', 159.00, 'Storting'),
(156, '2', '2024-04-04 12:08:05', 100.00, 'Storting'),
(157, '2', '2024-04-04 12:08:10', -100.00, 'Opname'),
(158, '2', '2024-04-04 12:08:14', -100.00, 'Opname'),
(159, '2', '2024-04-04 12:08:21', -490.00, 'Opname'),
(160, '2', '2024-04-04 12:08:44', 100.00, 'Storting');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`Admin_ID`);

--
-- Indexen voor tabel `klanten`
--
ALTER TABLE `klanten`
  ADD PRIMARY KEY (`Klantnummer`);

--
-- Indexen voor tabel `rekeningen`
--
ALTER TABLE `rekeningen`
  ADD PRIMARY KEY (`Rekeningnummer`),
  ADD KEY `fk_rekeningen_klanten1_idx` (`klanten_Klantnummer`);

--
-- Indexen voor tabel `transacties`
--
ALTER TABLE `transacties`
  ADD PRIMARY KEY (`Transactie_ID`),
  ADD KEY `FK_removeOnDelete` (`rekeningen_Rekeningnummer`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `admins`
--
ALTER TABLE `admins`
  MODIFY `Admin_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT voor een tabel `klanten`
--
ALTER TABLE `klanten`
  MODIFY `Klantnummer` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT voor een tabel `transacties`
--
ALTER TABLE `transacties`
  MODIFY `Transactie_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=161;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `rekeningen`
--
ALTER TABLE `rekeningen`
  ADD CONSTRAINT `fk_rekeningen_klanten1` FOREIGN KEY (`klanten_Klantnummer`) REFERENCES `klanten` (`Klantnummer`) ON DELETE CASCADE ON UPDATE NO ACTION;

--
-- Beperkingen voor tabel `transacties`
--
ALTER TABLE `transacties`
  ADD CONSTRAINT `FK_removeOnDelete` FOREIGN KEY (`rekeningen_Rekeningnummer`) REFERENCES `rekeningen` (`Rekeningnummer`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
