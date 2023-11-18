using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Models
{
    public partial class Users
    {
        public int Id_Users { get; set; }

        public string UserName { get; set; }

        public string Pass { get; set; }

        public DateTime Creation_date { get; set; }

        public int Persons_Id { get; set; } 


        public virtual ICollection<Persons> Persons { get; set; }
    }
}
