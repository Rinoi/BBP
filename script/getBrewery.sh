#!/bin/sh

if [ "$#" -ne 1 ]; then
    echo "Usage: $0 <breweryId>"
    exit 1
fi
curl -X GET http://localhost:7042/api/brewery/$1