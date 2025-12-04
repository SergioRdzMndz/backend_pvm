using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly PvmContext _context;

        public ProveedoresController(PvmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.proveedores.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var proveedor = await _context.proveedores.FindAsync(id);
            return proveedor == null ? NotFound() : Ok(proveedor);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Proveedores proveedores)
        {
            _context.proveedores.Add(proveedores);
            await _context.SaveChangesAsync();
            return Ok(proveedores);    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, Proveedores proveedores)
        {
            if (id != proveedores.IdProveedor)
                return BadRequest();

            _context.Entry(proveedores).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(proveedores);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _context.proveedores.FindAsync(id);
            if(proveedor == null)
                return NotFound();
            _context.proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
