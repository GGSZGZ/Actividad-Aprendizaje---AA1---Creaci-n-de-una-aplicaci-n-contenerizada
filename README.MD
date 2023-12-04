
<!-- Esta aplicación consiste en una cafetería en la cual puedes darte de alta, reservar mesas además de pedir cafés -->

<!-- Escribe la siguiente línea en la terminal para ejecutar la imagen normal -->
docker run -it --rm -p 7315:7315 ggszgz/coffeeroyale:latest

<!-- Escribe la siguiente línea en la terminal para ejecutar la imagen y crear dos volúmenes 
estos almacenaran los logs y los jsons de la aplicación en dos carpetas compartidas en local-->
docker run -it --rm -p 7315:7315 -v "$(pwd)\jsons:\app\Jsons" -v "$(pwd)\logs:\app\Utils" ggszgz/coffeeroyale:latest
