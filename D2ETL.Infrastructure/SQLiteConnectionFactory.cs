using System.Data;
using System.Data.SQLite;
using D2ETL.Core;
using D2ETL.Core.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace D2ETL.Infrastructure;

public class SQLiteConnectionFactory : ISQLiteConnectionFactory
{
    private readonly IPublisher _publisher;
    private readonly string _connectionString;
    
    public SQLiteConnectionFactory(IPublisher publisher, IConfiguration configuration)
    {
        _publisher = publisher;
        _connectionString = configuration["ConnectionStrings:SQLiteConnection"]!;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SQLiteConnection(_connectionString);
        // connection.ConnectionString = "Data Source=:memory:";
        connection.Open();
        return connection;
    }

    public async Task PublishEventsAsync(Entity entity)
    {
        var domainEvents = entity.DomainEvents;
        foreach(var e in domainEvents)
        {
            await _publisher.Publish(e);
        }
    }
}