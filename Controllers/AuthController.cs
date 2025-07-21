using KioscoAPI.DTOs;
using KioscoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KioscoAPI.Repositories;
using KioscoAPI.Services;


namespace KioscoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public AuthController(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO login)
        {
            var token = await _authService.LoginAsync(login.Usuario, login.Password);

            if (token == null)
                return Unauthorized(new { mensaje = "Usuario o credenciales no encontradas" });

            var usuario = await _usuarioRepository.GetByUsuarioAsync(login.Usuario);

            return Ok(new
            {
                token,
                usuario = new
                {
                    usuario.id,
                    usuario.nombre,
                    usuario.usuario,
                    usuario.rol
                }
            });
        } 
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Usuario) || string.IsNullOrEmpty(request.Password))
                return BadRequest(new { mensaje = "Usuario y contraseña son obligatorios." });

            var existente = await _usuarioRepository.GetByUsuarioAsync(request.Usuario);
            if (existente != null)
                return BadRequest(new { mensaje = "Ya existe un usuario con ese nombre de usuario." });

            var usuario = new Usuario
            {
                nombre = request.Nombre,
                usuario = request.Usuario,
                rol = request.Rol,
                password_hash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                activo = true
            };

            await _usuarioRepository.CrearAsync(usuario);
            await _usuarioRepository.SaveAsync();

            return Ok(new { mensaje = "Usuario registrado correctamente." });
        }
    }
    
}