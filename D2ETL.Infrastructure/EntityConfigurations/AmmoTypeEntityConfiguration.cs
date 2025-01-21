using D2ETL.Core.AmmoTypeDefinition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2ETL.Infrastructure.EntityConfigurations;

public class AmmoTypeEntityConfiguration : IEntityTypeConfiguration<AmmoType>
{
    public void Configure(EntityTypeBuilder<AmmoType> builder)
    {
        builder.ToTable("ammo_type_definition");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedNever().IsRequired();
        builder.Ignore(x => x.CreatedAt);
        builder.Ignore(x => x.UpdatedAt);
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("text")
            .IsRequired();
        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();
        builder.Property(x => x.Icon)
            .HasColumnName("icon")
            .HasColumnType("text")
            .IsRequired();
    }
}