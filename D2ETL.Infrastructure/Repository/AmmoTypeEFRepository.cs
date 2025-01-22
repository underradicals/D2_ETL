using D2ETL.Core.AmmoTypeDefinition;
using Microsoft.EntityFrameworkCore;

namespace D2ETL.Infrastructure.Repository;

public class AmmoTypeEFRepository : IAmmoTypeRepository
{
    private readonly ApplicationSqliteContext _context;

    public AmmoTypeEFRepository(ApplicationSqliteContext context)
    {
        _context = context;
    }

    public async Task<List<AmmoType>> GetAmmoTypes()
    {
        return await _context.AmmoTypes.ToListAsync();
    }

    public async Task<AmmoType?> GetAmmoTypeById(long id)
    {
        return await _context.AmmoTypes.FirstOrDefaultAsync();
    }
}