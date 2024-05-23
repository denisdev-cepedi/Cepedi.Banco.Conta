using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;
public class AtualizarContaRequestHandler : IRequestHandler<AtualizarContaRequest, Result<AtualizarContaResponse>>
{
    private readonly ILogger<AtualizarContaRequestHandler> _logger;
    private readonly IContaRepository _contaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarContaRequestHandler(IContaRepository contaRepository, IUnitOfWork unitOfWork, ILogger<AtualizarContaRequestHandler> logger)
    {
        _contaRepository = contaRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<Result<AtualizarContaResponse>> Handle(AtualizarContaRequest request, CancellationToken cancellationToken)
    {
        var contaExistente = await _contaRepository.ObterContaAsync(request.IdConta);

        if (contaExistente == null)
        {
            return Result.Error<AtualizarContaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (ContaMensagemErrors.ContaNaoExiste)));
        }

        contaExistente.Status = request.Status;
        contaExistente.LimiteTrasancao = request.LimiteTrasancao;
        contaExistente.LimiteCredito = request.LimiteCredito;

        await _contaRepository.AtualizarContaAsync(contaExistente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new AtualizarContaResponse(contaExistente.Id, contaExistente.Status, contaExistente.LimiteTrasancao, contaExistente.LimiteCredito));
    }

}