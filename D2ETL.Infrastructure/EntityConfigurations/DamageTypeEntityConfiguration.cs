using System.Linq.Expressions;
using D2ETL.Core.DamageTypeDefinition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2ETL.Infrastructure.EntityConfigurations;

public class DamageTypeEntityConfiguration : IEntityTypeConfiguration<DamageType>
{
    public void Configure(EntityTypeBuilder<DamageType> builder)
    {
        builder.ToTable("damage_type_definition");
        builder.HasKey(x => x.Id).HasName("id");
        builder.Ignore(x => x.CreatedAt);
        builder.Ignore(x => x.UpdatedAt);
        builder.Property(x => x.Id)
            .HasColumnType("integer")
            .IsRequired()
            .ValueGeneratedNever();
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
        builder.Property(x => x.Red)
            .HasColumnName("red")
            .HasColumnType("integer")
            .IsRequired();
        builder.Property(x => x.Green)
            .HasColumnName("green")
            .HasColumnType("integer")
            .IsRequired();
        builder.Property(x => x.Blue)
            .HasColumnName("blue")
            .HasColumnType("integer")
            .IsRequired();
        builder.Property(x => x.Alpha)
            .HasColumnName("alpha")
            .HasColumnType("integer")
            .IsRequired();
    }
}