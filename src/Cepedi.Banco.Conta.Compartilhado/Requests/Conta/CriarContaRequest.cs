using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class CriarContaRequest : IRequest<Result<CriarContaResponse>>
{
    public int IdPessoa { get; set; }
    public required string Agencia { get; set; }
    public required string Numero { get; set; }
    public EStatusConta Status { get; set; }
    public decimal LimiteTrasancao { get; set; }
    public decimal LimiteCredito { get; set; }
    public decimal Saldo { get; set; }
}
