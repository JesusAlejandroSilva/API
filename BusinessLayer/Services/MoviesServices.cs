using BusinessLayer.Interfaces;
using EntitiesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class MoviesServices : IMoviesServices
    {
        private readonly IMoviesRepository _studentRepository;
        private readonly ILogger<StudentServices> _logger;
        public CustomResponseDto<bool> CreateMovie(CreateMovieDTO createMovie)
        {
            throw new NotImplementedException();
        }

        public CustomResponseDto<List<GetMovieByTitle>> GetMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
