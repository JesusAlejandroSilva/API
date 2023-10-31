using DataConnect.Connection;
using DataLayer.DBContext;
using DataLayer.Interfaces;
using EntitiesLayer.DTO;
using EntitiesLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace DataLayer.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly string connectionString;
        private readonly ILogger<MoviesRepository> _logger;

        public MoviesRepository(IConfiguration configuration, ILogger<MoviesRepository> logger)
        {
            connectionString = configuration.GetConnectionString(Constants.BD_MOVIES);
            this._logger = logger;
        }

        public GetStatusCreate CreateMovie(CreateMovieDTO createMoviesDTO)
        {
            Movies movies = new Movies();
            GetStatusCreate response = null;

            using (var db = new MoviesContextDB())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        movies.Title = createMoviesDTO.Title;
                        movies.Description = createMoviesDTO.Description;
                        movies.launch_date = createMoviesDTO.launch_date;
                        movies.score = createMoviesDTO.score;

                        db.Movies.Add(movies);
                        db.SaveChanges();

                        dbContextTransaction.Commit();

                        response = new GetStatusCreate()
                        {
                            IsSuccessful = true,
                        };

                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        response = new GetStatusCreate()
                        {
                            IsSuccessful = false,
                            Message = string.Format("ERROR INESPERADO")
                        };
                        var sts = new System.Diagnostics.StackTrace();
                        var sf = sts.GetFrame(1);
                        _logger.LogError(ex, this.GetType().Name + "-" +
                                       sf.GetMethod().Name + ": " +
                                       ex.Message + " Detail: " +
                                       ex.StackTrace);
                    }

                }

            }
            return response;


        }

        public List<GetMovieByTitle> moviesByTitles(string title)
        {
            List<GetMovieByTitle> getMovie = new List<GetMovieByTitle>();
            ConnectionDB connection = new ConnectionDB(connectionString);
            string storedProcedure = "SP.GetMoviesByTitle @Title";
            getMovie = connection.ExecuteReaderList<GetMovieByTitle>(storedProcedure, new Dictionary<string, object>()
            {
                {"@IdProvincia", title}

            }).ToList();

            return getMovie;
        }

        public List<GetMovieByTitle> GetMovies()
        {
            List<GetMovieByTitle> getMovie = new List<GetMovieByTitle>();
            ConnectionDB connection = new ConnectionDB(connectionString);
            string storedProcedure = "SP.GetMovies";
            getMovie = connection.ExecuteReaderList<GetMovieByTitle>(storedProcedure, new Dictionary<string, object>()
            {
           

            }).ToList();

            return getMovie;
        }

    }
}
