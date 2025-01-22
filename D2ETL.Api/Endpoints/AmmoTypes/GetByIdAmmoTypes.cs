using D2ETL.Core.AmmoTypeDefinition;
using MediatR;

namespace D2ETL.Api.Endpoints.AmmoTypes;

public static class GetByIdAmmoTypes
{
    public static WebApplication UseByIdAmmoTypeRoutes(this WebApplication app)
    {
        app.MapGet("/ammo_type/{id:long}", GetById);

        return app;
    }
    
    static async Task<AmmoTypeResponse> GetById(IMediator mediator, long id)
    {
        var response = await mediator.Send(new GetByIdAmmoTypeQuery(id));
        return response;
    }
}