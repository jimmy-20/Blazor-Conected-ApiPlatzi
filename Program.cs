using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWebAssemblyApp;
using BlazorWebAssemblyApp.Services;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiPlatziUrl = builder.Configuration.GetValue<string>("UrlApiPlatzi");
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryServices>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiPlatziUrl) });



await builder.Build().RunAsync();
