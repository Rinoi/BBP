#!/bin/sh

curl -X GET -H "Content-Type: application/json" -d '{"stocks": [{"beerId": 1, "quantity": 4}, {"beerId": 2, "quantity": 7}]}' http://localhost:7042/api/wholesaler/1/devis
