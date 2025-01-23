using D2ETL.Core.LoreTypeDefinition;
using Microsoft.EntityFrameworkCore;

namespace D2ETL.Infrastructure.Repository;

public class LoreTypeEFRepository : ILoreTypeRepository
{
    private readonly ApplicationSqliteContext _context;
    public long TotalNumberOfRecords { get; }

    public LoreTypeEFRepository(ApplicationSqliteContext context)
    {
        _context = context;
        TotalNumberOfRecords = _context.LoreTypes.Count();
    }

    public async Task<List<LoreType>> GetPagedResult(int limit, int offset)
    {
        var result = await _context.LoreTypes
            .OrderBy(x => x.Id)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
        return result;
    }

    public async Task<LoreType> GetById(long id)
    {
        var result = await _context.LoreTypes.SingleOrDefaultAsync(x => x.Id == id);
        return result!;
    }
}