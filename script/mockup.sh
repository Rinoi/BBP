#!/bin/sh

SCRIPT_DIR="$(dirname "$(readlink -f "$0")")"

$SCRIPT_DIR/addBrewery.sh "Brasseur toto"
$SCRIPT_DIR/addBrewery.sh "The best Brasseur"
$SCRIPT_DIR/addBrewery.sh "Le medium"
$SCRIPT_DIR/addBrewery.sh "le null"

$SCRIPT_DIR/addBeer.sh "Stella" "5.0" "3.50" "1"
$SCRIPT_DIR/addBeer.sh "Guinness" "4.2" "5.00" "1"
$SCRIPT_DIR/addBeer.sh "Corona" "4.5" "4.20" "1"
$SCRIPT_DIR/addBeer.sh "Heineken" "5.4" "3.80" "2"
$SCRIPT_DIR/addBeer.sh "Pilsner" "4.8" "3.60" "2"
$SCRIPT_DIR/addBeer.sh "Amber" "6.2" "4.90" "3"
$SCRIPT_DIR/addBeer.sh "Porter" "5.8" "5.50" "3"
$SCRIPT_DIR/addBeer.sh "Lager" "4.0" "3.30" "4"

$SCRIPT_DIR/addWholesaler.sh "Bièrocentrale"
$SCRIPT_DIR/addWholesaler.sh "BrassMarket"
$SCRIPT_DIR/addWholesaler.sh "HopGros"
$SCRIPT_DIR/addWholesaler.sh "BevExpo"

#Add stock
$SCRIPT_DIR/updateStock.sh 1 1 25
$SCRIPT_DIR/updateStock.sh 1 2 10
$SCRIPT_DIR/updateStock.sh 1 5 35

$SCRIPT_DIR/updateStock.sh 2 1 24
$SCRIPT_DIR/updateStock.sh 2 3 100
$SCRIPT_DIR/updateStock.sh 2 4 8

$SCRIPT_DIR/updateStock.sh 3 1 1
$SCRIPT_DIR/updateStock.sh 3 2 1
$SCRIPT_DIR/updateStock.sh 3 3 1
$SCRIPT_DIR/updateStock.sh 3 4 1
$SCRIPT_DIR/updateStock.sh 3 5 1
$SCRIPT_DIR/updateStock.sh 3 6 1
$SCRIPT_DIR/updateStock.sh 3 7 1
$SCRIPT_DIR/updateStock.sh 3 8 1

$SCRIPT_DIR/updateStock.sh 4 1 22
$SCRIPT_DIR/updateStock.sh 4 7 420


