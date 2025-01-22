using MediatR;

namespace D2ETL.Core.AmmoTypeDefinition;

public class GetByIdAmmoTypeQueryHandler : IRequestHandler<GetByIdAmmoTypeQuery, AmmoTypeResponse>
{
    private readonly IAmmoTypeRepository _repository;

    public GetByIdAmmoTypeQueryHandler(IAmmoTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<AmmoTypeResponse> Handle(GetByIdAmmoTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAmmoTypeById(request.Id);
        if (result == null) return new AmmoTypeResponse();
        return new AmmoTypeResponse
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description,
            Icon = result.Icon,
        };
    }
}