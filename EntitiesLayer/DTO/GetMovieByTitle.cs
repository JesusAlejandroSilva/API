using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public class GetMovieByTitle
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime launch_date { get; set; }
        public string score { get; set; }

    }
}
