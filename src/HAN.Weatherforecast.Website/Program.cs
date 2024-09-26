using HAN.Weatherforecast.Website.Components;
using HAN.Weatherforecast.Website.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Environment.BaseAddress) });

var webApiBaseUrl = builder.Configuration["Endpoints:WebAPIBaseUrl"] ?? throw new InvalidOperationException("Unable to start because setting 'Endpoints:WebAPIUrl' is empty");
var webApiUri = new Uri($"{webApiBaseUrl}/api");

builder.Services.AddRefitClient<IWeatherForecastApi>()
                .ConfigureHttpClient(c => c.BaseAddress = webApiUri)
                .SetHandlerLifetime(TimeSpan.FromMinutes(2));

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
