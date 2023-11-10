using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Core.Application.Mappings;
using ApiLayer.Infrastructure.Tools;
using ApiLayer.Persistance.Context;
using ApiLayer.Persistance.Repsoitories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new
    Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
    };
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JWTContext>(opt => // bu opt ile delege geçtik
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));//appsetting deki veritabanýmýzý yolunu burdan verdik yani direk burdan da verebilrsin yolu Cors projesinde bunun örneði var 
});
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>() // map leme iþlemini sisteme tanýtýk
    {
        new ProductProfile(),
        new CategoryProfile()
    }) ;
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());//çalýþtýðým yeri otomatik ekle mediatR kütüphanesi için bunu yazdýk
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
