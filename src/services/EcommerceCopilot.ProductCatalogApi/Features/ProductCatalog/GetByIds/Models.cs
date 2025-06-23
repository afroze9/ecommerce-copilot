using EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetByIds;

public class GetProductsByIdsRequest
{
    public Guid[] Ids { get; set; } = [];
}

public class GetProductsByIdsResponse
{
    public List<CatalogItemSummaryDto> Items { get; set; } = [];
}