using D2ETL.Core;
using D2ETL.Core.DamageTypeDefinition;
using D2ETL.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2ETL.Infrastructure;

public static class ServiceCollectionPipeline
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDamageTypeRepository, DamageTypeRepository>();
        services.AddTransient<ISQLiteConnectionFactory, SQLiteConnectionFactory>();
        return services;
    }
}