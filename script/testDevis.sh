#!/bin/sh

curl -X GET -H "Content-Type: application/json" -d '{"stocks": [{"beerId": 3, "quantity": 100}, {"beerId": 3, "quantity": 0}]}' http://localhost:7042/api/wholesaler/2/devis
