using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services 
{
    public abstract class BaseService<T> : IBaseService<T> where T : EntidadeBase
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repo)
        {
            _repository = repo;
        }

        public async Task<EntidadePaginate<T>> ObterPaginado(int skip, int take)
        {
            return await _repository.ObterPaginado(skip, take);
        }
    }
}