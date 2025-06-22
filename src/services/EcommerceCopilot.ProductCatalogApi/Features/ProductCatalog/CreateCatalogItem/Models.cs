namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.CreateCatalogItem;


public class CreateCatalogItemRequest
{
    public int CatalogBrandId { get; set; }
    public int CatalogTypeId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int MaxStockThreshold { get; set; }
    public decimal Price { get; set; }
    public int RestockThreshold { get; set; }
    public int StockQuantity { get; set; }
}

public class CreateCatalogItemResponse
{
    public int Id { get; set; }
}

public class CreateCatalogItemErrorResponse
{
    public required string Error { get; set; }
}