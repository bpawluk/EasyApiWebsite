using BlazorUtils.EasyApi;
using BlazorUtils.EasyApi.Server;
using BlazorUtils.EasyApi.Server.Setup;
using EasyApiWebsite.Client;
using EasyApiWebsite.Contract.Model;
using EasyApiWebsite.Server;
using EasyApiWebsite.Server.Auth;
using EasyApiWebsite.Server.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PostsRepository>();

builder.Services
    .AddCascadingAuthenticationState()
    .AddScoped<AuthenticationStateProvider, PersistingAuthenticationStateProvider>();

builder.Services
    .AddAuthorization()
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Setup EasyApi server-side with the specified Contract 
builder.Services
    .AddEasyApi()
    .WithContract(typeof(Post).Assembly)
    .WithServer()
    .Using<PrerenderedResponsePersistence>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseStaticFiles()
   .UseAntiforgery()
   .UseAuthentication()
   .UseAuthorization();

app.MapRazorComponents<App>()
   .AddAdditionalAssemblies(typeof(Routes).Assembly)
   .AddInteractiveServerRenderMode()
   .AddInteractiveWebAssemblyRenderMode();

// Create API endpoints for EasyApi requests 
app.MapRequests();

app.Run();
