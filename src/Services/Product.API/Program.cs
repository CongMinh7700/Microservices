using Common.Logging;
using Product.API.Extensions;
using Product.API.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Information("Start Product API up");

// Add services to the container.
try
{
    builder.Host.UseSerilog(SeriLogger.Configure);

    builder.Host.AddAppCongfigurations();
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();
    app.UserInfrastructure();
    app.MigrateDatabase<ProductContext>((context, _) =>
    {
        ProductContextSeed.SeedProductAsync(context, Log.Logger).Wait();
    });

    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostExtension", StringComparison.Ordinal)) throw;


    Log.Fatal(ex, $"Unhandled exception: {ex.Message}");
}
finally
{
    Log.Information("Shut down Product API complete");
    Log.CloseAndFlush();
}