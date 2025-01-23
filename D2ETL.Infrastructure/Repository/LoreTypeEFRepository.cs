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
        TotalNumberOfRecords = _context.LoreTypes
            .Where(x => x.Name != string.Empty || x.Description != string.Empty || x.Subtitle != string.Empty)
            .OrderBy(x => x.Id)
            .Count();
    }

    public async Task<List<LoreType>> GetPagedResult(int limit, int offset)
    {
        var result = await _context.LoreTypes
            .Where(x => x.Name != string.Empty || x.Description != string.Empty || x.Subtitle != string.Empty)
            .OrderBy(x => x.Id)
            .Skip(offset)
            .Take(limit)
            .Select(x => LoreType.From(x.Id, x.Name, x.Description, x.Subtitle))
            .ToListAsync();
        return result;
    }

    public async Task<LoreType> GetById(long id)
    {
        var result = await _context.LoreTypes.SingleOrDefaultAsync(x => x.Id == id);
        if (result == null) throw new KeyNotFoundException();
        var response = LoreType.From(result.Id, result.Name, result.Description, result.Subtitle);
        return response;
    }
}