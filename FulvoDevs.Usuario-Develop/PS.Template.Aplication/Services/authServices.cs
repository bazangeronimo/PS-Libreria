using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Utils;
using PS.Template.Aplication.Utils.Authentication;
using PS.Template.Domain.DtoModels;

namespace PS.Template.Aplication.Services
{
    public class authServices : IAuthService
    {

        private readonly IUserQuery _userQuery;
        private readonly JwtAuthManager _jwtAuthManager;
        public authServices(IUserQuery query, JwtAuthManager manager)
        {
            _userQuery = query;
            _jwtAuthManager = manager;
        }
        public Response GetLoginUser(dtoLoginUser loginUser)
        {

            var response = new Response(true, "Usuario Encontrado");
            response.StatusCode = 200;
            var query = _userQuery.SearchUserByEmail(loginUser.email);
            if (query == null)
            {
                response.succes = false;
                response.content = "Usuario no existente";
                response.StatusCode = 400;
                return response;
            }
            Authentications password = new Authentications();
            loginUser.contraseña = password.Verification(loginUser.contraseña, query.salt);
            if (loginUser.contraseña != query.Contraseña)
            {
                response.succes = false;
                response.content = "Contraseña incorrecta";
                response.StatusCode = 400;
            }
            var token = _jwtAuthManager.Authenticate(query);
            response.objects = token;
            return response;
        }
    }
}
