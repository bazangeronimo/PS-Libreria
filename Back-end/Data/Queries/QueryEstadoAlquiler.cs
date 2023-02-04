using Application.Interfaces.IQueries;
using Domain.Entities;
namespace WebApplication1.Data.Queries
{
    public class QueryEstadoAlquiler : IQueryEstadoAlquiler
    {
        private readonly LibreriaContext context;
        public QueryEstadoAlquiler(LibreriaContext contex)
        {
            this.context = contex;
        }
        public EstadoDeAlquiler Estado(int id)
        {
            return context.EstadoDeAlquileres.Where(e => e.EstadoDeAlquilerId == id).FirstOrDefault();
        }
        public List<EstadoDeAlquiler> Cantidad()
        {
            return context.EstadoDeAlquileres.ToList();
        }
    }
}
