using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class BuscarTransacaoRequest : IRequest<Result<BuscarTransacaoResponse>>
{
    public int IdTransacao { get; set; }
}
