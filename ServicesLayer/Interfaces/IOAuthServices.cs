using EntitiesLayer.DTO;
using EntitiesLayer.Entities;
using EntitiesLayer.Models;
using static EntitiesLayer.DTO.CustomResponseDto<T>;

namespace ServicesLayer.Interfaces
{
    public interface IOAuthServices
    {
        ResponseResult<TokenJwt> AuthLogin(UserRequestLogin user);
        ResponseResult<string> ResetPassword(ResetPasswordModel resetPassword);
        ResponseResult<string> ForgotPassword(ForgotPasswordModel forgotPassword);
        ResponseResult<TokenResponseModel> RefreshToken(TokenRequest refreshToken, string token);
        ResponseResult<bool> Logout(UserRequestLogin tokenRequest, string token);
        ResponseResult<string> ChangePassword(ChangePasswordModel changePassword, string token);
    }
}
