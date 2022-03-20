namespace Domain.Entities
{
    public class EntidadePaginate<T> where T : EntidadeBase
    {
        public int TotalItens { get; private set; }
        public IList<T> Itens { get; private set; }
        public int TamanhoPagina { get; private set; }
        public int TotalDePaginas { get; private set; }
        public bool TemPaginaAnterior { get; private set; }
        public bool TemProximaPagina { get; private set; }

        public EntidadePaginate(int totalItens, IList<T> itens, int indicePagina, int tamanhoPagina)
        {
            TotalItens = totalItens;
            Itens = itens;
            TamanhoPagina = tamanhoPagina;
            TotalDePaginas = (int) Math.Ceiling(TotalItens / (double) TamanhoPagina);
            TemPaginaAnterior = indicePagina > 0;
            TemProximaPagina = (indicePagina+1) < TotalDePaginas;
        }




    }
}
