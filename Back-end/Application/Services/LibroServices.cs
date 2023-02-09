using Domain.Entities;
using System.Collections;
using WebApplication1.Application.Interfaces.IQueries;
using WebApplication1.Application.Interfaces.IServices;
using WebApplication1.Application.utils;
namespace WebApplication1.Application.Services
{
    public class LibroServices : ILibroServices
    {
        private readonly IQueryLibro libroQuery;
        public LibroServices(IQueryLibro query)
        {
            libroQuery = query;
        }
        public Response GetLibrosByFiltro(bool? stock, string? autor, string? titulo)
        {
            Response response = new(true, " Lista de libros");
            response.StatusCode = 200;
            var libros = libroQuery.GetLibrosByFiltros(stock, autor, titulo);
            if (libros.Count == 0)
            {
                response.succes = false;
                response.StatusCode = 400;
                response.content = " Libro/s no encontrado/s";
            }
            else
            {
                response.objects = libros;
            }
            return response;
        }
        public Response GetLibrosByInput(string? input)
        {
            Response response = new(true, " Lista de libros");
            response.StatusCode = 200;
            var libros = libroQuery.GetLibrosByInput(input);
            if (libros.Count == 0)
            {
                response.succes = false;
                response.StatusCode = 400;
                response.content = " Libro/s no encontrado/s";
            }
            else
            {
                response.objects = libros;
            }
            return response;
        }
        public Response GetLibrosByStock(int stock, string isbn)
        {
            Response response = new(true, "");
            response.StatusCode = 400;
            if (!ValidarLibro(isbn))
            {
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            if (libroQuery.Stock(isbn) >= stock)
            {
                response.succes = false;
                response.StatusCode = 200;
                return response;
            }
            return response;
        }
        public Response GetLibrosByIsbn(string? isbn)
        {
            ArrayList array = new();
            var response = new Response(true, "El alquiler fue encontrado");
            try
            {
                if (!ValidarLibro(isbn))
                {
                    response.succes = false;
                    response.content = " El Libro ingresado no existe en la base de datos.";
                    response.StatusCode = 400;
                    return response;
                }
                var ListaLibros = libroQuery.ListaLibros(isbn);
                foreach (var libro in ListaLibros)
                {
                    array.Add(new
                    {
                        libro.ISBN,
                        libro.Titulo,
                        libro.Autor,
                        libro.Edicion,
                        libro.Editorial,
                        libro.Stock,
                        libro.Imagen,

                    });
                }
                response.arrList = array;
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = " Internal error";
                response.StatusCode = 500;
                return response;
            }
        }
        public Response GetLibrosByLibroAutor(string? autor)
        {
            ArrayList array = new();
            var response = new Response(true, "El autor fue encontrado");
            try
            {
                if (!ValidarAutor(autor))
                {
                    response.succes = false;
                    response.content = " El Autor ingresado no existe en la base de datos.";
                    response.StatusCode = 400;
                    return response;
                }
                var ListaAutores = libroQuery.ListaAutor(autor);
                foreach (var autores in ListaAutores)
                {
                    array.Add(new
                    {
                        autores.ISBN,
                        autores.Titulo,
                        autores.Autor,
                        autores.Edicion,
                        autores.Editorial,
                        autores.Stock,
                        autores.Imagen,

                    });
                }
                response.arrList = array;
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.content = " Internal error";
                response.StatusCode = 500;
                return response;
            }
        }
        private bool ValidarLibro(string isbn)
        {
            Libro libro = libroQuery.BuscarLibro(isbn);
            return (libro != null);
        }
        private bool ValidarAutor(string autor)
        {
            List<Libro> aut = libroQuery.BuscarAutor(autor);
            return (aut != null);
        }

    }
}
