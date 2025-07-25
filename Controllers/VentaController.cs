using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KioscoAPI.DTOs;
using KioscoAPI.Models;
using KioscoAPI.Repositories;
using KioscoAPI.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace KioscoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly VentaService _service;
        private readonly IVentaRepository _repository;

        public VentasController(VentaService service, IVentaRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CrearVenta([FromBody] VentaDTO dto)
        {
            Console.WriteLine($"POST CrearVenta recibido a las {DateTime.Now}");
            var venta = await _service.CrearVentaDesdeDTOAsync(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = venta.id }, venta);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var ventas = await _repository.ObtenerTodasAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var venta = await _repository.ObtenerPorIdAsync(id);
            if (venta == null) return NotFound();
            return Ok(venta);
        }

        [HttpPut("{id}/cancelar")]
        public async Task<IActionResult> CancelarVenta(int id)
        {
            var result = await _repository.CancelarVentaAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
