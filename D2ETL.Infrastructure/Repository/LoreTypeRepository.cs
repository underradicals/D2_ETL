using D2ETL.Core;
using D2ETL.Core.LoreTypeDefinition;
using Dapper;

namespace D2ETL.Infrastructure.Repository;

public class LoreTypeRepository : ILoreTypeRepository
{
    public long TotalNumberOfRecords { get; }
    private readonly ISQLiteConnectionFactory _factory;

    public LoreTypeRepository(ISQLiteConnectionFactory factory)
    {
        _factory = factory;
        var connection = _factory.CreateConnection();
        const string sql = """
                           select count(*) from lore_type_definition
                           where name != "" or description != "" or subtitle != ""
                           order by id;
                           """;
        TotalNumberOfRecords = connection.ExecuteScalar<int>(sql);
    }
    
    public async Task<List<LoreType>> GetPagedResult(int limit, int offset)
    {
        var connection = _factory.CreateConnection();
        const string sql = """
                    select id, name, description, subtitle 
                    from lore_type_definition
                    where name != "" or description != "" or subtitle != ""
                    order by id Limit @Limit offset @Offset
                    """;
        var result = (await connection.QueryAsync<LoreType>(sql, new { Limit = limit, Offset = offset }))
            .Select(x => new LoreType(x.Id, x.Name, x.Description, x.Subtitle)).ToList();
        return result;
    }

    public async Task<LoreType> GetById(long id)
    {
        var connection = _factory.CreateConnection();
        const string sql = "select * from lore_type_definition where id=@Id;";
        var result = await connection.QuerySingleAsync<LoreType>(sql, new { Id = id });
        var response = new LoreType(result.Id, result.Name, result.Description, result.Subtitle);
        return response;
    }

}