using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Servicos.Http
{
    public class AdopetApiClientFactory : IHttpClientFactory
    {
        private readonly string url;

        public AdopetApiClientFactory(string url)
        {
            this.url = url;
        }

        public HttpClient CreateClient(string name)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }
    }
}
