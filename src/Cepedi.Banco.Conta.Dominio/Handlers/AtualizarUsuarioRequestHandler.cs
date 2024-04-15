using Cepedi.Banco.Conta.Compartilhado.Requests;
using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Conta.Dominio.Handlers;
public class AtualizarUsuarioRequestHandler :
    IRequestHandler<AtualizarUsuarioRequest, Result<AtualizarUsuarioResponse>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ILogger<AtualizarUsuarioRequestHandler> _logger;

    public AtualizarUsuarioRequestHandler(IUsuarioRepository usuarioRepository, ILogger<AtualizarUsuarioRequestHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarUsuarioResponse>> Handle(AtualizarUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var usuarioEntity = await _usuarioRepository.ObterUsuarioAsync(request.Id);

            if (usuarioEntity == null)
            {
                return Result.Error<AtualizarUsuarioResponse>(new Compartilhado.
                    Excecoes.SemResultadosExcecao());
            }

            usuarioEntity.Atualizar(request.Nome);

            await _usuarioRepository.AtualizarUsuarioAsync(usuarioEntity);

            return Result.Success(new AtualizarUsuarioResponse(usuarioEntity.Nome));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro ao atualizar os usuários");
            throw;
        }
    }
}
