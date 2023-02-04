using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Interfaces.IServices;
namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroServices serviceLibro;
        public LibroController(ILibroServices service)
        {
            this.serviceLibro = service;
        }
        [HttpGet("libros")]
        public IActionResult GetLibros([FromQuery] bool? stock, [FromQuery] string? autor, [FromQuery] string? titulo)
        {
            try
            {
                var response = serviceLibro.GetLibrosByFiltro(stock, autor, titulo);
                if (!response.succes)
                {
                    return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
                }
                return new JsonResult(new { Message = response.content, Libros = response.objects }) { StatusCode = response.StatusCode };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpHead("libros/{id}")]
        public IActionResult GetLibros([FromQuery] int stock, string id)
        {
            try
            {
                var response = serviceLibro.GetLibrosByStock(stock, id);
                if (response.succes)
                {
                    return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
                }
                return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //GetLibrosByIsbn
        [HttpGet("libros/isbn")]
        public IActionResult GetLibrosByIsbn([FromQuery] string isbn)
        {
            var response = serviceLibro.GetLibrosByIsbn(isbn);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.arrList }) { StatusCode = response.StatusCode };
        }
    }
}
