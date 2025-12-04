//Pablo//
using Back.DTOs;

namespace Back.Services
{
    public interface IPedidosService
    {
        //Sergio Rodríguez Mendoza
        Task<int> CrearPedido(CrearPedidoDto dto);
        //Saul Alvarado//
        Task<bool> ConfirmarRecoleccion(int id, ConfirmarRecoleccionDto dto);
        //Saul Alvarado//
        Task<bool> ConfirmarEntrega(int id,EntregadoDto dto);
        //Sergio Rodríguez Mendoza
        Task RegistrarPago(RegistrarPagoDTO dto);
    }
}