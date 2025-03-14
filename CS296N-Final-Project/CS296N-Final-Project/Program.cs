using System.Formats.Asn1;
using CS296N_Final_Project.Models;
using CS296N_Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


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

using (var scope = app.Services.CreateScope())
{
    await SeedUsers.CreateUsers(scope.ServiceProvider);
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedData.Seed(context, scope.ServiceProvider);
}

app.Run();