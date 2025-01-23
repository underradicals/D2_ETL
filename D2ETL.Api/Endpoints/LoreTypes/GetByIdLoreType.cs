using D2ETL.Core.LoreTypeDefinition;
using MediatR;

namespace D2ETL.Api.Endpoints.LoreTypes;

public static class GetByIdLoreType
{
    public static WebApplication UseGetByIdLoreType(this WebApplication app)
    {
        app.MapGet("/lore_type/{id:long}", GetById);
        return app;
    }

    static async Task<LoreTypeResponse> GetById(IMediator mediator, long id)
    {
        var result = await mediator.Send(new LoreTypeGetByIdQuery(id));
        return result;
    }
}