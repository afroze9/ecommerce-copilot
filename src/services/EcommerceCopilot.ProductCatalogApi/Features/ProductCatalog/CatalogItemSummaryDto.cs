using System.ComponentModel.DataAnnotations;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog;

public class CatalogItemSummaryDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}
