using D2ETL.Core;
using D2ETL.Core.DamageTypeDefinition;
using D2ETL.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2ETL.Infrastructure;

public static class ServiceCollectionPipeline
{
    private const string Environment = "EFCore";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        if (Environment == "Dapper")
        {
            services.AddTransient<IDamageTypeRepository, DamageTypeRepository>();
            services.AddTransient<ISQLiteConnectionFactory, SQLiteConnectionFactory>();
        }
        else
        {
            services.AddTransient<IDamageTypeRepository, DamageTypeEFRepository>();
            services.AddDbContext<ApplicationSqliteContext>(options =>
            {
                options.UseSqlite(configuration["ConnectionStrings:SQLiteConnection"])
                    .EnableSensitiveDataLogging(true)
                    .EnableDetailedErrors(true);
            });    
        }
        
        return services;
    }
}