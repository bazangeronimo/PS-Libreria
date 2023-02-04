using Domain.Dto;
using WebApplication1.Application.Interfaces.ICommand;
using WebApplication1.Application.Interfaces.IQueries;
using WebApplication1.Application.Interfaces.IServices;
using WebApplication1.Application.utils;
namespace WebApplication1.Application.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteCommand clienteCommand;
        private readonly IQueryCliente clienteQuery;
        public ClienteServices(IClienteCommand command, IQueryCliente query)
        {
            clienteCommand = command;
            clienteQuery = query;
        }
        public Response CreateCliente(ClienteDTO cliente)
        {
            Response response = new(true, " Se ha creado un cliente correctamente.");
            if (clienteQuery.  GetClienteDni(cliente.DNI) != null)
            {
                response.succes = false;
                response.content = " El dni ingresado ya existe en la base de datos";
                response.StatusCode = 400;
                return response;
            }
            else
            {
                if (!Validation.Dni(cliente.DNI))
                {
                    response.succes = false;
                    response.content = " El dni ingresado es invalido.";
                    response.StatusCode = 400;
                    return response;
                }
                if (!Validation.String(cliente.Nombre))
                {
                    response.succes = false;
                    response.content = " El nombre ingresado es invalido.";
                    response.StatusCode = 400;
                    return response;
                }
                if (!Validation.String(cliente.Apellido))
                {
                    response.succes = false;
                    response.content = " El apellido ingresado es invalido.";
                    response.StatusCode = 400;
                    return response;
                }
                if (!Validation.Email(cliente.Email))
                {
                    response.succes = false;
                    response.content = " El email ingresado es invalido.";
                    response.StatusCode = 400;
                    return response;
                }
                else
                {
                    _ = clienteCommand.CreateCliente(cliente);
                    response.StatusCode = 201;
                }
            }
            return response;
        }
        public Response GetClientesByFiltro(string nombre, string apellido, string dni)
        {
            Response response = new(true, " Lista de clientes");
            response.StatusCode = 200;
            var filtrarClientes = clienteQuery.GetClientesByFiltros(nombre, apellido, dni);
            if (filtrarClientes.Count == 0)
            {
                response.succes = false;
                response.StatusCode = 400;
                response.content = " No se encontraron clientes.";
            }
            else
            {
                response.objects = filtrarClientes;
            }
            return response;
        }
    }
}
