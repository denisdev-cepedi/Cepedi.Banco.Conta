using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;
public class CriarChavePixRequest : IRequest<Result<CriarChavePixResponse>>
{
    public int IdConta { get; set; } = default!;
    public ETipoPix IdTipoChavePix { get; set; }
    public string Valor { get; set; } = default!;
}
