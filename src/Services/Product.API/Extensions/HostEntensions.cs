﻿using Microsoft.EntityFrameworkCore;

namespace Product.API.Extensions;

// Trợ cho program file
public static class HostEntensions
{
    public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder)
  where TContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var configuration = services.GetRequiredService<IConfiguration>();
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();


            try
            {
                logger.LogInformation("Migrating mysql database");
                ExcuteMigrations(context);
                logger.LogInformation("Migrated mysql database");
                InvokeSeeder(seeder, context, services);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the mysql database");
            }
        }

        return host;
    }

    private static void ExcuteMigrations<TContext>(TContext context)
        where TContext : DbContext
    {
        context.Database.Migrate();
    }

    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
        where TContext : DbContext
    {
        seeder(context, services);
    }
}