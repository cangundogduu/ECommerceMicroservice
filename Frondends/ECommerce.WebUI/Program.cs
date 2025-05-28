using ECommerce.WebUI.Handlers;
using ECommerce.WebUI.Services.CatalogServices.CategoryServices;
using ECommerce.WebUI.Services.IdentityServices;
using ECommerce.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<TokenHandler>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection(nameof(ServiceApiSettings)));
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection(nameof(ClientSettings)));

var serviceApiSettings = builder.Configuration.GetSection(nameof(ServiceApiSettings)).Get<ServiceApiSettings>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri(serviceApiSettings.Catalog.Path);
}).AddHttpMessageHandler<TokenHandler>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Login/Index";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set the expiration time for the cookie
        options.Cookie.Name = "ECommerceCookie"; // Set a custom cookie name
        options.SlidingExpiration = true; // Enable sliding expiration
    });


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
