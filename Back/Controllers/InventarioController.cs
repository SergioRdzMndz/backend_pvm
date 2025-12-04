using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly PvmContext _context;

        public InventarioController(PvmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.inventario.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var inventario = await _context.inventario.FindAsync(id);
            return inventario == null ? NotFound() : Ok(inventario);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Inventario inventario)
        {
            _context.inventario.Add(inventario);
            await _context.SaveChangesAsync();
            return Ok(inventario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Inventario inventario)
        {
            if (id != inventario.IdMovimiento)
                return BadRequest();
            _context.Entry(inventario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(inventario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var inventario = await _context.inventario.FindAsync(id);
            if (inventario == null)
                return NotFound();
            _context.inventario.Remove(inventario);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
