using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;

namespace Cepedi.Banco.Conta.Data.Repositories;
public class ContaRepository : IContaRepository
{
    public Task<ContaEntity> CriarContaAsync(ContaEntity Conta)
    {
        throw new NotImplementedException();
    }
    
    public Task<ContaEntity> AtualizarContaAsync(ContaEntity Conta)
    {
        throw new NotImplementedException();
    }


    public Task<ContaEntity> ObterContaAsync(int id)
    {
        throw new NotImplementedException();
    }
}

