using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cepedi.Banco.Conta.Dados.Repositories.Queries;
public abstract class BaseDapperRepository
{
    private readonly string? _connectionString;

    protected BaseDapperRepository(IConfiguration configuration)
    {
        _connectionString = 
            configuration.GetConnectionString("DefaultConnection");
    }

    public virtual async Task<IEnumerable<T>> 
        ExecuteQueryAsync<T>(string query, DynamicParameters parametros)
    {
        using var conn = GetConnection();
        conn.Open();

        var result = await conn.QueryAsync<T>(query, parametros);

        conn.Close();

        return result.ToList();
    }

    public virtual async Task<T> ExecuteQueryFirstOrDefaultAsync<T>(string query, DynamicParameters parameters)
    {
        using var conn = GetConnection();
        conn.Open();

        var result = await conn.QueryFirstOrDefaultAsync<T>(query, parameters);

        conn.Close();

        return result!;
    }

    private IDbConnection GetConnection()
    {
        var sqlConnect = new SqlConnection(_connectionString);
        return sqlConnect;
    }
}