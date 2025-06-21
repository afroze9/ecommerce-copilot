﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceCopilot.ProductCatalogApi.Entities;

public class CatalogType
{
    public int Id { get; set; }

    [Required]
    public string Type { get; set; }
}
