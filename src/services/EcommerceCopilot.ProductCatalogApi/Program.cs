global using FastEndpoints;
global using Microsoft.EntityFrameworkCore;
global using EcommerceCopilot.ProductCatalogApi.Extensions;
using FastEndpoints.Swagger;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.AddProductCatalogServices();
builder.Services.AddProblemDetails()
    .AddFastEndpoints()
    .AddSwaggerDocument();

WebApplication app = builder.Build();
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app
    .MapDefaultEndpoints()
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

public partial class Program { }