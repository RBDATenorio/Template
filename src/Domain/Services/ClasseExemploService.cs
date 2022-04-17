using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ClasseExemploService : BaseService<ClasseExemplo>, IClasseExemploService
    {
        public ClasseExemploService(IClasseExemploRepository repo, IUnitOfWork uow) : base(repo, uow) { }
    }
}
