
using Application.Interfaces;
using Application.Service;
using Domain.Interfaces;
using Infrastructure.Date;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICompanieRepository, CompanieRepository>();
builder.Services.AddScoped<ICompanieService, CompanieService>();

builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();

builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

builder.Services.AddDbContext<Database>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseMiddleware<RequestLoggingMiddleware>();
app.Run();