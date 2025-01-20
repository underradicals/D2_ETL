using D2ETL.Core.Models;

namespace D2ETL.Core.DamageTypeDefinition;

public class DamageType : Entity
{
    private DamageType() { }
    
    public DamageType(long id, string? name, string? description, string? icon, int red, int green, int blue, int alpha) : base(id)
    {
        Name = name;
        Description = description;
        Icon = icon;
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
        AddDomainEvent(new DamageTypeViewedEvent(Id));
    }
    
    public DamageType(long id, string? name, string? description, string? icon) : base(id)
    {
        Name = name;
        Description = description;
        Icon = icon;
        AddDomainEvent(new DamageTypeViewedEvent(Id));
    }


    public static DamageType From(long id, string? name, string? description, string? icon, int red, int green, int blue, int alpha)
    {
        return new DamageType(id, name, description, icon, red, green, blue, alpha);
    }
    
    public static DamageType From(long id, string? name, string? description, string? icon)
    {
        return new DamageType(id, name, description, icon);
    }

    public static DamageType From(DamageTypeRequest request)
    {
        return DamageType.From(request.Id, request.Name, request.Description, request.Icon, request.Red,
            request.Green, request.Blue, request.Alpha);
    }

    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public string? Icon { get; private set; }
    public int Red { get; private set; }
    public int Green { get; private set; }
    public int Blue { get; private set; }
    public int Alpha { get; private set; }
}