IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

//var insights = builder.AddConnectionString("appInsights", "APPLICATIONINSIGHTS_CONNECTION_STRING");

IResourceBuilder<PostgresServerResource> postgres = builder.AddPostgres("postgres")
    .WithImage("ankane/pgvector")
    .WithImageTag("latest")
    .WithLifetime(ContainerLifetime.Persistent);

IResourceBuilder<PostgresDatabaseResource> productCatalogDb = postgres.AddDatabase("productCatalogDb");

//IResourceBuilder<ProjectResource> copilotApi = builder.AddProject<Projects.EcommerceCopilot_CopilotApi>("copilotapi");
IResourceBuilder<ProjectResource> productCatalogApi = builder
    .AddProject<Projects.EcommerceCopilot_ProductCatalogApi>("productcatalogapi")
    //.WithReference(insights)
    .WithReference(productCatalogDb);

builder.Build().Run();
