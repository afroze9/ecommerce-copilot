using EcommerceCopilot.ProductCatalogApi.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetById;

public class Endpoint : Endpoint<GetProductByIdRequest, Results<Ok<CatalogItemDto>, NotFound>>
{
    private readonly ProductCatalogContext _productCatalogContext;

    public Endpoint(ProductCatalogContext productCatalogContext)
    {
        _productCatalogContext = productCatalogContext;
    }

    public override void Configure()
    {
        Get("/api/product-catalog/{Id}");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<CatalogItemDto>, NotFound>> ExecuteAsync(GetProductByIdRequest req, CancellationToken ct)
    {
        var item = await _productCatalogContext.CatalogItems
            .Where(x => x.Id == req.Id)
            .Include(x => x.CatalogBrand)
            .ProjectToDto()
            .FirstOrDefaultAsync();

        if (item is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(item);
    }
}
