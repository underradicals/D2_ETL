using D2ETL.Core.DamageTypeDefinition;
using D2ETL.Core.LoreTypeDefinition;
using D2ETL.Core.Models;
using MediatR;

namespace D2ETL.Api.Endpoints.LoreTypes;

public static class GetPagedLoreType
{
    public static WebApplication UseGetPagedLoreType(this WebApplication app)
    {
        app.MapGet("/lore_type", GetPage);
        return app;
    }

    static async Task<PaginatedResult<List<LoreTypeResponse>>> GetPage(IMediator mediator, int pageSize, int pageNumber)
    {
        var response = await mediator.Send(new LoreTypePaginatedQuery(pageSize, pageNumber));
        return response;
    }
}