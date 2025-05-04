using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_Miranda.Dtos
{
    // DTO de creacion de Categorias para la entrada de datos.
    public class CreateCategoryDto
    {

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string CategoryName { get; set; } 
    }
}
