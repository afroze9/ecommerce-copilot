using EcommerceCopilot.ProductCatalogApi.Entities;
using EcommerceCopilot.ProductCatalogApi.Infrastructure.EntityConfigurations;

namespace EcommerceCopilot.ProductCatalogApi.Infrastructure;

/// <remarks>
/// Add migrations using the following command inside the 'EcommerceCopilot.ProductCatalogApi' project directory:
///
/// dotnet ef migrations add --context ProductCatalogContext [migration-name]
/// </remarks>
public class ProductCatalogContext : DbContext
{
    public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options, IConfiguration configuration) : base(options)
    {
    }

    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("vector");
        builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
    }
}
