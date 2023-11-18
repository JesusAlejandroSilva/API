using BusinessLayers.Interfaces;
using DataLayer.Interfaces;
using EntitiesLayer.DTO;
using EntitiesLayer.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayers.Services
{
    public class UserServices: IUsersServices
    {
            
        private readonly IUsersRepository _usersRepository;
        private readonly ILogger<UserServices> _logger;


        public UserServices(IUsersRepository users, ILogger<UserServices> logger)
        {
            this._usersRepository = users;
            this._logger = logger;

        }

        public CustomResponseDto<List<GetUsersDTO>> Login(string userName, string Pass)
        {
            CustomResponseDto<List<GetUsersDTO>> response = null;
            try
            {
                List<GetUsersDTO> result = _usersRepository.Login(userName, Pass);
                response = new CustomResponseDto<List<GetUsersDTO>>()
                {
                    Content = result,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                response = new CustomResponseDto<List<GetUsersDTO>>
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
