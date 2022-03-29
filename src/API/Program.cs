using API.Extensions;
using API.MapperConfiguration;
using API.Utils;
using Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* Importante efetuar as validações dos DTOs para que não se permita prosseguir com o 
 * fluxo de processamento caso os dados da requisição estejam inválidos. */
builder.Services.AddControllers().AddFluentValidation(fv => 
                            fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(typeof(MapperConfig));

var connectionConfig =
    builder.Configuration.GetSection("TemplateConnection").Get<ConnectionSettings>(); 

builder.Services.AddDbContext<Context>(opt => 
                           opt.UseSqlServer(connectionConfig.ConnectionString));

builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");

builder.Services.ResolverInjecaoDependencia();

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
