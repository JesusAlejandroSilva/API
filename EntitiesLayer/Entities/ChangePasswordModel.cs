using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class ChangePasswordModel
    {
        public string User { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
