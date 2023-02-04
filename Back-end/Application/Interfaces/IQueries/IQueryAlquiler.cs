using Domain.Entities;
namespace WebApplication1.Application.Interfaces.IQueries
{
    public interface IQueryAlquiler
    {
        public Alquiler? AlquilerByClienteIdAndIsbn(int clienteId, string isbn);
        public Alquiler? AlquilerByCliente(int clienteId);
        public Alquiler? ReservaByCliente(int clienteId);
        public List<Alquiler> GetAlquileresByClienteId(int id);
        public List<Alquiler> GetReservasByClienteId(int id);

        public List<Alquiler> GetAllAlquileres();
        public List<Alquiler> ListAlquilerLibroByEstado(int? estado);
    }
}
