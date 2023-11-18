using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public class CreatePersonsDTO
    {
        public string Names { get; set; }

        public string LastNames { get; set; }

        public string Type_Ide { get; set; }

        public string Id_Number { get; set; }

        public string Email { get; set; }

        public DateTime Date_Creation { get; set; }
    }
}
