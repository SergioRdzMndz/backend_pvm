//Pablo//
namespace Back.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = "pendiente";
        public List<PedidoDetalle> Detalles { get; set; } = new();
    }

    public class PedidoDetalle
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}