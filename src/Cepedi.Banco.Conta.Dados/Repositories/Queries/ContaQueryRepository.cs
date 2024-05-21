using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Queries;
public class ContaQueryRepository : BaseDapperRepository, IContaQueryRepository
{
    public ContaQueryRepository(IConfiguration configuration) 
        : base(configuration)
    {
    }

    public async Task<List<ContaEntity>> ObterContasAsync(string nome)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Nome", nome, System.Data.DbType.String);

        var sql = @"SELECT 
                        IdConta, 
                        Nome,
                        Cpf
                    FROM Conta WITH(NOLOCK)
                    Where
                        Nome = @Nome";

        var retorno = await ExecuteQueryAsync
            <ContaEntity>(sql, parametros);

        return retorno.ToList();
    }
}