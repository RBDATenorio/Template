using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntidadeBase
    {
        protected readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public Task<T> CriarEntidade()
        {
            throw new NotImplementedException();
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
    }
}
