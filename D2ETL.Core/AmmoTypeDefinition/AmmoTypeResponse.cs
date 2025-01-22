namespace D2ETL.Core.AmmoTypeDefinition;

public class AmmoTypeResponse
{
    public long Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Icon { get; init; } = string.Empty;

    public AmmoTypeResponse() 
    {
        
    }

    public AmmoTypeResponse(long id, string name, string description, string icon)
    {
        Id = id;
        Name = name;
        Description = description;
        Icon = icon;
    }


    public static AmmoTypeResponse From(int id, string name, string description, string icon)
    {
        return new AmmoTypeResponse(id, name, description, icon);
    }
}