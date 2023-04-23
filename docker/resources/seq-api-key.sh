#!/bin/bash

SERVICE="http://recrutseqlog"

until curl -fs $SERVICE  > /dev/null; do
  >&2 echo "$SERVICE is unavailable - sleeping"
  sleep 2
done
>&2 echo "$SERVICE is up"

./bin/seqcli/seqcli apikey create --title='recrutApiKey' --token='dYdpT4YwLXXZ4Yso3twn' --server=$SERVICE

sleep infinity 