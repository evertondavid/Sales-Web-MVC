// Import necessary namespaces
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Services;

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

// Register SeedingService for dependency injection.
// Scoped lifetime services are created once per client request (connection).
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();

// Add MVC services to the service container
builder.Services.AddControllersWithViews();

// Build the application
var app = builder.Build();

// Get an instance of SeedingService
using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<SeedingService>();

// Configure the HTTP request pipeline.
// If the app is not in development mode, use exception handler and HSTS
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use custom error handling page
    app.UseHsts(); // Use HSTS for security
    // Call the SeedDatabase method to populate the database
    seeder.Seed();
}

// Use HTTPS redirection and static files
app.UseHttpsRedirection();
app.UseStaticFiles();

// Use routing and authorization
app.UseRouting();
app.UseAuthorization();

// Default route
// Map the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();
