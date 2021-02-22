using Microsoft.Extensions.Configuration;

namespace myProjectApp.Core.Config.Extensions
{
    public static class ConfigurationExtensions
    {
        public static AppConfig ReadAppConfiguration(
            this IConfiguration @this)
        {
            var minLoggingLevel = @this.GetSection("MinLoggingLevel").Value;
            var connectionString = @this.GetConnectionString("myDatabase");

            return new AppConfig()
            {
                ConnectionString = connectionString,
                MinLoggingLevel = minLoggingLevel
            };
        }
    }
}
