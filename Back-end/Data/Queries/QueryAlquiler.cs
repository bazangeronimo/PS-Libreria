using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.Interfaces.IQueries;

namespace WebApplication1.Data.Queries
{
    public class QueryAlquiler : IQueryAlquiler
    {
        private readonly LibreriaContext context;
        public QueryAlquiler(LibreriaContext contex)
        {
            this.context = contex;
        }
        public Alquiler? AlquilerByClienteIdAndIsbn(int clienteId, string isbn)
        {
            return context.Alquileres.Where(a => a.ClienteId == clienteId && a.ISBN == isbn && a.EstadoDeAlquilerId == 1).FirstOrDefault();
        }
        public Alquiler? AlquilerByCliente(int clienteId)
        {
            return context.Alquileres.Where(a => a.ClienteId == clienteId && a.EstadoDeAlquilerId == 2).FirstOrDefault();
        }
        public Alquiler? ReservaByCliente(int clienteId)
        {
            return context.Alquileres.Where(a => a.ClienteId == clienteId && a.EstadoDeAlquilerId == 1).FirstOrDefault();
        }
        public List<Alquiler> GetAlquileresByClienteId(int id)
        {
            return context.Alquileres.Where(a => a.ClienteId == id).ToList();
        }
        public List<Alquiler> GetReservasByClienteId(int id)
        {
            return context.Alquileres.Where(a => a.ClienteId == id && a.EstadoDeAlquilerId == 1).ToList();
        }

        public List<Alquiler> GetAllAlquileres()
        {
            return context.Alquileres.ToList();
        }
        public List<Alquiler> ListAlquilerLibroByEstado(int? estado)
        {
            return context.Alquileres.Include(a => a.Libros).Where(a => a.EstadoDeAlquilerId == estado).ToList();
        }

    }
}



