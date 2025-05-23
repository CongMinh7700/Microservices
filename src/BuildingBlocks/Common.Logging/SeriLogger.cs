﻿using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.Logging;

public static class SeriLogger
{
    public static Action<HostBuilderContext, LoggerConfiguration> Configure => (context, configuation) =>
    {
        // Replace "," to "-"
        var applicationName = context.HostingEnvironment.ApplicationName?.ToLower().Replace(",", "-");
        var environmentName = context.HostingEnvironment.EnvironmentName ?? "Development";

        configuation
        .WriteTo.Debug()
        .WriteTo.Console(
            outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:l}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .Enrich.WithProperty("Environment", environmentName)
        .Enrich.WithProperty("Application", applicationName)
        .ReadFrom.Configuration(context.Configuration);
    };
}

