using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;

public class BuscarTransacaoRequestHandler
    : IRequestHandler<BuscarTransacaoRequest, Result<BuscarTransacaoResponse>>
{
    public readonly ILogger<BuscarTransacaoRequestHandler> _logger;
    public readonly IContaRepository _contaRepositorio;
    public readonly ITransacaoRepository _transacaoRepository;

    public BuscarTransacaoRequestHandler(
        IContaRepository contaRepositorio,
        ITransacaoRepository transacaoRepository,
        ILogger<BuscarTransacaoRequestHandler> logger)
    {
        _contaRepositorio = contaRepositorio;
        _transacaoRepository = transacaoRepository;
        _logger = logger;
    }

    public async Task<Result<BuscarTransacaoResponse>> Handle(BuscarTransacaoRequest request, CancellationToken cancellationToken)
    {
        var transacao = await _transacaoRepository.ObterTransacaoAsync(request.IdTransacao);

        return transacao == null
            ? Result.Error<BuscarTransacaoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao((ContaMensagemErrors.SemResultados)))
            : Result.Success(new BuscarTransacaoResponse(transacao.Id, transacao.IdContaOrigem, transacao.IdContaDestino, transacao.ValorTransacao, transacao.DataTransacao));
    }

}
