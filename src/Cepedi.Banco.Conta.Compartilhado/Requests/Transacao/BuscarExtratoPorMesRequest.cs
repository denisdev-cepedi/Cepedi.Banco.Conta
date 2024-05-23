using Cepedi.Banco.Conta.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Conta.Compartilhado.Requests;

public class BuscarExtratoPorMesRequest : IRequest<Result<BuscarExtratoPorMesResponse>>, IValida
{
    public int IdConta { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
}
