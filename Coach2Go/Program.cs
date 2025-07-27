using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Coach2Go;
using MudBlazor.Services;
using Blazored.LocalStorage;
using Coach2Go.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5204")
});

builder.Services.AddScoped<CustomAuthorisationMessageHandler>();

builder.Services.AddHttpClient("AuthorisedClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5204");
}).AddHttpMessageHandler<CustomAuthorisationMessageHandler>();

builder.Services.AddMudServices();
builder.Services.AddScoped<AuthService>();
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddScoped<OnboardingState>();

await builder.Build().RunAsync();