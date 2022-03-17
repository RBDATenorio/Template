using API.DTO.Request;
using FluentValidation;

namespace API.DTO.Validators
{
    /* Sempre use validações das requisições. Isso pode evitar outras 
     * requisições desnecessárias, que podem estar sendo realizadas para
     * outras APIs, uma vez que desde o ínicio do fluxo de processamento
     * os dados podem estar inválidos
     */
    public class ClasseExemploRequestDTOValidator : AbstractValidator<ClasseExemploRequestDTO>
    {
        public ClasseExemploRequestDTOValidator()
        {
            RuleFor(p => p.Propriedade1)
                .GreaterThan(0)
                .WithMessage("{PropertyName} deve ser maior que zero.");

            RuleFor(p => p.Propriedade3)
                .NotEmpty()
                .WithMessage("{PropertyName} é obrigatório.");
        }
    }
}
