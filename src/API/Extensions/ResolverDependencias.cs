using API.Notification;
using API.Services;
using Domain.Interfaces;

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
            services.AddScoped<IClasseExemploService, ClasseExemploService>();

            return services;
        }
    }
}