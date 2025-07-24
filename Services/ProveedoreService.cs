using KioscoAPI.DTOs;
using KioscoAPI.Models;
using KioscoAPI.Repositories;

namespace KioscoAPI.Services
{
    public class ProveedoreService : IProveedoreService
    {
        private readonly IProveedoreRepository _repository;

        public ProveedoreService(IProveedoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProveedoreDTO>> GetAllAsync()
        {
            var proveedores = await _repository.GetAllAsync();
            return proveedores.Select(p => new ProveedoreDTO
            {
                Id = p.id,
                Nombre = p.nombre,
                Telefono = p.telefono,
                CBU = p.CBU,
                deuda = p.deuda,
                direccion = p.direccion,
                email = p.email,
                activo = p.activo,

            });
        }

        public async Task<ProveedoreDTO?> GetByIdAsync(int id)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            if (proveedor == null) return null;

            return new ProveedoreDTO
            {
                Id = proveedor.id,
                Nombre = proveedor.nombre,
                Telefono = proveedor.telefono,
                CBU = proveedor.CBU,
                deuda = proveedor.deuda,
                direccion = proveedor.direccion,
                email = proveedor.email,
                activo = proveedor.activo,


            };
        }

        public async Task<ProveedoreDTO> CreateAsync(ProveedoreCreateDTO dto)
        {
            var proveedor = new Proveedore
            {
                nombre = dto.Nombre,
                telefono = dto.Telefono,
                CBU = dto.CBU,
                deuda = dto.deuda,
                direccion = dto.Direccion,
                 email = dto.Email, // Si el DTO incluye email, descomentar esta línea
                 activo = dto.Activo // Si el DTO incluye activo, descomentar esta línea

            };

            proveedor = await _repository.CreateAsync(proveedor);

            return new ProveedoreDTO
            {
                Id = proveedor.id,
                Nombre = proveedor.nombre,
                Telefono = proveedor.telefono,
                CBU = proveedor.CBU,
                deuda = proveedor.deuda,
                direccion = proveedor.direccion,
                email = proveedor.email,
                activo = proveedor.activo,

            };
        }

        public async Task UpdateAsync(int id, ProveedoreCreateDTO dto)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            if (proveedor == null) throw new Exception("Proveedor no encontrado");

            proveedor.nombre = dto.Nombre;
            proveedor.telefono = dto.Telefono;
            proveedor.CBU = dto.CBU;
            proveedor.deuda = dto.deuda;
            proveedor.direccion = dto.Direccion;
            proveedor.email = dto.Email; // Si el DTO incluye email, descomentar esta línea
            proveedor.activo = dto.Activo; // Si el DTO incluye activo, descomentar esta línea



            await _repository.UpdateAsync(proveedor);
        }

        public async Task DeleteAsync(int id)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            if (proveedor == null) throw new Exception("Proveedor no encontrado");

            await _repository.DeleteAsync(proveedor);
        }
    }
}