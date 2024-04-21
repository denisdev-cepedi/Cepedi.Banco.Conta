﻿using Cepedi.Banco.Conta.Compartilhado;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;

public class BuscarContaRequestHandler : IRequestHandler<BuscarContaRequest, Result<BuscarContaResponse>>
{
    private readonly ILogger<BuscarContaRequestHandler> _logger;
    private readonly IContaRepository _contaRepository;

    public BuscarContaRequestHandler(IContaRepository contaRepository, ILogger<BuscarContaRequestHandler> logger)
    {
        _contaRepository = contaRepository;
        _logger = logger;
    }
    public Task<Result<BuscarContaResponse>> Handle(BuscarContaRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var contaEntity = await _contaRepository.ObterContaAsync(request.Id);

            if (contaEntity == null)
            {
                return Result.Error<BuscarContaResponse>(new
                    Compartilhado.Excecoes.SemResultadosExcecao());
            }

            return Result.Success(new BuscarContaResponse(conta.IdConta, conta.Agencia, conta.Numero));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<BuscarContaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (ContaMensagemErrors.SemResultados)));
        }
    }
}