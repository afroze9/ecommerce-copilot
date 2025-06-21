using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel;

namespace EcommerceCopilot.CopilotApi.Plugins;

public class ProductSearchPlugin()
{
    [KernelFunction("search_products")]
    public async Task SearchProductAsync()
    {

    }
}


public class Product
{
    [VectorStoreKey]
    public string Id { get; set; }
}