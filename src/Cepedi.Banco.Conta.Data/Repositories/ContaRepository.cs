using Cepedi.Banco.Conta.Domain;
using Cepedi.Banco.Conta.Domain.Entities;
using Cepedi.Banco.Conta.Domain.Repository;
using Microsoft.EntityFrameworkCore;

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

