using BlazorDemoPart2.Client;
using BlazorDemoPart2.Client.DataServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ICustomerDataService,
    CustomerDataService>(client => client.BaseAddress =
    new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<ICountryDataService,
    CountryDataService>(client => client.BaseAddress =
new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
