using BusinessLayers.Interfaces;
using EntitiesLayer.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Users.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _users;

        public UsersController(IUsersServices users)
        {
            this._users = users;
        }


        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string userName, string Pass)
        {
            CustomResponseDto<List<GetUsersDTO>> response = _users.Login(userName, Pass);
            return StatusCode(response.StatusCode, response);
        }
    }
}
