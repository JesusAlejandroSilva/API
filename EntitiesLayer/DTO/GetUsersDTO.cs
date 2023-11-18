using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public class GetUsersDTO
    {
        public int Id_Users { get; set; }

        public string UserName { get; set; }

        public string Pass { get; set; }

        public DateTime Creation_date { get; set; }

        public string Id_Number { get; set; }

    }
}
