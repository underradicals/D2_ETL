namespace D2ETL.Core.DamageTypeDefinition;

public interface IDamageTypeRepository
{
    Task<List<DamageType>> GetAll();
    Task<DamageType> GetById(long id);
    Task<int> Add(DamageTypeRequest request);
    Task<int> Update(DamageTypeRequest request);
    Task<int> Delete(string id);
}