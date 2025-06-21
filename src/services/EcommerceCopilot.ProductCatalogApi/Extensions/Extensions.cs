using EcommerceCopilot.ProductCatalogApi.Infrastructure;

namespace EcommerceCopilot.ProductCatalogApi.Extensions;

public static class Extensions
{
    public static void AddProductCatalogServices(this IHostApplicationBuilder builder)
    {
        if (builder.Environment.IsBuild())
        {
            builder.Services.AddDbContext<ProductCatalogContext>();
            return;
        }

        builder.AddNpgsqlDbContext<ProductCatalogContext>("productCatalogDb", configureDbContextOptions: options =>
        {
            options.UseNpgsql(builder => builder.UseVector());
        });

        builder.Services.AddMigration<ProductCatalogContext, ProductCatalogContextSeed>();
        builder.Services.AddOptions<ProductCatalogOptions>().BindConfiguration(nameof(ProductCatalogOptions));
    }
}