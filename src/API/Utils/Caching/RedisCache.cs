using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace API.Utils.Caching
{
    public class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _cache;

        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public void AtualizarContagem(string chave, int valor)
        {
            if(chave != "")
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
