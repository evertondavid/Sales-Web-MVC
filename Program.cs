using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configure the database context for MySQL
builder.Services.AddDbContext<SalesWebMvcDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcDbContext"),
        new MySqlServerVersion(new Version(5, 7, 44)), // Change this version to your MySQL version as necessary
        builder => builder.MigrationsAssembly("SalesWebMvc")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Map specific routes
app.MapControllerRoute(
    name: "departments_error",
    pattern: "Departments/Error",
    defaults: new { controller = "Departments", action = "Error" });

app.MapControllerRoute(
    name: "departments",
    pattern: "Departments/{action=Index}/{id?}",
    defaults: new { controller = "Departments" });

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
