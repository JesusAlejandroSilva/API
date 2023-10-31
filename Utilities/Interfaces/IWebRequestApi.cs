using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.WebRequestApi;

namespace Utilities.Interfaces
{
    public interface IWebRequestApi
    {
        string CallService(string urlBase, string controller, string methodName, object body, EWebRequestApi method, string token = null);

    }
}
