#!/bin/sh

if [ "$#" -ne 1 ]; then
    echo "Usage: $0 <name>"
    exit 1
fi
curl -X POST -H "Content-Type: application/json" -d "{\"name\": \"$1\"}" http://localhost:7042/api/wholesaler