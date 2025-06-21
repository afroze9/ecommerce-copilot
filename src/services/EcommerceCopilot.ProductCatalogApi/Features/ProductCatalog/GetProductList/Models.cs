using EcommerceCopilot.ProductCatalogApi.Entities;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetProductList;

public class GetProductListRequest : GridifyQuery
{
}

public class GetProductListResponse
{
    public Paging<CatalogItem> Items { get; set; } = new Paging<CatalogItem>();
}
