using Cepedi.Banco.Conta.Domain.Entities;

namespace Cepedi.Banco.Conta.Domain.Repository;

public interface IContaRepository
{
    Task<ContaEntity> CriarContaAsync(ContaEntity Conta);
    Task<ContaEntity> ObterContaAsync(int id);
    Task<ContaEntity> AtualizarContaAsync(ContaEntity Conta);
}
