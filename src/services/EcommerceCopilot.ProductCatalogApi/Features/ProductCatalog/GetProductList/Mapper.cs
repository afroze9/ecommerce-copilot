﻿using EcommerceCopilot.ProductCatalogApi.Entities;
using Riok.Mapperly.Abstractions;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.GetProductList;

[Mapper]
public static partial class ProductCatalogMapper
{
#pragma warning disable RMG020 // Source member is not mapped to any target member
    public static partial IQueryable<CatalogItemSummaryDto> ProjectToDto(this IQueryable<CatalogItem> q);
#pragma warning restore RMG020 // Source member is not mapped to any target member
}