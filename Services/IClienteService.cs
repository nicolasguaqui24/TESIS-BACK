using KioscoAPI.DTOs;
using KioscoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KioscoAPI.Services
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>> ObtenerTodosAsync();
        Task<ClienteDTO> ObtenerPorIdAsync(int id);
        Task<ClienteDTO> CrearClienteAsync(ClienteDTO clienteDto);
    }
}