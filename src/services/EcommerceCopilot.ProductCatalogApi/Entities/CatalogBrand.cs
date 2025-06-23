using System.ComponentModel.DataAnnotations;

namespace EcommerceCopilot.ProductCatalogApi.Entities;

public class CatalogBrand
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Brand { get; set; }
}
