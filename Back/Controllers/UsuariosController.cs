using Back.Data;
using Back.Models;
using Back.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly PvmContext _context;
        public UsuariosController(PvmContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.usuarios.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            return usuario == null ? NotFound() : Ok (usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Usuarios usuarios)
        {
            usuarios.ContraseñaHash = PasswordHasher.Hash(usuarios.ContraseñaHash);
            _context.usuarios.Add(usuarios);
            await _context.SaveChangesAsync();
            return Ok(usuarios);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
                return BadRequest();
            _context.Entry(usuarios).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(usuarios);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();
            _context.usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
