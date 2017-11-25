<?php
//Variables for connecting to your database.
//These variable values come from your hosting account.
$hostname = "fotrplayerbase.db.10912347.30a.hostedresource.net";
$username = "fotrplayerbase";
$dbname = "fotrplayerbase";

//These variable values need to be changed by you before deploying
$password = "Centaur1!";
$usertable = "authentication";
$yourfield = "username";

//Connecting to your database
mysql_connect($hostname, $username, $password) OR DIE ("Unable to
connect to database! Please try again later.");
mysql_select_db($dbname);

//Fetching from your database table.
$query = "SELECT * FROM $usertable";
$result = mysql_query($query);

if ($result) {
    while($row = mysql_fetch_array($result)) {
        $name = $row["$yourfield"];
        echo "Name $name<br>";
        echo 'Hello ' . htmlspecialchars($_GET["username"]) . '!';
    }
}
?>