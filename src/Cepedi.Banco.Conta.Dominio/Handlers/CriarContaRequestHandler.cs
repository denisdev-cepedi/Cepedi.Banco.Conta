using Cepedi.Banco.Conta.Compartilhado;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;

public class CriarContaRequestHandler : IRequestHandler<CriarContaRequest, Result<CriarContaResponse>>
{
    private readonly ILogger<CriarContaRequestHandler> _logger;
    private readonly IContaRepository _contaRepository;

    public CriarContaRequestHandler(IContaRepository contaRepository, ILogger<CriarContaRequestHandler> logger)
    {
        _contaRepository = contaRepository;
        _logger = logger;
    }
    public Task<Result<CriarContaResponse>> Handle(CriarContaRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var conta = new ContaEntity()
            {
                IdPessoa = request.IdPessoa,
                Agencia = request.Agencia,
                Numero = request.Numero,
                Status = request.Status,
                LimiteTrasancao = request.LimiteTrasancao,
                LimiteCredito = request.LimiteCredito
            };

            _contaRepository.CriarContaAsync(conta);

            return Result.Success(new CriarContaResponse(conta.Id, conta.Agencia, conta.Numero));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<CriarContaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (ContaMensagemErrors.ErroGravacaoConta)));
        }
    }
}
