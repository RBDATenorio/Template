using Data.Caching.Replicas;
using Domain.Entities;

namespace API.Utils.Caching
{
    public interface IRedisCache
    {
        IEnumerable<ClasseExemploReplica> ObterTodosComPattern(string pattern);
        void AtualizarContagem(string chave, int valor);
        Task SalvarReplicasNoRedis(string chave, IList<ClasseExemploReplica> replica);
    }
}
