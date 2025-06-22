using EcommerceCopilot.ProductCatalogApi.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetCatalogTypes;

public class Endpoint : EndpointWithoutRequest<Results<Ok<List<CatalogTypeDto>>, NotFound>>
{
    private readonly ProductCatalogContext _productCatalogContext;

    public Endpoint(ProductCatalogContext productCatalogContext)
    {
        _productCatalogContext = productCatalogContext;
    }

    public override void Configure()
    {
        Get("/api/catalog-types");
        AllowAnonymous();
        ResponseCache(60);
    }

    public override async Task<Results<Ok<List<CatalogTypeDto>>, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        List<CatalogTypeDto> items = await _productCatalogContext.CatalogTypes
            .ProjectToDto()
            .ToListAsync();

        if(items.Count ==0)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(items);
    }
}
