<?php

include("connection.php");

$id_player = $_POST["id"];
$username = $_POST["name"];
$newscore = $_POST["score"];
$newattempt = $_POST['attempt'];
$newhealth = $_POST['health'];
$newblasterbullet = $_POST['blasterbullet'];
$newlaserbullet = $_POST['laserbullet'];

$usernameCheckQuery = "SELECT username FROM players WHERE username='".$username."';";

$usernameCheck = mysqli_query($conn, $usernameCheckQuery);
if (mysqli_num_rows($usernameCheck) != 1) 
{
	echo "No user with this username";
	exit();
}
/*$sqlInsertGamestats = "INSERT INTO gamestats(id_player,score) VALUES ('$id_player','$newscore')";
mysqli_query($conn, $sqlInsertGamestats);*/

$updatedataquery = "UPDATE gamestats gs, players pl SET gs.score = ".$newscore.",gs.attempt = ".$newattempt.",gs.health = ".$newhealth.",gs.blasterbullet = ".$newblasterbullet.",gs.laserbullet = ".$newlaserbullet." WHERE pl.username='".$username."' AND gs.id = pl.id;";
mysqli_query($conn, $updatedataquery);

echo "0";


?>