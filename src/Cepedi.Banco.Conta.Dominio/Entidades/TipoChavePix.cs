namespace Cepedi.Banco.Conta.Dominio.Entidades;

public class TipoChavePixEntity
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<ChavePixEntity>? ChavePixes { get; }
}
