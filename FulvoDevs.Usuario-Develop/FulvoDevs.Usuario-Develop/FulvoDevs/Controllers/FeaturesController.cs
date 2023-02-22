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
    public class FeaturesController : ControllerBase
    {
        private readonly IFeaturesService _featureServices;
        public FeaturesController(IFeaturesService use)
        {
            _featureServices = use;
        }
        [HttpPost("Create"), Authorize]
        public async Task<IActionResult> CreateFeatures([FromBody] dtoCreateFeatured featured)
        {
            var user = Convert.ToInt32(User.Identity.Name);
            var response = _featureServices.CreateFeature(user, featured);
            if (!response.succes)
            {
                 return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content}) { StatusCode = response.StatusCode };
        }
        [HttpPut("Update"), Authorize]
        public async Task<IActionResult> UpdateFeatures([FromBody] dtoUpdateFeature featured)
        {
            var user = Convert.ToInt32(User.Identity.Name);
            var response = _featureServices.UpdateFeature(user, featured);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
        }
        [HttpPut("Delete"), Authorize]
        public async Task<IActionResult> DeleteFeatures([FromBody] dtoDeleteFeature featured)
        {
            var user = Convert.ToInt32(User.Identity.Name);
            var response = _featureServices.DeleteFeature(user, featured);
            if (!response.succes)
            {
                return new JsonResult(new { Error = response.content }) { StatusCode = response.StatusCode };
            }
            return new JsonResult(new { Message = response.content }) { StatusCode = response.StatusCode };
        }
    }
}

