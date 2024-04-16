using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.Banco.Conta.Dados.Repositorios
{
    public class ContaRepository : IContaRepository
    {
        private readonly ApplicationDbContext _context;

        public ContaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContaEntity> CriarContaAsync(ContaEntity conta)
        {
            _context.Conta.Add(conta);
            await _context.SaveChangesAsync();
            return conta;
        }

        public async Task<ContaEntity> AtualizarContaAsync(ContaEntity conta)
        {
            _context.Conta.Update(conta);
            await _context.SaveChangesAsync();
            return conta;
        }

        public async Task<ContaEntity> ObterContaAsync(int id)
        {
            return await _context.Conta.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
