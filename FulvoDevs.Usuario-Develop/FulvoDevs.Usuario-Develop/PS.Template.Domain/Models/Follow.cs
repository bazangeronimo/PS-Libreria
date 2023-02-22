namespace PS.Template.Domain.Models
{
    public class Follow
    {
        public int FollowKey { get; set; }

        public int usuario_Fk { get; set; }
        public User? Usuario_Id { get; set; } = null;

        public int seguido_Fk { get; set; }
        public User? Seguido { get; set; } = null;

        public DateTime Fecha { get; set; }

        public bool softDelete { get; set; }
    }
}
