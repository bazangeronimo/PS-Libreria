using Domain.Entities;
namespace WebApplication1.Application.Interfaces.IQueries
{
    public interface IQueryLibro
    {
        public Libro BuscarLibro(string isbn);
        public int? Stock(string isbn);
        public List<Libro> GetLibrosByFiltros(bool? stock, string autor, string titulo);
        public Libro GetLibroByIsbn(string isbn);
        public List<Libro> ListaLibros(string isbn);
    }
}
