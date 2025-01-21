namespace D2ETL.Core.AmmoTypeDefinition;

public class GetByIdAmmoTypeQuery : IQuery<AmmoTypeResponse>
{
    public long Id { get; set; }

    public GetByIdAmmoTypeQuery(long id)
    {
        Id = id;
    }
}