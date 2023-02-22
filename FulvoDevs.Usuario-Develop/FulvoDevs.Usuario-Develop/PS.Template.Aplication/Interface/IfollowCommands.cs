using PS.Template.Aplication.Utils;
using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Interface
{
    public interface IfollowCommands
    {
        public Response CreatedFollows(User follower, User followed);
        public Response RemoveFollow(Follow follow);
    }
}
