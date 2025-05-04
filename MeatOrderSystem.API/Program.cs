using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MeatOrderSystem.Data.Context;
using MeatOrderSystem.Data.Interfaces;
using MeatOrderSystem.Data.Repositories;
using MeatOrderSystem.Service.Interfaces;
using MeatOrderSystem.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IMeatRepository, MeatRepository>();
builder.Services.AddScoped<IMeatService, MeatService>();
builder.Services.AddScoped<IMeatOriginRepository, MeatOriginRepository>();
builder.Services.AddScoped<IMeatOriginService, MeatOriginService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddHttpClient<ICurrencyConverterService, CurrencyConverterService>();
builder.Services
    .AddControllers()
    .AddApplicationPart(Assembly.Load("MeatOrderSystem.Controller"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();
