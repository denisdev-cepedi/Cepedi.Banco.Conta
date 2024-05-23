using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cepedi.Banco.Conta.Dados.Repositorios
{
    public class ChavePixRepository : IChavePixRepository
    {
        private readonly ApplicationDbContext _context;

        public ChavePixRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChavePixEntity> CriarChavePixAsync(ChavePixEntity chavePix)
        {
            _context.ChavePix.Add(chavePix);
            await _context.SaveChangesAsync();
            return chavePix;
        }

        public async Task<ChavePixEntity> AtualizarChavePixAsync(ChavePixEntity chavePix)
        {
            _context.ChavePix.Update(chavePix);
            await _context.SaveChangesAsync();
            return chavePix;
        }

        public async Task<ChavePixEntity> ObterChavePixAsync(int id)
        {
            return await _context.ChavePix.FirstOrDefaultAsync(cp => cp.Id == id);
        }

        public async Task<ICollection<ChavePixEntity>> ObterChavePixPorContaAsync(int ContaId)
        {
            return await _context.ChavePix.Where(cp => cp.IdConta == ContaId).ToListAsync();
        }

        public async Task<ChavePixEntity> RemoverChavePixAsync(ChavePixEntity chavePix)
        {
            _context.ChavePix.Remove(chavePix);
            await _context.SaveChangesAsync();
            return chavePix;
        }
    }
}
