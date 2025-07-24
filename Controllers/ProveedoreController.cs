using KioscoAPI.DTOs;
using KioscoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KioscoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoreController : ControllerBase
    {
        private readonly IProveedoreService _service;

        public ProveedoreController(IProveedoreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedoreDTO>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedoreDTO>> Get(int id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            if (proveedor == null) return NotFound();
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<ActionResult<ProveedoreDTO>> Post(ProveedoreCreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProveedoreCreateDTO dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}