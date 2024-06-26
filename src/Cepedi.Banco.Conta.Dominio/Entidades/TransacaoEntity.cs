namespace Cepedi.Banco.Conta.Dominio.Entidades;
public class TransacaoEntity
{
    public int IdTransacao { get; set; }
    public int IdContaOrigem { get; set; }
    public required ContaEntity ContaOrigem { get; set; }
    public int IdContaDestino { get; set; }
    public required ContaEntity ContaDestino { get; set; }
    public DateTime DataTransacao { get; set; }
    public int ValorTransacao { get; set; }
    public int IdTipoTransacao { get; set; }
}
