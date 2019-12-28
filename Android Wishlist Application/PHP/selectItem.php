<?php
    $db = new PDO("mysql:dbname=credentials;
    host=localhost","richts@localhost", "0741322");

    // SELECT * FROM `items` WHERE `u_name`='steven' AND `item_name`='laptop'
    try {
        $username = $_GET["u_name"];

        $sql = "SELECT * FROM `items` WHERE `u_name`= '$username'";
        $result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
        $print = [];

        foreach($result as $row) {
            $print[] = $row;
        }
        echo json_encode($print);
    }
    catch(PDOException $e) {
        echo "error";
    }
?>
