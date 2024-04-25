using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;
 public class CriarChavePixRequestHandler 
    : IRequestHandler<CriarChavePixRequest, Result<CriarChavePixResponse>>
{
    private readonly ILogger<CriarChavePixRequestHandler> _logger;
    private readonly IChavePixRepository _chavePixRepository;
    private readonly IContaRepository _contaRepository;

    public CriarChavePixRequestHandler(IChavePixRepository chavePixRepository, IContaRepository contaRepository, ILogger<CriarChavePixRequestHandler> logger)
    {
        _chavePixRepository = chavePixRepository;
        _contaRepository = contaRepository;
        _logger = logger;
    }

    public async Task<Result<CriarChavePixResponse>> Handle(CriarChavePixRequest request, CancellationToken cancellationToken)
    {
        var ChavePix = new ChavePixEntity()
        {
            IdConta = request.IdConta,
            Valor = request.Valor,
            IdTipoChavePix = request.IdTipoChavePix
        };

        await _chavePixRepository.CriarChavePixAsync(ChavePix);

        return Result.Success(new CriarChavePixResponse(ChavePix.Id));
    }
}
