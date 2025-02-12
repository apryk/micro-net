﻿using ECommerce.Shared.Infrastructure.RabbitMq;
using ECommerce.Shared.Observability.Metrics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Shared.Observability;
public static class OpenTelemetryStartupExtensions
{
    public static OpenTelemetryBuilder AddOpenTelemetryTracing(this IServiceCollection services, 
        string serviceName, IConfigurationManager configuration, 
        Action<TracerProviderBuilder>? customTracing = null)
    {
        var openTelemetryOptions = new OpenTelemetryOptions();
        configuration.GetSection(OpenTelemetryOptions.OpenTelemetrySectionName).Bind(openTelemetryOptions);

        return services.AddOpenTelemetry()
            .ConfigureResource(r => r.AddService(serviceName))
            .WithTracing(builder =>
            {
                builder
                    .AddConsoleExporter()
                    .AddAspNetCoreInstrumentation()
                    .AddSource(RabbitMqTelemetry.ActivitySourceName)
                    .AddOtlpExporter(options => options.Endpoint = 
                        new Uri(openTelemetryOptions.OtlpExporterEndpoint));

                customTracing?.Invoke(builder);
            });
    }


    public static OpenTelemetryBuilder AddOpenTelemetryMetrics(this OpenTelemetryBuilder openTelemetryBuilder, 
        string serviceName, IServiceCollection services, Action<MeterProviderBuilder>? customMetrics = null)
    {
        services.AddSingleton(new MetricFactory(serviceName));
        
        return openTelemetryBuilder
            .WithMetrics(builder =>
            {
                builder
                    .AddConsoleExporter()
                    .AddAspNetCoreInstrumentation()
                    .AddMeter(serviceName);
                    
                customMetrics?.Invoke(builder);
            });
    }

    public static TracerProviderBuilder WithSqlInstrumentation(this TracerProviderBuilder builder) => 
        builder.AddSqlClientInstrumentation();
}