namespace API.DTO.Request
{
    /* Os DTOs servem para transportar dados, não possuem regras de negócio
     * e são imutáveis, portanto usa-se o modificador de acesso init para aceitar
     * atribuição dos valores somente na instanciação. Você não deve alterar
     * o que veio da requisição do usuário, apenas validar os dados.
     * Para fins de legibilidade, é importante diferenciar os DTOs de entrada
     * das respostas, nesse caso, usamos RequestDTO e ResponseDTO como sufixo
     */
	public record ClasseExemploRequestDTO
    {
        public int Propriedade1 { get; init; }
        public int Propriedade2 { get; init; }
        public string? Propriedade3 { get; init; }
    }
}