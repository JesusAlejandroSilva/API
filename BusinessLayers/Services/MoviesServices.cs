using BusinessLayers.Interfaces;
using DataLayer.Interfaces;
using EntitiesLayer.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayers.Services
{
    public class MoviesServices: IMoviesServices
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly ILogger<MoviesServices> _logger;

        public MoviesServices(IMoviesRepository movies, ILogger<MoviesServices> logger)
        {
            this._moviesRepository = movies;
            this._logger = logger;
            
        }

        public CustomResponseDto<bool> CreateMovies(CreateMovieDTO createMovie)
        {
            CustomResponseDto<bool> response;
            try
            {
                GetStatusCreate result = _moviesRepository.CreateMovie(createMovie);

                if (result.IsSuccessful == true)
                {
                    response = new CustomResponseDto<bool>()
                    {
                        Content = result.IsSuccessful,
                        IsSuccessful = true,
                        Message = "CREACION EXITOSA"
                    };
                }
                else
                {
                    response = new CustomResponseDto<bool>()
                    {
                        Content = result.IsSuccessful,
                        IsSuccessful = false,
                        Message = result.Message
                    };
                }
            }
            catch (Exception ex)
            {
                response = new CustomResponseDto<bool>()
                {
                    IsSuccessful = false,
                    Message = "ERROR INESPERADO"
                };
                var st = new System.Diagnostics.StackTrace();
                var sf = st.GetFrame(1);
                _logger.LogError(ex, this.GetType().Name + "-" +
                                        sf.GetMethod().Name + ": " +
                                        ex.Message + " Detail: " +
                                        ex.StackTrace);
            }

            return response;

        }

        public CustomResponseDto<List<GetMovieByTitle>> getMovieByTitle(string title)
        {
            CustomResponseDto<List<GetMovieByTitle>> response = null;
            try
            {
                List<GetMovieByTitle> result = _moviesRepository.moviesByTitles(title);
                response = new CustomResponseDto<List<GetMovieByTitle>>()
                {
                    Content = result,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                response = new CustomResponseDto<List<GetMovieByTitle>>
                {
                    IsSuccessful = false,
                    Message = "ERROR INESPERADO"
                };
                var st = new System.Diagnostics.StackTrace();
                var sf = st.GetFrame(1);
                _logger.LogError(ex, this.GetType().Name + "-" +
                                        sf.GetMethod().Name + ": " +
                                        ex.Message + " Detail: " +
                                        ex.StackTrace);
            }
            return response;
        }

        public CustomResponseDto<List<GetMovieByTitle>> GetMovies()
        {
            CustomResponseDto<List<GetMovieByTitle>> response = null;
            try
            {
                List<GetMovieByTitle> result = _moviesRepository.GetMovies();
                response = new CustomResponseDto<List<GetMovieByTitle>>()
                {
                    Content = result,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                response = new CustomResponseDto<List<GetMovieByTitle>>
                {
                    IsSuccessful = false,
                    Message = "ERROR INESPERADO"
                };
                var st = new System.Diagnostics.StackTrace();
                var sf = st.GetFrame(1);
                _logger.LogError(ex, this.GetType().Name + "-" +
                                        sf.GetMethod().Name + ": " +
                                        ex.Message + " Detail: " +
                                        ex.StackTrace);
            }
            return response;


        }
    }
}
