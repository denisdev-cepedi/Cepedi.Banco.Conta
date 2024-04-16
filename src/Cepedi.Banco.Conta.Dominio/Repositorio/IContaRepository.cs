using Cepedi.Banco.Conta.Dominio.Entidades;
using System.Threading.Tasks;

namespace Cepedi.Banco.Conta.Dominio.Repositorio
{
    public interface IChavePixRepository
    {
        Task<ChavePixEntity> CriarChavePixAsync(ChavePixEntity chavePix);
        Task<ChavePixEntity> ObterChavePixAsync(int id);
        Task<ChavePixEntity> AtualizarChavePixAsync(ChavePixEntity chavePix);
    }
}
