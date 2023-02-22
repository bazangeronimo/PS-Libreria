using PS.Template.Aplication.Utils;

namespace PS.Template.Aplication.Interface
{
    public interface IFollowService
    {
        public Response CreateFollow(int follower, int followed);
        public Response removeFollow(int follower, int followed);
        public Response GetFollows(int user);
    }
}
