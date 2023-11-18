using EntitiesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayers.Interfaces
{
    public interface IUsersServices
    {
        CustomResponseDto<List<GetUsersDTO>> Login(string userName, string Pass);
    }
}
