<?php
  $db = new PDO("mysql:dbname=credentials;
    host=localhost","richts@localhost", "0741322");
  $username = $_GET['u_name'];
  $password = $_GET['p_word'];

  $sql = "INSERT INTO `creds` (`u_name`, `p_word`) VALUES ('$username','$password')";

  $db->query($sql);
?>
