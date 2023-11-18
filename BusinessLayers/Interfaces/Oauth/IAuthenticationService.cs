using EntitiesLayer.DTO;
using EntitiesLayer.Entities;
using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayers.Interfaces.Oauth
{
    public interface IAuthenticationService
    {
        CustomResponseDto<TokenJwt> AuthLogin(UserRequestLogin user);
        CustomResponseDto<string> ResetPassword(ResetPasswordModel resetPassword);
        CustomResponseDto<string> ForgotPassword(ForgotPasswordModel forgotPassword);
        CustomResponseDto<TokenResponseModel> RefreshToken(TokenRequest refreshToken, string token);
        CustomResponseDto<bool> Logout(UserRequestLogin tokenRequest, string token);
        CustomResponseDto<string> ChangePassword(ChangePasswordModel changePassword, string token);

    }
}
