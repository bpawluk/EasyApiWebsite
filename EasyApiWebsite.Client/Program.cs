using BlazorUtils.EasyApi;
using BlazorUtils.EasyApi.Client;
using EasyApiWebsite.Contract.Model;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register basic HttpClient
builder.Services.AddTransient(provider => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Setup EasyApi client-side with the specified Contract 
builder.Services
    .AddEasyApi()
    .WithContract(typeof(Post).Assembly)
    .WithClient();

await builder.Build().RunAsync();
