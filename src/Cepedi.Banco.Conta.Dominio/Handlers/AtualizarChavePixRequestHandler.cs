using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;
public class AtualizarChavePixRequestHandler :
    IRequestHandler<AtualizarChavePixRequest, Result<AtualizarChavePixResponse>>
{
    private readonly IChavePixRepository _chavePixRepository;
    private readonly ILogger<AtualizarChavePixRequestHandler> _logger;

    public AtualizarChavePixRequestHandler(IChavePixRepository chavePixRepository, ILogger<AtualizarChavePixRequestHandler> logger)
    {
        _chavePixRepository = chavePixRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarChavePixResponse>> Handle(AtualizarChavePixRequest request, CancellationToken cancellationToken)
    {

        var chavePixEntity = await _chavePixRepository.ObterChavePixAsync(request.IdChavePix);

        if (chavePixEntity == null)
        {
            _logger.LogError("ChavePix não encontrada para atualização");
            return Result.Error<AtualizarChavePixResponse>(new Compartilhado.
                Excecoes.SemResultadosExcecao());
        }

        chavePixEntity.IdConta = request.IdConta;
        chavePixEntity.Nome = request.Nome;
        chavePixEntity.IdTipoChavePix = request.IdTipoChavePix;

        await _chavePixRepository.AtualizarChavePixAsync(chavePixEntity);

        return Result.Success(new AtualizarChavePixResponse(chavePixEntity.Id, chavePixEntity.Nome, chavePixEntity.IdTipoChavePix.ToString()));
    }

}
