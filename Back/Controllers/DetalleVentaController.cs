using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentaController : ControllerBase
    {
        private readonly PvmContext _context;

        public DetalleVentaController(PvmContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Detalle.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var detalle = await _context.Detalle.FindAsync(id);
            return detalle == null ? NotFound() : Ok(detalle);
        }

        [HttpPost]
        public async Task<IActionResult>Post(DetalleVenta detalleVenta)
        {
            _context.Detalle.Add(detalleVenta);
            await _context.SaveChangesAsync();
            return Ok(detalleVenta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DetalleVenta detalleVenta)
        {
            if (id != detalleVenta.IdDetalle)
                return BadRequest();    

            _context.Entry(detalleVenta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(detalleVenta);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detalleventa = await _context.Detalle.FindAsync(id);
            if (detalleventa == null)
                return NotFound();
            _context.Detalle.Remove(detalleventa);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
