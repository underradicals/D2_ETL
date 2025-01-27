using D2ETL.Core;
using D2ETL.Infrastructure;
using Serilog;
using static Microsoft.Net.Http.Headers.HeaderNames;

namespace D2ETL.Api;

public static class D2ETLApplication
{
    public static WebApplicationBuilder CreateBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "DefaultPolicy",
                policy => policy.AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                    .WithHeaders(ContentType, "application/json")
                    .AllowAnyHeader());
        });
        
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApplicationServices();
        
        return builder;
    }

    public static WebApplication Build(WebApplicationBuilder builder)
    {
        var app = builder.Build();
        
        app.UseCors("DefaultPolicy");

        app.UseApplicationApi();

        return app;
    }
}