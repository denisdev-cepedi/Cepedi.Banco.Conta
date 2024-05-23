using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Excecoes;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;

public class RemoverChavePixRequestHandler : IRequestHandler<RemoverChavePixRequest, Result<RemoverChavePixResponse>>
{
    private readonly ILogger<RemoverChavePixRequestHandler> _logger;
    private readonly IChavePixRepository _chavePixRepository;

    public RemoverChavePixRequestHandler(IChavePixRepository chavePixRepository, ILogger<RemoverChavePixRequestHandler> logger)
    {
        _chavePixRepository = chavePixRepository;
        _logger = logger;
    }

    public async Task<Result<RemoverChavePixResponse>> Handle(RemoverChavePixRequest request, CancellationToken cancellationToken)
    {
        var chavePixEntity = await _chavePixRepository.ObterChavePixAsync(request.IdChavePix);

        if (chavePixEntity == null)
        {
            return Result.Error<RemoverChavePixResponse>(new ExcecaoAplicacao((ContaMensagemErrors.SemResultados)));
        }

        await _chavePixRepository.RemoverChavePixAsync(chavePixEntity);

        return Result.Success(new RemoverChavePixResponse(chavePixEntity.Id));
    }


}
