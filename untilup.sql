-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-12-2021 a las 12:25:48
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
  `attempt` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gamestats`
--

INSERT INTO `gamestats` (`id_player`, `id`, `score`, `attempt`) VALUES
(1, 1, 5, 0),
(3, 2, 16, 0),
(2, 3, 27, 0),
(3, 4, 6, 0);

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
(1, 'm', '$5$rounds=5000$steamedhamsm$c7CUesQ15EFDi8wKK/IRHXT6YYbFYAUK5oJZ.DkV4p2', '$5$rounds=5000$steamedhamsm$'),
(2, 'k', '$5$rounds=5000$steamedhamsk$IKxeIXjs60HQSXrZAN4eHwa1ZaKBQf8qh7ePWKnwmZ6', '$5$rounds=5000$steamedhamsk$'),
(3, 'z', '$5$rounds=5000$steamedhamsz$d.d50h74CA34i9oSceg5LELIJ4eHBQhY5lD3JZx0iB/', '$5$rounds=5000$steamedhamsz$');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `gamestats`
--
ALTER TABLE `gamestats`
  ADD PRIMARY KEY (`id`,`id_player`),
  ADD KEY `id_player` (`id_player`);

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
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `players`
--
ALTER TABLE `players`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
