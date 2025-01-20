using MediatR;

namespace D2ETL.Core.DamageTypeDefinition.GetDamageTypeById;

public class DamageTypeByIdHandler : IRequestHandler<DamageTypeByIdQuery, DamageTypeResponse>
{
    private readonly IDamageTypeRepository _damageTypeRepository;

    public DamageTypeByIdHandler(IDamageTypeRepository damageTypeRepository)
    {
        _damageTypeRepository = damageTypeRepository;
    }

    public async Task<DamageTypeResponse> Handle(DamageTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _damageTypeRepository.GetById(request.Id);
        return DamageTypeResponse.From(entity.Id, entity.Name!, entity.Description!, entity.Icon!, entity.Red, entity.Green, entity.Blue, entity.Alpha);
    }
}