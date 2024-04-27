using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class AtualizarChavePixRequest : IRequest<Result<AtualizarChavePixResponse>>
{
    public int IdChavePix { get; set; }
    public int IdConta { get; set; }
    public string Nome { get; set; }
    public ETipoPix IdTipoChavePix { get; set; }

}
