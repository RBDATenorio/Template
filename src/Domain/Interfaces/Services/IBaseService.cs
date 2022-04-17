using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : EntidadeBase
    {
        Task<EntidadePaginate<T>> ObterPaginado(int skip, int take);
        Task CriarEntidade(T entidade);
        Task<bool> SalvarAlteracoes();
        Task<int> ObterContagem(Expression<Func<T, bool>> predicate);
    }
}
