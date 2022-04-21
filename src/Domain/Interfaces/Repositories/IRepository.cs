using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    /* Num modelo de camadas, o domínio é agnóstico às implementações. No entanto,
     * para se evitar referências circulares, ou mesmo evitar a necessidade de se criar 
     * outro projeto só para resolver as dependências dos serviços é plausível utilizar
     * as interfaces no próprio domínio.
    */
    public interface IRepository<T> : IDisposable where T : EntidadeBase
    {
        Task<IList<T>> ObterTodos();
        Task<EntidadePaginate<T>> ObterPaginado(int skip, int take);
        Task CriarEntidade(T entidade);
        Task<IEnumerable<T>> ObterPorProp(Expression<Func<T, bool>> predicate);
        Task<int> Contagem(Expression<Func<T, bool>> predicate);
    }
}
