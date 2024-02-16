using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ZefixTest.Interfaces.Handlers
{
    internal interface IZefixProviderHandler
    {
        Task<HttpResponseMessage> GetAsync(string path, CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> PostAsync(string path, HttpContent content, CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> PutAsync(string path, HttpContent content, CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> DeleteAsync(string path, CancellationToken cancellationToken = default);
    }
}
