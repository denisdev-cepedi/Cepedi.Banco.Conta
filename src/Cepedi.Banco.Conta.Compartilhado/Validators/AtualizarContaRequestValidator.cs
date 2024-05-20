using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;

public class AtualizarContaRequestValidator : AbstractValidator<AtualizarContaRequest>
{
    public AtualizarContaRequestValidator()
    {
        RuleFor(x => x.IdConta)
            .GreaterThan(0)
            .WithMessage("IdConta deve ser maior que 0");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage($"Status deve ser um dos valores númericos: {string.Join(", ", Enum.GetValues<EStatusConta>().Cast<EStatusConta>().Select(x => $"{(int)x} - {x}"))}");

        RuleFor(x => x.LimiteTrasancao)
            .GreaterThanOrEqualTo(0)
            .WithMessage("LimiteTrasancao deve ser maior ou igual a 0");

        RuleFor(x => x.LimiteCredito)
            .GreaterThanOrEqualTo(0)
            .WithMessage("LimiteCredito deve ser maior ou igual a 0");
    }

}
