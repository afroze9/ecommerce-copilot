using EcommerceCopilot.ProductCatalogApi.Entities;
using Microsoft.Extensions.Options;
using Npgsql;
using Pgvector;
using System.Text.Json;

namespace EcommerceCopilot.ProductCatalogApi.Infrastructure;

public partial class ProductCatalogContextSeed(
    IWebHostEnvironment env,
    IOptions<ProductCatalogOptions> settings,
    ILogger<ProductCatalogContextSeed> logger) : IDbSeeder<ProductCatalogContext>
{
    public async Task SeedAsync(ProductCatalogContext context)
    {
        bool useCustomizationData = settings.Value.UseCustomizationData;
        string contentRootPath = env.ContentRootPath;
        string picturePath = env.WebRootPath;

        // Workaround from https://github.com/npgsql/efcore.pg/issues/292#issuecomment-388608426
        context.Database.OpenConnection();
        ((NpgsqlConnection)context.Database.GetDbConnection()).ReloadTypes();

        if (context.CatalogItems.Any()) return;

        string sourcePath = Path.Combine(contentRootPath, "Setup", "productcatalog.json");
        string sourceJson = File.ReadAllText(sourcePath);
        ProductCatalogSourceEntry[]? sourceItems = JsonSerializer.Deserialize<ProductCatalogSourceEntry[]>(sourceJson);

        context.CatalogBrands.RemoveRange(context.CatalogBrands);
        await context.CatalogBrands.AddRangeAsync(
            sourceItems
                .Select(x => x.Brand)
                .Distinct()
                .Select(brandName => new CatalogBrand { Brand = brandName }));
        logger.LogInformation("Seeded catalog with {NumBrands} brands", context.CatalogBrands.Count());

        context.CatalogTypes.RemoveRange(context.CatalogTypes);
        await context.CatalogTypes.AddRangeAsync(
            sourceItems
                .Select(x => x.Type)
                .Distinct()
                .Select(typeName => new CatalogType { Type = typeName }));
        logger.LogInformation("Seeded catalog with {NumTypes} types", context.CatalogTypes.Count());

        await context.SaveChangesAsync();

        Dictionary<string, Guid> brandIdsByName = await context.CatalogBrands.ToDictionaryAsync(x => x.Brand, x => x.Id);
        Dictionary<string, Guid> typeIdsByName = await context.CatalogTypes.ToDictionaryAsync(x => x.Type, x => x.Id);

        CatalogItem[] catalogItems = sourceItems.Select(source => new CatalogItem
        {
            Id = source.Id,
            Name = source.Name,
            Description = source.Description,
            Price = source.Price,
            CatalogBrandId = brandIdsByName[source.Brand],
            CatalogTypeId = typeIdsByName[source.Type],
            StockQuantity = 100,
            MaxStockThreshold = 200,
            RestockThreshold = 10,
            ImageUrl = $"{source.Id}.webp",
            Embedding = new Vector(Enumerable.Repeat(0.0f, 384).ToArray()),
        }).ToArray();

        await context.CatalogItems.AddRangeAsync(catalogItems);
        logger.LogInformation("Seeded catalog with {NumItems} items", context.CatalogItems.Count());
        await context.SaveChangesAsync();
    }

    private class ProductCatalogSourceEntry
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

