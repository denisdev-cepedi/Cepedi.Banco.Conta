using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;

public class AtualizarChavePixRequestValidator : AbstractValidator<AtualizarChavePixRequest>
{
    public AtualizarChavePixRequestValidator()
    {
        RuleFor(x => x.IdChavePix)
            .GreaterThan(0)
            .WithMessage("IdChavePix deve ser maior que 0");

        RuleFor(x => x.IdConta)
            .GreaterThan(0)
            .WithMessage("IdConta deve ser maior que 0");

        RuleFor(x => x.Valor)
            .NotEmpty()
            .WithMessage("Valor é obrigatório.")
            .MaximumLength(77)
            .WithMessage("Valor deve ter no máximo 77 caracteres.");

        RuleFor(x => x.IdTipoChavePix)
            .IsInEnum()
            .WithMessage($"IdTipoChavePix deve ser um dos valores: {string.Join(", ", Enum.GetNames(typeof(ETipoPix)))}");
    }
}
