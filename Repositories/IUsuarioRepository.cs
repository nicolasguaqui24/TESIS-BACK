using KioscoAPI.Models;
using System.Threading.Tasks;
using KioscoAPI.DTOs;

namespace KioscoAPI.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> GetByUsuarioAsync(string usuario);
        Task<UsuarioProfileDTO> GetBasicProfileByIdAsync(int userId);
        Task CrearAsync(Usuario usuario);
        
    }
}
