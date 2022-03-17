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
    }
}