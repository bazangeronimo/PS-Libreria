using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Interfaces.IServices;
namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices serviceCliente;
        public ClienteController(IClienteServices service)
        {
            this.serviceCliente = service;
        }

        [HttpPost("clientes")]
        public IActionResult PostUser(ClienteDTO ClienteDto)
        {
            try
            {
                var response = serviceCliente.CreateCliente(ClienteDto);
                if (!response.succes)
                {
                    return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
                }
                return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("clientes")]
        public IActionResult GetClientes([FromQuery] string? nombre, [FromQuery] string? apellido, [FromQuery] string? dni)
        {
            try
            {
                var response = serviceCliente.GetClientesByFiltro(nombre, apellido, dni);
                if (!response.succes)
                {
                    return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
                }
                return new JsonResult(new { Message = response.content, Clientes = response.objects }) { StatusCode = response.StatusCode };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
