using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interface;
using PS.Template.Domain.DtoModels;

namespace FulvoDevs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        private readonly IAuthService _authService;

        public authController(IAuthService auth)
        {
            _authService = auth;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult LoginUser(dtoLoginUser loginUser)
        {
            try
            {
                var ClientExist = _authService.GetLoginUser(loginUser);
                if (!ClientExist.succes)
                {
                    return new JsonResult(new { Error = ClientExist.content }) { StatusCode = ClientExist.StatusCode };
                }
                return new JsonResult(new { Token = ClientExist.objects }) { StatusCode = ClientExist.StatusCode };
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }
}
