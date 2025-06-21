using Azure;
using Microsoft.SemanticKernel;

namespace Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddEcommerceCopilotKernel(this IServiceCollection services)
    {
        IKernelBuilder builder = Kernel.CreateBuilder();
        builder.AddAzureOpenAIChatCompletion("", "", "");
        builder.Services.AddAzureAISearchVectorStore(
            endpoint: new Uri(""),
            keyCredential: new AzureKeyCredential(""));

        builder.AddAzureOpenAIEmbeddingGenerator(
            deploymentName: "",
            endpoint: "https",
            apiKey: "",
            modelId: "text-embedding-3-small",
            dimensions: 1536);

        Kernel kernel = builder.Build();
        services.AddSingleton<Kernel>(kernel);

        return services;
    }
}
