using Domain.Entities;
using Domain.Interfaces.Services;
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
            throw new NotImplementedException();
            // var contador = 0;

            // if(contagem?.Value != 0)
            // {
            //     //var objetoEmCache = await _cache.GetAsync(chave);
            //     var objetoEmCache = _cache.Get(chave.Split(':')[0]);

            //     if (objetoEmCache is null)
            //     {
            //         _cache.Set(chave.Split(':')[0], Encoding.UTF8.GetBytes(1.ToString()), new DistributedCacheEntryOptions());
            //     }

            //     else
            //     {
            //         //var obejtoEmCache = JsonConvert.DeserializeObject<ClasseExemploReplica>(_cache.GetString("classeExemplo:e1887af2-4d99-4391-88fe-bf95e2b5622f"));
            //         contador = Int32.Parse(_cache.GetString(chave.Split(':')[0]));
            //     }
            // }

            // var replicaSerialized = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(replica));
            
            // var options = new DistributedCacheEntryOptions()
            //                     .SetAbsoluteExpiration(DateTime.Now.AddDays(30));
            
            // await _cache.SetAsync(chave, replicaSerialized, options);
            // if(contagem?.Value != 0)
            // {
            //     var adicionar = contagem?.Value ?? 0;

            //     contador += adicionar;

            //     _cache.Set(contagem?.Key, Encoding.UTF8.GetBytes(contador.ToString()), new DistributedCacheEntryOptions());
            // }
        }
    }
}
