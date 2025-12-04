using Back.Data;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly PvmContext _context;
        public EmpleadosController(PvmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.empleados.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var empleado = await _context.empleados.FindAsync(id);
            return empleado == null ? NotFound() : Ok(empleado);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Empleados empleados)
        {
            _context.empleados.Add(empleados);
            await _context.SaveChangesAsync();
            return Ok(empleados);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Empleados empleados)
        {
            if(id != empleados.IdEmpleado)
                return BadRequest();
            _context.Entry(empleados).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(empleados);   
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _context.empleados.FindAsync(id);
            if (empleado == null)
                return NotFound();
            _context.empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
