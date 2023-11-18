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
    public class PersonsRepository : IPersonsRepository
    {
        private readonly string connectionString;
        private readonly ILogger<PersonsRepository> _logger;

        public PersonsRepository(IConfiguration configuration, ILogger<PersonsRepository> logger)
        {
            connectionString = configuration.GetConnectionString(Constants.BD_TecUsers);
            this._logger = logger;
        }

        public GetStatusCreate CreatePersons(CreatePersonsDTO createPersonsDTO)
        {
            Persons persons = new Persons();
            GetStatusCreate response = null;

            using (var db = new TecUsersContextDB())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        persons.Names = createPersonsDTO.Names;
                        persons.LastNames = createPersonsDTO.LastNames;
                        persons.Type_Ide = createPersonsDTO.Type_Ide;
                        persons.Id_Number = createPersonsDTO.Id_Number;
                        persons.Email = createPersonsDTO.Email;
                        persons.Date_Creation = DateTime.Now;


                        db.Persons.Add(persons);
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

        //public List<GetUsersDTO> moviesByTitles(string title)
        //{
        //    List<GetUsersDTO> getMovie = new List<GetUsersDTO>();
        //    ConnectionDB connection = new ConnectionDB(connectionString);
        //    string storedProcedure = "SP.GetMoviesByTitle @Title";
        //    getMovie = connection.ExecuteReaderList<GetUsersDTO>(storedProcedure, new Dictionary<string, object>()
        //    {
        //        {"@IdProvincia", title}

        //    }).ToList();

        //    return getMovie;
        //}

        //public List<GetUsersDTO> GetMovies()
        //{
        //    List<GetUsersDTO> getMovie = new List<GetUsersDTO>();
        //    ConnectionDB connection = new ConnectionDB(connectionString);
        //    string storedProcedure = "SP.GetMovies";
        //    getMovie = connection.ExecuteReaderList<GetUsersDTO>(storedProcedure, new Dictionary<string, object>()
        //    {
           

        //    }).ToList();

        //    return getMovie;
        //}

    }
}
