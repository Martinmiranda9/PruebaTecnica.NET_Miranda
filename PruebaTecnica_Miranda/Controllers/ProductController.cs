using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Miranda.Data;
using PruebaTecnica_Miranda.Dtos;
using PruebaTecnica_Miranda.Models;

namespace PruebaTecnica_Miranda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // Controladores de Product.
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        // Constructor del controlador que recibe e inicializa las dependencias.
        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Método GET para obtener todos los productos.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        // Método GET para obtener un producto específico por ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _context.Products.Include(p => p.Category)
                                                 .FirstOrDefaultAsync(p => p.idProduct == id);

            if (product == null)
                return NotFound(new { message = $"Producto con ID {id} no encontrado." });

            return Ok(_mapper.Map<ProductDto>(product));
        }

        // Método POST para crear un producto.
        [HttpPost]
        public async Task<ActionResult> Create(CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _context.Categories.FindAsync(dto.idCategory);
            if (category == null)
                return BadRequest(new { message = $"No existe la categoría con ID {dto.idCategory}." });

            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(new
            {
                message = "Producto creado exitosamente.",
                data = productDto
            });

            
        }

        // Método PUT para modificar un producto específico por ID.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound(new { message = $"Producto con ID {id} no encontrado." });

            var category = await _context.Categories.FindAsync(dto.idCategory);
            if (category == null)
                return BadRequest(new { message = $"No existe la categoría con ID {dto.idCategory}." });

            _mapper.Map(dto, existingProduct); 
            await _context.SaveChangesAsync();

            return Ok(new { message = "Producto actualizado con éxito." });
        }

        // Método DELETE para eliminar un producto específico por ID.
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound(new { message = $"Producto con ID {id} no encontrado." });

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Producto eliminado con éxito." });
        }
    }
}
