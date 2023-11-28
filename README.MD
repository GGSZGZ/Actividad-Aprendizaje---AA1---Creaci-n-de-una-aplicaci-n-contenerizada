#!/bin/bash

Nombres de los volúmenes
VOLUMEN1="volumejson"
VOLUMEN2="volumelogs"

Rutas a los archivos existentes
JSON_FILE="*.json"
TXT_FILE="Utils/error_logs.txt"

Eliminar los volúmenes si existen
docker volume rm $VOLUMEN1 2>/dev/null
docker volume rm $VOLUMEN2 2>/dev/null

Crear los nuevos volúmenes
docker volume create $VOLUMEN1
docker volume create $VOLUMEN2

Copiar archivos a los volúmenes
docker run -v $VOLUMEN1:/app -v $(pwd):/host -w /app --rm mcr.microsoft.com/dotnet/aspnet:6.0 cp /host/$JSON_FILE .
docker run -v $VOLUMEN2:/app -v $(pwd):/host -w /app --rm mcr.microsoft.com/dotnet/aspnet:6.0 cp /host/$TXT_FILE .

docker run -it --rm -p 7315:7315 ggszgz/coffeeroyale:latest