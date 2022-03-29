namespace API.Utils.Caching
{
    public interface IRedisCache
    {
        Task SalvarNoRedis(Replica replica);
    }
}
