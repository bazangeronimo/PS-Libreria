using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;


namespace PS.Template.Aplication.Interface
{
    public interface IFollowQuery
    {
        public List<Follow> searchFollowsByUser(int userFollower);
        public Response searchFollowExist(int follower, int followed);
        public int CountFollowersById(int id);
        public int CountFollowedById(int id);
    }
}
