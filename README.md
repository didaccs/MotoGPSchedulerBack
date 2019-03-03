# MotoGPSchedulerBack

Servicio REST que permite consultar el calendario 2019 de MotoGP.

La información que debe mostrar listado para cada uno de los eventos es: 
* Fecha del evento 
* Nombre del evento 
* Nombre del circuito donde se realiza el evento 
* País donde se encuentra ubicado el circuito 

La información que debe mostrar el detalle de un evento es: 
* Fecha del evento 
* Nombre del evento 
* Nombre del circuito donde se realiza el evento 
* País donde se encuentra ubicado el circuito 
* Longitud 
* Número de curvas 
* Anchura 
* Recta más larga 
* Record del circuito 

## Pre-requisitos

* [Visual Studio 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)
* [Git](https://git-scm.com/downloads)

## Tecnologias utilizadas

* Web API Net Core 2.2
* EF Core 2.2 + Lazy load
* Repositorio de acceso a base de datos genèrico
* Code first + Migrations

## Iniciar proyecto
Seguir los siguientes pasos para ejecutar la API:

  1. Clonar repositorio GIT:
     ```
     git clone https://github.com/didaccs/MotoGPSchedulerBack.git
     ```
  2. Acceder a la carpeta 'MotoGPSchedulerApi':
     ```
     cd MotoGPSchedulerApi
     ```
  3. Restaurar paquetes:
     ```
     dotnet restore
     ```
  4. Compilar la solución:
     ```
     dotnet build
     ```
  5. Ejecutar la API:
     ```
	   dotnet run
     ```

La API por defecto se está ejecutando en la URL: http://localhost:61678/
