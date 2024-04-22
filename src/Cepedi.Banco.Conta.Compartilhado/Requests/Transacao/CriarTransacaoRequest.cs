using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;
public class CriarTransacaoRequest : IRequest<Result<CriarTransacaoResponse>>
{
    public int IdContaOrigem { get; set; } = default!;
    public int IdContaDestino { get; set; } = default!;
    public DateTime DataTransacao { get; set; } = default!;
    public int ValorTransacao { get; set; } = default!;
    public ETipoTransacao IdTipoTransacao { get; set; } = default!;
}
