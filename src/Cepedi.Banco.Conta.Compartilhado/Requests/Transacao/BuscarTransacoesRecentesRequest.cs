using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class BuscarTransacoesRecentesRequest : IRequest<Result<BuscarTransacoesRecentesResponse>>
{
    public int IdConta { get; set; }
    public int Quantidade { get; set; }
}
