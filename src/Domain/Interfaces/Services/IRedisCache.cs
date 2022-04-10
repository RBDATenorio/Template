using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IRedisCache
    {
        Task SalvarNoRedis(Replica replica, KeyValuePair<string, int>? contagem,  string chave);
    }
}
