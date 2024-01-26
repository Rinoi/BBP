#!/bin/sh

if [ "$#" -ne 4 ]; then
    echo "Usage: $0 <name> <alcoholPercentage> <price> <breweryId>"
    exit 1
fi
curl -X POST -H "Content-Type: application/json" -d "{\"name\": \"$1\", \"alcoholPercentage\": $2, \"price\": $3, \"breweryId\": $4}" http://localhost:7042/api/beer