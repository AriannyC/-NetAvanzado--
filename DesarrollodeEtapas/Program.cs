using Microsoft.EntityFrameworkCore;
using Desarrollo.Core.Persistencia.Context;
using Desarrollo.Core.Aplication.Services;
using Desarrollo.Core.Persistencia.Repositories.Common;
using Desarrollo.Core.Domain.Models;
using Desarrollo.Core.Persistencia.Repositories.Repository;
using Desarrollo.Core.Persistencia.TokenJWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Applicationcontex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProcess <ModGene>,ModRepository >();
builder.Services.AddScoped<DTOServices>();
builder.Services.AddScoped<TOKEN>();
builder.Services.AddHttpContextAccessor();



builder.Services.AddAuthentication(confi =>
{
    confi.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    confi.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer(confi =>
{
    confi.RequireHttpsMetadata = false;
    confi.SaveToken = true;
    confi.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
    };
});


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
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
