namespace D2ETL.Core.AmmoTypeDefinition;

public interface IAmmoTypeRepository
{
    public Task<List<AmmoType>> GetAmmoTypes();
    public Task<AmmoType?> GetAmmoTypeById(long id);
}