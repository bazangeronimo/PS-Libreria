using System.ComponentModel.DataAnnotations;

namespace PS.Template.Domain.Models
{
    public class Features//Caracteristicas
    {
        [Key]
        public int Caracteristica_Id { get; set; }

        public int UsuarioId { get; set; }
        public User Usuario { get; set; }

        public string Skills { get; set; }

        public bool softDelete { get; set; }
    }
}
