using D2ETL.Core;
using D2ETL.Core.DamageTypeDefinition;
using Dapper;

namespace D2ETL.Infrastructure.Repository;

public class DamageTypeRepository : IDamageTypeRepository
{
    private readonly ISQLiteConnectionFactory _factory;

    public DamageTypeRepository(ISQLiteConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<DamageType>> GetAll()
    {
        var connection = _factory.CreateConnection();
        var sql = "select * from damage_type_definition";
        var entityList = connection.Query<DamageType>(sql).ToList();
        if (!entityList.Any())
        {
            return await Task.FromResult(new List<DamageType>());
        }

        foreach (var damageType in entityList)
        {
            await _factory.PublishEventsAsync(damageType);
        }
        
        return entityList;
    }

    public async Task<DamageType> GetById(long id)
    {
        var connection = _factory.CreateConnection();
        var sql = "select * from damage_type_definition where Id=@Id";
        var entity = connection.Query<DamageType>(sql, new { Id = id }).FirstOrDefault();
        if (entity is null)
        {
            Console.WriteLine("No damage_type definition found");
        }
        await _factory.PublishEventsAsync(entity!);
        return entity!;
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