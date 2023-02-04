using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Alquiler
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ISBN { get; set; }
        public int EstadoDeAlquilerId { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
        [JsonIgnore]
        public Libro Libros { get; set; }
        [JsonIgnore]
        public EstadoDeAlquiler EstadoDeAlquiler { get; set; }
    }
}
