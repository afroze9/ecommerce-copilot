using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Pgvector;

namespace EcommerceCopilot.ProductCatalogApi.Entities;

public class CatalogItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
    
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public Guid CatalogTypeId { get; set; }

    public CatalogType CatalogType { get; set; }

    public Guid CatalogBrandId { get; set; }

    public CatalogBrand CatalogBrand { get; set; }

    public int StockQuantity { get; set; }
    
    public int RestockThreshold { get; set; }

    public int MaxStockThreshold { get; set; }

    public bool OnReorder { get; set; }

    [JsonIgnore]
    public Vector Embedding { get; set; }

    public CatalogItem() { }
}
