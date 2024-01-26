#!/bin/sh

if [ "$#" -ne 1 ]; then
    echo "Usage: $0 <wholesalerId>"
    exit 1
fi
curl -X GET http://localhost:7042/api/wholesaler/$1