# Reserva Espectaculo 📖

## Objetivos 📋
Desarrollar un sistema, que permita la administración general de un cine.  De cara a los empleados: Peliculas, Genero, Salas, TipoSala, Funciones y Clientes entre otras, como así también, permitir a los clientes, realizar reservas sobre las funciones ofrecidas.
Utilizar Visual Studio 2022 community edition y crear una aplicación utilizando ASP.NET MVC Core (versión a definir por el docente, actualmente 8.0).

<hr />

## Enunciado 📢
La idea principal de este trabajo práctico, es que Uds. se comporten como un equipo de desarrollo.
Este documento, les acerca, un equivalente al resultado de una primera entrevista entre el cliente y alguien del equipo, el cual relevó e identificó la información aquí contenida. 
A partir de este momento, deberán comprender lo que se está requiriendo y construir dicha aplicación web.

Lo primero que deben hacer es comprender en detalle, que es lo que se espera y se busca como resultado del proyecto, para ello, deben recopilar todas las dudas que tengan entre Uds. y evacuarlas con su nexo (el docente) de cara al cliente. De esta manera, él nos ayudará a conseguir la información ya un poco más procesada. 
Es importante destacar, que este proceso no debe esperarse hacerlo 100% en clase; deben ir contemplandolas de manera independientemente, las unifican y hace una puesta comun dentro del equipo (ya sean de índole funcional o técnicas), en lugar de enviar consultas individuales, se sugiere y solicita que las envien de manera conjunta. 

Al inicio del proyecto, las consultas pueden ser enviadas por correo siguiente el siguiente formato:

Subject: [NT1-<CURSO LETRA>-GRP-<GRUPO NUMERO>] <Proyecto XXX> | Informativo o Consulta

Body: 

1.<xxxxxxxx>
2.< xxxxxxxx>

# Ejemplo
**Subject:** [NT1-A-GRP-5] Agenda de Turnos | Consulta

**Body:**

1.La relación del paciente con Turno es 1:1 o 1:N?
2.Está bien que encaremos la validación del turno activo, con una propiedad booleana en el Turno?

<hr />

Es sumamente importante que los correos siempre tengan:
1.Subject con la referencia, para agilizar cualquier interaccion entre el docente y el grupo
2. Siempre que envien una duda o consulta, pongan en copia a todos los participantes del equipo. 

Nota: A medida que avancemos en la materia, TODAS las dudas relacionadas al proyecto deberán ser canalizadas por medio de Github, y desde alli tendremos: seguimiento y las dudas con comentarios, accesibles por todo el equipo y el avance de las mismas. 

**Crear un Issue nuevo o agregar un comentario sobre un issue en cuestion**, si se requiere asistencia, evacuar una duda o lo que fuese, siempre arrobando al docente, ejemplo: @marianolongoort y agregando las etiquetas correspondientes.


### Proceso de ejecución en alto nivel ☑️
 - Crear un nuevo proyecto en [visual studio](https://visualstudio.microsoft.com/en/vs/) utilizando la template de MVC (Model-View-Controller).
 - Crear todos los modelos definidos y/o detectados por ustedes, dentro de la carpeta Models, cada uno en un archivo separado (Modelos anemicos, modelos sin responsabilidades).
 - En el proyecto trataremos de reducir al mínimo las herencias sobre los modelos anémicos.  Ej. la clase Persona, tendrá especializaciones como ser Empleado, Cliente, Alumno, Profesional, etc. según corresponda al proyecto.
 - Sobre dichos modelos, definir y aplica las restricciones necesarias y solicitadas para cada una de las entidades. [DataAnnotations](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-8.0).
 - Agregar las propiedades navegacionales que pudisen faltar, para las relaciones entre las entidades (modelos) nueva que pudieramos generar o encontrar.
 - Agregar las propiedades relacionales, en el modelo donde se quiere alojar la relacion (entidad dependiente). La entidad fuerte solo tendrá una propiedad Navegacional, mientras que la entidad debíl tendrá la propiedad relacional.
 - Crear una carpeta Data en la raíz del proyecto, y crear dentro al menos una clase que representará el contexto de la base de datos (DbContext - los datos a almacenar) para nuestra aplicacion. 
 - Agregar los paquetes necesarios para Incorporar Entity Framework e Identitiy en nuestros proyectos.
 - Crear el DbContext utilizando en esta primera estapa con base de datos en memoria (con fines de testing inicial, introduccion y fine tunning de las relaciones entre modelos). [DbContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-8.0), [Database In-Memory](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=vs).
 - Agregar las propiedades del tipo DbSet para cada una de las entidades que queremos persistir en el DbContext. Estas propiedades, serán colecciones de tipos que deseamos trabajar en la base de datos. En nuestro caso, serán las Tablas en la base de datos.
 - Agregar Identity a nuestro proyecto, y al menos definir IdentityUser como clase base de Persona en nuestro poryecto. Esto nos facilitará la inclusion de funcionalidades como Iniciar y cerrar sesion, agregado de entidades de soporte para esto Usuario y Roles que nos serviran para aplicar un control de acceso basado en roles (RBAC) basico. 
 - Por medio de Scaffolding, crear en esta instancia todos los CRUD (Create-Read-Update-Delete)/ABM (Altas-Bajas-Modificaiciones) de las entidades a persistir. Luego verificaremos cuales mantenemos, cuales removemos, y cuales adecuaremos para darle forma a nuestra WebApp.
 - Antes de continuar es importante realizar algun tipo de pre-carga de la base de datos. No solo es requisito del proyecto, sino que les ahorrara mucho tiempo en las pruebas y adecuaciones de los ABM.
 - Testear en detalle los ABM generados, y detectar todas las modificaciones requeridas para nuestros ABM e interfaces de usuario faltantes para resolver funcionalidades requeridas. (siempre tener presente el checklist de evaluacion final, que les dara el rumbo para esto).
 - Cambiar el dabatabase service provider de Database In Memory a SQL. Para aquellos casos que algunos alumnos utilicen MAC, tendran dos opciones para avanzar (adecuar el proyecto, para utilizar SQLLite o usar un docker con SQL Server instalado alli).
 - Aplicar las adecuaciones y validaciones necesarias en los controladores.  
 - Si el proyecto lo requiere, generar el proceso de auto-registración. Es importante aclarar que este proceso debe ser adecuado según las necesidades de cada proyecto, sus entidades y requerimientos al momento de auto-registrar; no seguir explicitamente un registro tan simple como email y password. 
 - A estas alturas, ya se han topado con varios inconvenientes en los procesos de adecuacion de las vistas y por consiguiente es una buena idea que generen ViewModels para desbloquear esas problematicas que nos estan trayendo los Modelos anemicos utilizados hasta el momento.
 - En el caso de ser requerido en el enunciado, un administrador podrá realizar todas tareas que impliquen interacción del lado del negocio (ABM "Alta-Baja-Modificación" de las entidades del sistema y configuraciones en caso de ser necesarias).
 - El <Usuario Cliente o equivalente> sólo podrá tomar acción en el sistema, en base al rol que que se le ha asignado al momento de auto-registrarse o creado por otro medio o entidad.
 - Realizar todos los ajustes necesarios en los modelos y/o código desde la perspectiva de funcionalidad.
 - Realizar los ajustes requeridos desde la perspectiva de permisos y validaciones.
 - Realizar los ajustes y mejoras en referencia a la presentación de la aplicaión (cuestiones visuales).
 
 Nota: Para la pre-carga de datos, las cuentas creadas por este proceso, deben cumplir las siguientes reglas de manera EXCLUYENTE:
 1. La contraseña por defecto para todas las cuentas pre-cargadas será: Password1!
 2. El UserName y el Email deben seguir la siguiente regla:  <classname>+<rolname si corresponde diferenciar>+<indice>@ort.edu.ar Ej.: cliente1@ort.edu.ar, empleado1@ort.edu.ar, empleadorrhh1@ort.edu.ar

<hr />

## Entidades 📄
- Persona
- Empleado
- Cliente
- Reserva
- Función
- Pelicula
- Genero
- Sala
- TipoSala

## `⚠️Importante: Todas las entidades deben tener su identificador único. Id⚠️`

`
Las propiedades descriptas a continuación, son las mínimas que deben tener las entidades. Uds. pueden proponer agregar las que consideren necesarias. Siempre validar primero con el docente.
De la misma manera Uds. deben definir los tipos de datos asociados a cada una de ellas, como así también las restricciones.
`

**Persona**
```
- UserName
- Nombre
- Apellido
- DNI
- Telefono
- Direccion
- FechaAlta
- Email
```

**Empleado**
```
- UserName
- Nombre
- Apellido
- DNI
- Telefono
- Direccion
- FechaAlta
- Email
- Legajo
```

**Cliente**
```
- UserName
- Nombre
- Apellido
- DNI
- Telefono
- Direccion
- FechaAlta
- Email
- Reservas
```

**Reserva**
```
- Activa (flag)
- CantidadButacas
- Cliente
- FechaAlta
- Funcion
```

**Función**
```
- Fecha
- Hora
- Descripcion
- ButacasDisponibles (Dato calculado)
- Confirmada
- Pelicula
- Reservas
- Sala
```

**Pelicula**
```
- Titulo
- Descripcion
- FechaLanzamiento
- Foto
- Funciones
- Genero (enum)
```

**Sala**
```
- Numero
- TipoSala
- CapacidadButacas
- Funciones
```

**TipoSala**
```
- Nombre
- Precio
```

**NOTA:** aquí un link para refrescar el uso de los [Data annotations](https://www.c-sharpcorner.com/UploadFile/af66b7/data-annotations-for-mvc/).

<hr />

## Características y Funcionalidades ⌨️
`⚠️Todas las entidades, deben tener implementado su correspondiente ABM, a menos que sea implícito el no tener que soportar alguna de estas acciones.⚠️`
 
 **NOTA:** En el EP3, se deberán presentar las ABM de todoas las entidades, independientemente de que luego sean modificadas o eliminadas. El fin academico de esto, es que tomen contacto con formas de manejar los datos con los usuarios desde una interfaz gráfica de usuario y les sea más facil en el siguiente entregable comprender que deben modificar o adecuar.

## Generalidades 🏠
- La aplicación deberá incluir un logo en el layout
- Deberá contar con información institucional (inventada) relacionada al proyecto.
- Contenido anónimo que debe estar disponible (sin iniciar sesión):
    - Los clientes pueden auto registrarse.
        - La autoregistración desde el sitio, es exclusiva para los clientes. Por lo cual, se le asignará dicho rol.
    - Los clientes podrán ver las peliculas en cartelera.        
        - Las películas de la cartelera deben ser en base a las funciones activas (del futuro).
            - Las películas que sean del futuro más allá de 7 días, deben decir, "Próximamente" y no deben poder reservarse. 
        - Al presionar en una pelicula de la cartelera se verá información detallada de la pelicula y las funciones disponibles de la próxima semana.
        - Deberán poder reservar desde los detalles de la pelicula o desde la cartelera.
            - En tal caso no deberán volver a seleccionar la pelicula ya elegída.
            - El cliente si o si deberá estar logueado (forzado), pero IMPORTANTE, no debe volver a seleccionar la pelicula por este proceso.


- Los Usuarios (cliente) pueden auto registrarse como se mencionó previamente o ser registrados por un empleado.
- La auto-registración desde el sitio, es exclusiva para los usuarios externos. Por lo cual, se le asignará dicho rol de manera automática.
- Los empleados, deben ser agregados por otro empleado. No pueden auto registrarse.	
    - Al momento, del alta de un empleado, se le definirá un UserName y la password será por defecto Password1!.
    - También se les asignará a estas cuentas el rol de Empleado.

**Cliente**
- Un cliente puede realizar una reserva Online
    - El proceso será en modo Wizard.
        - Selecciona la pelicula -> Siguiente (en caso de que el proceso inicie desde el catalogo, este paso no debe ser solicitado ni visualizado por el cliente). -> SiguienteSiguiente.
        - Selecciona la cantidad de butacas que quiere reservar. -> Siguiente
        - Seleccionará una función disponible dentro de la oferta.-> Siguiente
            - La oferta estará restringida desde el momento de la consulta hasta 7 dias posteriores.
            - Las funciones deben estar confirmadas
            - No debe incluir desde luego funciones que no tenga butacas disponibles.            
            - Debe ser en base a la oferta de la pelicula seleccionada.
            - El cliente, solo puede tener una reserva activa.
        - Verá un resumen de la solicitur -> Confirmar.
        - Irá a ver los detalles de la reserva realizada.

        - `⚠️Si ya tiene una reserva activa, no debería poder siquiera iniciar el proceso de reserva, no debe anoticiarse al final del proceso.⚠️`

 
- El cliente, podrá en todo momento, ver si tiene o no una reserva activa para una función futura.            
    - Podrá cancelarla, solo si es hasta 24hs. antes de la programación.
- Puede ver las reservas pasadas (aquellas de fechas pasadas).
- Puede actualizar datos de contacto, como el telefono, dirección,etc.. Pero no puede modificar su DNI, Nombre, Apellido, etc.

**Empleado**
- Puede listar las reservas por cada pelicula listado "en el futuro" y listado "en el pasado".
- Puede listar las reservas para una función en particular.
- Puede habilitar o cancelar funciones. 
    - Solo pueden cancelarse, si no tiene reservas y son del futuro.
    - Solo pueden cancelarse, si no tiene reservas y son del futuro.
- También, puede ver un balance de recaudación por pelicula en el corriente mes. El listado debe incluir el nombre de la pelicula y el monto recaudado en base a las reservas pasadas. Ordenadas de manera decreciente por monto recaudado.
- Puede dar de alta las Salas, Peliculas, etc. 
    - Nadie, puede eliminar las salas, pero si puede cambiar el tipo, solo si no tiene reservas activas.
- El empleado puede hacer un proceso de reserva para un cliente.
    - El proceso será en modo Wizard.
        - Busca al cliente por nombre o apellido y tendrá una acción (solo si no tiene reservas activas) -> Reservar
        - Selecciona la pelicula -> Siguiente
        - Selecciona la cantidad de butacas que quiere reservar. -> Siguiente
        - Seleccionará una función disponible dentro de la oferta.-> Siguiente
            - La oferta estará restringida desde el momento de la consulta hasta 7 dias posteriores.
            - Las funciones deben estar confirmadas
            - No debe incluir desde luego funciones que no tenga butacas disponibles.            
            - Debe ser en base a la oferta de la pelicula seleccionada.
        - Verá un resumen de la solicitur -> Confirmar.
        - Irá a ver los detalles de la reserva realizada.

**Reserva**
- La reserva al crearse debe estar en estado activa.
- El cliente solo puede tener una reserva activa.
- La reserva, tiene que validar, que sea factible, en cuanto a la cantidad de butacas que selecciona al cliente para una función especifica.
    - Si puede realizar la reserva se debe actualizar las butacas disponibles (Capacidad de la sala vs Reservas realizadas previas y actual).

**Funcion**
- No debe exitir una función que coincida la fecha, hora y sala.
- Las budatas disponibles, para esta aplicación debe ser un dato calculado, en base a la capacidad de la sala y las reservas realizadas.
- Las funciones, deben ser confirmadas por un empleado. Desde el listado de funciones, debe existir un boton On-Off para confirmarlas directamente.


**Aplicación General**
- No se debe poder acceder, ejecutar modificaciones/acciones no permitidas por acceso desde la URL.
- Las reservas en fechas pasadas deben pasar automátcamente a estado inactivas, para no bloquear nuevas reservas.
- Se debe poder listar las peliculas en cartelera sin iniciar sesión.
- La cartelera debe tener un filtro por genero.
- Ver fotos de pelicula o generico en la cartelera.
- Al hacer clic en la foto de la pelicula ver los detalles.
- Poder reservar, automáticamente desde la una pelicula en cartelera (con solicitud de inicio de sesión previo si fuese requerido)
- Poder reservar, automáticamente desde los detalles de una pelicula (con solicitud de inicio de sesión previo si fuese requerido)
- Por cada pelicula, se tiene que poder listar las funciones activas para la proxima semana. 
- La disponibilidad de las funciones, solo puede verse al tener una sesión iniciada como cliente.
- No se pueden repetir/duplicar Nombre de Pelicula, Tipo, Genero, etc. y Sala.Numero.

`
Nota: Las butacas no son numeradas. El complejo, no tiene limites fisicos en la construcción de salas. Las funciones tienen una duración fija de 2hs. 
`
