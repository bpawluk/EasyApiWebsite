using BlazorUtils.EasyApi;
using BlazorUtils.EasyApi.Server;
using EasyApiWebsite.Client;
using EasyApiWebsite.Contract.Model;
using EasyApiWebsite.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PostsRepository>();

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Setup EasyApi server-side with the specified Contract 
builder.Services
    .AddEasyApi()
    .WithContract(typeof(Post).Assembly)
    .WithServer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AddInteractiveWebAssemblyRenderMode();

// Create API endpoints for EasyApi requests 
app.MapRequests();

app.Run();
