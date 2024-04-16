using Cepedi.Banco.Conta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Conta.Dados.EntityTypeConfiguration;
public class ContaEntityTypeConfiguration : IEntityTypeConfiguration<ContaEntity>
{
    public void Configure(EntityTypeBuilder<ContaEntity> builder)
    {
        builder.ToTable("Conta");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Agencia).IsRequired().IsFixedLength().HasMaxLength(5);
        builder.Property(c => c.Numero).IsRequired().IsFixedLength().HasMaxLength(7);
        builder.Property(c => c.IdPessoa).IsRequired();
        builder.Property(c => c.Saldo).IsRequired();

/*         builder.HasMany(c => c.TransacoesEnviadas)
            .WithOne(c => c.ContaOrigem)
            .HasForeignKey(t => t.Id);

        builder.HasMany(c => c.TransacoesRecebidas)
            .WithOne(c => c.ContaDestino)
            .HasForeignKey(t => t.Id); */

        builder.HasMany(c => c.ChavesPix)
            .WithOne(c => c.Conta)
            .HasForeignKey(t => t.IdConta)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
