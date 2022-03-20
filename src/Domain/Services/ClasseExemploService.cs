using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class ClasseExemploService : BaseService<ClasseExemplo>, IClasseExemploService
    {
        public ClasseExemploService(IRepository<ClasseExemplo> repo) : base(repo)
        {

        }
    }
}
