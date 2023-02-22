using PS.Template.Aplication.Utils;
using PS.Template.Domain.DtoModels;
using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Interface
{
    public interface IUserCommands
    {

        public Response CreateUser(dtoUser user);
        public Response UpdateUser(User user, dtoUserPut newInfo);
        public Response UpdateDescription(User user, string description);
        public Response DeleteUser(User user);
        public Response UpdateImage(User user, string phatImg);
        public Response UpdateTeam(User user, string Team);
        public Response UpdateUbication(User user, string Ubication);
    }
}
