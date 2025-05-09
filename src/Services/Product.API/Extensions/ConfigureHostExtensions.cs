namespace Product.API.Extensions;

public static class ConfigureHostExtensions
{
    public static void AddAppCongfigurations(this ConfigureHostBuilder host)
    {
        host.ConfigureAppConfiguration((context, config) =>
        {
            var env = context.HostingEnvironment;
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        });

        //public static void AddAppCongfigurations(this WebApplicationBuilder builder)
        //{
        //    var env = builder.Environment;
        //    builder.Configuration
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
        //        .AddEnvironmentVariables();
        //}
    }
}
