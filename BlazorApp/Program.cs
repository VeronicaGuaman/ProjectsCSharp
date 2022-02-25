using BlazorApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//var httpClienHandler = new HttpClientHandler();
//httpClienHandler.ServerCertificateCustomValidationCallback = (message, cert,chain,errors)=> true;
builder.Services.AddSingleton(new HttpClient
                                    {
                                        BaseAddress = new Uri("https://localhost:7190")
                                    }
    );;;

await builder.Build().RunAsync();
