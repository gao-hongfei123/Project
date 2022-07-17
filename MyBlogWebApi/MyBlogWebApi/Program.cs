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
        Title = "API����",
        Description = "API����"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�",
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
//ע��������д����չ����
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



//sqlsugarע��
SugarIocServices.AddSqlSugar(new IocConfig()
{
    ConnectionString = builder.Configuration["SqlConn"],
    DbType = IocDbType.SqlServer,
    IsAutoCloseConnection = true//�Զ��ͷ�
}); ;

//automapperע��
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


//дһ����չ��������ע�룬�����������࣬Ϊservices���һ����չ����
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
