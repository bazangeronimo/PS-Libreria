using Application.Interfaces.IQueries;
using Domain.Dto;
using Domain.Entities;
using System.Collections;
using WebApplication1.Application.Interfaces.ICommand;
using WebApplication1.Application.Interfaces.IQueries;
using WebApplication1.Application.Interfaces.IServices;
using WebApplication1.Application.utils;
namespace WebApplication1.Application.Services
{
    public class AlquilerServices : IAlquilerServices
    {
        private readonly IAlquilerCommand alquilerCommand;
        private readonly IQueryAlquiler alquilerQuery;
        private readonly IQueryLibro libroQuery;
        private readonly IQueryCliente clienteQuery;
        private readonly IQueryEstadoAlquiler estadoQuery;
        public AlquilerServices(IAlquilerCommand command, IQueryLibro query, IQueryCliente queryCli, IQueryAlquiler queryAlqui, IQueryEstadoAlquiler queryEstado)
        {
            alquilerCommand = command;
            libroQuery = query;
            clienteQuery = queryCli;
            alquilerQuery = queryAlqui;
            estadoQuery = queryEstado;
        }
        public Response CreateAlquilerReserva(AlquilerDTO alquilerDto)
        {
            Response response = new(true, " El registro se ha realizado correctamente");
            var validFields = Validation.CamposAlquiler(alquilerDto);
            if (!validFields.succes)
            {
                response.succes = false;
                response.content = validFields.content;
                response.StatusCode = 400;
                return response;
            }
            if (!ValidarCliente(alquilerDto.Cliente))
            {
                response.succes = false;
                response.content = " El Cliente ingresado no existe en la base de datos.";
                response.StatusCode = 400;
                return response;
            }
            if (!ValidarLibro(alquilerDto.ISBN))
            {
                response.succes = false;
                response.content = " El ISBN ingresado no existe en la base de datos.";
                response.StatusCode = 400;
                return response;
            }
            else
            {
                if (!LibroStock(alquilerDto.ISBN))
                {
                    response.succes = false;
                    response.content = " El libro ingresado no tiene stock.";
                    response.StatusCode = 400;
                    return response;
                }
            }
            if (alquilerDto.FechaAlquiler != null && alquilerDto.FechaReserva != null)
            {
                response.succes = false;
                response.content = " No se puede crear un alquiler y una reserva a la misma vez";
                return response;
            }

            if (alquilerDto.FechaAlquiler != null)
            {
                response = alquilerCommand.CreateAlquiler(alquilerDto);
                response.succes = true;
                response.content = " El alquiler se creo correctamente";
                response.StatusCode = 201;
            }
            else
            {
                response = alquilerCommand.CreateReserva(alquilerDto);
                response.succes = true;
                response.content = " La reserva se creo correctamente";
                response.StatusCode = 201;
            }
            return response;
        }
        public Response UpdateReservaAlquiler(UpdateReservaAlquilerDTO updateReservaAlquiler)
        {
            var response = new Response(true, " La actualizacion se realizo correctamente.");
            Response validFields = Validation.CamposUpdate(updateReservaAlquiler);
            if (!validFields.succes)
            {
                response.succes = false;
                response.content = validFields.content;
                response.StatusCode = 400;
                return response;
            }
            if (clienteQuery.GetClientePorId(updateReservaAlquiler.cliente) == null)
            {
                response.succes = false;
                response.content = " El cliente ingresado no existe en la base de datos";
                response.StatusCode = 400;
                return response;
            }
            if (libroQuery.BuscarLibro(updateReservaAlquiler.ISBN) == null)
            {
                response.succes = false;
                response.content = " El ISBN ingresado no existe en la base de datos";
                response.StatusCode = 400;
                return response;
            }
            var clienteId = alquilerQuery.AlquilerByCliente(updateReservaAlquiler.cliente);
            if (clienteId == null)
            {
                response.content = " El cliente no tiene registrado ninguna reserva.";
                response.StatusCode = 400;
                return response;
            }
            var alquilerIsbn = alquilerQuery.AlquilerByClienteIdAndIsbn(updateReservaAlquiler.cliente, updateReservaAlquiler.ISBN);
            if (alquilerIsbn == null)
            {
                response.content = " El cliente no tiene reservado el ISBN ingresado.";
                response.StatusCode = 400;
                return response;
            }
            Response update = alquilerCommand.UpdateReservaAlquiler(alquilerIsbn);
            response.succes = false;
            response.content = update.content;
            response.content = " Se actualizó el estado de reserva a estado alquiler.";
            response.StatusCode = 201;
            return response;
        }

        public Response GetAlquileresByClienteId(int id)
        {
            ArrayList array = new();
            var response = new Response(true, "El alquiler fue encontrado");
            try
            {
                if (!ValidarCliente(id))
                {
                    response.succes = false;
                    response.content = " El Cliente ingresado no existe en la base de datos.";
                    response.StatusCode = 400;
                    return response;
                }

                var clienteId = alquilerQuery.AlquilerByCliente(id);
                if (clienteId == null)
                {
                    response.succes = false;
                    response.content = " El cliente ingresado no tiene alquileres ni reservas.";
                    response.StatusCode = 400;
                    return response;
                }

                var ListaAlquileres = alquilerQuery.GetAlquileresByClienteId(id);
                foreach (var alquileres in ListaAlquileres)
                {
                    var queryCliente = clienteQuery.GetClientePorId(alquileres.ClienteId);
                    var queryEstado = estadoQuery.Estado(alquileres.EstadoDeAlquilerId);
                    var queryListarLibros = libroQuery.BuscarLibro(alquileres.ISBN);
                    array.Add(new
                    {
                        queryCliente.Nombre,
                        queryCliente.Apellido,
                        queryListarLibros.ISBN,
                        queryListarLibros.Titulo,
                        queryListarLibros.Autor,
                        queryListarLibros.Edicion,
                        queryListarLibros.Editorial,
                        queryListarLibros.Imagen,
                        queryEstado.Descripcion,
                        alquileres.FechaAlquiler,
                        alquileres.FechaReserva,
                        alquileres.FechaDevolucion
                    });
                }
                response.arrList = array;
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = " Internal error";
                response.StatusCode = 500;
                return response;
            }
        }


        public Response GetReservasByClienteId(int id)
        {
            ArrayList array = new();
            var response = new Response(true, "La reserva fue encontrada");
            try
            {
                if (!ValidarCliente(id))
                {
                    response.succes = false;
                    response.content = " El Cliente ingresado no existe en la base de datos.";
                    response.StatusCode = 400;
                    return response;
                }

                var clienteId = alquilerQuery.ReservaByCliente(id);
                if (clienteId == null)
                {
                    response.succes = false;
                    response.content = " El cliente ingresado no tiene reservas.";
                    response.StatusCode = 400;
                    return response;
                }

                var ListaAlquileres = alquilerQuery.GetReservasByClienteId(id);
                foreach (var alquileres in ListaAlquileres)
                {
                    var queryCliente = clienteQuery.GetClientePorId(alquileres.ClienteId);
                    var queryEstado = estadoQuery.Estado(alquileres.EstadoDeAlquilerId);
                    var queryListarLibros = libroQuery.BuscarLibro(alquileres.ISBN);
                    array.Add(new
                    {
                        queryCliente.Nombre,
                        queryCliente.Apellido,
                        queryListarLibros.ISBN,
                        queryListarLibros.Titulo,
                        queryListarLibros.Autor,
                        queryListarLibros.Edicion,
                        queryListarLibros.Editorial,
                        queryListarLibros.Imagen,
                        queryEstado.Descripcion,
                        alquileres.FechaReserva,
                    });
                }
                response.arrList = array;
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = " Internal error";
                response.StatusCode = 500;
                return response;
            }
        }


        public Response ListAlquilerLibroByEstado(int estado)
        {
            Response response = new(true, "");
            ArrayList array = new();
            List<Alquiler> queryListarAlquiler;
            try
            {
                if (estado > estadoQuery.Cantidad().Count)
                {
                    response.succes = false;
                    response.content = " El estado ingresado es invalido.";
                    response.StatusCode = 400;
                    return response;
                }
                if (!ValidarEstado(estado))
                {
                    queryListarAlquiler = alquilerQuery.GetAllAlquileres();
                }
                else
                {
                    queryListarAlquiler = alquilerQuery.ListAlquilerLibroByEstado(estado);
                }
                foreach (var alquiler in queryListarAlquiler)
                {
                    if (alquiler.EstadoDeAlquilerId == 1)
                    {
                        var queryListarLibros = libroQuery.BuscarLibro(alquiler.ISBN);
                        var queryEstado = estadoQuery.Estado(alquiler.EstadoDeAlquilerId);
                        array.Add(new
                        {
                            alquiler.ISBN,
                            queryListarLibros.Titulo,
                            queryListarLibros.Autor,
                            queryListarLibros.Editorial,
                            queryListarLibros.Edicion,
                            queryListarLibros.Imagen,
                            queryEstado.Descripcion,
                            alquiler.FechaReserva
                        });
                    }
                    if (alquiler.EstadoDeAlquilerId == 2)
                    {
                        var queryListarLibros = libroQuery.BuscarLibro(alquiler.ISBN);
                        var queryEstado = estadoQuery.Estado(alquiler.EstadoDeAlquilerId);
                        array.Add(new
                        {
                            alquiler.ISBN,
                            queryListarLibros.Titulo,
                            queryListarLibros.Autor,
                            queryListarLibros.Editorial,
                            queryListarLibros.Edicion,
                            queryListarLibros.Imagen,
                            queryEstado.Descripcion,
                            alquiler.FechaAlquiler,
                            alquiler.FechaDevolucion
                        });
                    }
                    else
                    {
                        var alquileres = alquilerQuery.GetAllAlquileres();
                        response.objects = alquileres;
                    }
                }
                response.arrList = array;
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = " Internal error";
                response.StatusCode = 500;
                return response;
            }
        }
        private bool ValidarCliente(int id)
        {
            Cliente cliente = clienteQuery.GetClientePorId(id);
            return (cliente != null);
        }
        private bool ValidarLibro(string isbn)
        {
            Libro libro = libroQuery.BuscarLibro(isbn);
            return (libro != null);
        }
        private bool LibroStock(string isbn)
        {
            Libro libro = libroQuery.BuscarLibro(isbn);
            return (libro.Stock > 0);
        }
        private bool ValidarEstado(int estado)
        {
            EstadoDeAlquiler est = estadoQuery.Estado(estado);
            return (est != null);
        }
    }
}

