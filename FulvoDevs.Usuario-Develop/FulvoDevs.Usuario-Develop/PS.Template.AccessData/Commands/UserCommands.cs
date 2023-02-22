using PS.Template.AccessData.DBContext;
using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Security;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DtoModels;
using PS.Template.Domain.Models;
using System.Collections;


namespace PS.Template.AccessData.Commands
{
    public class UserCommands : IUserCommands
    {
        private readonly ProyectoSoftwareContext _context;

        public UserCommands(ProyectoSoftwareContext cont)
        {
            _context = cont;
        }
        public Response CreateUser(dtoUser _user)
        {
            security password = new security();

            try
            {
                ArrayList response = password.encryption(_user.Contraseña);

                var user = new User();
                {
                    user.Nombre = _user.Nombre;
                    user.Apellido = _user.Apellido;
                    user.Email = _user.Email;
                    user.Contraseña = response[0].ToString();//esto puede q no funcione
                    user.IsCreate = DateTime.Now;
                    user.softDelete = false;
                    user.salt = (byte[])response[1];
                }
                _context.users.Add(user);
                _context.SaveChanges();

                var responseCreated = new Response(true, "creacion del usuario completada");
                responseCreated.objects = user;
                return responseCreated;
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }
        public Response UpdateUser(User user, dtoUserPut newInfo)
        {
            try
            {
                user.Telefono = newInfo.Telefono;
                user.Edad = newInfo.Edad;

                _context.Update(user);
                _context.SaveChanges();

                return new Response(true, "update del usuario completado");
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }
        public Response DeleteUser(User user)
        {
            var response = new Response(true, "Usuario inhabilitado correctamente");
            try
            {
                user.softDelete = true;
                _context.Update(user);
                _context.SaveChanges();
                return response;
            }
            catch (Exception)
            {
                response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }

        }

        public Response UpdateImage(User user, string phatImg)
        {
            try
            {
                user.profilePicture = phatImg;
                _context.Update(user);
                _context.SaveChanges();

                return new Response(true, "update del usuario completado");
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }
        public Response UpdateDescription(User user, string description)
        {
            try
            {
                user.Description = description;
                _context.Update(user);
                _context.SaveChanges();

                return new Response(true, "update del usuario completado");
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }

        public Response UpdateTeam(User user, string Team)
        {
            try
            {
                user.EquipoFutbol = Team;
                _context.Update(user);
                _context.SaveChanges();

                return new Response(true, "update del usuario completado");
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }

        public Response UpdateUbication(User user, string Ubication)
        {
            try
            {
                user.Ubicacion = Ubication;
                _context.Update(user);
                _context.SaveChanges();

                return new Response(true, "update del usuario completado");
            }
            catch (Exception)
            {
                var response = new Response(false, "Internal server error");
                response.StatusCode = 500;
                return response;
            }
        }
    }
}
