using System.ComponentModel.DataAnnotations;

namespace EcommerceCopilot.ProductCatalogApi.Entities;

public class CatalogType
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Type { get; set; }
}
