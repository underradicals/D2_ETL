using D2ETL.Core;
using D2ETL.Core.AmmoTypeDefinition;
using D2ETL.Core.DamageTypeDefinition.GetAllDamageType;
using D2ETL.Core.DamageTypeDefinition.GetDamageTypeById;
using D2ETL.Infrastructure;
using MediatR;
using static Microsoft.Net.Http.Headers.HeaderNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "DefaultPolicy",
        policy => policy.AllowAnyOrigin()
            .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
            .WithHeaders(ContentType, "application/json")
            .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("DefaultPolicy");

app.MapGet("/damage_type", async (IMediator mediator) =>
{
    var response = await mediator.Send(new GetAllDamageTypeQuery());
    return response;
});

app.MapGet("/damage_type/{id:long}", async (IMediator mediator, long id) =>
{
    var response = await mediator.Send(new DamageTypeByIdQuery(id));
    return response;
});

app.MapGet("/ammo_type", async (IMediator mediator) =>
{
    var response = await mediator.Send(new GetAllAmmoTypeQuery());
    return response;
});

app.MapGet("/ammo_type/{id:long}", async (IMediator mediator, long id) =>
{
    var response = await mediator.Send(new GetByIdAmmoTypeQuery(id));
    return response;
});

app.Run();
