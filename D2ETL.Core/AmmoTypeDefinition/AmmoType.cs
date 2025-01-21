using D2ETL.Core.Models;

namespace D2ETL.Core.AmmoTypeDefinition;

public class AmmoType : Entity
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Icon { get; init; } = string.Empty;

    public AmmoType() 
    {
        
    }

    public AmmoType(long id, string name, string description, string icon) : base(id)
    {
        Name = name;
        Description = description;
        Icon = icon;
    }


    public static AmmoType From(int id, string name, string description, string icon)
    {
        return new AmmoType(id, name, description, icon);
    }
}