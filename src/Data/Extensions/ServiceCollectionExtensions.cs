using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddDbContext<EnergyDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
