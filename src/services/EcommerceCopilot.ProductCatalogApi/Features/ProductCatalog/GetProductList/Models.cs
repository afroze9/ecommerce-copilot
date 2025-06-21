using EcommerceCopilot.ProductCatalogApi.Entities;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetProductList;

public class GetProductListRequest
{
    public string SearchQuery { get; set; }

    public class Validator : Validator<GetProductListRequest>
    {
        public Validator()
        {

        }
    }
}

public class GetProductListResponse
{
    public List<CatalogItem> Items { get; set; } = [];
}
