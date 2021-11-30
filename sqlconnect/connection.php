<?php

$dbhost = "sql4.freemysqlhosting.nett";
$dbuser = "sql4455360";
$dbpass = "Qn35xDJKkl";
$dbname = "sql4455360";

/*$dbhost = "localhost";
$dbuser = "root";
$dbpass = "";
$dbname = "unityacces";*/

$conn = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname);
if (!$conn)
{
	die("No hay conexión: ".mysqli_connect_error());
}

?>