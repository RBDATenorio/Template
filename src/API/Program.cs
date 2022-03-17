using API.Extensions;
using API.MapperConfiguration;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* Importante efetuar as valida��es dos DTOs para que n�o se permita prosseguir com o 
 * fluxo de processamento caso os dados da requisi��o estejam inv�lidos. */
builder.Services.AddControllers().AddFluentValidation(fv => 
                            fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(typeof(MapperConfig));
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
