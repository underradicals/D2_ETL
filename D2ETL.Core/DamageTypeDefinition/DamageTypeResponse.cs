namespace D2ETL.Core.DamageTypeDefinition;

public class DamageTypeResponse
{
    public DamageTypeResponse(long id, string name, string description, string icon, int red, int green, int blue, int alpha)
    {
        Id = id;
        Name = name;
        Description = description;
        Icon = icon;
        Color = new Color(red, green, blue, alpha);
       
    }
    
    public DamageTypeResponse(long id, string name, string description, string icon)
    {
        Id = id;
        Name = name;
        Description = description;
        Icon = icon;
    }


    public static DamageTypeResponse From(long id, string name, string description, string icon, int red, int green, int blue, int alpha)
    {
        var entity = new DamageTypeResponse(id, name, description, icon, red, green, blue, alpha);
        
        return entity;
    }
    
    public static DamageTypeResponse From(long id, string name, string description, string icon)
    {
        return new DamageTypeResponse(id, name, description, icon);
    }

    public static DamageTypeResponse From(DamageType entity)
    {
        return new DamageTypeResponse(entity.Id, entity.Name ?? "", entity.Description ?? "", entity.Icon ?? "", entity.Red, entity.Green, entity.Blue, entity.Alpha);
    }
    
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Icon { get; private set; }
    public Color Color { get; private set; } = new Color(255, 255, 255, 255);
}