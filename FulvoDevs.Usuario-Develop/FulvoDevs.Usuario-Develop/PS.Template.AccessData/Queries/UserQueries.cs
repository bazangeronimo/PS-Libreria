using PS.Template.AccessData.DBContext;
using PS.Template.Aplication.Interface;
using PS.Template.Domain.DtoModels;
using PS.Template.Domain.Models;

namespace PS.Template.AccessData.Queries
{
    public class UserQueries : IUserQuery
    {
        private readonly ProyectoSoftwareContext _context;

        public UserQueries(ProyectoSoftwareContext cont)
        {
            _context = cont;
        }


        public User SearchUserByEmail(string _user)
        {
            var UserExistEmail = _context.users.Where(s => s.Email == _user).Where(A => A.softDelete == false).FirstOrDefault();

            return UserExistEmail;
        }

        public User SearchUserById(int UserId)
        {
            var UserExistId = _context.users.Where(s => s.Usuario_Id == UserId).FirstOrDefault();
            return UserExistId;
        }
        public List<User> SearchUserList(User user)
        {
            List<User> users = _context.users.Where(X => X.Usuario_Id == user.Usuario_Id).ToList();
            return users;
        }

        public User SearchUserExist(dtoLoginUser loginUser)
        {
            var userExist = _context.users.Where(X => X.Email == loginUser.email && X.Contraseña == loginUser.contraseña).FirstOrDefault();
            return userExist;
        }

        public List<User> SearchUserByName(string Name)
        {
            var listUser = (from b in _context.users where b.Nombre.StartsWith(Name) select b).ToList();
            return listUser;
        }
    }
}
