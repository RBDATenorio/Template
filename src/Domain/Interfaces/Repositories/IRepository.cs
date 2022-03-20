using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    /* Num modelo de camadas, o domínio é agnóstico às implementações. No entanto,
     * para se evitar referências circulares, ou mesmo evitar a necessidade de se criar 
     * outro projeto só para resolver as dependências dos serviços é plausível utilizar
     * as interfaces no próprio domínio.
    */
    public interface IRepository<T> where T : EntidadeBase
    {
        Task<EntidadePaginate<T>> ObterPaginado(int skip, int take);
        Task<T> CriarEntidade();
    }
}
