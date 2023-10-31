using EntitiesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IMoviesServices
    {
        CustomResponseDto<bool> CreateMovie(CreateMovieDTO createMovie);
        CustomResponseDto<List<GetMovieByTitle>> GetMovieByTitle(string title);
    }
}
