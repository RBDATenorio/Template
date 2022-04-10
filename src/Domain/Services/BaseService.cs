using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services 
{
    public abstract class BaseService<T> : IBaseService<T> where T : EntidadeBase
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRedisCache _cache;

        public BaseService(IRepository<T> repo, 
                            IUnitOfWork unitOfWork, 
                            IRedisCache cache)
        {
            _repository = repo;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task CriarEntidade(T entidade)
        {
            await _repository.CriarEntidade(entidade);
        }

        public async Task<EntidadePaginate<T>> ObterPaginado(int skip, int take)
        {
            return await _repository.ObterPaginado(skip, take);
        }

        public async Task<bool> SalvarAlteracoes(Replica? replica, KeyValuePair<string, int>? contador, string chave = "")
        {
            var salvouAlteracoes = await _unitOfWork.Commit();

            if(salvouAlteracoes)
            {
                if (replica != null && chave != "") await _cache.SalvarNoRedis(replica, contador, chave);

                return true;
            }

            return false;
        }
    }
}