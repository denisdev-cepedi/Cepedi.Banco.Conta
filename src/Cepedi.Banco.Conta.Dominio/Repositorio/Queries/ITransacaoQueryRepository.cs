using Cepedi.Banco.Conta.Dominio.Entidades;

namespace Cepedi.Banco.Conta.Dominio.Queries;

public interface ITransacaoQueryRepository
{
    Task<IEnumerable<TransacaoEntity>> ObterTransacoesRecentesPorContaAsync(int idConta, int quantidadeTransacoes);
}
