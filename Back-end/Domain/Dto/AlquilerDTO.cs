namespace Domain.Dto
{
    public class AlquilerDTO
    {
        public int Cliente { get; set; }
        public string ISBN { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
    }
}
