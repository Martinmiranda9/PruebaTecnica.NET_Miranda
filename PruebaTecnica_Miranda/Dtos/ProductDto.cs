namespace PruebaTecnica_Miranda.Dtos
{
    // DTO de Categoria para visualizar la salida de datos.
    public class ProductDto
    {
        public int idProduct { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Informacion básica de la categoría
        public int idCategory { get; set; }
        public string CategoryName { get; set; } 
    }
}
