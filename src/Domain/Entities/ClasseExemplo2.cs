namespace Domain.Entities
{
    public class ClasseExemplo2 : EntidadeBase
    {
        public int Propriedade1 { get; private set; }

        protected ClasseExemplo2() { }

        public ClasseExemplo2(int propriedade1)
        {
            Propriedade1 = propriedade1;
        }
    }


}
