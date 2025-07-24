using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using KioscoAPI.Models;
using KioscoAPI.Data;
using Microsoft.EntityFrameworkCore;
using KioscoAPI.DTOs;

namespace KioscoAPI.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(KioscoDbContext context) : base(context)
        { }


        public async Task<Usuario?> GetByUsuarioAsync(string usuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.usuario == usuario);
        }
        public async Task CrearAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        /* public async Task<UsuarioProfileDTO> GetBasicProfileByIdAsync(int userId)
         {
             return await _context.Usuarios
                 .Where(u => u.id == userId)
                 .Select(u => new UsuarioProfileDTO
                 {
                     Id = u.id,
                     Nombre = u.nombre,
                     Usuario = u.usuario,
                     Rol = u.rol,
                     Activo = u.activo,
                 })
                 .FirstOrDefaultAsync();
         }
        */
        public async Task<UsuarioProfileDTO> GetBasicProfileByIdAsync(int userId)
        {
            return await _context.Usuarios
                .Where(u => u.id == userId)
                .Select(u => new UsuarioProfileDTO
                {
                    Id = u.id,
                    Nombre = u.nombre,
                    Usuario = u.usuario,
                    Rol = u.rol,
                    Activo = u.activo,
                })
                .FirstOrDefaultAsync();

        }
    }
}