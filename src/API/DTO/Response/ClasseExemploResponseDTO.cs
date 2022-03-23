namespace API.DTO.Response
{
    /* Importante que tenha uma ViewModel para que dados sensíveis não sejam expostos */
    public class ClasseExemploResponseDTO<T> where T : class
    {
        public int TotalItens { get; set; }
        public IList<T>? Itens { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalDePaginas { get; set; }
        public bool TemPaginaAnterior { get; set; }
        public bool TemProximaPagina { get; set; }

    }

    public class ClasseExemploResponse
    {
        public int Propriedade1 { get; set; }
        public int Propriedade2 { get; set; }
        public string? Propriedade3 { get; set; }
        public int Propriedade4 { get; set; }
        public DateTime Propriedade5 { get; set; }
        public DateTime Propriedade6 { get; set; }
        public bool Propriedade8 { get; set; }
        public bool Propriedade9 { get; set; }
        public string? Propriedade10 { get; set; }
        public string? Propriedade11 { get; set; }
        public string? Propriedade12 { get; set; }
        public string? Propriedade13 { get; set; }
        public string? Propriedade14 { get; set; }
        public string? Propriedade15 { get; set; }
        public string? Propriedade16 { get; set; }
        public string? Propriedade17 { get; set; }
        public string? Propriedade18 { get; set; }
        public string? Propriedade19 { get; set; }
        public string? Propriedade20 { get; set; }
        public decimal? Propriedade21 { get; set; }
        public string? Propriedade22 { get; set; }
        public int Propriedade23 { get; set; }
    }
}
