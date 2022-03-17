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
