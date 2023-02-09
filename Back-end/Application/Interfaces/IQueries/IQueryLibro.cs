using Domain.Entities;
namespace WebApplication1.Application.Interfaces.IQueries
{
    public interface IQueryLibro
    {
        public Libro BuscarLibro(string isbn);
        public int? Stock(string isbn);
        public List<Libro> GetLibrosByFiltros(bool? stock, string autor, string titulo);
        //public List<Libro> GetLibrosByAutorTituloIsbn(string autor, string titulo, string isbn);
        public Libro GetLibroByIsbn(string isbn);
        public List<Libro> ListaLibros(string isbn);
        public List<Libro> GetLibrosByInput(string input);
        public List<Libro> ListaAutor(string autor);
        public List<Libro> BuscarAutor(string autor);

    }
}
