using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;

public class ExtratoContaRequestHandler
    : IRequestHandler<ExtratoContaRequest, Result<ExtratoContaResponse>>
{
    public readonly ILogger<ExtratoContaRequestHandler> _logger;
    public readonly IContaRepository _contaRepositorio;
    public readonly ITransacaoRepository _transacaoRepository;

    public ExtratoContaRequestHandler(IContaRepository contaRepositorio, ITransacaoRepository transacaoRepository, ILogger<ExtratoContaRequestHandler> logger)
    {
        _contaRepositorio = contaRepositorio;
        _transacaoRepository = transacaoRepository;
        _logger = logger;
    }

    public async Task<Result<ExtratoContaResponse>> Handle(ExtratoContaRequest request, CancellationToken cancellationToken)
    {
        var conta = await _contaRepositorio.ObterContaPorIdAsync(request.IdConta);

        if (conta == null)
        {
            _logger.LogError("Conta não encontrada ao tentar obter extrato");
            return Result.Error<ExtratoContaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (ContaMensagemErrors.SemResultados)));
        }

        List<TransacaoEntity> transacoes = await _transacaoRepository.ObterTransacoesPorContaAsync(request.IdConta, request.DataInicio, request.DataFim);

        var transacoesResponse = transacoes.Select(t => new BuscarTransacaoResponse(t.Id, t.IdContaOrigem, t.IdContaDestino, t.ValorTransacao, t.DataTransacao)).ToList();
        var saldo = conta.Saldo;

        return Result.Success(new ExtratoContaResponse(conta.Id, request.DataInicio.ToString(), saldo, transacoesResponse));
    }   

}
