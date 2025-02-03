using Order.Service.Infrastructure.EventBus.Abstractions;
using Order.Service.Infrastructure.RabbitMq;

namespace Order.Service.Infrastructure.RabbitMQ;

public static class RabbitMqExtensions
{
    public static void AddRabbitMqEventBus(this IServiceCollection services, IConfigurationManager configuration)
    {
        var rabbitMqOptions = new RabbitMqOptions();
        configuration.GetSection(RabbitMqOptions.RabbitMqSectionName).Bind(rabbitMqOptions);
        services.AddSingleton<IRabbitMqConnection>(new RabbitMqConnection(rabbitMqOptions));
        services.AddScoped<IEventBus, RabbitMqEventBus>();
    }
}