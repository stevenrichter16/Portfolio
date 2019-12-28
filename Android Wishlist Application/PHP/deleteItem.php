<?php
    $db = new PDO("mysql:dbname=credentials;
    host=localhost","richts@localhost", "0741322");

    // DELETE FROM `items` WHERE `u_name`='steven' AND `item_name`='laptop'
    try {
        $sql = "DELETE FROM `items` WHERE `u_name`=:uname AND `item_name`=:itemname";
        $statement = $db->prepare($sql);

        $statement->bindParam(":uname", $_GET["u_name"]);

        $item_name = str_replace("_"," ", $_GET["item_name"]);
        $statement->bindParam(":itemname", $item_name);
        
        $statement->execute();
    }
    catch(PDOException $e) {
        echo "error";
    }


   
?>
