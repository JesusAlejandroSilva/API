using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Models
{
    public class TokenRequest
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
    public class TokenResponseModel
    {
        public string token { get; set; }//jwt token
        public DateTime expiration { get; set; } // expiry time
        public string refresh_token { get; set; }// refresh token
        public string username { get; set; }// user name
        public string sex { get; set; }
        public bool is_internal { get; set; }
        public bool active_status { get; set; }
    }

}
