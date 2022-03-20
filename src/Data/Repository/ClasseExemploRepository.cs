using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repository
{
    public class ClasseExemploRepository : Repository<ClasseExemplo>, IClasseExemploRepository
    {
        public ClasseExemploRepository(Context context) : base(context)
        {

        }
    }
}
