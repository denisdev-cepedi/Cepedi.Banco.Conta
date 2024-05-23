using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;

public class BuscarExtratoPorMesRequestValidator :AbstractValidator<BuscarExtratoPorMesRequest>
{
    public BuscarExtratoPorMesRequestValidator()
    {
        RuleFor(x => x.IdConta)
            .GreaterThan(0)
            .WithMessage("IdConta deve ser maior que 0");

        RuleFor(x => x.Mes)
            .InclusiveBetween(1, 12)
            .WithMessage("Mes deve ser um valor entre 1 e 12");

        RuleFor(x => x.Ano)
            .GreaterThan(0)
            .WithMessage("Ano deve ser maior que 0");
    }
}
