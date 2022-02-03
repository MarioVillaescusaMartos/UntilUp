<?php

include("connection.php");

$username = $_GET["name"];
$password = $_GET["password"];
$newposX = $_GET['posX'];
$newposY = $_GET['posY'];
$newscore = $_GET['score'];
$newattempt = $_GET['attempt'];
$newhealth = $_GET['health'];
$newblasterbullet = $_GET['blasterbullet'];
$newlaserbullet = $_GET['laserbullet'];

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
$sqlInsertGameStats = "INSERT INTO gamestats(posx,posy,score,attempt,health,blasterbullet,laserbullet) VALUES ($newposX,$newposY,$newscore,$newattempt,$newhealth,$newblasterbullet,$newlaserbullet)";
mysqli_query($conn, $sqlInsertPlayers);
mysqli_query($conn, $sqlInsertGameStats);
//echo $newposX."  ".$newposY;//"INSERT INTO gamestats(posx,posy) VALUES ($newposX,$newposY)";




echo "0";

?>