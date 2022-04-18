using StackExchange.Redis;

namespace API.Utils.Caching
{
    public interface IRedisConnectionMultiplexer
    {
        IEnumerable<RedisKey> GetKeys(string pattern);
    }
}
