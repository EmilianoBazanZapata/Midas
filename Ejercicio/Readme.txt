Code Review / Refactoring exercise

Please review the following code snippet. Assume that all referenced assemblies have
been properly included.

The code is used to log different messages throughout an application. We want the ability
to be able to log to a text file, the console and/or the database. Messages can be marked
as message, warning or error. We also want the ability to selectively be able to choose
what gets logged, such as to be able to log only errors or only errors and warnings.

	1. If you were to review the following code, what feedback would you give? Please be
specific and indicate any errors that would occur as well as other best practices and
code refactoring that should be done.
	2. Rewrite the code based on the feedback you provided in question 1. Please include
unit tests on your code.

Code Review / Refactoring exercise

Please review the following code snippet. Assume that all referenced assemblies have
been properly included.

The code is used to log different messages throughout an application. We want the ability
to be able to log to a text file, the console and/or the database. Messages can be marked
as message, warning or error. We also want the ability to selectively be able to choose
what gets logged, such as to be able to log only errors or only errors and warnings.

1. If you were to review the following code, what feedback would you give? Please be
specific and indicate any errors that would occur as well as other best practices and
code refactoring that should be done.
2. Rewrite the code based on the feedback you provided in question 1. Please include
unit tests on your code.


Respuestas:

Lo primero que debo destacar, es que el proyecto está realizado  el tipo de programación espagueti, lo que hace difícil su comprensión sin ejecutar el programa e ir viendo paso por paso, así que lo primero que pensé en hacer, fue resolver el problema en capas, para dividir el desarrollo de la misma en componentes más pequeños.
Luego vi que todas las variables eran estáticas, así que cambie eso por variables dinámicas, para que al momento de ejecutar la aplicación funcione basándose en los datos proporcionados por el usuario. Esto le permitirá  trabajar más cómodamente, además de que  esto me permite trabajar los errores de forma más centrada y buscarle una solución para que no se rompa la aplicación.
Luego vi que en la sentencia de SQL para agregar los cambios en la base de datos estaban concatenados y esto es un problema, ya que facilita la inyección de SQL y los datos pueden verse vulnerados, así que decidí elaborar un Procedimiento almacenado y parametrizar los datos enviados por el usuario, además de hacerle un pequeño manejo de errores en caso de que algo no funcione correctamente.
Por último decidí que si el usuario ejecuta por primera vez la aplicación sé genere la base de datos por si sola para que no sea necesario armarla desde el Management u otra herramienta en particular.
Además, si la carpeta en donde se genera el archivo .txt no existe se generara sola sin necesidad que el usuario se encargue de hacerlo.

Con respecto al Unit Testing , en la facultad no aprendí como hacerlo, y en la aceleración de alkemy recién veré Unit Testing el final del desarrollo



