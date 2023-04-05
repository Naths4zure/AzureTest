using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AzureTest.Data;
using AzureTest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AzureTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING") 
    ?? throw new InvalidOperationException("Connection string 'AzureTestContext' not found.")));

var app = builder.Build();

// Add Movies
using (var scope = app.Services.CreateScope())      // Create the Scope
{
    var services = scope.ServiceProvider;           // Create the ServiceProvider
    SeedData.Initialize(services);                  // Run SeedData.Initialize() to populate the database with movies
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
