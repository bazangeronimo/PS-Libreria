using Domain.Dto;
using Domain.Entities;
using WebApplication1.Application.Interfaces.ICommand;
using WebApplication1.Application.utils;
namespace WebApplication1.Data.Commands
{
    public class ClienteCommand : IClienteCommand
    {
        private readonly LibreriaContext context;
        public ClienteCommand(LibreriaContext context)
        {
            this.context = context;
        }
        public Response CreateCliente(ClienteDTO client)
        {

            Response response = new(true, " El cliente ha sido creado correctamente");
            response.StatusCode = 201;
            try
            {
                var cliente = new Cliente()
                {
                    DNI = client.DNI,
                    Apellido = client.Apellido,
                    Nombre = client.Nombre,
                    Email = client.Email
                };
                context.Add(cliente);
                context.SaveChanges();

                return response;
            }
            catch
            {
                response.succes = false;
                response.content = " Internal server error";
                response.StatusCode = 500;
                return response;
            }
        }
    }
}
