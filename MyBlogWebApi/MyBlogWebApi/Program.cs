using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyBlog.IRespository;
using MyBlog.Respository;
using MyBlogWebApi.Utility.automapper;
using SqlSugar.IOC;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API标题",
        Description = "API描述"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
        Name = "Authorization",
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference=new OpenApiReference
              {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
              }
            },
            new string[] {}
          }
        });
});
builder.Services.AddControllers();
//注入下面手写的扩展方法
builder.Services.AddCustomIoc();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
    {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ghf.303515.096.aaa")),
        ValidateIssuer = true,
        ValidIssuer = "http://locolhost:7119",
        ValidateAudience = true,
        ValidAudience = "http://localhost:44339",
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(60)
    };
});



//sqlsugar注入
SugarIocServices.AddSqlSugar(new IocConfig()
{
    ConnectionString = builder.Configuration["SqlConn"],
    DbType = IocDbType.SqlServer,
    IsAutoCloseConnection = true//自动释放
}); ;

//automapper注册
builder.Services.AddAutoMapper(typeof(CustomAutoMapperProfile));




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "webapi2 v1"));

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


//写一个拓展方法用来注入，这样代码整洁，为services添加一个拓展方法
public static class IOCExtend
{
    public static IServiceCollection AddCustomIoc(this IServiceCollection services)
    {
        services.AddScoped<BlogNewsIRespository, BlogNewsRespository>();
        services.AddScoped<TypeInfoIRespository, TypeInfoRespository>();
        services.AddScoped<WriterIRespository, WriterRespository>();
        return services;
    }
}
