using D2ETL.Core.AmmoTypeDefinition;
using MediatR;

namespace D2ETL.Api.Endpoints.AmmoTypes;

public static class GetAllAmmoTypes
{
    public static WebApplication UseAllAmmoTypeRoutes(this WebApplication app)
    {
        app.MapGet("/ammo_type", GetAll);

        return app;
    }
    
    static async Task<List<AmmoTypeResponse>> GetAll(IMediator mediator)
    {
        var response = await mediator.Send(new GetAllAmmoTypeQuery());
        return response;
    }
}