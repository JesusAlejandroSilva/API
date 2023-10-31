using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public class GetStatusCreate
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public GetStatusCreate()
        {
            Message = "";
            IsSuccessful = true;
        }
    }
}
