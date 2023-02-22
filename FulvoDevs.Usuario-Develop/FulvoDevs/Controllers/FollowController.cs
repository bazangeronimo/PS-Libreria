using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interface;
using PS.Template.Domain.DtoModels;

namespace FulvoDevs.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService fol)
        {
            _followService = fol;
        }

        [HttpPost("Follow"), Authorize]
        public async Task<IActionResult> PostFollow([FromBody] dtoCreateFollow newFollowed)
        {
            var user = Convert.ToInt32(User.Identity.Name);
            var response = _followService.CreateFollow(user, newFollowed.idSeguido);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = 404 };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = 201 };
            //return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
        }
        [HttpDelete("unFollow"), Authorize]
        public async Task<IActionResult> UnFollow([FromBody] dtoCreateFollow newFollowed)
        {
            var user = Convert.ToInt32(User.Identity.Name);
            var response = _followService.removeFollow(user, newFollowed.idSeguido);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = 404 };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = 200 };
        }
        [HttpGet("getFollows"), Authorize]
        public async Task<IActionResult> GetFollow()
        {
            var user = Convert.ToInt32(User.Identity.Name);
            var response = _followService.GetFollows(user);
            if (!response.succes)
            {
                response.content = "Error al devolver la lista";
                return new JsonResult(new { Error = response.content }) { StatusCode = 404 };
            }
            return new JsonResult(response.objects) { StatusCode = 200 };
        }
    }
}
