using MediatR;

namespace D2ETL.Core.AmmoTypeDefinition;

public class GetAllAmmoTypeQueryHandler : IRequestHandler<GetAllAmmoTypeQuery, List<AmmoTypeResponse>>
{
    private readonly IAmmoTypeRepository _repository;

    public GetAllAmmoTypeQueryHandler(IAmmoTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AmmoTypeResponse>> Handle(GetAllAmmoTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAmmoTypes();
        if (result.Count == 0)
        {
            return [];
        }
        
        return result.Select(x => new AmmoTypeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Icon = x.Icon,
        }).ToList();
    }
}