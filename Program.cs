using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MoodSwings.Services;
using MoodSwings.Shared.ViewModels;
using MoodSwings.Shared.Store;
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
            builder.Services.AddSingleton<SelectCategoryViewModel>();
            builder.Services.AddSingleton<AppState>();
            builder.Services.AddStorage();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
