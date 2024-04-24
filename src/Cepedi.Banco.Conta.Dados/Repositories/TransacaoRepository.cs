using Cepedi.Banco.Conta.Compartilhado.Responses;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Cepedi.Banco.Conta.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.Banco.Conta.Dados.Repositorios
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public TransacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TransacaoEntity> CriarTransacaoAsync(TransacaoEntity transacao)
        {
            _context.Transacao.Add(transacao);
            await _context.SaveChangesAsync();
            return transacao;
        }

        public async Task<TransacaoEntity> AtualizarTransacaoAsync(TransacaoEntity conta)
        {
            _context.Transacao.Update(conta);
            await _context.SaveChangesAsync();
            return conta;
        }

        public async Task<TransacaoEntity> ObterTransacaoAsync(int id)
        {
            return await _context.Transacao.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<TransacaoEntity>> ObterTransacoesPorContaAsync(int idConta, DateTime dataInicio, DateTime dataFim)
        {            
            var transacoes = _context.Transacao
                .Where(t => t.IdContaOrigem == idConta || t.IdContaDestino == idConta)
                .Where(t => t.DataTransacao >= dataInicio && t.DataTransacao <= dataFim)
                .ToListAsync();

            return transacoes;
        }
    }
}
