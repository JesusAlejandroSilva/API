using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class TokenJwt
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Refresh_Token { get; set; }
        public string Username { get; set; }
        public bool Is_Internal { get; set; }
        public bool Active_Status { get; set; }
    }
}
