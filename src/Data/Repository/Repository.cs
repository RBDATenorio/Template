using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntidadeBase
    {
        protected readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public async Task<T> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
