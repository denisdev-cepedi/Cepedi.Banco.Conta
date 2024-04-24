using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class ExtratoContaRequest : IRequest<Result<ExtratoContaResponse>>
{
    public int IdConta { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}
