using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly PvmContext _context;
        public PagosController(PvmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.pagos.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pago = await _context.pagos.FindAsync(id);
            return pago == null ? NotFound() : Ok(pago);
        }


        /*
        [HttpPost]
        public async Task<IActionResult>Post(Pagos pagos)
        {
            _context.pagos.Add(pagos);
            await _context.SaveChangesAsync();
            return Ok(pagos);
        }
        */
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, Pagos pagos)
        {
            if (id != pagos.IdPago)
                return BadRequest();
            _context.Entry(pagos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(pagos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var pago = await _context.pagos.FindAsync(id);
            if (pago == null)
                return NotFound();
            _context.pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
