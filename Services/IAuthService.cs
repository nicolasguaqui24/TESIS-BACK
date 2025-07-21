using System.Threading.Tasks;
using KioscoAPI.Models;
namespace KioscoAPI.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string usuario, string password);

    
    }
}