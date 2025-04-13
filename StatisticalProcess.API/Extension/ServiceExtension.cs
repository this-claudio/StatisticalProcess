using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalProcess.Application;
using StatisticalProcess.Application.Utils.Contracts;
using StatisticalProcess.Application.Utils.Dictionaries;
using StatisticalProcess.Infrastructure.EntityFramework.Context;
using StatisticalProcess.Infrastructure.EntityFramework.Repository;
using StatisticProcess.Domain.Interfaces;

namespace StatisticalProcess.API.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureService(this IServiceCollection service, IConfiguration configuration, ILogger logger)
        {

            service.AddControllers();
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();

            service.AddScoped<IMeasurementDataRepository, MeasurementDataRepository>();
            service.AddSingleton<ILimitsCoefficient, LimitsCoefficient>();

            service.AddMediatR(typeof(IApplicationMark).Assembly);


            service.AddDbContext<EFContext>(options =>
                options.UseSqlServer(DbConnectionHelper.MakeConnection(logger)));

            service.AddAutoMapper(typeof(IApplicationMark).Assembly);

            service.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return service;
        }
    }
}
