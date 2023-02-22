using PS.Template.Aplication.Utils;
using PS.Template.Domain.DtoModels;

namespace PS.Template.Aplication.Interface
{
    public interface IAuthService
    {
        public Response GetLoginUser(dtoLoginUser loginUser);
    }
}
