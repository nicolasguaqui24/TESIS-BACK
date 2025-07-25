using KioscoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KioscoAPI.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodosAsync();
        Task<Cliente> ObtenerPorIdAsync(int id);
        Task<Cliente> CrearClienteAsync(Cliente cliente);
    }
}