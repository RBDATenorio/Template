using API.Notification;
using Domain.Services;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Data.Repository;
using Domain.Entities;
using Domain.Interfaces.Services;
using Data;

namespace API.Extensions
{
    /* O objetivo de se utilizar um método de extensão para resolver injeção de 
     * dependência é somente para manter uma boa legibilidade do código. Especialmente
     * no .NET 6 que não há mais a classe Startup em casos de muitos serviços podem 
     * deixar o arquivo Program.cs muito poluído.
     */
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolverInjecaoDependencia(this IServiceCollection services)
        {
            services.AddScoped<INotificacao, Notificacao>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClasseExemploRepository, ClasseExemploRepository>();
            services.AddScoped<IClasseExemploService, ClasseExemploService>();

            return services;
        }
    }
}