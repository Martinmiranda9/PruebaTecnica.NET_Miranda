using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Miranda.Models;

namespace PruebaTecnica_Miranda.Data
{
    // Clase que representa el contexto de base de datos principal de la aplicación.
    public class AppDbContext : DbContext
    {
        // Constructor que recibe las opciones del contexto.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Representacion de la tabla 'Categories' en la base de datos.
        public DbSet<Category> Categories { get; set; }

        // Representacion la tabla 'Products' en la base de datos.
        public DbSet<Product> Products { get; set; }

        
    }
}
