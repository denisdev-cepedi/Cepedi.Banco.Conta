using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;

public class CriarChavePixRequestValidator : AbstractValidator<CriarChavePixRequest>
{
    public CriarChavePixRequestValidator()
    {
        RuleFor(x => x.IdConta)
            .GreaterThan(0)
            .WithMessage("IdConta deve ser maior que 0");

        RuleFor(x => x.IdTipoChavePix)
            .IsInEnum()
            .WithMessage($"IdTipoChavePix deve ser um dos valores númericos: {string.Join(", ", Enum.GetValues<ETipoPix>().Cast<ETipoPix>().Select(x => $"{(int)x} - {x}"))}");

        RuleFor(x => x.Valor)
            .NotEmpty()
            .WithMessage("Valor é obrigatório.")
            .MaximumLength(77)
            .WithMessage("Valor deve ter no máximo 77 caracteres.");
    }

}