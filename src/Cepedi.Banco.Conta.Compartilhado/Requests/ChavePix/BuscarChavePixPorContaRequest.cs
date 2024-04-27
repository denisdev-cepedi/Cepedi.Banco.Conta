using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class BuscarChavePixPorContaRequest : IRequest<Result<BuscarChavePixPorContaResponse>>
{
    public int IdConta { get; set; }
}
