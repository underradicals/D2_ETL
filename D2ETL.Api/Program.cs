using D2ETL.Core;
using D2ETL.Core.DamageTypeDefinition.GetAllDamageType;
using D2ETL.Core.DamageTypeDefinition.GetDamageTypeById;
using D2ETL.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

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

app.Run();
