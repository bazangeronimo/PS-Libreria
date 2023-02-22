using PS.Template.Aplication.Utils;
using PS.Template.Domain.DtoModels;

namespace PS.Template.Aplication.Interface
{
    public interface IUserService
    {
        public Response CrateUser(dtoUser user);
        public Response UpdateUser(string user, dtoUserPut newInfo);
        public Response UpdateDescription(string user, dtoUpdateDescriptionUser description);
        public Response DeleteUser(string user);
        public Response GetUserById(int id, int owner);
        public Response GetUserByName(string Name);
        public Response PutImg(string user, string pathIMG);
        public Response GetUserIdByEmail(string email);
        public Response UpdateTeam(string user, string team);
        public Response UpdateUbication(string user, string ubicacion);
        public Response GetUsersRandom(string user);
    }
}
