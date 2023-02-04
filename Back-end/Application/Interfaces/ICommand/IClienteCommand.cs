using Domain.Dto;
using WebApplication1.Application.utils;
namespace WebApplication1.Application.Interfaces.ICommand
{
    public interface IClienteCommand
    {
        public Response CreateCliente(ClienteDTO client);
    }
}
