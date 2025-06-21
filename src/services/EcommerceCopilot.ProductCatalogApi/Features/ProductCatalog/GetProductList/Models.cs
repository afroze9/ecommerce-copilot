namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetProductList;

public class GetProductListRequest : GridifyQuery
{
}

public class GetProductListResponse
{
    public Paging<CatalogItemDto> Items { get; set; } = new Paging<CatalogItemDto>();
}