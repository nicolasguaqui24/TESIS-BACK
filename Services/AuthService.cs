using BCrypt.Net;
using KioscoAPI.Models;
using KioscoAPI.Repositories;
using KioscoAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KioscoAPI { 
public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration, ILogger<AuthService> logger)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<string?> LoginAsync(string usuario, string password)
    {
        _logger.LogInformation($"Intentando login para usuario: {usuario}");

        var user = await _usuarioRepository.GetByUsuarioAsync(usuario);

        if (user == null)
        {
            _logger.LogWarning($"Usuario '{usuario}' no encontrado.");
            return null;
        }

        if (!user.activo)
        {
            _logger.LogWarning($"Usuario '{usuario}' está inactivo.");
            return null;
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.password_hash);
        _logger.LogInformation($"Validación de contraseña para '{usuario}': {isPasswordValid}");

        if (!isPasswordValid)
            return null;

        _logger.LogInformation($"Login exitoso para usuario: {usuario}");

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(Usuario user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.usuario),
                new Claim(ClaimTypes.Role, user.rol ?? "Usuario")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
