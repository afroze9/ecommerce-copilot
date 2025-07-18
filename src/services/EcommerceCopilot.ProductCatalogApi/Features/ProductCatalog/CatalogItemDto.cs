﻿namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog;

public class CatalogItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public CatalogBrandDto CatalogBrand { get; set; }
}
