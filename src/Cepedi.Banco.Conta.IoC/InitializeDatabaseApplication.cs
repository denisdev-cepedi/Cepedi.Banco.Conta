﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Banco.Conta.Compartilhado.Enums;
using Cepedi.Banco.Conta.Dados;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cepedi.Banco.Conta.IoC;
public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.EnsureCreatedAsync();
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var usuario = new UsuarioEntity { Nome = "Denis", Celular = "71992414041", CelularValidado = true, 
            Cpf = "1234567891", DataNascimento = DateTime.Now.AddYears(-31), Email = "denis.vieira@cepedi.org.br" };

        var transacao1 = new TipoTransacaoEntity { Nome = "Debito" };
        var transacao2 = new TipoTransacaoEntity { Nome = "Credito" };
        var transacao3 = new TipoTransacaoEntity { Nome = "Transferencia" };
        var chavePix1 = new TipoChavePixEntity { Nome = "CPF" };
        var chavePix2 = new TipoChavePixEntity { Nome = "Email" };
        var chavePix3 = new TipoChavePixEntity { Nome = "Telefone" };
        var chavePix4 = new TipoChavePixEntity { Nome = "ChaveAleatoria" };

        // Default data
        // Seed, if necessary
        if (!_context.TipoTransacao.Any())
        {
            _context.TipoTransacao.Add(transacao1);
            _context.TipoTransacao.Add(transacao2);
            _context.TipoTransacao.Add(transacao3);

            await _context.SaveChangesAsync();
        }
        if (!_context.TipoChavePixTransacao.Any())
        {
            _context.TipoChavePixTransacao.Add(chavePix1);
            _context.TipoChavePixTransacao.Add(chavePix2);
            _context.TipoChavePixTransacao.Add(chavePix3);
            _context.TipoChavePixTransacao.Add(chavePix4);

            await _context.SaveChangesAsync();
        }
    }
}
