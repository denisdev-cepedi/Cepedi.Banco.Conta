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

public class FazerDepositoContaRequestHandler : IRequestHandler<FazerDepositoContaRequest, Result<FazerDepositoContaResponse>>
{

    private readonly ILogger<FazerDepositoContaRequestHandler> _logger;
    private readonly IContaRepository _contaRepository;

    public FazerDepositoContaRequestHandler(IContaRepository contaRepository, ILogger<FazerDepositoContaRequestHandler> logger)
    {
        _contaRepository = contaRepository;
        _logger = logger;
    }

    public async Task<Result<FazerDepositoContaResponse>> Handle(FazerDepositoContaRequest request, CancellationToken cancellationToken)
    {
        var contaEntity = await _contaRepository.ObterContaAsync(request.IdConta);

        if (contaEntity == null)
        {
            return Result.Error<FazerDepositoContaResponse>(new
                Compartilhado.Excecoes.SemResultadosExcecao());
        }

        if (request.ValorDeposito < 0)
        {
            return Result.Error<FazerDepositoContaResponse>(new
                Compartilhado.Excecoes.ExcecaoAplicacao(
                ContaMensagemErrors.ErroValorNegativo));
        }

        if (contaEntity.LimiteCredito < contaEntity.Saldo + request.ValorDeposito)
        {
            return Result.Error<FazerDepositoContaResponse>(new
                Compartilhado.Excecoes.ExcecaoAplicacao(
                ContaMensagemErrors.ErroDeposito));
        }

        contaEntity.Saldo += request.ValorDeposito;

        return Result.Success(new FazerDepositoContaResponse(contaEntity.Id, contaEntity.Agencia, contaEntity.Numero, contaEntity.Saldo));
    }
}