using StackExchange.Redis;

namespace API.Utils.Caching
{
    public class RedisConnectionMultiplexer : IRedisConnectionMultiplexer
    {
        private readonly ConnectionMultiplexer _connection;

        public RedisConnectionMultiplexer()
        {
            _connection = ConnectionMultiplexer.Connect("localhost:6379");
        }

        public IEnumerable<RedisKey> GetKeys(string pattern)
        {
            return _connection.GetServer("localhost", 6379).Keys(pattern: pattern);
            
        }
    }
}
