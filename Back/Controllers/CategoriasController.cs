using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly PvmContext _context;

        public CategoriasController(PvmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Categorias.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            return categoria == null ? NotFound() : Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Categorias categorias)
        {
            _context.Categorias.Add(categorias);
            await _context.SaveChangesAsync();
            return Ok(categorias);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Categorias categorias)
        {
           
            if (id != categorias.IdCategoria)
                return BadRequest();

            _context.Entry(categorias).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(categorias);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return NotFound();
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return Ok();
        }

        
    }
}
