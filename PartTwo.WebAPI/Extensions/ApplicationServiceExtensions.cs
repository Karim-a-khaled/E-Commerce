using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartTwo.Data;
using PartTwo.WebAPI.Errors;
using PartTwo.WebAPI.Middleware;

namespace PartTwo.WebAPI.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<StoreContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        services.AddControllers();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(errorResponse);
            };
        });

        return services;
    }

    public static IApplicationBuilder AddUsings(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthorization();

        return app;
    }
}