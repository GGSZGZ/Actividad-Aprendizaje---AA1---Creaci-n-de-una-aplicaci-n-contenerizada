
<!-- Por favor lee atentamente las siguientes instrucciones -->

<!-- Escribe la siguiente línea en la terminal para ejecutar la imagen normal -->
docker run -it --rm -p 7315:7315 ggszgz/coffeeroyale:latest

<!-- Escribe la siguiente línea en la terminal para ejecutar la imagen y crear dos volúmenes 
estos almacenaran los logs y los jsons de la aplicación-->
docker run -v "jsons:/app/Jsons" -v "logs:/app/Utils" -it --rm -p 7315:7315 ggszgz/coffeeroyale:latest

