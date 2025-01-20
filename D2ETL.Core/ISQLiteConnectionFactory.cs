using System.Data;
using D2ETL.Core.Models;

namespace D2ETL.Core;

public interface ISQLiteConnectionFactory
{
    public IDbConnection CreateConnection();
    public Task PublishEventsAsync(Entity entity);
}