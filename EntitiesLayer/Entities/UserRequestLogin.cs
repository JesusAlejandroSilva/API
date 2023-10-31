using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class UserRequestLogin
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public class UserAuthResponseDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public TokenJwt AuthToken { get; set; }
    }
    public class ResetPasswordModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string TokenCaptcha { get; set; }

    }

    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string token { get; set; }

    }
}