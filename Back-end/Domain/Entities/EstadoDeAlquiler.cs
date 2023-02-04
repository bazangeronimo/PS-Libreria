using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class EstadoDeAlquiler
    {
        public int EstadoDeAlquilerId { get; set; }
        public string Descripcion { get; set; }

        [JsonIgnore]
        public ICollection<Alquiler> AlquilerNavigator { get; set; }
    }
}
