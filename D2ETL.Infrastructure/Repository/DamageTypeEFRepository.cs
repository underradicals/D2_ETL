using D2ETL.Core.DamageTypeDefinition;
using Microsoft.EntityFrameworkCore;

namespace D2ETL.Infrastructure.Repository;

public class DamageTypeEFRepository : IDamageTypeRepository
{
    private readonly ApplicationSqliteContext _context;

    public DamageTypeEFRepository(ApplicationSqliteContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DamageType> GetById(long id)
    {
        var result = await _context.DamageTypes.FindAsync(id);
        if (result == null)
        {
            throw new ArgumentException($"No damage type with id: {id}");
        }

        return result;
    }

    public async Task<List<DamageType>> GetAll()
    {
        return await _context.DamageTypes.ToListAsync();
    }

    public Task<int> Add(DamageTypeRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(DamageTypeRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(string id)
    {
        throw new NotImplementedException();
    }
}