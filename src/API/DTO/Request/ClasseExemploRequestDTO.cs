namespace API.DTO.Request
{
    /* Os DTOs servem para transportar dados, n�o possuem regras de neg�cio
     * e s�o imut�veis, portanto usa-se o modificador de acesso init para aceitar
     * atribui��o dos valores somente na instancia��o. Voc� n�o deve alterar
     * o que veio da requisi��o do usu�rio, apenas validar os dados.
     * Para fins de legibilidade, � importante diferenciar os DTOs de entrada
     * das respostas, nesse caso, usamos RequestDTO e ResponseDTO como sufixo
     */
	public record ClasseExemploRequestDTO
    {
        public int Propriedade1 { get; init; }
        public int Propriedade2 { get; init; }
        public string? Propriedade3 { get; init; }
        public int Propriedade4 { get; init; }
        public DateTime Propriedade5 { get; init; }
        public DateTime Propriedade6 { get; init; }
        public DateTime Propriedade7 { get; init; }
        public bool Propriedade8 { get; init; }
        public bool Propriedade9 { get; init; }
        public string? Propriedade10 { get; init; }
        public string? Propriedade11 { get; init; }
        public string? Propriedade12 { get; init; }
        public string? Propriedade13 { get; init; }
        public string? Propriedade14 { get; init; }
        public string? Propriedade15 { get; init; }
        public string? Propriedade16 { get; init; }
        public string? Propriedade17 { get; init; }
        public string? Propriedade18 { get; init; }
        public string? Propriedade19 { get; init; }
        public string? Propriedade20 { get; init; }
        public decimal? Propriedade21 { get; init; }
        public string? Propriedade22 { get; init; }
        public int Propriedade23 { get; init; }
    }
}