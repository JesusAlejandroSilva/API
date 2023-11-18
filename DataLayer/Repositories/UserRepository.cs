using DataConnect.Connection;
using DataLayer.Interfaces;
using EntitiesLayer.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace DataLayer.Repositories
{
    public class UserRepository: IUsersRepository
    {
        private readonly string connectionString;
        private readonly ILogger<UserRepository> _logger;


        public UserRepository(IConfiguration configuration, ILogger<UserRepository> logger)
        {
            connectionString = configuration.GetConnectionString(Constants.BD_TecUsers);
            this._logger = logger;
        }

        public List<GetUsersDTO> Login(string userName, string Pass)
        {
            List<GetUsersDTO> users = new List<GetUsersDTO>();
            ConnectionDB connection = new ConnectionDB(connectionString);
            string storedProcedure = "dbo.LoginByUsers @UserName, @Pass";
            users = connection.ExecuteReaderList<GetUsersDTO>(storedProcedure, new Dictionary<string, object>()
            {
    

            }).ToList();

            return users;
        }
    }
}
