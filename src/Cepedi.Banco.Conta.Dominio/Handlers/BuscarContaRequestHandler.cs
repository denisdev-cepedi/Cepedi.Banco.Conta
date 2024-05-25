﻿using Cepedi.Banco.Conta.Compartilhado;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
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
    public async Task<Result<BuscarContaResponse>> Handle(BuscarContaRequest request, CancellationToken cancellationToken)
    {
        var contaEntity = await _contaRepository.ObterContaAsync(request.IdConta);

        if (contaEntity == null)
        {
            return Result.Error<BuscarContaResponse>(new
                Compartilhado.Excecoes.SemResultadosExcecao());
        }

        return Result.Success(new BuscarContaResponse(contaEntity.Id, contaEntity.IdPessoa, contaEntity.Agencia, contaEntity.Numero, contaEntity.DataCriacao, contaEntity.Status, contaEntity.LimiteTrasancao, contaEntity.LimiteCredito, contaEntity.Saldo));
    }
}