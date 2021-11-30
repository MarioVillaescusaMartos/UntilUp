<?php

include("connection.php");

$username = $_POST["name"];
$password = $_POST["password"];

$usernameCheckQuery = "SELECT * FROM players WHERE username='".$username."';";

$usernameCheck = mysqli_query($conn, $usernameCheckQuery);

if (mysqli_num_rows($usernameCheck) != 1) 
{
	echo "No user with this username";
	exit();
}

$existsLoginInfo = mysqli_fetch_assoc($usernameCheck);
$salt = $existsLoginInfo["salt"];
$hash = $existsLoginInfo["hash"];

$loginHash = crypt($password, $salt);
if ($hash != $loginHash)
{
	echo "Incorrect password";
	exit();
}

echo "0\t" .$existsLoginInfo["score"];


?>