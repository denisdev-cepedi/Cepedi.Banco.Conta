using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Dominio.Entidades;

public class TipoChavePixEntity
{
    public ETipoPix Id { get; set; }
    public ICollection<ChavePixEntity>? ChavePixes { get; }
}
