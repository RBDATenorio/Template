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

        public async Task<IEnumerable<ClasseExemploReplica>> ObterTodosComPattern(string pattern)
        {
            var chaves = _conn.GetKeys(pattern).ToList();
            
            foreach(var chave in chaves)
            {
                var replica = JsonConvert.DeserializeObject<ClasseExemploReplica>(_cache.GetString(chave.ToString()));
                
                if(replica != null) _replicas.Add(replica);
            }

            return _replicas;
        }

        public async void AtualizarContagem(string chave, int valor)
        {
            if (chave != "")
            {
                _cache.Set(chave, Encoding.UTF8.GetBytes(valor.ToString()), new DistributedCacheEntryOptions());
            }
        }

        public async Task SalvarReplicaNoRedis(string chave, IReplica replica)
        {
            if(chave != "")
            {
                var replicaSerialized = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(replica));
                var options = new DistributedCacheEntryOptions()
                                 .SetAbsoluteExpiration(DateTime.Now.AddDays(30));
                await _cache.SetAsync(chave, replicaSerialized, options);
            }
        }
    }
}
