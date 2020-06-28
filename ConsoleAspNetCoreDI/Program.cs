using ConsoleAspNetCoreDI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConsoleAspNetCoreDI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddHttpClient("anime", c =>
            {
                c.BaseAddress = new Uri("https://akiba-souken.com/anime/");
            });
            services.AddLogging(l =>
            {
                l.AddConsole();
            });
            services.AddSingleton<IScrapingService, ScrapingService>();

            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                            .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            var scraper = serviceProvider.GetService<IScrapingService>();
            var html = await scraper.GetHtmlString();

            logger.LogDebug("All done!");
        }
    }
}
