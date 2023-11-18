using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Models
{
    public partial class Persons
    {
        public int IdPersons { get; set; }

        public string Names { get; set; }

        public string LastNames { get; set; }

        public string Type_Ide { get; set; }

        public string Id_Number { get; set; }

        public string Email { get; set; }

        public DateTime Date_Creation { get; set; }

        public string FullName { get; set; }

        public string FullIdent { get; set; }
    }
}
