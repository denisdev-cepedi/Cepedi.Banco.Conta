using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado;

public class CriarContaRequest : IRequest<Result<CriarContaResponse>>
{
    public int IdPessoa { get; set; }
    public required string Agencia { get; set; }
    public required string Numero { get; set; }
    public decimal Saldo { get; set; }
}
