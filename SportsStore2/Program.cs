using Microsoft.EntityFrameworkCore;
using SportsStore2.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapGet("/hi", () => "Hello!");
app.MapControllerRoute(
    name: null,
    pattern: "{category}/Page{page:int}",
    defaults: new { Controller = "Product", action = "List" });

app.MapControllerRoute(
    name: null,
    pattern: "Page{page:int}",
    defaults: new { Controller = "Product", action = "List", page = 1 });

app.MapControllerRoute(
    name: null,
    pattern: "{category}",
    defaults: new { Controller = "Product", action = "List", page = 1 });

app.MapControllerRoute(
    name: null,
    pattern: "",
    defaults: new { Controller = "Product", action = "List", page = 1 });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");
app.UseSession();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();
