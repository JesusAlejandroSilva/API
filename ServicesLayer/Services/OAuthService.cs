using EntitiesLayer.Entities;
using EntitiesLayer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServicesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helpers;
using Utilities.Interfaces;
using static EntitiesLayer.DTO.CustomResponseDto<T>;

namespace ServicesLayer.Services
{
    public class OAuthService : IOAuthServices
    {
        #region Autenticación con OAuth
        private readonly IWebRequestApi webRequestApi;
        private readonly string OAuthUrl;
        public OAuthService(IWebRequestApi webRequestApi, IConfiguration configuration)
        {
            this.webRequestApi = webRequestApi;
            OAuthUrl = configuration.GetSection(Constants.OAUTH).GetSection(Constants.URL_BASE).Value;
        }
        public ResponseResult<TokenJwt> AuthLogin(UserRequestLogin user)
        {

            user.Password = user.Password;
            if (user.Password != "")
            {
                string result = webRequestApi.CallService(OAuthUrl, "token", "AuthLogin", user, Utilities.WebRequestApi.EWebRequestApi.POST);
                ResponseResult<TokenJwt> userResponse = JsonConvert.DeserializeObject<ResponseResult<TokenJwt>>(result);
                ResponseResult<TokenJwt> response = new ResponseResult<TokenJwt>()
                {
                    IsSuccessful = (userResponse != null) ? userResponse.IsSuccessful : false,
                    Message = (userResponse == null) ? "Servicio de autenticación no disponible" : userResponse.Message ?? "",
                    Result = (userResponse ?? new ResponseResult<TokenJwt>()).Result
                };
                return response;
            }
            else
            {
                return null;
            }
        }

        public ResponseResult<string> ResetPassword(ResetPasswordModel resetPassword)
        {
            resetPassword.Password = resetPassword.Password;
            string result = webRequestApi.CallService(OAuthUrl, "Account", "ResetPassword", resetPassword, Utilities.WebRequestApi.EWebRequestApi.POST);
            ResponseResult<string> userResponse = JsonConvert.DeserializeObject<ResponseResult<string>>(result);
            ResponseResult<string> response = new ResponseResult<string>()
            {
                IsSuccessful = (userResponse != null) ? userResponse.IsSuccessful : false,
                Message = (userResponse == null) ? "Servicio de autenticación no disponible" : userResponse.Message ?? "",
                Result = (userResponse ?? new ResponseResult<string>()).Result
            };
            return response;
        }

        public ResponseResult<string> ForgotPassword(ForgotPasswordModel forgotPassword)
        {

            string result = webRequestApi.CallService(OAuthUrl, "Account", "ForgotPassword", forgotPassword, Utilities.WebRequestApi.EWebRequestApi.POST);
            ResponseResult<string> userResponse = JsonConvert.DeserializeObject<ResponseResult<string>>(result);
            ResponseResult<string> response = new ResponseResult<string>()
            {
                IsSuccessful = (userResponse != null) ? userResponse.IsSuccessful : false,
                Message = (userResponse == null) ? "Servicio de autenticación no disponible" : userResponse.Message ?? "",
                Result = (userResponse ?? new ResponseResult<string>()).Result
            };
            return response;
        }

        public ResponseResult<TokenResponseModel> RefreshToken(TokenRequest refreshToken, string token)
        {
            string result = webRequestApi.CallService(OAuthUrl, "token", "RefreshToken", refreshToken, Utilities.WebRequestApi.EWebRequestApi.POST, token);
            ResponseResult<TokenResponseModel> userResponse = JsonConvert.DeserializeObject<ResponseResult<TokenResponseModel>>(result);
            ResponseResult<TokenResponseModel> response = new ResponseResult<TokenResponseModel>()
            {
                IsSuccessful = (userResponse != null) ? userResponse.IsSuccessful : false,
                Message = (userResponse == null) ? "Servicio de autenticación no disponible" : userResponse.Message ?? "",
                Result = (userResponse ?? new ResponseResult<TokenResponseModel>()).Result
            };

            return response;
        }

        public ResponseResult<bool> Logout(UserRequestLogin tokenRequest, string token)
        {
            string result = webRequestApi.CallService(OAuthUrl, "token", "Logout", tokenRequest, Utilities.WebRequestApi.EWebRequestApi.POST, token);
            ResponseResult<bool> userResponse = JsonConvert.DeserializeObject<ResponseResult<bool>>(result);
            ResponseResult<bool> response = new ResponseResult<bool>()
            {
                IsSuccessful = (userResponse != null) ? userResponse.IsSuccessful : false,
                Message = (userResponse == null) ? "Servicio de autenticación no disponible" : userResponse.Message ?? "",
                Result = (userResponse ?? new ResponseResult<bool>()).Result
            };
            return response;
        }

        public ResponseResult<string> ChangePassword(ChangePasswordModel changePassword, string token)
        {
            string result = webRequestApi.CallService(OAuthUrl, "Account", "ChangePasswordCurrentUser", changePassword, Utilities.WebRequestApi.EWebRequestApi.POST, token);
            ResponseResult<string> userResponse = JsonConvert.DeserializeObject<ResponseResult<string>>(result);
            ResponseResult<string> response = new ResponseResult<string>()
            {
                IsSuccessful = (userResponse != null) ? userResponse.IsSuccessful : false,
                Message = (userResponse == null) ? "Servicio de autenticación no disponible" : userResponse.Message ?? "",
                Result = (userResponse ?? new ResponseResult<string>()).Result
            };
            return response;
        }

        #endregion

    }
}