# PruebaTecnicaApi_Miranda
API REST desarrollada en .NET 9.0  con funcionalidades CRUD en base a las entidades CATEGORIAS y PRODUCTOS, con conexion a una base de datos MySQL, usando EntityFramework. Ademas incluye validaciones con DataAnnotations, uso de AutoMapper, estructuracion en capas, DTOs y documentacion en Swagger.

# TECNOLOGIAS / BIBLIOTECAS / BASE DE DATOS / COMPONENTES utilizados:        
- ASP.NET CORE 9.0
- Entity Framework Core
- MySQL CODE FIRST
- AutoMapper
- Swagger
- DataAnnotations

# ¿Como ejecutar el Proyecto?
- Cloná el repositorio
- Configurá la base de datos (Asegurate de tener MySQL instalado y en funcionamiento)
- En appsettings.json, ajusta la cadena de conexión y ejecuta los siguientes comandos:

  
  Restaurar paquetes
  ``dotnet restore``
  
Aplicar migraciones (crear DB)

  ``dotnet ef migrations add InitialCreate``
  
    dotnet ef database update
     
Ejecutar la API
 `` dotnet run``
 
Accedé a la documentación Swagger
``https://localhost:5001/swagger``

# ENDPOINTS CATEGORY
GET /api/Category: Obtiene todas las categorías registradas.

GET /api/Category/{id}: Obtiene los detalles de una categoría específica por su ID.

POST /api/Category: Crea una nueva categoría.

DELETE /api/Category/{id}: Elimina una categoría específica por su ID, si no tiene productos asociados.

# ENDPOINTS PRODUCT 
GET /api/Product: Obtiene todos los productos registrados, incluyendo la información de su categoría.

GET /api/Product/{id}: Obtiene los detalles de un producto específico por su ID, incluyendo la categoría asociada.

POST /api/Product: Crea un nuevo producto. 

PUT /api/Product/{id}: Actualiza los detalles de un producto específico por su ID.

DELETE /api/Product/{id}: Elimina un producto específico por su ID.
