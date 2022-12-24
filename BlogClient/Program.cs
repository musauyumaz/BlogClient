using BlogClient;
using BlogClient.Services;
using BlogClient.Services.Models.Abstract;
using BlogClient.Services.Models.Concrete;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
