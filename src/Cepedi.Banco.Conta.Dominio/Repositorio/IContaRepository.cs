using Cepedi.Banco.Conta.Dominio.Entidades;

namespace Cepedi.Banco.Conta.Dominio.Repositorio;

public interface IContaRepository
{
    Task<ContaEntity> CriarContaAsync(ContaEntity Conta);
    Task<ContaEntity> ObterContaAsync(int id);
    Task<ContaEntity> AtualizarContaAsync(ContaEntity Conta);
}
