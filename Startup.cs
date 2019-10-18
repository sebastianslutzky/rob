using Microsoft.AspNetCore.Components.Builder;
using Blazor.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace rob
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Api,Api>();
            services.AddLogging(builder => builder.AddBrowserConsole().SetMinimumLevel(LogLevel.Trace));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
