using KioscoAPI.Data;
using KioscoAPI.Models;
using KioscoAPI.Controllers;
using KioscoAPI.DTOs;
using KioscoAPI.Repositories;
using KioscoAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace KioscoAPI.Repositories
{
   
        public class CategoriaRepository : ICategoriaRepository
        {
            private readonly KioscoDbContext _context;

            public CategoriaRepository(KioscoDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Categoria>> GetAllAsync()
            {
                return await _context.Categorias.ToListAsync();
            }

            public async Task<Categoria?> GetByIdAsync(int id)
            {
                return await _context.Categorias.FindAsync(id);
            }

            public async Task<Categoria> AddAsync(Categoria categoria)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return categoria;
            }

            public async Task<Categoria?> UpdateAsync(int id, Categoria categoria)
            {
                var existing = await _context.Categorias.FindAsync(id);
                if (existing == null) return null;

                existing.nombre = categoria.nombre;
                existing.descripcion = categoria.descripcion;
                existing.estado = categoria.estado;

                await _context.SaveChangesAsync();
                return existing;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null) return false;

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return true;
            }
        }
}
