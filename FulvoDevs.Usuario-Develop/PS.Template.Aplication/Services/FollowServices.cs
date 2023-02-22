using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;


namespace PS.Template.Aplication.Services
{
    public class FollowServices : IFollowService
    {
        private readonly IfollowCommands _followCommands;
        private readonly IFollowQuery _followQuery;
        private readonly IUserQuery _userQuery;
        public FollowServices(IfollowCommands com, IFollowQuery query, IUserQuery user)
        {
            _followCommands = com;
            _followQuery = query;
            _userQuery = user;
        }
        public Response CreateFollow(int follower, int followed)
        {
            var response = new Response(true, "El seguimiento fue exitoso");
            var validFields = this.ValidatedFollow(follower, followed);
            if (!validFields.succes)
            {
                response.succes = false;
                response.content = validFields.content;
                return response;
            }
            var followerPerson = _userQuery.SearchUserById(follower);
            var followedPerson = _userQuery.SearchUserById(followed);
            if (followerPerson == null)
            {
                response.succes = false;
                response.content = "No se encontro el usuario a seguidor en la base de datos";
                return response;
            }
            if (followedPerson == null)
            {
                response.succes = false;
                response.content = "No se encontro el usuario a seguir en la base de datos";
                return response;
            }
            var followExist = _followQuery.searchFollowExist(follower, followed);
            if (followExist.objects != null)
            {
                response.succes = false;
                response.content = "Ya se encuentra siguiendo a este usuario";
                return response;
            }
            var followCreated = _followCommands.CreatedFollows(followerPerson, followedPerson);
            if (!followCreated.succes)
            {
                response.succes = false;
                response.content = followCreated.content;
                return response;
            }
            return response;
        }
        private Response ValidatedFollow(int follower, int followed)
        {
            var response = new Response(true, "Validacion de dato fue completada correctamente");
            try
            {
                if (follower == null || follower < 1)
                {
                    response.succes = false;
                    response.content = "La id del usuario seguidor no es correcta";
                    return response;
                }
                if (followed == null || followed < 1)
                {
                    response.succes = false;
                    response.content = "La id del usuario seguido no es correcta";
                    return response;
                }
                return response;
            }
            catch (Exception)
            {
                response.succes = false;
                response.content = "Se ha producido un error con la id de uno de los usuarios";
                return response;
            }
        }
        public Response removeFollow(int follower, int followed)
        {
            var response = new Response(true, "Se elimino el seguimiento correctamente");
            var validFields = this.ValidatedFollow(follower, followed);
            if (!validFields.succes)
            {
                response.succes = false;
                response.content = validFields.content;
                return response;
            }
            var foundFollow = _followQuery.searchFollowExist(follower, followed);
            if (foundFollow == null)
            {
                response.succes = false;
                response.content = "No se ha encontrado este seguimiento";
                return response;
            }
            response = _followCommands.RemoveFollow((Follow)foundFollow.objects);
            return response;
        }
        public Response GetFollows(int user)
        {
            Response response = new Response(true, "Seguimientos Encontrados: ");
            List<Follow> follows = _followQuery.searchFollowsByUser(user);
            response.objects = follows;
            return response;
        }

    }
}
