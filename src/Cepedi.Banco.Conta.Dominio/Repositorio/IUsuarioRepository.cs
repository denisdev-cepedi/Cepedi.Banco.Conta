using Cepedi.Banco.Conta.Dominio.Entidades;

namespace Cepedi.Banco.Conta.Dominio.Repositorio;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity> ObterUsuarioAsync(int id);

    Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario);
}
