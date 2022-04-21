using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntidadeBase
    {
        protected readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public async Task<int> Contagem(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).CountAsync();
        }

        public async Task CriarEntidade(T entidade)
        {
            await _context.Set<T>().AddAsync(entidade);
        }

        public async Task<EntidadePaginate<T>> ObterPaginado(int skip, int take)
        {
            var totalItens = await _context.Set<T>().CountAsync();

            var dados = await  _context.Set<T>()
                                    .AsNoTracking()
                                    .Skip(skip)
                                    .Take(take)
                                    .ToListAsync();

            return new EntidadePaginate<T>(totalItens, dados, skip, take);
        }

        public async Task<IList<T>> ObterTodos()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> ObterPorProp(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
