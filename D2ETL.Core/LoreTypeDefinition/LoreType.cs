using D2ETL.Core.Models;

namespace D2ETL.Core.LoreTypeDefinition;

public class LoreType : Entity
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Subtitle { get; init; } = string.Empty;

    public LoreType() : base(0)
    {
        
    }

    public LoreType(long id, string name, string description, string subtitle) : base(id)
    {
        Name = name;
        Description = description;
        Subtitle = subtitle;
    }

    public static LoreType From(long id, string name, string description, string subtitle)
    {
        return new LoreType(id, name, description, subtitle);
    }
}