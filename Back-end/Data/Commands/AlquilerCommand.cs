using Domain.Dto;
using Domain.Entities;
using WebApplication1.Application.Interfaces.ICommand;
using WebApplication1.Application.utils;

namespace WebApplication1.Data.Commands
{
    public class AlquilerCommand : IAlquilerCommand
    {
        private readonly LibreriaContext context;
        public AlquilerCommand(LibreriaContext context)
        {
            this.context = context;
        }
        public Response CreateAlquiler(AlquilerDTO alquilerDto)
        {
            Response response = new(true, " El alquiler se ha realizado correctamente");
            response.StatusCode = 201;
            try
            {
                Libro libro = context.Libros.Where(l => l.ISBN == alquilerDto.ISBN).First();
                Alquiler alquiler = new()
                {
                    ClienteId = alquilerDto.Cliente,
                    ISBN = alquilerDto.ISBN,
                    EstadoDeAlquilerId = 2,
                    FechaAlquiler = DateTime.Now,
                    FechaDevolucion = DateTime.Now.AddDays(7),
                };
                libro.Stock--;
                context.Add(alquiler);
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
        public Response CreateReserva(AlquilerDTO alquilerDto)
        {
            Response response = new(true, " La reserva se ha realizado correctamente");
            response.StatusCode = 200;
            try
            {
                Libro libro = context.Libros.Where(l => l.ISBN == alquilerDto.ISBN).First();
                Alquiler alquiler = new()
                {
                    ClienteId = alquilerDto.Cliente,
                    ISBN = alquilerDto.ISBN,
                    EstadoDeAlquilerId = 1,
                    FechaReserva = DateTime.Now,
                };
                libro.Stock--;
                context.Add(alquiler);
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

        public Response UpdateReservaAlquiler(Alquiler updateReservaAlquiler)
        {
            Response response = new(true, " El estado reserva fue actualizado al estado alquiler correctamente.");
            response.StatusCode = 200;
            try
            {
                updateReservaAlquiler.EstadoDeAlquilerId = 2;
                updateReservaAlquiler.FechaAlquiler = DateTime.Now;
                updateReservaAlquiler.FechaDevolucion = DateTime.Now.AddDays(7);
                context.Alquileres.Update(updateReservaAlquiler);
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

