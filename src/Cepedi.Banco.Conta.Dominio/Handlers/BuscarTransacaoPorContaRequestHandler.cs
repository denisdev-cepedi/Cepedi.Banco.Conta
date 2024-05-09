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

public class BuscarTransacaoPorContaRequestHandler : IRequestHandler<BuscarTransacaoPorContaRequest, Result<BuscarTransacaoPorContaResponse>>
{
    private readonly ILogger<BuscarContaRequestHandler> _logger;
    private readonly IContaRepository _contaRepository;
    private readonly ITransacaoRepository _transacaoRepository;

    public BuscarTransacaoPorContaRequestHandler(
        IContaRepository contaRepository, 
        ITransacaoRepository transacaoRepository,
        ILogger<BuscarContaRequestHandler> logger)
    {
        _contaRepository = contaRepository;
        _transacaoRepository = transacaoRepository;
        _logger = logger;
    }
    public async Task<Result<BuscarTransacaoPorContaResponse>> Handle(BuscarTransacaoPorContaRequest request, CancellationToken cancellationToken)
    {
        var contaEntity = await _contaRepository.ObterContaAsync(request.IdConta);

        if (contaEntity == null)
        {
            return Result.Error<BuscarTransacaoPorContaResponse>(new
                Compartilhado.Excecoes.SemResultadosExcecao());
        }

        List<TransacaoEntity> transacoes = await _transacaoRepository.ObterTransacoesPorContaAsync(request.IdConta);

        var transacoesResponse = transacoes.Select(t => new BuscarTransacaoResponse(t.Id, t.IdContaOrigem, t.IdContaDestino, t.ValorTransacao, t.DataTransacao)).ToList();

        return Result.Success(new BuscarTransacaoPorContaResponse(request.IdConta, transacoesResponse));
    }
}