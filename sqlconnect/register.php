<?php

include("connection.php");

$username = $_POST["name"];
$password = $_POST["password"];

//Check if the input username already exists
$usernameCheckQuery = "SELECT username FROM players WHERE username='".$username."';";

$usernameCheck = mysqli_query($conn, $usernameCheckQuery);

if (mysqli_num_rows($usernameCheck) > 0)
{
	echo "Username already exists";
	echo "Error: ".$sqli."<br>".mysqli_error($conn);
	exit();
}

//Prepare the insert for the input username and password, salt and hash is created to pretect the password
$salt = "\$5\$rounds=5000\$" ."steamedhams".$username."\$";
$hash = crypt($password, $salt);

$sqlInsertPlayers = "INSERT INTO players(username,hash,salt) VALUES ('$username','$hash','$salt')";


mysqli_query($conn, $sqlInsertPlayers);

echo "0";//0 = No errors

?>