using EntitiesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IMoviesRepository
    {
        GetStatusCreate CreateMovie(CreateMovieDTO createMoviesDTO);
        List<GetMovieByTitle> moviesByTitles(string title);
        List<GetMovieByTitle> GetMovies();
    }
}
