using Cepedi.Banco.Conta.Dominio.Entidades;

namespace Cepedi.Banco.Conta.Dominio.Repositorio;

public interface ITransacaoRepository
{
    Task<TransacaoEntity> CriarTransacaoAsync(TransacaoEntity transacao);
    Task<TransacaoEntity> ObterTransacaoAsync(int id);
    Task<TransacaoEntity> AtualizarTransacaoAsync(TransacaoEntity transacao);
    Task<List<TransacaoEntity>> ObterTransacoesPorContaAsync(int idConta);
    Task<List<TransacaoEntity>> ObterTransacoesPorContaAsync(int idConta, DateTime dataInicio, DateTime dataFim);
    Task<List<TransacaoEntity>> ObterTransacoesPorContaAsync(int idConta, int mes, int ano);
}
