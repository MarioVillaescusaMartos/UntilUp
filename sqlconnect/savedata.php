<?php

include("connection.php");

$username = $_POST["name"];
$newscore = $_POST["score"];

$usernameCheckQuery = "SELECT username FROM players WHERE username='".$username."';";

$usernameCheck = mysqli_query($conn, $usernameCheckQuery);
if (mysqli_num_rows($usernameCheck) != 1) 
{
	echo "No user with this username";
	exit();
}

$updatedataquery = "UPDATE players SET score = ".$newscore." WHERE username = '".$username."';";
mysqli_query($conn, $updatedataquery);

echo "0";


?>