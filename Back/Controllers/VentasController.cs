using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly PvmContext _context;

        public VentasController (PvmContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.ventas.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var venta = await _context.ventas.FindAsync(id);
            return venta == null ? NotFound() : Ok(venta);
        }
        [HttpPost]
        public async Task<IActionResult>Post(Ventas ventas)
        {
            _context.ventas.Add(ventas);
            await _context.SaveChangesAsync();
            return Ok(ventas);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ventas ventas)
        {
            if (id != ventas.IdVenta)
                return BadRequest();

            _context.Entry(ventas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(ventas);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var venta = await _context.ventas.FindAsync(id);
            if (venta == null)
                return NotFound();

            _context.ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
