using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class ExceptionModel: Exception
    {
        public ExceptionModel(string message) : base(message) { }
        public Dictionary<string, List<string>> Errors { get; set; }
    }

    public class RedisException : Exception
    {
        public RedisException(string message) : base(message) { }
    }
}
