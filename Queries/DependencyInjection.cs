﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Queries.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}