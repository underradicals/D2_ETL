namespace D2ETL.Core.DamageTypeDefinition.GetDamageTypeById;

public class DamageTypeByIdQuery : IQuery<DamageTypeResponse>
{
    public long Id { get; set; }

    public DamageTypeByIdQuery(long id)
    {
        Id = id;
    }
}