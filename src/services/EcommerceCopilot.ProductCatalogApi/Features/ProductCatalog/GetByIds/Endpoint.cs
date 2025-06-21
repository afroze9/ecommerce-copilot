using EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetProductList;
using EcommerceCopilot.ProductCatalogApi.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetByIds;

public class Endpoint : Endpoint<GetProductsByIdsRequest, Results<Ok<GetProductsByIdsResponse>, NotFound>>
{
    private readonly ProductCatalogContext _productCatalogContext;

    public Endpoint(ProductCatalogContext productCatalogContext)
    {
        _productCatalogContext = productCatalogContext;
    }

    public override void Configure()
    {
        Get("/api/product-catalog/by");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<GetProductsByIdsResponse>, NotFound>> ExecuteAsync(GetProductsByIdsRequest req, CancellationToken ct)
    {
        var items = await _productCatalogContext.CatalogItems
            .Where(x => req.Ids.Contains(x.Id))
            .ProjectToDto()
            .ToListAsync(ct);

        if (items.Count == 0)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(new GetProductsByIdsResponse
        {
            Items = items,
        });
    }
}
