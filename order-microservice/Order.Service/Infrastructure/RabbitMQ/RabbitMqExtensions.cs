using Order.Service.Infrastructure.EventBus.Abstractions;
using Order.Service.Infrastructure.RabbitMq;

namespace Order.Service.Infrastructure.RabbitMQ;

public static class RabbitMqExtensions
{
    public static void AddRabbitMqEventBus(this IServiceCollection services)
    {
        services.AddSingleton<IRabbitMqConnection>(new RabbitMqConnection());
        services.AddScoped<IEventBus, RabbitMqEventBus>();
    }
}