using KioscoAPI.DTOs;
using KioscoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KioscoAPI.Models;
  using KioscoAPI.Repositories;

namespace KioscoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.GetAllAsync();
            return Ok(productos);
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        // GET: api/Producto/barra/123456
        [HttpGet("barra/{codigoBarra}")]
        public async Task<IActionResult> GetByCodigoBarra(long codigoBarra)
        {
            var producto = await _productoService.GetByCodigoBarraAsync(codigoBarra);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        // POST: api/Producto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoCreateDTO dto)
        {
            var nuevo = await _productoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        // PUT: api/Producto
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductoUpdateDTO dto)
        {
            var actualizado = await _productoService.UpdateAsync(dto);
            if (actualizado == null) return NotFound();
            return Ok(actualizado);
        }
    }
}