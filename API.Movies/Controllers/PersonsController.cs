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
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsServices _persons;


        public PersonsController(IPersonsServices persons)
        {
            this._persons = persons;
        }

        [Route("CreatePersons")]
        [HttpPost]
        public IActionResult CreatePersons([FromBody] CreatePersonsDTO createPersons)
        {
            CustomResponseDto<bool> response = _persons.CreatePersons(createPersons);
            return StatusCode(response.StatusCode, response);
        }
    }
}
