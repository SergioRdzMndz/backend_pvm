//Pablo//
namespace Back.DTOs
{
    public class CrearPedidoDto
    {
        public int IdCliente { get; set; }
        public List<PedidoDetalleDto>? Detalles { get; set; }
    }

    public class PedidoDetalleDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}