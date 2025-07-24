using KioscoAPI.DTOs;

namespace KioscoAPI.Services

{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetAllAsync();
        Task<CategoriaDTO?> GetByIdAsync(int id);
        Task<CategoriaDTO> CreateAsync(CategoriaCreateDTO dto);
        Task<CategoriaDTO?> UpdateAsync(int id, CategoriaCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
