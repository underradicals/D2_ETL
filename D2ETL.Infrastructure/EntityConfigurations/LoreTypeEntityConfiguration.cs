using D2ETL.Core.LoreTypeDefinition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2ETL.Infrastructure.EntityConfigurations;

public class LoreTypeEntityConfiguration : IEntityTypeConfiguration<LoreType>
{
    public void Configure(EntityTypeBuilder<LoreType> builder)
    {
        builder.ToTable("lore_type_definition");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasColumnType("text").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text").HasMaxLength(20000).IsRequired();
        builder.Property(x => x.Subtitle).HasColumnName("subtitle").HasColumnType("text").HasMaxLength(1000).IsRequired();
        builder.Ignore(x => x.CreatedAt);
        builder.Ignore(x => x.UpdatedAt);
    }
}