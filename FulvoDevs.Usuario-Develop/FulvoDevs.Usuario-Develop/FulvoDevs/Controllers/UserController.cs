using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS.Template.Aplication.Interface;
using PS.Template.Aplication.Utils;
using PS.Template.Domain.DtoModels;
using PS.Template.Domain.Models;
using System.Collections;

namespace FulvoDevs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService use)
        {
            _userServices = use;
        }
        [HttpPost("Register"), AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] dtoUser user)
        {
            var response = _userServices.CrateUser(user);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content, Token = response.objects , Id = response.arrList[0] }) { StatusCode = response.StatusCode };
        }

        [HttpPut("updateUser"), Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] dtoUserPut modi)
        {
            var user = User.Identity.Name;
            var response = _userServices.UpdateUser(user, modi);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
        }
        [HttpPut("updateDescription"), Authorize]
        public IActionResult UpdateDescription([FromBody] dtoUpdateDescriptionUser modify)
        {
            var user = User.Identity.Name;
            var response = _userServices.UpdateDescription(user, modify);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
        }
        [HttpPut("updateTeam"), Authorize]
        public IActionResult UpdateTeam([FromBody] dtoUpdateDescriptionUser modify)
        {
            var user = User.Identity.Name;
            var response = _userServices.UpdateTeam(user, modify.description);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
        }
        [HttpPut("updateUbication"), Authorize]
        public IActionResult UpdateUbication([FromBody] dtoUpdateDescriptionUser modify)
        {
            var user = User.Identity.Name;
            var response = _userServices.UpdateUbication(user, modify.description);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
        }

        [HttpPut("deleteUser"), Authorize]
        public async Task<IActionResult> DeleteUser()
        {
            var user = User.Identity.Name;
            var response = _userServices.DeleteUser(user);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
        }
        [HttpPut("profileImg"), Authorize]
        public IActionResult PutProfilePicturePicture([FromBody] DtoProfileImg dtoimg)
        {
            var user = User.Identity.Name;
            var response = _userServices.PutImg(user,dtoimg.pathImg);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
        }

        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var response = _userServices.GetUserById(id);
                var user = (ReturnUserByID)response.objects;
                if (!response.succes)
                {
                    return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
                }
                return new JsonResult(user)
                { StatusCode = response.StatusCode };
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetUserByNane(string Name)
        {
            try
            {
                var response = _userServices.GetUserByName(Name);
                ArrayList array = new ArrayList();
                if (!response.succes)
                {
                    return new JsonResult(new { error = response.content }) { StatusCode = response.StatusCode };
                }
                else
                {
                    foreach (User user in response.arrList)
                    {
                        array.Add(new
                        {
                            nombre = user.Nombre,
                            apellido = user.Apellido,
                            email = user.Email,
                        });
                    }
                    response.arrList = array;
                }
                return new JsonResult(new { list = response.arrList }) { StatusCode = response.StatusCode };
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpGet("email"), AllowAnonymous]
        public IActionResult GetUserIdByEmail(string email)
        {
            try
            {
                var response = _userServices.GetUserIdByEmail(email);
                if (!response.succes)
                {
                    return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
                }
                return new JsonResult(new { Id = response.arrList[0], }) { StatusCode = response.StatusCode };
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
