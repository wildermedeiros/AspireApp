var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedisContainer("cache");

var apiservice = builder.AddProject<Projects.AspireApp_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithReference(apiservice);
    //.WithReference(cache)

builder.Build().Run();
