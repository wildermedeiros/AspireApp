using AspireApp.Web.Components;
using AspireApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
//builder.AddRedisOutputCache("cache");

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddHttpClient<WeatherService>(client=> client.BaseAddress = new("http://api-service"));
builder.Services.AddHttpClient<CustomerService>(client => client.BaseAddress = new("http://api-customer"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();

app.UseAntiforgery();

app.UseHttpsRedirection();

//app.UseOutputCache();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
    
app.MapDefaultEndpoints();

app.Run();
