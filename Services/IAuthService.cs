using System.Threading.Tasks;
using KioscoAPI.Models;
using KioscoAPI.DTOs;
namespace KioscoAPI.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string usuario, string password);


        Task<(bool Exito, string Mensaje)> RegistrarUsuarioAsync(RegisterRequest request);


    }
}