using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using ZefixTest.Interfaces.Handlers;

namespace ZefixTest.Handlers
{
    public class ZefixProviderHandler : IZefixProviderHandler
    {
        public HttpClient _httpClient;

        public string _baseUrl;

        public string _username;

        public string _password;

        public ZefixProviderHandler(
            HttpClient httpClient, 
            IConfiguration configuration
        ) {
            _httpClient = httpClient;
            _baseUrl = $"{configuration["Providers:Zefix:baseUrl"]}";
            _username = $"{configuration["Providers:Zefix:username"]}";
            _password = $"{configuration["Providers:Zefix:password"]}";
        }

        public async Task<HttpResponseMessage> GetAsync(string path, CancellationToken cancellationToken = default)
        {
            string auth = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_username}:{_password}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            return cancellationToken.Equals(default) ?
                await _httpClient.GetAsync($"{_baseUrl}{path}") :
                await _httpClient.GetAsync($"{_baseUrl}{path}", cancellationToken);
        }

        public async Task<HttpResponseMessage> PostAsync(string path, HttpContent content, CancellationToken cancellationToken = default)
        {
            string auth = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_username}:{_password}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            return cancellationToken.Equals(default) ?
                await _httpClient.PostAsync($"{_baseUrl}{path}", content) :
                await _httpClient.PostAsync($"{_baseUrl}{path}", content, cancellationToken);
        }

        public async Task<HttpResponseMessage> PutAsync(string path, HttpContent content, CancellationToken cancellationToken = default)
        {
            string auth = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_username}:{_password}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            return cancellationToken.Equals(default) ?
                await _httpClient.PutAsync($"{_baseUrl}{path}", content) :
                await _httpClient.PutAsync($"{_baseUrl}{path}", content, cancellationToken);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string path, CancellationToken cancellationToken = default)
        {
            string auth = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_username}:{_password}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            return cancellationToken.Equals(default) ?
                await _httpClient.DeleteAsync($"{_baseUrl}{path}") :
                await _httpClient.DeleteAsync($"{_baseUrl}{path}", cancellationToken);
        }
    }
}
