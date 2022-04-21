using API.Utils.Caching.Replicas;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace API.Utils.Caching
{
    public class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _cache;
        private readonly IRedisConnectionMultiplexer _conn;
        private readonly IList<ClasseExemploReplica> _replicas;

        public RedisCache(IDistributedCache cache, IRedisConnectionMultiplexer conn)
        {
            _cache = cache;
            _conn = conn;
            _replicas = new List<ClasseExemploReplica>();
        }

        public IEnumerable<ClasseExemploReplica> ObterTodosComPattern(string pattern)
        {
            var objetosEmCache = _cache.GetString(pattern);
            var replicaSerialized = JsonConvert.DeserializeObject<IList<ClasseExemploReplica>>(objetosEmCache);

            return replicaSerialized;
        }

        public void AtualizarContagem(string chave, int valor)
        {
            if (chave != "")
            {
                _cache.Set(chave, Encoding.UTF8.GetBytes(valor.ToString()), new DistributedCacheEntryOptions());
            }
        }

        public async Task SalvarReplicasNoRedis(string chave, IList<ClasseExemploReplica> replica)
        {
            var replicasSerialized = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(replica));
            var options = new DistributedCacheEntryOptions()
                 .SetAbsoluteExpiration(DateTime.Now.AddDays(30));
            await _cache.SetAsync(chave, replicasSerialized, options);
        }
    }
}
