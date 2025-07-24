using KioscoAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KioscoAPI.Services;
using System.Threading.Tasks;
using KioscoAPI.Models;
using KioscoAPI.Repositories;
using KioscoAPI.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
namespace KioscoAPI.Controllers

{
   

        [ApiController]
        [Route("api/[controller]")]
        public class CategoriaController : ControllerBase
        {
            private readonly ICategoriaService _categoriaService;

            public CategoriaController(ICategoriaService categoriaService)
            {
                _categoriaService = categoriaService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var categorias = await _categoriaService.GetAllAsync();
                return Ok(categorias);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var categoria = await _categoriaService.GetByIdAsync(id);
                if (categoria == null) return NotFound();
                return Ok(categoria);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CategoriaCreateDTO dto)
            {
                var created = await _categoriaService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, CategoriaCreateDTO dto)
            {
                var updated = await _categoriaService.UpdateAsync(id, dto);
                if (updated == null) return NotFound();
                return Ok(updated);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var deleted = await _categoriaService.DeleteAsync(id);
                if (!deleted) return NotFound();
                return NoContent();
            }
        }
}
