using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class AtualizarChavePixRequest : IRequest<Result<AtualizarChavePixResponse>>, IValida
{
    public int IdChavePix { get; set; }
    public int IdConta { get; set; }
    public string Valor { get; set; } = default!;
    public ETipoPix IdTipoChavePix { get; set; }

}
