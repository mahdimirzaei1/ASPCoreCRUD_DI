using Microsoft.EntityFrameworkCore;
using ASPCoreCRUD_DI.Entities;
using static System.Reflection.Metadata.BlobBuilder;
using ASPCoreCRUD_DI.Interfaces;
using ASPCoreCRUD_DI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration
    .GetConnectionString("LocalConnectionStr")));
builder.Services.AddTransient<IItem, ItemRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
