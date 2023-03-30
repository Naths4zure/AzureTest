using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AzureTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AzureTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureTestContext") 
    ?? throw new InvalidOperationException("Connection string 'AzureTestContext' not found.")));

var app = builder.Build();

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
