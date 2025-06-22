using EcommerceCopilot.ProductCatalogApi.Entities;
using EcommerceCopilot.ProductCatalogApi.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Pgvector;

namespace EcommerceCopilot.ProductCatalogApi.Features.ProductCatalog.CreateCatalogItem;

public class Endpoint : Endpoint<CreateCatalogItemRequest, Results<Created<CreateCatalogItemResponse>, BadRequest<CreateCatalogItemErrorResponse>>>
{
    private readonly ProductCatalogContext _productCatalogContext;

    public Endpoint(ProductCatalogContext productCatalogContext)
    {
        _productCatalogContext = productCatalogContext;
    }

    public override void Configure()
    {
        Post("/api/catalog");
        AllowAnonymous();
    }

    public override async Task<Results<Created<CreateCatalogItemResponse>, BadRequest<CreateCatalogItemErrorResponse>>> ExecuteAsync(CreateCatalogItemRequest req, CancellationToken ct)
    {
        CatalogItem item = new CatalogItem
        {
            CatalogBrandId = req.CatalogBrandId,
            CatalogTypeId = req.CatalogTypeId,
            Description = req.Description,
            Name = req.Name,
            ImageUrl = req.ImageUrl,
            MaxStockThreshold = req.MaxStockThreshold,
            Price = req.Price,
            RestockThreshold = req.RestockThreshold,
            StockQuantity = req.StockQuantity,
            Embedding = new Vector(Enumerable.Repeat(0.0f, 384).ToArray()),
        };

        if (!await _productCatalogContext.CatalogBrands.AnyAsync(cb => cb.Id == req.CatalogBrandId))
        {
            return TypedResults.BadRequest(new CreateCatalogItemErrorResponse
            {
                Error = $"Catalog Brand with ID {req.CatalogBrandId} does not exist"
            });
        }

        await _productCatalogContext.CatalogItems.AddAsync(item, ct);
        await _productCatalogContext.SaveChangesAsync(ct);

        return TypedResults.Created($"/api/catalog/{item.Id}", new CreateCatalogItemResponse
        {
            Id = item.Id,
        });
    }
}