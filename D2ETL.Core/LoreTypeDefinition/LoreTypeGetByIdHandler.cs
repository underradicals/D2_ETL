using MediatR;

namespace D2ETL.Core.LoreTypeDefinition;

public class LoreTypeGetByIdHandler : IRequestHandler<LoreTypeGetByIdQuery, LoreTypeResponse>
{
    private readonly ILoreTypeRepository _repsitory;

    public LoreTypeGetByIdHandler(ILoreTypeRepository repsitory)
    {
        _repsitory = repsitory;
    }

    public async Task<LoreTypeResponse> Handle(LoreTypeGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repsitory.GetById(request.Id);
        var response = new LoreTypeResponse
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description,
            Subtitle = result.Subtitle,
        };
        return response;
    }
}