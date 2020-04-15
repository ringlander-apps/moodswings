using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MoodSwings.Services;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace MoodSwings
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddSingleton<ConfigurationService>();
            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddSingleton<SpotifyService>();
            builder.Services.AddStorage();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
