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
        var venta = new Venta
        {
            fecha = dto.Fecha != default(DateTime) ? dto.Fecha : DateTime.Now,
            tipo_venta = dto.TipoVenta,
            total = dto.Total,
            saldo_pendiente = dto.SaldoPendiente,
            fecha_pago_pactado = dto.FechaPagoPactado,
            observaciones = dto.Observaciones,
            id_cliente = dto.IdCliente,
            id_usuario = dto.IdUsuario,
            id_cuenta = dto.IdCuenta,
            estado = "Pendiente",
            DetalleVenta = dto.Detalles.Select(d => new DetalleVenta
            {
                id_producto = d.IdProducto,
                cantidad = d.Cantidad,
                precio_unitario = d.PrecioUnitario
            }).ToList()
        };

        return await _repository.CrearVentaAsync(venta);
    }
}