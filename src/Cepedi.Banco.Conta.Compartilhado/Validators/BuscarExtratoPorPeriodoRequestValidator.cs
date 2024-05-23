using System.Data;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using FluentValidation;

namespace Cepedi.Banco.Conta.Compartilhado.Validators;

public class BuscarExtratoPorPeriodoRequestValidator : AbstractValidator<BuscarExtratoPorPeriodoRequest>
{
    public BuscarExtratoPorPeriodoRequestValidator()
    {
        RuleFor(x => x.IdConta)
            .GreaterThan(0)
            .WithMessage("IdConta deve ser maior que 0");
            
        RuleFor(x => x.DataInicio)
            .LessThan(x => x.DataFim)
            .WithMessage("DataInicio deve ser menor que DataFim");
    }

}
