using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZefixTest.Responses.Base
{
    public class BaseResponse<TBody> where TBody : AbstractResponse
    {
        public bool Success { get; set; }

        public TBody Data { get; set; }
    }
}
