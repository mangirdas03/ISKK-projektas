-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 08, 2021 at 06:05 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `iskk`
--

-- --------------------------------------------------------

--
-- Table structure for table `avalynė`
--

CREATE TABLE `avalynė` (
  `dydis` int(11) NOT NULL,
  `kaina` double NOT NULL,
  `spalva` varchar(20) NOT NULL,
  `partijos_numeris` int(11) NOT NULL,
  `pagaminimo_data` date NOT NULL,
  `individualus_numeris` int(11) NOT NULL,
  `fk_Modelisid_Modelis` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `avalynė`
--

INSERT INTO `avalynė` (`dydis`, `kaina`, `spalva`, `partijos_numeris`, `pagaminimo_data`, `individualus_numeris`, `fk_Modelisid_Modelis`) VALUES
(39, 615, 'Balta', 42342, '2021-03-22', 12312, 1031),
(44, 690, 'Juoda', 455, '2021-03-08', 41146, 10),
(43, 795, 'Oranžinė/Balta', 4324, '2021-08-13', 42344, 100),
(38, 700, 'Juoda', 4324, '2021-08-14', 42345, 100),
(43, 615, 'Juoda/Balta', 23, '2020-08-18', 45235, 1031),
(40, 175, 'Žalia/Juoda', 111115, '2021-10-03', 54353, 101),
(43, 175, 'Juoda/Raudona', 6554, '2021-07-06', 111112, 101),
(42, 175, 'Juoda/Raudona', 5555, '2021-07-06', 111113, 101),
(39, 175, 'Balta', 435, '2021-10-15', 111114, 101),
(45, 2000, 'Pilka/Balta', 5453, '2021-10-10', 111116, 101),
(41, 220, 'Balta', 3334, '2021-02-19', 321423, 104),
(44, 220.99, 'Balta', 1562, '2021-07-06', 538238, 1),
(42, 890, 'Bordo/Juoda', 3424, '2021-10-05', 543532, 10200),
(43, 797, 'Juoda', 10006, '2021-06-15', 543534, 10200),
(37, 160.99, 'Raudona/Balta', 33, '2021-05-10', 1236234, 201),
(43, 120.99, 'Raudona/Balta', 5435, '2021-10-01', 5654534, 201),
(46, 120.99, 'Mėlyna/Balta', 5345, '2021-02-15', 6543456, 201),
(43, 220.99, 'Pilka/Oranžinė', 1562, '2021-03-21', 7172864, 1),
(39, 220.99, 'Multi', 1588, '2020-11-17', 8725723, 2),
(44, 180, 'Balta/Raudona', 43244, '2021-02-02', 12312321, 102),
(45, 220.99, 'Juoda/Balta', 1562, '2021-02-22', 23467235, 1),
(41, 120.99, 'Juoda/Balta', 1235, '2021-10-04', 34565453, 201),
(44, 220, 'Mėlyna/Juoda', 32123, '2010-11-02', 54543455, 104),
(36, 220.99, 'Ruda', 1562, '2021-03-28', 67257341, 1),
(45, 220, 'Balta/Raudona', 4324, '2000-01-02', 67345645, 104),
(40, 400, 'Juoda', 1588, '2021-06-26', 72345723, 2);

-- --------------------------------------------------------

--
-- Table structure for table `dizaineris`
--

CREATE TABLE `dizaineris` (
  `vardas` varchar(20) NOT NULL,
  `pavardė` varchar(20) NOT NULL,
  `asmens_kodas` int(11) NOT NULL,
  `gimimo_data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dizaineris`
--

INSERT INTO `dizaineris` (`vardas`, `pavardė`, `asmens_kodas`, `gimimo_data`) VALUES
('Rick', 'Owens', 1111397355, '1990-10-05'),
('Kanye', 'West', 1111998773, '1986-06-13'),
('Daniel', 'Lee', 2121394498, '1990-11-25'),
('Tinker', 'Hatfield', 2121397348, '1976-08-01'),
('Maison', 'Margiela', 2121397349, '1976-09-01'),
('Dries', 'Van Noten', 2121999998, '1977-01-02'),
('Raf', 'Simons', 2125222333, '1966-11-22');

-- --------------------------------------------------------

--
-- Table structure for table `gamintojas`
--

CREATE TABLE `gamintojas` (
  `pavadinimas` varchar(20) NOT NULL,
  `įkūrimo_data` date NOT NULL,
  `metinis_pelnas` int(11) NOT NULL,
  `id_Gamintojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `gamintojas`
--

INSERT INTO `gamintojas` (`pavadinimas`, `įkūrimo_data`, `metinis_pelnas`, `id_Gamintojas`) VALUES
('Nike', '1964-01-25', 37000000, 1),
('Adidas', '1974-01-25', 6556546, 2),
('Bottega Veneta', '1988-05-21', 5453345, 3),
('DRKSHDW', '2000-06-08', 5453453, 6),
('Balenciaga', '1998-11-17', 2312333, 7);

-- --------------------------------------------------------

--
-- Table structure for table `medžiaga`
--

CREATE TABLE `medžiaga` (
  `pavadinimas` varchar(20) NOT NULL,
  `tipas` varchar(20) NOT NULL,
  `apdirbimas` varchar(20) NOT NULL,
  `id_Medžiaga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `medžiaga`
--

INSERT INTO `medžiaga` (`pavadinimas`, `tipas`, `apdirbimas`, `id_Medžiaga`) VALUES
('Orch', 'nailonas', 'lygus', 1001),
('Fondant', 'tekstilė', 'nėra', 1002),
('Nero', 'oda', 'lygi', 1003),
('Treh', 'versta oda', 'grublėta', 1004);

-- --------------------------------------------------------

--
-- Table structure for table `modelis`
--

CREATE TABLE `modelis` (
  `pavadinimas` varchar(20) NOT NULL,
  `sukūrimo_data` date NOT NULL,
  `patento_numeris` int(11) NOT NULL,
  `id_Modelis` int(11) NOT NULL,
  `fk_Dizainerisasmens_kodas` int(11) NOT NULL,
  `fk_Gamintojasid_Gamintojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `modelis`
--

INSERT INTO `modelis` (`pavadinimas`, `sukūrimo_data`, `patento_numeris`, `id_Modelis`, `fk_Dizainerisasmens_kodas`, `fk_Gamintojasid_Gamintojas`) VALUES
('Yeezy 350 v2', '2016-12-13', 3434, 1, 2125222333, 2),
('Yeezy 700', '2017-02-08', 9846, 2, 1111998773, 2),
('Triple S', '2016-06-22', 1111, 10, 2121394498, 7),
('Track', '2017-04-13', 6522, 100, 1111998773, 7),
('Jordan 1', '1985-02-03', 3455, 101, 2121397348, 1),
('Jordan 2', '1999-12-23', 5453, 102, 2121394498, 1),
('Jordan 4', '1998-08-08', 7374, 104, 2121999998, 1),
('Dunk', '1986-08-19', 1122, 201, 2121397349, 1),
('Ramones', '2011-02-26', 3213, 1031, 1111397355, 6),
('Lug boot', '2019-02-26', 76, 10200, 2121394498, 3);

-- --------------------------------------------------------

--
-- Table structure for table `naudoja`
--

CREATE TABLE `naudoja` (
  `fk_Avalynėindividualus_numeris` int(11) NOT NULL,
  `fk_Medžiagaid_Medžiaga` int(11) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `naudoja`
--

INSERT INTO `naudoja` (`fk_Avalynėindividualus_numeris`, `fk_Medžiagaid_Medžiaga`, `id`) VALUES
(12312, 1002, 1),
(41146, 1002, 3),
(42344, 1001, 4),
(42345, 1003, 5),
(45235, 1003, 6),
(54353, 1001, 7),
(111112, 1003, 8),
(111113, 1003, 9),
(111114, 1001, 10),
(111116, 1002, 11),
(321423, 1002, 12),
(543532, 1001, 14),
(543534, 1004, 15),
(1236234, 1001, 16),
(5654534, 1003, 17),
(6543456, 1004, 18),
(7172864, 1002, 19),
(8725723, 1003, 20),
(12312321, 1001, 21),
(23467235, 1003, 22),
(34565453, 1003, 23),
(54543455, 1004, 24),
(67257341, 1004, 25),
(67345645, 1003, 26),
(72345723, 1002, 27),
(111112, 1002, 38);

-- --------------------------------------------------------

--
-- Table structure for table `samdo`
--

CREATE TABLE `samdo` (
  `fk_Dizainerisasmens_kodas` int(11) NOT NULL,
  `fk_Gamintojasid_Gamintojas` int(11) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `samdo`
--

INSERT INTO `samdo` (`fk_Dizainerisasmens_kodas`, `fk_Gamintojasid_Gamintojas`, `id`) VALUES
(1111397355, 6, 1),
(1111998773, 2, 2),
(1111998773, 7, 3),
(2121394498, 1, 4),
(2121394498, 3, 5),
(2121394498, 7, 6),
(2121397348, 1, 7),
(2121397349, 1, 8),
(2121999998, 1, 9),
(2125222333, 2, 10);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `avalynė`
--
ALTER TABLE `avalynė`
  ADD PRIMARY KEY (`individualus_numeris`),
  ADD KEY `turi` (`fk_Modelisid_Modelis`);

--
-- Indexes for table `dizaineris`
--
ALTER TABLE `dizaineris`
  ADD PRIMARY KEY (`asmens_kodas`);

--
-- Indexes for table `gamintojas`
--
ALTER TABLE `gamintojas`
  ADD PRIMARY KEY (`id_Gamintojas`);

--
-- Indexes for table `medžiaga`
--
ALTER TABLE `medžiaga`
  ADD PRIMARY KEY (`id_Medžiaga`);

--
-- Indexes for table `modelis`
--
ALTER TABLE `modelis`
  ADD PRIMARY KEY (`id_Modelis`),
  ADD KEY `kuria` (`fk_Dizainerisasmens_kodas`),
  ADD KEY `priklauso` (`fk_Gamintojasid_Gamintojas`);

--
-- Indexes for table `naudoja`
--
ALTER TABLE `naudoja`
  ADD PRIMARY KEY (`fk_Avalynėindividualus_numeris`,`fk_Medžiagaid_Medžiaga`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `fk_Medžiagaid_Medžiaga` (`fk_Medžiagaid_Medžiaga`);

--
-- Indexes for table `samdo`
--
ALTER TABLE `samdo`
  ADD PRIMARY KEY (`fk_Dizainerisasmens_kodas`,`fk_Gamintojasid_Gamintojas`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `test` (`fk_Gamintojasid_Gamintojas`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `naudoja`
--
ALTER TABLE `naudoja`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `samdo`
--
ALTER TABLE `samdo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `avalynė`
--
ALTER TABLE `avalynė`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_Modelisid_Modelis`) REFERENCES `modelis` (`id_Modelis`);

--
-- Constraints for table `modelis`
--
ALTER TABLE `modelis`
  ADD CONSTRAINT `kuria` FOREIGN KEY (`fk_Dizainerisasmens_kodas`) REFERENCES `dizaineris` (`asmens_kodas`),
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_Gamintojasid_Gamintojas`) REFERENCES `gamintojas` (`id_Gamintojas`);

--
-- Constraints for table `naudoja`
--
ALTER TABLE `naudoja`
  ADD CONSTRAINT `naudoja` FOREIGN KEY (`fk_Avalynėindividualus_numeris`) REFERENCES `avalynė` (`individualus_numeris`),
  ADD CONSTRAINT `naudoja_ibfk_1` FOREIGN KEY (`fk_Medžiagaid_Medžiaga`) REFERENCES `medžiaga` (`id_Medžiaga`);

--
-- Constraints for table `samdo`
--
ALTER TABLE `samdo`
  ADD CONSTRAINT `samdo` FOREIGN KEY (`fk_Dizainerisasmens_kodas`) REFERENCES `dizaineris` (`asmens_kodas`),
  ADD CONSTRAINT `test` FOREIGN KEY (`fk_Gamintojasid_Gamintojas`) REFERENCES `gamintojas` (`id_Gamintojas`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
