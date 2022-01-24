<?php

include("connection.php");

$username = $_POST["name"];
$password = $_POST["password"];
$newscore = $_POST["score"];
$newattempt = $_POST['attempt'];
$newhealth = $_POST['health'];
$newblasterbullet = $_POST['blasterbullet'];
$newlaserbullet = $_POST['laserbullet'];

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
$sqlInsertGameStats = "INSERT INTO gamestats(score,attempt,health,blasterbullet,laserbullet) VALUES ('$newscore','$newattempt','$newhealth','$newblasterbullet','$newlaserbullet')";


mysqli_query($conn, $sqlInsertPlayers);
mysqli_query($conn, $sqlInsertGameStats);

echo "0\t";//0 = No errors

?>