using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTodo3.Webapi3.Common;
using MyTodo3.Webapi3.Context;
using MyTodo3.Webapi3.Repository;
using MyTodo3.Webapi3.Service;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyTodo3DbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString"]))
        .AddUnitOfWork<MyTodo3DbContext>()
        .AddCustomRepository<Todo, TodoRepository>()
        .AddCustomRepository<Memo, MemoRepository>()
        .AddCustomRepository<User, UserRepository>();
builder.Services.AddScoped<ITodoService,TodoService>();
builder.Services.AddScoped<IMemoService, MemoService>();
builder.Services.AddScoped<IUserService, UserService>();

var automapperconfig = new MapperConfiguration(config => { config.AddProfile(new AutoMapperExtentsion()); });
builder.Services.AddSingleton(automapperconfig.CreateMapper());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();