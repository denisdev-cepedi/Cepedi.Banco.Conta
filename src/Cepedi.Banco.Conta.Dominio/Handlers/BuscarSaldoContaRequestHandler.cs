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

public class BuscarSaldoContaRequestHandler 
    : IRequestHandler<BuscarSaldoContaRequest, Result<BuscarSaldoContaResponse>>
{
    private readonly ILogger<BuscarSaldoContaRequestHandler> _logger;
    private readonly IContaRepository _contaRepository;

    public BuscarSaldoContaRequestHandler(
        IContaRepository contaRepository, 
        ILogger<BuscarSaldoContaRequestHandler> logger)
    {
        _contaRepository = contaRepository;
        _logger = logger;
    }
    public async Task<Result<BuscarSaldoContaResponse>> Handle(BuscarSaldoContaRequest request, CancellationToken cancellationToken)
    {
        var contaEntity = await _contaRepository.ObterContaAsync(request.IdConta);

        if (contaEntity == null)
        {
            _logger.LogError("Conta não encontrada");
            return Result.Error<BuscarSaldoContaResponse>(new
                Compartilhado.Excecoes.SemResultadosExcecao());
        }

        return Result.Success(new BuscarSaldoContaResponse(contaEntity.Id, contaEntity.Agencia, contaEntity.Numero, contaEntity.Saldo));  
    }
}