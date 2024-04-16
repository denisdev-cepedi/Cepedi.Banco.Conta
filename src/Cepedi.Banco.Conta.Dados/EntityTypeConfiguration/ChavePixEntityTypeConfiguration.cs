using Cepedi.Banco.Conta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Conta.Dados;

public class ChavePixEntityTypeConfiguration : IEntityTypeConfiguration<ChavePixEntity>
{
    public void Configure(EntityTypeBuilder<ChavePixEntity> builder)
    {
        builder.ToTable("ChavePix");
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.TipoChavePix)
            .WithMany(c => c.ChavePixes)
            .HasForeignKey(t => t.IdTipoChavePix);
    }
}

