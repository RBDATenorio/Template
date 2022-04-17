using Domain.Entities;

namespace API.Utils.Caching
{
    public class ClasseExemploReplica : IReplica
    {
        public int Propriedade1 { get; private set; }
        public int Propriedade2 { get; private set; }
        public string? Propriedade3 { get; private set; }
        public DateTime? ArquivadaEm { get; private set; }

        public ClasseExemploReplica(int propriedade1,
                                    int propriedade2,
                                    string? propriedade3,
                                    DateTime? arquivadaEm) 
        {
            Propriedade1 = propriedade1;
            Propriedade2 = propriedade2;
            Propriedade3 = propriedade3;
            ArquivadaEm = arquivadaEm;
        }
    }
}
