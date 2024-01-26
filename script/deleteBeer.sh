#!/bin/sh

if [ "$#" -ne 1 ]; then
    echo "Usage: $0 <beerId>"
    exit 1
fi
curl -i -X DELETE http://localhost:7042/api/beer/$1
