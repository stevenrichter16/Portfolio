<?php
  $db = new PDO("mysql:dbname=credentials;
    host=localhost","richts@localhost", "0741322");
    $username = $_GET['u_name'];

    // For checking register condition (if username already exists)
    $sql = "SELECT `u_name` FROM `creds` WHERE `u_name`='$username'";
    $result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
        foreach($result as $row) {
        echo $row['u_name'];
    }
?>
