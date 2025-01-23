namespace D2ETL.Core.LoreTypeDefinition;

public class LoreTypeResponse
{
    public long Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Subtitle { get; init; } = string.Empty;

    public LoreTypeResponse()
    {
        
    }

    public LoreTypeResponse(long id, string name, string description, string subtitle)
    {
        Id = id;
        Name = name;
        Description = description;
        Subtitle = subtitle;
    }

    public static LoreType From(long id, string name, string description, string subtitle)
    {
        return new LoreType(id, name, description, subtitle);
    }
}