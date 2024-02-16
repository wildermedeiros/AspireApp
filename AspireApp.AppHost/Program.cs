var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedisContainer("cache");

var apiservice = builder.AddProject<Projects.AspireApp_ApiService>("api-service");
var apicustomer = builder.AddProject<Projects.AspireApp_ApiCustomer>("api-customer");

builder.AddProject<Projects.AspireApp_Web>("web-frontend")
    .WithReference(apiservice)
    .WithReference(apicustomer);
    //.WithReference(cache)

builder.Build().Run();
