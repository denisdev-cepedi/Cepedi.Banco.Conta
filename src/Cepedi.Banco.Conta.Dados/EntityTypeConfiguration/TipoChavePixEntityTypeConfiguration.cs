using Cepedi.Banco.Conta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Conta.Dados;

public class TipoChavePixEntityTypeConfiguration : IEntityTypeConfiguration<TipoChavePixEntity>
{
    public void Configure(EntityTypeBuilder<TipoChavePixEntity> builder)
    {
        builder.ToTable("TipoChavePix");
        builder.HasKey(c => c.Id);
            
    }
}