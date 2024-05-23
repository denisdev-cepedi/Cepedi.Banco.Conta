using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class RemoverChavePixRequest : IRequest<Result<RemoverChavePixResponse>>
{
    public int IdChavePix { get; set; }
}
