using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class FazerDepositoContaRequest  : IRequest<Result<FazerDepositoContaResponse>>, IValida
{
    public int IdConta { get; set; }
    public decimal ValorDeposito { get; set; }
}