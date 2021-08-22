using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.OpenApi.Models;
using TollCalculator.API.Builders;
using TollCalculator.API.Context;
using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;
using TollCalculator.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TollCalculator.API", Version = "v1" });
});
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IRepository<VehicleType>, SQLiteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TollCalculator.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
