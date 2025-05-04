using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_Miranda.Dtos
{
    // // DTO de creacion de Productos para la entrada de datos.
    public class CreateProductDto
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        public string? ProductName { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo. ¡Revise su stock!")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "El id de la categoría es obligatoria.")]
        public int idCategory { get; set; }
    }
}
