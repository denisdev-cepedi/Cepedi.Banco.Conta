using Cepedi.Banco.Conta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Conta.Dados;

public class TransacaoEntityTypeConfiguration : IEntityTypeConfiguration<TransacaoEntity>
{
    public void Configure(EntityTypeBuilder<TransacaoEntity> builder)
    {
        builder.ToTable("Transacao");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.DataTransacao).IsRequired();

        builder.HasOne(c => c.TipoTransacao)
            .WithMany(c => c.Transacoes)
            .HasForeignKey(t => t.IdTipoTransacao);

        builder.HasOne(c => c.ContaOrigem)
            .WithMany(c => c.TransacoesRecebidas)
            .HasForeignKey(t => t.IdContaOrigem)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.ContaDestino)
            .WithMany(c => c.TransacoesEnviadas)
            .HasForeignKey(t => t.IdContaDestino)
            .OnDelete(DeleteBehavior.Restrict);    
    }
}

