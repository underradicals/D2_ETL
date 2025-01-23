namespace D2ETL.Core.LoreTypeDefinition;

public interface ILoreTypeRepository
{
    public Task<List<LoreType>> GetPagedResult(int limit, int offset);
    public Task<LoreType> GetById(long id);
    public long TotalNumberOfRecords { get; }
}