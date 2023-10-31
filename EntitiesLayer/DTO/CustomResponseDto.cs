using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public class CustomResponseDto<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
        public int StatusCode { get; set; }
        public CustomResponseDto()
        {
            Message = "";
            IsSuccessful = true;
            StatusCode = (int)HttpStatusCode.OK;
        }


        public class ResponseResult<T>
        {
            public bool IsSuccessful { get; set; }
            public string Message { get; set; }
            public T Result { get; set; }
            public int StatusCode { get; set; }
            public ResponseResult()
            {
                Message = "";
                IsSuccessful = true;
                StatusCode = (int)HttpStatusCode.OK;
            }

            public static ResponseResult<IEnumerable<string>> CreateSuccessful(string[] vs)
            {
                ResponseResult<IEnumerable<string>> response = new ResponseResult<IEnumerable<string>>()
                {
                    Result = vs,
                    IsSuccessful = true,
                    Message = "isActive"
                };

                return response;
            }

        }
    }
}