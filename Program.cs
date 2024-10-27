using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);


String? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ?? "otra cadena";

builder.Services.AddControllers();
 
builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseMySQL(cadena));


       // opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//esta linea es para conectar con sqlserver
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();