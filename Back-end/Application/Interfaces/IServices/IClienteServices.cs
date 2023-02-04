using Domain.Dto;
using WebApplication1.Application.utils;
namespace WebApplication1.Application.Interfaces.IServices
{
    public interface IClienteServices
    {
        public Response CreateCliente(ClienteDTO cliente);
        public Response GetClientesByFiltro(string nombre, string apellido, string dni);
    }
}
