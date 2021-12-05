using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Api.Brokers.Loggings;
using Brasileirao.Api.Brokers.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Brasileirao.Api.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureCors(this IServiceCollection services) =>
        services
            .AddCors(options =>
            {
              options
                      .AddPolicy("CorsPolicy",
                      builder =>
                          builder
                              .AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());
            });

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddScoped<ILoggingBroker, LoggingBroker>();

    public static void ConfigureRepositories(this IServiceCollection services) =>
        services.AddScoped<ITimeRepository, TimeRepository>();
  }
}
