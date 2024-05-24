// Import necessary namespaces
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using Microsoft.Extensions.DependencyInjection;

// Create a new web application
var builder = WebApplication.CreateBuilder(args);

// Configure the database context for MySQL
// Add the SalesWebMvcDbContext to the service container
// Use the connection string from the app's configuration
// Specify the MySQL server version and the assembly containing migrations
builder.Services.AddDbContext<SalesWebMvcDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcDbContext"),
        new MySqlServerVersion(new Version(5, 7, 44)), // Change this version to your MySQL version as necessary
        builder => builder.MigrationsAssembly("SalesWebMvc")));

// Add MVC services to the service container
builder.Services.AddControllersWithViews();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
// If the app is not in development mode, use exception handler and HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use custom error handling page
    app.UseHsts(); // Use HSTS for security
}

// Use HTTPS redirection and static files
app.UseHttpsRedirection();
app.UseStaticFiles();

// Use routing and authorization
app.UseRouting();
app.UseAuthorization();

// Map specific routes
// Map the route for department errors
app.MapControllerRoute(
    name: "departments_error",
    pattern: "Departments/Error",
    defaults: new { controller = "Departments", action = "Error" });

// Map the route for departments
app.MapControllerRoute(
    name: "departments",
    pattern: "Departments/{action=Index}/{id?}",
    defaults: new { controller = "Departments" });

// Default route
// Map the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();
