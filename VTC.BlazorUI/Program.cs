using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Charts;
using VTC.BlazorUI.Components;
using VestasTestChallenge;
using VestasTestChallenge.Interfaces;
using VTC.Database;
using VTC.Database.Interfaces;
using VTC.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddDbContext<AppDbContext>()
    .AddScoped<IDatabaseConnection, DatabaseConnection>();

builder.Services.AddScoped<ITestSimulator, TestSimulator>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddBlazorise(options => { options.Immediate = true; })
    .AddBootstrapProviders();

var app = builder.Build();

app.MapHub<TestResultHub>("/testResultHub");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();