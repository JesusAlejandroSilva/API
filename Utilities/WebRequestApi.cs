using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace Utilities
{
    public class WebRequestApi: IWebRequestApi
    {
        private readonly ILogger<WebRequestApi> _logger;

        public WebRequestApi(ILogger<WebRequestApi> logger)
        {
            _logger = logger;
        }

        public enum EWebRequestApi
        {
            POST = 1,
            GET = 2,
            PUT = 3

        }

        public string CallService(string urlBase, string controller, string methodName, object body, EWebRequestApi method, string token = null)
        {
            urlBase += (urlBase.EndsWith("/")) ? "" : "/";
            string url = $"{urlBase}{controller}/{methodName}";
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = method.ToString();
            webRequest.ContentType = "application/json";
            WebResponse response = null;

            try
            {

                if (token != null)
                {
                    webRequest.Headers.Add("Authorization", token);
                }

                string bodyJson = (body == null) ? "" : JsonConvert.SerializeObject(body);
                if (bodyJson != "")
                {
                    Stream requestStream = webRequest.GetRequestStream();
                    StreamWriter writerStream = new StreamWriter(requestStream);
                    writerStream.WriteLine(bodyJson);
                    writerStream.Close();
                }

                response = webRequest.GetResponse();

            }
            catch (WebException ex)
            {
                response = ex.Response;
                var st = new StackTrace();
                var sf = st.GetFrame(1);
                _logger.LogError(ex, this.GetType().Name + "-" +
                                        sf.GetMethod().Name + ": " +
                                        ex.Message + " Detail: " +
                                        ex.StackTrace);
            }
            if (response == null)
            {
                return "";
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            return result;
        }

      

      
    }
}
