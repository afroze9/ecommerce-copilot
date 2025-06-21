using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Pgvector;

namespace EcommerceCopilot.ProductCatalogApi.Entities;

public class CatalogItem
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
    
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public int CatalogTypeId { get; set; }

    public CatalogType CatalogType { get; set; }

    public int CatalogBrandId { get; set; }

    public CatalogBrand CatalogBrand { get; set; }

    public int StockQuantity { get; set; }
    
    public int RestockThreshold { get; set; }

    public int MaxStockThreshold { get; set; }

    public bool OnReorder { get; set; }

    [JsonIgnore]
    public Vector Embedding { get; set; }

    public CatalogItem() { }
}
