using EcommerceCopilot.ProductCatalogApi.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetProductList;

public class Endpoint : Endpoint<GetProductListRequest, Results<Ok<GetProductListResponse>, NotFound>>
{
    private readonly ProductCatalogContext _productCatalogContext;

    public Endpoint(ProductCatalogContext productCatalogContext)
    {
        _productCatalogContext = productCatalogContext;
    }

    public override void Configure()
    {
        Get("/api/catalog");
        AllowAnonymous();
        ResponseCache(60);
    }

    public override async Task<Results<Ok<GetProductListResponse>, NotFound>> ExecuteAsync(GetProductListRequest r, CancellationToken c)
    {
        List<CatalogItemSummaryDto> items = await _productCatalogContext.CatalogItems
            .ApplyFilteringOrderingPaging(r)
            .ProjectToDto()
            .ToListAsync(cancellationToken: c);

        if (items.Count == 0)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(new GetProductListResponse
        {
            Items = new Paging<CatalogItemSummaryDto>(items.Count, items),
        });
    }
}
