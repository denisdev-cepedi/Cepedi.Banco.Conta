using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;
public class FazerSaqueContaRequestValidator : AbstractValidator<FazerSaqueContaRequest>
{
    public FazerSaqueContaRequestValidator()
    {
        RuleFor(x => x.IdConta)
            .NotEmpty()
            .WithMessage("O Id da conta é obrigatório.")
            .GreaterThan(0)
            .WithMessage("O Id da conta deve ser maior que zero.");

        RuleFor(x => x.ValorSaque)
            .NotEmpty()
            .WithMessage("O valor do saque é obrigatório.")
            .GreaterThan(0)
            .WithMessage("O valor do saque deve ser maior que zero.");
    }

}
