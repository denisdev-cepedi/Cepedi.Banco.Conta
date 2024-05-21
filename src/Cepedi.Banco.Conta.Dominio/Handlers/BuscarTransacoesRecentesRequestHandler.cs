using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Queries;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio;

public class BuscarTransacoesRecentesRequestHandler 
    : IRequestHandler<BuscarTransacoesRecentesRequest, Result<BuscarTransacoesRecentesResponse>>
{
    public readonly IContaRepository _contaRepositorio;
    public readonly ITransacaoQueryRepository _transacaoRepository;
    public readonly ILogger<BuscarTransacoesRecentesRequestHandler> _logger;

    public BuscarTransacoesRecentesRequestHandler(
        IContaRepository contaRepositorio,
        ITransacaoQueryRepository transacaoRepository,
        ILogger<BuscarTransacoesRecentesRequestHandler> logger)
    {
        _contaRepositorio = contaRepositorio;
        _transacaoRepository = transacaoRepository;
        _logger = logger;
    }

     public async Task<Result<BuscarTransacoesRecentesResponse>> Handle(BuscarTransacoesRecentesRequest request, CancellationToken cancellationToken)
    {
        var conta = await _contaRepositorio.ObterContaAsync(request.IdConta);
        if (conta == null)
        {
            _logger.LogWarning($"Conta com Id {request.IdConta} não encontrada.");
            return Result.Error<BuscarTransacoesRecentesResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
            (ContaMensagemErrors.ContaNaoExiste)));
        }

        var transacoes = await _transacaoRepository.ObterTransacoesRecentesPorContaAsync(request.IdConta, request.Quantidade);

        var transacoesResponse = transacoes.Select(t => new BuscarTransacaoResponse(t.Id, t.IdContaOrigem, t.IdContaDestino, t.ValorTransacao, t.DataTransacao)).ToList();

        return Result.Success(new BuscarTransacoesRecentesResponse(request.IdConta, transacoesResponse));
    }
   

}
