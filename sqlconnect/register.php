<?php

include("connection.php");

$username = $_POST["name"];
$password = $_POST["password"];

$usernameCheckQuery = "SELECT username FROM players WHERE username='".$username."';";

$usernameCheck = mysqli_query($conn, $usernameCheckQuery);

if (mysqli_num_rows($usernameCheck) > 0)
{
	echo "Username already exists";
	//echo "Error: ".$sqli."<br>".mysqli_error($conn);
	exit();
}

$salt = "\$5\$rounds=5000\$" ."steamedhams".$username."\$";
$hash = crypt($password, $salt);

$sqlInsert = "INSERT INTO players(username,hash,salt) VALUES ('$username','$hash','$salt')";

mysqli_query($conn, $sqlInsert);

echo "0";//0 = No errors

?>