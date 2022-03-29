using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace API.Utils.Caching
{
    public abstract class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _cache;

        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SalvarNoRedis(Replica replica)
        {
            var replicaSerialized = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(replica));
            
            var options = new DistributedCacheEntryOptions()
                                .SetAbsoluteExpiration(DateTime.Now.AddDays(30));

            await _cache.SetAsync(replica.CacheKey, replicaSerialized, options);
        }
    }
}
