using D2ETL.Core.DamageTypeDefinition;
using D2ETL.Core.DamageTypeDefinition.GetAllDamageType;
using D2ETL.Core.DamageTypeDefinition.GetDamageTypeById;
using MediatR;

namespace D2ETL.Api.Endpoints.DamageTypes;

public static class GetAllDamageTypes
{
    public static WebApplication UseAllDamageTypeRoutes(this WebApplication app)
    {
        app.MapGet("/damage_type", GetAll);

        return app;
    }
    
    static async Task<List<DamageTypeResponse>> GetAll(IMediator mediator)
    {
        var response = await mediator.Send(new GetAllDamageTypeQuery());
        return response;
    }
}