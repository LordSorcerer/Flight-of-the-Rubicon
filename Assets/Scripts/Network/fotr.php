<?php
//Variables for connecting to your database.
//These variable values come from your hosting account.
$hostname = "fotrplayerbase.db.10912347.30a.hostedresource.net";
$username = "fotrplayerbase";
$dbname = "fotrplayerbase";

//These variable values need to be changed by you before deploying
$password = "Centaur1!";
$usertable = "authentication";

//Connecting to your database
mysql_connect($hostname, $username, $password) OR DIE ("Unable to
connect to database! Please try again later.");
mysql_select_db($dbname);

//GET method used to check existing account
if  ($_SERVER['REQUEST_METHOD'] === 'GET') {
	echo "GET";
	$user = htmlspecialchars($_GET["username"]);
	$pass = htmlspecialchars($_GET["password"]);
	echo $user . " / ";
	echo $pass . " / ";
	$query = "SELECT * FROM $usertable WHERE username='$user' AND password='$pass'";	
} else 
//Post method used to create new account
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    echo "POST";
    $newuser = htmlspecialchars($_POST["newusername"]);
	$newpass = htmlspecialchars($_POST["newpassword"]);
	echo $newuser . " / ";
	echo $newpass . " / ";
    $query = "INSERT INTO $usertable (username, password) VALUES ('$newuser','$newpass')";
}

//Return the result of the query, error or success
$result = mysql_query($query);
if (mysql_fetch_array($result)) {
    echo "successcode01";
} else {
	echo "errorcode01";
}
?>