using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Utils;
using PS.Template.Aplication.Utils.Authentication;
using PS.Template.Domain.DtoModels;
using PS.Template.Domain.Models;
using System.Collections;


namespace PS.Template.Aplication.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserCommands _userCommands;
        private readonly IUserQuery _userQuery;
        private readonly IFollowQuery _followQuery;
        private readonly IFeaturesQueries _featureQuery;
        private readonly JwtAuthManager _jwtAuthManager;
        public UserServices(IUserCommands com, IUserQuery query, JwtAuthManager jwtAuthManager, IFollowQuery foll, IFeaturesQueries featured)
        {
            _userCommands = com;
            _userQuery = query;
            _jwtAuthManager = jwtAuthManager;
            _followQuery = foll;
            _featureQuery = featured;
        }
        public Response CrateUser(dtoUser user)
        {
            var response = new Response(true, "Se ha creado el usuario correctamente");
            response.StatusCode = 200;

            var fieldsvalidator = this.ValidateFields(user);
            if (!fieldsvalidator.succes)
            {
                response.content = fieldsvalidator.content;
                response.succes = false;
                response.StatusCode = fieldsvalidator.StatusCode;
                return response;
            }

            var userfound = _userQuery.SearchUserByEmail(user.Email);

            if (userfound != null)
            {
                response.content = "El Email ya pertenece a un usuario existente";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }

            var userCreated = _userCommands.CreateUser(user);
            if (!userCreated.succes)
            {
                response.succes = false;
                response.content = userCreated.content;
                response.StatusCode = userCreated.StatusCode;
            }

            var token = _jwtAuthManager.Authenticate((User)userCreated.objects);
            response.objects = token;
            response.arrList = new ArrayList() { ((User)userCreated.objects).Usuario_Id };
            return response;
        }
        public Response GetUserById(int id)
        {
            var response = new Response(true, "Usuario Encontrado");
            var query = _userQuery.SearchUserById(id);
            if (query == null)
            {
                response.succes = false;
                response.content = "Usuario no existente";
                response.StatusCode = 400;
                return response;
            }
            ReturnUserByID responseObject = new ReturnUserByID();

            responseObject.id = query.Usuario_Id;
            responseObject.name = query.Nombre;
            responseObject.lastName = query.Apellido;
            responseObject.followers = _followQuery.CountFollowersById(id);
            responseObject.following = _followQuery.CountFollowedById(id);
            responseObject.profilePicture = query.profilePicture;
            responseObject.Email = query.Email;
            responseObject.Edad = query.Edad;
            responseObject.SockerTeam = query.EquipoFutbol;
            responseObject.Ubication = query.Ubicacion;
            responseObject.description = query.Description;
            responseObject.Telefono = query.Telefono;
            responseObject.softDelete = query.softDelete;

            List <Features> features = _featureQuery.GetUserFeatures(id);
            if (features != null)
            {
                List<string> featuresList = new List<string>();
                foreach (Features feature in features)
                    featuresList.Add(feature.Skills);
                responseObject.features = featuresList;
            }
            response.objects=responseObject;
            response.StatusCode = 200;
            return response;
        }
        public Response GetUserByName(string Name)
        {
            var response = new Response(true, "");

            var query = _userQuery.SearchUserByName(Name);

            ArrayList array = new ArrayList();
            if (query == null)
            {
                response.succes = false;
                response.content = "El nombre es nulo ";
                response.StatusCode = 400;
            }
            else
            {
                foreach (User user in query)
                {
                    array.Add(user);
                }
                response.arrList = array;
                response.StatusCode = 200;
            }
            return response;
        }
        public Response UpdateUser(string user, dtoUserPut newInfo)
        {
            var response = new Response(true, "Se ha realizado los cambios correctamente");
            var fieldsvalidator = this.ValidUpdateFields(newInfo);
            if (!fieldsvalidator.succes)
            {
                response.content = fieldsvalidator.content;
                response.succes = false;
                response.StatusCode = fieldsvalidator.StatusCode;
                return response;
            }

            var userFound = _userQuery.SearchUserById(Convert.ToInt32(user));
            if (userFound == null)
            {
                response.content = "El Id no se encontro en la base de datos";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }

            _userCommands.UpdateUser(userFound, newInfo);

            return response;
        }
        public Response DeleteUser(string user)
        {
            var response = new Response(true, "usuario inhabilitado Correctamente");

            var userfound = _userQuery.SearchUserById(Convert.ToInt32(user));
            if (userfound == null)
            {
                response.content = "El Id no se encontro en la base de datos";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            if (!userfound.softDelete)
            {
                _userCommands.DeleteUser(userfound);
            }
            else
            {
                response.content = "El Id no se encontro en la base de datos";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            return response;
        }
        private Response ValidateFields(dtoUser user)
        {
            var response = new Response(true, "La informacion ingresada se verifico correctamente");
            if (user.Nombre == "" || user.Nombre == null)
            {
                response.content = "El campo de Nombre ingresado es nulo o se encuentra vacio";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            if (user.Apellido == "" || user.Apellido == null)
            {
                response.content = "El campo de Apellido ingresado es nulo o se encuentra vacio";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            if (user.Email == "" || user.Email == null)
            {
                response.content = "El campo de Email ingresado es nulo o se encuentra vacio";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            if (user.Contraseña == "" || user.Contraseña == null)
            {
                response.content = "El campo Contraseña no puede contener digitos no numericos";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            return response;
        }
        private Response ValidUpdateFields(dtoUserPut newInfo)
        {
            var response = new Response(true, "La informacion ingresada se verifico correctamente");
            response.StatusCode = 200;
            if (newInfo.Telefono > 9999999999 || newInfo.Telefono < 10000000)
            {
                response.content = "El telefono contiene menos de 8 caracteres o mas de 10 caracteres";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            if (newInfo.Edad > 125 || newInfo.Edad < 1)
            {
                response.content = "Su edad es menor a uno o mayor a 125";
                response.succes = false;
                response.StatusCode = 400;
                return response;
            }
            return response;
        }

        public Response PutImg(string user, string pathIMG)
        {
            var response = new Response(true, "se ha guardado correctamente la imagen");
            try
            {
                if (pathIMG == null || pathIMG == " ")
                {
                    response.succes = false;
                    response.StatusCode = 401;
                    response.content = "se esperaba recubir una direccion de la imagen";
                    return response;
                }
                var userFound = _userQuery.SearchUserById(Convert.ToInt32(user));
                if (userFound == null)
                {
                    response.content = "El Id no se encontro en la base de datos";
                    response.succes = false;
                    response.StatusCode = 400;
                    return response;
                }
                _userCommands.UpdateImage(userFound,pathIMG);
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.StatusCode = 500;
                response.content = "internal server error";
                return response;
            }
            
        }

        public Response UpdateDescription(string user, dtoUpdateDescriptionUser description)
        {
            var response = new Response(true, "se ha actualizado la description correctamente");
            try
            {
                if (description.description == null || description.description == " ")
                {
                    response.succes = false;
                    response.StatusCode = 401;
                    response.content = "se esperaba recubir una description";
                    return response;
                }
                var userFound = _userQuery.SearchUserById(Convert.ToInt32(user));
                if (userFound == null)
                {
                    response.content = "El Id no se encontro en la base de datos";
                    response.succes = false;
                    response.StatusCode = 400;
                    return response;
                }
                _userCommands.UpdateDescription(userFound, description.description);
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.StatusCode = 500;
                response.content = "internal server error";
                return response;
            }
        }

        public Response GetUserIdByEmail(string email)
        {     
            return new Response(true, "") { arrList = new ArrayList() { _userQuery.SearchUserByEmail(email).Usuario_Id }, StatusCode = 200 };
        }

        public Response UpdateTeam(string user, string team)
        {
            var response = new Response(true, "se ha actualizado el equipo correctamente");
            try
            {
                if (team == null || team == " ")
                {
                    response.succes = false;
                    response.StatusCode = 401;
                    response.content = "se esperaba recubir un equipo de futbol";
                    return response;
                }
                var userFound = _userQuery.SearchUserById(Convert.ToInt32(user));
                if (userFound == null)
                {
                    response.content = "El Id no se encontro en la base de datos";
                    response.succes = false;
                    response.StatusCode = 400;
                    return response;
                }
                _userCommands.UpdateTeam(userFound, team);
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.StatusCode = 500;
                response.content = "internal server error";
                return response;
            }
        }

        public Response UpdateUbication(string user, string ubicacion)
        {
            var response = new Response(true, "se ha actualizado la Ubicacion correctamente");
            try
            {
                if (ubicacion == null || ubicacion == " ")
                {
                    response.succes = false;
                    response.StatusCode = 401;
                    response.content = "se esperaba recubir una ubicacion";
                    return response;
                }
                var userFound = _userQuery.SearchUserById(Convert.ToInt32(user));
                if (userFound == null)
                {
                    response.content = "El Id no se encontro en la base de datos";
                    response.succes = false;
                    response.StatusCode = 400;
                    return response;
                }
                _userCommands.UpdateUbication(userFound, ubicacion);
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.succes = false;
                response.StatusCode = 500;
                response.content = "internal server error";
                return response;
            }
        }
    }
}