using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_Miranda.Models
{
    // Creacion de la entidad Categoria
    public class Category
    {
        // Atributo [Key] para ayudar a Entity Framework a mapear correctamente la entidad con la tabla en la base de datos.
        [Key]
        public int idCategory { get; set; }

        // Validaciones con DataAnnotations
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string CategoryName { get; set; }

        // Representacion de la colección de productos asociados a esta categoría
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
