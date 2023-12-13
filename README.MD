
<!-- Esta aplicación consiste en una cafetería en la cual puedes darte de alta, reservar mesas además de pedir cafés -->

<!-- Escribe la siguiente línea en la terminal para ejecutar la imagen normal -->
docker run -it --rm -p 7315:7315 ggszgz/coffeeroyale:latest

<!-- Escribe la siguiente línea en la terminal para ejecutar la imagen y crear dos volúmenes 
estos almacenaran los logs y los jsons de la aplicación en dos carpetas compartidas en local-->
<!-- este de abajo no va -->
<!-- docker run -it --rm -p 7315:7315 -v "$(pwd)\jsons:\app\Jsons" -v "$(pwd)\logs:\app\Utils" ggszgz/coffeeroyale:latest -->
<!-- este de abajo si funciona pero previamente create en el escritorio una carpeta llamada data y otra llamada utils-->
docker-compose run --rm --service-ports coffeeroyale /bin/bash
<!-- meter user en models para proximas funciones-->