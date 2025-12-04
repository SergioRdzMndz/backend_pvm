using Back.Data;
using Back.Models;
using Back.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly PvmContext _context;
        public AuthController(PvmContext context) { _context = context; }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var usuario = await _context.usuarios.FirstOrDefaultAsync(x => x.Correo == req.Correo);
            if (usuario == null)
                return BadRequest("Usuario no encontrado");
            var password_hashed = PasswordHasher.Hash(req.Contrasena);
            if (usuario.ContraseñaHash != password_hashed)
                return BadRequest("Contraseña incorrecta");

            // Lógica del token (opción 2)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),  // Corregido: IdUsuario
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.Rol ?? "Usuario")  // Corregido: Rol
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TuClaveSecretaAqui"));  // Cambia por una segura
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "TuIssuer",  // Cambia si quieres
                audience: "TuAudience",  // Cambia si quieres
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                Token = tokenString,  // Usa tokenString aquí
                Role = usuario.Rol  // Corregido: Rol
            });
        }
    }
}