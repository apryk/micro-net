using ECommerce.Shared.Infrastructure.RabbitMq;
using ECommerce.Shared.Observability;
using Order.Service.Endpoints;
using Order.Service.Infrastructure.Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServerDatastore(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRabbitMqEventBus(builder.Configuration)
    .AddRabbitMqEventPublisher();

builder.Services.AddOpenTelemetryTracing("Order", builder.Configuration, (traceBuilder) => 
        traceBuilder.WithSqlInstrumentation())
    .AddOpenTelemetryMetrics();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(); 

if (app.Environment.IsDevelopment())
{
    app.MigrateDatabase();
}

app.RegisterEndpoints();

app.UseHttpsRedirection();

app.Run();

public partial class Program { }