using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica_Miranda.Models
{
    // Creacion de la entidad Productos
    public class Product
    {
        // Atributo [Key] para ayudar a Entity Framework a mapear correctamente la entidad con la tabla en la base de datos.
        [Key]
        public int idProduct { get; set; }

        // Atributos con valdiaciones con DataAnnotations
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        public string? ProductName { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo. ¡Revise su stock!")]
        public int? Stock { get; set; }

        [Required]
        public int idCategory { get; set; }

        // Atributo [ForeignKey] para ayudar a Entity Framework a mapear correctamente la entidad con la tabla en la base de datos.
        [ForeignKey("idCategory")]
        public Category Category { get; set; }

    }
}
