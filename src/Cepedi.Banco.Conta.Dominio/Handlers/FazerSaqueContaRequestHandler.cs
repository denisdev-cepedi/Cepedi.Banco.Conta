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

public class FazerSaqueContaRequestHandler : IRequestHandler<FazerSaqueContaRequest, Result<FazerSaqueContaResponse>>
{

    private readonly ILogger<FazerSaqueContaRequestHandler> _logger;
    private readonly IContaRepository _contaRepository;

    public FazerSaqueContaRequestHandler(IContaRepository contaRepository, ILogger<FazerSaqueContaRequestHandler> logger)
    {
        _contaRepository = contaRepository;
        _logger = logger;
    }

    public async Task<Result<FazerSaqueContaResponse>> Handle(FazerSaqueContaRequest request, CancellationToken cancellationToken)
    {
        var contaEntity = await _contaRepository.ObterContaAsync(request.IdConta);

        if (contaEntity == null){
            return Result.Error<FazerSaqueContaResponse>(new
                Compartilhado.Excecoes.SemResultadosExcecao());
        }

        if(SaqueValorNegativoOuNulo(request.ValorSaque)){
            return Result.Error<FazerSaqueContaResponse>(new
                Compartilhado.Excecoes.ExcecaoAplicacao(
                ContaMensagemErrors.ErroValorNegativo));
        }

        if(SaqueMaiorQueSaldo(request.ValorSaque, contaEntity.Saldo) ){
            return Result.Error<FazerSaqueContaResponse>(new
                Compartilhado.Excecoes.ExcecaoAplicacao(
                ContaMensagemErrors.ErroSaque));
        }

        contaEntity.Saldo -= request.ValorSaque;

        await _contaRepository.AtualizarContaAsync(contaEntity);

        return Result.Success(new FazerSaqueContaResponse(contaEntity.Id, contaEntity.Agencia, contaEntity.Numero, contaEntity.Saldo));
    }

    private bool SaqueValorNegativoOuNulo(decimal valorSaque){
        if(valorSaque <= 0)
            return true;

        return false;
    }

    private bool SaqueMaiorQueSaldo(decimal valorSaque, decimal saldo){ 
        if(valorSaque > saldo)
            return true;

        return false;
    }
}