namespace D2ETL.Core.AmmoTypeDefinition;

public class AmmoType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;

    public AmmoType()
    {
        
    }

    public AmmoType(int id, string name, string description, string icon)
    {
        Id = id;
        Name = name;
        Description = description;
        Icon = icon;
    }


    public static AmmoType From(int id, string name, string description, string icon)
    {
        return new AmmoType(id, name, description, icon);
    }
}