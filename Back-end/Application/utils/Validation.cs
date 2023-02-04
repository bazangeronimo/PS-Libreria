using Domain.Dto;
using System.Text.RegularExpressions;
namespace WebApplication1.Application.utils
{
    public class Validation
    {
        public static bool Dni(string dni)
        {
            return ((dni != "") && Numero(dni) && dni.Length == 8);
        }
        public static bool Numero(string numero)
        {
            return int.TryParse(numero, out _);
        }
        public static bool Email(string email)
        {
            return (email != "" && !Numero(email) && email.Length >= 7 && Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"));
        }
        public static bool String(string cadena)
        {
            return (cadena.Length >= 4 && Regex.IsMatch(cadena, @"^[a-zA-Z]+$"));
        }
        public static Response CamposAlquiler(AlquilerDTO alquilerDto)
        {
            var response = new Response(true, " Los campos son correctos");
            if (alquilerDto.ISBN == "")
            {
                response.succes = false;
                response.content = " El campo ISBN no debe ser vacio.";
                return response;
            }
            if (alquilerDto.FechaAlquiler == null && alquilerDto.FechaReserva == null)
            {
                response.succes = false;
                response.content = " Fecha Alquiler y Fecha Reserva no pueden ser nulos a la misma vez";
                return response;
            }
            return response;
        }
        public static Response CamposUpdate(UpdateReservaAlquilerDTO updateReservaAlquiler)
        {
            var response = new Response(true, " Los campos son correctos");
            if (updateReservaAlquiler.ISBN == "" || updateReservaAlquiler.ISBN == null || updateReservaAlquiler.ISBN.Length > 45)
            {
                response.succes = false;
                response.content = " El campo ISBN no debe ser vacio, nulo, ni superar 45 caracteres.";
                return response;
            }
            return response;
        }
    }
}
