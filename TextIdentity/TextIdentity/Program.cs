using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TextIdentity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    //…Ë÷√√‹¬Î∏¥‘”∂»
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["databaseString"]));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
