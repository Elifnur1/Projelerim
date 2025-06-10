using FakeStoreApiMVC.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ApiSettings konfigüre ediliyor
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("FakeStoreApi"));

// HttpClient ApiSettings ile konfigüre ediliyor
builder.Services.AddHttpClient("FakeStoreApi", (serviceProvider, client) =>
{
    ApiSettings apiSettings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
    client.BaseAddress = new Uri(apiSettings.BaseUrl);
});





var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
