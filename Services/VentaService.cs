using KioscoAPI.Models;
using KioscoAPI.Repositories;
using KioscoAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

    


namespace KioscoAPI.Services;

public class VentaService : IVentaService
{
    private readonly IVentaRepository _repository;

    public VentaService(IVentaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Venta> CrearVentaDesdeDTOAsync(VentaDTO dto)  
    {
        if (dto.Detalles == null || !dto.Detalles.Any())
            throw new ArgumentException("La venta debe contener al menos un detalle.");
        var detalles = dto.Detalles.Select(d => new DetalleVenta
        {
            id_producto = d.IdProducto,
            cantidad = d.Cantidad,
            precio_unitario = d.PrecioUnitario,
            subtotal = d.Cantidad * d.PrecioUnitario
        }).ToList();

        var venta = new Venta
        {
            fecha = dto.Fecha != default(DateTime) ? dto.Fecha : DateTime.Now,
            tipo_venta = dto.TipoVenta,
            total = detalles.Sum(d => d.subtotal),
            fecha_pago_pactado = dto.FechaPagoPactado,
            observaciones = dto.Observaciones,
            id_cliente = dto.id_cliente,
            id_usuario = dto.id_usuario,
            id_cuenta = dto.id_cuenta,
            estado = "Pendiente",
      
        };
        venta.DetalleVenta = detalles;
        return await _repository.CrearVentaAsync(venta);
    }
}