using EcommerceCopilot.ProductCatalogApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceCopilot.ProductCatalogApi.Infrastructure.EntityConfigurations;

public class CatalogBrandEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrand>
{
    public void Configure(EntityTypeBuilder<CatalogBrand> builder)
    {
        builder.ToTable("CatalogBrand");

        builder.Property(cb => cb.Brand)
            .HasMaxLength(100);
    }
}
