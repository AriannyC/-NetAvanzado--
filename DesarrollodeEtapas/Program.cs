using Microsoft.EntityFrameworkCore;
using Desarrollo.Core.Persistencia.Context;
using Desarrollo.Core.Aplication.Services;
using Desarrollo.Core.Persistencia.Repositories.Common;
using Desarrollo.Core.Domain.Models;
using Desarrollo.Core.Persistencia.Repositories.Repository;



var builder = WebApplication.CreateBuilder(args);

var ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProcess <ModGene>,ModRepository >();
builder.Services.AddScoped<DTOServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Applicationcontex>(options=> options.UseSqlServer(ConnectionStrings));
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
