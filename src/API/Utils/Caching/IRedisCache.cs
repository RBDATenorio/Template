using Domain.Entities;

namespace API.Utils.Caching
{
    public interface IRedisCache
    {
        void AtualizarContagem(string chave, int valor);
        Task SalvarReplicaNoRedis(string chave, IReplica replica);
    }
}
