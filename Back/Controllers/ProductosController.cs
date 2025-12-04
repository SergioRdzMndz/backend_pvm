    using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    //Sergio Rodríguez Mendoza
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
       private readonly PvmContext _context;

        public ProductosController(PvmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.productos.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            return producto == null ? NotFound() : Ok(producto);   
        }

        [HttpPost]
        public async Task<IActionResult> Post(Productos productos)
        { 
            _context.productos.Add(productos);
            await _context.SaveChangesAsync();
            return Ok(productos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Productos productos)
        {
            if(id != productos.IdProducto)
                return BadRequest();    

            _context.Entry(productos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(productos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
                return NotFound();

            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
