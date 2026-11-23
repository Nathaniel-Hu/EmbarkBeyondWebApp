var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddDotnetProject("apiservice", "../EmbarkBeyond.ApiService/EmbarkBeyond.ApiService.csproj")
    .WithHttpHealthCheck("/health");

builder.AddDotnetProject("webfrontend", "../EmbarkBeyond.Web/EmbarkBeyond.Web.csproj")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
