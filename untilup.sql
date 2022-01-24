-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 24-01-2022 a las 14:29:35
-- Versión del servidor: 10.4.19-MariaDB
-- Versión de PHP: 8.0.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `untilup`
--
CREATE DATABASE IF NOT EXISTS `untilup` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `untilup`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gamestats`
--

DROP TABLE IF EXISTS `gamestats`;
CREATE TABLE `gamestats` (
  `id_player` int(10) NOT NULL,
  `id` int(10) NOT NULL,
  `score` int(100) NOT NULL,
  `attempt` int(100) NOT NULL,
  `health` int(1) NOT NULL,
  `blasterbullet` int(3) NOT NULL,
  `laserbullet` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gamestats`
--

INSERT INTO `gamestats` (`id_player`, `id`, `score`, `attempt`, `health`, `blasterbullet`, `laserbullet`) VALUES
(0, 1, 0, 0, 1, 5, 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `players`
--

DROP TABLE IF EXISTS `players`;
CREATE TABLE `players` (
  `id` int(10) NOT NULL,
  `username` varchar(16) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `players`
--

INSERT INTO `players` (`id`, `username`, `hash`, `salt`) VALUES
(1, 'j', '$5$rounds=5000$steamedhamsj$4J6s/RgF6y553.T/dpwuZqejPimym6hbH7s2G63cvD6', '$5$rounds=5000$steamedhamsj$');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `gamestats`
--
ALTER TABLE `gamestats`
  ADD PRIMARY KEY (`id`,`id_player`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indices de la tabla `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `username_2` (`username`),
  ADD KEY `id` (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `gamestats`
--
ALTER TABLE `gamestats`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `players`
--
ALTER TABLE `players`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
