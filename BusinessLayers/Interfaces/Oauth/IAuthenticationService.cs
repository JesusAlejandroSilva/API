using EntitiesLayer.Entities;
using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntitiesLayer.DTO.CustomResponseDto<T>;

namespace BusinessLayers.Interfaces.Oauth
{
    public interface IAuthenticationService
    {
        ResponseResult<TokenJwt> AuthLogin(UserRequestLogin user);
        ResponseResult<string> ResetPassword(ResetPasswordModel resetPassword);
        ResponseResult<string> ForgotPassword(ForgotPasswordModel forgotPassword);
        ResponseResult<TokenResponseModel> RefreshToken(TokenRequest refreshToken, string token);
        ResponseResult<bool> Logout(UserRequestLogin tokenRequest, string token);
        ResponseResult<string> ChangePassword(ChangePasswordModel changePassword, string token);

    }
}
