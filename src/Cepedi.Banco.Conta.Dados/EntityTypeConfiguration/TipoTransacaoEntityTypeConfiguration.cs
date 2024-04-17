using Cepedi.Banco.Conta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Conta.Dados;

public class TipoTransacaoEntityTypeConfiguration : IEntityTypeConfiguration<TipoTransacaoEntity>
{
    public void Configure(EntityTypeBuilder<TipoTransacaoEntity> builder)
    {
        builder.ToTable("TipoTransacao");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome).IsRequired();
            
    }
}

