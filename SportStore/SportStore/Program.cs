using Microsoft.EntityFrameworkCore;
using SportStore.Models;
using SportStore.Models.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(options=>options.EnableEndpointRouting=false);
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
//这是商品中使用的数据库
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString"]));
//这是identity用户数据库
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(builder.Configuration["IdentityConnectionString"]));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseAuthentication(); 
app.UseRouting();
//自己设置的路由模板
app.UseMvc(routes => {
           routes.MapRoute(
           name: "default",
           template: "{controller=Product}/{action=List}/{id?}");});//默认为该参数
app.Run();





