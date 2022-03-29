namespace API.Utils.Caching
{
    public abstract class Replica
    {
        public string CacheKey { get; private set; } = string.Empty;

        public void InserirCachaKey(string cacheKey)
        {
            CacheKey = cacheKey;
        }
    }
}
