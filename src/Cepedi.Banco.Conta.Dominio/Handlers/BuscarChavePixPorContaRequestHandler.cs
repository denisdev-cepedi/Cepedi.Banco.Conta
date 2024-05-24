using Cepedi.Banco.Conta.Compartilhado;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;

public class BuscarChavePixPorContaRequestHandler : IRequestHandler<BuscarChavePixPorContaRequest, Result<BuscarChavePixPorContaResponse>>
{
    private readonly ILogger<BuscarChavePixPorContaRequestHandler> _logger;
    private readonly IChavePixRepository _chavePixRepository;

    public BuscarChavePixPorContaRequestHandler(IChavePixRepository chavePixRepository, ILogger<BuscarChavePixPorContaRequestHandler> logger)
    {
        _chavePixRepository = chavePixRepository;
        _logger = logger;
    }
    public async Task<Result<BuscarChavePixPorContaResponse>> Handle(BuscarChavePixPorContaRequest request, CancellationToken cancellationToken)
    {
        _logger.LogError("Chamando handler de obter conta");
        var chavesPixes = await _chavePixRepository.ObterChavePixPorContaAsync(request.IdConta);

        var listaChavePixInfo = chavesPixes.Select(chave => new ChavePixInfo
        {
            Id = chave.Id,
            Valor = chave.Valor,
            Tipo = chave.IdTipoChavePix.ToString(),
        }).ToList();
        return Result.Success(new BuscarChavePixPorContaResponse(request.IdConta, listaChavePixInfo));
    }
}