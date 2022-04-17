namespace API.Utils.Caching.Replicas
{
    public class ClasseExemploReplica : IReplica
    {
        public Guid Id { get; private set; }
        public int Propriedade1 { get; private set; }
        public int Propriedade2 { get; private set; }
        public string? Propriedade3 { get; private set; }
        public DateTime? ArquivadaEm { get; private set; }

        public ClasseExemploReplica(Guid id,
                                    int propriedade1,
                                    int propriedade2,
                                    string? propriedade3,
                                    DateTime? arquivadaEm) 
        {
            Id = id;
            Propriedade1 = propriedade1;
            Propriedade2 = propriedade2;
            Propriedade3 = propriedade3;
            ArquivadaEm = arquivadaEm;
        }
    }
}
