# NotiApp

NotiApp es una aplicación de notificaciones desarrollada en .NET Core que utiliza Entity Framework en un sistema de tres capas. Esta aplicación administra una serie de entidades relacionadas en una base de datos. A continuación, se describen los principales componentes y cómo utilizarlos.

## Tabla de Contenido
- [Introducción](#introducción)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Requisitos del sistema](#requisitos-del-sistema)
- [Configuración](#configuración)
- [Entidades](#entidades)
- [Unit of Work](#unit_of_work)
- [Migraciones de Base de Datos](#migraciones-de-Base-de-Datos)
- [Packages](#packages)
- [API](#api)
- [Core](#core)
- [Infrastucture](#infrastucture)
- [Uso](#uso)
- [Contribución](#contribución)
- [Autor](#autor)
- [Licencia](#licencia)

## Introducción
La aplicación de notificaciones desarrollada en este proyecto es una solución integral diseñada para gestionar y administrar notificaciones en un entorno de aplicaciones web. Utiliza la plataforma de desarrollo .NET Core y una arquitectura de tres capas (API, Core e Infrastructure) para proporcionar una base sólida y escalable.

## Estructura del Proyecto
La aplicación sigue una estructura de tres capas:

- **API**: Contiene los controladores, DTOs y configuraciones de CORS. Se encarga de gestionar las solicitudes HTTP.
- **Core**: Aquí se definen las entidades (clases de tablas) y las interfaces que representan los repositorios. También se encuentra la interfaz `IUnitOfWork`.
- **Infrastructure**: Contiene el contexto de la base de datos, las migraciones, configuraciones de entidades y los repositorios con métodos CRUD.Infrastucture

## Requisitos del sistema
- Asegúrate de tener instalados los siguientes requisitos:
  - .NET Core
  - MySQL o una base de datos compatible
  - Paquetes NuGet mencionados en la sección "Packages" para API e Infrastructure

## Configuración
## Entidades

  Las entidades representan las tablas en la base de datos. Cada entidad tiene su propia clase en la capa Core. Aquí están las principales entidades del proyecto:

  - Auditoria
  - Blockchain
  - EstadoNotificacion
  - Formatos
  - GenericosVsSubmodulos
  - HilosRespuestaNotificacion
  - MaestrosVsSubmodulos
  - ModuloNotificaciones
  - ModulosMaestros
  - PermisosGenericos
  - Radicados
  - Rol
  - RolVsMaestro
  - Submodulos
  - TipoNotificacion
  - TipoRequerimiento

  ## Unit of Work

  El patrón Unit of Work se implementa en la capa Infrastructure a través de la interfaz `IUnitOfWork`. Esta interfaz proporciona un mecanismo para realizar operaciones transaccionales y coordinar las operaciones en la base de datos. Consulta la implementación en el código fuente de Infrastructure para obtener más detalles sobre cómo se utiliza en la aplicación.

  ## Migraciones de Base de Datos

  Para crear la base de datos y aplicar migraciones, utiliza las herramientas de Entity Framework. Asegúrate de tener configurada la cadena de conexión en `appsettings.json` en la capa API y ejecuta los siguientes comandos:

  ```powershell
  dotnet ef migrations add InitialCreate --project ./Infrastructure/ --startup-project ./API/ --output-dir ./Data/Migrations
  dotnet ef database update --project ./API/
  ```
  
  ## Packages
  
  los paquetes NuGet necesarios que estén instalados en cada capa:
  
  ### API
  
  ```
  Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.10
  Microsoft.EntityFrameworkCore --version 7.0.10
  Microsoft.EntityFrameworkCore.Design --version 7.0.10
  Microsoft.Extensions.DependencyInjection --version 7.0.0
  System.IdentityModel.Tokens.Jwt --version 6.32.3
  Serilog.AspNetCore --version 7.0.0
  AspNetCoreRateLimit --version 5.0.0
  AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
  ```
  ### Infrastucture
  ```
  dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
  dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
  dotnet add package CsvHelper --version 30.0.1
  ```
  
  
  ## API
  
  La capa API contiene los controladores RESTful para cada entidad. Puedes acceder a estos controladores para interactuar con la base de datos y gestionar las notificaciones.
  
  ## Core
  
  En la capa Core, se definen las entidades y las interfaces que se utilizan en toda la aplicación. También se encuentra la interfaz `IUnitOfWork`, que representa el patrón Unit of Work.
  
  ## Infrastructure
  
  La capa Infrastructure contiene el contexto de la base de datos, las migraciones, configuraciones de entidades y los repositorios que interactúan con la base de datos. Esta capa es esencial para el acceso a datos y las operaciones CRUD.  
  
  ## Uso
  
- Clona el repositorio
- Actualiza los paquetes usando:
```powershell
dotnet restore
```

- comprueba la solucion usando:
```powershell
dotnet build
```

- Ejecuta la aplicación desde tu entorno de desarrollo.

  ```powershell
  dotnet run --project .\API\ 
  ```
- Accede a los controladores de API para interactuar con las entidades, por ejemplo, `/auditoria` o `/blockchain`.

## Contribución
Si deseas contribuir a este proyecto, sigue estos pasos:

1. Haz un fork del repositorio.
2. Clona el repositorio en tu máquina local.
3. Crea una rama para tu nueva funcionalidad o corrección de errores.
4. Desarrolla y realiza pruebas en tu rama.
5. Asegúrate de que las pruebas pasen y sigue las guías de estilo del proyecto.
6. Envía una solicitud de extracción (pull request) detallando tus cambios.

## Autor
Duban Rodriguez - Initial work with EF - Campusland

## Licencia
Este proyecto está bajo la Licencia de Entity Framework 5 (ENU). Consulta el archivo [LICENSE](https://learn.microsoft.com/es-es/ef/ef6/resources/licenses/ef5/enu) para más detalles.