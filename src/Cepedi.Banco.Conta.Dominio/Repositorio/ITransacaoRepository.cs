using Cepedi.Banco.Conta.Dominio.Entidades;

namespace Cepedi.Banco.Conta.Dominio.Repositorio;

public interface ITransacaoRepository
{
    Task<TransacaoEntity> CriarTransacaoAsync(TransacaoEntity transacao);
    Task<TransacaoEntity> ObterTransacaoAsync(int id);
    Task<TransacaoEntity> AtualizarTransacaoAsync(TransacaoEntity transacao);
}
