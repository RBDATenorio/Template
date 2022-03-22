namespace Domain.Entities
{
    /* Todas as entidades devem seguir os principios do SOLID
     * Para cumprir o Open-Closed Principle, as classes
     * devem estar fechadas para modificações e abertas para extensão.
     * Assim, os valores das propriedades devem ser atribuídos na
     * instanciação, por isso usamos private para os setters
     */
    public class ClasseExemplo : EntidadeBase
    {
        public int Propriedade1 { get; private set; }
        public int Propriedade2 { get; private set; }
        public string? Propriedade3 { get; private set; }
        public int Propriedade4 { get; private set; }
        public DateTime Propriedade5 { get; private set; }
        public DateTime Propriedade6 { get; private set; }
        public DateTime Propriedade7 { get; private set; }
        public bool Propriedade8 { get; private set; }
        public bool Propriedade9 { get; private set; }
        public string? Propriedade10 { get; private set; }
        public string? Propriedade11 { get; private set; }
        public string? Propriedade12 { get; private set; }
        public string? Propriedade13 { get; private set; }
        public string? Propriedade14 { get; private set; }
        public string? Propriedade15 { get; private set; }
        public string? Propriedade16 { get; private set; }
        public string? Propriedade17 { get; private set; }
        public string? Propriedade18 { get; private set; }
        public string? Propriedade19 { get; private set; }
        public string? Propriedade20 { get; private set; }
        public decimal? Propriedade21 { get; private set; }
        public string? Propriedade22 { get; private set; }
        public int Propriedade23 { get; private set; }



        public IList<ClasseExemplo2> PropriedadeDeNavegacao { get; private set; } = new List<ClasseExemplo2>();

        protected ClasseExemplo() { }

        public ClasseExemplo(int prop1, int prop2, string prop3)
        {
            Propriedade1 = prop1;
            Propriedade2 = prop2;
            Propriedade3 = prop3;
        }

        public bool AlterarValorDaPropriedadeDeNavegacao(int novoValor, int idPropriedadeDeNavegacao) 
        {
            /* Importante que no service seja feita a validação e que
             * o usuário seja notificado seguindo o Notification Pattern.
             * No entanto, as entidades devem se autovalidar, para garantir 
             * a consistência das informações. E nesse último estágio deve
             * ser lançada uma exceção.
             */
            if (novoValor < 0) throw new ArgumentOutOfRangeException("Valor da Propriedade1", "Precisa ser maior que zero.");
            
            return true;
        }
    }
}
