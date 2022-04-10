namespace Domain.Entities
{
    public abstract class EntidadeBase
    {
        /* propriedades comuns a todas entidades devem estar presentes
         * na classe base
         */
        public Guid Id { get; private set; }
        public DateTime CadastradoEm { get; private set; }
        public DateTime? ArquivadaEm { get; private set; }
        public bool Ativa { get; private set; }

        /* Usando GUID temos mais controle sobre as entidades, uma vez 
         que, se utilizarmos o tipo int como chave primária, então depende-
         remos do banco de dados para poder manipular as entidades nas re-
         gras de negócio que envolvam transações, especialmente para 
         recuperar os Ids */
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
            CadastradoEm = DateTime.Now;
            Ativa = true;
        }

        protected void Arquivar()
        {
            ArquivadaEm = DateTime.Now;
            Ativa = false;
        }

        protected void ativar()
        {
            Ativa = true;
        }

    }
}
