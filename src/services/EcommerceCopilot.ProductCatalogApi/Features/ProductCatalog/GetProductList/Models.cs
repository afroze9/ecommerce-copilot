namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetProductList;

public class GetProductListRequest : GridifyQuery
{
}

public class GetProductListResponse
{
    public Paging<CatalogItemSummaryDto> Items { get; set; } = new Paging<CatalogItemSummaryDto>();
}
