using EcommerceCopilot.ProductCatalogApi.Entities;
using EcommerceCopilot.ProductCatalogApi.Infrastructure;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetProductList;

public class Endpoint : Endpoint<GetProductListRequest, GetProductListResponse, Mapper>
{
    private readonly ProductCatalogContext _productCatalogContext;

    public Endpoint(ProductCatalogContext productCatalogContext)
    {
        _productCatalogContext = productCatalogContext;
    }

    public override void Configure()
    {
        Post("/api/product-catalog");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductListRequest r, CancellationToken c)
    {
        List<CatalogItem> items = [];
        if (string.IsNullOrWhiteSpace(r.SearchQuery))
        {
            items = await _productCatalogContext.CatalogItems
                .OrderBy(ci => ci.Name)
                .Take(10).ToListAsync();
        }
        else 
        {
            items = await _productCatalogContext.CatalogItems
                .Where(ci => ci.Name.Contains(r.SearchQuery))
                .OrderBy(ci => ci.Name)
                .Take(10).ToListAsync();
        }
        await SendAsync(new GetProductListResponse()
        {
            Items = items,
        });
    }
}