using Cepedi.Banco.Conta.Compartilhado.Enums;

namespace Cepedi.Banco.Conta.Dominio.Entidades;
public class ChavePixEntity
{
    public int Id { get; set; }
    public required int IdConta { get; set; }
    public string Nome { get; set; }
    public ContaEntity? Conta { get; set; }
    public required ETipoPix IdTipoChavePix { get; set; }
    public  TipoChavePixEntity? TipoChavePix { get; set; }

}
