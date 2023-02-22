using PS.Template.Domain.DtoModels;
using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Interface
{
    public interface IUserQuery
    {
        public User SearchUserByEmail(string _user);
        public User SearchUserById(int _user);
        public List<User> SearchUserList(User user);
        public User SearchUserExist(dtoLoginUser loginUser);
        public List<User> SearchUserByName(string Name);
    }
}
