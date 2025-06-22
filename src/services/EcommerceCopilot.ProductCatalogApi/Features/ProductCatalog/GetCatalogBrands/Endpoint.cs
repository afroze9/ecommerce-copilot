using EcommerceCopilot.ProductCatalogApi.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetCatalogBrands;

public class Endpoint : EndpointWithoutRequest<Results<Ok<List<CatalogBrandDto>>, NotFound>>
{
    private readonly ProductCatalogContext _productCatalogContext;

    public Endpoint(ProductCatalogContext productCatalogContext)
    {
        _productCatalogContext = productCatalogContext;
    }

    public override void Configure()
    {
        Get("/api/catalog-brands");
        AllowAnonymous();
        ResponseCache(60);
    }

    public override async Task<Results<Ok<List<CatalogBrandDto>>, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        List<CatalogBrandDto> items = await _productCatalogContext.CatalogBrands
            .ProjectToDto()
            .ToListAsync();

        if (items.Count == 0)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(items);
    }
}
