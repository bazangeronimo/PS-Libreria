using PS.Template.AccessData.DBContext;
using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;


namespace PS.Template.AccessData.Commands
{
    public class FollowCommans : IfollowCommands
    {
        private readonly ProyectoSoftwareContext _context;

        public FollowCommans(ProyectoSoftwareContext cont)
        {
            _context = cont;
        }
        public Response CreatedFollows(User follower, User followed)
        {
            var response = new Response(true, "Follow creados Exitosamente");
            try
            {
                Follow follow = new Follow
                {
                    usuario_Fk = follower.Usuario_Id,
                    seguido_Fk = followed.Usuario_Id,
                    Fecha = DateTime.Now,
                    softDelete = false
                };
                _context.Add(follow);
                _context.SaveChanges();
                return response;
            }
            catch (Exception)
            {
                response.succes = false;
                response.content = "Internal Server Error";
                return response;
            }

        }
        public Response RemoveFollow(Follow follow)
        {
            var response = new Response(true, "Follows eliminado correctamente");
            try
            {
                follow.softDelete = true;
                _context.Update(follow);
                _context.SaveChanges();
                return response;
            }
            catch (Exception)
            {
                response.succes = false;
                response.content = "Internal Server Error";
                return response;
            }

        }
    }
}
