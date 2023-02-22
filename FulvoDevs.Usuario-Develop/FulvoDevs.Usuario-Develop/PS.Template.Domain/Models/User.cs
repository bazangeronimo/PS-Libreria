using System.ComponentModel.DataAnnotations;

namespace PS.Template.Domain.Models
{
    public class User
    {
        [Key]
        public int Usuario_Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
        public int? Edad { get; set; }
        public string? Description { get; set; }
        public string? EquipoFutbol { get; set; }
        public string? Ubicacion { get; set; }
        public string Contraseña { get; set; }
        public DateTime IsCreate { get; set; }
        public bool softDelete { get; set; }
        public byte[] salt { get; set; } 
        public string? profilePicture { get; set;}
        //AGREGAR UserEnabled


        public ICollection<Features>? features { get; set; } = null;
        public ICollection<Follow>? follows { get; set; } = null;
        public ICollection<Follow>? followers { get; set; } = null;
    }
}
