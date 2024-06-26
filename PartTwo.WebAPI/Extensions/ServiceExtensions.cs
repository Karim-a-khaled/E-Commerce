﻿using PartTwo.Entities.Entities;
using PartTwo.Services.Interfaces;
using PartTwo.Services.Services;

namespace PartTwo.WebAPI.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

        return services; 
    }
}