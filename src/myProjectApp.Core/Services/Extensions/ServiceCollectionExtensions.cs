using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myProjectApp.Core.Config;
using myProjectApp.Core.Config.Extensions;
using myProjectApp.Core.Data;

using Microsoft.EntityFrameworkCore;


namespace myProjectApp.Core.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(
            this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddSingleton<AppConfig>(
                configuration.ReadAppConfiguration());

            // AddScoped
            @this.AddDbContext<ΜyBDContext>(
                (serviceProvider, optionsBuilder) => {
                    var appConfig = serviceProvider.GetRequiredService<AppConfig>();

                    optionsBuilder.UseSqlServer(appConfig.ConnectionString);
                });

            @this.AddScoped<ICustomerService, CustomerService>();
        }

    }
}
