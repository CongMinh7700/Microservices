﻿using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Product.API.Extensions;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Persistence;
using Repositories;
using Repositories.Interfaces;
// Trợ cho program file
public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureProductDbContext(configuration);
        services.AddIfractructureServices();
        services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));

        return services;
    }

    private static IServiceCollection ConfigureProductDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        var builder = new MySqlConnectionStringBuilder(connectionString + "");

        services.AddDbContext<ProductContext>(p => p.UseMySql(builder.ConnectionString,
            ServerVersion.AutoDetect(builder.ConnectionString), c =>
            {
                c.MigrationsAssembly("Product.API");
                c.SchemaBehavior(MySqlSchemaBehavior.Ignore);
            }));

        return services;
    }

    private static IServiceCollection AddIfractructureServices(this IServiceCollection services)
    {
        return services.AddScoped(typeof(IRepositoryBaseAsync<,,>), typeof(RepositoryBaseAsync<,,>))
                       .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
                       .AddScoped<IProductRepository, ProductRepository>();
    }
}

