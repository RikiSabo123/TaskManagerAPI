using AutoMapper;
using BLL;
using DAL;
using DAL.models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use connection string from appsettings.json
builder.Services.AddDbContext<TaskManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskManagerDb")));

builder.Services.AddScoped<IUser, BLL.User>();
builder.Services.AddScoped<ICategory, BLL.Category>();
builder.Services.AddScoped<ITask, BLL.Task>();
builder.Services.AddScoped<Idb, DBConnect>();

builder.Services.AddSingleton<IMapper>(_ =>
    new MapperConfiguration(cfg => cfg.AddProfile<DAL.Mapper>()).CreateMapper());

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
