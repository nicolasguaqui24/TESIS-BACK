using KioscoAPI.DTOs;
using KioscoAPI.Models;
using KioscoAPI.Repositories;
using KioscoAPI.Services;
using KioscoAPI.Controllers;

namespace KioscoAPI.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repo;

        public CategoriaService(ICategoriaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            var categorias = await _repo.GetAllAsync();
            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.id,
                Nombre = c.nombre,
                Descripcion = c.descripcion,
                Estado = c.estado
            });
        }

        public async Task<CategoriaDTO?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;

            return new CategoriaDTO
            {
                Id = c.id,
                Nombre = c.nombre,
                Descripcion = c.descripcion,
                Estado = c.estado
            };
        }

        public async Task<CategoriaDTO> CreateAsync(CategoriaCreateDTO dto)
        {
            var c = new Categoria
            {
                nombre = dto.Nombre,
                descripcion = dto.Descripcion,
                estado = dto.Estado
            };

            var created = await _repo.AddAsync(c);

            return new CategoriaDTO
            {
                Id = created.id,
                Nombre = created.nombre,
                Descripcion = created.descripcion,
                Estado = created.estado
            };
        }

        public async Task<CategoriaDTO?> UpdateAsync(int id, CategoriaCreateDTO dto)
        {
            var updated = await _repo.UpdateAsync(id, new Categoria
            {
                nombre = dto.Nombre,
                descripcion = dto.Descripcion,
                estado = dto.Estado
            });

            if (updated == null) return null;

            return new CategoriaDTO
            {
                Id = updated.id,
                Nombre = updated.nombre,
                Descripcion = updated.descripcion,
                Estado = updated.estado
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}