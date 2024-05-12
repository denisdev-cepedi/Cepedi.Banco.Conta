using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class BuscarSaldoContaRequest : IRequest<Result<BuscarSaldoContaResponse>>
{
    public int IdPessoa { get; set; }
}
