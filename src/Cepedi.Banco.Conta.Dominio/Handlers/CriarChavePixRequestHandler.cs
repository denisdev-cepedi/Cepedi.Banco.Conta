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
        var conta = await _contaRepository.ObterContaAsync(request.IdConta);

        if (conta == null)
        {
            return Result.Error<CriarChavePixResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao ((ContaMensagemErrors.ContaNaoExiste)));
        }

        var chavePix = new ChavePixEntity()
        {
            IdConta = request.IdConta,
            Valor = request.Valor,
            IdTipoChavePix = request.IdTipoChavePix
        };

        var chavePixEntity = await _chavePixRepository.CriarChavePixAsync(chavePix);

        return Result.Success(new CriarChavePixResponse(chavePixEntity.Id));
    }
}
