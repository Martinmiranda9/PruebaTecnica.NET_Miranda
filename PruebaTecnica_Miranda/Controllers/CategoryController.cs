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

    // Controladores de Category
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        // Constructor del controlador que recibe e inicializa las dependencias.
        public CategoryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Método GET para obtener todas las categorías.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        // Método GET para obtener una categoría específica por ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound($"No existe la categoría con ID {id}.");

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        // Método POST para crear una nueva categoría.
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _mapper.Map<Category>(dto);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return CreatedAtAction(nameof(GetById), new { id = categoryDto.idCategory }, categoryDto);
        }

        // Método DELETE para eliminar una categoría por ID.
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products) 
                .FirstOrDefaultAsync(c => c.idCategory == id);

            if (category == null)
                return NotFound($"No se encontró la categoría con ID {id}.");

            if (category.Products.Any()) 
                return BadRequest("No se puede eliminar una categoria que contiene productos.");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok("Categoria borrada con exito");
        }

    }
}


