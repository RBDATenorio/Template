using API.Utils.Caching.Replicas;
using Domain.Entities;

namespace API.Utils.Caching
{
    public interface IRedisCache
    {
        Task<IEnumerable<ClasseExemploReplica>> ObterTodosComPattern(string pattern);
        void AtualizarContagem(string chave, int valor);
        Task SalvarReplicaNoRedis(string chave, IReplica replica);
    }
}
