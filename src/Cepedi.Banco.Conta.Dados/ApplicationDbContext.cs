using System.Diagnostics.CodeAnalysis;
using Cepedi.Banco.Conta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Banco.Conta.Dados;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<UsuarioEntity> Usuario { get; set; } = default!;
    public DbSet<ContaEntity> Conta { get; set; } = default!;
    public DbSet<TransacaoEntity> Transacao { get; set; } = default!;
    public DbSet<ChavePixEntity> ChavePix { get; set; } = default!;
    public DbSet<TipoTransacaoEntity> TipoTransacao { get; set; } = default!;
    public DbSet<TipoChavePixEntity> TipoChavePixTransacao { get; set; } = default!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
