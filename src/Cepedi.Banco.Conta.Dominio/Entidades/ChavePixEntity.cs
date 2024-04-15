namespace Cepedi.Banco.Conta.Dominio.Entidades;
public class ChavePixEntity
{
    public int IdChavePix { get; set; }
    public int IdConta { get; set; }
    public int IdTipo { get; set; }
    public string ValorToken { get; set; }
}
