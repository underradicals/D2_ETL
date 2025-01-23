namespace D2ETL.Core.LoreTypeDefinition;

public class LoreTypeGetByIdQuery : IQuery<LoreTypeResponse>
{
    public long Id { get; set; }

    public LoreTypeGetByIdQuery(long id)
    {
        Id = id;
    }
}