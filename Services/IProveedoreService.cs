using KioscoAPI.DTOs;

namespace KioscoAPI.Services
{
    public interface IProveedoreService
    {
        Task<IEnumerable<ProveedoreDTO>> GetAllAsync();
        Task<ProveedoreDTO?> GetByIdAsync(int id);
        Task<ProveedoreDTO> CreateAsync(ProveedoreCreateDTO dto);
        Task UpdateAsync(int id, ProveedoreCreateDTO dto);
        Task DeleteAsync(int id);
    }
}