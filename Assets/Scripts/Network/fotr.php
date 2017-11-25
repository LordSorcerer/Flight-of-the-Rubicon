

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

//Get the user's information
$user = htmlspecialchars($_GET["username"]);
$pass = htmlspecialchars($_GET["password"]);
$newuser = htmlspecialchars($_POST["newusername"]);
$newpass = htmlspecialchars($_POST["newpassword"]);
echo $user . " / ";
echo $pass . " / ";
echo $newuser . " / ";
echo $newpass . " / ";
//Fetching from your database table.

//if($newuser && $newpass){

	$query = "INSERT INTO $usertable (username, password) VALUES ('$newuser','$newpass')";
//} else
if (isset($user, $pass)) {
	//echo "GET";
	$query = "SELECT * FROM $usertable WHERE username='$user' AND password='$pass'";
}

$result = mysql_query($query);

if (mysql_fetch_array($result)) {
    echo "successcode01";
} else {
	echo "errorcode01";
}
?>