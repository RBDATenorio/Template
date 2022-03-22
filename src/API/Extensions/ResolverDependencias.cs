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
    /* O objetivo de se utilizar um m�todo de extens�o para resolver inje��o de 
     * depend�ncia � somente para manter uma boa legibilidade do c�digo. Especialmente
     * no .NET 6 que n�o h� mais a classe Startup em casos de muitos servi�os podem 
     * deixar o arquivo Program.cs muito polu�do.
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