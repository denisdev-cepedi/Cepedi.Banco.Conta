using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado;

public class BuscarTransacaoPorContaRequest : IRequest<Result<BuscarTransacaoPorContaResponse>>
{
    public int IdConta { get; set; }
}
