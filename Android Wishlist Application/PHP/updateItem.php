<?php
    $db = new PDO("mysql:dbname=credentials;
    host=localhost","richts@localhost", "0741322");

    // UPDATE `items` SET `u_name`='steven',`item_name`='MacBook Pro', `item_price`=9000.0 WHERE `u_name`='steven' AND `item_name`='MacBook Pro'
    try {
        $username = $_GET["u_name"];
        $old_item_name = str_replace("_"," ",$_GET["old_itemname"]);
        $new_item_name = str_replace("_"," ",$_GET["new_itemname"]);
        $new_item_price = (double)$_GET["new_itemprice"];

        $sql = "UPDATE `items` SET `item_name`= ?, `item_price`= ? WHERE `u_name`= ? AND `item_name`= ?";

        //$sql = "UPDATE `items` SET `u_name`=:uname" . "," . "`item_name`=:new_itemname" . "," . "`item_price`=:new_itemprice" . " WHERE `u_name`=:uname AND `item_name`=:old_itemname";
        $statement = $db->prepare($sql);
        $statement->execute([$new_item_name, $new_item_price, $username, $old_item_name]);
    }
    catch(PDOException $e) {
        echo "error";
    }
?>
