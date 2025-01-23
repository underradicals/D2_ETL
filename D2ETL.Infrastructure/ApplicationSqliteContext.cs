using D2ETL.Core.AmmoTypeDefinition;
using D2ETL.Core.DamageTypeDefinition;
using D2ETL.Core.LoreTypeDefinition;
using D2ETL.Core.Models;
using D2ETL.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace D2ETL.Infrastructure;

public class ApplicationSqliteContext : DbContext
{
    private readonly IPublisher _publisher;
    
    public ApplicationSqliteContext(DbContextOptions<ApplicationSqliteContext> options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }
    
    public DbSet<DamageType> DamageTypes { get; set; }
    public DbSet<AmmoType> AmmoTypes { get; set; }
    public DbSet<LoreType> LoreTypes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DamageTypeEntityConfiguration());
        builder.ApplyConfiguration(new AmmoTypeEntityConfiguration());
        builder.ApplyConfiguration(new LoreTypeEntityConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(x => x.Entity)
            .Where(y => y.DomainEvents.Count != 0)
            .SelectMany(x => x.DomainEvents);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        return await base.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}