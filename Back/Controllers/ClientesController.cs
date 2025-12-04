using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly PvmContext _context;

        public ClientesController(PvmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.clientes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _context.clientes.FindAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Clientes clientes)
        {
            _context.clientes.Add(clientes);
            await _context.SaveChangesAsync();
            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Clientes clientes)
        {
            if (id != clientes.IdCliente)
                return BadRequest();
            _context.Entry(clientes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(clientes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _context.clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _context.clientes.Remove(cliente);
            await _context.SaveChangesAsync();  
            return Ok();
        }

      
    }
}
