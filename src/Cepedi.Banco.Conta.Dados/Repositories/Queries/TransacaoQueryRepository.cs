using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Queries;
using Cepedi.Banco.Conta.Dominio.Servicos;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cepedi.Banco.Conta.Dados.Repositories.Queries
{
    public class TransacaoQueryRepository : BaseDapperRepository, ITransacaoQueryRepository
    {
        private readonly ICache<IEnumerable<TransacaoEntity>> _cache;

        public TransacaoQueryRepository(IConfiguration configuration, ICache<IEnumerable<TransacaoEntity>> cache)
            : base(configuration)
        {
            _cache = cache;
        }

        public async Task<IEnumerable<TransacaoEntity>> ObterTransacoesRecentesPorContaAsync(int idConta, int quantidadeTransacoes)
        {
            var cacheKey = $"TransacoesConta_{idConta}_Recentes";

            var transacoesCache = await _cache.ObterAsync(cacheKey);
            if (transacoesCache != null)
            {
                return transacoesCache;
            }

            var parametros = new DynamicParameters();
            parametros.Add("@IdConta", idConta, System.Data.DbType.Int32);
            parametros.Add("@QuantidadeTransacoes", quantidadeTransacoes, System.Data.DbType.Int32);

            var sql = @"SELECT TOP(@QuantidadeTransacoes)
                            Id,
                            IdContaOrigem,
                            IdContaDestino,
                            ValorTransacao,
                            DataTransacao
                        FROM Transacao
                        WHERE IdContaOrigem = @IdConta OR IdContaDestino = @IdConta
                        ORDER BY DataTransacao DESC";

            var transacoes = await ExecuteQueryAsync<TransacaoEntity>(sql, parametros);

            await _cache.SalvarAsync(cacheKey, transacoes);

            return transacoes;
        }

    }
}
