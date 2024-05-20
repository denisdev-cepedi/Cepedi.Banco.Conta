using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class FazerSaqueContaRequest  : IRequest<Result<FazerSaqueContaResponse>>, IValida
{
    public int IdConta { get; set; }
    public decimal ValorSaque { get; set; }
}