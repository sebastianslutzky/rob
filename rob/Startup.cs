using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components.Builder;
using Blazor.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using rob.Services;

[assembly: InternalsVisibleTo("rob.representations.tests")]
namespace rob
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Api,Api>();
            services.AddSingleton<ApacheIsisApi,ApacheIsisApi>();
            services.AddSingleton<MissingApi,MissingApi>();
            services.AddSingleton<ObjectLoadedPublisherService,ObjectLoadedPublisherService>();
            services.AddSingleton<ActionInvocationService,ActionInvocationService>();
            services.AddLogging(builder => builder.AddBrowserConsole().SetMinimumLevel(LogLevel.None));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
