using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class AtualizarContaRequest  : IRequest<Result<AtualizarContaResponse>>
{
    public int IdConta { get; set; }
    public EStatusConta Status { get; set; }
    public decimal LimiteTrasancao { get; set; }
    public decimal LimiteCredito { get; set; }
}
