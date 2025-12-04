//Pablo//
using Microsoft.AspNetCore.Mvc;
using Back.Services;
using Back.DTOs;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _service;

        public PedidosController(IPedidosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] CrearPedidoDto dto)
        {
            var resultado = await _service.CrearPedido(dto);
            return Ok(resultado);
        }
        [HttpPut("recoleccion/{id}")]
        public async Task<IActionResult> ConfirmarRecoleccion(int id, [FromBody] ConfirmarRecoleccionDto dto)
        {
            var resultado = await _service.ConfirmarRecoleccion(id, dto);

            return Ok(resultado);
        }
        [HttpPost("/api/pagos")]
        public async Task<IActionResult> RegistrarPago([FromBody] RegistrarPagoDTO dto)
        {
            await _service.RegistrarPago(dto);
            return Ok(new {message  = "Pago creado correctamente"});
        }


        [HttpPut("entregas/{id}")]
        public async Task<IActionResult> Entregado(int id, [FromBody] EntregadoDto dto)
        {
            var resultado = await _service.ConfirmarEntrega(id, dto);

            return Ok(resultado);
        }
      
    }
}
