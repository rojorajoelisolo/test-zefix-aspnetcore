using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ZefixTest.Interfaces.Handlers;

namespace ZefixTest.Handlers
{
    public class ZefixCompanyHandler : ZefixProviderHandler, IZefixCompanyHandler
    {
        public ZefixCompanyHandler(HttpClient client, IConfiguration configuration) : base(client, configuration) { }

        public async Task<HttpResponseMessage> GetByChid(string chid)
        {
            return await GetAsync($"/api/v1/company/chid/{chid}");
        }
    }
}
