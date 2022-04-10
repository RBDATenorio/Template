using API.Notification;
using Domain.Services;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Data.Repository;
using Data;
using API.Utils.Caching;
using Domain.Interfaces.Services;

namespace API.Extensions
{
    /* O objetivo de se utilizar um metodo de extensao para resolver injecao de 
     * dependencia eh somente para manter uma boa legibilidade do codigo. Especialmente
     * no .NET 6 que nao ha mais a classe Startup em casos de muitos servicos podem 
     * deixar o arquivo Program.cs muito poluido.
     */
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolverInjecaoDependencia(this IServiceCollection services)
        {
            services.AddScoped<INotificacao, Notificacao>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClasseExemploRepository, ClasseExemploRepository>();
            services.AddScoped<IClasseExemploService, ClasseExemploService>();
            services.AddScoped<IRedisCache, RedisCache>();

            return services;
        }
    }
}