using KioscoAPI.DTOs;
using KioscoAPI.Models;
using KioscoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioscoAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<ProductoDTO>> GetAllAsync()
        {
            var productos = await _productoRepository.GetAllAsync();
            return productos.Select(p => new ProductoDTO
            {
                Id = p.id,
                Nombre = p.nombre,
                Descripcion = p.descripcion,
                Precio = p.precio,
                Stock = p.stock,
                StockMinimo = p.stock_minimo,
                CodigoBarra = p.codigo_barra,
                Estado = p.estado,
                CategoriaNombre = p.Categoria.nombre,
                ProveedorNombre = p.Proveedore.nombre
            });
        }

        public async Task<ProductoDTO> GetByIdAsync(int id)
        {
            var p = await _productoRepository.GetByIdAsync(id);
            if (p == null) return null;

            return new ProductoDTO
            {
                Id = p.id,
                Nombre = p.nombre,
                Descripcion = p.descripcion,
                Precio = p.precio,
                Stock = p.stock,
                StockMinimo = p.stock_minimo,
                CodigoBarra = p.codigo_barra,
                Estado = p.estado,
                CategoriaNombre = p.Categoria.nombre,
                ProveedorNombre = p.Proveedore.nombre
            };
        }

        public async Task<ProductoDTO> GetByCodigoBarraAsync(long codigoBarra)
        {
            var p = await _productoRepository.GetByCodigoBarraAsync(codigoBarra);
            if (p == null) return null;

            return new ProductoDTO
            {
                Id = p.id,
                Nombre = p.nombre,
                Descripcion = p.descripcion,
                Precio = p.precio,
                Stock = p.stock,
                StockMinimo = p.stock_minimo,
                CodigoBarra = p.codigo_barra,
                Estado = p.estado,
                CategoriaNombre = p.Categoria.nombre,
                ProveedorNombre = p.Proveedore.nombre
            };
        }

        public async Task<ProductoDTO> CreateAsync(ProductoCreateDTO dto)
        {
            var producto = new Producto
            {
                nombre = dto.Nombre,
                descripcion = dto.Descripcion,
                precio = dto.Precio,
                stock = dto.Stock,
                stock_minimo = dto.StockMinimo,
                codigo_barra = dto.CodigoBarra,
                estado = true,
                id_categoria = dto.IdCategoria,
                id_proveedor = dto.IdProveedor
            };

            await _productoRepository.AddAsync(producto);

            return new ProductoDTO
            {
                Id = producto.id,
                Nombre = producto.nombre,
                Descripcion = producto.descripcion,
                Precio = producto.precio,
                Stock = producto.stock,
                StockMinimo = producto.stock_minimo,
                CodigoBarra = producto.codigo_barra,
                Estado = producto.estado,
                CategoriaNombre = null, // Lo podés llenar si hacés un include
                ProveedorNombre = null
            };
        }

        public async Task<ProductoDTO> UpdateAsync(ProductoUpdateDTO dto)
        {
            var existente = await _productoRepository.GetByIdAsync(dto.Id);
            if (existente == null) return null;

            existente.nombre = dto.Nombre;
            existente.descripcion = dto.Descripcion;
            existente.precio = dto.Precio;
            existente.stock = dto.Stock;
            existente.stock_minimo = dto.StockMinimo;
            existente.codigo_barra = dto.CodigoBarra;
            existente.estado = dto.Estado;
            existente.id_categoria= dto.IdCategoria;
            existente.id_proveedor = dto.IdProveedor;

            await _productoRepository.UpdateAsync(existente);

            return new ProductoDTO
            {
                Id = existente.id,
                Nombre = existente.nombre,
                Descripcion = existente.descripcion,
                Precio = existente.precio,
                Stock = existente.stock,
                StockMinimo = existente.stock_minimo,
                CodigoBarra = existente.codigo_barra,
                Estado = existente.estado,
                CategoriaNombre = null,
                ProveedorNombre = null
            };
        }
    }
}