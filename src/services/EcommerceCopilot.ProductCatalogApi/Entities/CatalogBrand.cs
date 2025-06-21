using System.ComponentModel.DataAnnotations;

namespace EcommerceCopilot.ProductCatalogApi.Entities;

public class CatalogBrand
{
    public int Id { get; set; }

    [Required]
    public string Brand { get; set; }
}
