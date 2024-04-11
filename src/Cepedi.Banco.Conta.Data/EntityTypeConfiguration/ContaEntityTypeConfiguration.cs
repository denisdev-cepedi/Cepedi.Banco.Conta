using Cepedi.Banco.Conta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Conta.Data.EntityTypeConfiguration;
public class ContaEntityTypeConfiguration : IEntityTypeConfiguration<ContaEntity>
{
    public void Configure(EntityTypeBuilder<ContaEntity> builder)
    {
        builder.ToTable("Conta");
        builder.HasKey(c => c.IdConta); // Define a chave primária

        builder.Property(c => c.Agencia).IsRequired().IsFixedLength().HasMaxLength(5);
        builder.Property(c => c.Numero).IsRequired().IsFixedLength().HasMaxLength(7);
        builder.Property(c => c.IdPessoa).IsRequired();
        builder.Property(c => c.Saldo).IsRequired();
        builder.Property(c => c.Transacoes);

        builder.HasMany(c => c.Transacoes)
            .WithOne(c => c.ContaOrigem)
            .HasForeignKey(t => t.IdTransacao);
    }
}
