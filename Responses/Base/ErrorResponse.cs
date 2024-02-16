using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZefixTest.Responses.Base
{
    public class ErrorResponse : AbstractResponse
    {
        public string Message { get; set; }
    }
}
