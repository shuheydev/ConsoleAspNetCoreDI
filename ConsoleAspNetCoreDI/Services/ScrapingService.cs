using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAspNetCoreDI.Services
{
    public class ScrapingService : IScrapingService
    {
        private readonly HttpClient _httpClient;
        public ScrapingService(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient("anime");
        }

        public async Task<string> GetHtmlString()
        {
            var response = await _httpClient.GetAsync("summer");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
