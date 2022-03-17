using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        /* Para evitar os avisos do compilador sobre propriedades não nulas 
         * podemos usar essa abordagem */
        public DbSet<ClasseExemplo> ClasseExemplos => Set<ClasseExemplo>();
        public DbSet<ClasseExemplo2> ClasseExemplos2 => Set<ClasseExemplo2>();
    }
}
