using EntitiesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayers.Interfaces
{
    public interface IMoviesServices
    {
        CustomResponseDto<bool> CreateMovies(CreateMovieDTO createMovie);
        CustomResponseDto<List<GetMovieByTitle>> getMovieByTitle(string title);
        CustomResponseDto<List<GetMovieByTitle>> GetMovies();
    }
}
