<?php
  $db = new PDO("mysql:dbname=credentials;
    host=localhost","richts@localhost", "0741322");
  $username = $_GET['u_name'];
  $password = $_GET['p_word'];

  $sql = "SELECT `u_name`,`p_word` FROM `creds` WHERE `u_name`='$username' AND `p_word`='$password'";
  $result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
  foreach($result as $row) {
    echo $row['u_name'];
    echo $row['p_word'];
  }
?>