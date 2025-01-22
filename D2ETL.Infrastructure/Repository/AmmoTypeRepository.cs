using D2ETL.Core;
using D2ETL.Core.AmmoTypeDefinition;
using Dapper;

namespace D2ETL.Infrastructure.Repository;

public class AmmoTypeRepository : IAmmoTypeRepository
{
    private readonly ISQLiteConnectionFactory _context;

    public AmmoTypeRepository(ISQLiteConnectionFactory context)
    {
        _context = context;
    }

    public async Task<List<AmmoType>> GetAmmoTypes()
    {
        var connection = _context.CreateConnection();
        const string sql = "select * from ammo_type_definition";
        var result = (await connection.QueryAsync<AmmoType>(sql)).ToList();
        return result;
        
    }

    public async Task<AmmoType?> GetAmmoTypeById(long id)
    {
        var connection = _context.CreateConnection();
        const string sql = "select * from ammo_type_definition where id=@id";
        var result = (await connection.QuerySingleOrDefaultAsync<AmmoType>(sql, new { id }));
        return result;
    }
}