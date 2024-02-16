using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZefixTest.Interfaces.Handlers
{
    public interface IZefixCompanyHandler
    {
        Task<HttpResponseMessage> GetByChid(string chid);
    }
}
