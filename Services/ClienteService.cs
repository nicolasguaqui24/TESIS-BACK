/*using KioscoAPI.DTOs;
using KioscoAPI.Models;
using KioscoAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KioscoAPI.Data;
namespace KioscoAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly ICuentaRepository _cuentaRepository;

        public ClienteService(IClienteRepository repository, ICuentaRepository cuentaRepository)
        {
            _repository = repository;
            _cuentaRepository = cuentaRepository;
        }

        public async Task<List<ClienteDTO>> ObtenerTodosAsync()
        {
            var clientes = await _repository.ObtenerTodosAsync();
            return clientes.Select(c => MapToDTO(c)).ToList();
        }

        public async Task<ClienteDTO> ObtenerPorIdAsync(int id)
        {
            var cliente = await _repository.ObtenerPorIdAsync(id);
            if (cliente == null)
                return null;

            return MapToDTO(cliente);
        }

        public async Task<ClienteDTO> CrearClienteAsync(ClienteDTO clienteDto)
        {
            var cliente = new Cliente
            {
                
                nombre = clienteDto.Nombre,
                telefono = clienteDto.Telefono,
                email = clienteDto.Email,
                activo = clienteDto.Activo,
                deuda = clienteDto.Deuda,
                observaciones = clienteDto.Observaciones,
                direccion = clienteDto.Direccion,
                tipo_cliente = clienteDto.TipoCliente
            };

            var nuevoCliente = await _repository.CrearClienteAsync(cliente);
            var cuenta = new Cuenta
            {
                numero = GenerarNumeroCuenta(),
                saldo = 0,
                activa = true,
                ClienteId = nuevoCliente.id
            };

            await _cuentaRepository.CrearCuentaAsync(cuenta);
            return MapToDTO(nuevoCliente);
        }

        private ClienteDTO MapToDTO(Cliente c) =>
            new ClienteDTO
            {
                Id = c.id,
                Nombre = c.nombre,
                Telefono = c.telefono,
                Email = c.email,
                Activo = c.activo,
                Deuda = c.deuda,
                Observaciones = c.observaciones,
                Direccion = c.direccion,
                TipoCliente = c.tipo_cliente
            };
    }
}*/