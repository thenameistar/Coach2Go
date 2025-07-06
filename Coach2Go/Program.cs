using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Coach2Go;
using MudBlazor.Services;
using Blazored.LocalStorage; 

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
<<<<<<< HEAD
    BaseAddress = new Uri("http://localhost:5136")
=======
    BaseAddress = new Uri("http://localhost:5136") 
>>>>>>> e02b59bb5928a45dfbb571013add94516414e195
});

builder.Services.AddMudServices();

<<<<<<< HEAD
builder.Services.AddScoped<AuthService>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
=======
await builder.Build().RunAsync();
>>>>>>> e02b59bb5928a45dfbb571013add94516414e195
