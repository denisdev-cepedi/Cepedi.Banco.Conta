using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;
public class FazerDepositoContaRequestValidator : AbstractValidator<FazerDepositoContaRequest>
{
    public FazerDepositoContaRequestValidator()
    {
        RuleFor(x => x.IdConta)
            .NotEmpty()
            .WithMessage("O Id da conta é obrigatório.")
            .GreaterThan(0)
            .WithMessage("O Id da conta deve ser maior que zero.");

        RuleFor(x => x.ValorDeposito)
            .GreaterThan(0)
            .WithMessage("O valor do depósito deve ser maior que zero.");
    }
}
