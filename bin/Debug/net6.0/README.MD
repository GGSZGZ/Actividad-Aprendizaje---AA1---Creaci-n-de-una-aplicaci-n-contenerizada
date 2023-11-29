#!/bin/bash

Nombres de los volúmenes
VOLUMEN1="volumejson"
VOLUMEN2="volumelogs"


Copiar archivos a los volúmenes
docker run -v $VOLUMEN1:/app -v $(pwd)/log:/app/Jsons --rm mcr.microsoft.com/dotnet/aspnet:6.0
docker run -v $VOLUMEN2:/app -v $(pwd):/app/Utils --rm mcr.microsoft.com/dotnet/aspnet:6.0

#Escribe la siguiente línea en la terminal para ejecutar la imagen normal
docker run -it --rm -p 7315:7315 ggszgz/coffeeroyale:latest