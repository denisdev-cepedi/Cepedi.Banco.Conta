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

        builder.Property(c => c.Agencia).IsRequired().IsFixedLength().HasMaxLength(4);
        builder.Property(c => c.Numero).IsRequired().IsFixedLength().HasMaxLength(6);
        builder.Property(c => c.IdPessoa).IsRequired();
        builder.Property(c => c.DataCriacao).IsRequired();
        builder.Property(c => c.Status).IsRequired();
        builder.Property(c => c.Saldo).IsRequired();

        builder.Property(c => c.DataCriacao).HasDefaultValueSql("GETDATE()");

        builder.HasMany(c => c.ChavesPix)
            .WithOne(c => c.Conta)
            .HasForeignKey(t => t.IdConta)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
