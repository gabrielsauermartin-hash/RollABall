# Roll-a-ball

Un proyecto hecho en Unity como práctica para realizar videojuegos sencillos en 3D. Este proyecto 
contiene mecánicas de salto, recolección de objetos, IA de enemigos con patrullas y conos de visión, 
obstáculos, contador de puntos y la capacidad de reiniciar una partida una vez ganada o perdida.

### Prerequisitos

Es necesario tener una buena máquina para poder instalar y ejecutar proyectos de Unity, 
cualquier máquina de baja gama tendrá problemas a la hora de operar en el proyecto. Y, para cuando quiera iniciar
el juego, asegúrese de tener seleccionada la primera escena.

### Instalación

1. Asegúrese de tener Unity instalado primero.

2. Diríjase a el enlace de GitHub y descargue el proyecto:
https://github.com/gabrielsauermartin-hash/RollABall

3. Abra el proyecto dentro del entorno de Unity y ejecútelo (al ejecutarlo, deberían
descargarse todas las librerías que fueron usadas en el proyecto).

### Función extra

En el proyecto se ha implementado un sistema de patrulla y búsqueda donde, el enemigo atravesará el entorno pasando por puntos
de patrulla. Pero, en el momento en el que su cono de visión entre en contacto con el jugador, sin ningún obstáculo en el camino,
dejará la patrulla y perseguirá al jugador. Una vez el jugador rompa la línea de visión con el enemigo o salga de su cono de visión,
el enemigo reanudará la patrulla por donde la dejó.

## Autor

  - **Gabriel Sauer Martín**

<!--
## License

This project is licensed under the [CC0 1.0 Universal](LICENSE.md)
Creative Commons License - see the [LICENSE.md](LICENSE.md) file for
details

## Acknowledgments

  - Hat tip to anyone whose code is used
  - Inspiration
  - etc
->