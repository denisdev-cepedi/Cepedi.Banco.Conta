using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;

public class CriarContaRequestValidator : AbstractValidator<CriarContaRequest>
{
    public CriarContaRequestValidator()
    {
        RuleFor(x => x.IdPessoa)
            .GreaterThan(0)
            .WithMessage("IdPessoa deve ser maior que 0");

        RuleFor(x => x.Agencia)
            .NotEmpty()
            .WithMessage("Agencia é obrigatória.")
            .Matches(@"^\d{4}$")
            .WithMessage("Agencia deve ter exatamente 4 caracteres numéricos.");

        RuleFor(x => x.Numero)
            .NotEmpty()
            .WithMessage("Numero é obrigatório.")
            .Matches(@"^\d{6}$")
            .WithMessage("Numero deve ter exatamente 6 caracteres numéricos.");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage($"Status deve ser um dos valores: {string.Join(", ", Enum.GetNames(typeof(EStatusConta)))}");

        RuleFor(x => x.LimiteTrasancao)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O Limite de Transação deve ser maior ou igual a zero.");

        RuleFor(x => x.LimiteCredito)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O Limite de Crédito deve ser maior ou igual a zero.");

        RuleFor(x => x.Saldo)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O Saldo deve ser maior ou igual a zero.");
    }
}
