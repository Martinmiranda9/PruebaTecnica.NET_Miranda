using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Miranda.Data;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using PruebaTecnica_Miranda.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Configuracion de la conexion a la base de datos MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))));


// Integracion de AutoMapper.
builder.Services.AddAutoMapper(typeof(Program));


// Add services to the container.
builder.Services.AddControllers();



// Agregacion de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Construye la API con la configuración anterior.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware personalizado para el manejo global de errores.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

// Habilita la autorización.
app.UseAuthorization();

// Mapea los controladores a las rutas correspondientes.
app.MapControllers();

// Ejecuta la aplicación.
app.Run();
