namespace D2ETL.Core.DamageTypeDefinition;

public record DamageTypeRequest
{
    public DamageTypeRequest(long id, string name, string description, string icon, int red, int green, int blue, int alpha)
    {
        Id = id;
        Name = name;
        Description = description;
        Icon = icon;
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
       
    }
    
    public DamageTypeRequest(long id, string name, string description, string icon)
    {
        Id = id;
        Name = name;
        Description = description;
        Icon = icon;
    }


    public static DamageTypeRequest From(long id, string name, string description, string icon, int red, int green, int blue, int alpha)
    {
        return new DamageTypeRequest(id, name, description, icon, red, green, blue, alpha);
    }
    
    public static DamageTypeRequest From(long id, string name, string description, string icon)
    {
        return new DamageTypeRequest(id, name, description, icon);
    }
    
    public readonly long Id;

    public string Name { get; private set; }

    public string Description { get; private set; }
    public string Icon { get; private set; }
    public int Red { get; private set; }
    public int Green { get; private set; }
    public int Blue { get; private set; }
    public int Alpha { get; private set; }
};