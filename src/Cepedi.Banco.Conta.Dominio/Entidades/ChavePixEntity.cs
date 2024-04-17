namespace Cepedi.Banco.Conta.Dominio.Entidades;
public class ChavePixEntity
{
    public int Id { get; set; }
    public int IdConta { get; set; }
    public required ContaEntity Conta { get; set; }
    public int IdTipoChavePix { get; set; }
    public required TipoChavePixEntity TipoChavePix { get; set; }
}
