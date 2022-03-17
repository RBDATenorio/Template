using Domain.Entities;
using Domain.Interfaces.Services;

namespace API.Services 
{
    public abstract class BaseService<T> : IBaseService<T> where T : EntidadeBase
    {
        public async Task<IList<T>> ObterTodos()
        {

            return await Task.FromResult(new List<T>());
        }
    }
}