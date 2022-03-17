namespace Domain.Entities
{
    public abstract class EntidadeBase
    {
        /* propriedades comuns a todas entidades devem estar presentes
         * na classe base
         */
        public int Id { get; private set; }
        public DateTime CadastradoEm { get; private set; }
        public DateTime? ArquivadaEm { get; private set; }
        public bool Ativa { get; private set; }

        public EntidadeBase()
        {
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
