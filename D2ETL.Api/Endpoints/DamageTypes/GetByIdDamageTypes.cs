using D2ETL.Core.DamageTypeDefinition;
using D2ETL.Core.DamageTypeDefinition.GetDamageTypeById;
using MediatR;

namespace D2ETL.Api.Endpoints.DamageTypes;

public static class GetByIdDamageTypes
{
    public static WebApplication UseByIdDamageTypeRoutes(this WebApplication app)
    {
        app.MapGet("/damage_type/{id:long}", GetAll);

        return app;
    }
    
    static async Task<DamageTypeResponse> GetAll(IMediator mediator, long id)
    {
        var response = await mediator.Send(new DamageTypeByIdQuery(id));
        return response;
    }
}