using D2ETL.Core.AmmoTypeDefinition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2ETL.Infrastructure.EntityConfigurations;

public class AmmoTypeEntityConfiguration : IEntityTypeConfiguration<AmmoType>
{
    public void Configure(EntityTypeBuilder<AmmoType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
        builder.Property(x => x.Name)
            .HasColumnType("text")
            .IsRequired();
        builder.Property(x => x.Description)
            .HasColumnType("text")
            .IsRequired();
        builder.Property(x => x.Icon)
            .HasColumnType("text")
            .IsRequired();
    }
}