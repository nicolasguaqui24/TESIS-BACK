using KioscoAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KioscoAPI.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDTO>> GetAllAsync();
        Task<ProductoDTO> GetByIdAsync(int id);
        Task<ProductoDTO> GetByCodigoBarraAsync(long codigoBarra);
        Task<ProductoDTO> CreateAsync(ProductoCreateDTO dto);
        Task<ProductoDTO> UpdateAsync(ProductoUpdateDTO dto);
    }
}