using Domain.Dto;
using Domain.Entities;
using WebApplication1.Application.utils;
namespace WebApplication1.Application.Interfaces.ICommand
{
    public interface IAlquilerCommand
    {
        public Response CreateAlquiler(AlquilerDTO alquiler);
        public Response CreateReserva(AlquilerDTO alquiler);
        public Response UpdateReservaAlquiler(Alquiler updateReservaAlquiler);
    }
}
