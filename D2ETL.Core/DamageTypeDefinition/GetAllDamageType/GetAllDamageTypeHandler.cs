using MediatR;

namespace D2ETL.Core.DamageTypeDefinition.GetAllDamageType;

public class GetAllDamageTypeHandler : IRequestHandler<GetAllDamageTypeQuery, List<DamageTypeResponse>>
{
    private readonly IDamageTypeRepository _damageTypeRepository;

    public GetAllDamageTypeHandler(IDamageTypeRepository damageTypeRepository)
    {
        _damageTypeRepository = damageTypeRepository;
    }

    public async Task<List<DamageTypeResponse>> Handle(GetAllDamageTypeQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _damageTypeRepository.GetAll();
        var damageTypeResponses = new List<DamageTypeResponse>();
        foreach (var entity in entityList)
        {
            damageTypeResponses.Add(new DamageTypeResponse(
                entity.Id, 
                entity.Name!, 
                entity.Description!, 
                entity.Icon!, 
                entity.Red, 
                entity.Green, 
                entity.Blue, 
                entity.Alpha));
        }
        return damageTypeResponses;
    }
}