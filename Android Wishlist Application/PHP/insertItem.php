<?php
  $db = new PDO("mysql:dbname=credentials;
    host=localhost","richts@localhost", "0741322");

  $sql = "INSERT INTO `items` (`u_name`, `item_name`, `item_price`) VALUES (?, ?, ?)";
  $statement = $db->prepare($sql);
  $statement->execute([$_GET["u_name"], str_replace("_"," ", $_GET["item_name"]), (double)$_GET["item_price"]]);
  echo str_replace("_"," ", $_GET["item_name"]);
?>
