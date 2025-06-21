using EcommerceCopilot.ProductCatalogApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceCopilot.ProductCatalogApi.Infrastructure.EntityConfigurations;

public class CatalogTypeEntityTypeConfiguration : IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.ToTable("CatalogType");

        builder.Property(cb => cb.Type)
            .HasMaxLength(100);
    }
}