<?php

include("connection.php");

$id_player = $_GET["id"];
$username = $_GET["name"];
$newposX = $_GET['posX'];
$newposY = $_GET['posY'];
$newscore = $_GET['score'];
$newattempt = $_GET['attempt'];
$newhealth = $_GET['health'];
$newblasterbullet = $_GET['blasterbullet'];
$newlaserbullet = $_GET['laserbullet'];

$usernameCheckQuery = "SELECT username FROM players WHERE username='".$username."';";

$usernameCheck = mysqli_query($conn, $usernameCheckQuery);
if (mysqli_num_rows($usernameCheck) != 1) 
{
	echo "Not saved correctly!";
	exit();
}

$updatedataquery = "UPDATE gamestats gs, players pl SET gs.posx = ".$newposX.", gs.posy = ".$newposY." , gs.score = ".$newscore.", gs.attempt = ".$newattempt.", gs.health = ".$newhealth.", gs.blasterbullet = ".$newblasterbullet.", gs.laserbullet = ".$newlaserbullet." WHERE pl.username='".$username."' AND gs.id = pl.id;";
mysqli_query($conn, $updatedataquery);

echo "0";
?>