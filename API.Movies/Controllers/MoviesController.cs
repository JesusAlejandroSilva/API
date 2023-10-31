using BusinessLayers.Interfaces;
using EntitiesLayer.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Movies.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesServices _movies;


        public MoviesController(IMoviesServices movies)
        {
            this._movies = movies;
        }

        [Route("CreateMovies")]
        [HttpPost]
        public IActionResult CreateMovies([FromBody] CreateMovieDTO moviesDTO)
        {
            CustomResponseDto<bool> response = _movies.CreateMovies(moviesDTO);
            return StatusCode(response.StatusCode, response);
        }

        [Route("GetMoviesByTitle")]
        [HttpGet]
        public IActionResult GetMoviesByTitle(string title)
        {
            CustomResponseDto<List<GetMovieByTitle>> response = _movies.getMovieByTitle(title);
            return StatusCode(response.StatusCode, response);
        }


        [Route("GetMovies")]
        [HttpGet]
        public IActionResult GetMovies()
        {
            CustomResponseDto<List<GetMovieByTitle>> response = _movies.GetMovies();
            return StatusCode(response.StatusCode, response);
        }
    }
}
