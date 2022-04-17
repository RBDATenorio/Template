using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace Domain.Services 
{
    public abstract class BaseService<T> : IBaseService<T> where T : EntidadeBase
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IRepository<T> repo, 
                            IUnitOfWork unitOfWork)
        {
            _repository = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task CriarEntidade(T entidade)
        {
            await _repository.CriarEntidade(entidade);
        }

        public async Task<EntidadePaginate<T>> ObterPaginado(int skip, int take)
        {
            return await _repository.ObterPaginado(skip, take);
        }

        public async Task<int> ObterContagem(Expression<Func<T, bool>> predicate)
        {
            return await _repository.Contagem(predicate);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return await _unitOfWork.Commit();
        }
    }
}