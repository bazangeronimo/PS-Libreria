using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Interfaces.IServices;
namespace Api.Controllers
{

    [Route("api/alquiler")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerServices serviceAlquiler;
        public AlquilerController(IAlquilerServices service)
        {
            this.serviceAlquiler = service;
        }

        [HttpPost]
        public IActionResult PostUser(AlquilerDTO alquilerDTO)
        {
            try
            {
                var response = serviceAlquiler.CreateAlquilerReserva(alquilerDTO);
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

        [HttpPut]
        public IActionResult UpdateAlquilerReserva(UpdateReservaAlquilerDTO id)
        {
            try
            {
                var response = serviceAlquiler.UpdateReservaAlquiler(id);
                if (!response.succes)
                {
                    return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
                }
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAlquileresLibroByEstado(int estado)
        {
            try
            {
                var response = serviceAlquiler.ListAlquilerLibroByEstado(estado);
                if (!response.succes)
                {
                    return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
                }
                return new JsonResult(new { Estado = response.arrList }) { StatusCode = response.StatusCode };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cliente/{id}")]

        public IActionResult GetAlquileresByClienteId(int id)
        {
            var response = serviceAlquiler.GetAlquileresByClienteId(id);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.arrList }) { StatusCode = response.StatusCode };
        }

        [HttpGet("reservas/cliente/{id}")]

        public IActionResult GetReservasByClienteId(int id)
        {
            var response = serviceAlquiler.GetReservasByClienteId(id);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.arrList }) { StatusCode = response.StatusCode };
        }
    }
}
