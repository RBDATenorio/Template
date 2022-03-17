using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : EntidadeBase
    {
        Task<IList<T>> ObterTodos();
    }
}
