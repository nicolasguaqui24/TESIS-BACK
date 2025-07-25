using KioscoAPI.Models;
using KioscoAPI.Controllers;
using KioscoAPI.Services;
using KioscoAPI.DTOs;

namespace KioscoAPI.Repositories
{
    public class ICuentaRepository
    {
        Task<Cuenta> ObtenerPorClienteIdAsync(int clienteId);
        Task ActualizarCuentaAsync(Cuenta cuenta);
    }
}
