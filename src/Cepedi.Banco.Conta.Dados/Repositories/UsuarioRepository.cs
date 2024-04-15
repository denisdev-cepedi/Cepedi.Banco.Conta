using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Banco.Conta.Dados.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario)
        {
            _context.Usuario.Update(usuario);

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario)
        {
            _context.Usuario.Add(usuario);
            
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<List<UsuarioEntity>> GetUsuariosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<UsuarioEntity> ObterUsuarioAsync(int id)
        {
            return await
                _context.Usuario.Where(e => e.Id == id).FirstOrDefaultAsync();
        }
    }
}
