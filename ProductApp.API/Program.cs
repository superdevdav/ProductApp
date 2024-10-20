using Microsoft.EntityFrameworkCore;
using ProductApp.Core.Abstractions;
using ProductApp.DataAccess;
using ProductApp.Application.Services;
using ProductApp.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

builder.Services.AddScoped<IProductsCategoriesService, ProductsCategoriesService>();
builder.Services.AddScoped<IProductsCategoriesRepository, ProductsCategoriesRepository>();


builder.Services.AddDbContext<ProductAppDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ProductAppDbContext)));
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
