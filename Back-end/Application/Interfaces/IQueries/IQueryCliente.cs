using Domain.Entities;
namespace WebApplication1.Application.Interfaces.IQueries
{
    public interface IQueryCliente
    {
        public Cliente GetClienteDni(string dni);
        public Cliente GetClientePorId(int ClienteId);
        public List<Cliente> GetClientesByFiltros(string nombre, string apellido, string dni);
    }
}
