using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
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
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CriarContaRequestHandler(
        IContaRepository contaRepository, 
        IUsuarioRepository usuarioRepository, 
        IUnitOfWork unitOfWork, 
        ILogger<CriarContaRequestHandler> logger)
    {
        _contaRepository = contaRepository;
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<Result<CriarContaResponse>> Handle(CriarContaRequest request, CancellationToken cancellationToken)
    {

        var pessoaExistente = await _usuarioRepository.ObterUsuarioAsync(request.IdPessoa);

        if (pessoaExistente == null)
        {
            return Result.Error<CriarContaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (ContaMensagemErrors.UsuarioNaoEncontrado)));
        }

        var contaExistente = await _contaRepository.ObterContaPorAgenciaNumeroAsync(request.Agencia, request.Numero);

        if (contaExistente != null)
        {
            return Result.Error<CriarContaResponse>(new Compartilhado.Excecoes.ExcecaoAplicacao(
                (ContaMensagemErrors.ContaExistente)));
        }

        var conta = new ContaEntity()
        {
            IdPessoa = request.IdPessoa,
            Agencia = request.Agencia,
            Numero = request.Numero,
            Status = request.Status,
            LimiteTrasancao = request.LimiteTrasancao,
            LimiteCredito = request.LimiteCredito,
            Saldo = request.Saldo
        };

        await _contaRepository.CriarContaAsync(conta);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new CriarContaResponse(conta.Id, conta.Agencia, conta.Numero));
    }
}
