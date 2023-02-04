using Domain.Dto;
using WebApplication1.Application.utils;
namespace WebApplication1.Application.Interfaces.IServices
{
    public interface IAlquilerServices
    {
        public Response CreateAlquilerReserva(AlquilerDTO alquiler);
        public Response GetAlquileresByClienteId(int id);
        public Response GetReservasByClienteId(int id);

        public Response UpdateReservaAlquiler(UpdateReservaAlquilerDTO updateReservaAlquiler);
        public Response ListAlquilerLibroByEstado(int estado);
    }
}
