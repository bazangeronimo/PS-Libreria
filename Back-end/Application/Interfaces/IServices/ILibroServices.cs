using WebApplication1.Application.utils;
namespace WebApplication1.Application.Interfaces.IServices
{
    public interface ILibroServices
    {
        public Response GetLibrosByFiltro(bool? stock, string? autor, string? titulo);
        public Response GetLibrosByStock(int stock, string isbn);
        public Response GetLibrosByIsbn(string? isbn);
    }
}
