using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project.Shared;
using Project.Wazem.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Wazem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

           builder.Services.AddScoped<IServices<Category>, CategoryServices>();
            builder.Services.AddScoped<IServices<Product>, ProductServices>();

            //register httpclient & determine base provider address
            builder.Services.AddScoped(sp =>
                   new HttpClient { 
                      BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>()["ProviderWebApiIp"])
                  });

              await builder.Build().RunAsync();
        }
    }
}
