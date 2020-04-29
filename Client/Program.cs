using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorIdiomas.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            ConfigureService(builder.Services);
            builder.Services.AddBaseAddressHttpClient();

            await builder.Build().RunAsync();
        }

        public static void ConfigureService(IServiceCollection services)
        {
            services.AddOptions();
            services.AddI18nText(options =>
            options.PersistanceLevel = Toolbelt.Blazor.I18nText.PersistanceLevel.SessionAndLocal);
        }
    }
}
