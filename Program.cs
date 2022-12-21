using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAppTask.Data;
using WebAppTask.Models;
using WebAppTask.Models.Database;
using WebAppTask.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AuditReadContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuditReadContext") ?? throw new InvalidOperationException("Connection string 'AuditReadContext' not found.")));
builder.Services.AddDbContext<AuditContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuditContext") ?? throw new InvalidOperationException("Connection string 'AuditContext' not found.")));
builder.Services.AddDbContext<ProductsDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDataContext") ?? throw new InvalidOperationException("Connection string 'ProductsDataContext' not found.")));
builder.Services.AddDbContext<MovieDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDataContext") ?? throw new InvalidOperationException("Connection string 'MovieDataContext' not found.")));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn") ?? throw new InvalidOperationException("Connection string 'conn' not found.")));

// For Identity  
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Login");

//add services to container
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddSession();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
