using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;

public class BuscarExtratoPorMesRequestHandler
    : IRequestHandler<BuscarExtratoPorMesRequest, Result<BuscarExtratoPorMesResponse>>
{
    public readonly ILogger<BuscarExtratoPorMesRequestHandler> _logger;
    public readonly IContaRepository _contaRepositorio;
    public readonly ITransacaoRepository _transacaoRepository;

    public BuscarExtratoPorMesRequestHandler(
        IContaRepository contaRepositorio, 
        ITransacaoRepository transacaoRepository, 
        ILogger<BuscarExtratoPorMesRequestHandler> logger)
    {
        _contaRepositorio = contaRepositorio;
        _transacaoRepository = transacaoRepository;
        _logger = logger;
    }

    public async Task<Result<BuscarExtratoPorMesResponse>> Handle(BuscarExtratoPorMesRequest request, CancellationToken cancellationToken)
    {
        var conta = await _contaRepositorio.ObterContaAsync(request.IdConta);

        if (conta == null)
        {
            _logger.LogError("Conta não encontrada ao tentar obter extrato");
            return Result.Error<BuscarExtratoPorMesResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (ContaMensagemErrors.ContaNaoExiste)));
        }

        List<TransacaoEntity> transacoes = await _transacaoRepository.ObterTransacoesPorContaAsync(request.IdConta, request.Mes, request.Ano);

        var transacoesResponse = transacoes.Select(t => new BuscarTransacaoResponse(t.Id, t.IdContaOrigem, t.IdContaDestino, t.ValorTransacao, t.DataTransacao)).ToList();
        var saldo = conta.Saldo;

        return Result.Success(new BuscarExtratoPorMesResponse(conta.Id, DateTime.Now, saldo, transacoesResponse));
    }

}
