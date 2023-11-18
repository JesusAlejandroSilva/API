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
    public class PersonServices: IPersonsServices
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly ILogger<PersonServices> _logger;

        public PersonServices(IPersonsRepository persons, ILogger<PersonServices> logger)
        {
            this._personsRepository = persons;
            this._logger = logger;
            
        }

        public CustomResponseDto<bool> CreatePersons(CreatePersonsDTO createPersons)
        {
            CustomResponseDto<bool> response;
            try
            {
                GetStatusCreate result = _personsRepository.CreatePersons(createPersons);

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

        //public CustomResponseDto<List<GetUsersDTO>> getMovieByTitle(string title)
        //{
        //    CustomResponseDto<List<GetUsersDTO>> response = null;
        //    try
        //    {
        //        List<GetUsersDTO> result = _moviesRepository.moviesByTitles(title);
        //        response = new CustomResponseDto<List<GetUsersDTO>>()
        //        {
        //            Content = result,
        //            IsSuccessful = true
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        response = new CustomResponseDto<List<GetUsersDTO>>
        //        {
        //            IsSuccessful = false,
        //            Message = "ERROR INESPERADO"
        //        };
        //        var st = new System.Diagnostics.StackTrace();
        //        var sf = st.GetFrame(1);
        //        _logger.LogError(ex, this.GetType().Name + "-" +
        //                                sf.GetMethod().Name + ": " +
        //                                ex.Message + " Detail: " +
        //                                ex.StackTrace);
        //    }
        //    return response;
        //}

        //public CustomResponseDto<List<GetUsersDTO>> GetMovies()
        //{
        //    CustomResponseDto<List<GetUsersDTO>> response = null;
        //    try
        //    {
        //        List<GetUsersDTO> result = _moviesRepository.GetMovies();
        //        response = new CustomResponseDto<List<GetUsersDTO>>()
        //        {
        //            Content = result,
        //            IsSuccessful = true
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        response = new CustomResponseDto<List<GetUsersDTO>>
        //        {
        //            IsSuccessful = false,
        //            Message = "ERROR INESPERADO"
        //        };
        //        var st = new System.Diagnostics.StackTrace();
        //        var sf = st.GetFrame(1);
        //        _logger.LogError(ex, this.GetType().Name + "-" +
        //                                sf.GetMethod().Name + ": " +
        //                                ex.Message + " Detail: " +
        //                                ex.StackTrace);
        //    }
        //    return response;


        //}
    }
}
