using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_Miranda.Dtos
{
    // DTO para actualizacion de Productos.
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo. ¡Revise su stock!")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El ID de la categoría es obligatorio.")]
        public int idCategory { get; set; }

    }
}
