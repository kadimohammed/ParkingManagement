using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ParkingManagement;
using ParkingManagement.Services;
using ParkingManagement.Services.Interfaces;
using ParkingManagement.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7113/api/") });

//builder.Services.AddSingleton<HttpClient>();
// Pour gérer l'autorisation côté client
builder.Services.AddAuthorizationCore();

// Enregistrement du fournisseur personnalisé d'état d'authentification
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IParkingService, ParkingService>();
builder.Services.AddScoped<IUserService,UserService>();

// Service de stockage local (pour sauvegarder le token)
builder.Services.AddBlazoredLocalStorage();




await builder.Build().RunAsync();
