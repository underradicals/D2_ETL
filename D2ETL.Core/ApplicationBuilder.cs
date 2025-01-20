using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace D2ETL.Core;

public static class ApplicationBuilder
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}