using KioscoAPI.DTOs;
using KioscoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KioscoAPI.Repositories;
using KioscoAPI.Services;
using KioscoAPI.DTOs;

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
    var (exito, mensaje) = await _authService.RegistrarUsuarioAsync(request);

    if (!exito)
        return BadRequest(new { mensaje });

    return Ok(new { mensaje });
}
    }
    
}