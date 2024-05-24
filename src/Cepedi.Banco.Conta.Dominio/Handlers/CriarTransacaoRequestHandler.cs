using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;
public class CriarTransacaoRequestHandler 
    : IRequestHandler<CriarTransacaoRequest, Result<CriarTransacaoResponse>>
{
    private readonly ILogger<CriarTransacaoRequestHandler> _logger;
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly IContaRepository _contaRepository;

    public CriarTransacaoRequestHandler(ITransacaoRepository transacaoRepository, IContaRepository contaRepository, ILogger<CriarTransacaoRequestHandler> logger)
    {
        _transacaoRepository = transacaoRepository;
        _contaRepository = contaRepository;
        _logger = logger;
    }

    public async Task<Result<CriarTransacaoResponse>> Handle(CriarTransacaoRequest request, CancellationToken cancellationToken)
    {

        var contaOrigem = await _contaRepository.ObterContaAsync(request.IdContaOrigem);
        var contaDestino = await _contaRepository.ObterContaAsync(request.IdContaDestino);


        if(contaOrigem == null || contaDestino == null){
            return Result.Error<CriarTransacaoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
            ContaMensagemErrors.DadosInvalidos));
        }

        if(StatusNaoAtivo(contaOrigem.Status, contaDestino.Status)){
            return Result.Error<CriarTransacaoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
            ContaMensagemErrors.ErroStatusConta));
        }

        if(TransacaoMaiorQueSaldo(request.ValorTransacao, contaOrigem.Saldo)){
            return Result.Error<CriarTransacaoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
            ContaMensagemErrors.ErroTransacaoSaldo));
        }

        if(request.IdTipoTransacao == ETipoTransacao.Transferencia 
        && TransacaoMaiorQueLimiteTransacao(request.ValorTransacao, contaOrigem.LimiteTrasancao)){
            return Result.Error<CriarTransacaoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
            ContaMensagemErrors.ErroTransacaoLimiteTransacao));
        }

        if(request.IdTipoTransacao == ETipoTransacao.Credito 
        && TransacaoMaiorQueLimiteTransacao(request.ValorTransacao, contaOrigem.LimiteCredito)){
            return Result.Error<CriarTransacaoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
            ContaMensagemErrors.ErroTransacaoLimiteCredito));
        }

        if(TransacaoValorNegativoOuNulo(request.ValorTransacao)){
            return Result.Error<CriarTransacaoResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
            ContaMensagemErrors.ErroValorNegativoOuNulo));
        }

        contaOrigem.Saldo -= request.ValorTransacao;
        contaDestino.Saldo += request.ValorTransacao;
        await _contaRepository.AtualizarContaAsync(contaOrigem);
        await _contaRepository.AtualizarContaAsync(contaDestino);

        var transacao = new TransacaoEntity()
        {
            IdContaOrigem = request.IdContaOrigem,
            IdContaDestino = request.IdContaDestino,
            IdTipoTransacao = request.IdTipoTransacao,
            DataTransacao = request.DataTransacao,
            ValorTransacao = request.ValorTransacao
        };

        await _transacaoRepository.CriarTransacaoAsync(transacao);

        return Result.Success(new CriarTransacaoResponse(transacao.Id, transacao.DataTransacao.ToString(), transacao.ValorTransacao ));
    }

    private bool StatusNaoAtivo(EStatusConta statusOrigem, EStatusConta statusDestino){ 
        if((int)statusOrigem != 1 || (int)statusDestino != 1)
            return true;

        return false;
    }

    private bool TransacaoMaiorQueSaldo(decimal valorTransacao, decimal saldo){ 
        if(valorTransacao > saldo)
            return true;

        return false;
    }

    private bool TransacaoMaiorQueLimiteTransacao(decimal valorTransacao, decimal limiteTransacao){ 
        if(valorTransacao > limiteTransacao)
            return true;

        return false;
    }

    private bool TransacaoValorNegativoOuNulo(decimal valorTransacao){
        if(valorTransacao <= 0)
            return true;

        return false;
    }
}

