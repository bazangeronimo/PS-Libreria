using Domain.Entities;
using WebApplication1.Application.Interfaces.IQueries;

namespace WebApplication1.Data.Queries
{
    public class QueryCliente : IQueryCliente
    {
        private readonly LibreriaContext context;
        public QueryCliente(LibreriaContext contex)
        {
            this.context = contex;
        }
        public Cliente GetClienteDni(string dni)
        {
            return context.Clientes.Where(c => c.DNI == dni).FirstOrDefault();
        }
        public Cliente GetClientePorId(int ClienteId)
        {
            return context.Clientes.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
        }

        public List<Cliente> GetClientesByFiltros(string nombre, string apellido, string dni)
        {
            if (nombre != null && apellido != null && dni != null)
            {
                return context.Clientes.Where(cli => ((string.IsNullOrEmpty(nombre) || cli.Nombre.Contains(nombre) || cli.Nombre == nombre) &&
                (string.IsNullOrEmpty(apellido) || cli.Apellido.Contains(apellido) || cli.Apellido == apellido) && (string.IsNullOrEmpty(dni) || cli.DNI.Contains(dni) || cli.DNI == dni))).ToList();
            }
            if (nombre != null && apellido != null && dni == null)
            {
                return context.Clientes.Where(cli => ((string.IsNullOrEmpty(nombre) || cli.Nombre.Contains(nombre) || cli.Nombre == nombre) &&
                (string.IsNullOrEmpty(apellido) || cli.Apellido.Contains(apellido) || cli.Apellido == apellido))).ToList();
            }
            if (nombre != null && apellido == null && dni != null)
            {
                return context.Clientes.Where(cli => ((string.IsNullOrEmpty(nombre) || cli.Nombre.Contains(nombre) || cli.Nombre == nombre) &&
                (string.IsNullOrEmpty(dni) || cli.DNI.Contains(dni) || cli.DNI == dni))).ToList();
            }
            if (nombre != null && apellido == null && dni == null)
            {
                return context.Clientes.Where(cli => ((string.IsNullOrEmpty(nombre) || cli.Nombre.Contains(nombre) || cli.Nombre == nombre))).ToList();
            }
            if (nombre == null && apellido != null & dni != null)
            {
                return context.Clientes.Where(cli => ((string.IsNullOrEmpty(apellido) || cli.Apellido.Contains(apellido) || cli.Apellido == apellido) &&
                (string.IsNullOrEmpty(dni) || cli.DNI.Contains(dni) || cli.DNI == dni))).ToList();
            }
            if (nombre == null && apellido != null && dni == null)
            {
                return context.Clientes.Where(cli => ((string.IsNullOrEmpty(apellido) || cli.Apellido.Contains(apellido) || cli.Apellido == apellido))).ToList();
            }
            if (nombre == null && apellido == null && dni != null)
            {
                return context.Clientes.Where(cli => ((string.IsNullOrEmpty(dni) || cli.DNI.Contains(dni) || cli.DNI == dni))).ToList();
            }
            return context.Clientes.ToList();
        }
    }
}














