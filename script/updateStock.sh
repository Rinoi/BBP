#!/bin/sh

if [ "$#" -ne 3 ]; then
    echo "Usage: $0 <wholesalerId> <BeerId> <Quantity>"
    exit 1
fi
curl -X PUT -H "Content-Type: application/json" -d "{\"BeerId\": $2, \"Quantity\": $3}" http://localhost:7042/api/wholesaler/$1/stock