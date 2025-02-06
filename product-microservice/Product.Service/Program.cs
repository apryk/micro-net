using ECommerce.Shared.Infrastructure.RabbitMq;
// using Product.Service.Endpoints;
using Product.Service.Infrastructure.Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServerDatastore(builder.Configuration);

var app = builder.Build();


app.Run();
