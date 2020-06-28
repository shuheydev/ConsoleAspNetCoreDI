using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAspNetCoreDI.Services
{
    public interface IScrapingService
    {
        public Task<string> GetHtmlString();
    }
}
