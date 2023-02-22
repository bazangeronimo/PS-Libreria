using PS.Template.AccessData.DBContext;
using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;


namespace PS.Template.AccessData.Queries
{
    public class FollowQueries : IFollowQuery
    {
        private readonly ProyectoSoftwareContext _context;

        public FollowQueries(ProyectoSoftwareContext cont)
        {
            _context = cont;
        }
        public List<Follow> searchFollowsByUser(int userFollower)
        {
            List<Follow> follows = _context.follows.Where(X => X.usuario_Fk == userFollower).Where(Y => Y.softDelete == false).ToList();
            return follows;
        }
        public Response searchFollowExist(int follower, int followed)
        {
            var response = new Response(true, "Follow Existente");
            var followExist = _context.follows.Where(X => X.seguido_Fk == followed).Where(Z => Z.usuario_Fk == follower).Where(Y => Y.softDelete != true).FirstOrDefault();
            response.objects = followExist;
            return response;
        }
        public int CountFollowersById(int id)
        {
            List<Follow> follows = _context.follows.Where(X => X.seguido_Fk == id).Where(Y => Y.softDelete == false).ToList();
            if (follows == null)
                return 0;
            return follows.Count();
        }
        public int CountFollowedById(int id)
        {
            List<Follow> follows = _context.follows.Where(X => X.usuario_Fk == id).Where(Y => Y.softDelete == false).ToList();
            if (follows == null)
                return 0;
            return follows.Count();
        }
    }
}
