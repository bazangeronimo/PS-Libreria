using Domain.Entities;
namespace Application.Interfaces.IQueries
{
    public interface IQueryEstadoAlquiler
    {
        public EstadoDeAlquiler Estado(int est);
        public List<EstadoDeAlquiler> Cantidad();
    }
}
