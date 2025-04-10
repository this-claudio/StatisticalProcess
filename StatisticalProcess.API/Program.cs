using Microsoft.EntityFrameworkCore;
using StatisticalProcess.Infrastructure.EntityFramework.Context;
using StatisticalProcess.Infrastructure.EntityFramework.Repository;
using StatisticProcess.Domain.Interfaces;
using StatisticProcess.Domain.Constant;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StatisticalProcess.Application;
using StatisticalProcess.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMeasurementDataRepository, MeasurementDataRepository>();

builder.Services.AddMediatR(typeof(IApplicationMark).Assembly);

var connectionString = builder.Configuration.GetConnectionString(Configuration.CONNECTION);

builder.Services.AddDbContext<EFContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EFContext>();

    var pendingMigrations = dbContext.Database.GetPendingMigrations();

    if (pendingMigrations.Any())
    {
        dbContext.Database.Migrate();
        Console.WriteLine($"Pending Migration Executed: {string.Join(", ", pendingMigrations)}");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
