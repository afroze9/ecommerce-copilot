using EcommerceCopilot.ProductCatalogApi.Entities;
using EcommerceCopilot.ProductCatalogApi.Infrastructure;
using Gridify.EntityFramework;

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
        Paging<CatalogItem> items = await _productCatalogContext.CatalogItems.GridifyAsync(r);
        await SendAsync(new GetProductListResponse()
        {
            Items = items,
        });
    }
}