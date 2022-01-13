<?php

include("connection.php");

$username = $_POST["name"];
$newscore = $_POST["score"];
$id_player = $_POST["id"];

$usernameCheckQuery = "SELECT username FROM players WHERE username='".$username."';";

$usernameCheck = mysqli_query($conn, $usernameCheckQuery);
if (mysqli_num_rows($usernameCheck) != 1) 
{
	echo "No user with this username";
	exit();
}
$sqlInsertGamestats = "INSERT INTO gamestats(id_player,score) VALUES ('$id_player','$newscore')";
mysqli_query($conn, $sqlInsertGamestats);

/*$updatedataquery = "UPDATE gamestats gs, players pl SET gs.score = ".$newscore." WHERE pl.username='".$username."' AND gs.id_player=pl.id;";
mysqli_query($conn, $updatedataquery);*/

echo "0";


?>