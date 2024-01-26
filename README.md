# Instrucciones Backend

## Requisitos Previos
- Visual Studio (o cualquier IDE compatible con .NET Core)
- SQL Server
- .NET Core SDK 6


## Pasos
1. Abra el proyecto de backend en su IDE preferido (se recomienda Visual Studio).

2. Asegúrese de tener configurada la conexión a la base de datos SQL Server en el archivo appsettings.json. En el archivo, ajuste la cadena de conexión bajo la clave ConnectionStrings:ReportDbContext.

```
{
  "ConnectionStrings": {
    "ReportDbContext": "Data Source=localhost\\sqlexpress; Initial Catalog=lbs; Integrated Security=True; TrustServerCertificate=True"
  }
}
```
3. Abra la Consola del Administrador de Paquetes (Package Manager Console) y ejecute el siguiente comando para aplicar las migraciones y crear la base de datos.

 ```
update-database
```

## Configuración de la Base de Datos (Opcional)
1. Abra SQL Server Management Studio (SSMS) u otra herramienta compatible.
2. Ejecute el siguiente script SQL para crear la base de datos manualmente.

   ```sql
   USE master;
   GO
   CREATE DATABASE lbs;
   
##  Creación Manual de la Tabla (Opcional)
Si desea crear manualmente la tabla en SQL Server, ejecute el siguiente script SQL después de crear la base de datos lbs.

```
USE lbs;

CREATE TABLE [Report] (
  [id] int NOT NULL IDENTITY,
  [Fecha] datetime2 NOT NULL,
  [Descripcion] nvarchar(500) NOT NULL,
  [AccionesInmediatas] nvarchar(500) NOT NULL,
  [Antecedentes] nvarchar(500) NOT NULL,
  [AtencionAlEvento] nvarchar(500) NOT NULL,
  [PersonalInvolucrado] nvarchar(500) NOT NULL,
  [Impacto] nvarchar(max) NOT NULL,
  [imagePath] nvarchar(max) NOT NULL,
  CONSTRAINT [PK_Report] PRIMARY KEY ([id])
);

```

