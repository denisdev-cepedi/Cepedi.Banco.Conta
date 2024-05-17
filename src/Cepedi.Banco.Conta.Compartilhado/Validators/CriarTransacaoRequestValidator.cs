using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;

public class CriarTransacaoRequestValidator : AbstractValidator<CriarTransacaoRequest>
{
    public CriarTransacaoRequestValidator()
    {
        RuleFor(x => x.IdContaOrigem)
            .NotEmpty()
            .WithMessage("IdContaOrigem é obrigatório.")
            .GreaterThan(0)
            .WithMessage("IdContaOrigem deve ser maior que 0");

        RuleFor(x => x.IdContaDestino)
            .NotEmpty()
            .WithMessage("IdContaDestino é obrigatório.")
            .GreaterThan(0)
            .WithMessage("IdContaDestino deve ser maior que 0");

        RuleFor(x => x.ValorTransacao)
            .NotEmpty()
            .WithMessage("ValorTransacao é obrigatório.")
            .GreaterThan(0)
            .WithMessage("ValorTransacao deve ser maior que 0");

        RuleFor(x => x.IdTipoTransacao)
            .IsInEnum()
            .WithMessage($"IdTipoTransacao deve ser um dos valores: {string.Join(", ", Enum.GetNames(typeof(ETipoTransacao)))}");
    }
}
